using System;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Reinforcement;

namespace TSD_API_ver101_ISlabReinforcement_Explode
{
    public class Explode_ISlabReinforcement : GH_Component
    {
        public Explode_ISlabReinforcement()
          : base("Explode_ISlabReinforcement_1", "ExplodeSlabReinforcement_1",
            "Explodes an ISlabReinforcement into its properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ISlabReinforcement", "ISR", "Input ISlabReinforcement", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("AreaPerLength", "APL", "Gets the area per unit length of the reinforcement (in [mm²/mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("BarDistance", "BD", "Gets the distance between individual bars (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("BarDistanceInside", "BDI", "Gets the distance between individual bars in the inside layer (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("BarDistanceOutside", "BDO", "Gets the distance between individual bars in the outside layer (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("GeometryInside", "GI", "Gets the reinforcement geometry of the inner layer", GH_ParamAccess.item);
            pManager.AddGenericParameter("GeometryOutside", "GO", "Gets the reinforcement geometry of the outer layer", GH_ParamAccess.item);
            pManager.AddGenericParameter("HasBarSpacingByHollowCores", "HBSHC", "Gets a value indicating whether the bar spacing is determined by spacing of hollow cores", GH_ParamAccess.item);
            pManager.AddGenericParameter("HasMainBarsInInnerLayer", "HMBIL", "Gets a value indicating whether the main mesh bars are located in the inner layer", GH_ParamAccess.item);
            pManager.AddGenericParameter("HasMainMeshInXDirection", "HMMXD", "Gets a value indicating whether the main mesh is in X direction", GH_ParamAccess.item);
            pManager.AddGenericParameter("HasOutsideLayerInXDirection", "HOLXD", "Gets a value indicating whether the outside layer is in X direction", GH_ParamAccess.item);
            pManager.AddGenericParameter("HasReinforcementIn2Layers", "HRL2", "Gets a value indicating whether the reinforcement is set in two layers ('inside' and 'outside')", GH_ParamAccess.item);
            pManager.AddGenericParameter("HollowCoresBetweenBarsCount", "HCBC", "Gets the number of hollow cores between bars", GH_ParamAccess.item);
            pManager.AddGenericParameter("ReinforcementType", "RT", "Gets the type of reinforcement", GH_ParamAccess.item);
            pManager.AddGenericParameter("SizeInside(IReinforcementSize)", "SI(IReinforcementSize)", "Gets the reinforcement size in the inside layer", GH_ParamAccess.item);
            pManager.AddGenericParameter("SizeOutside(IReinforcementSize)", "SO(IReinforcementSize)", "Gets the reinforcement size in the outside layer", GH_ParamAccess.item);
            pManager.AddGenericParameter("Strength", "ST", "Gets the reinforcement strength (in [N/mm²])", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            ISlabReinforcement inputSlabReinforcement = null;

            if (!DA.GetData(0, ref inputSlabReinforcement)) return;

            var areaPerLength = inputSlabReinforcement.AreaPerLength.Value;
            var barDistance = inputSlabReinforcement.BarDistance.Value;
            var barDistanceInside = inputSlabReinforcement.BarDistanceInside.Value;
            var barDistanceOutside = inputSlabReinforcement.BarDistanceOutside.Value;
            var geometryInside = inputSlabReinforcement.GeometryInside.Value;
            var geometryOutside = inputSlabReinforcement.GeometryOutside.Value;
            var hasBarSpacingByHollowCores = inputSlabReinforcement.HasBarSpacingByHollowCores.Value;
            var hasMainBarsInInnerLayer = inputSlabReinforcement.HasMainBarsInInnerLayer.Value;
            var hasMainMeshInXDirection = inputSlabReinforcement.HasMainMeshInXDirection.Value;
            var hasOutsideLayerInXDirection = inputSlabReinforcement.HasOutsideLayerInXDirection.Value;
            var hasReinforcementIn2Layers = inputSlabReinforcement.HasReinforcementIn2Layers.Value;
            var hollowCoresBetweenBarsCount = inputSlabReinforcement.HollowCoresBetweenBarsCount.Value;
            var reinforcementType = inputSlabReinforcement.ReinforcementType.Value;
            var sizeInside = inputSlabReinforcement.SizeInside.Value;
            var sizeOutside = inputSlabReinforcement.SizeOutside.Value;
            var strength = inputSlabReinforcement.Strength.Value;

            DA.SetData(0, areaPerLength);
            DA.SetData(1, barDistance);
            DA.SetData(2, barDistanceInside);
            DA.SetData(3, barDistanceOutside);
            DA.SetData(4, geometryInside);
            DA.SetData(5, geometryOutside);
            DA.SetData(6, hasBarSpacingByHollowCores);
            DA.SetData(7, hasMainBarsInInnerLayer);
            DA.SetData(8, hasMainMeshInXDirection);
            DA.SetData(9, hasOutsideLayerInXDirection);
            DA.SetData(10, hasReinforcementIn2Layers);
            DA.SetData(11, hollowCoresBetweenBarsCount);
            DA.SetData(12, reinforcementType);
            DA.SetData(13, sizeInside);
            DA.SetData(14, sizeOutside);
            DA.SetData(15, strength);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon; // Replace with appropriate icon

        public override Guid ComponentGuid => new Guid("98FC729D-8AE5-415A-83F9-03ADC7458114");
    }
}
