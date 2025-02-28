using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;


namespace TSD_API_ver101_stIModel
{
    public class Get_solIModel_process
    {


        // Geting Documents task
        public static async Task<TSD.API.Remoting.Structure.IModel> GetstIModelAsync(IDocument IDoc)
        {
            try
            {
                var stIModel = await IDoc.GetModelAsync();

                if (stIModel == null)
                {
                    throw new Exception("No structure IModel found");
                }
                else
                {
                    return (stIModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
