using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Materials;


namespace TSD_API_ver101_Get_IMaterials_from_BeamAttribute
{
    public class Get_IMaterials_from_BeamAttribute_process
    {


        // Geting solver IModel 
        public static async Task<List<TSD.API.Remoting.Materials.IMaterial>> GetIMaterialsfromBeamAttributeAsync(TSD.API.Remoting.Structure.IModel stIModel,MaterialType materialType)
        {
            try
            {
                List<IMaterial> list_out = new List<IMaterial>();

                var memberAttributeSet = await stIModel.CreateMemberAttributeSetAsync();
                await memberAttributeSet.MaterialType.SetValueAndUpdateAsync(materialType);

                var Item_catched = memberAttributeSet.Material.ValidValues;
                list_out = Item_catched.ToList();


                if (list_out == null)
                {
                    throw new Exception("No item found");
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
