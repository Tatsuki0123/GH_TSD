using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure.Create;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;

namespace TSD_API_ver101_Create_IMember
{

    public class Create_IMember_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Structure.IMember CreateIMember(TSD.API.Remoting.Structure.IModel iModel, MemberParams entityParams)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Create_IMember_process.CreateIMemberAsync(iModel, entityParams));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                return null;
                //throw new Exception("Error during Task -> object");
            }
        }

    }
}
