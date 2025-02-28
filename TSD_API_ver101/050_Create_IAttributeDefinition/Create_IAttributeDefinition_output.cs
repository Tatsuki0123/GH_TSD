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

namespace TSD_API_ver101_Create_IAttributeDefinition
{
    public class Remove_IAttributeDefinition_output
    {
        // Task -> Object
        public static TSD.API.Remoting.UserDefinedAttributes.IAttributeDefinition CreateIAttributeDefinition(TSD.API.Remoting.Structure.IModel iModel,CreateAttributeDefinitionParams createAttributeDefinitionParams)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Create_IAttributeDefinition_process.CreateIAttributeDefinitionAsync(iModel,createAttributeDefinitionParams));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
