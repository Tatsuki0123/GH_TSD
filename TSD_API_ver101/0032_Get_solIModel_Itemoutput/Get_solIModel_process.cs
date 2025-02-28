using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_solIModel
{
    public class Get_AnalysisResult_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.Solver.IModel> GetsolIModelAsync(TSD.API.Remoting.Structure.IModel stIModel, AnalysisType analysisType)
        {
            try
            {
                List<AnalysisType> List_analysisTypes = new List<AnalysisType>();
                List_analysisTypes.Add(analysisType);
                IEnumerable<AnalysisType> enu_analysisType = List_analysisTypes;

                var enu_solIModel = await stIModel.GetSolverModelsAsync(enu_analysisType);
                var solIModel = enu_solIModel.First();
                

                if (enu_solIModel.FirstOrDefault() == null)
                {
                    throw new Exception("No solver IModel found");
                }
                else
                {
                    return (solIModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
