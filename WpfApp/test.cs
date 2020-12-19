using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace WpfApp
{
    class test
    {
    }
}

    class Plant
    {
        public string Common { get; set; }
        public string Botanical { get; set; }
        public string Zone { get; set; }
        public string Light { get; set; }
        public string Price { get; set; }
        public string Availability { get; set; }
        public Plant(string common, string botanical, string zone, string light, string price, string availability)
        {
            Common = common;
            Botanical = botanical;
            Zone = zone;
            Light = light;
            Price = price;
            Availability = availability;
        }
        public Plant()
        {

        }
        public override string ToString()
        {
            return string.Format("Common: {0}\n Botanical: {1}\n Zone: {2}\n Light: {3}\n Price: {4}\n Availability: {5}",
               Common, Botanical, Zone, Light, Price, Availability);
        }

    }
    enum ReaderType
    {
        stream,
        xml
    }
    class WorkWithFile : IDisposable
    {
        private List<Plant> plants;
        private string fileName;
        private StreamReader streamReader = null;
        private StreamWriter streamWriter = null;
        private XmlTextReader xmlReader = null;
        private XmlTextWriter xmlWriter = null;
        private bool disposedValue = false;
        private ReaderType readerType;

        public WorkWithFile(string name, ReaderType rType)
        {
            fileName = name;
            plants = new List<Plant>();
            readerType = rType;

        }
        public void ReadFromFile()
        {
            if (disposedValue)
            {
                throw new ObjectDisposedException(fileName);
            }

            using (streamReader = File.OpenText(fileName))
            {
                List<string> temp = new List<string>();
                if (readerType == ReaderType.stream)
                {
                    Console.WriteLine("Welcome to StreamReader!");
                    string pattern = @"(?<=\>)(.*)(?=\<)";
                    string input = null;
                    while ((input = streamReader.ReadLine()) != null)
                    {
                        foreach (Match match in Regex.Matches(input, pattern))
                        {
                            temp.Add(match.Value);
                        }
                        if (temp.Count == 6)
                        {
                            plants.Add(new Plant(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5]));
                            temp.Clear();
                        }
                    }
                }
                else
                {
                    using (xmlReader = new XmlTextReader(fileName))
                    {
                        Console.WriteLine("Welcome to XMLReader!");
                        while (xmlReader.Read())
                        {
                            switch (xmlReader.NodeType)
                            {
                                case XmlNodeType.Text:
                                    temp.Add(xmlReader.Value);
                                    break;
                            }
                            if (temp.Count == 6)
                            {
                                plants.Add(new Plant(temp[0], temp[1], temp[2], temp[3], temp[4], temp[5]));
                                temp.Clear();
                            }
                        }
                    }
                }
            }
        }


        public void WriteToFile()
        {
            if (disposedValue)
            {
                throw new ObjectDisposedException(fileName);
            }
            Console.WriteLine("Введите имя файла с требуемым расширением:");
            string name = Console.ReadLine();
            using (streamWriter = File.CreateText(name))
            {
                if (readerType == ReaderType.xml)
                {
                    using (xmlWriter = new XmlTextWriter(streamWriter))
                    {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("CATALOG");
                        xmlWriter.WriteWhitespace("\n");
                        foreach (Plant val in plants)
                        {
                            xmlWriter.WriteStartElement("PLANT");
                            xmlWriter.WriteElementString("COMMON", val.Common);
                            xmlWriter.WriteElementString("BOTANICAL", val.Botanical);
                            xmlWriter.WriteElementString("ZONE", val.Zone);
                            xmlWriter.WriteElementString("LIGHT", val.Light);
                            xmlWriter.WriteElementString("PRICE", val.Price);
                            xmlWriter.WriteElementString("AVAILABILITY", val.Availability);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteWhitespace("\n");
                        }
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                    }
                    Console.WriteLine("Файл: {0} создан с помощью XMLWriter", name);
                }
                else
                {
                    streamWriter.WriteLine("<CATALOG>");
                    foreach (Plant val in plants)
                    {
                        streamWriter.Write(new string(' ', 2));
                        streamWriter.WriteLine("<PLANT>");
                        streamWriter.WriteLine("\t" + "<COMMON>" + val.Common + "</COMMON>");
                        streamWriter.WriteLine("\t" + "<BOTANICAL>" + val.Botanical + "</BOTANICAL>");
                        streamWriter.WriteLine("\t" + "<ZONE>" + val.Zone + "</ZONE>");
                        streamWriter.WriteLine("\t" + "<LIGHT>" + val.Light + "</LIGHT>");
                        streamWriter.WriteLine("\t" + "<PRICE>" + val.Price + "</PRICE>");
                        streamWriter.WriteLine("\t" + "<AVAILABILITY>" + val.Availability + "</AVAILABILITY>");
                        streamWriter.Write(new string(' ', 2));
                        streamWriter.WriteLine("</PLANT>");
                    }
                    streamWriter.WriteLine("</CATALOG>");
                    Console.WriteLine("Файл: {0} создан с помощью StreamWriter", name);
                }
            }
        }


        public void ShowList()
        {
            foreach (Plant val in plants)
            {
                Console.WriteLine(val);
            }
        }

        //Реализация шаблона Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Console.WriteLine("Список очищен");
                    plants = null;
                }
                if (xmlReader != null)
                {
                    Console.WriteLine("Очистка ресурсов xmlReader");
                    xmlReader.Close();
                    xmlReader = null;
                }
                if (xmlWriter != null)
                {
                    Console.WriteLine("Очистка ресурсов xmlWriter");
                    xmlWriter.Close();
                    xmlWriter = null;
                }
                if (streamReader != null)
                {
                    Console.WriteLine("Очистка ресурсов streamReader");
                    streamReader.Close();
                    streamReader = null;
                }
                if (streamWriter != null)
                {
                    Console.WriteLine("Очистка ресурсов streamWriter");
                    streamWriter.Close();
                    streamWriter = null;
                }

                disposedValue = true;
            }
        }

        ~WorkWithFile()
        {
            Dispose(false);
        }

    }
