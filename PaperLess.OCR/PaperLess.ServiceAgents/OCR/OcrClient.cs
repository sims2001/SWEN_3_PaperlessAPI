using PaperLess.ServiceAgents.Interfaces;
using System.Text;
using ImageMagick;
using Microsoft.Extensions.Options;
using Tesseract;


namespace PaperLess.ServiceAgents.OCR;

public class OcrClient : IOcrClient
{
    private readonly string tesseractDataPath;
    private readonly string language;

    public OcrClient(OcrOptions options) {
        this.tesseractDataPath = options.TessDataPath;
        this.language = options.Language;
    }

    public string PerformOcrPdf(Stream pdfStream){
        var stringBuilder = new StringBuilder();

        using (var magickImages = new MagickImageCollection())
        {
            magickImages.Read(pdfStream);
            foreach (var magickImage in magickImages)
            {
                // Set the resolution and format of the image (adjust as needed)
                magickImage.Density = new Density(300, 300);
                magickImage.Format = MagickFormat.Png;

                // Perform OCR on the image
                using (var tesseractEngine = new TesseractEngine(tesseractDataPath, language, EngineMode.Default))
                {
                    using (var page = tesseractEngine.Process(Pix.LoadFromMemory(magickImage.ToByteArray())))
                    {
                        var extractedText = page.GetText();
                        stringBuilder.Append(extractedText);
                    }
                }
            }
        }


        return stringBuilder.ToString();
    }
}
