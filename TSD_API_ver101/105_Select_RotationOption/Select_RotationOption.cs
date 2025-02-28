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

namespace TSD_API_ver101_Choose_RotationOption
{
    public class Choose_RotationOption : GH_Component
    {
        RotationOption rotationOption = RotationOption.Unknown; // Default type

        /// <summary>
        /// Initializes a new instance of the Choose_RotationOption class.
        /// </summary>
        public Choose_RotationOption()
          : base("Select_RotationOption", "S_RotationOption",
            "Selecting the RotationOption",
            "TSD_API", "Select_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("RotationOption Number", "RO Number", "Unknown = 0, Degrees0 = 1, Degrees90 = 2, Degrees180 = 3, Degrees270 = 4, Angle = 5", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("RotationOption", "RO", "This is a RotationOption", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        int input_param = 0;

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = rotationOption.ToString();

            if (DA.GetData(0, ref input_param))
            {
                rotationOption = GetRotationOptionFromInput(input_param);
                this.Message = rotationOption.ToString();
            }
            DA.SetData(0, rotationOption);
        }

        private RotationOption GetRotationOptionFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return RotationOption.Unknown;
                case 1:
                    return RotationOption.Degrees0;
                case 2:
                    return RotationOption.Degrees90;
                case 3:
                    return RotationOption.Degrees180;
                case 4:
                    return RotationOption.Degrees270;
                case 5:
                    return RotationOption.Angle;
                default:
                    return RotationOption.Unknown;
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

            var checks = BooleanList(6, input_param);
            AddMenuItems(menu, checks);
        }

        private void AddMenuItems(ToolStripDropDown menu, List<bool> checks)
        {
            Menu_AppendItem(menu, "Unknown", (sender, e) => HandleMenuClick(0, checks, RotationOption.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "0 degrees", (sender, e) => HandleMenuClick(1, checks, RotationOption.Degrees0), true, checks[1]);
            Menu_AppendItem(menu, "90 degrees", (sender, e) => HandleMenuClick(2, checks, RotationOption.Degrees90), true, checks[2]);
            Menu_AppendItem(menu, "180 degrees", (sender, e) => HandleMenuClick(3, checks, RotationOption.Degrees180), true, checks[3]);
            Menu_AppendItem(menu, "270 degrees", (sender, e) => HandleMenuClick(4, checks, RotationOption.Degrees270), true, checks[4]);
            Menu_AppendItem(menu, "User angle", (sender, e) => HandleMenuClick(5, checks, RotationOption.Angle), true, checks[5]);
        }

        void HandleMenuClick(int index, List<bool> checks, RotationOption type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                rotationOption = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                rotationOption = RotationOption.Unknown;
            }
            this.Message = rotationOption.ToString();
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
            get { return new Guid("C8528E25-B496-45AE-B5AE-22AEA95B63F4"); }
        }
    }
}
