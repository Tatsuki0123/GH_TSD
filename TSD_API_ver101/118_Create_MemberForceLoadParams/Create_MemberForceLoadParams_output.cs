using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Geometry;
using TSD.API.Remoting.Loading.Create;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_Create_MemberForceLoadParams
{
    public class Create_MemberForceLoadParams_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Loading.Create.MemberForceLoadParams CreateMemberForceLoadParams(MemberSpanInfo memberSpanInfo, double load, double distance, MemberLoadParams.LoadDirectionGlobal direction, MemberLoadParams.ApplicableMeasuring measure)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Create_MemberForceLoadParams_process.CreateMemberForceLoadParamsAsync(memberSpanInfo,load,distance,direction,measure));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
