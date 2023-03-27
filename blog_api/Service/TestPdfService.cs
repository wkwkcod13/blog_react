using iText;
using iText.Kernel.Pdf;
using iText.Html2pdf;

namespace blog_api.Service
{
    public class TestPdfService
    {
        public TestPdfService()
        {

        }

        public void PdfReader()
        {
            PdfDocument pdf = new PdfDocument(new PdfReader(""));
            PdfReader reader = new PdfReader("", new ReaderProperties());
        }

        public void Pdf2Html()
        {
            PdfDocument pdf = new PdfDocument(new PdfReader(""));
        }
    }
}
