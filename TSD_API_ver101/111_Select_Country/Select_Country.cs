using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Windows.Forms;
using TSD.API.Remoting.Common;

namespace TSD_API_ver101_Choose_Country
{
    public class Choose_Country : GH_Component
    {
        Country country = Country.Unknown; // default type

        public Choose_Country()
          : base("Select_Country", "S_Country",
            "Selecting the Country",
            "TSD_API", "Select_Functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("Country Number", "C Number", "Country enumeration values", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Country", "C", "This is a Country", GH_ParamAccess.item);
        }

        int input_param = 0;
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = country.ToString();

            if (DA.GetData(0, ref input_param))
            {
                country = GetCountryFromInput(input_param);
                this.Message = country.ToString();
            }
            DA.SetData(0, country);
        }

        private Country GetCountryFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return Country.Unknown;
                case 1:
                    return Country.Worldwide;
                case 2:
                    return Country.Usa;
                case 3:
                    return Country.Canada;
                case 4:
                    return Country.SouthAfrica;
                case 5:
                    return Country.Uk;
                case 6:
                    return Country.Europe;
                case 7:
                    return Country.Ireland;
                case 8:
                    return Country.Australia;
                case 9:
                    return Country.Malaysia;
                case 10:
                    return Country.Singapore;
                case 11:
                    return Country.China;
                case 12:
                    return Country.Japan;
                case 13:
                    return Country.India;
                case 14:
                    return Country.Korea;
                case 15:
                    return Country.Taiwan;
                case 16:
                    return Country.Thailand;
                case 17:
                    return Country.Finland;
                case 18:
                    return Country.Norway;
                case 19:
                    return Country.Sweden;
                case 20:
                    return Country.Philippines;
                case 21:
                    return Country.Indonesia;
                default:
                    return Country.Unknown;
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

            var checks = BooleanList(22, input_param);
            AddMenuItems(menu, checks);
        }

        private void AddMenuItems(ToolStripDropDown menu, List<bool> checks)
        {
            Menu_AppendItem(menu, "Unknown", (sender, e) => HandleMenuClick(0, checks, Country.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "Worldwide", (sender, e) => HandleMenuClick(1, checks, Country.Worldwide), true, checks[1]);
            Menu_AppendItem(menu, "United States of America", (sender, e) => HandleMenuClick(2, checks, Country.Usa), true, checks[2]);
            Menu_AppendItem(menu, "Canada", (sender, e) => HandleMenuClick(3, checks, Country.Canada), true, checks[3]);
            Menu_AppendItem(menu, "South Africa", (sender, e) => HandleMenuClick(4, checks, Country.SouthAfrica), true, checks[4]);
            Menu_AppendItem(menu, "United Kingdom", (sender, e) => HandleMenuClick(5, checks, Country.Uk), true, checks[5]);
            Menu_AppendItem(menu, "Europe", (sender, e) => HandleMenuClick(6, checks, Country.Europe), true, checks[6]);
            Menu_AppendItem(menu, "Ireland", (sender, e) => HandleMenuClick(7, checks, Country.Ireland), true, checks[7]);
            Menu_AppendItem(menu, "Australia", (sender, e) => HandleMenuClick(8, checks, Country.Australia), true, checks[8]);
            Menu_AppendItem(menu, "Malaysia", (sender, e) => HandleMenuClick(9, checks, Country.Malaysia), true, checks[9]);
            Menu_AppendItem(menu, "Singapore", (sender, e) => HandleMenuClick(10, checks, Country.Singapore), true, checks[10]);
            Menu_AppendItem(menu, "China", (sender, e) => HandleMenuClick(11, checks, Country.China), true, checks[11]);
            Menu_AppendItem(menu, "Japan", (sender, e) => HandleMenuClick(12, checks, Country.Japan), true, checks[12]);
            Menu_AppendItem(menu, "India", (sender, e) => HandleMenuClick(13, checks, Country.India), true, checks[13]);
            Menu_AppendItem(menu, "Korea", (sender, e) => HandleMenuClick(14, checks, Country.Korea), true, checks[14]);
            Menu_AppendItem(menu, "Taiwan", (sender, e) => HandleMenuClick(15, checks, Country.Taiwan), true, checks[15]);
            Menu_AppendItem(menu, "Thailand", (sender, e) => HandleMenuClick(16, checks, Country.Thailand), true, checks[16]);
            Menu_AppendItem(menu, "Finland", (sender, e) => HandleMenuClick(17, checks, Country.Finland), true, checks[17]);
            Menu_AppendItem(menu, "Norway", (sender, e) => HandleMenuClick(18, checks, Country.Norway), true, checks[18]);
            Menu_AppendItem(menu, "Sweden", (sender, e) => HandleMenuClick(19, checks, Country.Sweden), true, checks[19]);
            Menu_AppendItem(menu, "Philippines", (sender, e) => HandleMenuClick(20, checks, Country.Philippines), true, checks[20]);
            Menu_AppendItem(menu, "Indonesia", (sender, e) => HandleMenuClick(21, checks, Country.Indonesia), true, checks[21]);
        }

        void HandleMenuClick(int index, List<bool> checks, Country type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                country = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                country = Country.Unknown;
            }
            this.Message = country.ToString();
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
            get { return new Guid("778BE4BE-E1FE-454E-B42D-E2D7A60C0619"); }
        }
    }
}
