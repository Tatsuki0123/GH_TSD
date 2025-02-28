using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Rhino.Geometry;
using Grasshopper;
using System.Windows.Forms;
using Grasshopper.GUI.Canvas;
using System.Drawing;
using Grasshopper.Kernel.Attributes;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_Choose_SpringStiffness
{
    public class Choose_SpringStiffness : GH_Component
    {
        SpringStiffness springStiffness = SpringStiffness.Unknown; // Default type

        /// <summary>
        /// Initializes a new instance of the Choose_SpringStiffness class.
        /// </summary>
        public Choose_SpringStiffness()
          : base("Select_SpringStiffness", "S_SpringStiffness",
            "Selecting the SpringStiffness",
            "TSD_API", "Select_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("SpringStiffness Number", "SS Number", "Unknown = 0, Release = 1, SpringLinear = 2, SpringNonLinear = 3, Fixed = 4, NominallyPinned = 5, NominallyFixed = 6, PartiallyFixed = 7", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("SpringStiffness", "SS", "This is a SpringStiffness", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        int input_param = 0;

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = springStiffness.ToString();

            if (DA.GetData(0, ref input_param))
            {
                springStiffness = GetSpringStiffnessFromInput(input_param);
                this.Message = springStiffness.ToString();
            }
            DA.SetData(0, springStiffness);
        }

        private SpringStiffness GetSpringStiffnessFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return SpringStiffness.Unknown;
                case 1:
                    return SpringStiffness.Release;
                case 2:
                    return SpringStiffness.SpringLinear;
                case 3:
                    return SpringStiffness.SpringNonLinear;
                case 4:
                    return SpringStiffness.Fixed;
                case 5:
                    return SpringStiffness.NominallyPinned;
                case 6:
                    return SpringStiffness.NominallyFixed;
                case 7:
                    return SpringStiffness.PartiallyFixed;
                default:
                    return SpringStiffness.Unknown;
            }
        }

        public List<bool> BooleanList(int length, int input_param)
        {
            var checks = new List<bool>(new bool[length]);
            if (input_param >= 0 && input_param < length)
                checks[input_param] = true;
            return checks;
        }

        protected override void AppendAdditionalComponentMenuItems(ToolStripDropDown menu)
        {
            base.AppendAdditionalComponentMenuItems(menu);

            var checks = BooleanList(8, input_param);
            AddMenuItems(menu, checks);
        }

        private void AddMenuItems(ToolStripDropDown menu, List<bool> checks)
        {
            Menu_AppendItem(menu, "Unknown", (sender, e) => HandleMenuClick(0, checks, SpringStiffness.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "Release", (sender, e) => HandleMenuClick(1, checks, SpringStiffness.Release), true, checks[1]);
            Menu_AppendItem(menu, "Spring Linear", (sender, e) => HandleMenuClick(2, checks, SpringStiffness.SpringLinear), true, checks[2]);
            Menu_AppendItem(menu, "Spring Non-Linear", (sender, e) => HandleMenuClick(3, checks, SpringStiffness.SpringNonLinear), true, checks[3]);
            Menu_AppendItem(menu, "Fixed", (sender, e) => HandleMenuClick(4, checks, SpringStiffness.Fixed), true, checks[4]);
            Menu_AppendItem(menu, "Nominally pinned", (sender, e) => HandleMenuClick(5, checks, SpringStiffness.NominallyPinned), true, checks[5]);
            Menu_AppendItem(menu, "Nominally fixed", (sender, e) => HandleMenuClick(6, checks, SpringStiffness.NominallyFixed), true, checks[6]);
            Menu_AppendItem(menu, "Partially fixed", (sender, e) => HandleMenuClick(7, checks, SpringStiffness.PartiallyFixed), true, checks[7]);
        }

        void HandleMenuClick(int index, List<bool> checks, SpringStiffness type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                springStiffness = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                springStiffness = SpringStiffness.Unknown;
            }
            this.Message = springStiffness.ToString();
            ExpireSolution(true);
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
            get { return new Guid("9CD179AE-FEE4-4872-B54A-0E76B01AC509"); }
        }
    }
}
