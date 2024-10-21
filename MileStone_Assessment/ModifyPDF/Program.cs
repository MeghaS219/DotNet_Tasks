using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace ModifyPDF
{
    class Program
    {
        // Define a simple class to hold the CSV data
        public class Record
        {
            public string Name { get; set; }
            public int Amount { get; set; }
        }

        static void Main(string[] args)
        {
            string csvFilePath = @"C:\DotNetProjectsMS\Git\DotNet_Tasks\MileStone_Assessment\PDFManupulation\input\data.csv"; // Path to your CSV file
            string pdfFilePath = @"C:\DotNetProjectsMS\Git\DotNet_Tasks\MileStone_Assessment\PDFManupulation\Output\SummaryReport.pdf"; // Path where the PDF will be saved

            try
            {
                // Step 1: Parse CSV
                var records = ReadCsv(csvFilePath);

                // Step 2: Generate PDF report
                GeneratePdfReport(pdfFilePath, records);

                Console.WriteLine("PDF Report generated successfully at: " + pdfFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Step 1: Function to read CSV data using CsvHelper
        static List<Record> ReadCsv(string filePath)
        {
            var records = new List<Record>();
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HeaderValidated = null, MissingFieldFound = null }))
                {
                    records = csv.GetRecords<Record>().ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading CSV: " + ex.Message);
            }
            return records;
        }

        // Step 2: Function to generate PDF with data from the CSV
        static void GeneratePdfReport(string pdfFilePath, List<Record> records)
        {
            using (var writer = new PdfWriter(pdfFilePath))
            using (var pdf = new PdfDocument(writer))
            {
                var document = new Document(pdf);

                // Title of the PDF report
                document.Add(new Paragraph("Summary Report")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(18)
                    .SetBold());

                // Create the table (2 columns)
                var table = new Table(2);  // 2 columns for Name and Amount

                // Set column widths as percentages of the total width (100%)
                float[] columnWidths = { 200f, 150f };  // Adjust the proportions as needed (e.g., Name takes 60%, Amount takes 40%)
                table.SetWidth(columnWidths[0]);
            

                // Add table headers
                table.AddHeaderCell(new Cell().Add(new Paragraph("Name")).SetBold().SetTextAlignment(TextAlignment.CENTER));
                table.AddHeaderCell(new Cell().Add(new Paragraph("Amount")).SetBold().SetTextAlignment(TextAlignment.CENTER));

                // Add rows to the table from the CSV records
                foreach (var record in records)
                {
                    table.AddCell(new Paragraph(record.Name).SetTextAlignment(TextAlignment.LEFT));
                    table.AddCell(new Paragraph(record.Amount.ToString()).SetTextAlignment(TextAlignment.RIGHT));
                }

                // Add the table to the document
                document.Add(table);

                // Close the document to finalize the PDF
                document.Close();
            }
        }
    }
}
