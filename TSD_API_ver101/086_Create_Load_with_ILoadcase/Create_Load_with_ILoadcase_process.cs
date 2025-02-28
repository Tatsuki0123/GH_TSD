using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Loading.Create;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;
using TSD.API.Remoting.Structure.Create;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;


namespace TSD_API_ver101_Create_Load_with_ILoadcase
{
    public class Create_Load_with_ILoadcase_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.Loading.ILoad> CreateLoadwithILoadcaseAsync(ILoadcase iLoadcase, LoadParams loadParams)
        {
            try
            {
                List<LoadParams> loadParams_list = new List<LoadParams>();
                loadParams_list.Add(loadParams);

                 var Item_catched = (await iLoadcase.CreateLoadAsync(loadParams_list)).ToList().First();

                if (Item_catched == null)
                {
                    throw new Exception("No AnalysisResult found");
                }
                else
                {
                    return (Item_catched);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
