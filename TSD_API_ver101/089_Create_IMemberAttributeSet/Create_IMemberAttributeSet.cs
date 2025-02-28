using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Geometry;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Materials;
using TSD.API.Remoting.Sections;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;
using TSD.API.Remoting.Structure.Create;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;

namespace TSD_API_ver101_Create_IMemberAttributeSetBase
{
    public class Get_Instance : GH_Component
    {
        public Get_Instance()
          : base("Create_IMemberAttributeSet", "C_IMemberAttributeSet",
            "Creating the IMemberAttributeSet",
            "TSD_API", "Creating_Functions")
        {
        }

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("iModel", "iModel", "[IModel] The Tekla Structural Designer IModel", GH_ParamAccess.item);
            pManager[0].Optional = true;
            pManager.AddGenericParameter("Active", "Active", "[Bool] Gets a value indicating whether the member is active", GH_ParamAccess.item);
            pManager[1].Optional = true;

            // Alignment
            pManager.AddGenericParameter("EndGlobalOffset", "EndGlobalOffset", "[Vector3D] The global offset at the end of the member", GH_ParamAccess.item);
            pManager[2].Optional = true;
            pManager.AddGenericParameter("OffsetMajor", "OffsetMajor", "[Double] The major offset of the member", GH_ParamAccess.item);
            pManager[3].Optional = true;
            pManager.AddGenericParameter("OffsetMinor", "OffsetMinor", "[Double] The minor offset of the member", GH_ParamAccess.item);
            pManager[4].Optional = true;
            pManager.AddGenericParameter("SnapLevelMajor", "SnapLevelMajor", "[SectionSnapLevel] Gets the major snap level of the member", GH_ParamAccess.item);
            pManager[5].Optional = true;
            pManager.AddGenericParameter("SnapLevelMinor", "SnapLevelMinor", "[SectionSnapLevel] Gets the minor snap level of the member", GH_ParamAccess.item);
            pManager[6].Optional = true;
            pManager.AddGenericParameter("StartGlobalOffset", "StartGlobalOffset", "[Vector3D] The global offset at the start of the member", GH_ParamAccess.item);
            pManager[7].Optional = true;

            pManager.AddGenericParameter("AllowanceForOpeningLeft", "AllowanceForOpeningLeft", "[Double] Gets the allowance for opening left (in [mm])", GH_ParamAccess.item);
            pManager[8].Optional = true;
            pManager.AddGenericParameter("AllowanceForOpeningRight", "AllowanceForOpeningRight", "[Double] Gets the allowance for opening right (in [mm])", GH_ParamAccess.item);
            pManager[9].Optional = true;
            pManager.AddGenericParameter("AllowAutomaticJoinAtEnd", "AllowAutomaticJoinAtEnd", "[Bool] Gets a value indicating whether the member joins automatically at end node", GH_ParamAccess.item);
            pManager[10].Optional = true;
            pManager.AddGenericParameter("AllowAutomaticJoinAtStart", "AllowAutomaticJoinAtStart", "[Bool] Gets a value indicating whether the member joins automatically at start node", GH_ParamAccess.item);
            pManager[11].Optional = true;
            pManager.AddGenericParameter("AutoAlign", "AutoAlign", "[Bool] Gets a value indicating whether automatic alignment will be applied when the member is created in the model", GH_ParamAccess.item);
            pManager[12].Optional = true;
            pManager.AddGenericParameter("AutoDesign", "AutoDesign", "[Bool] Gets a value indicating whether sections from the design section order will be considered during the design process", GH_ParamAccess.item);
            pManager[13].Optional = true;
            pManager.AddGenericParameter("AutoDesignOption", "AutoDesignOption", "[AutoDesignOption] Gets the auto-design option", GH_ParamAccess.item);
            pManager[14].Optional = true;
            pManager.AddGenericParameter("ConcreteDensityClass", "ConcreteDensityClass", "[ConcreteDensityClass] Gets the concrete density class", GH_ParamAccess.item);
            pManager[15].Optional = true;
            pManager.AddGenericParameter("ConcreteType", "ConcreteType", "[ConcreteType] Gets the concrete type", GH_ParamAccess.item);
            pManager[16].Optional = true;
            pManager.AddGenericParameter("ConsiderFlanges", "ConsiderFlanges", "[Bool] Gets a value indicating whether to consider flanges", GH_ParamAccess.item);
            pManager[17].Optional = true;
            pManager.AddGenericParameter("Construction", "Construction", "[MemberConstruction] Gets the member construction", GH_ParamAccess.item);
            pManager[18].Optional = true;
            pManager.AddGenericParameter("CurvedEccentricity", "CurvedEccentricity", "[Double] Gets the curved eccentricity (in [mm])", GH_ParamAccess.item);
            pManager[19].Optional = true;
            pManager.AddGenericParameter("CurvedOption", "CurvedOption", "[CurvedOption] Gets the CurvedOption", GH_ParamAccess.item);
            pManager[20].Optional = true;
            pManager.AddGenericParameter("ISection", "ISection", "[ISection] Gets the element section", GH_ParamAccess.item);
            pManager[21].Optional = true;
            pManager.AddGenericParameter("ElementType", "ElementType", "[ElementType] Gets the element type", GH_ParamAccess.item);
            pManager[22].Optional = true;

