using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Rhino.Geometry;
using Grasshopper;
using System.Windows.Forms;
using Grasshopper.GUI.Canvas;
using System.Drawing;
using Grasshopper.Kernel.Attributes;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_Choose_CurvedOption
{
    public class Choose_CurvedOption : GH_Component
    {
        CurvedOption curvedOption = CurvedOption.Unknown; // Default type

        /// <summary>
        /// Initializes a new instance of the Choose_CurvedOption class.
        /// </summary>
        public Choose_CurvedOption()
          : base("Select_CurvedOption", "S_CurvedOption",
            "Selecting the CurvedOption",
            "TSD_API", "Select_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("CurvedOption Number", "CO Number", "Unknown = 0, Straight = 1, Major = 2, Minor = 3", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("CurvedOption", "CO", "This is a CurvedOption", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        int input_param = 0;

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = curvedOption.ToString();

            if (DA.GetData(0, ref input_param))
            {
                curvedOption = GetCurvedOptionFromInput(input_param);
                this.Message = curvedOption.ToString();
            }
            DA.SetData(0, curvedOption);
        }

        private CurvedOption GetCurvedOptionFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return CurvedOption.Unknown;
                case 1:
                    return CurvedOption.Straight;
                case 2:
                    return CurvedOption.Major;
                case 3:
                    return CurvedOption.Minor;
                default:
                    return CurvedOption.Unknown;
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

            var checks = BooleanList(4, input_param);
            AddMenuItems(menu, checks);
        }

        private void AddMenuItems(ToolStripDropDown menu, List<bool> checks)
        {
            Menu_AppendItem(menu, "Unknown", (sender, e) => HandleMenuClick(0, checks, CurvedOption.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "Straight", (sender, e) => HandleMenuClick(1, checks, CurvedOption.Straight), true, checks[1]);
            Menu_AppendItem(menu, "Curved major (curves vertically)", (sender, e) => HandleMenuClick(2, checks, CurvedOption.Major), true, checks[2]);
            Menu_AppendItem(menu, "Curved minor (curves horizontally)", (sender, e) => HandleMenuClick(3, checks, CurvedOption.Minor), true, checks[3]);
        }

        void HandleMenuClick(int index, List<bool> checks, CurvedOption type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                curvedOption = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                curvedOption = CurvedOption.Unknown;
            }
            this.Message = curvedOption.ToString();
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
            get { return new Guid("6567E926-421E-448A-8E03-7D90BCF19CF5"); }
        }
    }
}
