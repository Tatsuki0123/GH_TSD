using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Sections;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_INonParametricSections_with3input
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Get_INonParametricSections_with3input", "G_INonParametricSections_with3input",
            "Getting theINonParametricSections_with3input",
            "TSD_API", "Basic_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ISectionFactory", "ISectionFactory", "Input ISectionFactory", GH_ParamAccess.item);
            pManager.AddGenericParameter("SectionGroup", "SectionGroup", "Input SectionGroup", GH_ParamAccess.item);
            pManager.AddIntegerParameter("limit number of output sections", "Limit", "Input limit number of sections", GH_ParamAccess.item);
            pManager.AddGenericParameter("HeadCode", "HeadCode", "Input Headcode", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("INonParametricSections", "INonParametricSections", "this is the list of INonParametricSections", GH_ParamAccess.list);
            pManager.AddGenericParameter("Name", "Name", "this is the list of section name", GH_ParamAccess.list);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Sections.ISectionFactory input_1 = null;
            SectionGroup input_2 = SectionGroup.Unknown;
            int input_3 = 100;
            HeadCode input_4 = HeadCode.Unknown;
            

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;
            if (!DA.GetData(1, ref input_2)) return;
            if (!DA.GetData(2, ref input_3)) return;
            if (!DA.GetData(3, ref input_4)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            List<INonParametricSection> output_list = null;

            if (input_1 != null)
            {
                output_list = TSD_API_ver101_INonParametricSections_with3input.Get_INonParametricSections_with3input_output.GetINonParametricSections_with3input(input_1,input_2,input_3,input_4);
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetDataList(0, output_list);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return TSD_API_ver101.Properties.Resources.API_icon;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("8B68D0D5-6983-4928-A0FC-579657799923"); }
        }
    }
}