            // ISpanRelease parameters
            pManager.AddGenericParameter("FxStart", "FxStart", "[Bool] Fx release at start", GH_ParamAccess.item);
            pManager[23].Optional = true;
            pManager.AddGenericParameter("FyStart", "FyStart", "[Bool] Fy release at start", GH_ParamAccess.item);
            pManager[24].Optional = true;
            pManager.AddGenericParameter("FzStart", "FzStart", "[Bool] Fz release at start", GH_ParamAccess.item);
            pManager[25].Optional = true;
            pManager.AddGenericParameter("MxStart", "MxStart", "[Bool] Mx release at start", GH_ParamAccess.item);
            pManager[26].Optional = true;
            pManager.AddGenericParameter("MyStart", "MyStart", "[Bool] My release at start", GH_ParamAccess.item);
            pManager[27].Optional = true;
            pManager.AddGenericParameter("MzStart", "MzStart", "[Bool] Mz release at start", GH_ParamAccess.item);
            pManager[28].Optional = true;
            pManager.AddGenericParameter("FxEnd", "FxEnd", "[Bool] Fx release at end", GH_ParamAccess.item);
            pManager[29].Optional = true;
            pManager.AddGenericParameter("FyEnd", "FyEnd", "[Bool] Fy release at end", GH_ParamAccess.item);
            pManager[30].Optional = true;
            pManager.AddGenericParameter("FzEnd", "FzEnd", "[Bool] Fz release at end", GH_ParamAccess.item);
            pManager[31].Optional = true;
            pManager.AddGenericParameter("MxEnd", "MxEnd", "[Bool] Mx release at end", GH_ParamAccess.item);
            pManager[32].Optional = true;
            pManager.AddGenericParameter("MyEnd", "MyEnd", "[Bool] My release at end", GH_ParamAccess.item);
            pManager[33].Optional = true;
            pManager.AddGenericParameter("MzEnd", "MzEnd", "[Bool] Mz release at end", GH_ParamAccess.item);
            pManager[34].Optional = true;

            // IStiffness parameters
            pManager.AddGenericParameter("MaxForceCompressionStart", "MaxForceCompressionStart", "[Double] Gets the maximum force compression at start", GH_ParamAccess.item);
            pManager[35].Optional = true;
            pManager.AddGenericParameter("MaxForceTensionStart", "MaxForceTensionStart", "[Double] Gets the maximum force tension at start", GH_ParamAccess.item);
            pManager[36].Optional = true;
            pManager.AddGenericParameter("NominallyFixedPercentageStart", "NominallyFixedPercentageStart", "[Double] Gets the nominally fixed percentage at start", GH_ParamAccess.item);
            pManager[37].Optional = true;
            pManager.AddGenericParameter("NominallyPinnedPercentageStart", "NominallyPinnedPercentageStart", "[Double] Gets the nominally pinned percentage at start", GH_ParamAccess.item);
            pManager[38].Optional = true;
            pManager.AddGenericParameter("PartiallyFixedPercentageStart", "PartiallyFixedPercentageStart", "[Double] Gets the partially fixed percentage at start", GH_ParamAccess.item);
            pManager[39].Optional = true;
            pManager.AddGenericParameter("StiffnessStart", "StiffnessStart", "[Double] Gets the stiffness at start", GH_ParamAccess.item);
            pManager[40].Optional = true;
            pManager.AddGenericParameter("StiffnessCompressionStart", "StiffnessCompressionStart", "[Double] Gets the stiffness compression at start", GH_ParamAccess.item);
            pManager[41].Optional = true;
            pManager.AddGenericParameter("StiffnessTensionStart", "StiffnessTensionStart", "[Double] Gets the stiffness tension at start", GH_ParamAccess.item);
            pManager[42].Optional = true;
            pManager.AddGenericParameter("SpringStiffnessTypeStart", "SpringStiffnessTypeStart", "[SpringStiffness] Gets the spring stiffness type at start", GH_ParamAccess.item);
            pManager[43].Optional = true;

