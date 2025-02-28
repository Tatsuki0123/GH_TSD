using System;
using System.Linq;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Geometry;

namespace TSD_API_ver101_ICompositeCurve2D_Explode
{
    public class Explode_ICompositeCurve2D : GH_Component
    {
        public Explode_ICompositeCurve2D()
          : base("Explode_ICompositeCurve2D_1", "ExplodeCompCurve2D_1",
            "Explodes an ICompositeCurve2D into its segments ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ICompositeCurve2D", "ICC2D", "Input ICompositeCurve2D", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Segments2D", "Segs2D", "Gets the collection of segments", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            ICompositeCurve2D inputCompositeCurve2D = null;

            if (!DA.GetData(0, ref inputCompositeCurve2D)) return;

            var segments = inputCompositeCurve2D.Segments.Value.Select(i=>i.Value).ToList();

            DA.SetDataList(0, segments);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("39310E97-AB8D-4982-B902-3B8C0D8BA8E0");
    }
}
