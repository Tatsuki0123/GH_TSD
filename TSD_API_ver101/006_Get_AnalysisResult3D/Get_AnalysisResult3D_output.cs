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
    public class Get_INode_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Solver.IAnalysis3DResults GetAnalysisResult3D(TSD.API.Remoting.Solver.IAnalysisResults AnalysisReuslt)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_AnalysisResult3D_process.GetAnalysisResult3DAsync(AnalysisReuslt));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
