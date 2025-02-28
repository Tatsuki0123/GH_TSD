using System;
using System.Collections.Generic;
using System.Linq;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_solIModelIEnu
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Get_IEnu_solverIModel", "G_IEnu_solIModel",
            "Getting the IEnumerable of solver IModel",
            "TSD_API", "Basic_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("structure IModel", "stIModel", "Input structure IModel", GH_ParamAccess.item);
            pManager.AddGenericParameter("IEnumerable Analysis Type", "IEnu_AT", "Input IEnumerable of Analysis Type using analysis type component", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("IEnumerable solver IModel", "IEnu_solIModel", "IEnumerable of solIModel", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Structure.IModel input_1 = null;
            List<AnalysisType> input_2_pre = new List<AnalysisType>();

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;
            if (!DA.GetDataList(1, input_2_pre)) return;

            IEnumerable<AnalysisType> input_2 = input_2_pre;
            

            // We should now validate the data and warn the user if invalid data is supplied.
            List<TSD.API.Remoting.Solver.IModel> output = new List<TSD.API.Remoting.Solver.IModel>();

            if (input_1 != null && input_2 != null)
            {
                output = Get_AnalysisResult_output.GetsolIModelIEnu(input_1,input_2).ToList<TSD.API.Remoting.Solver.IModel>();
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetDataList(0, output);
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
            get { return new Guid("0857909C-A735-4401-BEBB-DD97B72905BF"); }
            
        }
    }
}