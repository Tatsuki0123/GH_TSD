using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Windows.Forms;
using TSD.API.Remoting.Sections;

namespace TSD_API_ver101_Choose_SectionType
{
    public class Choose_SectionType : GH_Component
    {
        SectionType sectionType = SectionType.Unknown; // default type

        public Choose_SectionType()
          : base("Select_SectionType", "S_SectionType",
            "Selecting the Section Type",
            "TSD_API", "Select_Functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("SectionType Number", "ST Number", "SectionType enumeration values", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("SectionType", "ST", "This is a SectionType", GH_ParamAccess.item);
        }

        int input_param = 0;
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = sectionType.ToString();

            if (DA.GetData(0, ref input_param))
            {
                sectionType = GetSectionTypeFromInput(input_param);
                this.Message = sectionType.ToString();
            }
            DA.SetData(0, sectionType);
        }

        private SectionType GetSectionTypeFromInput(int input)
        {
            switch (input)
            {
                case 0:
                    return SectionType.Unknown;
                case 1:
                    return SectionType.UniversalBeam;
                case 2:
                    return SectionType.UniversalColumn;
                case 3:
                    return SectionType.RolledSteelJoist;
                case 4:
                    return SectionType.AsymmetricBeam;
                case 5:
                    return SectionType.RolledSteelChannel;
                case 6:
                    return SectionType.RolledSteelChannelParallel;
                case 7:
                    return SectionType.RectangularHollowSection;
                case 8:
                    return SectionType.SquareHollowSection;
                case 9:
                    return SectionType.CircularHollowSection;
                case 10:
                    return SectionType.StructuralTeeFromUb;
                case 11:
                    return SectionType.StructuralTeeFromUc;
                case 12:
                    return SectionType.EqualAngle;
                case 13:
                    return SectionType.UnequalAngle;
                case 14:
                    return SectionType.FlatBar;
                case 15:
                    return SectionType.ParallelFacedFlangeBeam;
                case 16:
                    return SectionType.WideFlangedBeam;
                case 17:
                    return SectionType.WideFlangedColumn;
                case 18:
                    return SectionType.HSection;
                case 19:
                    return SectionType.ISection;
                case 20:
                    return SectionType.CSection;
                case 21:
                    return SectionType.ASection;
                case 22:
                    return SectionType.Ws;
                case 23:
                    return SectionType.DoubleEqualAngle;
                case 24:
                    return SectionType.DoubleUnequalAngle;
                case 25:
                    return SectionType.W;
                case 26:
                    return SectionType.S;
                case 27:
                    return SectionType.Hp;
                case 28:
                    return SectionType.DoubleAngleShortLegBackToBack;
                case 29:
                    return SectionType.DoubleAngleLongLegBackToBack;
                case 30:
                    return SectionType.PlatedBeam;
                case 31:
                    return SectionType.PlatedColumn;
                case 32:
                    return SectionType.FabsecPlatedBeam;
                case 33:
                    return SectionType.Strongbox235Rhs;
                case 34:
                    return SectionType.Strongbox235Shs;
                case 35:
                    return SectionType.Strongbox235Chs;
                case 36:
                    return SectionType.Hybox355Rhs;
                case 37:
                    return SectionType.Hybox355Chs;
                case 38:
                    return SectionType.Hybox355Shs;
                case 39:
                    return SectionType.SlimflorFabricatedBeam;
                case 40:
                    return SectionType.TimberBeam;
                case 41:
                    return SectionType.GluedLaminatedTimberBeam;
                case 42:
                    return SectionType.ConcreteBeam;
                case 43:
                    return SectionType.WeldedBeam;
                case 44:
                    return SectionType.WeldedColumn;
                case 45:
                    return SectionType.SteelJoist;
                case 46:
                    return SectionType.Rod;
                case 47:
                    return SectionType.ColdRolledZSection;
                case 48:
                    return SectionType.ColdRolledCSection;
                case 49:
                    return SectionType.ColdRolledEavesBeam;
                case 50:
                    return SectionType.WestokCellularBeam;
                case 51:
                    return SectionType.WestokPlatedBeam;
                case 52:
                    return SectionType.DoubleChannelBackToBack;
                case 53:
                    return SectionType.DoubleChannelFaceToFace;
                case 54:
                    return SectionType.Pipe;
                case 55:
                    return SectionType.StiffSection;
                case 56:
                    return SectionType.I3FlangesSymmetric;
                case 57:
                    return SectionType.I3FlangesAsymmetric;
                case 58:
                    return SectionType.HaunchedSection;
                case 59:
                    return SectionType.WallElement;
                case 60:
                    return SectionType.UsColdRolledSSection;
                case 61:
                    return SectionType.UsColdRolledTSection;
                case 62:
                    return SectionType.ColdRolledCSectionWithLip;
                case 63:
                    return SectionType.ColdRolledCSectionWithCurvedLip;
                case 64:
                    return SectionType.ISectionWithPlates;
                case 65:
                    return SectionType.StructuralCompositeLumber;
                case 66:
                    return SectionType.SimpleIWithPlates;
                case 67:
                    return SectionType.SimpleIWithTopPlate;
                case 68:
                    return SectionType.SimpleIWithBottomPlate;
                case 69:
                    return SectionType.RolledSteelJoistWithPlates;
                case 70:
                    return SectionType.SWithPlates;
                case 71:
                    return SectionType.IPlatedWithPlates;
                case 72:
                    return SectionType.IPlatedStar;
                case 73:
                    return SectionType.DoubleI;
                case 74:
                    return SectionType.DoubleIWithPlates;
                case 75:
                    return SectionType.DoublePlated;
                case 76:
                    return SectionType.DoubleAngleStar;
                case 77:
                    return SectionType.PlatedChannelF2F;
                case 78:
                    return SectionType.PlatedChannelF2FWithVerticalPlates;
                case 79:
                    return SectionType.PlatedChannelF2FWithHorizontalPlates;
                case 80:
                    return SectionType.PlatedChannelB2B;
                case 81:
                    return SectionType.PlatedChannelB2BWithPlates;
                case 82:
                    return SectionType.Box;
                case 83:
                    return SectionType.RolledSteelJoistStar;
                case 84:
                    return SectionType.RolledSteelJoistStarWithPlates;
                case 85:
                    return SectionType.SStar;
                case 86:
                    return SectionType.SStarWithPlates;
                case 87:
                    return SectionType.SidePlateSection;
                case 88:
                    return SectionType.AxialSpringSection;
                case 89:
                    return SectionType.DeltabeamDSeries;
                case 90:
                    return SectionType.DeltabeamDrSeries;
                default:
                    return SectionType.Unknown;
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

            var checks = BooleanList(91, input_param);
            AddMenuItems(menu, checks);

        }

        private void AddMenuItems(ToolStripDropDown menu, List<bool> checks)
        {
            Menu_AppendItem(menu, "Unknown", (sender, e) => HandleMenuClick(0, checks, SectionType.Unknown), true, checks[0]);
            Menu_AppendItem(menu, "UniversalBeam", (sender, e) => HandleMenuClick(1, checks, SectionType.UniversalBeam), true, checks[1]);
            Menu_AppendItem(menu, "UniversalColumn", (sender, e) => HandleMenuClick(2, checks, SectionType.UniversalColumn), true, checks[2]);
            Menu_AppendItem(menu, "RolledSteelJoist", (sender, e) => HandleMenuClick(3, checks, SectionType.RolledSteelJoist), true, checks[3]);
            Menu_AppendItem(menu, "AsymmetricBeam", (sender, e) => HandleMenuClick(4, checks, SectionType.AsymmetricBeam), true, checks[4]);
            Menu_AppendItem(menu, "RolledSteelChannel", (sender, e) => HandleMenuClick(5, checks, SectionType.RolledSteelChannel), true, checks[5]);
            Menu_AppendItem(menu, "RolledSteelChannelParallel", (sender, e) => HandleMenuClick(6, checks, SectionType.RolledSteelChannelParallel), true, checks[6]);
            Menu_AppendItem(menu, "RectangularHollowSection", (sender, e) => HandleMenuClick(7, checks, SectionType.RectangularHollowSection), true, checks[7]);
            Menu_AppendItem(menu, "SquareHollowSection", (sender, e) => HandleMenuClick(8, checks, SectionType.SquareHollowSection), true, checks[8]);
            Menu_AppendItem(menu, "CircularHollowSection", (sender, e) => HandleMenuClick(9, checks, SectionType.CircularHollowSection), true, checks[9]);
            Menu_AppendItem(menu, "StructuralTeeFromUB", (sender, e) => HandleMenuClick(10, checks, SectionType.StructuralTeeFromUb), true, checks[10]);
            Menu_AppendItem(menu, "StructuralTeeFromUC", (sender, e) => HandleMenuClick(11, checks, SectionType.StructuralTeeFromUc), true, checks[11]);
            Menu_AppendItem(menu, "EqualAngle", (sender, e) => HandleMenuClick(12, checks, SectionType.EqualAngle), true, checks[12]);
            Menu_AppendItem(menu, "UnequalAngle", (sender, e) => HandleMenuClick(13, checks, SectionType.UnequalAngle), true, checks[13]);
            Menu_AppendItem(menu, "FlatBar", (sender, e) => HandleMenuClick(14, checks, SectionType.FlatBar), true, checks[14]);
            Menu_AppendItem(menu, "ParallelFacedFlangeBeam", (sender, e) => HandleMenuClick(15, checks, SectionType.ParallelFacedFlangeBeam), true, checks[15]);
            Menu_AppendItem(menu, "WideFlangedBeam", (sender, e) => HandleMenuClick(16, checks, SectionType.WideFlangedBeam), true, checks[16]);
            Menu_AppendItem(menu, "WideFlangedColumn", (sender, e) => HandleMenuClick(17, checks, SectionType.WideFlangedColumn), true, checks[17]);
            Menu_AppendItem(menu, "HSection", (sender, e) => HandleMenuClick(18, checks, SectionType.HSection), true, checks[18]);
            Menu_AppendItem(menu, "ISection", (sender, e) => HandleMenuClick(19, checks, SectionType.ISection), true, checks[19]);
            Menu_AppendItem(menu, "CSection", (sender, e) => HandleMenuClick(20, checks, SectionType.CSection), true, checks[20]);
            Menu_AppendItem(menu, "ASection", (sender, e) => HandleMenuClick(21, checks, SectionType.ASection), true, checks[21]);
            Menu_AppendItem(menu, "WS", (sender, e) => HandleMenuClick(22, checks, SectionType.Ws), true, checks[22]);
            Menu_AppendItem(menu, "DoubleEqualAngle", (sender, e) => HandleMenuClick(23, checks, SectionType.DoubleEqualAngle), true, checks[23]);
            Menu_AppendItem(menu, "DoubleUnequalAngle", (sender, e) => HandleMenuClick(24, checks, SectionType.DoubleUnequalAngle), true, checks[24]);
            Menu_AppendItem(menu, "W", (sender, e) => HandleMenuClick(25, checks, SectionType.W), true, checks[25]);
            Menu_AppendItem(menu, "S", (sender, e) => HandleMenuClick(26, checks, SectionType.S), true, checks[26]);
            Menu_AppendItem(menu, "HP", (sender, e) => HandleMenuClick(27, checks, SectionType.Hp), true, checks[27]);
            Menu_AppendItem(menu, "DoubleAngleShortLegBackToBack", (sender, e) => HandleMenuClick(28, checks, SectionType.DoubleAngleShortLegBackToBack), true, checks[28]);
            Menu_AppendItem(menu, "DoubleAngleLongLegBackToBack", (sender, e) => HandleMenuClick(29, checks, SectionType.DoubleAngleLongLegBackToBack), true, checks[29]);
            Menu_AppendItem(menu, "PlatedBeam", (sender, e) => HandleMenuClick(30, checks, SectionType.PlatedBeam), true, checks[30]);
            Menu_AppendItem(menu, "PlatedColumn", (sender, e) => HandleMenuClick(31, checks, SectionType.PlatedColumn), true, checks[31]);
            Menu_AppendItem(menu, "FabsecPlatedBeam", (sender, e) => HandleMenuClick(32, checks, SectionType.FabsecPlatedBeam), true, checks[32]);
            Menu_AppendItem(menu, "Strongbox235RHS", (sender, e) => HandleMenuClick(33, checks, SectionType.Strongbox235Rhs), true, checks[33]);
            Menu_AppendItem(menu, "Strongbox235SHS", (sender, e) => HandleMenuClick(34, checks, SectionType.Strongbox235Shs), true, checks[34]);
            Menu_AppendItem(menu, "Strongbox235CHS", (sender, e) => HandleMenuClick(35, checks, SectionType.Strongbox235Chs), true, checks[35]);
            Menu_AppendItem(menu, "Hybox355RHS", (sender, e) => HandleMenuClick(36, checks, SectionType.Hybox355Rhs), true, checks[36]);
            Menu_AppendItem(menu, "Hybox355CHS", (sender, e) => HandleMenuClick(37, checks, SectionType.Hybox355Chs), true, checks[37]);
            Menu_AppendItem(menu, "Hybox355SHS", (sender, e) => HandleMenuClick(38, checks, SectionType.Hybox355Shs), true, checks[38]);
            Menu_AppendItem(menu, "SlimflorFabricatedBeam", (sender, e) => HandleMenuClick(39, checks, SectionType.SlimflorFabricatedBeam), true, checks[39]);
            Menu_AppendItem(menu, "TimberBeam", (sender, e) => HandleMenuClick(40, checks, SectionType.TimberBeam), true, checks[40]);
            Menu_AppendItem(menu, "GluedLaminatedTimberBeam", (sender, e) => HandleMenuClick(41, checks, SectionType.GluedLaminatedTimberBeam), true, checks[41]);
            Menu_AppendItem(menu, "ConcreteBeam", (sender, e) => HandleMenuClick(42, checks, SectionType.ConcreteBeam), true, checks[42]);
            Menu_AppendItem(menu, "WeldedBeam", (sender, e) => HandleMenuClick(43, checks, SectionType.WeldedBeam), true, checks[43]);
            Menu_AppendItem(menu, "WeldedColumn", (sender, e) => HandleMenuClick(44, checks, SectionType.WeldedColumn), true, checks[44]);
            Menu_AppendItem(menu, "SteelJoist", (sender, e) => HandleMenuClick(45, checks, SectionType.SteelJoist), true, checks[45]);
            Menu_AppendItem(menu, "Rod", (sender, e) => HandleMenuClick(46, checks, SectionType.Rod), true, checks[46]);
            Menu_AppendItem(menu, "ColdRolledZSection", (sender, e) => HandleMenuClick(47, checks, SectionType.ColdRolledZSection), true, checks[47]);
            Menu_AppendItem(menu, "ColdRolledCSection", (sender, e) => HandleMenuClick(48, checks, SectionType.ColdRolledCSection), true, checks[48]);
            Menu_AppendItem(menu, "ColdRolledEavesBeam", (sender, e) => HandleMenuClick(49, checks, SectionType.ColdRolledEavesBeam), true, checks[49]);
            Menu_AppendItem(menu, "WestokCellularBeam", (sender, e) => HandleMenuClick(50, checks, SectionType.WestokCellularBeam), true, checks[50]);
            Menu_AppendItem(menu, "WestokPlatedBeam", (sender, e) => HandleMenuClick(51, checks, SectionType.WestokPlatedBeam), true, checks[51]);
            Menu_AppendItem(menu, "DoubleChannelBackToBack", (sender, e) => HandleMenuClick(52, checks, SectionType.DoubleChannelBackToBack), true, checks[52]);
            Menu_AppendItem(menu, "DoubleChannelFaceToFace", (sender, e) => HandleMenuClick(53, checks, SectionType.DoubleChannelFaceToFace), true, checks[53]);
            Menu_AppendItem(menu, "Pipe", (sender, e) => HandleMenuClick(54, checks, SectionType.Pipe), true, checks[54]);
            Menu_AppendItem(menu, "StiffSection", (sender, e) => HandleMenuClick(55, checks, SectionType.StiffSection), true, checks[55]);
            Menu_AppendItem(menu, "I3FlangesSymmetric", (sender, e) => HandleMenuClick(56, checks, SectionType.I3FlangesSymmetric), true, checks[56]);
            Menu_AppendItem(menu, "I3FlangesAsymmetric", (sender, e) => HandleMenuClick(57, checks, SectionType.I3FlangesAsymmetric), true, checks[57]);
            Menu_AppendItem(menu, "HaunchedSection", (sender, e) => HandleMenuClick(58, checks, SectionType.HaunchedSection), true, checks[58]);
            Menu_AppendItem(menu, "WallElement", (sender, e) => HandleMenuClick(59, checks, SectionType.WallElement), true, checks[59]);
            Menu_AppendItem(menu, "USColdRolledSSection", (sender, e) => HandleMenuClick(60, checks, SectionType.UsColdRolledSSection), true, checks[60]);
            Menu_AppendItem(menu, "USColdRolledTSection", (sender, e) => HandleMenuClick(61, checks, SectionType.UsColdRolledTSection), true, checks[61]);
            Menu_AppendItem(menu, "ColdRolledCSectionWithLip", (sender, e) => HandleMenuClick(62, checks, SectionType.ColdRolledCSectionWithLip), true, checks[62]);
            Menu_AppendItem(menu, "ColdRolledCSectionWithCurvedLip", (sender, e) => HandleMenuClick(63, checks, SectionType.ColdRolledCSectionWithCurvedLip), true, checks[63]);
            Menu_AppendItem(menu, "ISectionWithPlates", (sender, e) => HandleMenuClick(64, checks, SectionType.ISectionWithPlates), true, checks[64]);
            Menu_AppendItem(menu, "StructuralCompositeLumber", (sender, e) => HandleMenuClick(65, checks, SectionType.StructuralCompositeLumber), true, checks[65]);
            Menu_AppendItem(menu, "SimpleIWithPlates", (sender, e) => HandleMenuClick(66, checks, SectionType.SimpleIWithPlates), true, checks[66]);
            Menu_AppendItem(menu, "SimpleIWithTopPlate", (sender, e) => HandleMenuClick(67, checks, SectionType.SimpleIWithTopPlate), true, checks[67]);
            Menu_AppendItem(menu, "SimpleIWithBottomPlate", (sender, e) => HandleMenuClick(68, checks, SectionType.SimpleIWithBottomPlate), true, checks[68]);
            Menu_AppendItem(menu, "RolledSteelJoistWithPlates", (sender, e) => HandleMenuClick(69, checks, SectionType.RolledSteelJoistWithPlates), true, checks[69]);
            Menu_AppendItem(menu, "SWithPlates", (sender, e) => HandleMenuClick(70, checks, SectionType.SWithPlates), true, checks[70]);
            Menu_AppendItem(menu, "IPlatedWithPlates", (sender, e) => HandleMenuClick(71, checks, SectionType.IPlatedWithPlates), true, checks[71]);
            Menu_AppendItem(menu, "IPlatedStar", (sender, e) => HandleMenuClick(72, checks, SectionType.IPlatedStar), true, checks[72]);
            Menu_AppendItem(menu, "DoubleI", (sender, e) => HandleMenuClick(73, checks, SectionType.DoubleI), true, checks[73]);
            Menu_AppendItem(menu, "DoubleIWithPlates", (sender, e) => HandleMenuClick(74, checks, SectionType.DoubleIWithPlates), true, checks[74]);
            Menu_AppendItem(menu, "DoublePlated", (sender, e) => HandleMenuClick(75, checks, SectionType.DoublePlated), true, checks[75]);
            Menu_AppendItem(menu, "DoubleAngleStar", (sender, e) => HandleMenuClick(76, checks, SectionType.DoubleAngleStar), true, checks[76]);
            Menu_AppendItem(menu, "PlatedChannelF2F", (sender, e) => HandleMenuClick(77, checks, SectionType.PlatedChannelF2F), true, checks[77]);
            Menu_AppendItem(menu, "PlatedChannelF2FWithVerticalPlates", (sender, e) => HandleMenuClick(78, checks, SectionType.PlatedChannelF2FWithVerticalPlates), true, checks[78]);
            Menu_AppendItem(menu, "PlatedChannelF2FWithHorizontalPlates", (sender, e) => HandleMenuClick(79, checks, SectionType.PlatedChannelF2FWithHorizontalPlates), true, checks[79]);
            Menu_AppendItem(menu, "PlatedChannelB2B", (sender, e) => HandleMenuClick(80, checks, SectionType.PlatedChannelB2B), true, checks[80]);
            Menu_AppendItem(menu, "PlatedChannelB2BWithPlates", (sender, e) => HandleMenuClick(81, checks, SectionType.PlatedChannelB2BWithPlates), true, checks[81]);
            Menu_AppendItem(menu, "Box", (sender, e) => HandleMenuClick(82, checks, SectionType.Box), true, checks[82]);
            Menu_AppendItem(menu, "RolledSteelJoistStar", (sender, e) => HandleMenuClick(83, checks, SectionType.RolledSteelJoistStar), true, checks[83]);
            Menu_AppendItem(menu, "RolledSteelJoistStarWithPlates", (sender, e) => HandleMenuClick(84, checks, SectionType.RolledSteelJoistStarWithPlates), true, checks[84]);
            Menu_AppendItem(menu, "SStar", (sender, e) => HandleMenuClick(85, checks, SectionType.SStar), true, checks[85]);
            Menu_AppendItem(menu, "SStarWithPlates", (sender, e) => HandleMenuClick(86, checks, SectionType.SStarWithPlates), true, checks[86]);
            Menu_AppendItem(menu, "SidePlateSection", (sender, e) => HandleMenuClick(87, checks, SectionType.SidePlateSection), true, checks[87]);
            Menu_AppendItem(menu, "AxialSpringSection", (sender, e) => HandleMenuClick(88, checks, SectionType.AxialSpringSection), true, checks[88]);
            Menu_AppendItem(menu, "DeltabeamDSeries", (sender, e) => HandleMenuClick(89, checks, SectionType.DeltabeamDSeries), true, checks[89]);
            Menu_AppendItem(menu, "DeltabeamDRSeries", (sender, e) => HandleMenuClick(90, checks, SectionType.DeltabeamDrSeries), true, checks[90]);


        }

        void HandleMenuClick(int index, List<bool> checks, SectionType type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                sectionType = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                sectionType = SectionType.Unknown;
            }
            this.Message = sectionType.ToString();
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
            get { return new Guid("7EDCB109-E3A6-4108-9DD1-8AA2B5B440D8"); }
        }
    }
}
