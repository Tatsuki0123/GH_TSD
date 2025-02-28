using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Rhino.Geometry;
using Grasshopper;
using System.Windows.Forms;
using Grasshopper.GUI.Canvas;
using System.Drawing;
using Grasshopper.Kernel.Attributes;
using TSD.API.Remoting.Common;

namespace TSD_API_ver101_Choose_AutoDesignOption
{
    public class Choose_AutoDesignOption : GH_Component
    {
        AutoDesignOption autoDesignOption = AutoDesignOption.Unknown; // Default type

        /// <summary>
        /// Initializes a new instance of the Choose_AutoDesignOption class.
        /// </summary>
        public Choose_AutoDesignOption()
          : base("Select_AutoDesignOption", "S_DesignOption",
            "Selecting the AutoDesignOption",
            "TSD_API", "Select_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("AutoDesignOption Number", "AD Number", "Unknown = 0, StartingFromMinima = 1, StartingFromCurrent = 2", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("AutoDesignOption", "AD", "This is an AutoDesignOption", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        int input_param = 0;

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = autoDesignOption.ToString();

            if (DA.GetData(0, ref input_param))
            {
                autoDesignOption = GetAutoDesignOptionFromInput(input_param);
                this.Message = autoDesignOption.ToString();
            }
            DA.SetData(0, autoDesignOption);
        }

        private AutoDesignOption GetAutoDesignOptionFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return AutoDesignOption.Unknown;
                case 1:
                    return AutoDesignOption.StartingFromMinima;
                case 2:
                    return AutoDesignOption.StartingFromCurrent;
                default:
                    return AutoDesignOption.Unknown;
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

            var checks = BooleanList(3, input_param);
            AddMenuItems(menu, checks);
        }

        private void AddMenuItems(ToolStripDropDown menu, List<bool> checks)
        {
            Menu_AppendItem(menu, "Unknown", (sender, e) => HandleMenuClick(0, checks, AutoDesignOption.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "Starting from minima", (sender, e) => HandleMenuClick(1, checks, AutoDesignOption.StartingFromMinima), true, checks[1]);
            Menu_AppendItem(menu, "Starting from current", (sender, e) => HandleMenuClick(2, checks, AutoDesignOption.StartingFromCurrent), true, checks[2]);
        }

        void HandleMenuClick(int index, List<bool> checks, AutoDesignOption type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                autoDesignOption = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                autoDesignOption = AutoDesignOption.Unknown;
            }
            this.Message = autoDesignOption.ToString();
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
            get { return new Guid("C6908F55-AFFA-47CA-A959-33D8844BBF97"); }
        }
    }
}
