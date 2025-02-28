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

namespace TSD_API_ver101_Choose_ElementType
{
    public class Choose_ElementType : GH_Component
    {
        ElementType elementType = ElementType.Unknown; // Default type

        /// <summary>
        /// Initializes a new instance of the Choose_ElementType class.
        /// </summary>
        public Choose_ElementType()
          : base("Select_ElementType", "S_ElementType",
            "Selecting the ElementType",
            "TSD_API", "Select_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("ElementType Number", "ET Number", "Unknown = 0, Beam = 1, Truss = 2, TensionOnly = 3, TensionOnlyXBrace = 4, CompressionOnly = 5, LinearAxial = 6, LinearTorsional = 7, NonLinearAxial = 8, NonLinearTorsional = 9, Link = 10", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("ElementType", "ET", "This is an ElementType", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        int input_param = 0;

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = elementType.ToString();

            if (DA.GetData(0, ref input_param))
            {
                elementType = GetElementTypeFromInput(input_param);
                this.Message = elementType.ToString();
            }
            DA.SetData(0, elementType);
        }

        private ElementType GetElementTypeFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return ElementType.Unknown;
                case 1:
                    return ElementType.Beam;
                case 2:
                    return ElementType.Truss;
                case 3:
                    return ElementType.TensionOnly;
                case 4:
                    return ElementType.TensionOnlyXBrace;
                case 5:
                    return ElementType.CompressionOnly;
                case 6:
                    return ElementType.LinearAxial;
                case 7:
                    return ElementType.LinearTorsional;
                case 8:
                    return ElementType.NonLinearAxial;
                case 9:
                    return ElementType.NonLinearTorsional;
                case 10:
                    return ElementType.Link;
                default:
                    return ElementType.Unknown;
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

            var checks = BooleanList(11, input_param);
            AddMenuItems(menu, checks);
        }

        private void AddMenuItems(ToolStripDropDown menu, List<bool> checks)
        {
            Menu_AppendItem(menu, "Unknown", (sender, e) => HandleMenuClick(0, checks, ElementType.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "Beam", (sender, e) => HandleMenuClick(1, checks, ElementType.Beam), true, checks[1]);
            Menu_AppendItem(menu, "Truss", (sender, e) => HandleMenuClick(2, checks, ElementType.Truss), true, checks[2]);
            Menu_AppendItem(menu, "Tension only", (sender, e) => HandleMenuClick(3, checks, ElementType.TensionOnly), true, checks[3]);
            Menu_AppendItem(menu, "Tension only X brace", (sender, e) => HandleMenuClick(4, checks, ElementType.TensionOnlyXBrace), true, checks[4]);
            Menu_AppendItem(menu, "Compression only", (sender, e) => HandleMenuClick(5, checks, ElementType.CompressionOnly), true, checks[5]);
            Menu_AppendItem(menu, "Linear axial spring", (sender, e) => HandleMenuClick(6, checks, ElementType.LinearAxial), true, checks[6]);
            Menu_AppendItem(menu, "Linear torsional spring", (sender, e) => HandleMenuClick(7, checks, ElementType.LinearTorsional), true, checks[7]);
            Menu_AppendItem(menu, "Non-linear axial spring", (sender, e) => HandleMenuClick(8, checks, ElementType.NonLinearAxial), true, checks[8]);
            Menu_AppendItem(menu, "Non-linear torsional spring", (sender, e) => HandleMenuClick(9, checks, ElementType.NonLinearTorsional), true, checks[9]);
            Menu_AppendItem(menu, "Link", (sender, e) => HandleMenuClick(10, checks, ElementType.Link), true, checks[10]);
        }

        void HandleMenuClick(int index, List<bool> checks, ElementType type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                elementType = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                elementType = ElementType.Unknown;
            }
            this.Message = elementType.ToString();
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
            get { return new Guid("D9459B11-181F-4B52-8383-59DBCEB1A9AD"); }
        }
    }
}
