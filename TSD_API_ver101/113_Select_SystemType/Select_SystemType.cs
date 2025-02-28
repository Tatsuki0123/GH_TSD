using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Windows.Forms;
using TSD.API.Remoting.Common;

namespace TSD_API_ver101_Choose_SystemType
{
    public class Choose_SystemType : GH_Component
    {
        SystemType systemType = SystemType.Unknown; // default type

        public Choose_SystemType()
          : base("Select_SystemType", "S_SystemType",
            "Selecting the System Type",
            "TSD_API", "Select_Functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("SystemType Number", "ST Number", "SystemType enumeration values", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("SystemType", "ST", "This is a SystemType", GH_ParamAccess.item);
        }

        int input_param = 0;
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = systemType.ToString();

            if (DA.GetData(0, ref input_param))
            {
                systemType = GetSystemTypeFromInput(input_param);
                this.Message = systemType.ToString();
            }
            DA.SetData(0, systemType);
        }

        private SystemType GetSystemTypeFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return SystemType.Unknown;
                case 1:
                    return SystemType.Metric;
                case 2:
                    return SystemType.Imperial;
                default:
                    return SystemType.Unknown;
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
            Menu_AppendItem(menu, "Unknown", (sender, e) => HandleMenuClick(0, checks, SystemType.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "Metric", (sender, e) => HandleMenuClick(1, checks, SystemType.Metric), true, checks[1]);
            Menu_AppendItem(menu, "Imperial", (sender, e) => HandleMenuClick(2, checks, SystemType.Imperial), true, checks[2]);
        }

        void HandleMenuClick(int index, List<bool> checks, SystemType type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                systemType = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                systemType = SystemType.Unknown;
            }
            this.Message = systemType.ToString();
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
            get { return new Guid("6EB19788-DAD2-4A08-8D67-FC931BA88082"); }
        }
    }
}
