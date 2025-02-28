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
    public class Create_IAttributeDefinition_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.UserDefinedAttributes.IAttributeDefinition> CreateIAttributeDefinitionAsync(TSD.API.Remoting.Structure.IModel iModel, CreateAttributeDefinitionParams createAttributeDefinition)
        {
            try
            {
                var Item_catched = await iModel.UserDefinedAttributesManager.CreateAttributeDefinitionAsync(createAttributeDefinition);

                

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
