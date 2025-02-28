using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_INode
{
    public class Get_IElement1D_process
    {


        // Geting solver IModel 
        public static async Task<List<TSD.API.Remoting.Solver.INode>> GetINodeAsync(TSD.API.Remoting.Solver.IModel solIModel)
        {
            try
            {
                IEnumerable<INode> INodes_catched = await solIModel.GetNodesAsync(null);
                List<INode> INodes = new List<INode>();
                INodes = INodes_catched.ToList();

                if (INodes == null)
                {
                    throw new Exception("No INodes found");
                }
                else
                {
                    return (INodes);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
