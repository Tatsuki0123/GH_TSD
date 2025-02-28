using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_Create_ConstructionPointParams_Cubical
{
    public class Create_PointLoadParamsCreate_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Structure.Create.CubicalPointParams CreateConstructionPointParamsCubical(double x_coor, double y_coor, double z_coor)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Create_ConstructionPointParams_Planar_process.CreateConstructionPointParamsAsync(x_coor,y_coor,z_coor));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
