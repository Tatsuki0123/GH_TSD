using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_IMemberLoading
{
    public class Get_ILoadingValue_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Loading.IMemberLoading GetIMemberLoading(TSD.API.Remoting.Structure.IMember iMember, Guid guid, AnalysisType analysisType)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_LoadingValue_process.GetIMemberLoadingAsync(iMember,guid,analysisType));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
