using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_IElement1D
{
    public class Get_SolverElemet_IElement1D_FromMemberSpan_process
    {


        // Geting solver IModel 
        public static async Task<List<TSD.API.Remoting.Solver.IElement1D>> GetIElement1DAsync(TSD.API.Remoting.Solver.IModel solIModel)
        {
            try
            {
                IEnumerable<IElement1D> IElems1D_catched = await solIModel.GetElements1DAsync(null);
                List<IElement1D> IElems1D = new List<IElement1D>();
                IElems1D = IElems1D_catched.ToList();

                if (IElems1D == null)
                {
                    throw new Exception("No INodes found");
                }
                else
                {
                    return (IElems1D);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
