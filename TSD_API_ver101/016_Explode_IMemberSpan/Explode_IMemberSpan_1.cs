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

namespace TSD_API_ver101_IMemberSpan_Explode

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_IMemberSpan_1", "E_IMemberSpan_1",
            "Explodeing the IMemberSpan ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IMemberSpan", "IMemberSpan", "Input IMemberSpan", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Name", "N", "this is name of the loadcase", GH_ParamAccess.item);
            pManager.AddGenericParameter("Index", "Index", "this is Loadcase index in tsd", GH_ParamAccess.item);
            pManager.AddGenericParameter("Length", "L", "this is the length of the span", GH_ParamAccess.item);
            pManager.AddGenericParameter("Material", "mat", "this is the material of the span", GH_ParamAccess.item);
            pManager.AddGenericParameter("Section", "sec", "this is the section of the span", GH_ParamAccess.item);
            pManager.AddGenericParameter("Angle", "Angle", "this is the rotational angle of the span", GH_ParamAccess.item);
            pManager.AddGenericParameter("Material Type", "Mat_type", "this is the Material type of the span", GH_ParamAccess.item);
            pManager.AddGenericParameter("IMemberSection", "IMemSec", "this is the object of IMeberSection", GH_ParamAccess.item);
            pManager.AddGenericParameter("IMaterial", "IMat", "this is the object of IMaterial", GH_ParamAccess.item);
            pManager.AddGenericParameter("ISegment3D", "ISegment3D", "this is the object of ISegment3D", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Structure.IMemberSpan input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            string output_name = "N.A";
            int output_index = -1;
            double output_length = -1;
            string output_mat = "N.A";
            string output_sec = "N.A";
            double output_angle = 0;
            string output_mat_type = "N.A";
            IMemberSection output_IMemberSection = null;
            IMaterial output_IMaterial = null;
            ISegment3D output_ISegment3D = null;



            if (input_1 != null)
            {
                output_name = input_1.Name;
                output_index = input_1.Index;
                output_length = input_1.Length.Value;
                output_mat = input_1.Material.Value.Name;
                output_sec = (input_1.ElementSection.Value as IMemberSection)?.PhysicalSection.Value.LongName;
                output_angle = input_1.RotationAngle.Value;
                output_mat_type = input_1.Material.Value.Type.ToString();
                output_IMemberSection = (input_1.ElementSection.Value as IMemberSection);
                output_IMaterial = input_1.Material.Value; 
                output_ISegment3D = input_1.DesignSegment.Value;

                


            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetData(0, output_name);
            DA.SetData(1, output_index);
            DA.SetData(2, output_length);
            DA.SetData(3, output_mat);
            DA.SetData(4, output_sec);
            DA.SetData(5, output_angle);
            DA.SetData(6, output_mat_type);
            DA.SetData(7, output_IMemberSection);
            DA.SetData(8, output_IMaterial);
            DA.SetData(9, output_ISegment3D);


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
            get { return new Guid("113A2494-9E8D-42A9-BC81-4559633A08CD"); }
        }
    }
}