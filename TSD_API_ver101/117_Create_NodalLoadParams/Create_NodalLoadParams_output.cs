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

namespace TSD_API_ver101_Create_NodalLoadParams
{
    public class Create_NodalLoadPramas_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Loading.Create.NodalLoadParams CreateNodalLoadParams(int idx_point, double fx, double fy, double fz, double mx, double my, double mz)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Create_NodalLoadParams_process.CreateNodalLoadParamsAsync(idx_point,fx,fy,fz,mx,my,mz));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
