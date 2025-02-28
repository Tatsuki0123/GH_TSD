using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;

namespace TSD_API_ver101.Get_IDocument_FileStream

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Get_IDocument_FileStream", "G_IDoc_FileStream",
            "Getting the IDocument FileStreamversion",
            "TSD_API", "Basic_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("tsdInstance", "tsdInst", "Input instance", GH_ParamAccess.item);
            pManager.AddGenericParameter("File Path", "File Path", "Input FilePath", GH_ParamAccess.item);
            pManager.AddGenericParameter("AllowUserInteraction", "AllowUserInteraction", "Input AllowUserInteraction bool", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("IDocument", "IDoc", "IDocument", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            IApplication IApp = null;
            string FilePath = null;
            bool AllowUserInteraction = true;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref IApp)) return;
            if(!DA.GetData(1, ref FilePath)) return;
            if(!DA.GetData(2, ref AllowUserInteraction)) return;    

            // We should now validate the data and warn the user if invalid data is supplied.
            IDocument output_IDoc = null;

            if (IApp != null && FilePath != null)
            {
                output_IDoc = Get_IDocument_FileStream_output.GetIDocumentFileStream(IApp,FilePath,AllowUserInteraction);
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetData(0, output_IDoc);
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
                return Properties.Resources.API_icon;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("C6DECA71-053E-4FBB-BF6E-6D20C14DBBFF") ; }
        }
    }
}