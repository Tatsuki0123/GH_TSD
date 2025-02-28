using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_AnalysisResult3D
{
    public class Get_AnalysisResult3D_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.Solver.IAnalysis3DResults> GetAnalysisResult3DAsync(TSD.API.Remoting.Solver.IAnalysisResults AnalysisReuslt)
        {
            try
            {
                var AnalysisResult3D_catched = await AnalysisReuslt.GetAnalysis3DAsync();

                if (AnalysisResult3D_catched == null)
                {
                    throw new Exception("No AnalysisResult found");
                }
                else
                {
                    return (AnalysisResult3D_catched);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
