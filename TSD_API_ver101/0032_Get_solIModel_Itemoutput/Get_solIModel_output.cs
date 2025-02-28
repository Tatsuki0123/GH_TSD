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
    public class Get_AnalysisResult_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Solver.IModel GetsolIModel(TSD.API.Remoting.Structure.IModel stIModel,AnalysisType analysisType)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_AnalysisResult_process.GetsolIModelAsync(stIModel, analysisType));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
