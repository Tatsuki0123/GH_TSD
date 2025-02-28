using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_GetNodalReaction

{
    public class Get_NodalReaction_process
    {


        // Geting solver IModel 
        public static async Task<List<TSD.API.Remoting.Solver.INodalForce>> GetNodalReactionAsync(TSD.API.Remoting.Solver.IAnalysis3DResults IanalysisResult3D, Guid guid)
        {
            try
            {
                IEnumerable<INodalForce> INodalForce_catched = await IanalysisResult3D.GetNodalReactionsAsync(guid,LoadingResultType.Base,null);
                List<INodalForce> INodalforce = new List<INodalForce>();
                INodalforce = INodalForce_catched.ToList();

                if (INodalforce == null)
                {
                    throw new Exception("No IElements found");
                }
                else
                {
                    return (INodalforce);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
