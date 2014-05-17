using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace Invert911.InvertCommon.Reports
{
    class PDFUtility
    {

        private MemoryStream createPDF(string html)
        {
            MemoryStream msOutput = new MemoryStream();
            TextReader reader = new StringReader(html);

            // step 1: creation of a document-object
            Document document = new Document(PageSize.A4, 30, 30, 30, 30);

            // step 2:
            // we create a writer that listens to the document
            // and directs a XML-stream to a file
            PdfWriter writer = PdfWriter.GetInstance(document, msOutput);

            // step 3: we create a worker parse the document
            HTMLWorker worker = new HTMLWorker(document);

            // step 4: we open document and start the worker on the document
            document.Open();
            worker.StartDocument();

            // step 5: parse the html into the document
            worker.Parse(reader);

            // step 6: close the document and the worker
            worker.EndDocument();
            worker.Close();
            document.Close();

            return msOutput;
        }

        public void WriteAllFields(string SourceFilePath, string DestFilePath, Dictionary<string, string> Fields)
        {
            //Dictionary<string, string> Results = new Dictionary<string, string>();

            using (FileStream outFile = new FileStream(DestFilePath, FileMode.Create))
            {
                PdfReader pdfReader = new PdfReader(SourceFilePath);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, outFile);
                AcroFields fields = pdfStamper.AcroFields;
                //rest of the code here
                foreach(KeyValuePair<string, string> kvp in Fields)
                {
                    fields.SetField(kvp.Key, kvp.Value);
                }
                pdfStamper.Close();
                pdfReader.Close();
            }
        }

        public Dictionary<string, string> ReadAllFields(string SourceFilePath)
        {
            Dictionary<string, string> Results = new Dictionary<string, string>();
            
            using (MemoryStream ms = new MemoryStream())
            {
                PdfReader pdfReader = new PdfReader(SourceFilePath);
                PdfStamper pdfStamper = new PdfStamper(pdfReader,ms);
                AcroFields af = pdfStamper.AcroFields;

                //AcroFields af = ps.AcroFields;

                foreach (var field in af.Fields)
                {
                    //Console.WriteLine("{0}, {1}", field.Key, field.Value);
                    Results.Add(field.Key.ToString(), field.Value.ToString());
                }

                pdfStamper.Close();
                pdfReader.Close();
            }            
            return Results;
        }
    }
}
