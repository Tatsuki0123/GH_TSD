using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_IMemberLoading
{
    public class Get_LoadingValue_process
    {


        // Geting solver IModel 
        public static async Task<TSD.API.Remoting.Loading.IMemberLoading> GetIMemberLoadingAsync(TSD.API.Remoting.Structure.IMember iMember,Guid guid,AnalysisType analysisType)
        {
            try
            {
                TSD.API.Remoting.Loading.IMemberLoading ImemberLoading = await iMember.GetLoadingAsync(guid, analysisType,LoadingResultType.Base);

                if (ImemberLoading == null)
                {
                    throw new Exception("No AnalysisResult found");
                }
                else
                {
                    return (ImemberLoading);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
