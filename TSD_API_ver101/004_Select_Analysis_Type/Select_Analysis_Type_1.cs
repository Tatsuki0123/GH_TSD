using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Grasshopper;
using TSD.API.Remoting.Solver;
using System.Windows.Forms;
using Grasshopper.GUI.Canvas;
using System.Drawing;
using Grasshopper.Kernel.Attributes;

namespace TSD_API_ver101_Choose_Analysis_Type_1
{
    public class Choose_Analysis_Type : GH_Component
    {

        AnalysisType analysisType = AnalysisType.FirstOrderLinear; //this is a defalut type
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Choose_Analysis_Type()
          : base("Select_Analysis_Type_2", "S_AnalysisType_2",
            "Selecting the Analysis_Type ver2",
            "TSD_API", "Select_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("AnalysisType Number", "AT Number", "FirstorderLinear = 0, FistOrderNonLinear = 1, SecondOrderLinear = 2, SecondOrderNonLinear = 3, GrillageChasedown = 4, FEChaseDown = 5", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("AnalysisType", "AT", "This is a AnlaysisType", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        /// 

        int input_param = 0;
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = analysisType.ToString();

            if (DA.GetData(0, ref input_param))
            {
                analysisType = GetAnalysisTypeFromInput(input_param);
                this.Message = analysisType.ToString();
            }
            DA.SetData(0, analysisType);
        }

        private AnalysisType GetAnalysisTypeFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return AnalysisType.FirstOrderLinear;
                case 1:
                    return AnalysisType.FirstOrderNonLinear;
                case 2:
                    return AnalysisType.SecondOrderLinear;
                case 3:
                    return AnalysisType.SecondOrderNonLinear;
                case 4:
                    return AnalysisType.GrillageChaseDown;
                case 5:
                    return AnalysisType.FEChaseDown;
                default:
                    return AnalysisType.FirstOrderLinear;
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
            Menu_AppendItem(menu, "First order linear analysis", (sender, e) => HandleMenuClick(0, checks, AnalysisType.FirstOrderLinear), true, checks[0]);
            Menu_AppendItem(menu, "First order non-linear analysis", (sender, e) => HandleMenuClick(1, checks, AnalysisType.FirstOrderNonLinear), true, checks[1]);
            Menu_AppendItem(menu, "Second order linear analysis", (sender, e) => HandleMenuClick(2, checks, AnalysisType.SecondOrderLinear), true, checks[2]);
            Menu_AppendItem(menu, "Second order non-linear analysis", (sender, e) => HandleMenuClick(3, checks, AnalysisType.SecondOrderNonLinear), true, checks[3]);
            Menu_AppendItem(menu, "Grillage chase-down analysis", (sender, e) => HandleMenuClick(4, checks, AnalysisType.GrillageChaseDown), true, checks[4]);
            Menu_AppendItem(menu, "FE chase-down analysis", (sender, e) => HandleMenuClick(5, checks, AnalysisType.FEChaseDown), true, checks[5]);
        }



        void HandleMenuClick(int index, List<bool> checks, AnalysisType type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                analysisType = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                analysisType = AnalysisType.None;
            }
            this.Message = analysisType.ToString();
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
            get { return new Guid("F8FE32C1-A2AD-4182-A878-7B8AEF20D3BB"); }
        }
    }
}