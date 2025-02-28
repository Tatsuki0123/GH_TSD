using System;
using System.Collections.Generic;
using System.Linq;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Reinforcement;

namespace TSD_API_ver101_ILongitudinalBarDetailingGroup_Explode
{
    public class Explode_ILongitudinalBarDetailingGroup : GH_Component
    {
        public Explode_ILongitudinalBarDetailingGroup()
          : base("Explode_ILongitudinalBarDetailingGroup_1", "ExplodeLongBarDetailGrp_1",
            "Explodes an ILongitudinalBarDetailingGroup into its various properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ILongitudinalBarDetailingGroup", "ILBDG", "Input ILongitudinalBarDetailingGroup", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("BarMark", "BM", "Gets the mark of the bars used in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("DesignSpacing", "DS", "Gets the design spacing of the bars (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("DetailingPrefix", "DP", "Gets the detailing prefix of the reinforcement grade used in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsApplicable", "IA", "Gets a value indicating whether the property is applicable", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsSideFaceBarGroup", "ISFBG", "Gets a value indicating whether the group is positioned at a side face of a beam", GH_ParamAccess.item);
            pManager.AddGenericParameter("LayerIndex", "LI", "Gets the index of the layer (in the group's own zone) of bars the group holds (if used in a beam)", GH_ParamAccess.item);
            pManager.AddGenericParameter("LayerIndicesTop", "LIT", "The index of the layer in the top zone", GH_ParamAccess.list);
            pManager.AddGenericParameter("LayerIndicesBottom", "LIB", "The index of the layer in the bottom zone", GH_ParamAccess.list);
            pManager.AddGenericParameter("PatternBarNumber", "PBN", "Gets the pattern number of the bars included in this group", GH_ParamAccess.item);
            pManager.AddGenericParameter("Size(IReinforcementBarSize)", "S(IReinforcementBarSize)", "Gets the size of the bars used in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("TestStatus", "TS", "Gets the test status of the property", GH_ParamAccess.item);
            pManager.AddGenericParameter("Value(List_IReinforcementBar)", "V(List_IReinforcementBar)", "Gets the value of this property", GH_ParamAccess.list);
            pManager.AddGenericParameter("WallZone", "WZ", "Gets the zone the group is placed in (if used in a wall)", GH_ParamAccess.item);
            pManager.AddGenericParameter("Zone", "Z", "Gets the zone the group is placed in (if used in a beam)", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            ILongitudinalBarDetailingGroup inputLongitudinalBarDetailingGroup = null;

            if (!DA.GetData(0, ref inputLongitudinalBarDetailingGroup)) return;

            var barMark = inputLongitudinalBarDetailingGroup.BarMark.Value;
            var designSpacing = inputLongitudinalBarDetailingGroup.DesignSpacing.Value;
            var detailingPrefix = inputLongitudinalBarDetailingGroup.DetailingPrefix.Value;
            var isApplicable = inputLongitudinalBarDetailingGroup.IsApplicable;
            var isSideFaceBarGroup = inputLongitudinalBarDetailingGroup.IsSideFaceBarGroup.Value;
            var layerIndex = inputLongitudinalBarDetailingGroup.LayerIndex.Value;

            List<int> layerIndicesTop = new List<int>();
            List<int> layerIndicesBottom = new List<int>();

            var enumerator = inputLongitudinalBarDetailingGroup.LayerIndices.Value.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.Key == BeamReinforcementZoneType.Top)
                {
                    layerIndicesTop.Add(enumerator.Current.Value.Value);
                }
                if (enumerator.Current.Key == BeamReinforcementZoneType.Bottom)
                {
                    layerIndicesBottom.Add(enumerator.Current.Value.Value);
                }
            }

            var patternBarNumber = inputLongitudinalBarDetailingGroup.PatternBarNumber.Value;
            var size = inputLongitudinalBarDetailingGroup.Size.Value;
            var testStatus = inputLongitudinalBarDetailingGroup.TestStatus;
            var value = inputLongitudinalBarDetailingGroup.Value.Select(i=> i.Value).ToList();
            var wallZone = inputLongitudinalBarDetailingGroup.WallZone.Value;
            var zone = inputLongitudinalBarDetailingGroup.Zone.Value;

            DA.SetData(0, barMark);
            DA.SetData(1, designSpacing);
            DA.SetData(2, detailingPrefix);
            DA.SetData(3, isApplicable);
            DA.SetData(4, isSideFaceBarGroup);
            DA.SetData(5, layerIndex);
            DA.SetDataList(6, layerIndicesTop);
            DA.SetDataList(7, layerIndicesBottom);
            DA.SetData(8, patternBarNumber);
            DA.SetData(9, size);
            DA.SetData(10, testStatus);
            DA.SetDataList(11, value);
            DA.SetData(12, wallZone);
            DA.SetData(13, zone);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("D18F90E1-54D3-462A-B5F0-1CA56E4B1991");
    }
}
