using System.Xml.Linq;

namespace ParsingXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("Productsxml.xml");

            // Add a new product
            XElement newProduct = new XElement("Product",
                new XElement("ID", "4"),
                new XElement("Name", "Smartwatch"),
                new XElement("Price", "250"),
                new XElement("Stock", "15")
            );
            doc.Root.Add(newProduct);

            foreach (var product in doc.Root.Elements("Product"))
            {
                var id = (string)product.Element("ID");
                var stock = (int)product.Element("Stock");
                if (id == "2" && stock > 30)
                {
                    product.Element("Price").Value = "850";
                }
            }

            var lowStockProducts = doc.Root.Elements("Product")
                .Where(p => (int)p.Element("Stock") < 10)
                .ToList();

            foreach (var product in lowStockProducts)
            {
                product.Remove();
            }

            var sortedProducts = doc.Root.Elements("Product")
                .OrderBy(p => (int)p.Element("ID"))
                .ToList();

            doc.Root.RemoveAll();
            doc.Root.Add(sortedProducts);

            doc.Save("Products.xml");

            Console.WriteLine(doc);
        }
    }
}