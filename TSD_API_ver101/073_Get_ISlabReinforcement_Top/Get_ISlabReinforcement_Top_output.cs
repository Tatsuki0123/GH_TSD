using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_ISlabReinforcement_Top
{
    public class Get_ISlabReinforcement_Bottom_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Reinforcement.ISlabReinforcement GetISlabReinforcement_Top(TSD.API.Remoting.Structure.ISlabItem islabItem)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_ISlabReinforcement_BOttom_process.GetISlabReinforcement_TopAsync(islabItem));
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
