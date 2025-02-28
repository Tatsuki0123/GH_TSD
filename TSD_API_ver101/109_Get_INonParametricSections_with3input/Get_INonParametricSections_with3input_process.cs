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
    public class Get_INonParametricSections_with3input_process
    {


        // Geting solver IModel 
        public static async Task<List<TSD.API.Remoting.Sections.INonParametricSection>> GetINonParametricSections_with3inputAsync(TSD.API.Remoting.Sections.ISectionFactory iSectionFactory, SectionGroup sectionGroup, int limit,HeadCode headCode)
        {
            try
            {
                List<INonParametricSection> list_out = new List<INonParametricSection>();
                var Item_catched = await iSectionFactory.GetNonParametricSectionsAsync(headCode,sectionGroup,limit);
                list_out = Item_catched.ToList();

                if (list_out == null)
                {
                    throw new Exception("No item found");
                }
                else
                {
                    return (list_out);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }



    }
}
