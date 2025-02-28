using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;

namespace TSD_API_ver101.Get_Instance_IApplicationInfo
{
    public class Get_Instance_IApplicationInfo_output
    {
        // Task -> Object
        public static IApplication GetInstanceIApplicationInfo(IApplicationInfo IapplicationInfo)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_Instance_IApplicationInfo_process.GetInstanceIApplicationInfoAsync(IapplicationInfo));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
