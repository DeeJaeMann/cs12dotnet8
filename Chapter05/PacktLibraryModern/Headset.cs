namespace Packt.Shared;

// C# 12 primary constructor
// parameters don't automatically become public
public class Headset(string manufacturer, string productName)
{
    public string Manufacturer { get; set; } = manufacturer;
    public string ProductName { get; set; } = productName;

    // Default parameterless constructor
    public Headset() : this("Microsoft", "HoloLens") { }
}