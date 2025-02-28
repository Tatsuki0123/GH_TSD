using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;


namespace TSD_API_ver101_Set_UserDefinedAttribute_MemberSpan
{
    public class Set_UserDefinedAttribute_MemberSpan_process
    {


        // Geting solver IModel 
        public static async Task SetUserDefinedAttribute_MemberSpanAsync(TSD.API.Remoting.Structure.IMemberSpan iMemberSpan, IAttributeDefinition AttributeDefinition, string Value)
        {
            try
            {


                var Item_catched = await iMemberSpan.SetUserDefinedAttributeAsync(AttributeDefinition, Value);

                

                if (Item_catched == null)
                {
                    throw new Exception("No AnalysisResult found");
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
