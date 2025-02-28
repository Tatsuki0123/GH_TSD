﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Reinforcement;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_ISlabReinforcement_Bottom
{
    public class Get_ISlabReinforcement_Bottom_process
    {


        // Geting solver IModel 
        public static async Task<ISlabReinforcement> GetISlabReinforcement_BottomAsync(TSD.API.Remoting.Structure.ISlabItem islabItem)
        {
            try
            {
                var ISlabReinforcement_Bottom_catched = await islabItem.GetBottomReinforcementAsync();

                if (ISlabReinforcement_Bottom_catched == null)
                {
                    throw new Exception("No ISlabReinforcement_Top found");
                }
                else
                {
                    return (ISlabReinforcement_Bottom_catched);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
