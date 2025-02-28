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

namespace TSD_API_ver101_Choose_MaterialType
{
    public class Choose_MaterialType : GH_Component
    {
        MaterialType materialType = MaterialType.Unknown; // Default type

        /// <summary>
        /// Initializes a new instance of the Choose_MaterialType class.
        /// </summary>
        public Choose_MaterialType()
          : base("Select_MaterialType", "S_MaterialType",
            "Selecting the MaterialType",
            "TSD_API", "Select_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("MaterialType Number", "MT Number", "Unknown = 0, Steel = 1, Concrete = 2, Timber = 3, General = 4, ColdFormed = 5, ColdRolled = 6", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("MaterialType", "MT", "This is a MaterialType", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        int input_param = 0;

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = materialType.ToString();

            if (DA.GetData(0, ref input_param))
            {
                materialType = GetMaterialTypeFromInput(input_param);
                this.Message = materialType.ToString();
            }
            DA.SetData(0, materialType);
        }

        private MaterialType GetMaterialTypeFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return MaterialType.Unknown;
                case 1:
                    return MaterialType.Steel;
                case 2:
                    return MaterialType.Concrete;
                case 3:
                    return MaterialType.Timber;
                case 4:
                    return MaterialType.General;
                case 5:
                    return MaterialType.ColdFormed;
                case 6:
                    return MaterialType.ColdRolled;
                default:
                    return MaterialType.Unknown;
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
            Menu_AppendItem(menu, "Unknown type", (sender, e) => HandleMenuClick(0, checks, MaterialType.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "Steel", (sender, e) => HandleMenuClick(1, checks, MaterialType.Steel), true, checks[1]);
            Menu_AppendItem(menu, "Concrete", (sender, e) => HandleMenuClick(2, checks, MaterialType.Concrete), true, checks[2]);
            Menu_AppendItem(menu, "Timber", (sender, e) => HandleMenuClick(3, checks, MaterialType.Timber), true, checks[3]);
            Menu_AppendItem(menu, "General", (sender, e) => HandleMenuClick(4, checks, MaterialType.General), true, checks[4]);
            Menu_AppendItem(menu, "Cold formed", (sender, e) => HandleMenuClick(5, checks, MaterialType.ColdFormed), true, checks[5]);
            Menu_AppendItem(menu, "Cold rolled", (sender, e) => HandleMenuClick(6, checks, MaterialType.ColdRolled), true, checks[6]);
        }

        void HandleMenuClick(int index, List<bool> checks, MaterialType type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                materialType = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                materialType = MaterialType.Unknown;
            }
            this.Message = materialType.ToString();
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
            get { return new Guid("60F73B97-C9C1-4280-88D3-6D801D80BB62"); }
        }
    }
}
