using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure.Create;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;

namespace TSD_API_ver101_Create_IConstructionPoint
{
    public class Create_IEntity_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Structure.IConstructionPoint CreateIConstructionPoint(TSD.API.Remoting.Structure.IModel iModel, ConstructionPointParams constructionpointParams)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Create_IEntity_process.CreateIConstructionPointAsync(iModel, constructionpointParams));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
