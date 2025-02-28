using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_ILoadingValue
{
    public class Get_ILoadingValue_process
    {


        // Geting solver IModel 
        public static async Task<List<ILoadingValue>> GetILoadingValueAsync(TSD.API.Remoting.Loading.IMemberLoading iMemberloading,LoadingValueOptions loadingValueOptions,int SpanIndex,double position)
        {
            try
            {
                IEnumerable<ILoadingValue> LoadingValue = await iMemberloading.GetValueAsync(loadingValueOptions, SpanIndex, position);
                List<ILoadingValue> List_LoadingValue = new List<ILoadingValue>();
                List_LoadingValue = LoadingValue.ToList();

                if (List_LoadingValue == null)
                {
                    throw new Exception("No AnalysisResult found");
                }
                else
                {
                    return (List_LoadingValue);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
