using System;
using System.Collections.Generic;
using System.Linq;
using GH_IO.Types;
using Google.Protobuf.WellKnownTypes;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_IStructuralWall_Explode
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the Explode_IStructuralWall class.
        /// </summary>
        public Get_Instance()
          : base("Explode_IStructuralWall", "E_IStructuralWall",
            "Exploding the IStructuralWall interface",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IStructuralWall", "Wall", "Input IStructuralWall", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Name", "N", "This is the name of the wall", GH_ParamAccess.item);
            pManager.AddGenericParameter("Index", "Index", "This is the wall index in TSD", GH_ParamAccess.item);
            pManager.AddGenericParameter("Span Count", "Span_Count", "This is the number of spans", GH_ParamAccess.item);
            pManager.AddGenericParameter("ID", "ID", "This is the ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("Entity Type Name", "TypeName", "This is the entity type name", GH_ParamAccess.item);
            pManager.AddGenericParameter("Element Group Name", "Group", "This is the element group name", GH_ParamAccess.item);
            pManager.AddGenericParameter("Rotation Angle", "Rotation", "This is the rotation angle (in radians)", GH_ParamAccess.item);
            pManager.AddGenericParameter("Construction Point Indices", "CP_Indices", "This is the construction point indices", GH_ParamAccess.list);
            pManager.AddGenericParameter("Mesh Type", "MeshType", "This is the mesh type", GH_ParamAccess.item);
            pManager.AddGenericParameter("Mesh Horizontal Size", "MeshHorizSize", "This is the mesh horizontal size (in mm)", GH_ParamAccess.item);
            pManager.AddGenericParameter("Mesh Vertical Size", "MeshVertSize", "This is the mesh vertical size (in mm)", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Declare input variables
            IStructuralWall inputWall = null;

            // Retrieve data from the input parameter
            if (!DA.GetData(0, ref inputWall)) return;

            // Initialize default output variables
            string output_name = "N.A";
            int output_index = -1;
            int output_span = -1;
            Guid output_id = Guid.Empty;
            string output_type_name = null;
            string output_group_name = null;
            double output_rotation = 0.0;
            List<int> output_cp_indices = new List<int>();
            string output_mesh_type = "N.A";
            double output_mesh_horiz_size = 0.0;
            double output_mesh_vert_size = 0.0;

            // Validate input and extract data
            if (inputWall != null)
            {
                output_name = inputWall.Name ;
                output_index = inputWall.Index;
                output_span = inputWall.SpanCount.IsApplicable ? inputWall.SpanCount.Value : -1;
                output_id = inputWall.Id;
                output_type_name = inputWall.EntityType.ToString();
                output_group_name = inputWall.ElementGroupName;
                output_rotation = inputWall.RotationAngle.IsApplicable ? inputWall.RotationAngle.Value: -1;
                output_cp_indices = inputWall.ConstructionPointIndices.ToList();
                output_mesh_type = inputWall.MeshType.ToString();
                output_mesh_horiz_size = inputWall.MeshHorizontalSize.IsApplicable ? inputWall.MeshHorizontalSize.Value: -1;
                output_mesh_vert_size = inputWall.MeshVerticalSize.IsApplicable ? inputWall.MeshVerticalSize.Value: -1;
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "IStructuralWall is not valid.");
            }

            // Assign the output data
            DA.SetData(0, output_name);
            DA.SetData(1, output_index);
            DA.SetData(2, output_span);
            DA.SetData(3, output_id);
            DA.SetData(4, output_type_name);
            DA.SetData(5, output_group_name);
            DA.SetData(6, output_rotation);
            DA.SetDataList(7, output_cp_indices);
            DA.SetData(8, output_mesh_type);
            DA.SetData(9, output_mesh_horiz_size);
            DA.SetData(10, output_mesh_vert_size);
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
            get { return new Guid("0014B7A5-C2E1-4F65-AFEF-6D29B62914F1"); }
        }
    }
}
