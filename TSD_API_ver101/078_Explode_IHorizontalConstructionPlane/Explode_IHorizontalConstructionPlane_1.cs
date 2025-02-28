using System;
using System.Collections.Generic;
using System.Linq;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_IHorizontalConstructionPlane_Explode
{
    public class Explode_IHorizontalConstructionPlane : GH_Component
    {
        public Explode_IHorizontalConstructionPlane()
          : base("Explode_IHorizontalConstructionPlane_1", "E_IHCP_1",
            "Explodes an IHorizontalConstructionPlane into its properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IHorizontalConstructionPlane", "IHCP", "Input IHorizontalConstructionPlane", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("ElementGroupName", "EGN", "Gets the name of the element group", GH_ParamAccess.item);
            pManager.AddGenericParameter("EntityType", "ET", "Gets the type of the entity", GH_ParamAccess.item);
            pManager.AddGenericParameter("Id", "ID", "Gets the ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("Index", "IDX", "Gets the index", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsFloor", "IF", "Gets a value indicating whether the level is specified as a floor", GH_ParamAccess.item);
            pManager.AddGenericParameter("Level", "L", "Gets the height at which the level is (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("LongReference", "LR", "Gets the long name of the level", GH_ParamAccess.item);
            pManager.AddGenericParameter("Name", "N", "Gets the name", GH_ParamAccess.item);
            pManager.AddGenericParameter("Plane(IPlane)", "P(IPlane)", "Gets the base plane of this construction plane", GH_ParamAccess.item);
            pManager.AddGenericParameter("ShortReference", "SR", "Gets the short name of the level", GH_ParamAccess.item);
            pManager.AddGenericParameter("SlabThickness", "ST", "Gets the thickness of slabs (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("SourcePlaneId", "SPI", "Gets the ID of the source level", GH_ParamAccess.item);
            pManager.AddGenericParameter("Type", "T", "Gets the type of the level", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IHorizontalConstructionPlane inputHorizontalConstructionPlane = null;

            if (!DA.GetData(0, ref inputHorizontalConstructionPlane)) return;

            string elementGroupName = null;
            EntityType entityType = EntityType.Unknown;
            Guid id = Guid.Empty;
            int index = 0;
            bool isFloor = false;
            double level = 0.0;
            string longReference = null;
            string name = null;
            TSD.API.Remoting.Geometry.IPlane plane = null;
            string shortReference = null;
            double slabThickness = 0.0;
            Guid sourcePlaneId = Guid.Empty;
            PlaneType type = PlaneType.Unknown;

            if (inputHorizontalConstructionPlane != null)
            {
                elementGroupName = inputHorizontalConstructionPlane.ElementGroupName;
                entityType = inputHorizontalConstructionPlane.EntityType;
                id = inputHorizontalConstructionPlane.Id;
                index = inputHorizontalConstructionPlane.Index;
                isFloor = inputHorizontalConstructionPlane.IsFloor.Value;
                level = inputHorizontalConstructionPlane.Level.Value;
                longReference = inputHorizontalConstructionPlane.LongReference.Value;
                name = inputHorizontalConstructionPlane.Name;
                plane = inputHorizontalConstructionPlane.Plane.Value;
                shortReference = inputHorizontalConstructionPlane.ShortReference.Value;
                slabThickness = inputHorizontalConstructionPlane.SlabThickness.Value;
                sourcePlaneId = inputHorizontalConstructionPlane.SourcePlaneId.Value;
                type = inputHorizontalConstructionPlane.Type.Value;
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Input IHorizontalConstructionPlane is not activated");
            }

            DA.SetData(0, elementGroupName);
            DA.SetData(1, entityType);
            DA.SetData(2, id);
            DA.SetData(3, index);
            DA.SetData(4, isFloor);
            DA.SetData(5, level);
            DA.SetData(6, longReference);
            DA.SetData(7, name);
            DA.SetData(8, plane);
            DA.SetData(9, shortReference);
            DA.SetData(10, slabThickness);
            DA.SetData(11, sourcePlaneId);
            DA.SetData(12, type);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("C721D506-21DC-447F-B33D-55F5DA2FAC09");
    }
}
