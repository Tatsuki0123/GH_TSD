using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_Create_Vector3D
{

    public class Create_Entity_General_output
{
    // Task -> Object
    public static TSD.API.Remoting.Geometry.Vector3D CreateVector3D(double x_coor, double y_coor, double z_coor)
    {
        try
        {
            // Call the asynchronous method and wait for its completion non-blockingly
            var resultTask = Task.Run(async () => await Create_Entity_General_process.CreateVector3DAsync(x_coor, y_coor, z_coor));
            return resultTask.Result; // Retrieve the result
        }
        catch (Exception ex)
        {
            throw new Exception("Error during Task -> object");
        }
    }

}
}
