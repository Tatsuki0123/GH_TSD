using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;

namespace TSD_API_ver101_tsdInstance
{
    public class Get_RunningApplicationInfo_Output
    {
        // Task -> Object
        public static IApplication GetInstance()
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_IDocument_process.GetInstanceAsync());
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
