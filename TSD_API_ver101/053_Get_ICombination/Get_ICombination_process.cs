﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_ICombination
{
    public class Get_ICombination_process
    {


        // Geting solver IModel 
        public static async Task<List<TSD.API.Remoting.Loading.ICombination>> GetICombinationAsync(TSD.API.Remoting.Structure.IModel stIModel)
        {
            try
            {
                List<ICombination> list_out = new List<ICombination>();
                var Item_catched = await stIModel.GetCombinationsAsync();
                list_out = Item_catched.ToList();

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
