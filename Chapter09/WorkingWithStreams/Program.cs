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