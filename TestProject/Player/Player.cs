using System;
namespace TestProject.Players
{
    public interface IOutField
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string Fullname { get { return $"{First} {Last}"; } set { } }
        public int ShirtNum { get; set; }
        public double StartPercentage { get { return (Starts / Appearances) * 100; } }
        public int Starts { get; set; }
        public int Appearances { get; set; }

    }


    public struct OutField
    {
        public string First { get; set; }
        public string Last { get; set; }
        public readonly string Fullname { get { return $"{First} {Last}"; } }
        public int ShirtNum { get; set; }
        public readonly int StartPercentage { get => Starts / Appearances * 100; }
        public int Starts { get; set; }
        public int Appearances { get; set; }
    }

    public struct OutFieldArgumentsNull
    {
        public string ErrorMessage { get; set; }
        public PlayerClass InitialInput { get; set; }
    }

    public struct StartsGreaterAppearances
    {
        public string ErrorMessage { get; set; }
        public int Starts { get; set; }
        public int Appearances { get; set; }

    }
}