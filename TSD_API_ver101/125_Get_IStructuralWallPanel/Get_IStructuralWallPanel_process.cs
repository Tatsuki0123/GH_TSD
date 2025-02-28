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
    public class Get_IStructuralWallPanel_process
    {


        // Geting solver IModel 
        public static async Task<List<TSD.API.Remoting.Structure.IStructuralWallPanel>> GetIStructuralWallPanelAsync(TSD.API.Remoting.Structure.IStructuralWall iStructuralWall)
        {
            try
            {
                List<TSD.API.Remoting.Structure.IStructuralWallPanel> list_out = new List<TSD.API.Remoting.Structure.IStructuralWallPanel>();
                var IStructuralWall_catched = await iStructuralWall.GetSpanAsync(null);
                list_out = IStructuralWall_catched.ToList();

                if (list_out == null)
                {
                    throw new Exception("No AnalysisResult found");
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
