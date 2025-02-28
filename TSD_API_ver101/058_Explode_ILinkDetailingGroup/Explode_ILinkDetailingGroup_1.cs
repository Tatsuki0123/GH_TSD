using System;
using System.Collections.Generic;
using System.Linq;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Reinforcement;

namespace TSD_API_ver101_ILinkDetailingGroup_Explode
{
    public class Explode_ILinkDetailingGroup : GH_Component
    {
        public Explode_ILinkDetailingGroup()
          : base("Explode_ILinkDetailingGroup_1", "ExplodeLinkDetailingGrp_1",
            "Explodes an ILinkDetailingGroup into its various properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ILinkDetailingGroup", "ILDG", "Input ILinkDetailingGroup", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("BarMark", "BM", "Gets the mark of the bars used in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("CentreSpacing", "CS", "Gets the centre spacing of the links (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("DetailingPrefix", "DP", "Gets the detailing prefix of the reinforcement grade used in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsApplicable", "IA", "Gets a value indicating whether the property is applicable", GH_ParamAccess.item);
            pManager.AddGenericParameter("LinksPerPosition", "LPP", "Gets the number of links in a single position", GH_ParamAccess.item);
            pManager.AddGenericParameter("PositionsPerGroup", "PPG", "Gets the number of positions in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("RegionIndex", "RI", "Gets the index of the span region the group is placed in", GH_ParamAccess.item);
            pManager.AddGenericParameter("IReinforcementBarSize", "IReinforcementBarSize", "Gets the size of the bars used in the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("TestStatus", "TS", "Gets the test status of the property", GH_ParamAccess.item);
            pManager.AddGenericParameter("Type", "T", "Gets the type of the group", GH_ParamAccess.item);
            pManager.AddGenericParameter("Value(List_IReinforcementBar)", "V(LIst_IReinforcementBar)", "Gets the value of this property", GH_ParamAccess.list);
            pManager.AddGenericParameter("WallZone", "WZ", "Gets the zone the group is placed in (if used in a wall)", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            ILinkDetailingGroup inputLinkDetailingGroup = null;

            if (!DA.GetData(0, ref inputLinkDetailingGroup)) return;

            var barMark = inputLinkDetailingGroup.BarMark.Value;
            var centreSpacing = inputLinkDetailingGroup.CentreSpacing.Value;
            var detailingPrefix = inputLinkDetailingGroup.DetailingPrefix.Value;
            var isApplicable = inputLinkDetailingGroup.IsApplicable;
            var linksPerPosition = inputLinkDetailingGroup.LinksPerPosition.Value;
            var positionsPerGroup = inputLinkDetailingGroup.PositionsPerGroup.Value;
            var regionIndex = inputLinkDetailingGroup.RegionIndex.Value;
            var size = inputLinkDetailingGroup.Size.Value;
            var testStatus = inputLinkDetailingGroup.TestStatus;
            var type = inputLinkDetailingGroup.Type.Value;
            var value = inputLinkDetailingGroup.Value.Select(i => i.Value).ToList();
            var wallZone = inputLinkDetailingGroup.WallZone.Value;

            DA.SetData(0, barMark);
            DA.SetData(1, centreSpacing);
            DA.SetData(2, detailingPrefix);
            DA.SetData(3, isApplicable);
            DA.SetData(4, linksPerPosition);
            DA.SetData(5, positionsPerGroup);
            DA.SetData(6, regionIndex);
            DA.SetData(7, size);
            DA.SetData(8, testStatus);
            DA.SetData(9, type);
            DA.SetDataList(10, value);
            DA.SetData(11, wallZone);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("65A5A49B-5EFE-4535-A66C-DFAF71E3086E");
    }
}
