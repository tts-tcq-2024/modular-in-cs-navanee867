using System.Drawing;

namespace TelCo.ColorCoder
{
    public class ColorMapHelper
    {
        private static readonly Color[] _colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
        private static readonly Color[] _colorMapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };

        public static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            if (pairNumber < 1 || pairNumber > _colorMapMinor.Length * _colorMapMajor.Length)
            {
                throw new ArgumentOutOfRangeException($"Argument PairNumber:{pairNumber} is outside the permissible range");
            }

            int majorIndex = (pairNumber - 1) / _colorMapMinor.Length;
            int minorIndex = (pairNumber - 1) % _colorMapMinor.Length;

            return new ColorPair(_colorMapMajor[majorIndex], _colorMapMinor[minorIndex]);
        }

        public static int GetPairNumberFromColor(ColorPair pair)
        {
            int majorIndex = Array.IndexOf(_colorMapMajor, pair.MajorColor);
            int minorIndex = Array.IndexOf(_colorMapMinor, pair.MinorColor);

            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException($" Colors not defined for pairing {0}, {1}: {pair.MajorColor} {pair.MinorColor}");
            }

            return (majorIndex * _colorMapMinor.Length) + (minorIndex + 1);
        }
    }
}
