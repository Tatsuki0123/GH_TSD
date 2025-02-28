using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;

namespace TSD_API_ver101_Save_IDocument
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Save_IDocument", "Save_IDocument",
            "Save_IDocument",
            "TSD_API", "Util_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Activate", "A", "Activate and get tsdInstance", GH_ParamAccess.item, false);
            pManager.AddGenericParameter("IDocument", "IDocument", "IDocument", GH_ParamAccess.item);
            pManager.AddGenericParameter("File Path", "File Path", "File Path to save", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Model Only", "Model Only", "If true only Model is saved, false -> Model and result is asaved", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("task comment", "task comment", "task comment", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            bool Active_status = false;
            IDocument Idoc = null;
            string filepath = null;
            bool modelonly = false;
            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref Active_status)) return;
            if (!DA.GetData(1, ref Idoc)) return;   
            if(!DA.GetData(2, ref filepath)) return;
            if(!DA.GetData(3, ref  modelonly)) return;  

            // We should now validate the data and warn the user if invalid data is supplied.
            string output_comment = "Not yet processed";

            if (Active_status && Idoc != null && filepath != null)
            {
                output_comment = TSD_API_ver101_Save_IDocument.Save_IDocument_Output.SaveIDocument(Idoc, filepath, modelonly);
                

            }
            else
            {
                output_comment = "Process failed";

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetData(0, output_comment);
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
            get { return new Guid("B12F7EBE-16B2-4078-837E-DBB2E10E7ABD"); }
        }

        public object TSD_API_ver101_Get_RunningApplicatinInfo { get; private set; }
    }
}