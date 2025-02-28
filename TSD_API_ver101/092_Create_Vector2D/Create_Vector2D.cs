
using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Sections;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;
using TSD.API.Remoting.Structure.Create;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;

namespace TSD_API_ver101_Create_Vector2D
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Create_Vector2D", "C_Vector2D",
            "Creating the Vector2D",
            "TSD_API", "Creating_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("X coordinate", "X", "Input X coordinate", GH_ParamAccess.item);
            pManager.AddGenericParameter("Y coordinate", "Y", "Input Y coordinate", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Vector2D", "Vector2D", "This is the vector 2D", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            double x_coor = 0.0;
            double y_coor = 0.0;

            if (!DA.GetData(0, ref x_coor)) return;
            if (!DA.GetData(1, ref y_coor)) return;

            var Output_1 = new TSD.API.Remoting.Geometry.Vector2D();

            Output_1 = Create_Vector2D_output.CreateVector2D(x_coor, y_coor);

            DA.SetData(0, Output_1);



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
            get { return new Guid("FEE6400C-1709-421D-931B-FC0812A33CC2"); }
        }
    }
}



