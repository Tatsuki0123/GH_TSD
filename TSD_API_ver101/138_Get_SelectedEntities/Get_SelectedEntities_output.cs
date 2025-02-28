using System;
using System.Collections.Generic;
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
    public class Get_SelectedEntities_output
    {
        // Task -> Object
        public static (List<ISelectedEntity>,List<ISelectedSubEntity>) GetISelectedEntity(TSD.API.Remoting.Structure.IModel stIModel)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_SelectedEntities_process.GetISelectedEntityAsync(stIModel));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
