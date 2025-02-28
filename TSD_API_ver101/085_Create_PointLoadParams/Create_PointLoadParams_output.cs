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

namespace TSD_API_ver101_Create_PointLoadParams
{
    public class Create_Point2D_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Loading.Create.PointLoadParams CreatePointLoadParams(IConstructionPoint referencePoint,double load,Point2D coordinate,PlanarLoadParams.LoadDirectionGlobal direction)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Create_Point2D_process.CreatePointLoadParamsAsync(referencePoint,load,coordinate,direction));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
