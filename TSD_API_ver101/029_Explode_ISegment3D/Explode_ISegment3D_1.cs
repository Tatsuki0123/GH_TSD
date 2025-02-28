using System;
using System.Collections.Generic;
using System.Linq;
using GH_IO.Types;
using Google.Protobuf.WellKnownTypes;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Geometry;
using TSD.API.Remoting.Materials;
using TSD.API.Remoting.Sections;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_ISegment3D_Explode

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_ISegment3D_1", "E_ISegment3D_1",
            "Explodeing the ISegment3D ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ISegment3D", "ISegment3D", "Input ISegment3D", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Magnitude", "Magnitude", "this is Magnitude", GH_ParamAccess.item);
            pManager.AddGenericParameter("Type of the Segment", "TypeofSegment", "this is Type of the segment", GH_ParamAccess.item);
            pManager.AddGenericParameter("LocalCoordSystem3D", "LocalCoordSystem3D", "this is the LocalCoordSystem3D", GH_ParamAccess.item);
            pManager.AddGenericParameter("LocalCorrdinateOriginPoint", "Origin_Point", "this is the LocalCoordSystem3D of the origin point", GH_ParamAccess.item);
            pManager.AddGenericParameter("LocalCoordSystm X vector", "LocalCoor_X_Vector", "this is the LocalCoordSystem3D or X axis vector", GH_ParamAccess.item);
            pManager.AddGenericParameter("LocalCoordSystm Y vector", "LocalCoor_Y_Vector", "this is the LocalCoordSystem3D or Y axis vector", GH_ParamAccess.item);
            pManager.AddGenericParameter("LocalCoordSystm Z vector", "LocalCoor_Z_Vector", "this is the LocalCoordSystem3D or Z axis vector", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Geometry.ISegment3D input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            double output_mag = 0.0;
            SegmentType output_type = SegmentType.Unknown;
            LocalCoordSystem3D output_localcoor = new LocalCoordSystem3D();
            Point3d output_origin = new Point3d();
            Vector3d output_localx = new Vector3d();
            Vector3d output_localy = new Vector3d();
            Vector3d output_localz = new Vector3d();





            if (input_1 != null)
            {
                output_mag = input_1.Magnitude.Value;
                output_type = input_1.Type.Value;
                output_localcoor = input_1.GetLcs(0); //Local coordinate with origin at the start of the segment
                output_origin = new Point3d(output_localcoor.Origin.X, output_localcoor.Origin.Y, output_localcoor.Origin.Z);
                output_localx = new Vector3d(output_localcoor.Axes.XAxis.X, output_localcoor.Axes.XAxis.Y, output_localcoor.Axes.XAxis.Z);
                output_localy = new Vector3d(output_localcoor.Axes.YAxis.X, output_localcoor.Axes.YAxis.Y, output_localcoor.Axes.YAxis.Z);
                output_localz = new Vector3d(output_localcoor.Axes.ZAxis.X, output_localcoor.Axes.ZAxis.Y, output_localcoor.Axes.ZAxis.Z);
         



            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetData(0, output_mag);
            DA.SetData(1, output_type);
            DA.SetData(2, output_localcoor);
            DA.SetData(3, output_origin);
            DA.SetData(4, output_localx);
            DA.SetData(5, output_localy);
            DA.SetData(6, output_localz);



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
            get { return new Guid("C2446B86-4468-435D-BF11-7516763E0DA7"); }
        }
    }
}