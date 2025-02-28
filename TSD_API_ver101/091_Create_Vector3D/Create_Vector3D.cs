
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

namespace TSD_API_ver101_Create_Vector3D
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Create_Vector3D", "C_Vector3D",
            "Creating the Vector3D",
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
            pManager.AddGenericParameter("Z coordinate", "Z", "Input Z coordinate", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Vector3D", "Vector3D", "This is the vector 3D", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            double x_coor = 0.0;
            double y_coor = 0.0;
            double z_coor = 0.0;

            if (!DA.GetData(0, ref x_coor)) return;
            if (!DA.GetData(1, ref y_coor)) return;
            if (!DA.GetData(2, ref z_coor)) return;

            var Output_1 = new TSD.API.Remoting.Geometry.Vector3D();

            Output_1 = Create_Entity_General_output.CreateVector3D(x_coor, y_coor,z_coor);

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
            get { return new Guid("4744570D-C492-4ABC-86D5-0A25A1B7A5CB"); }
        }
    }
}



