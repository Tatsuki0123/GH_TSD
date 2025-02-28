using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Reinforcement;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_IReinforcementCollection
{
    public class Get_IReinforcementCollection_process
    {


        // Geting solver IModel 
        public static async Task<IReinforcementCollection> GetIReinforcementCollectionAsync(TSD.API.Remoting.Structure.IMember iMember)
        {
            try
            {
                var IReinforcementCollection_catched = await iMember.GetReinforcementAsync();

                if (IReinforcementCollection_catched == null)
                {
                    throw new Exception("No IReinforcementCollection found");
                }
                else
                {
                    return (IReinforcementCollection_catched);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
