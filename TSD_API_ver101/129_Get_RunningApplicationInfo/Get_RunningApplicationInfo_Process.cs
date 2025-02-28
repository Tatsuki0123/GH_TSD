using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;


namespace TSD_API_ver101_Get_RunningApplicationInfo
{
    public class Get_RunningApplicationInfo_process
    {
        // Get the first running TSD instance found asynchronously
        public static async Task<List<IApplicationInfo>> GetRunningApplicationInfoAsync()
        {
            try
            {
                var Iapplicationinfo = await ApplicationFactory.GetRunningApplicationInfosAsync();

                if (Iapplicationinfo != null)
                {
                    return Iapplicationinfo.ToList() ;
                }
                else
                {
                    throw new Exception("Error during getting instance");
                }
            }
            catch (Exception ex)
            {
                throw new Exception( "Error during getting instance_1 " , ex);
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
