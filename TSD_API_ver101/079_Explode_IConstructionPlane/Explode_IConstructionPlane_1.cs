using System;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_IConstructionPlane_Explode
{
    public class Explode_IConstructionPlane : GH_Component
    {
        public Explode_IConstructionPlane()
          : base("Explode_IConstructionPlane_1", "E_ICPlane_1",
            "Explodes an IConstructionPlane into its properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IConstructionPlane", "ICP", "Input IConstructionPlane", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("ElementGroupName", "EGN", "Gets the name of the element group", GH_ParamAccess.item);
            pManager.AddGenericParameter("EntityType", "ET", "Gets the type of the entity", GH_ParamAccess.item);
            pManager.AddGenericParameter("Id", "ID", "Gets the ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("Index", "IDX", "Gets the index", GH_ParamAccess.item);
            pManager.AddGenericParameter("Name", "N", "Gets the name", GH_ParamAccess.item);
            pManager.AddGenericParameter("Plane(IPlane)", "P(IPlane)", "Gets the base plane of this construction plane", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IConstructionPlane inputConstructionPlane = null;

            if (!DA.GetData(0, ref inputConstructionPlane)) return;

            var elementGroupName = inputConstructionPlane.ElementGroupName;
            var entityType = inputConstructionPlane.EntityType;
            var id = inputConstructionPlane.Id;
            var index = inputConstructionPlane.Index;
            var name = inputConstructionPlane.Name;
            var plane = inputConstructionPlane.Plane.Value;

            DA.SetData(0, elementGroupName);
            DA.SetData(1, entityType);
            DA.SetData(2, id);
            DA.SetData(3, index);
            DA.SetData(4, name);
            DA.SetData(5, plane);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("764FAB35-06E8-49DD-96A0-3CF27EAC8FBA");
    }
}
