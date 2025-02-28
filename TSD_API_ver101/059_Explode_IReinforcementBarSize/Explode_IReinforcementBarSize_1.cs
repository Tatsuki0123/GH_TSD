using System;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Reinforcement;

namespace TSD_API_ver101_IReinforcementBarSize_Explode
{
    public class Explode_IReinforcementBarSize : GH_Component
    {
        public Explode_IReinforcementBarSize()
          : base("Explode_IReinforcementBarSize_1", "ExplodeReinBarSize_1",
            "Explodes an IReinforcementBarSize into its various properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IReinforcementBarSize", "IRBS", "Input IReinforcementBarSize", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Area", "A", "Gets the cross-sectional area of the bar (in [mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Description", "D", "Gets the description of the reinforcement", GH_ParamAccess.item);
            pManager.AddGenericParameter("Diameter", "Dia", "Gets the bar diameter (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("IReinforcementGrade", "IReinforcementGrade", "Gets the grade of this reinforcement size", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsUserDefined", "IUD", "Gets a value specifying whether this object is user-defined", GH_ParamAccess.item);
            pManager.AddGenericParameter("MassPerLength", "MPL", "Gets the mass per unit length of the bar (in [kg/mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("MaxBarLength", "MBL", "Gets the maximum bar length (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Size", "S", "Gets the size name according to the current unit system", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IReinforcementBarSize inputReinforcementBarSize = null;

            if (!DA.GetData(0, ref inputReinforcementBarSize)) return;

            var area = inputReinforcementBarSize.Area;
            var description = inputReinforcementBarSize.Description;
            var diameter = inputReinforcementBarSize.Diameter;
            var grade = inputReinforcementBarSize.Grade;
            var isUserDefined = inputReinforcementBarSize.IsUserDefined;
            var massPerLength = inputReinforcementBarSize.MassPerLength;
            var maxBarLength = inputReinforcementBarSize.MaxBarLength;
            var size = inputReinforcementBarSize.Size;

            DA.SetData(0, area);
            DA.SetData(1, description);
            DA.SetData(2, diameter);
            DA.SetData(3, grade);
            DA.SetData(4, isUserDefined);
            DA.SetData(5, massPerLength);
            DA.SetData(6, maxBarLength);
            DA.SetData(7, size);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("607B2B7C-E3C8-41F0-A973-676D8AA81EB8");
    }
}
