using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_IMemberSpan
{
    public class Get_RigidZone_process
    {


        // Geting solver IModel 
        public static async Task<List<TSD.API.Remoting.Structure.IMemberSpan>> GetIMemberSpanAsync(TSD.API.Remoting.Structure.IMember iMember)
        {
            try
            {
                List<TSD.API.Remoting.Structure.IMemberSpan> list_out = new List<TSD.API.Remoting.Structure.IMemberSpan>();
                var IMember_catched = await iMember.GetSpanAsync(null);
                list_out = IMember_catched.ToList();

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
