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

namespace TSD_API_ver101_Choose_MemberFabrication
{
    public class Choose_MemberFabrication : GH_Component
    {
        MemberFabrication memberFabrication = MemberFabrication.Unknown; // Default type

        /// <summary>
        /// Initializes a new instance of the Choose_MemberFabrication class.
        /// </summary>
        public Choose_MemberFabrication()
          : base("Select_MemberFabrication", "S_MemberFab",
            "Selecting the MemberFabrication",
            "TSD_API", "Select_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("MemberFabrication Number", "MF Number", "Unknown = 0, Rolled = 1, Plated = 2, WestokCellular = 3, WestokPlated = 4, Fabsec = 5, ConcreteFilled = 6, ConcreteEncased = 7, Joist = 8, Reinforced = 9, PostTensioned = 10, Precast = 11, Sawn = 12, GluLaminated = 13, ColdFormed = 14, ColdRolled = 15, StructuralCompositeLumber = 16, Deltabeam = 17", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("MemberFabrication", "MF", "This is a MemberFabrication", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        int input_param = 0;

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = memberFabrication.ToString();

            if (DA.GetData(0, ref input_param))
            {
                memberFabrication = GetMemberFabricationFromInput(input_param);
                this.Message = memberFabrication.ToString();
            }
            DA.SetData(0, memberFabrication);
        }

        private MemberFabrication GetMemberFabricationFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return MemberFabrication.Unknown;
                case 1:
                    return MemberFabrication.Rolled;
                case 2:
                    return MemberFabrication.Plated;
                case 3:
                    return MemberFabrication.WestokCellular;
                case 4:
                    return MemberFabrication.WestokPlated;
                case 5:
                    return MemberFabrication.Fabsec;
                case 6:
                    return MemberFabrication.ConcreteFilled;
                case 7:
                    return MemberFabrication.ConcreteEncased;
                case 8:
                    return MemberFabrication.Joist;
                case 9:
                    return MemberFabrication.Reinforced;
                case 10:
                    return MemberFabrication.PostTensioned;
                case 11:
                    return MemberFabrication.Precast;
                case 12:
                    return MemberFabrication.Sawn;
                case 13:
                    return MemberFabrication.GluLaminated;
                case 14:
                    return MemberFabrication.ColdFormed;
                case 15:
                    return MemberFabrication.ColdRolled;
                case 16:
                    return MemberFabrication.StructuralCompositeLumber;
                case 17:
                    return MemberFabrication.Deltabeam;
                default:
                    return MemberFabrication.Unknown;
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

            var checks = BooleanList(18, input_param);
            AddMenuItems(menu, checks);
        }

        private void AddMenuItems(ToolStripDropDown menu, List<bool> checks)
        {
            Menu_AppendItem(menu, "Unknown", (sender, e) => HandleMenuClick(0, checks, MemberFabrication.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "Rolled", (sender, e) => HandleMenuClick(1, checks, MemberFabrication.Rolled), true, checks[1]);
            Menu_AppendItem(menu, "Plated", (sender, e) => HandleMenuClick(2, checks, MemberFabrication.Plated), true, checks[2]);
            Menu_AppendItem(menu, "Westok cellular", (sender, e) => HandleMenuClick(3, checks, MemberFabrication.WestokCellular), true, checks[3]);
            Menu_AppendItem(menu, "Westok plated", (sender, e) => HandleMenuClick(4, checks, MemberFabrication.WestokPlated), true, checks[4]);
            Menu_AppendItem(menu, "Fabsec", (sender, e) => HandleMenuClick(5, checks, MemberFabrication.Fabsec), true, checks[5]);
            Menu_AppendItem(menu, "Concrete filled", (sender, e) => HandleMenuClick(6, checks, MemberFabrication.ConcreteFilled), true, checks[6]);
            Menu_AppendItem(menu, "Concrete encased", (sender, e) => HandleMenuClick(7, checks, MemberFabrication.ConcreteEncased), true, checks[7]);
            Menu_AppendItem(menu, "Joist", (sender, e) => HandleMenuClick(8, checks, MemberFabrication.Joist), true, checks[8]);
            Menu_AppendItem(menu, "Reinforced", (sender, e) => HandleMenuClick(9, checks, MemberFabrication.Reinforced), true, checks[9]);
            Menu_AppendItem(menu, "Post tensioned", (sender, e) => HandleMenuClick(10, checks, MemberFabrication.PostTensioned), true, checks[10]);
            Menu_AppendItem(menu, "Precast", (sender, e) => HandleMenuClick(11, checks, MemberFabrication.Precast), true, checks[11]);
            Menu_AppendItem(menu, "Sawn", (sender, e) => HandleMenuClick(12, checks, MemberFabrication.Sawn), true, checks[12]);
            Menu_AppendItem(menu, "Glu laminated", (sender, e) => HandleMenuClick(13, checks, MemberFabrication.GluLaminated), true, checks[13]);
            Menu_AppendItem(menu, "Cold formed", (sender, e) => HandleMenuClick(14, checks, MemberFabrication.ColdFormed), true, checks[14]);
            Menu_AppendItem(menu, "Cold rolled", (sender, e) => HandleMenuClick(15, checks, MemberFabrication.ColdRolled), true, checks[15]);
            Menu_AppendItem(menu, "Structural composite lumber", (sender, e) => HandleMenuClick(16, checks, MemberFabrication.StructuralCompositeLumber), true, checks[16]);
            Menu_AppendItem(menu, "DELTABEAM®", (sender, e) => HandleMenuClick(17, checks, MemberFabrication.Deltabeam), true, checks[17]);
        }

        void HandleMenuClick(int index, List<bool> checks, MemberFabrication type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                memberFabrication = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                memberFabrication = MemberFabrication.Unknown;
            }
            this.Message = memberFabrication.ToString();
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
            get { return new Guid("08352473-1380-47A0-84CD-8622CA1CC0C7"); }
        }
    }
}
