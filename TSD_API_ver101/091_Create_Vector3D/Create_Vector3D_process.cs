using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Geometry;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure.Create;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;


namespace TSD_API_ver101_Create_Vector3D
{
    public class Create_Entity_General_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.Geometry.Vector3D> CreateVector3DAsync(double x_coor, double y_coor, double z_coor)
        {
            try
            {
                var Item_catched = new TSD.API.Remoting.Geometry.Vector3D(x_coor, y_coor, z_coor);

                if (1 == 2)
                {
                    throw new Exception("No item found");
                }
                else
                {
                    return (Item_catched);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
