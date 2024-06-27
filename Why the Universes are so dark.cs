using System;
using System.Drawing;

namespace BlackscaleImaging
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputImagePath = "input.jpg"; // Path to the input image
            string outputImagePath = "output.jpg"; // Path to save the blackscale image

            // Load the input image
            Bitmap bitmap = new Bitmap(inputImagePath);

            // Convert to blackscale
            Bitmap blackscaleBitmap = ConvertToBlackscale(bitmap);

            // Save the blackscale image
            blackscaleBitmap.Save(outputImagePath);

            Console.WriteLine("Blackscale image saved successfully.");
        }

        static Bitmap ConvertToBlackscale(Bitmap original)
        {
            int width = original.Width;
            int height = original.Height;
            Bitmap blackscaleBitmap = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = original.GetPixel(x, y);

                    // Convert to blackscale
                    double blackScaleValue = 1.0 - (pixelColor.R / 255.0);

                    // In blackscale, the RGB values are the same and scaled to 0.0 to 1.0 range
                    byte blackScaleByte = (byte)(blackScaleValue * 255);

                    Color blackscaleColor = Color.FromArgb(blackScaleByte, blackScaleByte, blackScaleByte);

                    blackscaleBitmap.SetPixel(x, y, blackscaleColor);
                }
            }

            return blackscaleBitmap;
        }
    }
}
