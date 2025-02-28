using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_IAttributeDefinition
{
    public class Get_IAttributeDefinition_process
    {


        // Geting solver IModel 
        public static async Task<List<TSD.API.Remoting.UserDefinedAttributes.IAttributeDefinition>> GetIAttributeDefinitionAsync(TSD.API.Remoting.Structure.IModel iModel, string name)
        {
            try
            {
                List<string> List_name = new List<string>();
                List_name.Add(name);
                IEnumerable<string> IEnu_name = List_name;

                List<TSD.API.Remoting.UserDefinedAttributes.IAttributeDefinition> list_out = new List<TSD.API.Remoting.UserDefinedAttributes.IAttributeDefinition>();
                var IAD_catched = await iModel.UserDefinedAttributesManager.GetAttributeDefinitionsByNamesAsync(IEnu_name);
                list_out = IAD_catched.ToList();

                if (list_out == null)
                {
                    throw new Exception("No AnalysisResult found");
                }
                else
                {
                    return (list_out);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
