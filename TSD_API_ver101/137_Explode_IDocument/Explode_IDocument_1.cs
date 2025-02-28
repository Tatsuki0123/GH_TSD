using System;
using System.Drawing;
using Grasshopper.Kernel;
using TSD.API.Remoting.Document;

namespace TSD_API
{
    public class Explode_IDocument : GH_Component
    {
        public Explode_IDocument()
          : base("Explode_IDocument", "E_IDocument",
              "Explodes the IDocument interface to retrieve its properties",
              "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IDocument", "IDoc", "The IDocument instance to explode", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("ModelId", "ModelId", "The ID of the model contained in the document", GH_ParamAccess.item);
            pManager.AddGenericParameter("Path", "Path", "The path of the document file on disk (empty if not saved)", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IDocument iDoc = null;
            if (!DA.GetData(0, ref iDoc)) return;

            if (iDoc != null)
            {
                DA.SetData("ModelId", iDoc.ModelId);
                DA.SetData("Path", iDoc.Path);
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "IDocument input is null.");
            }
        }

        public override GH_Exposure Exposure => GH_Exposure.primary;

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return TSD_API_ver101.Properties.Resources.API_icon;
            }
        }

        public override Guid ComponentGuid => new Guid("D416A8D4-4C21-47D5-8D5F-879F7D2D764E");
    }
}
