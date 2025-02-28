using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Materials;
using TSD.API.Remoting.Sections;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;
using TSD.API.Remoting.Geometry;

namespace TSD_API_ver101_Create_IMemberAttributeSet
{
    public class Create_IMembetAttributeSet_output
    {
        // Task -> Object
        public static TSD.API.Remoting.Structure.Create.IMemberAttributeSet CreateIMemberAttributeSet(TSD.API.Remoting.Structure.IModel iModel, bool? active, Vector3D? endGlobalOffset, double? offsetMajor, double? offsetMinor,
            SectionSnapLevel? snapLevelMajor, SectionSnapLevel? snapLevelMinor, Vector3D? startGlobalOffset, double? allowanceForOpeningLeft,
            double? allowanceForOpeningRight, bool? allowAutomaticJoinAtEnd, bool? allowAutomaticJoinAtStart, bool? autoAlign, bool? autoDesign,
            AutoDesignOption? autoDesignOption, ConcreteDensityClass? concreteDensityClass, ConcreteType? concreteType, bool? considerFlanges,
            MemberConstruction? construction, double? curvedEccentricity, CurvedOption? curvedOption, ISection iSection, ElementType? elementType,
            bool? Fx_start, bool? Fy_start, bool? Fz_start, bool? Mx_start, bool? My_start, bool? Mz_start, bool? Fx_end, bool? Fy_end,
            bool? Fz_end, bool? Mx_end, bool? My_end, bool? Mz_end, double? maxForceCompression_start, double? maxForceTension_start,
            double? nominallyFixedPercentage_start, double? nominallyPinnedPercentage_start, double? partiallyFixedPercentage_start,
            double? stiffness_start, double? stiffnessCompression_start, double? stiffnessTension_start, SpringStiffness? type_start,
            double? maxForceCompression_end, double? maxForceTension_end, double? nominallyFixedPercentage_end, double? nominallyPinnedPercentage_end,
            double? partiallyFixedPercentage_end, double? stiffness_end, double? stiffnessCompression_end, double? stiffnessTension_end,
            SpringStiffness? type_end, MemberFabrication? fabrication, bool? gravityOnly, bool? includeFlangesInAnalysis,
            bool? increaseReinforcementIfDeflectionCheckFails, bool? isolatedBeam, IMaterial imaterial, MaterialType? materialType,
            double? maxFacetError, MemberType? memberType, double? nominalCoverBeamBottomEdge, double? nominalCoverBeamEnds,
            double? nominalCoverBeamTopEdge, double? nominalCoverSectionSide, double? permissibleIncreaseInReinforcement, double? rotationAngle,
            RotationOption? rotationOption, bool? structureSupportingSensitiveFinishes, double? userFlangeDepthLeft, double? userFlangeDepthRight,
            bool? userFlangeLeft, bool? userFlangeRight, double? userFlangeWidthLeft, double? userFlangeWidthRight,
            bool? useSlabForStiffnessCalculationEndMajor, bool? useSlabForStiffnessCalculationEndMinor,
            bool? useSlabForStiffnessCalculationStartMajor, bool? useSlabForStiffnessCalculationStartMinor)
        {
            try
            {
                // Call the asynchronous method and wait for its completion non-blockingly
                var resultTask = Task.Run(async () => await Create_IMemberAttributeSet_process.CreateIMemberAttributeSetAsync(iModel, active, endGlobalOffset, offsetMajor, offsetMinor, snapLevelMajor, snapLevelMinor, startGlobalOffset, allowanceForOpeningLeft, allowanceForOpeningRight, allowAutomaticJoinAtEnd, allowAutomaticJoinAtStart, autoAlign, autoDesign, autoDesignOption, concreteDensityClass, concreteType, considerFlanges, construction, curvedEccentricity, curvedOption, iSection, elementType, Fx_start, Fy_start, Fz_start, Mx_start, My_start, Mz_start, Fx_end, Fy_end, Fz_end, Mx_end, My_end, Mz_end, maxForceCompression_start, maxForceTension_start, nominallyFixedPercentage_start, nominallyPinnedPercentage_start, partiallyFixedPercentage_start, stiffness_start, stiffnessCompression_start, stiffnessTension_start, type_start, maxForceCompression_end, maxForceTension_end, nominallyFixedPercentage_end, nominallyPinnedPercentage_end, partiallyFixedPercentage_end, stiffness_end, stiffnessCompression_end, stiffnessTension_end, type_end, fabrication, gravityOnly, includeFlangesInAnalysis, increaseReinforcementIfDeflectionCheckFails, isolatedBeam, imaterial, materialType, maxFacetError, memberType, nominalCoverBeamBottomEdge, nominalCoverBeamEnds, nominalCoverBeamTopEdge, nominalCoverSectionSide, permissibleIncreaseInReinforcement, rotationAngle, rotationOption, structureSupportingSensitiveFinishes, userFlangeDepthLeft, userFlangeDepthRight, userFlangeLeft, userFlangeRight, userFlangeWidthLeft, userFlangeWidthRight, useSlabForStiffnessCalculationEndMajor, useSlabForStiffnessCalculationEndMinor, useSlabForStiffnessCalculationStartMajor, useSlabForStiffnessCalculationStartMinor));
                return resultTask.Result; // Retrieve the result
            }
            catch (Exception ex)
            {
                throw new Exception("Error during Task -> object");
            }
        }

    }
}
