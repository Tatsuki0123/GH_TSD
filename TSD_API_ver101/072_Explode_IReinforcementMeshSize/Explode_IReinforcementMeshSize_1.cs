using System;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Reinforcement;

namespace TSD_API_ver101_IReinforcementMeshSize_Explode
{
    public class Explode_IReinforcementMeshSize : GH_Component
    {
        public Explode_IReinforcementMeshSize()
          : base("Explode_IReinforcementMeshSize", "ExplodeReinMeshSize",
            "Explodes an IReinforcementMeshSize into its properties",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IReinforcementMeshSize", "IRMS", "Input IReinforcementMeshSize", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Description", "D", "Gets the description of the reinforcement", GH_ParamAccess.item);
            pManager.AddGenericParameter("Grade(IReinforcementGrade)", "G(IReinforcementGrade)", "Gets the grade of this reinforcement size", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsUserDefined", "IUD", "Gets a value specifying whether this object is user-defined", GH_ParamAccess.item);
            pManager.AddGenericParameter("MassPerArea", "MPA", "Gets the mass per unit area of the mesh (in [kg/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("MaxPanelLength", "MPL", "Gets the maximum length of a mesh panel (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("MaxPanelWidth", "MPW", "Gets the maximum width of a mesh panel (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Size", "S", "Gets the size name according to the current unit system", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IReinforcementMeshSize inputReinforcementMeshSize = null;

            if (!DA.GetData(0, ref inputReinforcementMeshSize)) return;

            var description = inputReinforcementMeshSize.Description;
            var grade = inputReinforcementMeshSize.Grade;
            var isUserDefined = inputReinforcementMeshSize.IsUserDefined;
            var massPerArea = inputReinforcementMeshSize.MassPerArea;
            var maxPanelLength = inputReinforcementMeshSize.MaxPanelLength;
            var maxPanelWidth = inputReinforcementMeshSize.MaxPanelWidth;
            var size = inputReinforcementMeshSize.Size;

            DA.SetData(0, description);
            DA.SetData(1, grade);
            DA.SetData(2, isUserDefined);
            DA.SetData(3, massPerArea);
            DA.SetData(4, maxPanelLength);
            DA.SetData(5, maxPanelWidth);
            DA.SetData(6, size);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon; // Replace with appropriate icon

        public override Guid ComponentGuid => new Guid("8071320E-8716-4283-9356-03CA6B99DDFA");
    }
}
