using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_IReinforcementCollection
{
    public class Get_ISlabReinforcement_Top_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Reinforcement.IReinforcementCollection GetIReinforcementCollection(TSD.API.Remoting.Structure.IMember iMember)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_IReinforcementCollection_process.GetIReinforcementCollectionAsync(iMember));
                var result = resultTask.Result; // Retrieve the result
                
                    return result;
                
            }
            catch (Exception ex)
            {
                return null;
                //throw new Exception("Error during Task -> object", ex);
            }

        }

    }
}
