namespace Packt.Shared;

// Values do not overlap
// Flag attribute automatically matches multiple values as
//  comma separated string instead of int
// Uses byte to reduce memory requirement by 75%
//  1 byte per value instead of 4
[Flags]
public enum WondersOfTheAncientWorld : byte
{
    None                        = 0b_0000_0000, // 0
    GreatPyramidOfGiza          = 0b_0000_0001, // 1
    HangingGardensOfBabylon     = 0b_0000_0010, // 2
    StatueOfZeusAtOlympia       = 0b_0000_0100, // 4
    TempleOfArtemisAtEphesus    = 0b_0000_1000, // 8
    MausoleumAtHalicarnassus    = 0b_0001_0000, // 16
    ColossusOfRhodes            = 0b_0010_0000, // 32
    LighthouseOfAlexandira      = 0b_0100_0000  // 64
}