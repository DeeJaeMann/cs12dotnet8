using System.IO.Compression; // For BrotliStream, GZipStream
using System.Xml; // For XmlWriter, XmlReader
using Packt.Shared;

partial class Program
{
    private static void Compress(string algorithm = "gzip")
    {
        string filePath = Combine(CurrentDirectory, $"streams.{algorithm}");

        FileStream file = File.Create(filePath);
        Stream compressor;
        if (algorithm == "gzip")
        {
            compressor = new GZipStream(file, CompressionMode.Compress);
        }
        else
        {
            compressor = new BrotliStream(file, CompressionMode.Compress);
        }

        using (compressor)
        {
            using (XmlWriter xml = XmlWriter.Create(compressor))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement("callsigns");
                foreach (string item in Viper.Callsigns)
                {
                    xml.WriteElementString("callsign", item);
                }
            }
        } // Also closes underlying stream

        OutputFileInfo(filePath);
        
        // Read compressed file
        WriteLine("Reading the compressed XML file");
        file = File.Open(filePath, FileMode.Open);
        Stream decompressor;
        if (algorithm == "gzip")
        {
            decompressor = new GZipStream(file, CompressionMode.Decompress);
        }
        else
        {
            decompressor = new BrotliStream(file, CompressionMode.Decompress);
        }
        
        using (decompressor)
            using (XmlReader reader = XmlReader.Create(decompressor))

                while (reader.Read())
                {
                    // Check if we are on an element node named callsign
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
                    {
                        reader.Read();
                        WriteLine($"{reader.Value}");
                    }
                    
                    // Alternate syntax with property pattern matching:
                    //if (reader is { NodeType: XmlNodeType.Element, Name: "callsign" })
                }
    }
}