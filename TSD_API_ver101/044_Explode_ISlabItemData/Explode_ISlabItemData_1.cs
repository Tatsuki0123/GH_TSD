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
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Materials;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_ISlabItemData_Explode
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_ISlabItemData_1", "E_ISlabItemData_1",
            "Exploding the ISlabItemData ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ISlabItemData", "ISlabItemData", "Input ISlabItemData", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("AutoDesign", "AutoDesign", "Gets a value indicating whether sections from the design section order will be considered during the design process", GH_ParamAccess.item);
            pManager.AddGenericParameter("AutoDesignOption", "AutoDesignOption", "Gets the AutoDesignOption", GH_ParamAccess.item);
            pManager.AddGenericParameter("BottomCover", "BottomCover", "Gets the bottom cover (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Depth", "Depth", "Gets the depth of the slab item (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("OverrideSlabDepth", "OverrideSlabDepth", "Gets a value indicating whether the slab item overrides depth of the parent slab", GH_ParamAccess.item);
            pManager.AddGenericParameter("TopCover", "TopCover", "Gets the top cover (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("VerticalOffset", "VerticalOffset", "Gets the vertical offset of the slab item (in [mm])", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Structure.ISlabItemData input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.

            bool output_autoDesign = false;
            AutoDesignOption output_autoDesignOption = AutoDesignOption.Unknown;
            double output_bottomCover = 0.0;
            double output_depth = 0.0;
            bool output_overrideSlabDepth = false;
            double output_topCover = 0.0;
            string output_verticalOffset = "N.A";

            if (input_1 != null)
            {
                // Assuming 'input_1' is your input object which contains the required properties.
                try { output_autoDesign = input_1.AutoDesign.Value; }
                catch { output_autoDesign = false; }

                try { output_autoDesignOption = input_1.AutoDesignOption.Value; }
                catch { output_autoDesignOption = AutoDesignOption.Unknown; }

                try { output_bottomCover = input_1.BottomCover.Value; }
                catch { output_bottomCover = 0.0; }

                try { output_depth = input_1.Depth.Value; }
                catch { output_depth = 0.0; }

                try { output_overrideSlabDepth = input_1.OverrideSlabDepth.Value; }
                catch { output_overrideSlabDepth = false; }

                try { output_topCover = input_1.TopCover.Value; }
                catch { output_topCover = 0.0; }

                //output_verticalOffset = input_1.VerticalOffset.Value;
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");
            }

            // Setting the output parameters
            DA.SetData(0, output_autoDesign);
            DA.SetData(1, output_autoDesignOption);
            DA.SetData(2, output_bottomCover);
            DA.SetData(3, output_depth);
            DA.SetData(4, output_overrideSlabDepth);
            DA.SetData(5, output_topCover);
            DA.SetData(6, output_verticalOffset);
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
            get { return new Guid("6C38C057-34ED-4800-BDCE-F25B9FCAA4DE"); }
        }
    }
}
