using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.IO;

namespace ContainerManagement.Services
{
    public class ContainerColorDetection
    {
        public string DetectContainerColor(byte[] imageBytes)
        {
            string tempFilePath = Path.GetTempFileName() + ".jpg";
            File.WriteAllBytes(tempFilePath, imageBytes);

            var image = new Image<Bgr, byte>(tempFilePath);

            var hsvImage = image.Convert<Hsv, byte>();

            var lowerBlue = new Hsv(100, 150, 50);
            var upperBlue = new Hsv(130, 255, 255);

            var lowerRed = new Hsv(0, 150, 50);
            var upperRed = new Hsv(10, 255, 255);

            var lowerGreen = new Hsv(35, 100, 100);
            var upperGreen = new Hsv(85, 255, 255);

            var blueMask = hsvImage.InRange(lowerBlue, upperBlue);
            var blueCount = blueMask.CountNonzero()[0];

            var redMask = hsvImage.InRange(lowerRed, upperRed);
            var redCount = redMask.CountNonzero()[0];

            var greenMask = hsvImage.InRange(lowerGreen, upperGreen);
            var greenCount = greenMask.CountNonzero()[0];

            string detectedColor;
            if (blueCount > redCount && blueCount > greenCount)
            {
                detectedColor = "Azul";
            }
            else if (redCount > blueCount && redCount > greenCount)
            {
                detectedColor = "Vermelho";
            }
            else if (greenCount > blueCount && greenCount > redCount)
            {
                detectedColor = "Verde";
            }
            else
            {
                detectedColor = "Cor não detectada";
            }

            File.Delete(tempFilePath);

            return detectedColor;
        }
    }
}
