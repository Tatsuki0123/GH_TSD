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
using TSD.API.Remoting.Loading.Create;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;
using TSD.API.Remoting.Structure.Create;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;


namespace TSD_API_ver101_Create_PointLoadParams
{
    public class Create_Point2D_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.Loading.Create.PointLoadParams> CreatePointLoadParamsAsync(IConstructionPoint point_CP, double load,Point2D coordinate,PlanarLoadParams.LoadDirectionGlobal direction)
        {
            try
            {
                var Item_catched = PointLoadParams.Create(point_CP,load,coordinate,direction);

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
