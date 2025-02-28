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
using TSD.API.Remoting.Structure;
using TSD.API.Remoting.Structure.Create;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;


namespace TSD_API_ver101_Create_MemberParams
{
    public class Create_MemberParams_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.Structure.Create.MemberParams> CreateMemberParamsAsync(IConstructionPoint start, IConstructionPoint end, IMemberAttributeSet iMemberAttributeSet)
        {
            try
            {
                List<IConstructionPoint> point_list = new List<IConstructionPoint>();
                point_list.Add(start);
                point_list.Add(end);

                var Item_catched = MemberParams.Create(point_list, iMemberAttributeSet);

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
