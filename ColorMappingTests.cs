using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    internal class ColorMappingTests
    {
        public static void TestColorMapping()
        {
            ValidateColorMapping(10, Color.Red, Color.SlateGray, true);
            ValidateColorMapping(21, Color.Violet, Color.Blue, true);
            ValidateColorMapping(7, Color.Red, Color.Orange, true);
            ValidateColorMapping(0, Color.Violet, Color.Green, false);
            ValidateColorMapping(26, Color.Violet, Color.Green, false);
        }

        private static void ValidateColorMapping(int pairNumber, Color expectedMajor, Color expectedMinor, bool isValid)
        {
            if(isValid)
            {
                ColorPair colorPair = ColorMapHelper.GetColorFromPairNumber(pairNumber);
                Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, colorPair);
                Debug.Assert(colorPair.MajorColor == expectedMajor);
                Debug.Assert(colorPair.MinorColor == expectedMinor);
            }
            else
            {
                try
                {
                    ColorPair colorPair = ColorMapHelper.GetColorFromPairNumber(pairNumber);
                    Debug.Fail("Expected ArgumentException was not thrown");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
