using System;
using System.Linq;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Reinforcement;

namespace TSD_API_ver101_IReinforcementMeshDetailingGroup_Explode
{
    public class Explode_IReinforcementMeshDetailingGroup : GH_Component
    {
        public Explode_IReinforcementMeshDetailingGroup()
          : base("Explode_IReinforcementMeshDetailingGroup", "ExplodeReinMeshDetailGroup",
            "Explodes an IReinforcementMeshDetailingGroup into its properties",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IReinforcementMeshDetailingGroup", "IRMDG", "Input IReinforcementMeshDetailingGroup", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("DetailingPrefix", "DP", "Gets the detailing prefix of the reinforcement grade used in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsApplicable", "IA", "Gets a value indicating whether the property is applicable", GH_ParamAccess.item);
            pManager.AddGenericParameter("Size(IReinforcementMeshSize)", "S(IReinforcementMeshSize)", "Gets the size of the meshes used in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("TestStatus", "TS", "Gets the test status of the property", GH_ParamAccess.item);
            pManager.AddGenericParameter("Value(List_IReninforcementMesh)", "V(List_IReninforcementMesh)", "Gets the value of this property", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IReinforcementMeshDetailingGroup inputReinforcementMeshDetailingGroup = null;

            if (!DA.GetData(0, ref inputReinforcementMeshDetailingGroup)) return;

            var detailingPrefix = inputReinforcementMeshDetailingGroup.DetailingPrefix.Value;
            var isApplicable = inputReinforcementMeshDetailingGroup.IsApplicable;
            var size = inputReinforcementMeshDetailingGroup.Size.Value;
            var testStatus = inputReinforcementMeshDetailingGroup.TestStatus;
            var value = inputReinforcementMeshDetailingGroup.Value.Select(i=>i.Value).ToList();

            DA.SetData(0, detailingPrefix);
            DA.SetData(1, isApplicable);
            DA.SetData(2, size);
            DA.SetData(3, testStatus);
            DA.SetDataList(4, value);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon; // Replace with appropriate icon

        public override Guid ComponentGuid => new Guid("BCA7BF09-BC2D-4826-9D07-69F9BC63AA75");
    }
}
