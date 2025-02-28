using Rhino.UI.Theme;
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


namespace TSD_API_ver101_Create_NodalLoadParams
{
    public class Create_NodalLoadParams_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.Loading.Create.NodalLoadParams> CreateNodalLoadParamsAsync(int idx_point, double fx, double fy, double fz, double mx, double my, double mz)
        {
            try
            {
                var Item_catched = NodalLoadParams.ForceAndMoment(idx_point,fx,fy,fz,mx,my,mz);

                if (Item_catched == null)
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
