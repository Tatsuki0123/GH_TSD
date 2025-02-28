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

namespace TSD_API_ver101_Choose_MemberConstruction
{
    public class Choose_MemberConstruction : GH_Component
    {
        MemberConstruction memberConstruction = MemberConstruction.Unknown; // Default type

        /// <summary>
        /// Initializes a new instance of the Choose_MemberConstruction class.
        /// </summary>
        public Choose_MemberConstruction()
          : base("Select_MemberConstruction", "S_MemberConstruction",
            "Selecting the MemberConstruction",
            "TSD_API", "Select_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("MemberConstruction Number", "MC Number", "Unknown = 0, SteelBeam = 1, CompositeBeam = 2, SteelColumn = 3, CompositeColumn = 4, SteelBrace = 5, SteelJoist = 6, SteelGablePost = 7, SteelParapetPost = 8, SteelTie = 9, SteelTrussMemberTop = 10, SteelTrussMemberBottom = 11, SteelTrussMemberSide = 12, SteelTrussInternal = 13, ConcreteBeam = 14, ConcreteColumn = 15, TimberBeam = 16, TimberColumn = 17, TimberBrace = 18, TimberGablePost = 19, TimberTrussMemberTop = 20, TimberTrussMemberBottom = 21, TimberTrussMemberSide = 22, TimberTrussInternal = 23, ColdFormedBeam = 24, ColdFormedColumn = 25, ColdFormedBrace = 26, ColdFormedGablePost = 27, Purlin = 28, Rail = 29, EavesBeam = 30, ConcreteWallBeamElement = 31, ConcreteWallMeshBeamElement = 32, ConcreteWallColumnElement = 33, ColdFormedParapetPost = 34, GeneralMaterialBeam = 35, GeneralMaterialColumn = 36, GeneralMaterialBrace = 37, ColdFormedTrussMemberTop = 38, ColdFormedTrussMemberBottom = 39, ColdFormedTrussMemberSide = 40, ColdFormedTrussInternal = 41, BearingWallBeam = 42, BearingWallColumn = 43, ColdRolledBeam = 44, ColdRolledColumn = 45, GroundBeam = 46, StiffeningBeam = 47, CouplingBeam = 48, GeneralWallMeshBeamElement = 49, MasonryWallMeshBeamElement = 50", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("MemberConstruction", "MC", "This is a MemberConstruction", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        int input_param = 0;

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = memberConstruction.ToString();

            if (DA.GetData(0, ref input_param))
            {
                memberConstruction = GetMemberConstructionFromInput(input_param);
                this.Message = memberConstruction.ToString();
            }
            DA.SetData(0, memberConstruction);
        }

