using Google.Cloud.Vision.V1;
using System;

namespace ContainerManagement.Services
{
    public class ImageRecognitionService
    {
        public string GetImageDescription(byte[] imageBytes)
        {
            // Cria um cliente de visão computacional do Google
            var client = ImageAnnotatorClient.Create();

            // Cria uma requisição de imagem a partir dos bytes
            var image = Image.FromBytes(imageBytes);

            // Realiza a detecção de rótulos na imagem
            var response = client.DetectLabels(image);

            // Captura as descrições e escolhe a mais relevante
            var description = response.FirstOrDefault()?.Description;

            return description ?? "Não foi possível gerar uma descrição para esta imagem.";
        }
    }
}
