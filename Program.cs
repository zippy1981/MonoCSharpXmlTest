using System;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using MongoDB.Bson;

using MongoDB.Bson.IO;


namespace ConsoleApplication1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var settings = new JsonWriterSettings { Indent = true };


            // Its XML Time
            using (var strm = Assembly.GetExecutingAssembly().GetManifestResourceStream("ConsoleApplication1.SomeXml.xml"))
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(strm);

                Console.Write("XML: ");
                Console.WriteLine(xmlDocument.OuterXml);
                Console.WriteLine();

                Console.Write("XML2JSON: ");
                Console.WriteLine(xmlDocument.DocumentElement.ToBsonDocument().ToJson(settings));
                Console.WriteLine();
            }

            Console.WriteLine("Press Any Key To Continue . . .");
            Console.ReadKey(true);
        }
    }
}
