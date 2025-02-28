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

namespace TSD_API_ver101_Choose_ConcreteDensityClass
{
    public class Choose_ConcreteDensityClass : GH_Component
    {
        ConcreteDensityClass concreteDensityClass = ConcreteDensityClass.Unknown; // Default type

        /// <summary>
        /// Initializes a new instance of the Choose_ConcreteDensityClass class.
        /// </summary>
        public Choose_ConcreteDensityClass()
          : base("Select_ConcreteDensityClass", "S_DensityClass",
            "Selecting the ConcreteDensityClass",
            "TSD_API", "Select_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("ConcreteDensityClass Number", "CD Number", "Unknown = 0, Class20 = 1, Class18 = 2, Class16 = 3, Class14 = 4, Class12 = 5, Class10 = 6", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("ConcreteDensityClass", "CD", "This is a ConcreteDensityClass", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        int input_param = 0;

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = concreteDensityClass.ToString();

            if (DA.GetData(0, ref input_param))
            {
                concreteDensityClass = GetConcreteDensityClassFromInput(input_param);
                this.Message = concreteDensityClass.ToString();
            }
            DA.SetData(0, concreteDensityClass);
        }

        private ConcreteDensityClass GetConcreteDensityClassFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return ConcreteDensityClass.Unknown;
                case 1:
                    return ConcreteDensityClass.Class20;
                case 2:
                    return ConcreteDensityClass.Class18;
                case 3:
                    return ConcreteDensityClass.Class16;
                case 4:
                    return ConcreteDensityClass.Class14;
                case 5:
                    return ConcreteDensityClass.Class12;
                case 6:
                    return ConcreteDensityClass.Class10;
                default:
                    return ConcreteDensityClass.Unknown;
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

            var checks = BooleanList(7, input_param);
            AddMenuItems(menu, checks);
        }

        private void AddMenuItems(ToolStripDropDown menu, List<bool> checks)
        {
            Menu_AppendItem(menu, "Unknown", (sender, e) => HandleMenuClick(0, checks, ConcreteDensityClass.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "Class 2.0", (sender, e) => HandleMenuClick(1, checks, ConcreteDensityClass.Class20), true, checks[1]);
            Menu_AppendItem(menu, "Class 1.8", (sender, e) => HandleMenuClick(2, checks, ConcreteDensityClass.Class18), true, checks[2]);
            Menu_AppendItem(menu, "Class 1.6", (sender, e) => HandleMenuClick(3, checks, ConcreteDensityClass.Class16), true, checks[3]);
            Menu_AppendItem(menu, "Class 1.4", (sender, e) => HandleMenuClick(4, checks, ConcreteDensityClass.Class14), true, checks[4]);
            Menu_AppendItem(menu, "Class 1.2", (sender, e) => HandleMenuClick(5, checks, ConcreteDensityClass.Class12), true, checks[5]);
            Menu_AppendItem(menu, "Class 1.0", (sender, e) => HandleMenuClick(6, checks, ConcreteDensityClass.Class10), true, checks[6]);
        }

        void HandleMenuClick(int index, List<bool> checks, ConcreteDensityClass type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                concreteDensityClass = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                concreteDensityClass = ConcreteDensityClass.Unknown;
            }
            this.Message = concreteDensityClass.ToString();
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
            get { return new Guid("94F4DF9A-3A86-4CA0-AA81-7D5A6459B03A"); }
        }
    }
}
