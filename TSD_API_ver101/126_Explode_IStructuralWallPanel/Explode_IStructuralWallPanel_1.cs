using System;
using System.Collections.Generic;
using System.Linq;
using GH_IO.Types;
using Google.Protobuf.WellKnownTypes;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Common.Properties;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Geometry;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_IStructuralWallPanel_Explode
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the Explode_IStructuralWallPanel class.
        /// </summary>
        public Get_Instance()
          : base("Explode_IStructuralWallPanel", "E_IStructuralWallPanel",
            "Exploding the IStructuralWallPanel interface",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IStructuralWallPanel", "WallPanel", "Input IStructuralWallPanel", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("ID", "ID", "This is the panel ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("Index", "Index", "This is the panel index in TSD", GH_ParamAccess.item);
            pManager.AddGenericParameter("Entity Type", "TypeName", "This is the entity type", GH_ParamAccess.item);
            pManager.AddGenericParameter("Back Surface Plane", "BackPlane", "This is the back surface plane", GH_ParamAccess.item);
            pManager.AddGenericParameter("Front Surface Plane", "FrontPlane", "This is the front surface plane", GH_ParamAccess.item);
            pManager.AddGenericParameter("Top Segment", "TopSegment", "This is the top segment of the panel", GH_ParamAccess.item);
            pManager.AddGenericParameter("Bottom Segment", "BottomSegment", "This is the bottom segment of the panel", GH_ParamAccess.item);
            pManager.AddGenericParameter("Check Results", "CheckResults", "These are the check results of the panel", GH_ParamAccess.item);
            pManager.AddGenericParameter("Wall Panel Data", "WallPanelData", "This is the additional wall panel data", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Declare input variables
            IStructuralWallPanel inputWallPanel = null;

            // Retrieve data from the input parameter
            if (!DA.GetData(0, ref inputWallPanel)) return;

            // Initialize default output variables
            Guid output_id = Guid.Empty;
            int output_index = -1;
            string output_type_name = "N.A";
            IPlane output_backPlane = null;
            IPlane output_frontPlane = null;
            ISegment3D output_topSegment = null;
            ISegment3D output_bottomSegment = null;
            List<IKeyValuePair<CheckResultType, IReadOnlyProperty<ICheckResult>>> output_checkResults = null; // Assuming check results could be of different types
            IStructuralWallPanelData output_wallPanelData = null; // Generic object for wall panel data

            // Validate input and extract data
            if (inputWallPanel != null)
            {
                output_id = inputWallPanel.Id != Guid.Empty ? inputWallPanel.Id : Guid.Empty;
                output_index = inputWallPanel.Index;
                output_type_name = inputWallPanel.EntityType.ToString() ?? "N.A";
                output_backPlane = inputWallPanel.BackSurfacePlane.IsApplicable ? inputWallPanel.BackSurfacePlane.Value: null;
                output_frontPlane = inputWallPanel.FrontSurfacePlane.IsApplicable ? inputWallPanel.FrontSurfacePlane.Value: null;
                output_topSegment = inputWallPanel.TopSegment.IsApplicable ? inputWallPanel.TopSegment.Value: null;
                output_bottomSegment = inputWallPanel.BottomSegment.IsApplicable ? inputWallPanel.BottomSegment.Value : null;
                output_checkResults = inputWallPanel.CheckResults.IsApplicable? inputWallPanel.CheckResults.Value.ToList() : null;
                output_wallPanelData = inputWallPanel.WallPanelData.IsApplicable ? inputWallPanel.WallPanelData.Value : null;
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "IStructuralWallPanel is not valid.");
            }

            // Assign the output data
            DA.SetData(0, output_id);
            DA.SetData(1, output_index);
            DA.SetData(2, output_type_name);
            DA.SetData(3, output_backPlane);
            DA.SetData(4, output_frontPlane);
            DA.SetData(5, output_topSegment);
            DA.SetData(6, output_bottomSegment);
            DA.SetData(7, output_checkResults);
            DA.SetData(8, output_wallPanelData);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return TSD_API_ver101.Properties.Resources.API_icon;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("7F127B7B-2B12-4B71-839C-2BB5DACFDFDB"); }
        }
    }
}
