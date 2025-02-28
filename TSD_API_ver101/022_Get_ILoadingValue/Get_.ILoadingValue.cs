using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_ILoadingValue

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Get_ILoadingValue", "G_ILoadingValue",
            "Getting the LoadingValue",
            "TSD_API", "Basic_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IMemberLoading", "IMemberLoading", "Input IMemberLoading", GH_ParamAccess.item);
            pManager.AddGenericParameter("Loading Value Option", "LoadingValueOption", "Input LoadingValueOption", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Span Index", "SpanIndex", "Input SpanIndex", GH_ParamAccess.item);
            pManager.AddGenericParameter("Position", "Position", "Input distance from the start, if there is rigid zone, the part is ignored so subtract the part and input the distance", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("ILoadingValue", "ILoadingValue", "this is ILoadingValue ", GH_ParamAccess.list);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Loading.IMemberLoading input_1 = null;
            LoadingValueOptions input_2 = null;
            int input_3 = 0;
            double input_4 = 0.0; 

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;
            if (!DA.GetData(1, ref input_2)) return;
            if (!DA.GetData(2, ref input_3)) return;
            if (!DA.GetData(3, ref input_4)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            List<TSD.API.Remoting.Loading.ILoadingValue> output_ILoadingValue = null;

            if (input_1 != null)
            {
                output_ILoadingValue = TSD_API_ver101_ILoadingValue.Get_ILoadingValue_output.GetILoadingValue(input_1,input_2,input_3,input_4);
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetDataList(0, output_ILoadingValue);
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
            get { return new Guid("1F529A76-F9E9-40E0-8AF2-F65B4CDD13B1"); }
        }
    }
}