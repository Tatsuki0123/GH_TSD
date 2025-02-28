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

namespace TSD_API_ver101_Choose_SectionSnapLevel
{
    public class Choose_SectionSnapLevel : GH_Component
    {
        SectionSnapLevel sectionSnapLevel = SectionSnapLevel.Unknown; // Default type

        /// <summary>
        /// Initializes a new instance of the Choose_SectionSnapLevel class.
        /// </summary>
        public Choose_SectionSnapLevel()
          : base("Select_SectionSnapLevel", "S_SnapLevel",
            "Selecting the SectionSnapLevel",
            "TSD_API", "Select_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("SectionSnapLevel Number", "SL Number", "Unknown = 0, Center = 1, Centroid = 2, Outline0 = 3, Outline1 = 4, Flange0Center = 5, Flange0Outline = 6, Flange1Center = 7, Flange1Outline = 8, WebCenter = 9, WebOutline0 = 10, WebOutline1 = 11, BeamDefault = 12, ColumnDefault = 13", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("SectionSnapLevel", "SL", "This is a SectionSnapLevel", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        int input_param = 0;

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = sectionSnapLevel.ToString();

            if (DA.GetData(0, ref input_param))
            {
                sectionSnapLevel = GetSectionSnapLevelFromInput(input_param);
                this.Message = sectionSnapLevel.ToString();
            }
            DA.SetData(0, sectionSnapLevel);
        }

        private SectionSnapLevel GetSectionSnapLevelFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return SectionSnapLevel.Unknown;
                case 1:
                    return SectionSnapLevel.Center;
                case 2:
                    return SectionSnapLevel.Centroid;
                case 3:
                    return SectionSnapLevel.Outline0;
                case 4:
                    return SectionSnapLevel.Outline1;
                case 5:
                    return SectionSnapLevel.Flange0Center;
                case 6:
                    return SectionSnapLevel.Flange0Outline;
                case 7:
                    return SectionSnapLevel.Flange1Center;
                case 8:
                    return SectionSnapLevel.Flange1Outline;
                case 9:
                    return SectionSnapLevel.WebCenter;
                case 10:
                    return SectionSnapLevel.WebOutline0;
                case 11:
                    return SectionSnapLevel.WebOutline1;
                case 12:
                    return SectionSnapLevel.BeamDefault;
                case 13:
                    return SectionSnapLevel.ColumnDefault;
                default:
                    return SectionSnapLevel.Unknown;
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

            var checks = BooleanList(14, input_param);
            AddMenuItems(menu, checks);
        }

        private void AddMenuItems(ToolStripDropDown menu, List<bool> checks)
        {
            Menu_AppendItem(menu, "Unknown", (sender, e) => HandleMenuClick(0, checks, SectionSnapLevel.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "Center", (sender, e) => HandleMenuClick(1, checks, SectionSnapLevel.Center), true, checks[1]);
            Menu_AppendItem(menu, "Centroid", (sender, e) => HandleMenuClick(2, checks, SectionSnapLevel.Centroid), true, checks[2]);
            Menu_AppendItem(menu, "Outline 0", (sender, e) => HandleMenuClick(3, checks, SectionSnapLevel.Outline0), true, checks[3]);
            Menu_AppendItem(menu, "Outline 1", (sender, e) => HandleMenuClick(4, checks, SectionSnapLevel.Outline1), true, checks[4]);
            Menu_AppendItem(menu, "Flange 0 Center", (sender, e) => HandleMenuClick(5, checks, SectionSnapLevel.Flange0Center), true, checks[5]);
            Menu_AppendItem(menu, "Flange 0 Outline", (sender, e) => HandleMenuClick(6, checks, SectionSnapLevel.Flange0Outline), true, checks[6]);
            Menu_AppendItem(menu, "Flange 1 Center", (sender, e) => HandleMenuClick(7, checks, SectionSnapLevel.Flange1Center), true, checks[7]);
            Menu_AppendItem(menu, "Flange 1 Outline", (sender, e) => HandleMenuClick(8, checks, SectionSnapLevel.Flange1Outline), true, checks[8]);
            Menu_AppendItem(menu, "Web Center", (sender, e) => HandleMenuClick(9, checks, SectionSnapLevel.WebCenter), true, checks[9]);
            Menu_AppendItem(menu, "Web Outline 0", (sender, e) => HandleMenuClick(10, checks, SectionSnapLevel.WebOutline0), true, checks[10]);
            Menu_AppendItem(menu, "Web Outline 1", (sender, e) => HandleMenuClick(11, checks, SectionSnapLevel.WebOutline1), true, checks[11]);
            Menu_AppendItem(menu, "Beam Default", (sender, e) => HandleMenuClick(12, checks, SectionSnapLevel.BeamDefault), true, checks[12]);
            Menu_AppendItem(menu, "Column Default", (sender, e) => HandleMenuClick(13, checks, SectionSnapLevel.ColumnDefault), true, checks[13]);
        }

        void HandleMenuClick(int index, List<bool> checks, SectionSnapLevel type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                sectionSnapLevel = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                sectionSnapLevel = SectionSnapLevel.Unknown;
            }
            this.Message = sectionSnapLevel.ToString();
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
            get { return new Guid("3EE63073-593A-430F-AE4B-638A942C3BF8"); }
        }
    }
}
