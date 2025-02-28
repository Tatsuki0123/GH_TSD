using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_GetSolverElement

{
    public class Get_NodalReaction_output
    {
        // Task -> Object
        public static List<TSD.API.Remoting.Solver.IElement1D> GetSolverElement_IElement1D(TSD.API.Remoting.Structure.IMemberSpan IMemberspan, AnalysisType analysisType)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_NodalReaction_process.GetSolverElement_IElement1DAsync(IMemberspan,analysisType));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
