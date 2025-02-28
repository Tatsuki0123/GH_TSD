using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;


namespace TSD_API_ver101.Get_IDocument_FileStream
{
    public class Get_IDocument_FileStream_process
    {


        // Geting Documents task
        public static async Task<IDocument> GetDocumentFileStreamAsync(IApplication IApp, string filepath, bool allowUserInteraction)
        {
            try
            {
                var tsdInstance = IApp;
                using (FileStream fileStream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    var document = await tsdInstance.OpenDocumentAsync(fileStream, allowUserInteraction);

                    if (document == null)
                    {
                        throw new Exception("No document found");
                    }
                    else
                    {
                        return document;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
