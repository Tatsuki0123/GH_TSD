using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_IMemberSpan
{
    public class Get_RigidZone_output
    {
        // Task -> Object
        public static List<TSD.API.Remoting.Structure.IMemberSpan> GetIMemberSpan(TSD.API.Remoting.Structure.IMember iMember)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_RigidZone_process.GetIMemberSpanAsync(iMember));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
