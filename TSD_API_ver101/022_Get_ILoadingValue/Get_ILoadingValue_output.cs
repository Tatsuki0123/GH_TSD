using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_ILoadingValue
{
    public class Get_ILoadingValue_output
    {
        // Task -> Object
        public static List<TSD.API.Remoting.Loading.ILoadingValue> GetILoadingValue(TSD.API.Remoting.Loading.IMemberLoading iMemberloading, LoadingValueOptions loadingValueOptions, int SpanIndex, double position)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_ILoadingValue_process.GetILoadingValueAsync(iMemberloading,loadingValueOptions,SpanIndex, position));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