        private MemberConstruction GetMemberConstructionFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return MemberConstruction.Unknown;
                case 1:
                    return MemberConstruction.SteelBeam;
                case 2:
                    return MemberConstruction.CompositeBeam;
                case 3:
                    return MemberConstruction.SteelColumn;
                case 4:
                    return MemberConstruction.CompositeColumn;
                case 5:
                    return MemberConstruction.SteelBrace;
                case 6:
                    return MemberConstruction.SteelJoist;
                case 7:
                    return MemberConstruction.SteelGablePost;
                case 8:
                    return MemberConstruction.SteelParapetPost;
                case 9:
                    return MemberConstruction.SteelTie;
                case 10:
                    return MemberConstruction.SteelTrussMemberTop;
                case 11:
                    return MemberConstruction.SteelTrussMemberBottom;
                case 12:
                    return MemberConstruction.SteelTrussMemberSide;
                case 13:
                    return MemberConstruction.SteelTrussInternal;
                case 14:
                    return MemberConstruction.ConcreteBeam;
                case 15:
                    return MemberConstruction.ConcreteColumn;
                case 16:
                    return MemberConstruction.TimberBeam;
                case 17:
                    return MemberConstruction.TimberColumn;
                case 18:
                    return MemberConstruction.TimberBrace;
                case 19:
                    return MemberConstruction.TimberGablePost;
                case 20:
                    return MemberConstruction.TimberTrussMemberTop;
                case 21:
                    return MemberConstruction.TimberTrussMemberBottom;
                case 22:
                    return MemberConstruction.TimberTrussMemberSide;
                case 23:
                    return MemberConstruction.TimberTrussInternal;
                case 24:
                    return MemberConstruction.ColdFormedBeam;
                case 25:
                    return MemberConstruction.ColdFormedColumn;
                case 26:
                    return MemberConstruction.ColdFormedBrace;
                case 27:
                    return MemberConstruction.ColdFormedGablePost;
                case 28:
                    return MemberConstruction.Purlin;
                case 29:
                    return MemberConstruction.Rail;
                case 30:
                    return MemberConstruction.EavesBeam;
                case 31:
                    return MemberConstruction.ConcreteWallBeamElement;
                case 32:
                    return MemberConstruction.ConcreteWallMeshBeamElement;
                case 33:
                    return MemberConstruction.ConcreteWallColumnElement;
                case 34:
                    return MemberConstruction.ColdFormedParapetPost;
                case 35:
                    return MemberConstruction.GeneralMaterialBeam;
                case 36:
                    return MemberConstruction.GeneralMaterialColumn;
                case 37:
                    return MemberConstruction.GeneralMaterialBrace;
                case 38:
                    return MemberConstruction.ColdFormedTrussMemberTop;
                case 39:
                    return MemberConstruction.ColdFormedTrussMemberBottom;
                case 40:
                    return MemberConstruction.ColdFormedTrussMemberSide;
                case 41:
                    return MemberConstruction.ColdFormedTrussInternal;
                case 42:
                    return MemberConstruction.BearingWallBeam;
                case 43:
                    return MemberConstruction.BearingWallColumn;
                case 44:
                    return MemberConstruction.ColdRolledBeam;
                case 45:
                    return MemberConstruction.ColdRolledColumn;
                case 46:
                    return MemberConstruction.GroundBeam;
                case 47:
                    return MemberConstruction.StiffeningBeam;
                case 48:
                    return MemberConstruction.CouplingBeam;
                case 49:
                    return MemberConstruction.GeneralWallMeshBeamElement;
                case 50:
                    return MemberConstruction.MasonryWallMeshBeamElement;
                default:
                    return MemberConstruction.Unknown;
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

            var checks = BooleanList(51, input_param);
            AddMenuItems(menu, checks);
        }

