using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_ISlabItem
{
    public class Get_ISlabItem_process
    {


        // Geting solver IModel 
        public static async Task<List<TSD.API.Remoting.Structure.ISlabItem>> ProcessAsync(TSD.API.Remoting.Structure.IModel stIModel)
        {
            try
            {
                List<TSD.API.Remoting.Structure.ISlabItem> list_out = new List<TSD.API.Remoting.Structure.ISlabItem>();
                var Item_catched = await stIModel.GetSlabItemsAsync(null);
                list_out = Item_catched.ToList();

                if (list_out == null)
                {
                    throw new Exception("No item found");
                }
                else
                {
                    return (list_out);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