            pManager.AddGenericParameter("MaxForceCompressionEnd", "MaxForceCompressionEnd", "[Double] Gets the maximum force compression at end", GH_ParamAccess.item);
            pManager[44].Optional = true;
            pManager.AddGenericParameter("MaxForceTensionEnd", "MaxForceTensionEnd", "[Double] Gets the maximum force tension at end", GH_ParamAccess.item);
            pManager[45].Optional = true;
            pManager.AddGenericParameter("NominallyFixedPercentageEnd", "NominallyFixedPercentageEnd", "[Double] Gets the nominally fixed percentage at end", GH_ParamAccess.item);
            pManager[46].Optional = true;
            pManager.AddGenericParameter("NominallyPinnedPercentageEnd", "NominallyPinnedPercentageEnd", "[Double] Gets the nominally pinned percentage at end", GH_ParamAccess.item);
            pManager[47].Optional = true;
            pManager.AddGenericParameter("PartiallyFixedPercentageEnd", "PartiallyFixedPercentageEnd", "[Double] Gets the partially fixed percentage at end", GH_ParamAccess.item);
            pManager[48].Optional = true;
            pManager.AddGenericParameter("StiffnessEnd", "StiffnessEnd", "[Double] Gets the stiffness at end", GH_ParamAccess.item);
            pManager[49].Optional = true;
            pManager.AddGenericParameter("StiffnessCompressionEnd", "StiffnessCompressionEnd", "[Double] Gets the stiffness compression at end", GH_ParamAccess.item);
            pManager[50].Optional = true;
            pManager.AddGenericParameter("StiffnessTensionEnd", "StiffnessTensionEnd", "[Double] Gets the stiffness tension at end", GH_ParamAccess.item);
            pManager[51].Optional = true;
            pManager.AddGenericParameter("SpringStiffnessTypeEnd", "SpringStiffnessTypeEnd", "[SpringStiffness] Gets the spring stiffness type at end", GH_ParamAccess.item);
            pManager[52].Optional = true;

