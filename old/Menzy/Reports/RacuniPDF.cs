using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Menzy.Models;
using System.IO;
using System.Web.Hosting;

namespace Menzy.Reports
{
    public class RacuniPDF
    {
        private ApplicationDbContext _context;
        public RacuniPDF() {
            _context = new ApplicationDbContext();

        }

        public byte[] Podaci { get; private set; }
        public void GenerirajPDF(List<Stavka> stavke)
        {
            BaseFont bfontHeader = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false);
            BaseFont bfontText = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            BaseFont bfontFooter = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1250, false);

            Font header = new Font(bfontHeader, 12, Font.NORMAL, BaseColor.DARK_GRAY);
            Font headerBold = new Font(bfontHeader, 12, Font.BOLD, BaseColor.DARK_GRAY);
            Font naslov = new Font(bfontHeader, 14, Font.BOLDITALIC, BaseColor.DARK_GRAY);
            Font tekst = new Font(bfontHeader, 10, Font.NORMAL, BaseColor.BLACK);

            using (MemoryStream memo = new MemoryStream())
            {

                using (Document pdfDokument = new Document(PageSize.A4, 50, 50, 20, 50))
                {
                    PdfWriter.GetInstance(pdfDokument, memo).CloseStream = false;
                    pdfDokument.Open();
                    var logo = iTextSharp.text.Image.GetInstance(HostingEnvironment.MapPath("~/images/mev.jpg"));
                    logo.Alignment = Element.ALIGN_LEFT;
                    logo.ScaleAbsoluteWidth(50);
                    logo.ScaleAbsoluteHeight(50);

                    Paragraph info = new Paragraph();
                    info.Add(new Chunk("Studentska menza Čakovec - Menzy \n", headerBold));
                    info.Add(new Chunk("BANA JOSIPA JELAČIĆA 22a \n" + "Čakovec \n", header));

                    PdfPTable tableHeader;
                    tableHeader = new PdfPTable(2);
                    tableHeader.HorizontalAlignment = Element.ALIGN_LEFT;
                    tableHeader.DefaultCell.Border = Rectangle.NO_BORDER;
                    tableHeader.WidthPercentage = 100f;
                    float[] widthsTableHeader = null;
                    widthsTableHeader = new float[] { 1f, 3f };
                    tableHeader.SetWidths(widthsTableHeader);

                    PdfPCell cLogo = null;
                    cLogo = new PdfPCell(logo);
                    cLogo.Border = Rectangle.NO_BORDER;
                    tableHeader.AddCell(cLogo);

                    PdfPCell cInfo = new PdfPCell(info);
                    cInfo.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    cInfo.Border = Rectangle.NO_BORDER;
                    tableHeader.AddCell(cInfo);
                    pdfDokument.Add(tableHeader);

                    Paragraph p = new Paragraph("Račun", naslov);
                    p.Alignment = Element.ALIGN_CENTER;
                    p.SpacingAfter = 20;
                    p.SpacingAfter = 20;
                    pdfDokument.Add(p);

                    BaseColor colorHeader = BaseColor.LIGHT_GRAY;

                    //tablica
                    PdfPTable t = new PdfPTable(5);
                    t.WidthPercentage = 100;
                    t.SetWidths(new float[] { 3, 2, 1, 3, 2 });


                    //definiramo zaglavlja tablice
                    t.AddCell(VratiCeliju("Artikl", tekst, colorHeader, true));
                    t.AddCell(VratiCeliju("Tip hrane", tekst, colorHeader, true));
                    t.AddCell(VratiCeliju("Broj", tekst, colorHeader, true));
                    t.AddCell(VratiCeliju("Cijena artikla", tekst, colorHeader, true));
                    t.AddCell(VratiCeliju("Cijena ukupno", tekst, colorHeader, true));

                    int i = 1;//brojač redova                   
                    foreach (Stavka s in stavke)
                    {
                        t.AddCell(VratiCeliju(s.Food.Name, tekst, BaseColor.WHITE, false));
                        t.AddCell(VratiCeliju(s.Food.TipHrane, tekst, BaseColor.WHITE, false));
                        t.AddCell(VratiCeliju(s.Quantity.ToString(), tekst, BaseColor.WHITE, false));
                        t.AddCell(VratiCeliju(s.Food.Price.ToString(), tekst, BaseColor.WHITE, false));
                        t.AddCell(VratiCeliju((s.Food.Price * s.Quantity).ToString(), tekst, BaseColor.WHITE, false));

                        i++;
                    }

                    pdfDokument.Add(t);

                    //mjesto i vrijeme
                    p = new Paragraph("Čakovec, " + DateTime.Now.ToString("dd.MM.yyyy"), tekst);
                    p.Alignment = Element.ALIGN_RIGHT;
                    p.SpacingBefore = 30;
                    pdfDokument.Add(p);
                }

                Podaci = memo.ToArray();

                using (var reader = new PdfReader(Podaci))
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var stamper = new PdfStamper(reader, ms))
                        {
                            int PageCount = reader.NumberOfPages;
                            for (int i = 1; i <= PageCount; i++)
                            {
                                Rectangle pageSize = reader.GetPageSize(i);
                                PdfContentByte canvas = stamper.GetOverContent(i);

                                canvas.BeginText();
                                canvas.SetFontAndSize(bfontFooter, 10);

                                canvas.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, $"Stranica {i} / {PageCount}", pageSize.Right - 50, 30, 0);
                                canvas.EndText();
                            }
                        }
                        Podaci = ms.ToArray();
                    }
                }
            }
        }

        private PdfPCell VratiCeliju(string labela, Font font, BaseColor boja, bool wrap)
        {
            PdfPCell c1 = new PdfPCell(new Phrase(labela, font));
            c1.BackgroundColor = boja;
            c1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            c1.Padding = 5;
            c1.NoWrap = wrap;

            return c1;
        }


    }
}
