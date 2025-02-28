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


namespace TSD_API_ver101_Remove_IAttributeDefinition
{
    public class Remove_IAttributeDefinition_process
    {


        // Geting solver IModel 
        public static async Task RemoveIAttributeDefinitionAsync(TSD.API.Remoting.Structure.IModel iModel, IAttributeDefinition IAttributeDefinition)
        {
            try
            {
                List<IAttributeDefinition> list_IAD = new List<IAttributeDefinition>();
                list_IAD.Add(IAttributeDefinition);
                IEnumerable<IAttributeDefinition> IEnu_IAD = list_IAD;

                await iModel.UserDefinedAttributesManager.RemoveAttributeDefinitionsAsync(IEnu_IAD);

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