            // Other parameters
            pManager.AddGenericParameter("Fabrication", "Fabrication", "[MemberFabrication] Gets the member fabrication", GH_ParamAccess.item);
            pManager[53].Optional = true;
            pManager.AddGenericParameter("GravityOnly", "GravityOnly", "[Bool] Gets a value indicating whether the member is designed for gravity combinations only", GH_ParamAccess.item);
            pManager[54].Optional = true;
            pManager.AddGenericParameter("IncludeFlangesInAnalysis", "IncludeFlangesInAnalysis", "[Bool] Gets a value indicating whether the flanges are included in the analysis", GH_ParamAccess.item);
            pManager[55].Optional = true;
            pManager.AddGenericParameter("IncreaseReinforcementIfDeflectionCheckFails", "IncreaseReinforcementIfDeflectionCheckFails", "[Bool] Gets a value indicating whether to increase the reinforcement if the deflection check fails", GH_ParamAccess.item);
            pManager[56].Optional = true;
            pManager.AddGenericParameter("IsolatedBeam", "IsolatedBeam", "[Bool] Gets a value indicating whether the member is isolated", GH_ParamAccess.item);
            pManager[57].Optional = true;
            pManager.AddGenericParameter("Material", "Material", "[IMaterial] Gets the material", GH_ParamAccess.item);
            pManager[58].Optional = true;
            pManager.AddGenericParameter("MaterialType", "MaterialType", "[MaterialType] Gets the material type", GH_ParamAccess.item);
            pManager[59].Optional = true;
            pManager.AddGenericParameter("MaxFacetError", "MaxFacetError", "[Double] Gets the maximum facet error (in [mm])", GH_ParamAccess.item);
            pManager[60].Optional = true;
            pManager.AddGenericParameter("MemberType", "MemberType", "[MemberType] Gets the member type", GH_ParamAccess.item);
            pManager[61].Optional = true;
            pManager.AddGenericParameter("NominalCoverBeamBottomEdge", "NominalCoverBeamBottomEdge", "[Double] Gets the nominal cover on bottom edge (in [mm])", GH_ParamAccess.item);
            pManager[62].Optional = true;
            pManager.AddGenericParameter("NominalCoverBeamEnds", "NominalCoverBeamEnds", "[Double] Gets the nominal cover on ends (in [mm])", GH_ParamAccess.item);
            pManager[63].Optional = true;
            pManager.AddGenericParameter("NominalCoverBeamTopEdge", "NominalCoverBeamTopEdge", "[Double] Gets the nominal cover on top edge (in [mm])", GH_ParamAccess.item);
            pManager[64].Optional = true;
            pManager.AddGenericParameter("NominalCoverSectionSide", "NominalCoverSectionSide", "[Double] Gets the nominal cover on section side (in [mm])", GH_ParamAccess.item);
            pManager[65].Optional = true;
            pManager.AddGenericParameter("PermissibleIncreaseInReinforcement", "PermissibleIncreaseInReinforcement", "[Double] Gets the permissible increase in the reinforcement (in [mm])", GH_ParamAccess.item);
            pManager[66].Optional = true;
            pManager.AddGenericParameter("RotationAngle", "RotationAngle", "[Double] Gets the rotation angle (in [rad])", GH_ParamAccess.item);
            pManager[67].Optional = true;
            pManager.AddGenericParameter("RotationOption", "RotationOption", "[RotationOption] Gets the rotation option", GH_ParamAccess.item);
            pManager[68].Optional = true;
            pManager.AddGenericParameter("StructureSupportingSensitiveFinishes", "StructureSupportingSensitiveFinishes", "[Bool] Gets a value indicating the structure supporting sensitive finishes", GH_ParamAccess.item);
            pManager[69].Optional = true;
            pManager.AddGenericParameter("UserFlangeDepthLeft", "UserFlangeDepthLeft", "[Double] Gets the left flange depth if it has fixed dimensions (in [mm])", GH_ParamAccess.item);
            pManager[70].Optional = true;
            pManager.AddGenericParameter("UserFlangeDepthRight", "UserFlangeDepthRight", "[Double] Gets the right flange depth if it has fixed dimensions (in [mm])", GH_ParamAccess.item);
            pManager[71].Optional = true;
            pManager.AddGenericParameter("UserFlangeLeft", "UserFlangeLeft", "[Bool] Gets a value indicating whether the left flange dimensions are fixed instead of being calculated from the neighbor distance and slab", GH_ParamAccess.item);
            pManager[72].Optional = true;
            pManager.AddGenericParameter("UserFlangeRight", "UserFlangeRight", "[Bool] Gets a value indicating whether the right flange dimensions are fixed instead of being calculated from the neighbor distance and slab", GH_ParamAccess.item);
            pManager[73].Optional = true;
            pManager.AddGenericParameter("UserFlangeWidthLeft", "UserFlangeWidthLeft", "[Double] Gets the left flange width if it has fixed dimensions (in [mm])", GH_ParamAccess.item);
            pManager[74].Optional = true;
            pManager.AddGenericParameter("UserFlangeWidthRight", "UserFlangeWidthRight", "[Double] Gets the right flange width if it has fixed dimensions (in [mm])", GH_ParamAccess.item);
            pManager[75].Optional = true;
            pManager.AddGenericParameter("UseSlabForStiffnessCalculationEndMajor", "UseSlabForStiffnessCalculationEndMajor", "[Bool] Gets a value indicating whether the slab should be used for the stiffness calculation at end node in major direction", GH_ParamAccess.item);
            pManager[76].Optional = true;
            pManager.AddGenericParameter("UseSlabForStiffnessCalculationEndMinor", "UseSlabForStiffnessCalculationEndMinor", "[Bool] Gets a value indicating whether the slab should be used for the stiffness calculation at end node in minor direction", GH_ParamAccess.item);
            pManager[77].Optional = true;
            pManager.AddGenericParameter("UseSlabForStiffnessCalculationStartMajor", "UseSlabForStiffnessCalculationStartMajor", "[Bool] Gets a value indicating whether the slab should be used for the stiffness calculation at start node in major direction", GH_ParamAccess.item);
            pManager[78].Optional = true;
            pManager.AddGenericParameter("UseSlabForStiffnessCalculationStartMinor", "UseSlabForStiffnessCalculationStartMinor", "[Bool] Gets a value indicating whether the slab should be used for the stiffness calculation at start node in minor direction", GH_ParamAccess.item);
            pManager[79].Optional = true;
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("IMemberAttributeSet", "IMemberAttributeSet", "IMemberAttributeset", GH_ParamAccess.item);
            pManager.AddGenericParameter("Status", "Status", "Status", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            TSD.API.Remoting.Structure.IModel iModel = null;
            bool? active = null;

            // Alignment
            Vector3D? endGlobalOffset = null;
            double? offsetMajor = null;
            double? offsetMinor = null;
            SectionSnapLevel? snapLevelMajor = null;
            SectionSnapLevel? snapLevelMinor = null;
            Vector3D? startGlobalOffset = null;

            double? allowanceForOpeningLeft = null;
            double? allowanceForOpeningRight = null;
            bool? allowAutomaticJoinAtEnd = null;
            bool? allowAutomaticJoinAtStart = null;
            bool? autoAlign = null;
            bool? autoDesign = null;
            AutoDesignOption? autoDesignOption = null;
            ConcreteDensityClass? concreteDensityClass = null;
            ConcreteType? concreteType = null;
            bool? considerFlanges = null;
            MemberConstruction? construction = null;
            double? curvedEccentricity = null;
            CurvedOption? curvedOption = null;
            ISection iSection = null;
            ElementType? elementType = null;

            // ISpanRelease
            bool? Fx_start = null;
            bool? Fy_start = null;
            bool? Fz_start = null;
            bool? Mx_start = null;
            bool? My_start = null;
            bool? Mz_start = null;

            bool? Fx_end = null;
            bool? Fy_end = null;
            bool? Fz_end = null;
            bool? Mx_end = null;
            bool? My_end = null;
            bool? Mz_end = null;

            // IStiffness
            double? maxForceCompression_start = null;
            double? maxForceTension_start = null;
            double? nominallyFixedPercentage_start = null;
            double? nominallyPinnedPercentage_start = null;
            double? partiallyFixedPercentage_start = null;
            double? stiffness_start = null;
            double? stiffnessCompression_start = null;
            double? stiffnessTension_start = null;
            SpringStiffness? type_start = null;

            double? maxForceCompression_end = null;
            double? maxForceTension_end = null;
            double? nominallyFixedPercentage_end = null;
            double? nominallyPinnedPercentage_end = null;
            double? partiallyFixedPercentage_end = null;
            double? stiffness_end = null;
            double? stiffnessCompression_end = null;
            double? stiffnessTension_end = null;
            SpringStiffness? type_end = null;

            MemberFabrication? fabrication = null;
            bool? gravityOnly = null;
            bool? includeFlangesInAnalysis = null;
            bool? increaseReinforcementIfDeflectionCheckFails = null;
            bool? isolatedBeam = null;
            IMaterial imaterial = null;
            MaterialType? materialType = null;
            double? maxFacetError = null;
            MemberType? memberType = null;
            double? nominalCoverBeamBottomEdge = null;
            double? nominalCoverBeamEnds = null;
            double? nominalCoverBeamTopEdge = null;
            double? nominalCoverSectionSide = null;
            double? permissibleIncreaseInReinforcement = null;
            double? rotationAngle = null;
            RotationOption? rotationOption = null;
            bool? structureSupportingSensitiveFinishes = null;
            double? userFlangeDepthLeft = null;
            double? userFlangeDepthRight = null;
            bool? userFlangeLeft = null;
            bool? userFlangeRight = null;
            double? userFlangeWidthLeft = null;
            double? userFlangeWidthRight = null;
            bool? useSlabForStiffnessCalculationEndMajor = null;
            bool? useSlabForStiffnessCalculationEndMinor = null;
            bool? useSlabForStiffnessCalculationStartMajor = null;
            bool? useSlabForStiffnessCalculationStartMinor = null;

            if (!DA.GetData(0, ref iModel)) return;
            DA.GetData(1, ref active);
            DA.GetData(2, ref endGlobalOffset);
            DA.GetData(3, ref offsetMajor);
            DA.GetData(4, ref offsetMinor);
            DA.GetData(5, ref snapLevelMajor);
            DA.GetData(6, ref snapLevelMinor);
            DA.GetData(7, ref startGlobalOffset);
            DA.GetData(8, ref allowanceForOpeningLeft);
            DA.GetData(9, ref allowanceForOpeningRight);
            DA.GetData(10, ref allowAutomaticJoinAtEnd);
            DA.GetData(11, ref allowAutomaticJoinAtStart);
            DA.GetData(12, ref autoAlign);
            DA.GetData(13, ref autoDesign);
            DA.GetData(14, ref autoDesignOption);
            DA.GetData(15, ref concreteDensityClass);
            DA.GetData(16, ref concreteType);
            DA.GetData(17, ref considerFlanges);
            DA.GetData(18, ref construction);
            DA.GetData(19, ref curvedEccentricity);
            DA.GetData(20, ref curvedOption);
            DA.GetData(21, ref iSection);
            DA.GetData(22, ref elementType);
            DA.GetData(23, ref Fx_start);
            DA.GetData(24, ref Fy_start);
            DA.GetData(25, ref Fz_start);
            DA.GetData(26, ref Mx_start);
            DA.GetData(27, ref My_start);
            DA.GetData(28, ref Mz_start);
            DA.GetData(29, ref Fx_end);
            DA.GetData(30, ref Fy_end);
            DA.GetData(31, ref Fz_end);
            DA.GetData(32, ref Mx_end);
            DA.GetData(33, ref My_end);
            DA.GetData(34, ref Mz_end);
            DA.GetData(35, ref maxForceCompression_start);
            DA.GetData(36, ref maxForceTension_start);
            DA.GetData(37, ref nominallyFixedPercentage_start);
            DA.GetData(38, ref nominallyPinnedPercentage_start);
            DA.GetData(39, ref partiallyFixedPercentage_start);
            DA.GetData(40, ref stiffness_start);
            DA.GetData(41, ref stiffnessCompression_start);
            DA.GetData(42, ref stiffnessTension_start);
            DA.GetData(43, ref type_start);
            DA.GetData(44, ref maxForceCompression_end);
            DA.GetData(45, ref maxForceTension_end);
            DA.GetData(46, ref nominallyFixedPercentage_end);
            DA.GetData(47, ref nominallyPinnedPercentage_end);
            DA.GetData(48, ref partiallyFixedPercentage_end);
            DA.GetData(49, ref stiffness_end);
            DA.GetData(50, ref stiffnessCompression_end);
            DA.GetData(51, ref stiffnessTension_end);
            DA.GetData(52, ref type_end);
            DA.GetData(53, ref fabrication);
            DA.GetData(54, ref gravityOnly);
            DA.GetData(55, ref includeFlangesInAnalysis);
            DA.GetData(56, ref increaseReinforcementIfDeflectionCheckFails);
            DA.GetData(57, ref isolatedBeam);
            DA.GetData(58, ref imaterial);
            DA.GetData(59, ref materialType);
            DA.GetData(60, ref maxFacetError);
            DA.GetData(61, ref memberType);
            DA.GetData(62, ref nominalCoverBeamBottomEdge);
            DA.GetData(63, ref nominalCoverBeamEnds);
            DA.GetData(64, ref nominalCoverBeamTopEdge);
            DA.GetData(65, ref nominalCoverSectionSide);
            DA.GetData(66, ref permissibleIncreaseInReinforcement);
            DA.GetData(67, ref rotationAngle);
            DA.GetData(68, ref rotationOption);
            DA.GetData(69, ref structureSupportingSensitiveFinishes);
            DA.GetData(70, ref userFlangeDepthLeft);
            DA.GetData(71, ref userFlangeDepthRight);
            DA.GetData(72, ref userFlangeLeft);
            DA.GetData(73, ref userFlangeRight);
            DA.GetData(74, ref userFlangeWidthLeft);
            DA.GetData(75, ref userFlangeWidthRight);
            DA.GetData(76, ref useSlabForStiffnessCalculationEndMajor);
            DA.GetData(77, ref useSlabForStiffnessCalculationEndMinor);
            DA.GetData(78, ref useSlabForStiffnessCalculationStartMajor);
            DA.GetData(79, ref useSlabForStiffnessCalculationStartMinor);

            // Output
            IMemberAttributeSet Output = null;
            string output_1 = "N.A";

            try
            {
                Output = TSD_API_ver101_Create_IMemberAttributeSet.Create_IMembetAttributeSet_output.CreateIMemberAttributeSet(
                    iModel, active, endGlobalOffset, offsetMajor, offsetMinor, snapLevelMajor, snapLevelMinor, startGlobalOffset,
                    allowanceForOpeningLeft, allowanceForOpeningRight, allowAutomaticJoinAtEnd, allowAutomaticJoinAtStart, autoAlign, autoDesign,
                    autoDesignOption, concreteDensityClass, concreteType, considerFlanges, construction, curvedEccentricity, curvedOption, iSection,
                    elementType, Fx_start, Fy_start, Fz_start, Mx_start, My_start, Mz_start, Fx_end, Fy_end, Fz_end, Mx_end, My_end, Mz_end,
                    maxForceCompression_start, maxForceTension_start, nominallyFixedPercentage_start, nominallyPinnedPercentage_start,
                    partiallyFixedPercentage_start, stiffness_start, stiffnessCompression_start, stiffnessTension_start, type_start,
                    maxForceCompression_end, maxForceTension_end, nominallyFixedPercentage_end, nominallyPinnedPercentage_end,
                    partiallyFixedPercentage_end, stiffness_end, stiffnessCompression_end, stiffnessTension_end, type_end, fabrication, gravityOnly,
                    includeFlangesInAnalysis, increaseReinforcementIfDeflectionCheckFails, isolatedBeam, imaterial, materialType, maxFacetError,
                    memberType, nominalCoverBeamBottomEdge, nominalCoverBeamEnds, nominalCoverBeamTopEdge, nominalCoverSectionSide, permissibleIncreaseInReinforcement, rotationAngle, rotationOption, structureSupportingSensitiveFinishes, userFlangeDepthLeft, userFlangeDepthRight, userFlangeLeft, userFlangeRight, userFlangeWidthLeft, userFlangeWidthRight, useSlabForStiffnessCalculationEndMajor, useSlabForStiffnessCalculationEndMinor, useSlabForStiffnessCalculationStartMajor, useSlabForStiffnessCalculationStartMinor);

                output_1 = "Succeeded";
            }
            catch (Exception ex)
            {
                output_1 = $"Failed: {ex.Message}";
            }

            DA.SetData(0, Output);
            DA.SetData(1, output_1);
        }

