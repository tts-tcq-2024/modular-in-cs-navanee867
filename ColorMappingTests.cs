using Xunit;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    internal class ColorMappingTests
    {
        public static void RunTests()
        {
            Assert.That(() => { ValidateColorMapping(10, Color.Red, Color.SlateGray); }, Throws.Nothing);
            Assert.That(() => { ValidateColorMapping(21, Color.Violet, Color.Blue); }, Throws.Nothing);
            Assert.That(() => { ValidateColorMapping(7, Color.Red, Color.Orange);}, Throws.Nothing);
            Assert.Throws<ArgumentOutOfRangeException>(() => ValidateColorMapping(0, Color.Violet, Color.Green));
            Assert.Throws<ArgumentOutOfRangeException>(() => ValidateColorMapping(26, Color.Violet, Color.Green));

        }
        private static void ValidateColorMapping(int pairNumber, Color expectedMajor, Color expectedMinor)
        {
            ColorPair colorPair = ColorMapHelper.GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, colorPair);
            Debug.Assert(colorPair.MajorColor == expectedMajor);
            Debug.Assert(colorPair.MinorColor == expectedMinor);
        }
    }
}
