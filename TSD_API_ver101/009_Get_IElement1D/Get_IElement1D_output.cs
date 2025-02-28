using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_IElement1D
{
    public class Get_SolverElemet_IElement1D_FromMemberSpan_output
    {
        // Task -> Object
        public static List<TSD.API.Remoting.Solver.IElement1D> GetIElement1D(TSD.API.Remoting.Solver.IModel solIModel)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_SolverElemet_IElement1D_FromMemberSpan_process.GetIElement1DAsync(solIModel));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
