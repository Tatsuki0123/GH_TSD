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

namespace TSD_API_ver101_Create_MemberSpanInfo_GuidGuid
{
    public class Create_MemberSpanInfo_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Structure.MemberSpanInfo CreateMemberSpanInfo(Guid memberid, Guid spanid)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Create_MemberSpanInfo_process.CreateMemberSpanInfoAsync(memberid,spanid));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
