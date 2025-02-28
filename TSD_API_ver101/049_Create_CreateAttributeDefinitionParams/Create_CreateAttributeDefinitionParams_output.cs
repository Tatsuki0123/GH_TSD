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

namespace TSD_API_ver101_CreateAttributeDefinitionParams
{
    public class Create_IAttributeDefinition_output
    {
        // Task -> Object
        public static TSD.API.Remoting.UserDefinedAttributes.Create.CreateAttributeDefinitionParams CreateCreateAttributeDefinitionParams(TSD.API.Remoting.Structure.IModel iModel, string name, AttributeValueType valueType, AttributeValueSource valueSource, List<string> listed_value)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Create_CreateAttributeDefinitionParams_process.CreateCreateAttributeDefinitionParamsAsync(iModel,name,valueType,valueSource,listed_value));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
