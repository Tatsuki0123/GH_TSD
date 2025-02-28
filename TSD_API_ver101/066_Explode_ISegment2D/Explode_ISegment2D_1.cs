using System;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Geometry;

namespace TSD_API_ver101_ISegment2D_Explode
{
    public class Explode_ISegment2D : GH_Component
    {
        public Explode_ISegment2D()
          : base("Explode_ISegment2D_1", "ExplodeSegment2D_1",
            "Explodes an ISegment2D into its properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ISegment2D", "Seg2D", "Input ISegment2D", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Magnitude", "Mag", "Gets the magnitude", GH_ParamAccess.item);
            pManager.AddGenericParameter("Type", "Type", "Gets the type of the segment", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            ISegment2D inputSegment2D = null;

            if (!DA.GetData(0, ref inputSegment2D)) return;

            var magnitude = inputSegment2D.Magnitude.Value;
            var type = inputSegment2D.Type.Value;

            DA.SetData(0, magnitude);
            DA.SetData(1, type);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("09B644F4-6ADA-4D2D-A95C-60882C2F910D");
    }
}
