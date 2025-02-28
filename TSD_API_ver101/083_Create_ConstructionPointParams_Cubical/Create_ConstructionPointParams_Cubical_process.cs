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


namespace TSD_API_ver101_Create_ConstructionPointParams_Cubical
{
    public class Create_ConstructionPointParams_Planar_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.Structure.Create.CubicalPointParams> CreateConstructionPointParamsAsync(double x_coor, double y_coor, double z_coor)
        {
            try
            {
                Point3D point_3d_temp = new Point3D(x_coor,y_coor, z_coor);
                var Item_catched = CubicalPointParams.Create(point_3d_temp);

                if (Item_catched == null)
                {
                    throw new Exception("No AnalysisResult found");
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
