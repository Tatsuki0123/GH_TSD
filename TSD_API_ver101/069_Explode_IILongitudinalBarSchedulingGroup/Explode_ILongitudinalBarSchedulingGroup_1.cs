using System;
using System.Collections.Generic;
using System.Linq;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Reinforcement;

namespace TSD_API_ver101_ILongitudinalBarSchedulingGroup_Explode
{
    public class Explode_ILongitudinalBarSchedulingGroup : GH_Component
    {
        public Explode_ILongitudinalBarSchedulingGroup()
          : base("Explode_ILongitudinalBarSchedulingGroup_1", "ExplodeLongBarSchedGrp_1",
            "Explodes an ILongitudinalBarSchedulingGroup into its various properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ILongitudinalBarSchedulingGroup", "ILBSG", "Input ILongitudinalBarSchedulingGroup", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("BarMark", "BM", "Gets the mark of the bars used in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("DesignSpacing", "DS", "Gets the design spacing of the bars (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("DetailingPrefix", "DP", "Gets the detailing prefix of the reinforcement grade used in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("EdgeIndex", "EI", "Gets the index of the edge the group belongs to", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsApplicable", "IA", "Gets a value indicating whether the property is applicable", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsSideFaceBarGroup", "ISFBG", "Gets a value indicating whether the group is positioned at a side face of a beam", GH_ParamAccess.item);
            pManager.AddGenericParameter("Key", "Key", "Gets the group key", GH_ParamAccess.item);
            pManager.AddGenericParameter("LayerIndex", "LI", "Gets the index of the layer (in the group's own zone) of bars the group holds (if used in a beam)", GH_ParamAccess.item);
            pManager.AddGenericParameter("LayerIndicesTop", "LIT", "The index of the layer in the top zone", GH_ParamAccess.list);
            pManager.AddGenericParameter("LayerIndicesBottom", "LIB", "The index of the layer in the bottom zone", GH_ParamAccess.item);
            pManager.AddGenericParameter("PatternBarNumber", "PBN", "Gets the pattern number of the bars included in this group", GH_ParamAccess.list);
            pManager.AddGenericParameter("Position", "P", "Gets the position of the group in the beam", GH_ParamAccess.item);
            pManager.AddGenericParameter("RegionLength", "RL", "Gets the proportional length of the region the group occupies (unitless)", GH_ParamAccess.item);
            pManager.AddGenericParameter("Size(IReinforcementBarSize)", "S(IReinforcementBarSize)", "Gets the size of the bars used in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("TestStatus", "TS", "Gets the test status of the property", GH_ParamAccess.item);
            pManager.AddGenericParameter("Value(List_IReinforcementBar)", "V(List_IReinforcementBar)", "Gets the value of this property", GH_ParamAccess.list);
            pManager.AddGenericParameter("WallZone", "WZ", "Gets the zone the group is placed in (if used in a wall)", GH_ParamAccess.item);
            pManager.AddGenericParameter("Zone", "Z", "Gets the zone the group is placed in (if used in a beam)", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            ILongitudinalBarSchedulingGroup inputLongitudinalBarSchedulingGroup = null;

            if (!DA.GetData(0, ref inputLongitudinalBarSchedulingGroup)) return;

            var barMark = inputLongitudinalBarSchedulingGroup.BarMark.Value;
            var designSpacing = inputLongitudinalBarSchedulingGroup.DesignSpacing.Value;
            var detailingPrefix = inputLongitudinalBarSchedulingGroup.DetailingPrefix.Value;
            var edgeIndex = inputLongitudinalBarSchedulingGroup.EdgeIndex.Value;
            var isApplicable = inputLongitudinalBarSchedulingGroup.IsApplicable;
            var isSideFaceBarGroup = inputLongitudinalBarSchedulingGroup.IsSideFaceBarGroup.Value;
            var key = inputLongitudinalBarSchedulingGroup.Key.Value;
            var layerIndex = inputLongitudinalBarSchedulingGroup.LayerIndex.Value;


            List<int> layerIndicesTop = new List<int>();
            List<int> layerIndicesBottom = new List<int>();

            var enumerator = inputLongitudinalBarSchedulingGroup.LayerIndices.Value.GetEnumerator();
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

            var patternBarNumber = inputLongitudinalBarSchedulingGroup.PatternBarNumber.Value;
            var position = inputLongitudinalBarSchedulingGroup.Position.Value;
            var regionLength = inputLongitudinalBarSchedulingGroup.RegionLength.Value;
            var size = inputLongitudinalBarSchedulingGroup.Size.Value;
            var testStatus = inputLongitudinalBarSchedulingGroup.TestStatus;
            var value = inputLongitudinalBarSchedulingGroup.Value.Select(i => i.Value).ToList();
            var wallZone = inputLongitudinalBarSchedulingGroup.WallZone.Value;
            var zone = inputLongitudinalBarSchedulingGroup.Zone.Value;

            DA.SetData(0, barMark);
            DA.SetData(1, designSpacing);
            DA.SetData(2, detailingPrefix);
            DA.SetData(3, edgeIndex);
            DA.SetData(4, isApplicable);
            DA.SetData(5, isSideFaceBarGroup);
            DA.SetData(6, key);
            DA.SetData(7, layerIndex);
            DA.SetDataList(8, layerIndicesTop);
            DA.SetDataList(9, layerIndicesBottom);
            DA.SetData(10, patternBarNumber);
            DA.SetData(11, position);
            DA.SetData(12, regionLength);
            DA.SetData(13, size);
            DA.SetData(14, testStatus);
            DA.SetDataList(15, value);
            DA.SetData(16, wallZone);
            DA.SetData(17, zone);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("6FAA645A-640A-4B94-8946-FC67E12D0772");
    }
}
