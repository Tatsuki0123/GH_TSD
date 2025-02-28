using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;

namespace TSD_API_ver101_Save_IDocument
{
    public class Save_IDocument_Output
    {
        // Task -> Object
        public static string SaveIDocument(IDocument Idoc, string filepath, bool modelonly)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => 
                

                    await Save_IDocument_Process.SaveIDocumentAsync(Idoc, filepath, modelonly)
                    
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
