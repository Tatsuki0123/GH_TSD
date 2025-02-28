using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;


namespace TSD_API_ver101_Save_IDocument
{
    public class Save_IDocument_Process
    {
        // Get the first running TSD instance found asynchronously
        public static async Task<string> SaveIDocumentAsync(IDocument Idoc, string filepath, bool modelonly)
        {
            try
            {
                //using (CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromMinutes(1)))
                {
                    await Idoc.SaveToAsync(filepath, modelonly);
                    string output_comment = "Done";

                    if (output_comment != null)
                    {
                        return output_comment;
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
