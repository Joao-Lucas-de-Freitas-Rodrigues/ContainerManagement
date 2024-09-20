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
            // Salvar a imagem em um arquivo temporário
            string tempFilePath = Path.GetTempFileName() + ".jpg";
            File.WriteAllBytes(tempFilePath, imageBytes);

            // Carregar a imagem do arquivo temporário
            var image = new Image<Bgr, byte>(tempFilePath);

            // Converter a imagem para o espaço de cores HSV
            var hsvImage = image.Convert<Hsv, byte>();

            // Definir as faixas de cores HSV para detecção de cores (Exemplo: Azul, Vermelho, Verde)
            var lowerBlue = new Hsv(100, 150, 50);
            var upperBlue = new Hsv(130, 255, 255);

            var lowerRed = new Hsv(0, 150, 50);
            var upperRed = new Hsv(10, 255, 255);

            var lowerGreen = new Hsv(35, 100, 100);
            var upperGreen = new Hsv(85, 255, 255);

            // Detectar a cor Azul
            var blueMask = hsvImage.InRange(lowerBlue, upperBlue);
            var blueCount = blueMask.CountNonzero()[0];  // Contar os pixels azuis

            // Detectar a cor Vermelha
            var redMask = hsvImage.InRange(lowerRed, upperRed);
            var redCount = redMask.CountNonzero()[0];  // Contar os pixels vermelhos

            // Detectar a cor Verde
            var greenMask = hsvImage.InRange(lowerGreen, upperGreen);
            var greenCount = greenMask.CountNonzero()[0];  // Contar os pixels verdes

            // Determinar a cor predominante
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

            // Excluir o arquivo temporário
            File.Delete(tempFilePath);

            return detectedColor;
        }
    }
}
