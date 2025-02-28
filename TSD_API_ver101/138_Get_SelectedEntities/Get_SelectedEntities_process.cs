using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Common.Interfaces;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_Get_SelectedEntities
{
    public class Get_SelectedEntities_process
    {


        // Geting solver IModel 
        public static async Task<(List<ISelectedEntity>,List<ISelectedSubEntity>)> GetISelectedEntityAsync(TSD.API.Remoting.Structure.IModel stIModel)
        {
            try
            {
                List<ISelectedEntity> list_out_1 = new List<ISelectedEntity>();
                List<ISelectedSubEntity> list_out_2 = new List<ISelectedSubEntity>();

                var Item_catched_original = await stIModel.GetSelectedEntitiesAsync();

                foreach(var item_i in Item_catched_original)
                {
                    var Item_catched = (item_i as ISelectedEntity);
                    var Item_catched_sub = (item_i as ISelectedSubEntity);

                    if(Item_catched != null)
                    {
                        list_out_1.Add(Item_catched);
                    }
                    else if(Item_catched_sub != null)
                    {
                        list_out_2.Add(Item_catched_sub);
                    }

                    
                }


                if (list_out_1 == null )
                {
                    throw new Exception("No selected item found");
                }
                else
                {
                    return (list_out_1,list_out_2);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
