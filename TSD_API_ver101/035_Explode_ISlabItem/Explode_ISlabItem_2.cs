using System;
using System.Collections.Generic;
using System.Linq;
using GH_IO.Types;
using Google.Protobuf.WellKnownTypes;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Geometry;
using Grasshopper.Kernel.Parameters.Hints;
using Grasshopper.Kernel.Types;
using Rhino.DocObjects;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Geometry;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_ISlabItem_2_Explode
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_ISlabItem_2", "E_ISlabItem_2",
            "Explodeing the ISlabItem ver2",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ISlabItem", "ISlabItem", "Input ISlabItem", GH_ParamAccess.item);
            pManager.AddGenericParameter("IConstructionPoint", "IConstructionPoint", "Input IConstructionPoint", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Slab Edge Curve", "SlabEdge", "This is the slab edge", GH_ParamAccess.item);
            pManager.AddGenericParameter("Corner Points", "Corner Points", "The corner points", GH_ParamAccess.list);
            pManager.AddGenericParameter("Name", "N", "This is the name", GH_ParamAccess.item);
            pManager.AddGenericParameter("Index", "Index", "This is the index", GH_ParamAccess.item);
            pManager.AddGenericParameter("List of Construction Point Indices", "List_ConstPtIndices", "This is the index of IConstructionPoint", GH_ParamAccess.list);
            pManager.AddGenericParameter("ID", "ID", "This is the ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("Entity Type Name", "TypeName", "This is the entity type name", GH_ParamAccess.item);
            pManager.AddGenericParameter("ISlabItemData", "ISlabItemData", "This is the ISlabItemData", GH_ParamAccess.item);
            pManager.AddGenericParameter("Rotation Angle [rad]", "Rotation angle [rad]", "This is the rotation angle of the slab, used for one-way slab", GH_ParamAccess.item);
            pManager.AddGenericParameter("Construction Plane Index", "Construction Plane Index", "This is the corresponding construction plane index", GH_ParamAccess.item);
            pManager.AddGenericParameter("Construction Plane ID", "Construction Plane ID", "This is the corresponding construction plane ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("Slab Surface", "SlabSurface", "This is the slab surface", GH_ParamAccess.item);
            pManager.AddGenericParameter("Check Result", "CheckResult", "General check result", GH_ParamAccess.item);
            pManager.AddGenericParameter("Check Result Bearing Pressure", "CheckResultBearingPressure", "Check result for bearing pressure", GH_ParamAccess.item);
            pManager.AddGenericParameter("Check Result Deflection", "CheckResultDeflection", "Check result for deflection", GH_ParamAccess.item);
            //pManager.AddGenericParameter("Check Results By Layer", "CheckResultsByLayer", "Check results for layer types", GH_ParamAccess.item);
            pManager.AddGenericParameter("Check Result Slab Depth", "CheckResultSlabDepth", "Check result for slab depth", GH_ParamAccess.item);
            pManager.AddGenericParameter("Column Drop Data", "ColumnDropData", "Column drop data", GH_ParamAccess.item);
            pManager.AddGenericParameter("Element Group Name", "ElementGroupName", "Name of the element group", GH_ParamAccess.item);
            pManager.AddGenericParameter("Element Plane", "ElementPlane", "Element IPlane", GH_ParamAccess.item);
            pManager.AddGenericParameter("Is Column Drop", "IsColumnDrop", "Whether the slab item is a column drop", GH_ParamAccess.item);
            pManager.AddGenericParameter("Is Overhang", "IsOverhang", "Whether this slab item is an overhang", GH_ParamAccess.item);
            pManager.AddGenericParameter("Slab Index", "SlabIndex", "Slab index", GH_ParamAccess.item);
            pManager.AddGenericParameter("Slab Item Edges", "SlabItemEdges", "Collection of ISlabItemEdge instances", GH_ParamAccess.list);
            pManager.AddGenericParameter("Slab Item Overhang Data", "SlabItemOverhangData", "Overhang data if this slab item is an overhang", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            ISlabItem inputSlabItem = null;
            List<IConstructionPoint> inputConstructionPoints = new List<IConstructionPoint>();

            if (!DA.GetData(0, ref inputSlabItem)) return;
            if (!DA.GetDataList(1, inputConstructionPoints)) return;

            // Validate the input
            if (inputSlabItem == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "ISlabItem is null.");
                return;
            }

            // Extract properties from the input ISlabItem
            Polyline outputSlabEdge = null;
            List<Point3d> outputPoints = new List<Point3d>();
            List<Point3d> outputPointsTemp = new List<Point3d>();
            string outputName = inputSlabItem.Name;
            int outputIndex = inputSlabItem.Index;
            List<int> outputConstPtIdx = inputSlabItem.ConstructionPointIndices.ToList();
            Guid outputId = inputSlabItem.Id;
            string outputTypeName = inputSlabItem.EntityType.ToString();
            ISlabItemData outputSlabData = inputSlabItem.SlabItemData.Value;
            double outputAngle = inputSlabItem.RotationAngle.Value;
            int outputConstPlaneIndex = inputSlabItem.ConstructionPlaneInfo.Index;
            Guid outputConstPlaneId = inputSlabItem.ConstructionPlaneInfo.Id;
            Surface outputSlabSurface = null;

            foreach (var item in outputConstPtIdx)
            {
                var constructionPoint = inputConstructionPoints.First(i => i.Index == item);
                Point3d pointTemp = new Point3d(constructionPoint.Coordinates.Value.X, constructionPoint.Coordinates.Value.Y, constructionPoint.Coordinates.Value.Z);
                outputPoints.Add(pointTemp);
            }

            outputPointsTemp.AddRange(outputPoints);
            outputPointsTemp.Add(outputPoints[0]);

            outputSlabEdge = new Polyline(outputPointsTemp);
            PolylineCurve polyCurveTemp = new PolylineCurve(outputSlabEdge);
            Curve curveTemp = polyCurveTemp;
            outputSlabSurface = Brep.CreatePlanarBreps(curveTemp)[0].Surfaces[0];

            // Additional properties
            ICheckResult checkResult;
            try { checkResult = inputSlabItem.CheckResult.Value; }
            catch { checkResult = default(ICheckResult); }

            ICheckResult checkResultBearingPressure;
            try { checkResultBearingPressure = inputSlabItem.CheckResultBearingPressure.Value; }
            catch { checkResultBearingPressure = default(ICheckResult); }

            ICheckResult checkResultDeflection;
            try { checkResultDeflection = inputSlabItem.CheckResultDeflection.Value; }
            catch { checkResultDeflection = default(ICheckResult); }

            // Uncomment and handle similarly if needed
            //var checkResultsByLayer = inputSlabItem.CheckResultsByLayer;

            ICheckResult checkResultSlabDepth;
            try { checkResultSlabDepth = inputSlabItem.CheckResultSlabDepth.Value; }
            catch { checkResultSlabDepth = default(ICheckResult); }

            IColumnDropData columnDropData;
            try { columnDropData = inputSlabItem.ColumnDropData.Value; }
            catch { columnDropData = default(IColumnDropData); }

            string elementGroupName;
            try { elementGroupName = inputSlabItem.ElementGroupName; }
            catch { elementGroupName = string.Empty; }

            IPlane elementPlane;
            try { elementPlane = inputSlabItem.ElementPlane.Value; }
            catch { elementPlane = default(IPlane); }

            bool isColumnDrop;
            try { isColumnDrop = inputSlabItem.IsColumnDrop.Value; }
            catch { isColumnDrop = false; }

            bool isOverhang;
            try { isOverhang = inputSlabItem.IsOverhang.Value; }
            catch { isOverhang = false; }

            int slabIndex;
            try { slabIndex = inputSlabItem.SlabIndex.Value; }
            catch { slabIndex = 0; }

            List<ISlabItemEdge> slabItemEdges;
            try { slabItemEdges = inputSlabItem.SlabItemEdges.Value.Select(i => i.Value).ToList(); }
            catch { slabItemEdges = new List<ISlabItemEdge>(); }

            ISlabItemOverhangData slabItemOverhangData;
            try { slabItemOverhangData = inputSlabItem.SlabItemOverhangData.Value; }
            catch { slabItemOverhangData = null; }

            // Set the output parameters
            DA.SetData(0, outputSlabEdge);
            DA.SetDataList(1, outputPoints);
            DA.SetData(2, outputName);
            DA.SetData(3, outputIndex);
            DA.SetDataList(4, outputConstPtIdx);
            DA.SetData(5, outputId);
            DA.SetData(6, outputTypeName);
            DA.SetData(7, outputSlabData);
            DA.SetData(8, outputAngle);
            DA.SetData(9, outputConstPlaneIndex);
            DA.SetData(10, outputConstPlaneId);
            DA.SetData(11, outputSlabSurface);
            DA.SetData(12, checkResult);
            DA.SetData(13, checkResultBearingPressure);
            DA.SetData(14, checkResultDeflection);
            DA.SetData(15, checkResultSlabDepth);
            DA.SetData(16, columnDropData);
            DA.SetData(17, elementGroupName);
            DA.SetData(18, elementPlane);
            DA.SetData(19, isColumnDrop);
            DA.SetData(20, isOverhang);
            DA.SetData(21, slabIndex);
            DA.SetDataList(22, slabItemEdges);
            DA.SetData(23, slabItemOverhangData);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return TSD_API_ver101.Properties.Resources.API_icon;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("70610351-BCDB-490E-B5DA-3F82E1D5817B"); }
        }
    }
}
