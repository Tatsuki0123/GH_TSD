using System;
using System.Collections.Generic;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Loading;

namespace TSD_API_ver101_ILoadCaseFactors_Explode
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_ILoadCaseFactors_1", "E_ILoadCaseFactors_1",
            "Exploding the ILoadCaseFactors ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ILoadCaseFactors", "ILoadCaseFactors", "Input ILoadCaseFactors", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("LoadcaseId", "LoadcaseId", "Gets the loadcase ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("ServiceFactor", "ServiceFactor", "Gets the service factor", GH_ParamAccess.item);
            pManager.AddGenericParameter("ServiceQuasiFactor", "ServiceQuasiFactor", "Gets the service quasi factor", GH_ParamAccess.item);
            pManager.AddGenericParameter("StrengthFactor", "StrengthFactor", "Gets the strength factor", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Loading.ILoadcaseFactors input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            Guid output_loadcaseId = Guid.Empty;
            double output_serviceFactor = 0.0;
            double output_serviceQuasiFactor = 0.0;
            double output_strengthFactor = 0.0;

            if (input_1 != null)
            {
                try { output_loadcaseId = input_1.LoadcaseId.Value; }
                catch { output_loadcaseId = Guid.Empty; }

                try { output_serviceFactor = input_1.ServiceFactor.Value; }
                catch { output_serviceFactor = 0.0; }

                try { output_serviceQuasiFactor = input_1.ServiceQuasiFactor.Value; }
                catch { output_serviceQuasiFactor = 0.0; }

                try { output_strengthFactor = input_1.StrengthFactor.Value; }
                catch { output_strengthFactor = 0.0; }
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "ILoadCaseFactors is not provided or invalid.");
            }

            // Setting the output parameters
            DA.SetData(0, output_loadcaseId);
            DA.SetData(1, output_serviceFactor);
            DA.SetData(2, output_serviceQuasiFactor);
            DA.SetData(3, output_strengthFactor);
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
            get { return new Guid("892CD2AB-89B4-4007-A91B-981268FB0412"); }
        }
    }
}
