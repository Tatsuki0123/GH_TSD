using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_IConstructionPoint
{
    public class Get_IConstructionPlane_process
    {


        // Geting solver IModel 
        public static async Task<List<TSD.API.Remoting.Structure.IConstructionPoint>> GetIConstructionPointAsync(TSD.API.Remoting.Structure.IModel stIModel)
        {
            try
            {
                List<TSD.API.Remoting.Structure.IConstructionPoint> list_out = new List<TSD.API.Remoting.Structure.IConstructionPoint>();
                var IConPt_catched = await stIModel.GetConstructionPointsAsync(null);
                list_out = IConPt_catched.ToList();

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
