using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Windows.Forms;
using TSD.API.Remoting.Common;

namespace TSD_API_ver101_Choose_HeadCode
{
    public class Choose_HeadCode : GH_Component
    {
        HeadCode headCode = HeadCode.Unknown; // default type

        public Choose_HeadCode()
          : base("Select_HeadCode", "S_HeadCode",
            "Selecting the Head Code",
            "TSD_API", "Select_Functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("HeadCode Number", "HC Number", "HeadCode enumeration values", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("HeadCode", "HC", "This is a HeadCode", GH_ParamAccess.item);
        }

        int input_param = 0;
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = headCode.ToString();

            if (DA.GetData(0, ref input_param))
            {
                headCode = GetHeadCodeFromInput(input_param);
                this.Message = headCode.ToString();
            }
            DA.SetData(0, headCode);
        }

        private HeadCode GetHeadCodeFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return HeadCode.Unknown;
                case 1:
                    return HeadCode.Bs;
                case 2:
                    return HeadCode.Aisc;
                case 3:
                    return HeadCode.Ec;
                case 4:
                    return HeadCode.UnitedStatesAisc;
                case 5:
                    return HeadCode.EuropeEc;
                case 6:
                    return HeadCode.UnitedKingdomEc;
                case 7:
                    return HeadCode.IrelandEc;
                case 8:
                    return HeadCode.SingaporeEc;
                case 9:
                    return HeadCode.MalaysiaEc;
                case 10:
                    return HeadCode.India;
                case 11:
                    return HeadCode.UnitedKingdomBs;
                case 12:
                    return HeadCode.SouthAfricaBs;
                case 13:
                    return HeadCode.SingaporeBs;
                case 14:
                    return HeadCode.MalaysiaBs;
                case 15:
                    return HeadCode.Australia;
                case 16:
                    return HeadCode.IrelandBs;
                case 17:
                    return HeadCode.CzechRepublicEc;
                case 18:
                    return HeadCode.EstoniaEc;
                case 19:
                    return HeadCode.FinlandEc;
                case 20:
                    return HeadCode.NorwayEc;
                case 21:
                    return HeadCode.SwedenEc;
                case 22:
                    return HeadCode.NeutralEc;
                case 23:
                    return HeadCode.NeutralUs;
                case 24:
                    return HeadCode.NeutralBs;
                case 25:
                    return HeadCode.NeutralAs;
                case 26:
                    return HeadCode.NeutralIs;
                default:
                    return HeadCode.Unknown;
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

            var checks = BooleanList(27, input_param);
            AddMenuItems(menu, checks);
        }

        private void AddMenuItems(ToolStripDropDown menu, List<bool> checks)
        {
            Menu_AppendItem(menu, "Unknown", (sender, e) => HandleMenuClick(0, checks, HeadCode.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "BS", (sender, e) => HandleMenuClick(1, checks, HeadCode.Bs), true, checks[1]);
            Menu_AppendItem(menu, "AISC", (sender, e) => HandleMenuClick(2, checks, HeadCode.Aisc), true, checks[2]);
            Menu_AppendItem(menu, "EC", (sender, e) => HandleMenuClick(3, checks, HeadCode.Ec), true, checks[3]);
            Menu_AppendItem(menu, "United States AISC", (sender, e) => HandleMenuClick(4, checks, HeadCode.UnitedStatesAisc), true, checks[4]);
            Menu_AppendItem(menu, "Europe EC", (sender, e) => HandleMenuClick(5, checks, HeadCode.EuropeEc), true, checks[5]);
            Menu_AppendItem(menu, "United Kingdom EC", (sender, e) => HandleMenuClick(6, checks, HeadCode.UnitedKingdomEc), true, checks[6]);
            Menu_AppendItem(menu, "Ireland EC", (sender, e) => HandleMenuClick(7, checks, HeadCode.IrelandEc), true, checks[7]);
            Menu_AppendItem(menu, "Singapore EC", (sender, e) => HandleMenuClick(8, checks, HeadCode.SingaporeEc), true, checks[8]);
            Menu_AppendItem(menu, "Malaysia EC", (sender, e) => HandleMenuClick(9, checks, HeadCode.MalaysiaEc), true, checks[9]);
            Menu_AppendItem(menu, "India", (sender, e) => HandleMenuClick(10, checks, HeadCode.India), true, checks[10]);
            Menu_AppendItem(menu, "United Kingdom BS", (sender, e) => HandleMenuClick(11, checks, HeadCode.UnitedKingdomBs), true, checks[11]);
            Menu_AppendItem(menu, "South Africa BS", (sender, e) => HandleMenuClick(12, checks, HeadCode.SouthAfricaBs), true, checks[12]);
            Menu_AppendItem(menu, "Singapore BS", (sender, e) => HandleMenuClick(13, checks, HeadCode.SingaporeBs), true, checks[13]);
            Menu_AppendItem(menu, "Malaysia BS", (sender, e) => HandleMenuClick(14, checks, HeadCode.MalaysiaBs), true, checks[14]);
            Menu_AppendItem(menu, "Australia", (sender, e) => HandleMenuClick(15, checks, HeadCode.Australia), true, checks[15]);
            Menu_AppendItem(menu, "Ireland BS", (sender, e) => HandleMenuClick(16, checks, HeadCode.IrelandBs), true, checks[16]);
            Menu_AppendItem(menu, "Czech Republic EC", (sender, e) => HandleMenuClick(17, checks, HeadCode.CzechRepublicEc), true, checks[17]);
            Menu_AppendItem(menu, "Estonia EC", (sender, e) => HandleMenuClick(18, checks, HeadCode.EstoniaEc), true, checks[18]);
            Menu_AppendItem(menu, "Finland EC", (sender, e) => HandleMenuClick(19, checks, HeadCode.FinlandEc), true, checks[19]);
            Menu_AppendItem(menu, "Norway EC", (sender, e) => HandleMenuClick(20, checks, HeadCode.NorwayEc), true, checks[20]);
            Menu_AppendItem(menu, "Sweden EC", (sender, e) => HandleMenuClick(21, checks, HeadCode.SwedenEc), true, checks[21]);
            Menu_AppendItem(menu, "Neutral EC", (sender, e) => HandleMenuClick(22, checks, HeadCode.NeutralEc), true, checks[22]);
            Menu_AppendItem(menu, "Neutral US", (sender, e) => HandleMenuClick(23, checks, HeadCode.NeutralUs), true, checks[23]);
            Menu_AppendItem(menu, "Neutral BS", (sender, e) => HandleMenuClick(24, checks, HeadCode.NeutralBs), true, checks[24]);
            Menu_AppendItem(menu, "Neutral AS", (sender, e) => HandleMenuClick(25, checks, HeadCode.NeutralAs), true, checks[25]);
            Menu_AppendItem(menu, "Neutral IS", (sender, e) => HandleMenuClick(26, checks, HeadCode.NeutralIs), true, checks[26]);
        }

        void HandleMenuClick(int index, List<bool> checks, HeadCode type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                headCode = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                headCode = HeadCode.Unknown;
            }
            this.Message = headCode.ToString();
            ExpireSolution(true);
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return TSD_API_ver101.Properties.Resources.API_icon;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("D9F09DFE-9984-4283-8CE1-53DE0C14C71D"); }
        }
    }
}
