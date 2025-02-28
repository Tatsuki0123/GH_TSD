using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_IStructuralWallPanel
{
    public class Get_IStructuralWallPanel_output
    {
        // Task -> Object
        public static List<TSD.API.Remoting.Structure.IStructuralWallPanel> GetIStructuralWallPanel(TSD.API.Remoting.Structure.IStructuralWall iStructuralWall)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_IStructuralWallPanel_process.GetIStructuralWallPanelAsync(iStructuralWall));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
