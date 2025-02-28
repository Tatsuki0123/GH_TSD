using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_AnalysisResult
{
    public class Get_AnalysisResult3D_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.Solver.IAnalysisResults> GetAnalysisResultAsync(TSD.API.Remoting.Solver.IModel solIModel)
        {
            try
            {
                var AnalysisResult_catched = await solIModel.GetResultsAsync();

                if (AnalysisResult_catched == null)
                {
                    throw new Exception("No AnalysisResult found");
                }
                else
                {
                    return (AnalysisResult_catched);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
