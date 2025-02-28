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


namespace TSD_API_ver101_CreateAttributeDefinitionParams
{
    public class Create_CreateAttributeDefinitionParams_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.UserDefinedAttributes.Create.CreateAttributeDefinitionParams> CreateCreateAttributeDefinitionParamsAsync(TSD.API.Remoting.Structure.IModel iModel, string name, AttributeValueType valueType, AttributeValueSource valueSource, List<string> listed_value)
        {
            try
            {
                var Item_catched = CreateAttributeDefinitionParams.Create(name,valueType,valueSource);

                if(valueSource == AttributeValueSource.PredefinedList)
                {
                    Item_catched.Values = listed_value;
                }
                

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
