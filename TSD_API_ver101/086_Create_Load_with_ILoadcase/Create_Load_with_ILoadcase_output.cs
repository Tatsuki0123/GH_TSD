using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Loading.Create;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure.Create;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;

namespace TSD_API_ver101_Create_Load_with_ILoadcase
{
    public class Create_Load_with_ILoadcase_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Loading.ILoad CreateLoadwithILoadcase(TSD.API.Remoting.Loading.ILoadcase iLoadcase, LoadParams loadParams)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Create_Load_with_ILoadcase_process.CreateLoadwithILoadcaseAsync(iLoadcase,loadParams));
                var output = resultTask.Result;

                return output;

                //Be Careful, if load value is 0 it will not return anyvalue

   
            }
            catch (Exception ex)
            {
               
                return null;
                //throw new Exception("Error during Task -> object");
            }
        }

    }
}
