using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    public class PairNumberMappingTests
    {
        public static void TestPairNumberMapping()
        {
            ValidatePairNumberMapping(Color.Red, Color.Brown, 9, true);
            ValidatePairNumberMapping(Color.Violet, Color.SlateGray, 25, true);
            ValidatePairNumberMapping(Color.AliceBlue, Color.AntiqueWhite, 10, false);
        }

        private static void ValidatePairNumberMapping(Color majorColor, Color minorColor, int expectedPairNumber, bool isValid)
        {
            ColorPair colorPair = new ColorPair(majorColor, minorColor);
            if (isValid)
            {
                int pairNumber = ColorMapHelper.GetPairNumberFromColor(colorPair);
                Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", colorPair, pairNumber);
                Debug.Assert(pairNumber == expectedPairNumber);
            }
            else
            {
                try
                {
                    int pairNumber = ColorMapHelper.GetPairNumberFromColor(colorPair);
                    Debug.Fail("Expected ArgumentOutOfRangeException was not thrown");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
