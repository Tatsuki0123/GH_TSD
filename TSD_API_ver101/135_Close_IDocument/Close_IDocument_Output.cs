using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;

namespace TSD_API_ver101_Close_IDocument
{
    public class Close_IDocument_Output
    {
        // Task -> Object
        public static string CloseIDocument(IDocument Idoc)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => 
                

                    await Close_IDocument_Process.CloseIDocumentAsync(Idoc)
                    
                );
                
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
