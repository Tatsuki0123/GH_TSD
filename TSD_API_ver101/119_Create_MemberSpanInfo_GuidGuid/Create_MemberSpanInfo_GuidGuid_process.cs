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


namespace TSD_API_ver101_Create_MemberSpanInfo_GuidGuid
{
    public class Create_MemberSpanInfo_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.Structure.MemberSpanInfo> CreateMemberSpanInfoAsync(Guid memberid, Guid spanid)
        {
            try
            {
                var Item_catched = new MemberSpanInfo(memberid, spanid);

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
