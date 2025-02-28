using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;
using TSD.API.Remoting.Structure.Create;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;


namespace TSD_API_ver101_Create_Entity_General
{
    public class Create_IEntity_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.Common.IEntity> CreateIEntityGeneralAsync(TSD.API.Remoting.Structure.IModel iModel, EntityParams entityParams)
        {
            try
            {
                List<EntityParams> CPParams_list = new List<EntityParams>();
                CPParams_list.Add(entityParams);

                var Item_catched = (await iModel.CreateEntityAsync(CPParams_list)).ToList().FirstOrDefault();

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
