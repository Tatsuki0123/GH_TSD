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

namespace TSD_API_ver101_Choose_MemberType
{
    public class Choose_MemberType : GH_Component
    {
        MemberType memberType = MemberType.Unknown; // Default type

        /// <summary>
        /// Initializes a new instance of the Choose_MemberType class.
        /// </summary>
        public Choose_MemberType()
          : base("Select_MemberType", "S_MemberType",
            "Selecting the MemberType",
            "TSD_API", "Select_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("MemberType Number", "MT Number", "Unknown = 0, Beam = 1, Column = 2, Brace = 3, SteelJoist = 4, GablePost = 5, ParapetPost = 6, Tie = 7, EavesBeam = 8, Purlin = 9, Rail = 10, TrussMemberTop = 11, TrussMemberBottom = 12, TrussMemberSide = 13, TrussInternal = 14, AnalysisElement = 15, WallBeamElement = 16, WallColumnElement = 17, WallMeshBeamElement = 18, BearingWallBeam = 19, BearingWallColumn = 20", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("MemberType", "MT", "This is a MemberType", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        int input_param = 0;

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = memberType.ToString();

            if (DA.GetData(0, ref input_param))
            {
                memberType = GetMemberTypeFromInput(input_param);
                this.Message = memberType.ToString();
            }
            DA.SetData(0, memberType);
        }

        private MemberType GetMemberTypeFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return MemberType.Unknown;
                case 1:
                    return MemberType.Beam;
                case 2:
                    return MemberType.Column;
                case 3:
                    return MemberType.Brace;
                case 4:
                    return MemberType.SteelJoist;
                case 5:
                    return MemberType.GablePost;
                case 6:
                    return MemberType.ParapetPost;
                case 7:
                    return MemberType.Tie;
                case 8:
                    return MemberType.EavesBeam;
                case 9:
                    return MemberType.Purlin;
                case 10:
                    return MemberType.Rail;
                case 11:
                    return MemberType.TrussMemberTop;
                case 12:
                    return MemberType.TrussMemberBottom;
                case 13:
                    return MemberType.TrussMemberSide;
                case 14:
                    return MemberType.TrussInternal;
                case 15:
                    return MemberType.AnalysisElement;
                case 16:
                    return MemberType.WallBeamElement;
                case 17:
                    return MemberType.WallColumnElement;
                case 18:
                    return MemberType.WallMeshBeamElement;
                case 19:
                    return MemberType.BearingWallBeam;
                case 20:
                    return MemberType.BearingWallColumn;
                default:
                    return MemberType.Unknown;
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

            var checks = BooleanList(21, input_param);
            AddMenuItems(menu, checks);
        }

        private void AddMenuItems(ToolStripDropDown menu, List<bool> checks)
        {
            Menu_AppendItem(menu, "Unknown type", (sender, e) => HandleMenuClick(0, checks, MemberType.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "Beam", (sender, e) => HandleMenuClick(1, checks, MemberType.Beam), true, checks[1]);
            Menu_AppendItem(menu, "Column", (sender, e) => HandleMenuClick(2, checks, MemberType.Column), true, checks[2]);
            Menu_AppendItem(menu, "Brace", (sender, e) => HandleMenuClick(3, checks, MemberType.Brace), true, checks[3]);
            Menu_AppendItem(menu, "Steel joist", (sender, e) => HandleMenuClick(4, checks, MemberType.SteelJoist), true, checks[4]);
            Menu_AppendItem(menu, "Gable joist", (sender, e) => HandleMenuClick(5, checks, MemberType.GablePost), true, checks[5]);
            Menu_AppendItem(menu, "Parapet joist", (sender, e) => HandleMenuClick(6, checks, MemberType.ParapetPost), true, checks[6]);
            Menu_AppendItem(menu, "Tie", (sender, e) => HandleMenuClick(7, checks, MemberType.Tie), true, checks[7]);
            Menu_AppendItem(menu, "Eaves beam", (sender, e) => HandleMenuClick(8, checks, MemberType.EavesBeam), true, checks[8]);
            Menu_AppendItem(menu, "Purlin", (sender, e) => HandleMenuClick(9, checks, MemberType.Purlin), true, checks[9]);
            Menu_AppendItem(menu, "Rail", (sender, e) => HandleMenuClick(10, checks, MemberType.Rail), true, checks[10]);
            Menu_AppendItem(menu, "Member of a truss (top)", (sender, e) => HandleMenuClick(11, checks, MemberType.TrussMemberTop), true, checks[11]);
            Menu_AppendItem(menu, "Member of a truss (bottom)", (sender, e) => HandleMenuClick(12, checks, MemberType.TrussMemberBottom), true, checks[12]);
            Menu_AppendItem(menu, "Member of a truss (side)", (sender, e) => HandleMenuClick(13, checks, MemberType.TrussMemberSide), true, checks[13]);
            Menu_AppendItem(menu, "Member of a truss (internal)", (sender, e) => HandleMenuClick(14, checks, MemberType.TrussInternal), true, checks[14]);
            Menu_AppendItem(menu, "Analysis element", (sender, e) => HandleMenuClick(15, checks, MemberType.AnalysisElement), true, checks[15]);
            Menu_AppendItem(menu, "Wall beam of shear wall modelled as mid-pier", (sender, e) => HandleMenuClick(16, checks, MemberType.WallBeamElement), true, checks[16]);
            Menu_AppendItem(menu, "Wall column of shear wall modelled as mid-pier", (sender, e) => HandleMenuClick(17, checks, MemberType.WallColumnElement), true, checks[17]);
            Menu_AppendItem(menu, "Wall beam of shear wall modelled as mesh", (sender, e) => HandleMenuClick(18, checks, MemberType.WallMeshBeamElement), true, checks[18]);
            Menu_AppendItem(menu, "Wall beam of bearing wall", (sender, e) => HandleMenuClick(19, checks, MemberType.BearingWallBeam), true, checks[19]);
            Menu_AppendItem(menu, "Wall column of bearing wall", (sender, e) => HandleMenuClick(20, checks, MemberType.BearingWallColumn), true, checks[20]);
        }

        void HandleMenuClick(int index, List<bool> checks, MemberType type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                memberType = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                memberType = MemberType.Unknown;
            }
            this.Message = memberType.ToString();
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
            get { return new Guid("031C1052-9107-4E02-8A21-94F01ACDB157"); }
        }
    }
}
