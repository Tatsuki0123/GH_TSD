using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Sections;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_INonParametricSections_with3input
{
    public class Get_INonParametricSections_with3input_output
    {
        // Task -> Object
        public static List<INonParametricSection> GetINonParametricSections_with3input(TSD.API.Remoting.Sections.ISectionFactory iSectionFactory, SectionGroup sectionGroup, int limit, HeadCode headCode)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Get_INonParametricSections_with3input_process.GetINonParametricSections_with3inputAsync(iSectionFactory, sectionGroup, limit,headCode));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                return null;
                //throw new Exception("Error during Task -> object");
            }
        }

    }
}
