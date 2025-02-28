using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;

namespace TSD_API_ver101.Get_IDocument_FileStream
{
    public class Get_IDocument_FileStream_output
    {
        // Task -> Object
        public static IDocument GetIDocumentFileStream(IApplication IApp, string filepath, bool allowUserInteraction)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_IDocument_FileStream_process.GetDocumentFileStreamAsync(IApp,filepath,allowUserInteraction));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
