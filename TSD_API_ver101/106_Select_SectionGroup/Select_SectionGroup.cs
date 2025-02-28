using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Rhino.Geometry;
using Grasshopper;
using System.Windows.Forms;
using Grasshopper.GUI.Canvas;
using System.Drawing;
using Grasshopper.Kernel.Attributes;
using TSD.API.Remoting.Sections;

namespace TSD_API_ver101_Choose_SectionGroup
{
    public class Choose_SectionGroup : GH_Component
    {
        SectionGroup sectionGroup = SectionGroup.Unknown; // Default type

        /// <summary>
        /// Initializes a new instance of the Choose_SectionGroup class.
        /// </summary>
        public Choose_SectionGroup()
          : base("Select_SectionGroup", "S_SectionGroup",
            "Selecting the SectionGroup",
            "TSD_API", "Select_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("SectionGroup Number", "SG Number", "The number representing the section group", GH_ParamAccess.item);
            pManager[0].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("SectionGroup", "SG", "This is a SectionGroup", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        int input_param = 0;

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            this.Message = sectionGroup.ToString();

            if (DA.GetData(0, ref input_param))
            {
                sectionGroup = GetSectionGroupFromInput(input_param);
                this.Message = sectionGroup.ToString();
            }
            DA.SetData(0, sectionGroup);
        }

        private SectionGroup GetSectionGroupFromInput(int input)
        {
            switch (input)
            {
                case 1:
                    return SectionGroup.AusCompoundSteelSectionsDoubleRolledISections;
                case 2:
                    return SectionGroup.AusCompoundSteelSectionsDoubleRolledISectionsWithPlates;
                case 3:
                    return SectionGroup.AusCompoundSteelSectionsRolledAnglesInStarArrangement;
                case 4:
                    return SectionGroup.AusCompoundSteelSectionsRolledChannelsBackToBack;
                case 5:
                    return SectionGroup.AusCompoundSteelSectionsRolledChannelsBackToBackWithPlates;
                case 6:
                    return SectionGroup.AusCompoundSteelSectionsRolledChannelsToeToToe;
                case 7:
                    return SectionGroup.AusCompoundSteelSectionsRolledChannelsToeToToeWithHorizontalPlates;
                case 8:
                    return SectionGroup.AusCompoundSteelSectionsRolledChannelsToeToToeWithVerticalPlates;
                case 9:
                    return SectionGroup.AusCompoundSteelSectionsRolledISectionsWithBottomPlate;
                case 10:
                    return SectionGroup.AusCompoundSteelSectionsRolledISectionsWithPlates;
                case 11:
                    return SectionGroup.AusCompoundSteelSectionsRolledISectionsWithTopPlate;
                case 12:
                    return SectionGroup.AusCompoundSteelSectionsRolledSteelJoistsInStarArrangement;
                case 13:
                    return SectionGroup.AusCompoundSteelSectionsRolledSteelJoistsWithPlates;
                case 14:
                    return SectionGroup.AusCompoundSteelSectionsRolledSteelJoistsWithPlatesInStarArrangement;
                case 15:
                    return SectionGroup.AustralianColdRolledSectionsBluescopeLysaghtCSections;
                case 16:
                    return SectionGroup.AustralianColdRolledSectionsBluescopeLysaghtEavesBeams;
                case 17:
                    return SectionGroup.AustralianColdRolledSectionsBluescopeLysaghtZSections;
                case 18:
                    return SectionGroup.AustralianHollowSteelSectionsCircularHollowSectionsC250;
                case 19:
                    return SectionGroup.AustralianHollowSteelSectionsCircularHollowSectionsC350;
                case 20:
                    return SectionGroup.AustralianHollowSteelSectionsRectangularHollowSectionsC350;
                case 21:
                    return SectionGroup.AustralianHollowSteelSectionsRectangularHollowSectionsC450;
                case 22:
                    return SectionGroup.AustralianHollowSteelSectionsSquareHollowSectionsC350;
                case 23:
                    return SectionGroup.AustralianHollowSteelSectionsSquareHollowSectionsC450;
                case 24:
                    return SectionGroup.AustralianSteelSections2EqualAnglesBackToBack;
                case 25:
                    return SectionGroup.AustralianSteelSections2UnequalAnglesLongLegBackToBack;
                case 26:
                    return SectionGroup.AustralianSteelSections2UnequalAnglesShortLegBackToBack;
                case 27:
                    return SectionGroup.AustralianSteelSectionsEqualAngles;
                case 28:
                    return SectionGroup.AustralianSteelSectionsFlatBars;
                case 29:
                    return SectionGroup.AustralianSteelSectionsParallelFlangeChannels;
                case 30:
                    return SectionGroup.AustralianSteelSectionsPlatedBeams;
                case 31:
                    return SectionGroup.AustralianSteelSectionsPlatedColumns;
                case 32:
                    return SectionGroup.AustralianSteelSectionsTaperFlangeChannels;
                case 33:
                    return SectionGroup.AustralianSteelSectionsTaperedFlangeBeams;
                case 34:
                    return SectionGroup.AustralianSteelSectionsTeeFromUniversalBeams;
                case 35:
                    return SectionGroup.AustralianSteelSectionsTeeFromUniversalColumns;
                case 36:
                    return SectionGroup.AustralianSteelSectionsUnequalAngles;
                case 37:
                    return SectionGroup.AustralianSteelSectionsUniversalBeams;
                case 38:
                    return SectionGroup.AustralianSteelSectionsUniversalColumns;
                case 39:
                    return SectionGroup.AustralianSteelSectionsWeldedBeams;
                case 40:
                    return SectionGroup.AustralianSteelSectionsWeldedColumns;
                case 41:
                    return SectionGroup.AustralianSteelSectionsWestokCellularBeams;
                case 42:
                    return SectionGroup.CanadianSclTimberSectionsSiMicrollamLvl20E;
                case 43:
                    return SectionGroup.CanadianSclTimberSectionsSiTimberStrandLsl13E;
                case 44:
                    return SectionGroup.CanadianSclTimberSectionsSiTimberStrandLsl155E;
                case 45:
                    return SectionGroup.CanadianSclTimberSectionsSiWestFraserLvl17E;
                case 46:
                    return SectionGroup.CanadianSclTimberSectionsSiWestFraserLvl18E;
                case 47:
                    return SectionGroup.CanadianSclTimberSectionsSiWestFraserLvl19E;
                case 48:
                    return SectionGroup.CanadianSclTimberSectionsSiWestFraserLvl20E;
                case 49:
                    return SectionGroup.CanadianSclTimberSectionsUsMicrollamLvl20E;
                case 50:
                    return SectionGroup.CanadianSclTimberSectionsUsTimberStrandLsl13E;
                case 51:
                    return SectionGroup.CanadianSclTimberSectionsUsTimberStrandLsl155E;
                case 52:
                    return SectionGroup.CanadianSclTimberSectionsUsWestFraserLvl17E;
                case 53:
                    return SectionGroup.CanadianSclTimberSectionsUsWestFraserLvl18E;
                case 54:
                    return SectionGroup.CanadianSclTimberSectionsUsWestFraserLvl19E;
                case 55:
                    return SectionGroup.CanadianSclTimberSectionsUsWestFraserLvl20E;
                case 56:
                    return SectionGroup.CanadianSteelSectionsAstmPipes;
                case 57:
                    return SectionGroup.CanadianSteelSectionsAngles;
                case 58:
                    return SectionGroup.CanadianSteelSectionsChannels;
                case 59:
                    return SectionGroup.CanadianSteelSectionsDoubleAnglesEqual;
                case 60:
                    return SectionGroup.CanadianSteelSectionsDoubleAnglesLongLegBackToBack;
                case 61:
                    return SectionGroup.CanadianSteelSectionsDoubleAnglesShortLegBackToBack;
                case 62:
                    return SectionGroup.CanadianSteelSectionsHp;
                case 63:
                    return SectionGroup.CanadianSteelSectionsM;
                case 64:
                    return SectionGroup.CanadianSteelSectionsMiscChannels;
                case 65:
                    return SectionGroup.CanadianSteelSectionsPipes;
                case 66:
                    return SectionGroup.CanadianSteelSectionsPlatedBeams;
                case 67:
                    return SectionGroup.CanadianSteelSectionsPlatedColumns;
                case 68:
                    return SectionGroup.CanadianSteelSectionsRectangularAstmTubes;
                case 69:
                    return SectionGroup.CanadianSteelSectionsRectangularTubes;
                case 70:
                    return SectionGroup.CanadianSteelSectionsS;
                case 71:
                    return SectionGroup.CanadianSteelSectionsSquareAstmTubes;
                case 72:
                    return SectionGroup.CanadianSteelSectionsSquareTubes;
                case 73:
                    return SectionGroup.CanadianSteelSectionsSuperLightBeams;
                case 74:
                    return SectionGroup.CanadianSteelSectionsTeeFromWideFlangeShapes;
                case 75:
                    return SectionGroup.CanadianSteelSectionsW;
                case 76:
                    return SectionGroup.CanadianSteelSectionsWestokCellularBeams;
                case 77:
                    return SectionGroup.ChineseSteelSectionsChannelSections;
                case 78:
                    return SectionGroup.ChineseSteelSectionsEqualAngles;
                case 79:
                    return SectionGroup.ChineseSteelSectionsHSections;
                case 80:
                    return SectionGroup.ChineseSteelSectionsISections;
                case 81:
                    return SectionGroup.ChineseSteelSectionsJoistSections;
                case 82:
                    return SectionGroup.ChineseSteelSectionsPlatedBeams;
                case 83:
                    return SectionGroup.ChineseSteelSectionsPlatedColumns;
                case 84:
                    return SectionGroup.ChineseSteelSectionsRectangularHollowSections;
                case 85:
                    return SectionGroup.ChineseSteelSectionsSquareHollowSections;
                case 86:
                    return SectionGroup.ChineseSteelSectionsUnequalAngles;
                case 87:
                    return SectionGroup.ChineseSteelSectionsWestokCellularBeams;
                case 88:
                    return SectionGroup.EcCompoundSteelSectionsDoubleRolledISections;
                case 89:
                    return SectionGroup.EcCompoundSteelSectionsDoubleRolledISectionsWithPlates;
                case 90:
                    return SectionGroup.EcCompoundSteelSectionsRolledAnglesInStarArrangement;
                case 91:
                    return SectionGroup.EcCompoundSteelSectionsRolledChannelsBackToBack;
                case 92:
                    return SectionGroup.EcCompoundSteelSectionsRolledChannelsBackToBackWithPlates;
                case 93:
                    return SectionGroup.EcCompoundSteelSectionsRolledChannelsToeToToe;
                case 94:
                    return SectionGroup.EcCompoundSteelSectionsRolledChannelsToeToToeWithHorizontalPlates;
                case 95:
                    return SectionGroup.EcCompoundSteelSectionsRolledChannelsToeToToeWithVerticalPlates;
                case 96:
                    return SectionGroup.EcCompoundSteelSectionsRolledISectionsWithBottomPlate;
                case 97:
                    return SectionGroup.EcCompoundSteelSectionsRolledISectionsWithPlates;
                case 98:
                    return SectionGroup.EcCompoundSteelSectionsRolledISectionsWithTopPlate;
                case 99:
                    return SectionGroup.EcCompoundSteelSectionsRolledSteelJoistsInStarArrangement;
                case 100:
                    return SectionGroup.EcCompoundSteelSectionsRolledSteelJoistsWithPlates;
                case 101:
                    return SectionGroup.EcCompoundSteelSectionsRolledSteelJoistsWithPlatesInStarArrangement;
                case 102:
                    return SectionGroup.EuropeanSteelSectionsDeltabeamDrSeries;
                case 103:
                    return SectionGroup.EuropeanSteelSectionsDeltabeamDSeries;
                case 104:
                    return SectionGroup.EuropeanSteelSectionsEuropean2EqualAnglesBackToBack;
                case 105:
                    return SectionGroup.EuropeanSteelSectionsEuropean2UnequalAnglesLongLegBackToBack;
                case 106:
                    return SectionGroup.EuropeanSteelSectionsEuropean2UnequalAnglesShortLegBackToBack;
                case 107:
                    return SectionGroup.EuropeanSteelSectionsEuropeanCircularHollowSections;
                case 108:
                    return SectionGroup.EuropeanSteelSectionsEuropeanEqualAngles;
                case 109:
                    return SectionGroup.EuropeanSteelSectionsEuropeanParallelFlangeChannels;
                case 110:
                    return SectionGroup.EuropeanSteelSectionsEuropeanRectangularHollowSections;
                case 111:
                    return SectionGroup.EuropeanSteelSectionsEuropeanSquareHollowSections;
                case 112:
                    return SectionGroup.EuropeanSteelSectionsEuropeanStandardBeams;
                case 113:
                    return SectionGroup.EuropeanSteelSectionsEuropeanStandardChannels;
                case 114:
                    return SectionGroup.EuropeanSteelSectionsEuropeanUnequalAngles;
                case 115:
                    return SectionGroup.EuropeanSteelSectionsFabsecPlatedBeams;
                case 116:
                    return SectionGroup.EuropeanSteelSectionsParallelFacedFlangeBeams;
                case 117:
                    return SectionGroup.EuropeanSteelSectionsPlatedBeams;
                case 118:
                    return SectionGroup.EuropeanSteelSectionsPlatedColumns;
                case 119:
                    return SectionGroup.EuropeanSteelSectionsWestokCellularBeams;
                case 120:
                    return SectionGroup.EuropeanSteelSectionsWestokPlatedBeams;
                case 121:
                    return SectionGroup.EuropeanSteelSectionsWideFlangedColumns;
                case 122:
                    return SectionGroup.EuropeanSteelSectionsWideVeryWideFlangedBeams;
                case 123:
                    return SectionGroup.HyundaiSteelSectionsHyundaiAstmChannelsUsSections;
                case 124:
                    return SectionGroup.HyundaiSteelSectionsHyundaiAstmHpUsSections;
                case 125:
                    return SectionGroup.HyundaiSteelSectionsHyundaiAstmUsSections;
                case 126:
                    return SectionGroup.HyundaiSteelSectionsHyundaiChannelsEuropeanSections;
                case 127:
                    return SectionGroup.HyundaiSteelSectionsHyundaiChannelsKoreanAndJapaneseSections;
                case 128:
                    return SectionGroup.HyundaiSteelSectionsHyundaiEqualAnglesEuropeanSections;
                case 129:
                    return SectionGroup.HyundaiSteelSectionsHyundaiEqualAnglesKoreanAndJapaneseSections;
                case 130:
                    return SectionGroup.HyundaiSteelSectionsHyundaiHdEuropeanSections;
                case 131:
                    return SectionGroup.HyundaiSteelSectionsHyundaiHeEuropeanSections;
                case 132:
                    return SectionGroup.HyundaiSteelSectionsHyundaiHpEuropeanSections;
                case 133:
                    return SectionGroup.HyundaiSteelSectionsHyundaiHpKoreanSections;
                case 134:
                    return SectionGroup.HyundaiSteelSectionsHyundaiIpeEuropeanSections;
                case 135:
                    return SectionGroup.HyundaiSteelSectionsHyundaiIBeamsKoreanSections;
                case 136:
                    return SectionGroup.HyundaiSteelSectionsHyundaiJuniorBeamsKoreanSections;
                case 137:
                    return SectionGroup.HyundaiSteelSectionsHyundaiMJapanese9408Sections;
                case 138:
                    return SectionGroup.HyundaiSteelSectionsHyundaiMKoreanJapanese90Sections;
                case 139:
                    return SectionGroup.HyundaiSteelSectionsHyundaiParallelFlangeChannelsKoreanBsAndAsNzsSections;
                case 140:
                    return SectionGroup.HyundaiSteelSectionsHyundaiUbpBsSections;
                case 141:
                    return SectionGroup.HyundaiSteelSectionsHyundaiUbAsNzsSections;
                case 142:
                    return SectionGroup.HyundaiSteelSectionsHyundaiUbBsSections;
                case 143:
                    return SectionGroup.HyundaiSteelSectionsHyundaiUcAsNzsSections;
                case 144:
                    return SectionGroup.HyundaiSteelSectionsHyundaiUcBsSections;
                case 145:
                    return SectionGroup.HyundaiSteelSectionsHyundaiUnequalAnglesKoreanAndJapaneseSections;
                case 146:
                    return SectionGroup.InCompoundSteelSectionsDoubleRolledISections;
                case 147:
                    return SectionGroup.InCompoundSteelSectionsDoubleRolledISectionsWithPlates;
                case 148:
                    return SectionGroup.InCompoundSteelSectionsRolledAnglesInStarArrangement;
                case 149:
                    return SectionGroup.InCompoundSteelSectionsRolledChannelsBackToBack;
                case 150:
                    return SectionGroup.InCompoundSteelSectionsRolledChannelsBackToBackWithPlates;
                case 151:
                    return SectionGroup.InCompoundSteelSectionsRolledChannelsToeToToe;
                case 152:
                    return SectionGroup.InCompoundSteelSectionsRolledChannelsToeToToeWithHorizontalPlates;
                case 153:
                    return SectionGroup.InCompoundSteelSectionsRolledChannelsToeToToeWithVerticalPlates;
                case 154:
                    return SectionGroup.InCompoundSteelSectionsRolledISectionsWithBottomPlate;
                case 155:
                    return SectionGroup.InCompoundSteelSectionsRolledISectionsWithPlates;
                case 156:
                    return SectionGroup.InCompoundSteelSectionsRolledISectionsWithTopPlate;
                case 157:
                    return SectionGroup.InCompoundSteelSectionsRolledSteelJoistsInStarArrangement;
                case 158:
                    return SectionGroup.InCompoundSteelSectionsRolledSteelJoistsWithPlatesInStarArrangement;
                case 159:
                    return SectionGroup.IndianStructuralSections2EqualAnglesBackToBack;
                case 160:
                    return SectionGroup.IndianStructuralSections2UnequalAnglesLongLegBackToBack;
                case 161:
                    return SectionGroup.IndianStructuralSections2UnequalAnglesShortLegBackToBack;
                case 162:
                    return SectionGroup.IndianStructuralSectionsCircularHollowSections;
                case 163:
                    return SectionGroup.IndianStructuralSectionsEqualAngles;
                case 164:
                    return SectionGroup.IndianStructuralSectionsIscBackToBack;
                case 165:
                    return SectionGroup.IndianStructuralSectionsIscFaceToFace;
                case 166:
                    return SectionGroup.IndianStructuralSectionsIshbSections;
                case 167:
                    return SectionGroup.IndianStructuralSectionsIsjbSections;
                case 168:
                    return SectionGroup.IndianStructuralSectionsIsjcSections;
                case 169:
                    return SectionGroup.IndianStructuralSectionsIslbSections;
                case 170:
                    return SectionGroup.IndianStructuralSectionsIslcSections;
                case 171:
                    return SectionGroup.IndianStructuralSectionsIsmbSections;
                case 172:
                    return SectionGroup.IndianStructuralSectionsIsmbAndIswbSectionsWithTopAndBottomFlangePlates;
                case 173:
                    return SectionGroup.IndianStructuralSectionsIsmcpParallel;
                case 174:
                    return SectionGroup.IndianStructuralSectionsIsmcSections;
                case 175:
                    return SectionGroup.IndianStructuralSectionsIsscSections;
                case 176:
                    return SectionGroup.IndianStructuralSectionsIsTeeBar;
                case 177:
                    return SectionGroup.IndianStructuralSectionsIswbSections;
                case 178:
                    return SectionGroup.IndianStructuralSectionsPlatedBeams;
                case 179:
                    return SectionGroup.IndianStructuralSectionsPlatedColumns;
                case 180:
                    return SectionGroup.IndianStructuralSectionsRectangularHollowSections;
                case 181:
                    return SectionGroup.IndianStructuralSectionsSquareHollowSections;
                case 182:
                    return SectionGroup.IndianStructuralSectionsUnequalAngles;
                case 183:
                    return SectionGroup.IndianStructuralSectionsWestokCellularBeams;
                case 184:
                    return SectionGroup.JapaneseSteelSectionsCircularHollowSections;
                case 185:
                    return SectionGroup.JapaneseSteelSectionsEqualAngles;
                case 186:
                    return SectionGroup.JapaneseSteelSectionsPlatedBeams;
                case 187:
                    return SectionGroup.JapaneseSteelSectionsPlatedColumns;
                case 188:
                    return SectionGroup.JapaneseSteelSectionsRectangularHollowSections;
                case 189:
                    return SectionGroup.JapaneseSteelSectionsRolledSteelChannels;
                case 190:
                    return SectionGroup.JapaneseSteelSectionsRolledSteelJoists;
                case 191:
                    return SectionGroup.JapaneseSteelSectionsSquareHollowSections;
                case 192:
                    return SectionGroup.JapaneseSteelSectionsUnequalAngles;
                case 193:
                    return SectionGroup.JapaneseSteelSectionsUniversalBeams;
                case 194:
                    return SectionGroup.JapaneseSteelSectionsUniversalColumns;
                case 195:
                    return SectionGroup.JapaneseSteelSectionsWestokCellularBeams;
                case 196:
                    return SectionGroup.KoreanSteelSectionsKoreanChannelSections;
                case 197:
                    return SectionGroup.KoreanSteelSectionsKoreanCircularHollowSections;
                case 198:
                    return SectionGroup.KoreanSteelSectionsKoreanEqualAngles;
                case 199:
                    return SectionGroup.KoreanSteelSectionsKoreanHSections;
                case 200:
                    return SectionGroup.KoreanSteelSectionsKoreanISections;
                case 201:
                    return SectionGroup.KoreanSteelSectionsKoreanLhSections;
                case 202:
                    return SectionGroup.KoreanSteelSectionsKoreanSquareAndRectangularHollowSections;
                case 203:
                    return SectionGroup.KoreanSteelSectionsKoreanTSections;
                case 204:
                    return SectionGroup.KoreanSteelSectionsKoreanUnequalAngles;
                case 205:
                    return SectionGroup.NipponAndSumitomoSteelSectionsNipponAstmUsSections;
                case 206:
                    return SectionGroup.NipponAndSumitomoSteelSectionsNipponHc400Nstwh;
                case 207:
                    return SectionGroup.NipponAndSumitomoSteelSectionsNipponHeEuropeanSections;
                case 208:
                    return SectionGroup.NipponAndSumitomoSteelSectionsNipponIpeEuropeanSections;
                case 209:
                    return SectionGroup.NipponAndSumitomoSteelSectionsNipponKsKoreanSections;
                case 210:
                    return SectionGroup.NipponAndSumitomoSteelSectionsNipponNsHyperBeam;
                case 211:
                    return SectionGroup.NipponAndSumitomoSteelSectionsNipponUbAsNzsSections;
                case 212:
                    return SectionGroup.NipponAndSumitomoSteelSectionsNipponUbBsSections;
                case 213:
                    return SectionGroup.NipponAndSumitomoSteelSectionsNipponUbJisSections;
                case 214:
                    return SectionGroup.NipponAndSumitomoSteelSectionsNipponUcAsNzsSections;
                case 215:
                    return SectionGroup.NipponAndSumitomoSteelSectionsNipponUcBsSections;
                case 216:
                    return SectionGroup.NipponAndSumitomoSteelSectionsNipponUcJisSections;
                case 217:
                    return SectionGroup.NonUsGlulamAndSclTimberSectionsGlulam;
                case 218:
                    return SectionGroup.NonUsGlulamAndSclTimberSectionsKertoSLvl;
                case 219:
                    return SectionGroup.NonUsGlulamAndSclTimberSectionsParallamPsl20E;
                case 220:
                    return SectionGroup.NonUsGlulamAndSclTimberSectionsTimberStrandLsl13E;
                case 221:
                    return SectionGroup.NonUsGlulamAndSclTimberSectionsTimberStrandLsl15E;
                case 222:
                    return SectionGroup.NonUsGlulamAndSclTimberSectionsVersaLamLvl;
                case 223:
                    return SectionGroup.NordicColdFormedSectionsColdFormedChs;
                case 224:
                    return SectionGroup.NordicColdFormedSectionsColdFormedRhs;
                case 225:
                    return SectionGroup.NordicColdFormedSectionsColdFormedShs;
                case 226:
                    return SectionGroup.PerwajaSteelSectionsASectionsPerwaja;
                case 227:
                    return SectionGroup.PerwajaSteelSectionsBarsContinental;
                case 228:
                    return SectionGroup.PerwajaSteelSectionsCSectionsPerwaja;
                case 229:
                    return SectionGroup.PerwajaSteelSectionsCircularHollowSectionsContinental;
                case 230:
                    return SectionGroup.PerwajaSteelSectionsEqualAnglesContinental;
                case 231:
                    return SectionGroup.PerwajaSteelSectionsFlatBarsContinental;
                case 232:
                    return SectionGroup.PerwajaSteelSectionsHSectionsPerwaja;
                case 233:
                    return SectionGroup.PerwajaSteelSectionsISectionsPerwaja;
                case 234:
                    return SectionGroup.PerwajaSteelSectionsPlatedBeams;
                case 235:
                    return SectionGroup.PerwajaSteelSectionsPlatedColumns;
                case 236:
                    return SectionGroup.PerwajaSteelSectionsRectangularHollowSectionsContinental;
                case 237:
                    return SectionGroup.PerwajaSteelSectionsRodsContinental;
                case 238:
                    return SectionGroup.PerwajaSteelSectionsRolledSteelChannelsContinental;
                case 239:
                    return SectionGroup.PerwajaSteelSectionsRolledSteelChannelsParallelContinental;
                case 240:
                    return SectionGroup.PerwajaSteelSectionsSquareHollowSectionsContinental;
                case 241:
                    return SectionGroup.PerwajaSteelSectionsStructuralTeeFromImperialUbContinental;
                case 242:
                    return SectionGroup.PerwajaSteelSectionsStructuralTeeFromImperialUcContinental;
                case 243:
                    return SectionGroup.PerwajaSteelSectionsStructuralTeeFromMetricUbContinental;
                case 244:
                    return SectionGroup.PerwajaSteelSectionsStructuralTeeFromMetricUcContinental;
                case 245:
                    return SectionGroup.PerwajaSteelSectionsUbSectionsContinental;
                case 246:
                    return SectionGroup.PerwajaSteelSectionsUcSectionsContinental;
                case 247:
                    return SectionGroup.PerwajaSteelSectionsUnequalAnglesContinental;
                case 248:
                    return SectionGroup.PerwajaSteelSectionsWestokCellularBeams;
                case 249:
                    return SectionGroup.SailIndiaStructuralSectionsEqualAnglesSail;
                case 250:
                    return SectionGroup.SailIndiaStructuralSectionsEuropeanChannelsSail;
                case 251:
                    return SectionGroup.SailIndiaStructuralSectionsMediumBeamsSail;
                case 252:
                    return SectionGroup.SailIndiaStructuralSectionsMediumChannelsSail;
                case 253:
                    return SectionGroup.SailIndiaStructuralSectionsNarrowFlangeParallelBeamsSail;
                case 254:
                    return SectionGroup.SailIndiaStructuralSectionsWBeamsSail;
                case 255:
                    return SectionGroup.SailIndiaStructuralSectionsWideFlangeParallelBeamsSail;
                case 256:
                    return SectionGroup.SouthAfricanSteelSections2EqualAnglesBackToBack;
                case 257:
                    return SectionGroup.SouthAfricanSteelSections2UnequalAnglesLongLegBackToBack;
                case 258:
                    return SectionGroup.SouthAfricanSteelSections2UnequalAnglesShortLegBackToBack;
                case 259:
                    return SectionGroup.SouthAfricanSteelSectionsChannelsParallelFlange;
                case 260:
                    return SectionGroup.SouthAfricanSteelSectionsChannelsTaperFlange;
                case 261:
                    return SectionGroup.SouthAfricanSteelSectionsCircularHollowSections;
                case 262:
                    return SectionGroup.SouthAfricanSteelSectionsEqualAngles;
                case 263:
                    return SectionGroup.SouthAfricanSteelSectionsParallelFlangeBeams;
                case 264:
                    return SectionGroup.SouthAfricanSteelSectionsPlatedBeams;
                case 265:
                    return SectionGroup.SouthAfricanSteelSectionsPlatedColumns;
                case 266:
                    return SectionGroup.SouthAfricanSteelSectionsRectangularHollowSections;
                case 267:
                    return SectionGroup.SouthAfricanSteelSectionsSquareHollowSections;
                case 268:
                    return SectionGroup.SouthAfricanSteelSectionsUnequalAngles;
                case 269:
                    return SectionGroup.SouthAfricanSteelSectionsUniversalBeams;
                case 270:
                    return SectionGroup.SouthAfricanSteelSectionsUniversalColumns;
                case 271:
                    return SectionGroup.SouthAfricanSteelSectionsWestokCellularBeams;
                case 272:
                    return SectionGroup.SpanishColdRolledSectionsBrausaSigmaSections;
                case 273:
                    return SectionGroup.SpanishColdRolledSectionsCorreasAchcSections;
                case 274:
                    return SectionGroup.SpanishColdRolledSectionsCorreasAchzSections;
                case 275:
                    return SectionGroup.SteelJoistsDlhSeriesJoists;
                case 276:
                    return SectionGroup.SteelJoistsKcsSeriesJoists;
                case 277:
                    return SectionGroup.SteelJoistsKSeriesJoistsAngle;
                case 278:
                    return SectionGroup.SteelJoistsKSeriesJoistsRod;
                case 279:
                    return SectionGroup.SteelJoistsLhSeriesJoists;
                case 280:
                    return SectionGroup.SteelJoistsSiDlhSeriesJoists;
                case 281:
                    return SectionGroup.SteelJoistsSiKcsSeriesJoists;
                case 282:
                    return SectionGroup.SteelJoistsSiKSeriesJoistsAngle;
                case 283:
                    return SectionGroup.SteelJoistsSiKSeriesJoistsRod;
                case 284:
                    return SectionGroup.SteelJoistsSiLhSeriesJoists;
                case 285:
                    return SectionGroup.TaiwanSteelSectionsBhSections;
                case 286:
                    return SectionGroup.TaiwanSteelSectionsChannels;
                case 287:
                    return SectionGroup.TaiwanSteelSectionsDlEqualLegged;
                case 288:
                    return SectionGroup.TaiwanSteelSectionsDlUnequalLeggedLongSideConnected;
                case 289:
                    return SectionGroup.TaiwanSteelSectionsDlUnequalLeggedShortSideConnected;
                case 290:
                    return SectionGroup.TaiwanSteelSectionsEqualLegged;
                case 291:
                    return SectionGroup.TaiwanSteelSectionsISections;
                case 292:
                    return SectionGroup.TaiwanSteelSectionsParallelFlangedChannels;
                case 293:
                    return SectionGroup.TaiwanSteelSectionsPipeCircular;
                case 294:
                    return SectionGroup.TaiwanSteelSectionsRhSections;
                case 295:
                    return SectionGroup.TaiwanSteelSectionsStructuralTees;
                case 296:
                    return SectionGroup.TaiwanSteelSectionsTubeRectangular;
                case 297:
                    return SectionGroup.TaiwanSteelSectionsTubeSquare;
                case 298:
                    return SectionGroup.TaiwanSteelSectionsUnequalLegged;
                case 299:
                    return SectionGroup.ThailandSteelSectionsCellularBeams;
                case 300:
                    return SectionGroup.ThailandSteelSectionsChannels;
                case 301:
                    return SectionGroup.ThailandSteelSectionsEqualAngles;
                case 302:
                    return SectionGroup.ThailandSteelSectionsHSections;
                case 303:
                    return SectionGroup.ThailandSteelSectionsISections;
                case 304:
                    return SectionGroup.ThailandSteelSectionsPipeSections;
                case 305:
                    return SectionGroup.ThailandSteelSectionsRectangularTubes;
                case 306:
                    return SectionGroup.ThailandSteelSectionsSquareTubes;
                case 307:
                    return SectionGroup.UkColdFormedSectionsColdFormedChs;
                case 308:
                    return SectionGroup.UkColdFormedSectionsColdFormedRhs;
                case 309:
                    return SectionGroup.UkColdFormedSectionsColdFormedShs;
                case 310:
                    return SectionGroup.UkColdFormedSectionsHybox355Chs;
                case 311:
                    return SectionGroup.UkColdFormedSectionsHybox355Rhs;
                case 312:
                    return SectionGroup.UkColdFormedSectionsHybox355Shs;
                case 313:
                    return SectionGroup.UkColdFormedSectionsStrongbox235Chs;
                case 314:
                    return SectionGroup.UkColdFormedSectionsStrongbox235Rhs;
                case 315:
                    return SectionGroup.UkColdFormedSectionsStrongbox235Shs;
                case 316:
                    return SectionGroup.UkColdRolledSectionsAlbionCSections;
                case 317:
                    return SectionGroup.UkColdRolledSectionsAlbionEavesBeams;
                case 318:
                    return SectionGroup.UkColdRolledSectionsAlbionSigmaSections;
                case 319:
                    return SectionGroup.UkColdRolledSectionsAlbionZSections;
                case 320:
                    return SectionGroup.UkColdRolledSectionsAyrshireCSections;
                case 321:
                    return SectionGroup.UkColdRolledSectionsAyrshireEavesBeams;
                case 322:
                    return SectionGroup.UkColdRolledSectionsAyrshireSteelFramingCSections;
                case 323:
                    return SectionGroup.UkColdRolledSectionsAyrshireSwageBeam;
                case 324:
                    return SectionGroup.UkColdRolledSectionsAyrshireZSections;
                case 325:
                    return SectionGroup.UkColdRolledSectionsAyrshireZeta2Sections;
                case 326:
                    return SectionGroup.UkColdRolledSectionsAyrshireZetaSections;
                case 327:
                    return SectionGroup.UkColdRolledSectionsHiSpanCSections;
                case 328:
                    return SectionGroup.UkColdRolledSectionsHiSpanEavesBeams;
                case 329:
                    return SectionGroup.UkColdRolledSectionsHiSpanZSections;
                case 330:
                    return SectionGroup.UkColdRolledSectionsKingspanEavesBeams;
                case 331:
                    return SectionGroup.UkColdRolledSectionsKingspanMultiBeamSections;
                case 332:
                    return SectionGroup.UkColdRolledSectionsKingspanMultiChannelSections;
                case 333:
                    return SectionGroup.UkColdRolledSectionsMetsecCSections;
                case 334:
                    return SectionGroup.UkColdRolledSectionsMetsecEavesBeams;
                case 335:
                    return SectionGroup.UkColdRolledSectionsMetsecZSections;
                case 336:
                    return SectionGroup.UkColdRolledSectionsSteadmansCSections;
                case 337:
                    return SectionGroup.UkColdRolledSectionsSteadmansEavesBeams;
                case 338:
                    return SectionGroup.UkColdRolledSectionsSteadmansZSections;
                case 339:
                    return SectionGroup.UkColdRolledSectionsStructuralSectionsEavesBeams;
                case 340:
                    return SectionGroup.UkColdRolledSectionsStructuralSectionsUltraBeamSections;
                case 341:
                    return SectionGroup.UkColdRolledSectionsStructuralSectionsUltraZedSections;
                case 342:
                    return SectionGroup.UkColdRolledSectionsTegralCSections;
                case 343:
                    return SectionGroup.UkColdRolledSectionsTegralEavesBeams;
                case 344:
                    return SectionGroup.UkColdRolledSectionsTegralZSections;
                case 345:
                    return SectionGroup.UkColdRolledSectionsTegralZeta2Sections;
                case 346:
                    return SectionGroup.UkColdRolledSectionsTegralZetaSections;
                case 347:
                    return SectionGroup.UkCompoundSteelSectionsDoubleRolledISections;
                case 348:
                    return SectionGroup.UkCompoundSteelSectionsDoubleRolledISectionsWithPlates;
                case 349:
                    return SectionGroup.UkCompoundSteelSectionsRolledAnglesInStarArrangement;
                case 350:
                    return SectionGroup.UkCompoundSteelSectionsRolledChannelsBackToBack;
                case 351:
                    return SectionGroup.UkCompoundSteelSectionsRolledChannelsBackToBackWithPlates;
                case 352:
                    return SectionGroup.UkCompoundSteelSectionsRolledChannelsToeToToe;
                case 353:
                    return SectionGroup.UkCompoundSteelSectionsRolledChannelsToeToToeWithHorizontalPlates;
                case 354:
                    return SectionGroup.UkCompoundSteelSectionsRolledChannelsToeToToeWithVerticalPlates;
                case 355:
                    return SectionGroup.UkCompoundSteelSectionsRolledISectionsWithBottomPlate;
                case 356:
                    return SectionGroup.UkCompoundSteelSectionsRolledISectionsWithPlates;
                case 357:
                    return SectionGroup.UkCompoundSteelSectionsRolledISectionsWithTopPlate;
                case 358:
                    return SectionGroup.UkCompoundSteelSectionsRolledSteelJoistsInStarArrangement;
                case 359:
                    return SectionGroup.UkCompoundSteelSectionsRolledSteelJoistsWithPlates;
                case 360:
                    return SectionGroup.UkCompoundSteelSectionsRolledSteelJoistsWithPlatesInStarArrangement;
                case 361:
                    return SectionGroup.UkSteelSections2EqualAnglesBackToBack;
                case 362:
                    return SectionGroup.UkSteelSections2UnequalAnglesLongLegBackToBack;
                case 363:
                    return SectionGroup.UkSteelSections2UnequalAnglesShortLegBackToBack;
                case 364:
                    return SectionGroup.UkSteelSectionsAdvanceUkb;
                case 365:
                    return SectionGroup.UkSteelSectionsAdvanceUkc;
                case 366:
                    return SectionGroup.UkSteelSectionsAdvanceUkpfc;
                case 367:
                    return SectionGroup.UkSteelSectionsAsymmetricBeams;
                case 368:
                    return SectionGroup.UkSteelSectionsCircularHollowSections;
                case 369:
                    return SectionGroup.UkSteelSectionsEqualAngles;
                case 370:
                    return SectionGroup.UkSteelSectionsFabsecPlatedBeams;
                case 371:
                    return SectionGroup.UkSteelSectionsFlatBars;
                case 372:
                    return SectionGroup.UkSteelSectionsPlatedBeams;
                case 373:
                    return SectionGroup.UkSteelSectionsPlatedColumns;
                case 374:
                    return SectionGroup.UkSteelSectionsRectangularHollowSections;
                case 375:
                    return SectionGroup.UkSteelSectionsRolledSteelChannels;
                case 376:
                    return SectionGroup.UkSteelSectionsRolledSteelChannelsParallel;
                case 377:
                    return SectionGroup.UkSteelSectionsRolledSteelJoists;
                case 378:
                    return SectionGroup.UkSteelSectionsSlimflorFabricatedBeams;
                case 379:
                    return SectionGroup.UkSteelSectionsSquareHollowSections;
                case 380:
                    return SectionGroup.UkSteelSectionsStructuralTeeFromUb;
                case 381:
                    return SectionGroup.UkSteelSectionsStructuralTeeFromUc;
                case 382:
                    return SectionGroup.UkSteelSectionsUnequalAngles;
                case 383:
                    return SectionGroup.UkSteelSectionsUniversalBeams;
                case 384:
                    return SectionGroup.UkSteelSectionsUniversalColumns;
                case 385:
                    return SectionGroup.UkSteelSectionsWestokCellularBeams;
                case 386:
                    return SectionGroup.UkSteelSectionsWestokPlatedBeams;
                case 387:
                    return SectionGroup.UkTimberSectionsPlanedAllRoundSoftwood;
                case 388:
                    return SectionGroup.UkTimberSectionsRegularisedSoftwood;
                case 389:
                    return SectionGroup.UkTimberSectionsSawnHardwood;
                case 390:
                    return SectionGroup.UkTimberSectionsSawnSoftwood;
                case 391:
                    return SectionGroup.UkTimberSectionsSurfacedHardwood;
                case 392:
                    return SectionGroup.UkTimberSectionsSurfacedSoftwood;
                case 393:
                    return SectionGroup.UsColdRolledSectionsUsS33Ksi;
                case 394:
                    return SectionGroup.UsColdRolledSectionsUsS50Ksi;
                case 395:
                    return SectionGroup.UsColdRolledSectionsUsT33Ksi;
                case 396:
                    return SectionGroup.UsColdRolledSectionsUsT50Ksi;
                case 397:
                    return SectionGroup.UsCompoundSteelSectionsSiDoubleRolledISections;
                case 398:
                    return SectionGroup.UsCompoundSteelSectionsSiDoubleRolledISectionsWithPlates;
                case 399:
                    return SectionGroup.UsCompoundSteelSectionsSiRolledAnglesInStarArrangement;
                case 400:
                    return SectionGroup.UsCompoundSteelSectionsSiRolledChannelsBackToBack;
                case 401:
                    return SectionGroup.UsCompoundSteelSectionsSiRolledChannelsBackToBackWithPlates;
                case 402:
                    return SectionGroup.UsCompoundSteelSectionsSiRolledChannelsToeToToe;
                case 403:
                    return SectionGroup.UsCompoundSteelSectionsSiRolledChannelsToeToToeWithHorizontalPlates;
                case 404:
                    return SectionGroup.UsCompoundSteelSectionsSiRolledChannelsToeToToeWithVerticalPlates;
                case 405:
                    return SectionGroup.UsCompoundSteelSectionsSiRolledISectionsWithBottomPlate;
                case 406:
                    return SectionGroup.UsCompoundSteelSectionsSiRolledISectionsWithPlates;
                case 407:
                    return SectionGroup.UsCompoundSteelSectionsSiRolledISectionsWithTopPlate;
                case 408:
                    return SectionGroup.UsCompoundSteelSectionsSiRolledSteelJoistsInStarArrangement;
                case 409:
                    return SectionGroup.UsCompoundSteelSectionsSiRolledSteelJoistsWithPlates;
                case 410:
                    return SectionGroup.UsCompoundSteelSectionsSiRolledSteelJoistsWithPlatesInStarArrangement;
                case 411:
                    return SectionGroup.UsCompoundSteelSectionsUsDoubleRolledISections;
                case 412:
                    return SectionGroup.UsCompoundSteelSectionsUsDoubleRolledISectionsWithPlates;
                case 413:
                    return SectionGroup.UsCompoundSteelSectionsUsRolledAnglesInStarArrangement;
                case 414:
                    return SectionGroup.UsCompoundSteelSectionsUsRolledChannelsBackToBack;
                case 415:
                    return SectionGroup.UsCompoundSteelSectionsUsRolledChannelsBackToBackWithPlates;
                case 416:
                    return SectionGroup.UsCompoundSteelSectionsUsRolledChannelsToeToToe;
                case 417:
                    return SectionGroup.UsCompoundSteelSectionsUsRolledChannelsToeToToeWithHorizontalPlates;
                case 418:
                    return SectionGroup.UsCompoundSteelSectionsUsRolledChannelsToeToToeWithVerticalPlates;
                case 419:
                    return SectionGroup.UsCompoundSteelSectionsUsRolledISectionsWithBottomPlate;
                case 420:
                    return SectionGroup.UsCompoundSteelSectionsUsRolledISectionsWithPlates;
                case 421:
                    return SectionGroup.UsCompoundSteelSectionsUsRolledISectionsWithTopPlate;
                case 422:
                    return SectionGroup.UsCompoundSteelSectionsUsRolledSteelJoistsInStarArrangement;
                case 423:
                    return SectionGroup.UsCompoundSteelSectionsUsRolledSteelJoistsWithPlates;
                case 424:
                    return SectionGroup.UsCompoundSteelSectionsUsRolledSteelJoistsWithPlatesInStarArrangement;
                case 425:
                    return SectionGroup.UsSclTimberSectionsSiMicrollamLvl20E;
                case 426:
                    return SectionGroup.UsSclTimberSectionsSiParallamPsl18E;
                case 427:
                    return SectionGroup.UsSclTimberSectionsSiParallamPsl20E;
                case 428:
                    return SectionGroup.UsSclTimberSectionsSiTimberStrandLsl13E;
                case 429:
                    return SectionGroup.UsSclTimberSectionsSiTimberStrandLsl155E;
                case 430:
                    return SectionGroup.UsSclTimberSectionsSiWestFraserLvl17E;
                case 431:
                    return SectionGroup.UsSclTimberSectionsSiWestFraserLvl18E;
                case 432:
                    return SectionGroup.UsSclTimberSectionsSiWestFraserLvl19E;
                case 433:
                    return SectionGroup.UsSclTimberSectionsSiWestFraserLvl20E;
                case 434:
                    return SectionGroup.UsSclTimberSectionsUsMicrollamLvl20E;
                case 435:
                    return SectionGroup.UsSclTimberSectionsUsParallamPsl18E;
                case 436:
                    return SectionGroup.UsSclTimberSectionsUsParallamPsl20E;
                case 437:
                    return SectionGroup.UsSclTimberSectionsUsTimberStrandLsl13E;
                case 438:
                    return SectionGroup.UsSclTimberSectionsUsTimberStrandLsl155E;
                case 439:
                    return SectionGroup.UsSclTimberSectionsUsWestFraserLvl17E;
                case 440:
                    return SectionGroup.UsSclTimberSectionsUsWestFraserLvl18E;
                case 441:
                    return SectionGroup.UsSclTimberSectionsUsWestFraserLvl19E;
                case 442:
                    return SectionGroup.UsSclTimberSectionsUsWestFraserLvl20E;
                case 443:
                    return SectionGroup.UsSteelSectionsSiAngles;
                case 444:
                    return SectionGroup.UsSteelSectionsSiBars;
                case 445:
                    return SectionGroup.UsSteelSectionsSiChannels;
                case 446:
                    return SectionGroup.UsSteelSectionsSiDoubleAnglesEqual;
                case 447:
                    return SectionGroup.UsSteelSectionsSiDoubleAnglesLongLegBackToBack;
                case 448:
                    return SectionGroup.UsSteelSectionsSiDoubleAnglesShortLegBackToBack;
                case 449:
                    return SectionGroup.UsSteelSectionsSiFlats;
                case 450:
                    return SectionGroup.UsSteelSectionsSiHp;
                case 451:
                    return SectionGroup.UsSteelSectionsSiMiscChannels;
                case 452:
                    return SectionGroup.UsSteelSectionsSiPipes;
                case 453:
                    return SectionGroup.UsSteelSectionsSiPlatedBeams;
                case 454:
                    return SectionGroup.UsSteelSectionsSiPlatedColumns;
                case 455:
                    return SectionGroup.UsSteelSectionsSiRectangularHss;
                case 456:
                    return SectionGroup.UsSteelSectionsSiRods;
                case 457:
                    return SectionGroup.UsSteelSectionsSiRoundHss;
                case 458:
                    return SectionGroup.UsSteelSectionsSiS;
                case 459:
                    return SectionGroup.UsSteelSectionsSiSquareHss;
                case 460:
                    return SectionGroup.UsSteelSectionsSiWtMtSt;
                case 461:
                    return SectionGroup.UsSteelSectionsSiWAndM;
                case 462:
                    return SectionGroup.UsSteelSectionsSiWestokCellularBeams;
                case 463:
                    return SectionGroup.UsSteelSectionsUsAngles;
                case 464:
                    return SectionGroup.UsSteelSectionsUsBars;
                case 465:
                    return SectionGroup.UsSteelSectionsUsChannels;
                case 466:
                    return SectionGroup.UsSteelSectionsUsDoubleAnglesEqual;
                case 467:
                    return SectionGroup.UsSteelSectionsUsDoubleAnglesLongLegBackToBack;
                case 468:
                    return SectionGroup.UsSteelSectionsUsDoubleAnglesShortLegBackToBack;
                case 469:
                    return SectionGroup.UsSteelSectionsUsFlats;
                case 470:
                    return SectionGroup.UsSteelSectionsUsHp;
                case 471:
                    return SectionGroup.UsSteelSectionsUsMiscChannels;
                case 472:
                    return SectionGroup.UsSteelSectionsUsPipes;
                case 473:
                    return SectionGroup.UsSteelSectionsUsPlatedBeams;
                case 474:
                    return SectionGroup.UsSteelSectionsUsPlatedColumns;
                case 475:
                    return SectionGroup.UsSteelSectionsUsRectangularHss;
                case 476:
                    return SectionGroup.UsSteelSectionsUsRectangularHssA1085;
                case 477:
                    return SectionGroup.UsSteelSectionsUsRods;
                case 478:
                    return SectionGroup.UsSteelSectionsUsRoundHss;
                case 479:
                    return SectionGroup.UsSteelSectionsUsRoundHssA1085;
                case 480:
                    return SectionGroup.UsSteelSectionsUsS;
                case 481:
                    return SectionGroup.UsSteelSectionsUsSquareHss;
                case 482:
                    return SectionGroup.UsSteelSectionsUsSquareHssA1085;
                case 483:
                    return SectionGroup.UsSteelSectionsUsWtMtSt;
                case 484:
                    return SectionGroup.UsSteelSectionsUsWAndM;
                case 485:
                    return SectionGroup.UsSteelSectionsUsWestokCellularBeams;
                case 486:
                    return SectionGroup.UsTimberSectionsSiSouthernPineGluedLaminatedTimber;
                case 487:
                    return SectionGroup.UsTimberSectionsSiStandardDressedSawnLumber;
                case 488:
                    return SectionGroup.UsTimberSectionsSiWesternSpeciesGluedLaminatedTimber;
                case 489:
                    return SectionGroup.UsTimberSectionsUsSouthernPineGluedLaminatedTimber;
                case 490:
                    return SectionGroup.UsTimberSectionsUsStandardDressedSawnLumber;
                case 491:
                    return SectionGroup.UsTimberSectionsUsWesternSpeciesGluedLaminatedTimber;
                case 492:
                    return SectionGroup.WorldwideCompoundSteelSectionsSiBoxWithPlates;
                case 493:
                    return SectionGroup.WorldwideCompoundSteelSectionsSiPlatedISectionsWithPlates;
                case 494:
                    return SectionGroup.WorldwideCompoundSteelSectionsSiStarSectionsWithPlates;
                case 495:
                    return SectionGroup.WorldwideCompoundSteelSectionsSiWeldedSectionsWithPlates;
                case 496:
                    return SectionGroup.WorldwideCompoundSteelSectionsUsBoxWithPlates;
                case 497:
                    return SectionGroup.WorldwideCompoundSteelSectionsUsPlatedISectionsWithPlates;
                case 498:
                    return SectionGroup.WorldwideCompoundSteelSectionsUsStarSectionsWithPlates;
                case 499:
                    return SectionGroup.WorldwideCompoundSteelSectionsUsWeldedSectionsWithPlates;
                default:
                    return SectionGroup.Unknown;
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

            var checks = BooleanList(500, input_param);
            AddMenuItems(menu, checks);
        }

        private void AddMenuItems(ToolStripDropDown menu, List<bool> checks)
        {
            Menu_AppendItem(menu, "Aus Compound Steel Sections: Double Rolled I Sections", (sender, e) => HandleMenuClick(1, checks, SectionGroup.AusCompoundSteelSectionsDoubleRolledISections), true, checks[1]);
            Menu_AppendItem(menu, "Aus Compound Steel Sections: Double Rolled I Sections with Plates", (sender, e) => HandleMenuClick(2, checks, SectionGroup.AusCompoundSteelSectionsDoubleRolledISectionsWithPlates), true, checks[2]);
            Menu_AppendItem(menu, "Aus Compound Steel Sections: Rolled Angles in Star Arrangement", (sender, e) => HandleMenuClick(3, checks, SectionGroup.AusCompoundSteelSectionsRolledAnglesInStarArrangement), true, checks[3]);
            Menu_AppendItem(menu, "Aus Compound Steel Sections: Rolled Channels (back to back)", (sender, e) => HandleMenuClick(4, checks, SectionGroup.AusCompoundSteelSectionsRolledChannelsBackToBack), true, checks[4]);
            Menu_AppendItem(menu, "Aus Compound Steel Sections: Rolled Channels (back to back) with Plates", (sender, e) => HandleMenuClick(5, checks, SectionGroup.AusCompoundSteelSectionsRolledChannelsBackToBackWithPlates), true, checks[5]);
            Menu_AppendItem(menu, "Aus Compound Steel Sections: Rolled Channels (toe to toe)", (sender, e) => HandleMenuClick(6, checks, SectionGroup.AusCompoundSteelSectionsRolledChannelsToeToToe), true, checks[6]);
            Menu_AppendItem(menu, "Aus Compound Steel Sections: Rolled Channels (toe to toe) with Horizontal Plates", (sender, e) => HandleMenuClick(7, checks, SectionGroup.AusCompoundSteelSectionsRolledChannelsToeToToeWithHorizontalPlates), true, checks[7]);
            Menu_AppendItem(menu, "Aus Compound Steel Sections: Rolled Channels (toe to toe) with Vertical Plates", (sender, e) => HandleMenuClick(8, checks, SectionGroup.AusCompoundSteelSectionsRolledChannelsToeToToeWithVerticalPlates), true, checks[8]);
            Menu_AppendItem(menu, "Aus Compound Steel Sections: Rolled I Sections with Bottom Plate", (sender, e) => HandleMenuClick(9, checks, SectionGroup.AusCompoundSteelSectionsRolledISectionsWithBottomPlate), true, checks[9]);
            Menu_AppendItem(menu, "Aus Compound Steel Sections: Rolled I Sections with Plates", (sender, e) => HandleMenuClick(10, checks, SectionGroup.AusCompoundSteelSectionsRolledISectionsWithPlates), true, checks[10]);
            Menu_AppendItem(menu, "Aus Compound Steel Sections: Rolled I Sections with Top Plate", (sender, e) => HandleMenuClick(11, checks, SectionGroup.AusCompoundSteelSectionsRolledISectionsWithTopPlate), true, checks[11]);
            Menu_AppendItem(menu, "Aus Compound Steel Sections: Rolled Steel Joists in Star Arrangement", (sender, e) => HandleMenuClick(12, checks, SectionGroup.AusCompoundSteelSectionsRolledSteelJoistsInStarArrangement), true, checks[12]);
            Menu_AppendItem(menu, "Aus Compound Steel Sections: Rolled Steel Joists with Plates", (sender, e) => HandleMenuClick(13, checks, SectionGroup.AusCompoundSteelSectionsRolledSteelJoistsWithPlates), true, checks[13]);
            Menu_AppendItem(menu, "Aus Compound Steel Sections: Rolled Steel Joists with Plates in Star Arrangement", (sender, e) => HandleMenuClick(14, checks, SectionGroup.AusCompoundSteelSectionsRolledSteelJoistsWithPlatesInStarArrangement), true, checks[14]);
            Menu_AppendItem(menu, "Australian Cold Rolled Sections: Bluescope Lysaght C Sections", (sender, e) => HandleMenuClick(15, checks, SectionGroup.AustralianColdRolledSectionsBluescopeLysaghtCSections), true, checks[15]);
            Menu_AppendItem(menu, "Australian Cold Rolled Sections: Bluescope Lysaght Eaves Beams", (sender, e) => HandleMenuClick(16, checks, SectionGroup.AustralianColdRolledSectionsBluescopeLysaghtEavesBeams), true, checks[16]);
            Menu_AppendItem(menu, "Australian Cold Rolled Sections: Bluescope Lysaght Z Sections", (sender, e) => HandleMenuClick(17, checks, SectionGroup.AustralianColdRolledSectionsBluescopeLysaghtZSections), true, checks[17]);
            Menu_AppendItem(menu, "Australian Hollow Steel Sections: Circular Hollow Sections C250", (sender, e) => HandleMenuClick(18, checks, SectionGroup.AustralianHollowSteelSectionsCircularHollowSectionsC250), true, checks[18]);
            Menu_AppendItem(menu, "Australian Hollow Steel Sections: Circular Hollow Sections C350", (sender, e) => HandleMenuClick(19, checks, SectionGroup.AustralianHollowSteelSectionsCircularHollowSectionsC350), true, checks[19]);
            Menu_AppendItem(menu, "Australian Hollow Steel Sections: Rectangular Hollow Sections C350", (sender, e) => HandleMenuClick(20, checks, SectionGroup.AustralianHollowSteelSectionsRectangularHollowSectionsC350), true, checks[20]);
            Menu_AppendItem(menu, "Australian Hollow Steel Sections: Rectangular Hollow Sections C450", (sender, e) => HandleMenuClick(21, checks, SectionGroup.AustralianHollowSteelSectionsRectangularHollowSectionsC450), true, checks[21]);
            Menu_AppendItem(menu, "Australian Hollow Steel Sections: Square Hollow Sections C350", (sender, e) => HandleMenuClick(22, checks, SectionGroup.AustralianHollowSteelSectionsSquareHollowSectionsC350), true, checks[22]);
            Menu_AppendItem(menu, "Australian Hollow Steel Sections: Square Hollow Sections C450", (sender, e) => HandleMenuClick(23, checks, SectionGroup.AustralianHollowSteelSectionsSquareHollowSectionsC450), true, checks[23]);
            Menu_AppendItem(menu, "Australian Steel Sections: 2 Equal Angles Back to Back", (sender, e) => HandleMenuClick(24, checks, SectionGroup.AustralianSteelSections2EqualAnglesBackToBack), true, checks[24]);
            Menu_AppendItem(menu, "Australian Steel Sections: 2 Unequal Angles Long Leg Back to Back", (sender, e) => HandleMenuClick(25, checks, SectionGroup.AustralianSteelSections2UnequalAnglesLongLegBackToBack), true, checks[25]);
            Menu_AppendItem(menu, "Australian Steel Sections: 2 Unequal Angles Short Leg Back to Back", (sender, e) => HandleMenuClick(26, checks, SectionGroup.AustralianSteelSections2UnequalAnglesShortLegBackToBack), true, checks[26]);
            Menu_AppendItem(menu, "Australian Steel Sections: Equal Angles", (sender, e) => HandleMenuClick(27, checks, SectionGroup.AustralianSteelSectionsEqualAngles), true, checks[27]);
            Menu_AppendItem(menu, "Australian Steel Sections: Flat Bars", (sender, e) => HandleMenuClick(28, checks, SectionGroup.AustralianSteelSectionsFlatBars), true, checks[28]);
            Menu_AppendItem(menu, "Australian Steel Sections: Parallel Flange Channels", (sender, e) => HandleMenuClick(29, checks, SectionGroup.AustralianSteelSectionsParallelFlangeChannels), true, checks[29]);
            Menu_AppendItem(menu, "Australian Steel Sections: Plated Beams", (sender, e) => HandleMenuClick(30, checks, SectionGroup.AustralianSteelSectionsPlatedBeams), true, checks[30]);
            Menu_AppendItem(menu, "Australian Steel Sections: Plated Columns", (sender, e) => HandleMenuClick(31, checks, SectionGroup.AustralianSteelSectionsPlatedColumns), true, checks[31]);
            Menu_AppendItem(menu, "Australian Steel Sections: Taper Flange Channels", (sender, e) => HandleMenuClick(32, checks, SectionGroup.AustralianSteelSectionsTaperFlangeChannels), true, checks[32]);
            Menu_AppendItem(menu, "Australian Steel Sections: Tapered Flange Beams", (sender, e) => HandleMenuClick(33, checks, SectionGroup.AustralianSteelSectionsTaperedFlangeBeams), true, checks[33]);
            Menu_AppendItem(menu, "Australian Steel Sections: Tee from Universal Beams", (sender, e) => HandleMenuClick(34, checks, SectionGroup.AustralianSteelSectionsTeeFromUniversalBeams), true, checks[34]);
            Menu_AppendItem(menu, "Australian Steel Sections: Tee from Universal Columns", (sender, e) => HandleMenuClick(35, checks, SectionGroup.AustralianSteelSectionsTeeFromUniversalColumns), true, checks[35]);
            Menu_AppendItem(menu, "Australian Steel Sections: Unequal Angles", (sender, e) => HandleMenuClick(36, checks, SectionGroup.AustralianSteelSectionsUnequalAngles), true, checks[36]);
            Menu_AppendItem(menu, "Australian Steel Sections: Universal Beams", (sender, e) => HandleMenuClick(37, checks, SectionGroup.AustralianSteelSectionsUniversalBeams), true, checks[37]);
            Menu_AppendItem(menu, "Australian Steel Sections: Universal Columns", (sender, e) => HandleMenuClick(38, checks, SectionGroup.AustralianSteelSectionsUniversalColumns), true, checks[38]);
            Menu_AppendItem(menu, "Australian Steel Sections: Welded Beams", (sender, e) => HandleMenuClick(39, checks, SectionGroup.AustralianSteelSectionsWeldedBeams), true, checks[39]);
            Menu_AppendItem(menu, "Australian Steel Sections: Welded Columns", (sender, e) => HandleMenuClick(40, checks, SectionGroup.AustralianSteelSectionsWeldedColumns), true, checks[40]);
            Menu_AppendItem(menu, "Australian Steel Sections: Westok Cellular Beams", (sender, e) => HandleMenuClick(41, checks, SectionGroup.AustralianSteelSectionsWestokCellularBeams), true, checks[41]);
            Menu_AppendItem(menu, "Canadian SCL Timber Sections: SI Microllam LVL 20E", (sender, e) => HandleMenuClick(42, checks, SectionGroup.CanadianSclTimberSectionsSiMicrollamLvl20E), true, checks[42]);
            Menu_AppendItem(menu, "Canadian SCL Timber Sections: SI TimberStrand LSL 13E", (sender, e) => HandleMenuClick(43, checks, SectionGroup.CanadianSclTimberSectionsSiTimberStrandLsl13E), true, checks[43]);
            Menu_AppendItem(menu, "Canadian SCL Timber Sections: SI TimberStrand LSL 15.5E", (sender, e) => HandleMenuClick(44, checks, SectionGroup.CanadianSclTimberSectionsSiTimberStrandLsl155E), true, checks[44]);
            Menu_AppendItem(menu, "Canadian SCL Timber Sections: SI West Fraser LVL 17E", (sender, e) => HandleMenuClick(45, checks, SectionGroup.CanadianSclTimberSectionsSiWestFraserLvl17E), true, checks[45]);
            Menu_AppendItem(menu, "Canadian SCL Timber Sections: SI West Fraser LVL 18E", (sender, e) => HandleMenuClick(46, checks, SectionGroup.CanadianSclTimberSectionsSiWestFraserLvl18E), true, checks[46]);
            Menu_AppendItem(menu, "Canadian SCL Timber Sections: SI West Fraser LVL 19E", (sender, e) => HandleMenuClick(47, checks, SectionGroup.CanadianSclTimberSectionsSiWestFraserLvl19E), true, checks[47]);
            Menu_AppendItem(menu, "Canadian SCL Timber Sections: SI West Fraser LVL 20E", (sender, e) => HandleMenuClick(48, checks, SectionGroup.CanadianSclTimberSectionsSiWestFraserLvl20E), true, checks[48]);
            Menu_AppendItem(menu, "Canadian SCL Timber Sections: US Microllam LVL 20E", (sender, e) => HandleMenuClick(49, checks, SectionGroup.CanadianSclTimberSectionsUsMicrollamLvl20E), true, checks[49]);
            Menu_AppendItem(menu, "Canadian SCL Timber Sections: US TimberStrand LSL 13E", (sender, e) => HandleMenuClick(50, checks, SectionGroup.CanadianSclTimberSectionsUsTimberStrandLsl13E), true, checks[50]);
            Menu_AppendItem(menu, "Canadian SCL Timber Sections: US TimberStrand LSL 15.5E", (sender, e) => HandleMenuClick(51, checks, SectionGroup.CanadianSclTimberSectionsUsTimberStrandLsl155E), true, checks[51]);
            Menu_AppendItem(menu, "Canadian SCL Timber Sections: US West Fraser LVL 17E", (sender, e) => HandleMenuClick(52, checks, SectionGroup.CanadianSclTimberSectionsUsWestFraserLvl17E), true, checks[52]);
            Menu_AppendItem(menu, "Canadian SCL Timber Sections: US West Fraser LVL 18E", (sender, e) => HandleMenuClick(53, checks, SectionGroup.CanadianSclTimberSectionsUsWestFraserLvl18E), true, checks[53]);
            Menu_AppendItem(menu, "Canadian SCL Timber Sections: US West Fraser LVL 19E", (sender, e) => HandleMenuClick(54, checks, SectionGroup.CanadianSclTimberSectionsUsWestFraserLvl19E), true, checks[54]);
            Menu_AppendItem(menu, "Canadian SCL Timber Sections: US West Fraser LVL 20E", (sender, e) => HandleMenuClick(55, checks, SectionGroup.CanadianSclTimberSectionsUsWestFraserLvl20E), true, checks[55]);
            Menu_AppendItem(menu, "Canadian Steel Sections: ASTM Pipes", (sender, e) => HandleMenuClick(56, checks, SectionGroup.CanadianSteelSectionsAstmPipes), true, checks[56]);
            Menu_AppendItem(menu, "Canadian Steel Sections: Angles", (sender, e) => HandleMenuClick(57, checks, SectionGroup.CanadianSteelSectionsAngles), true, checks[57]);
            Menu_AppendItem(menu, "Canadian Steel Sections: Channels", (sender, e) => HandleMenuClick(58, checks, SectionGroup.CanadianSteelSectionsChannels), true, checks[58]);
            Menu_AppendItem(menu, "Canadian Steel Sections: Double Angles Equal", (sender, e) => HandleMenuClick(59, checks, SectionGroup.CanadianSteelSectionsDoubleAnglesEqual), true, checks[59]);
            Menu_AppendItem(menu, "Canadian Steel Sections: Double Angles Long Leg Back to Back", (sender, e) => HandleMenuClick(60, checks, SectionGroup.CanadianSteelSectionsDoubleAnglesLongLegBackToBack), true, checks[60]);
            Menu_AppendItem(menu, "Canadian Steel Sections: Double Angles Short Leg Back to Back", (sender, e) => HandleMenuClick(61, checks, SectionGroup.CanadianSteelSectionsDoubleAnglesShortLegBackToBack), true, checks[61]);
            Menu_AppendItem(menu, "Canadian Steel Sections: HP", (sender, e) => HandleMenuClick(62, checks, SectionGroup.CanadianSteelSectionsHp), true, checks[62]);
            Menu_AppendItem(menu, "Canadian Steel Sections: M", (sender, e) => HandleMenuClick(63, checks, SectionGroup.CanadianSteelSectionsM), true, checks[63]);
            Menu_AppendItem(menu, "Canadian Steel Sections: Misc Channels", (sender, e) => HandleMenuClick(64, checks, SectionGroup.CanadianSteelSectionsMiscChannels), true, checks[64]);
            Menu_AppendItem(menu, "Canadian Steel Sections: Pipes", (sender, e) => HandleMenuClick(65, checks, SectionGroup.CanadianSteelSectionsPipes), true, checks[65]);
            Menu_AppendItem(menu, "Canadian Steel Sections: Plated Beams", (sender, e) => HandleMenuClick(66, checks, SectionGroup.CanadianSteelSectionsPlatedBeams), true, checks[66]);
            Menu_AppendItem(menu, "Canadian Steel Sections: Plated Columns", (sender, e) => HandleMenuClick(67, checks, SectionGroup.CanadianSteelSectionsPlatedColumns), true, checks[67]);
            Menu_AppendItem(menu, "Canadian Steel Sections: Rectangular ASTM Tubes", (sender, e) => HandleMenuClick(68, checks, SectionGroup.CanadianSteelSectionsRectangularAstmTubes), true, checks[68]);
            Menu_AppendItem(menu, "Canadian Steel Sections: Rectangular Tubes", (sender, e) => HandleMenuClick(69, checks, SectionGroup.CanadianSteelSectionsRectangularTubes), true, checks[69]);
            Menu_AppendItem(menu, "Canadian Steel Sections: S", (sender, e) => HandleMenuClick(70, checks, SectionGroup.CanadianSteelSectionsS), true, checks[70]);
            Menu_AppendItem(menu, "Canadian Steel Sections: Square ASTM Tubes", (sender, e) => HandleMenuClick(71, checks, SectionGroup.CanadianSteelSectionsSquareAstmTubes), true, checks[71]);
            Menu_AppendItem(menu, "Canadian Steel Sections: Square Tubes", (sender, e) => HandleMenuClick(72, checks, SectionGroup.CanadianSteelSectionsSquareTubes), true, checks[72]);
            Menu_AppendItem(menu, "Canadian Steel Sections: Super Light Beams", (sender, e) => HandleMenuClick(73, checks, SectionGroup.CanadianSteelSectionsSuperLightBeams), true, checks[73]);
            Menu_AppendItem(menu, "Canadian Steel Sections: Tee from Wide Flange Shapes", (sender, e) => HandleMenuClick(74, checks, SectionGroup.CanadianSteelSectionsTeeFromWideFlangeShapes), true, checks[74]);
            // Add other menu items here as needed
        }

        void HandleMenuClick(int index, List<bool> checks, SectionGroup type)
        {
            checks[index] = !checks[index];

            if (checks[index])
            {
                sectionGroup = type;
                for (int i = 0; i < checks.Count; i++)
                    if (i != index) checks[i] = false;
            }
            else
            {
                sectionGroup = SectionGroup.Unknown;
            }
            this.Message = sectionGroup.ToString();
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
            get { return new Guid("765AC20C-4C44-4634-9D16-5963C82C581C"); }
        }
    }
}
