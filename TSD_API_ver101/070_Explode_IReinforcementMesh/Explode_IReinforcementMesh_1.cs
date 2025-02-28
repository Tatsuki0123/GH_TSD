using System;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Reinforcement;

namespace TSD_API_ver101_IReinforcementMesh_Explode
{
    public class Explode_IReinforcementMesh : GH_Component
    {
        public Explode_IReinforcementMesh()
          : base("Explode_IReinforcementMesh_1", "ExplodeReinMesh_1",
            "Explodes an IReinforcementMesh into its properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IReinforcementMesh", "IRM", "Input IReinforcementMesh", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Area", "A", "Gets the total area of the mesh (in [mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("DistanceToFirstLongitudinalBar", "DTFLB", "Gets the distance to the first longitudinal bar along the line from start position 1 to start position 2 (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("FlyingEnd", "FE", "Gets the length of the 'flying end' of the mesh at both ends (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Geometry", "G", "Gets the geometry of the reinforcement object", GH_ParamAccess.item);
            pManager.AddGenericParameter("Height", "H", "Gets the height of the mesh (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Id", "ID", "Gets the unique ID of the mesh", GH_ParamAccess.item);
            pManager.AddGenericParameter("Mark", "M", "Gets the object mark (an arbitrary number used in drawings)", GH_ParamAccess.item);
            pManager.AddGenericParameter("Size", "S", "Gets the size of the reinforcement mesh used", GH_ParamAccess.item);
            pManager.AddGenericParameter("StartPosition1", "SP1", "Gets the first point of the start line of the mesh", GH_ParamAccess.item);
            pManager.AddGenericParameter("StartPosition2", "SP2", "Gets the second point of start line of the mesh", GH_ParamAccess.item);
            pManager.AddGenericParameter("StartSpanIndex", "SSI", "Gets the index of the span in the parent object the reinforcement starts in", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IReinforcementMesh inputReinforcementMesh = null;

            if (!DA.GetData(0, ref inputReinforcementMesh)) return;

            var area = inputReinforcementMesh.Area.Value;
            var distanceToFirstLongitudinalBar = inputReinforcementMesh.DistanceToFirstLongitudinalBar.Value;
            var flyingEnd = inputReinforcementMesh.FlyingEnd.Value;
            var geometry = inputReinforcementMesh.Geometry.Value; //attention
            var height = inputReinforcementMesh.Height.Value; //attention
            var id = inputReinforcementMesh.Id.Value;
            var mark = inputReinforcementMesh.Mark.Value;
            var size = inputReinforcementMesh.Size.Value; //attention
            var startPosition1 = inputReinforcementMesh.StartPosition1.Value; //attention
            var startPosition2 = inputReinforcementMesh.StartPosition2.Value; //attention
            var startSpanIndex = inputReinforcementMesh.StartSpanIndex.Value; //attention

            DA.SetData(0, area);
            DA.SetData(1, distanceToFirstLongitudinalBar);
            DA.SetData(2, flyingEnd);
            DA.SetData(3, geometry);
            DA.SetData(4, height);
            DA.SetData(5, id);
            DA.SetData(6, mark);
            DA.SetData(7, size);
            DA.SetData(8, startPosition1);
            DA.SetData(9, startPosition2);
            DA.SetData(10, startSpanIndex);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("32138B0D-F811-45A7-9A9B-C0CF50615516");
    }
}
