using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;
using TSD.API.Remoting.Structure.Create;

namespace TSD_API_ver101_Create_MemberParams
{
    public class Create_MemberParams_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Structure.Create.MemberParams CreateMemberParams(IConstructionPoint start, IConstructionPoint end, IMemberAttributeSet iMemberAttributeSet)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Create_MemberParams_process.CreateMemberParamsAsync(start,end,iMemberAttributeSet));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
