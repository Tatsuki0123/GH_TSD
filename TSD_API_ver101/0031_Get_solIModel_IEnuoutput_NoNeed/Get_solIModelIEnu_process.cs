using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_solIModelIEnu
{
    public class Get_AnalysisResult_process
    {


        // Geting solver IModel 
        public static async Task<IEnumerable<TSD.API.Remoting.Solver.IModel>> GetsolIModelIEnuAsync(TSD.API.Remoting.Structure.IModel stIModel, IEnumerable<AnalysisType> IEnu_analysisTypes)
        {
            try
            {
                IEnumerable<AnalysisType> enu_analysisType = IEnu_analysisTypes;

                var enu_solIModel = await stIModel.GetSolverModelsAsync(enu_analysisType);
                //var solIModel = enu_solIModel.First();

                if (enu_solIModel.FirstOrDefault() == null)
                {
                    throw new Exception("No solver IModel found");
                }
                else
                {
                    return (enu_solIModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
