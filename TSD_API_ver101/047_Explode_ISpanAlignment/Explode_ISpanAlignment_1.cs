using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
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
using TSD.API.Remoting.Common.Properties;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Materials;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_ISpanAlignment
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_ISpanAlignment_1", "E_ISpanAlignment_1",
            "Exploding the ISpanAlignment ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ISpanAlignment", "ISpanAlignment", "Input ISpanAlignment", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("EndGlobalOffset", "EndGlobalOffset", "Gets the Vector3D at the end of the member span", GH_ParamAccess.item);
            pManager.AddGenericParameter("OffsetMajor", "OffsetMajor", "Gets the offset in the local major direction (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("OffsetMinor", "OffsetMinor", "Gets the offset in the local minor direction (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("SnapLevelMajor", "SnapLevelMajor", "Gets the SectionSnapLevel in local major direction", GH_ParamAccess.item);
            pManager.AddGenericParameter("SnapLevelMinor", "SnapLevelMinor", "Gets the SectionSnapLevel in local minor direction", GH_ParamAccess.item);
            pManager.AddGenericParameter("StartGlobalOffset", "StartGlobalOffset", "Gets the Vector3D at the start of the member span", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Structure.ISpanAlignment input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.

            Vector3d output_endGlobalOffset = Vector3d.Zero;
            double output_offsetMajor = 0.0;
            double output_offsetMinor = 0.0;
            SectionSnapLevel output_snapLevelMajor = SectionSnapLevel.Unknown;
            SectionSnapLevel output_snapLevelMinor = SectionSnapLevel.Unknown;
            Vector3d output_startGlobalOffset = Vector3d.Zero;

            if (input_1 != null)
            {
                // Check each property before accessing it
                try { output_endGlobalOffset = new Vector3d(input_1.EndGlobalOffset.Value.X, input_1.EndGlobalOffset.Value.Y, input_1.EndGlobalOffset.Value.Z); }
                catch { output_endGlobalOffset = Vector3d.Zero; }

                try { output_offsetMajor = input_1.OffsetMajor.Value; }
                catch { output_offsetMajor = 0.0; }

                try { output_offsetMinor = input_1.OffsetMinor.Value; }
                catch { output_offsetMinor = 0.0; }

                try { output_snapLevelMajor = input_1.SnapLevelMajor.Value; }
                catch { output_snapLevelMajor = SectionSnapLevel.Unknown; }

                try { output_snapLevelMinor = input_1.SnapLevelMinor.Value; }
                catch { output_snapLevelMinor = SectionSnapLevel.Unknown; }

                try { output_startGlobalOffset = new Vector3d(input_1.StartGlobalOffset.Value.X, input_1.StartGlobalOffset.Value.Y, input_1.StartGlobalOffset.Value.Z); }
                catch { output_startGlobalOffset = Vector3d.Zero; }
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "ISpanAlignment is not provided or invalid.");
            }

            // Setting the output parameters
            DA.SetData(0, output_endGlobalOffset);
            DA.SetData(1, output_offsetMajor);
            DA.SetData(2, output_offsetMinor);
            DA.SetData(3, output_snapLevelMajor);
            DA.SetData(4, output_snapLevelMinor);
            DA.SetData(5, output_startGlobalOffset);
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
            get { return new Guid("C5592BF4-5346-479E-BF32-ABDCE3B39318"); }
        }

    }
}
