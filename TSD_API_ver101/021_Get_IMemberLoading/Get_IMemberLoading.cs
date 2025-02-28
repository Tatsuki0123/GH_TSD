using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_IMemberLoading

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Get_IMemberLoading", "G_IMemLoad",
            "Getting the IMemberLoading",
            "TSD_API", "Basic_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IMember", "IMember", "Input structure IMember", GH_ParamAccess.item);
            pManager.AddGenericParameter("Loadcase ID", "LoadcaseID", "Input LoadcaseID", GH_ParamAccess.item);
            pManager.AddGenericParameter("AnalysisType", "AnalysisType", "Input AnalysisType", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("IMemberLoading", "IMemberLoading", "this is IMemberLoading", GH_ParamAccess.item);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Structure.IMember input_1 = null;
            Guid input_2 = Guid.Empty;
            AnalysisType input_3 = AnalysisType.None;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;
            if (!DA.GetData(1, ref input_2)) return;
            if (!DA.GetData(2, ref input_3)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            TSD.API.Remoting.Loading.IMemberLoading output_IMemberLoading = null;

            if (input_1 != null && input_2 != null && input_3 != AnalysisType.None)
            {
                output_IMemberLoading = TSD_API_ver101_IMemberLoading.Get_ILoadingValue_output.GetIMemberLoading(input_1,input_2,input_3);
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetData(0, output_IMemberLoading);
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
            get { return new Guid("4FFE8D80-1A12-40B6-9EB3-8FBD165493D5"); }
        }
    }
}