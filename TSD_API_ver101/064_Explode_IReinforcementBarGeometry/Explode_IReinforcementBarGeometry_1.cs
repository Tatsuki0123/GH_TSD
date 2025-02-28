using System;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Geometry;
using TSD.API.Remoting.Reinforcement;

namespace TSD_API_ver101_IReinforcementBarGeometry_Explode
{
    public class Explode_IReinforcementBarGeometry : GH_Component
    {
        public Explode_IReinforcementBarGeometry()
          : base("Explode_IReinforcementBarGeometry_1", "ExplodeReinBarGeom_1",
            "Explodes an IReinforcementBarGeometry into its various properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IReinforcementBarGeometry", "IRBG", "Input IReinforcementBarGeometry", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Curve(ICompositeCurve2D)", "C(ICompositeCurve2D)", "Gets the bar curve excluding the hooks", GH_ParamAccess.item);
            pManager.AddGenericParameter("EndHook(IReinforcementBarHook)", "EH(IReinforcementBarHook)", "Gets the geometry of the hook at the end of the bar curve", GH_ParamAccess.item);
            pManager.AddGenericParameter("StartHook(IReinforcementBarHook)", "SH(IReinforcementBarHook)", "Gets the geometry of the hook at the start of the bar curve", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IReinforcementBarGeometry inputReinforcementBarGeometry = null;

            if (!DA.GetData(0, ref inputReinforcementBarGeometry)) return;


            ICompositeCurve2D curve = null;
            IReinforcementBarHook endHook = null;
            IReinforcementBarHook startHook = null;


            try { curve = inputReinforcementBarGeometry.Curve.Value; }
            catch { curve = null; }

            try { endHook = inputReinforcementBarGeometry.EndHook.Value; }
            catch { endHook =  null; }


            try { startHook = inputReinforcementBarGeometry.StartHook.Value; }
            catch { startHook = null; }

            DA.SetData(0, curve);
            DA.SetData(1, endHook);
            DA.SetData(2, startHook);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("0FA7853E-9ABF-430E-9E4B-800BDB911890");
    }
}