        public override void AddedToDocument(GH_Document document)
        {
            base.AddedToDocument(document);

            EnsureBooleanToggle(23, "Fx_start", document);
            EnsureBooleanToggle(24, "Fy_start", document);
            EnsureBooleanToggle(25, "Fz_start", document);
            EnsureBooleanToggle(26, "Mx_start", document);
            EnsureBooleanToggle(27, "My_start", document);
            EnsureBooleanToggle(28, "Mz_start", document);
            EnsureBooleanToggle(29, "Fx_end", document);
            EnsureBooleanToggle(30, "Fy_end", document);
            EnsureBooleanToggle(31, "Fz_end", document);
            EnsureBooleanToggle(32, "Mx_end", document);
            EnsureBooleanToggle(33, "My_end", document);
            EnsureBooleanToggle(34, "Mz_end", document);
        }

        public void EnsureBooleanToggle(int inputIndex, string paramName, GH_Document document)
        {
            if (!InputHasConnections(inputIndex))
            {
                GH_BooleanToggle booleanToggle = new GH_BooleanToggle();
                booleanToggle.CreateAttributes();
                booleanToggle.Attributes.Pivot = new System.Drawing.PointF(this.Attributes.Pivot.X - Params.OutputWidth - Params.InputWidth - 150, this.Attributes.Pivot.Y + Params.Input[inputIndex].Attributes.Pivot.Y - 12);

                document.AddObject(booleanToggle, false);

                Params.Input[inputIndex].AddSource(booleanToggle);
            }
        }

        public bool InputHasConnections(int index)
        {
            return Params.Input[index].Sources.Count > 0;
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
            get { return new Guid("5DD442D7-A247-4666-9A03-E30CE2BD5D53"); }
        }
    }
}
