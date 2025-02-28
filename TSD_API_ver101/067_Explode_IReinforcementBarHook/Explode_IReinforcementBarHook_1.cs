using System;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Reinforcement;

namespace TSD_API_ver101_IReinforcementBarHook_Explode
{
    public class Explode_IReinforcementBarHook : GH_Component
    {
        public Explode_IReinforcementBarHook()
          : base("Explode_IReinforcementBarHook_1", "ExplodeReinBarHook_1",
            "Explodes an IReinforcementBarHook into its properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IReinforcementBarHook", "IRBH", "Input IReinforcementBarHook", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Angle", "A", "Gets the angle of the straight part of the hook relative to the adjacent part of the bar curve (in [rad])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Length", "L", "Gets the length of the straight part of the hook (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Radius", "R", "Gets the inner radius of the hook curve (in [mm])", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IReinforcementBarHook inputReinforcementBarHook = null;

            if (!DA.GetData(0, ref inputReinforcementBarHook)) return;

            var angle = inputReinforcementBarHook.Angle.Value;
            var length = inputReinforcementBarHook.Length.Value;
            var radius = inputReinforcementBarHook.Radius.Value;

            DA.SetData(0, angle);
            DA.SetData(1, length);
            DA.SetData(2, radius);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("64793AC3-1AB1-413D-937F-325C6775DC4C");
    }
}
