using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Grasshopper;
using TSD.API.Remoting.Solver;
using System.Windows.Forms;

namespace TSD_API_ver101_Choose_Analysis_Type
{
    public class Select_Analysis_Type : GH_Component
    {

        AnalysisType analysisType = AnalysisType.FirstOrderLinear; //this is a defalut type
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Select_Analysis_Type()
          : base("Select_Analysis_Type_1", "S_AanlysisType_1",
            "Select the Analysis_Type ver 1",
            "TSD_API", "Select_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {

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
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            DA.SetData(0, analysisType);
        }



        Boolean check_1 = true; //default FirstOrderLinear is selected
        Boolean check_2 = false;
        Boolean check_3 = false;
        Boolean check_4 = false;
        Boolean check_5 = false;
        Boolean check_6 = false;
        protected override void AppendAdditionalComponentMenuItems(System.Windows.Forms.ToolStripDropDown menu)
        {
            base.AppendAdditionalComponentMenuItems(menu);
            Menu_AppendItem(menu, "First order linear analysis", (sender, e) => FirstOrderLinear_DoClick(),true,check_1);
            Menu_AppendItem(menu, "First order non-linear analysis", FirstOrderNonLinear_DoClick, true, check_2);
            Menu_AppendItem(menu, "Second order linear analysis", SecondOrderLinear_DoClick, true, check_3);
            Menu_AppendItem(menu, "Second order linear analysis", SecondOrderNonLinear_DoClick, true, check_4);
            Menu_AppendItem(menu, "Grillage chase-down analysis", GrillageChaseDown_DoClick, true, check_5);
            Menu_AppendItem(menu, "FE chase-down analysis", FEChaseDown_DoClick, true, check_6);
        }
        void FirstOrderLinear_DoClick(/*object sender, EventArgs e*/)
        {
            check_1 = !check_1;

            if(check_1)
            {
                analysisType = AnalysisType.FirstOrderLinear;
                check_2 = false;
                check_3 = false;
                check_4 = false;
                check_5 = false;
                check_6 = false;
            }
            else
            {
                analysisType = AnalysisType.None;
            }

            ExpireSolution(true); //this one trigger the SolverInstance -> SolverInstane trigger the RegisterOutputParams -> stop 
        }


        void FirstOrderNonLinear_DoClick(object sender, EventArgs e)
        {
            check_2 = !check_2;

            if (check_2)
            {
                analysisType = AnalysisType.FirstOrderNonLinear;
                check_1 = false;
                check_3 = false;
                check_4 = false;
                check_5 = false;
                check_6 = false;
            }
            else
            {
                analysisType = AnalysisType.None;
            }

            ExpireSolution(true); //this one trigger the SolverInstance -> SolverInstane trigger the RegisterOutputParams -> stop 
        }

        void SecondOrderLinear_DoClick(object sender, EventArgs e)
        {
            check_3 = !check_3;

            if (check_3)
            {
                analysisType = AnalysisType.SecondOrderLinear;
                check_1 = false;
                check_2 = false;
                check_4 = false;
                check_5 = false;
                check_6 = false;
            }
            else
            {
                analysisType = AnalysisType.None;
            }

            ExpireSolution(true); //this one trigger the SolverInstance -> SolverInstane trigger the RegisterOutputParams -> stop 
        }

        void SecondOrderNonLinear_DoClick(object sender, EventArgs e)
        {
            check_4 = !check_4;

            if (check_4)
            {
                analysisType = AnalysisType.SecondOrderNonLinear;
                analysisType = AnalysisType.SecondOrderLinear;
                check_1 = false;
                check_2 = false;
                check_3 = false;
                check_5 = false;
                check_6 = false;
            }
            else
            {
                analysisType = AnalysisType.None;
            }

            ExpireSolution(true); //this one trigger the SolverInstance -> SolverInstane trigger the RegisterOutputParams -> stop 
        }

        void GrillageChaseDown_DoClick(object sender, EventArgs e)
        {
            check_5 = !check_5;

            if (check_5)
            {
                analysisType = AnalysisType.GrillageChaseDown;
                check_1 = false;
                check_2 = false;
                check_3 = false;
                check_4 = false;
                check_6 = false;
            }
            else
            {
                analysisType = AnalysisType.None;
            }

            ExpireSolution(true); //this one trigger the SolverInstance -> SolverInstane trigger the RegisterOutputParams -> stop 
        }

        void FEChaseDown_DoClick(object sender, EventArgs e)
        {
            check_6 = !check_6;

            if (check_6)
            {
                analysisType = AnalysisType.FEChaseDown;
                check_1 = false;
                check_2 = false;
                check_3 = false;
                check_4 = false;
                check_5 = false;
            }
            else
            {
                analysisType = AnalysisType.None;
            }

            ExpireSolution(true); //this one trigger the SolverInstance -> SolverInstane trigger the RegisterOutputParams -> stop 
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
            get { return new Guid("273D560E-F82F-41C2-B51D-2699153AF502"); }
        }
    }
}