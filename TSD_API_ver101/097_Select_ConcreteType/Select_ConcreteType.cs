using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Rhino.Geometry;
using Grasshopper;
using System.Windows.Forms;
using Grasshopper.GUI.Canvas;
using System.Drawing;
using Grasshopper.Kernel.Attributes;
using TSD.API.Remoting.Materials;

namespace TSD_API_ver101_Choose_ConcreteType
{
    public class Choose_ConcreteType : GH_Component
    {
        ConcreteType concreteType = ConcreteType.Unknown; // Default type

        /// <summary>
        /// Initializes a new instance of the Choose_ConcreteType class.
        /// </summary>
        public Choose_ConcreteType()
          : base("Select_ConcreteType", "S_ConcreteType",
            "Selecting the ConcreteType",
            "TSD_API", "Select_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("ConcreteType Number", "CT Number", "Unknown = 0, Normal = 1, Lightweight = 2", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("ConcreteType", "CT", "This is a ConcreteType", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        int input_param = 0;

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = concreteType.ToString();

            if (DA.GetData(0, ref input_param))
            {
                concreteType = GetConcreteTypeFromInput(input_param);
                this.Message = concreteType.ToString();
            }
            DA.SetData(0, concreteType);
        }

        private ConcreteType GetConcreteTypeFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return ConcreteType.Unknown;
                case 1:
                    return ConcreteType.Normal;
                case 2:
                    return ConcreteType.Lightweight;
                default:
                    return ConcreteType.Unknown;
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
            Menu_AppendItem(menu, "Unknown", (sender, e) => HandleMenuClick(0, checks, ConcreteType.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "Normal", (sender, e) => HandleMenuClick(1, checks, ConcreteType.Normal), true, checks[1]);
            Menu_AppendItem(menu, "Lightweight", (sender, e) => HandleMenuClick(2, checks, ConcreteType.Lightweight), true, checks[2]);
        }

        void HandleMenuClick(int index, List<bool> checks, ConcreteType type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                concreteType = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                concreteType = ConcreteType.Unknown;
            }
            this.Message = concreteType.ToString();
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
            get { return new Guid("C92C47E9-31EC-42A3-9A9A-7904BDAC1E2B"); }
        }
    }
}
