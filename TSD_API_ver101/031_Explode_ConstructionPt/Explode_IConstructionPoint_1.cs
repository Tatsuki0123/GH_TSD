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

namespace TSD_API_ver101_IConstructionPoint_Explode

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_IConstructionPoint_1", "E_IConstructionPoint_1",
            "Explodeing the IConstructionPoints ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IConstructionPoints", "IConstructionPoints", "Input IConstructionPoints", GH_ParamAccess.item);
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
            pManager.AddGenericParameter("Solver Node Index", "Solver Node Index", "this is the solver Node index", GH_ParamAccess.item);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Structure.IConstructionPoint input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            double output_coordinate_x = 0;
            double output_coordinate_y = 0;
            double output_coordinate_z = 0;
            int output_index = 0;
            Point3d output_point = new Point3d();
            int output_solvernode_idx = -1;


            if (input_1 != null)
            {
                output_coordinate_x = input_1.Coordinates.Value.X;
                output_coordinate_y = input_1.Coordinates.Value.Y;
                output_coordinate_z = input_1.Coordinates.Value.Z;
                output_index = input_1.Index;
                output_point = new Point3d(output_coordinate_x,output_coordinate_y,output_coordinate_z);
                output_solvernode_idx = input_1.SolverNodeIndex.Value;

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
            DA.SetData(5, output_solvernode_idx);

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
            get { return new Guid("1CC225A4-B5B3-46BA-9D3A-0A9C61DB1867"); }
        }
    }
}