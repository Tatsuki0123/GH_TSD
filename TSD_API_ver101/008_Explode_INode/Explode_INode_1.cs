using System;
using System.Collections.Generic;
using System.Linq;
using GH_IO.Types;
using Google.Protobuf.WellKnownTypes;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_INode_Explode

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_INode_1", "E_INode_1",
            "Explodeing the INodes ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("INode", "INode", "Input INode", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Point", "P", "this is INode Point", GH_ParamAccess.item);
            pManager.AddGenericParameter("Index", "Index", "this is INode index", GH_ParamAccess.item);
            pManager.AddGenericParameter("Coordinate_X", "X", "this is INode Coordinate X", GH_ParamAccess.item);
            pManager.AddGenericParameter("Coordinate_Y", "Y", "this is INode Coordinate Y", GH_ParamAccess.item);
            pManager.AddGenericParameter("Coordinate_Z", "Z", "this is INode Coordinate Z", GH_ParamAccess.item);
            pManager.AddGenericParameter("Dof", "Dof", "this is Degree of freedom", GH_ParamAccess.item);
            pManager.AddGenericParameter("Element1D indices", "Element1Dindices", "this is the indices of element1D connected to the node", GH_ParamAccess.list);
            pManager.AddGenericParameter("Element2D indices", "Element2Dindices", "this is the indices of element2D connected to the node", GH_ParamAccess.list);
            pManager.AddGenericParameter("is Constrained", "isConstrained", "this indicates if the node is constrained or not", GH_ParamAccess.item);
            pManager.AddGenericParameter("is Supporting", "isSupporting", "this indicates if the node is supporting or not", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Solver.INode input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            double output_coordinate_x = 0;
            double output_coordinate_y = 0;
            double output_coordinate_z = 0;
            int output_index = 0;
            Point3d output_point = new Point3d();
            string output_Dof = null;
            List<int> output_element1D_idx = new List<int>();
            List<int> output_element2D_idx = new List<int>();
            string output_constrained = "Not sure why but it always gives me only false";
            string output_supporting = "Not sure why but it always gives me only false";

            if (input_1 != null)
            {
                output_coordinate_x = input_1.Coordinates.X;
                output_coordinate_y = input_1.Coordinates.Y;
                output_coordinate_z = input_1.Coordinates.Z;
                output_index = input_1.Index;
                output_point = new Point3d(output_coordinate_x,output_coordinate_y,output_coordinate_z);
                output_Dof = input_1.Dof.ToString();
                output_element1D_idx = input_1.Element1dIndices.ToList();
                output_element2D_idx = input_1.Element2dIndices.ToList();
                //output_constrained = input_1.IsConstrained; //not sure why but its not working always false
                //output_supporting = input_1.IsSupporting; // not sure why but its not working alyways false
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetData(0, output_point);
            DA.SetData(1, output_index);
            DA.SetData(2, output_coordinate_x);
            DA.SetData(3, output_coordinate_y);
            DA.SetData(4, output_coordinate_z);
            DA.SetData(5, output_Dof);
            DA.SetDataList(6, output_element1D_idx);
            DA.SetDataList(7, output_element2D_idx);
            DA.SetData(8, output_constrained);
            DA.SetData(9, output_supporting);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return TSD_API_ver101.Properties.Resources.API_icon;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("E14D221B-2D99-464F-93A4-1D8C31C6AC02"); }
        }
    }
}