        private void AddMenuItems(ToolStripDropDown menu, List<bool> checks)
        {
            Menu_AppendItem(menu, "Unknown", (sender, e) => HandleMenuClick(0, checks, MemberConstruction.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "Steel beam", (sender, e) => HandleMenuClick(1, checks, MemberConstruction.SteelBeam), true, checks[1]);
            Menu_AppendItem(menu, "Composite beam", (sender, e) => HandleMenuClick(2, checks, MemberConstruction.CompositeBeam), true, checks[2]);
            Menu_AppendItem(menu, "Steel column", (sender, e) => HandleMenuClick(3, checks, MemberConstruction.SteelColumn), true, checks[3]);
            Menu_AppendItem(menu, "Composite column", (sender, e) => HandleMenuClick(4, checks, MemberConstruction.CompositeColumn), true, checks[4]);
            Menu_AppendItem(menu, "Steel brace", (sender, e) => HandleMenuClick(5, checks, MemberConstruction.SteelBrace), true, checks[5]);
            Menu_AppendItem(menu, "Steel joist", (sender, e) => HandleMenuClick(6, checks, MemberConstruction.SteelJoist), true, checks[6]);
            Menu_AppendItem(menu, "Steel gable post", (sender, e) => HandleMenuClick(7, checks, MemberConstruction.SteelGablePost), true, checks[7]);
            Menu_AppendItem(menu, "Steel parapet post", (sender, e) => HandleMenuClick(8, checks, MemberConstruction.SteelParapetPost), true, checks[8]);
            Menu_AppendItem(menu, "Steel tie", (sender, e) => HandleMenuClick(9, checks, MemberConstruction.SteelTie), true, checks[9]);
            Menu_AppendItem(menu, "Steel truss member top", (sender, e) => HandleMenuClick(10, checks, MemberConstruction.SteelTrussMemberTop), true, checks[10]);
            Menu_AppendItem(menu, "Steel truss member bottom", (sender, e) => HandleMenuClick(11, checks, MemberConstruction.SteelTrussMemberBottom), true, checks[11]);
            Menu_AppendItem(menu, "Steel truss member side", (sender, e) => HandleMenuClick(12, checks, MemberConstruction.SteelTrussMemberSide), true, checks[12]);
            Menu_AppendItem(menu, "Steel truss internal", (sender, e) => HandleMenuClick(13, checks, MemberConstruction.SteelTrussInternal), true, checks[13]);
            Menu_AppendItem(menu, "Concrete beam", (sender, e) => HandleMenuClick(14, checks, MemberConstruction.ConcreteBeam), true, checks[14]);
            Menu_AppendItem(menu, "Concrete column", (sender, e) => HandleMenuClick(15, checks, MemberConstruction.ConcreteColumn), true, checks[15]);
            Menu_AppendItem(menu, "Timber beam", (sender, e) => HandleMenuClick(16, checks, MemberConstruction.TimberBeam), true, checks[16]);
            Menu_AppendItem(menu, "Timber column", (sender, e) => HandleMenuClick(17, checks, MemberConstruction.TimberColumn), true, checks[17]);
            Menu_AppendItem(menu, "Timber brace", (sender, e) => HandleMenuClick(18, checks, MemberConstruction.TimberBrace), true, checks[18]);
            Menu_AppendItem(menu, "Timber gable post", (sender, e) => HandleMenuClick(19, checks, MemberConstruction.TimberGablePost), true, checks[19]);
            Menu_AppendItem(menu, "Timber truss member top", (sender, e) => HandleMenuClick(20, checks, MemberConstruction.TimberTrussMemberTop), true, checks[20]);
            Menu_AppendItem(menu, "Timber truss member bottom", (sender, e) => HandleMenuClick(21, checks, MemberConstruction.TimberTrussMemberBottom), true, checks[21]);
            Menu_AppendItem(menu, "Timber truss member side", (sender, e) => HandleMenuClick(22, checks, MemberConstruction.TimberTrussMemberSide), true, checks[22]);
            Menu_AppendItem(menu, "Timber truss internal", (sender, e) => HandleMenuClick(23, checks, MemberConstruction.TimberTrussInternal), true, checks[23]);
            Menu_AppendItem(menu, "Cold formed beam", (sender, e) => HandleMenuClick(24, checks, MemberConstruction.ColdFormedBeam), true, checks[24]);
            Menu_AppendItem(menu, "Cold formed column", (sender, e) => HandleMenuClick(25, checks, MemberConstruction.ColdFormedColumn), true, checks[25]);
            Menu_AppendItem(menu, "Cold formed brace", (sender, e) => HandleMenuClick(26, checks, MemberConstruction.ColdFormedBrace), true, checks[26]);
            Menu_AppendItem(menu, "Cold formed gable post", (sender, e) => HandleMenuClick(27, checks, MemberConstruction.ColdFormedGablePost), true, checks[27]);
            Menu_AppendItem(menu, "Cold formed purlin", (sender, e) => HandleMenuClick(28, checks, MemberConstruction.Purlin), true, checks[28]);
            Menu_AppendItem(menu, "Cold formed rail", (sender, e) => HandleMenuClick(29, checks, MemberConstruction.Rail), true, checks[29]);
            Menu_AppendItem(menu, "Eaves beam", (sender, e) => HandleMenuClick(30, checks, MemberConstruction.EavesBeam), true, checks[30]);
            Menu_AppendItem(menu, "Concrete wall beam element", (sender, e) => HandleMenuClick(31, checks, MemberConstruction.ConcreteWallBeamElement), true, checks[31]);
            Menu_AppendItem(menu, "Concrete wall mesh beam element", (sender, e) => HandleMenuClick(32, checks, MemberConstruction.ConcreteWallMeshBeamElement), true, checks[32]);
            Menu_AppendItem(menu, "Concrete wall column element", (sender, e) => HandleMenuClick(33, checks, MemberConstruction.ConcreteWallColumnElement), true, checks[33]);
            Menu_AppendItem(menu, "Cold formed parapet post", (sender, e) => HandleMenuClick(34, checks, MemberConstruction.ColdFormedParapetPost), true, checks[34]);
            Menu_AppendItem(menu, "General material beam", (sender, e) => HandleMenuClick(35, checks, MemberConstruction.GeneralMaterialBeam), true, checks[35]);
            Menu_AppendItem(menu, "General material column", (sender, e) => HandleMenuClick(36, checks, MemberConstruction.GeneralMaterialColumn), true, checks[36]);
            Menu_AppendItem(menu, "General material brace", (sender, e) => HandleMenuClick(37, checks, MemberConstruction.GeneralMaterialBrace), true, checks[37]);
            Menu_AppendItem(menu, "Cold formed truss member top", (sender, e) => HandleMenuClick(38, checks, MemberConstruction.ColdFormedTrussMemberTop), true, checks[38]);
            Menu_AppendItem(menu, "Cold formed truss member bottom", (sender, e) => HandleMenuClick(39, checks, MemberConstruction.ColdFormedTrussMemberBottom), true, checks[39]);
            Menu_AppendItem(menu, "Cold formed truss member side", (sender, e) => HandleMenuClick(40, checks, MemberConstruction.ColdFormedTrussMemberSide), true, checks[40]);
            Menu_AppendItem(menu, "Cold formed truss internal", (sender, e) => HandleMenuClick(41, checks, MemberConstruction.ColdFormedTrussInternal), true, checks[41]);
            Menu_AppendItem(menu, "Bearing wall beam", (sender, e) => HandleMenuClick(42, checks, MemberConstruction.BearingWallBeam), true, checks[42]);
            Menu_AppendItem(menu, "Bearing wall column", (sender, e) => HandleMenuClick(43, checks, MemberConstruction.BearingWallColumn), true, checks[43]);
            Menu_AppendItem(menu, "Cold rolled beam", (sender, e) => HandleMenuClick(44, checks, MemberConstruction.ColdRolledBeam), true, checks[44]);
            Menu_AppendItem(menu, "Cold rolled column", (sender, e) => HandleMenuClick(45, checks, MemberConstruction.ColdRolledColumn), true, checks[45]);
            Menu_AppendItem(menu, "Ground beam", (sender, e) => HandleMenuClick(46, checks, MemberConstruction.GroundBeam), true, checks[46]);
            Menu_AppendItem(menu, "Stiffening beam", (sender, e) => HandleMenuClick(47, checks, MemberConstruction.StiffeningBeam), true, checks[47]);
            Menu_AppendItem(menu, "Coupling beam", (sender, e) => HandleMenuClick(48, checks, MemberConstruction.CouplingBeam), true, checks[48]);
            Menu_AppendItem(menu, "General wall mesh beam element", (sender, e) => HandleMenuClick(49, checks, MemberConstruction.GeneralWallMeshBeamElement), true, checks[49]);
            Menu_AppendItem(menu, "Masonry wall mesh beam element", (sender, e) => HandleMenuClick(50, checks, MemberConstruction.MasonryWallMeshBeamElement), true, checks[50]);
        }

        void HandleMenuClick(int index, List<bool> checks, MemberConstruction type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                memberConstruction = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                memberConstruction = MemberConstruction.Unknown;
            }
            this.Message = memberConstruction.ToString();
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
            get { return new Guid("84FA1AF5-B886-4E1C-872F-A40506FA9F4A"); }
        }
    }
}
