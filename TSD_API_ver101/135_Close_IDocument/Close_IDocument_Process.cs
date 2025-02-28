using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;


namespace TSD_API_ver101_Close_IDocument
{
    public class Close_IDocument_Process
    {
        // Get the first running TSD instance found asynchronously
        public static async Task<string> CloseIDocumentAsync(IDocument Idoc)
        {
            try
            {
                using (CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromMinutes(1)))
                {
                    var boolendesu = true;
                    await Idoc.CloseAsync(boolendesu);

                    if (Idoc != null)
                    {
                        return "Done";
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
