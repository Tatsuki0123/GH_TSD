using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Geometry;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;
using TSD.API.Remoting.Structure.Create;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;


namespace TSD_API_ver101_Create_ConstructionPointParams_Planar
{
    public class Create_PointLoadParamsCreate_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.Structure.Create.PlanarPointParams> CreateConstructionPointParamsPlanarAsync(double x_coor, double y_coor, IConstructionPlane iConstructionPlane)
        {
            try
            {
                Point2D point_2d_temp = new Point2D(x_coor,y_coor);
                EntityInfo entity_info = new EntityInfo();
                entity_info.Index = iConstructionPlane.Index;
                entity_info.Id  = iConstructionPlane.Id;
                entity_info.Type = iConstructionPlane.EntityType;

                var Item_catched = PlanarPointParams.Create(entity_info, point_2d_temp);

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
