using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;
using iText.Layout.Properties;

namespace PDFManupulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title = "Monthly Sales Report";
            string text = "Total Sales: $10,000";
            string imagePath = @"C:\DotNetProjectsMS\Git\DotNet_Tasks\MileStone_Assessment\PDFManupulation\input\OIP (1).jfif";
            string pdfFilePath = @"C:\DotNetProjectsMS\Git\DotNet_Tasks\MileStone_Assessment\PDFManupulation\Output\SalesReport.pdf";

            try
            {
                // Check if the directory exists, if not, create it
                string directoryPath = Path.GetDirectoryName(pdfFilePath);
                if (!Directory.Exists(directoryPath))
                {
                    Console.WriteLine("Directory does not exist. Creating directory...");
                    Directory.CreateDirectory(directoryPath);
                }

                // Generate PDF
                GeneratePdf(pdfFilePath, title, text, imagePath);
                Console.WriteLine($"PDF successfully generated at: {pdfFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
            }
        }
        static void GeneratePdf(string pdfFilePath, string title, string text, string imagePath)
        {
            // Step 1: Create a PdfWriter
            using (PdfWriter writer = new PdfWriter(pdfFilePath))
            {
                // Step 2: Initialize PdfDocument
                using (PdfDocument pdfDoc = new PdfDocument(writer))
                {
                    // Step 3: Initialize Document
                    Document doc = new Document(pdfDoc);

                    // Step 4: Add Title to the PDF
                    doc.Add(new Paragraph(title)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(18)
                        .SetBold());

                    // Step 5: Add Text to the PDF
                    doc.Add(new Paragraph(text)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetFontSize(12));

                    // Step 6: Add Image to the PDF (if the image exists)
                    if (File.Exists(imagePath))
                    {
                        Image img = new Image(ImageDataFactory.Create(imagePath));
                        img.SetWidth(300); // Resize the image if necessary
                        img.SetHeight(200);
                        img.SetTextAlignment(TextAlignment.CENTER);
                        doc.Add(img);
                    }
                    else
                    {
                        throw new FileNotFoundException($"Image file not found at: {imagePath}");
                    }
                }
            }
        }
    }
}