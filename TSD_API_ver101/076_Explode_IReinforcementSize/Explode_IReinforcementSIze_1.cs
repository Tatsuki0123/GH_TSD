using System;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Reinforcement;

namespace TSD_API_ver101_IReinforcementSize_Explode
{
    public class Explode_IReinforcementSize : GH_Component
    {
        public Explode_IReinforcementSize()
          : base("Explode_IReinforcementSize_1", "ExplodeReinSize_1",
            "Explodes an IReinforcementSize into its properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IReinforcementSize", "IRS", "Input IReinforcementSize", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Description", "D", "Gets the description of the reinforcement", GH_ParamAccess.item);
            pManager.AddGenericParameter("Grade(IReinforcementGrade)", "G(IReinforcementGrade)", "Gets the grade of this reinforcement size", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsUserDefined", "IUD", "Gets a value specifying whether this object is user-defined", GH_ParamAccess.item);
            pManager.AddGenericParameter("Size", "S", "Gets the size name according to the current unit system", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IReinforcementSize inputReinforcementSize = null;

            if (!DA.GetData(0, ref inputReinforcementSize)) return;

            var description = inputReinforcementSize.Description;
            var grade = inputReinforcementSize.Grade;
            var isUserDefined = inputReinforcementSize.IsUserDefined;
            var size = inputReinforcementSize.Size;

            DA.SetData(0, description);
            DA.SetData(1, grade);
            DA.SetData(2, isUserDefined);
            DA.SetData(3, size);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon; // Replace with appropriate icon

        public override Guid ComponentGuid => new Guid("8C9465BF-E35D-476B-BB3E-839453EE718B");
    }
}
