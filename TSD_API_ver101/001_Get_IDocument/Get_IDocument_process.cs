using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;


namespace TSD_API_ver101.Get_IDocument
{
    public class Get_stIModel_process
    {


        // Geting Documents task
        public static async Task<IDocument> GetDocumentsAsync(IApplication IApp)
        {
            try
            {
                var tsdInstance = IApp;
                var document = await tsdInstance.GetDocumentAsync();

                if (document == null)
                {
                    throw new Exception("No document found");
                }
                else
                {
                    return document;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
