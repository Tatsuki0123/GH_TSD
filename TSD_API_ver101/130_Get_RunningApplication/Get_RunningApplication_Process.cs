using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;


namespace TSD_API_ver101_Get_RunningApplication
{
    public class Get_RunningApplication_process
    {
        // Get the first running TSD instance found asynchronously
        public static async Task<List<IApplication>> GetRunningApplicationsAsync()
        {
            try
            {
                var Iapplication = await ApplicationFactory.GetRunningApplicationsAsync();

                if (Iapplication != null)
                {
                    return Iapplication.ToList();
                }
                else
                {
                    throw new Exception("Error during getting instance");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error during getting instance_1 ", ex);
            }
        }

        // Geting Documents task
        /*public static async Task<IDocument> GetDocumentsAsync()
        {
            try
            {
                var tsdInstance = await ApplicationFactory.GetFirstRunningApplicationAsync();
                var document = await tsdInstance.GetDocumentAsync();

                if (document == null)
                {
                    throw new Exception("No document found");
                }
                else
                {
                    return (document);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }*/



    }
}
