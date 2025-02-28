using System;
using System.Collections.Generic;
using GH_IO.Types;
using Google.Protobuf.WellKnownTypes;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Geometry;
using TSD.API.Remoting.Materials;
using TSD.API.Remoting.Sections;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Reinforcement;
using System.Linq;

namespace TSD_API_ver101_IReinforcementCollection_Explode
{
    public class Explode_IReinforcementCollection : GH_Component
    {
        public Explode_IReinforcementCollection()
          : base("Explode_IReinforcementCollection_1", "ExplodeReinfColl_1",
            "Explodes an IReinforcementCollection into its various properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IReinforcementCollection", "IRC", "Input IReinforcementCollection", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("HorizontalBarGroups(ILinkDeitalingGroup)", "HBG(ILinkDetailingGroup)", "List of horizontal bar groups", GH_ParamAccess.list);
            pManager.AddGenericParameter("LinkGroups(ILinkDeitalingGroup)", "LG(ILinkDeitalingGroup)", "List of shear link detailing groups", GH_ParamAccess.list);
            pManager.AddGenericParameter("LinkSchedulingGroups(ILinkSheduleDeitalingGroup)", "LSG(ILinkSheduleDeitalingGroup)", "List of shear link scheduling groups", GH_ParamAccess.list);
            pManager.AddGenericParameter("LongitudinalBarGroups(ILongitudinalBarGroups)", "LBG(ILongitudinalBarGroups)", "List of longitudinal bar detailing groups", GH_ParamAccess.list);
            pManager.AddGenericParameter("LongitudinalBars(IReinforcementBar)", "LB(IReinforcementBar)", "List of longitudinal bars used in the collection", GH_ParamAccess.list);
            pManager.AddGenericParameter("LongitudinalBarSchedulingGroups(ILongitudinalBarSchedulingGroup)", "LBSG(ILongitudinalBarSchedulingGroup)", "List of longitudinal bar scheduling groups", GH_ParamAccess.list);
            pManager.AddGenericParameter("Meshes(IReinforcementMesh)", "M(IReinforcementMesh)", "List of meshes used in the collection", GH_ParamAccess.list);
            pManager.AddGenericParameter("MeshGroups(IReinforcementMeshDetailingGroup)", "MG(IReinforcementMeshDetailingGroup)", "List of mesh groups", GH_ParamAccess.list);
            pManager.AddGenericParameter("ShearLinks(IReinforcementBar)", "SL(IReinforcementBar)", "List of shear links used in the collection", GH_ParamAccess.list);
            pManager.AddGenericParameter("SimplifiedLongitudinalBarGroups(ILongitudinalBarDetailingGroup)", "SLBG(ILongitudinalBarDetailingGroup)", "Collection of longitudinal bar detailing groups containing simplified (straight-only) bars", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IReinforcementCollection inputReinforcementCollection = null;

            if (!DA.GetData(0, ref inputReinforcementCollection)) return;

            var horizontalBarGroups = inputReinforcementCollection.HorizontalBarGroups.Value.Select(i => i.Value).ToList();
            var linkGroups = inputReinforcementCollection.LinkGroups.Value.Select(i => i.Value).ToList();
            var linkSchedulingGroups = inputReinforcementCollection.LinkSchedulingGroups.Value.Select(i => i.Value).ToList();
            var longitudinalBarGroups = inputReinforcementCollection.LongitudinalBarGroups.Value.Select(i => i.Value).ToList();
            var longitudinalBars = inputReinforcementCollection.LongitudinalBars.Value.Select(i => i.Value).ToList();
            var longitudinalBarSchedulingGroups = inputReinforcementCollection.LongitudinalBarSchedulingGroups.Value.Select(i => i.Value).ToList();
            var meshes = inputReinforcementCollection.Meshes.Value.Select(i => i.Value).ToList();
            var meshGroups = inputReinforcementCollection.MeshGroups.Value.Select(i => i.Value).ToList();
            var shearLinks = inputReinforcementCollection.ShearLinks.Value.Select(i => i.Value).ToList();
            var simplifiedLongitudinalBarGroups = inputReinforcementCollection.SimplifiedLongitudinalBarGroups.Value.Select(i => i.Value).ToList();

            DA.SetDataList(0, horizontalBarGroups);
            DA.SetDataList(1, linkGroups);
            DA.SetDataList(2, linkSchedulingGroups);
            DA.SetDataList(3, longitudinalBarGroups);
            DA.SetDataList(4, longitudinalBars);
            DA.SetDataList(5, longitudinalBarSchedulingGroups);
            DA.SetDataList(6, meshes);
            DA.SetDataList(7, meshGroups);
            DA.SetDataList(8, shearLinks);
            DA.SetDataList(9, simplifiedLongitudinalBarGroups);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("68AB5328-DD56-4EA0-8D60-7C48BB2CC643");
    }
}
