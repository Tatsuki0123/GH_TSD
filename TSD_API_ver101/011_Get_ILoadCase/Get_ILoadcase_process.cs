﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_ILoadcase
{
    public class Get_IMember_process
    {


        // Geting solver IModel 
        public static async Task<List<TSD.API.Remoting.Loading.ILoadcase>> GetILoadcaseAsync(TSD.API.Remoting.Structure.IModel stIModel)
        {
            try
            {
                List<ILoadcase> list_out = new List<ILoadcase>();
                var ILoadcase_catched = await stIModel.GetLoadcasesAsync();
                list_out = ILoadcase_catched.ToList();

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
