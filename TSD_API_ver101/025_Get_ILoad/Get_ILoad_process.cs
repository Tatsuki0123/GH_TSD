using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;


namespace TSD_API_ver101_ILoad
{
    public class Get_ILoad_process
    {


        // Geting solver IModel 
        public static async Task<List<TSD.API.Remoting.Loading.ILoad>> GetILoadAsync(TSD.API.Remoting.Loading.ILoadcase Iloadcase)
        {
            try
            {
                IEnumerable<TSD.API.Remoting.Loading.ILoad> Iload = await Iloadcase.GetLoadsAsync();
                List<TSD.API.Remoting.Loading.ILoad> Iload_list = Iload.ToList();

                if (Iload_list == null)
                {
                    throw new Exception("No ILoad found");
                }
                else
                {
                    return (Iload_list);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
