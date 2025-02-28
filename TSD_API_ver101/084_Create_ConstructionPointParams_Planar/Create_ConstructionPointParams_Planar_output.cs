using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_Create_ConstructionPointParams_Planar
{
    public class Create_ConstructionPointParams_Planar_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Structure.Create.PlanarPointParams CreateConstructionPointParamsPlanar(double x_coor, double y_coor,IConstructionPlane iConstructionPlane)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Create_PointLoadParamsCreate_process.CreateConstructionPointParamsPlanarAsync(x_coor,y_coor,iConstructionPlane));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
