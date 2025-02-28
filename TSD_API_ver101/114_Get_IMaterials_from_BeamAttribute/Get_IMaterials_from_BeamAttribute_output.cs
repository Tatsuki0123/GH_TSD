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
    public class Get_IMaterials_from_BeamAttribute_output
    {
        
    
        // Task -> Object
        public static List<IMaterial> GetIMaterialsfromBeamAttribute(TSD.API.Remoting.Structure.IModel stIModel,MaterialType materialType)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_IMaterials_from_BeamAttribute_process.GetIMaterialsfromBeamAttributeAsync(stIModel,materialType));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                return null;
                //throw new Exception("Error during Task -> object");
            }
        }

    }
}
