using System.Xml;
using Packt.Shared;

SectionTitle("Writing to text streams");

string textFile = Combine(CurrentDirectory, "streams.txt");
StreamWriter text = File.CreateText(textFile);

foreach (string item in Viper.Callsigns)
{
    text.WriteLine(item);
}
text.Close();

OutputFileInfo(textFile);

WriteLine();

SectionTitle("Writing to XML streams:");

string xmlFile = Combine(CurrentDirectory, "streams.xml");
FileStream? xmlFileStream = null;
XmlWriter? xml = null;

try
{
    xmlFileStream = File.Create(xmlFile);

    // Wrap file stream in XML writer helper and tell it to automatically indent nested elements
    xml = XmlWriter.Create(xmlFileStream,
        new XmlWriterSettings { Indent = true });

    xml.WriteStartDocument();
    xml.WriteStartElement("callsigns");

    foreach (string item in Viper.Callsigns)
    {
        xml.WriteElementString("callsign", item);
    }

    xml.WriteEndElement();
}
catch (Exception ex)
{
    // If path doesn't exist exception will be caught
    WriteLine($"{ex.GetType()} says {ex.Message}");
}
finally
{
    if (xml is not null)
    {
        xml.Close();
        WriteLine("The XML writer's unmanaged resources have been disposed.");
    }

    if (xmlFileStream is not null)
    {
        xmlFileStream.Close();
        WriteLine("The file stream's unmanaged resources have been disposed.");
    }
}

OutputFileInfo(xmlFile);