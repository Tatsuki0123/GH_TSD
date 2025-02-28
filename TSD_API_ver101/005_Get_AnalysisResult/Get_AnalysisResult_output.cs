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
    public class Get_AnalysisResult3D_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Solver.IAnalysisResults GetAnalysisResult(TSD.API.Remoting.Solver.IModel solIModel)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_AnalysisResult3D_process.GetAnalysisResultAsync(solIModel));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
