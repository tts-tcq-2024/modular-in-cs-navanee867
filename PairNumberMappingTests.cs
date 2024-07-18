using Xunit;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    internal class PairNumberMappingTests
    {
        public static void RunTests()
        {
            ValidatePairNumberMapping(Color.Red, Color.Brown, 9);
            ValidatePairNumberMapping(Color.Violet, Color.SlateGray, 25);
            Assert.Throws<ArgumentException>(() => ValidatePairNumberMapping(Color.AliceBlue, Color.AntiqueWhite, 10));
        }

        private static void ValidatePairNumberMapping(Color majorColor, Color minorColor, int expectedPairNumber)
        {
            ColorPair colorPair = new ColorPair(majorColor, minorColor);
            int pairNumber = ColorMapHelper.GetPairNumberFromColor(colorPair);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", colorPair, pairNumber);
            Debug.Assert(pairNumber == expectedPairNumber);
        }
    }
}
