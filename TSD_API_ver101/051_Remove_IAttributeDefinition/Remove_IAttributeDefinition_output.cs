﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;

namespace TSD_API_ver101_Remove_IAttributeDefinition
{
    public class Remove_IAttributeDefinition_output
    {
        // Task -> Object
        public static String RemoveIAttributeDefinition(TSD.API.Remoting.Structure.IModel iModel,IAttributeDefinition IAttributeDefinition)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Remove_IAttributeDefinition_process.RemoveIAttributeDefinitionAsync(iModel,IAttributeDefinition));
                return "UDAs Removed";
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
