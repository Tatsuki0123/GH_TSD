using System;
using System.Collections.Generic;
using System.Linq;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Reinforcement;

namespace TSD_API_ver101_ILinkSchedulingGroup_Explode
{
    public class Explode_ILinkSchedulingGroup : GH_Component
    {
        public Explode_ILinkSchedulingGroup()
          : base("Explode_ILinkSchedulingGroup_1", "ExplodeLinkSchedGrp_1",
            "Explodes an ILinkSchedulingGroup into its various properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ILinkSchedulingGroup", "ILSG", "Input ILinkSchedulingGroup", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("BarMark", "BM", "Gets the mark of the bars used in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("CentreSpacing", "CS", "Gets the centre spacing of the links (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("DetailingPrefix", "DP", "Gets the detailing prefix of the reinforcement grade used in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("EdgeIndex", "EI", "Gets the index of the edge the group belongs to", GH_ParamAccess.item);
            pManager.AddGenericParameter("HasTorsionLinks", "HTL", "Gets a value indicating whether the group contains torsion links", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsApplicable", "IA", "Gets a value indicating whether the property is applicable", GH_ParamAccess.item);
            pManager.AddGenericParameter("LegCount", "LC", "Gets the number of legs of each link in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("LinksPerPosition", "LPP", "Gets the number of links in a single position", GH_ParamAccess.item);
            pManager.AddGenericParameter("Position", "P", "Gets the position of the group in the beam", GH_ParamAccess.item);
            pManager.AddGenericParameter("PositionsPerGroup", "PPG", "Gets the number of positions in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("RegionIndex", "RI", "Gets the index of the span region the group is placed in", GH_ParamAccess.item);
            pManager.AddGenericParameter("RegionLength", "RL", "Gets the length of the region the group belongs to (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("IReinforcementBarSize", "IReinforcementBarSize", "Gets the size of the bars used in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("TestStatus", "TS", "Gets the test status of the property", GH_ParamAccess.item);
            pManager.AddGenericParameter("Type", "T", "Gets the type of the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("Value(List_IReinforcementBar)", "V(List_IReinforcementBar)", "Gets the value of this property", GH_ParamAccess.list);
            pManager.AddGenericParameter("WallZone", "WZ", "Gets the zone the group is placed in (if used in a wall)", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            ILinkSchedulingGroup inputLinkSchedulingGroup = null;

            if (!DA.GetData(0, ref inputLinkSchedulingGroup)) return;

            var barMark = inputLinkSchedulingGroup.BarMark.Value;
            var centreSpacing = inputLinkSchedulingGroup.CentreSpacing.Value;
            var detailingPrefix = inputLinkSchedulingGroup.DetailingPrefix.Value;
            var edgeIndex = inputLinkSchedulingGroup.EdgeIndex.Value;
            var hasTorsionLinks = inputLinkSchedulingGroup.HasTorsionLinks.Value;
            var isApplicable = inputLinkSchedulingGroup.IsApplicable;
            var legCount = inputLinkSchedulingGroup.LegCount.Value;
            var linksPerPosition = inputLinkSchedulingGroup.LinksPerPosition.Value;
            var position = inputLinkSchedulingGroup.Position.Value;
            var positionsPerGroup = inputLinkSchedulingGroup.PositionsPerGroup.Value;
            var regionIndex = inputLinkSchedulingGroup.RegionIndex.Value;
            var regionLength = inputLinkSchedulingGroup.RegionLength.Value;
            var size = inputLinkSchedulingGroup.Size.Value;
            var testStatus = inputLinkSchedulingGroup.TestStatus;
            var type = inputLinkSchedulingGroup.Type.Value;
            var value = inputLinkSchedulingGroup.Value.Select(i => i.Value).ToList();
            var wallZone = inputLinkSchedulingGroup.WallZone.Value;

            DA.SetData(0, barMark);
            DA.SetData(1, centreSpacing);
            DA.SetData(2, detailingPrefix);
            DA.SetData(3, edgeIndex);
            DA.SetData(4, hasTorsionLinks);
            DA.SetData(5, isApplicable);
            DA.SetData(6, legCount);
            DA.SetData(7, linksPerPosition);
            DA.SetData(8, position);
            DA.SetData(9, positionsPerGroup);
            DA.SetData(10, regionIndex);
            DA.SetData(11, regionLength);
            DA.SetData(12, size);
            DA.SetData(13, testStatus);
            DA.SetData(14, type);
            DA.SetDataList(15, value);
            DA.SetData(16, wallZone);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("4A88DC67-3C37-49C8-B6B5-D42FAFBA4541");
    }
}
