using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Sections;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_ISectionFactory
{
    public class Get_ISectionFactory_process
    {


        // Geting solver IModel 
        public static async Task<ISectionFactory> GetISectionFactoryAsync(TSD.API.Remoting.Structure.IModel stIModel)
        {
            try
            {
                var Item_catched =  stIModel.SectionFactory;

                if (Item_catched == null)
                {
                    throw new Exception("No Item found");
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
