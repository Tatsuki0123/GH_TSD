using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;
using TSD.API.Remoting.Structure.Create;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;


namespace TSD_API_ver101_Create_IConstructionPoint
{
    public class Create_IEntity_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.Structure.IConstructionPoint> CreateIConstructionPointAsync(TSD.API.Remoting.Structure.IModel iModel, ConstructionPointParams constructionpointParms)
        {
            try
            {
                List<ConstructionPointParams> CPParams_list = new List<ConstructionPointParams>();
                CPParams_list.Add(constructionpointParms);

                var Item_catched = (await iModel.CreateEntityAsync(CPParams_list)).Cast<IConstructionPoint>().ToList().First();

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
