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
    public class Set_UserDefinedAttribute_MemberSpan_output
    {
        // Task -> Object
        public static void SetUserDefinedAttribute_MemberSpan(TSD.API.Remoting.Structure.IMemberSpan iMemberSpan,IAttributeDefinition IattributeDefinition, string Value)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Set_UserDefinedAttribute_MemberSpan_process.SetUserDefinedAttribute_MemberSpanAsync(iMemberSpan,IattributeDefinition, Value));
                return ; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
