using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;

namespace TSD_API_ver101_Create_IDocument
{
    public class Create_IDocument_Output
    {
        // Task -> Object
        public static IDocument CreateIDocument(IApplication app, bool allowUserInteraction)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => 
                

                    await Save_IDocument_Process.CreateIDocumentAsync(app, allowUserInteraction)
                    
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
