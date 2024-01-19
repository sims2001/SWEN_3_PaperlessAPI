namespace PaperLess.ServiceAgents.Interfaces;
public interface IOcrClient
{
    string PerformOcrPdf(Stream pdfStream);
}
