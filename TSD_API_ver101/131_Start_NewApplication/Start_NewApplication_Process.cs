using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;


namespace TSD_API_ver101_Start_NewApplication
{
    public class Create_IDocument_Process
    {
        // Get the first running TSD instance found asynchronously
        public static async Task<IApplication> StartNewApplicationAsync()
        {
            try
            {
                using (CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromMinutes(1)))
                {
                    var tsdInstance = await ApplicationFactory.StartNewApplicationAsync(cts.Token);

                    if (tsdInstance != null)
                    {
                        // Wait until tsdInstance.Connected is true or timeout occurs
                        while (!tsdInstance.Connected)
                        {
                            await Task.Delay(500, cts.Token); // Check every 500ms
                        }
                        return tsdInstance;
                    }
                    else
                    {
                        throw new Exception("Error during getting instance");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                throw new Exception("Timeout occurred while waiting for the application to connect.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error during getting instance_1", ex);
            }
        }
    }

}
