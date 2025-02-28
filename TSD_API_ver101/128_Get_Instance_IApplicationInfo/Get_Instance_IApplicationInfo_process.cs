using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;


namespace TSD_API_ver101.Get_Instance_IApplicationInfo
{
    public class Get_Instance_IApplicationInfo_process
    {


        // Geting Documents task
        public static async Task<IApplication> GetInstanceIApplicationInfoAsync(IApplicationInfo IapplicationInfo)
        {
            try
            {
                
                var instance = await ApplicationFactory.ConnectToRunningApplicationAsync(IapplicationInfo);

                if (instance == null)
                {
                    throw new Exception("No document found");
                }
                else
                {
                    return instance;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
