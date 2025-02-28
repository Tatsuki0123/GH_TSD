using System;
using System.Threading.Tasks;
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

namespace TSD_API_ver101_Create_IMemberAttributeSet
{
    public class Create_IMemberAttributeSet_process
    {
        // Getting solver IModel 
        public static async Task<IMemberAttributeSet> CreateIMemberAttributeSetAsync(
            TSD.API.Remoting.Structure.IModel iModel, bool? active, Vector3D? endGlobalOffset, double? offsetMajor, double? offsetMinor,
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
            var itemCatched = await iModel.CreateMemberAttributeSetAsync();



            //firstly need to be implemented
            if (memberType.HasValue)
            {
                await itemCatched.MemberType.SetValueAndUpdateAsync(memberType.Value);
            }

            if (memberType.HasValue && materialType.HasValue)
            {
                await itemCatched.MaterialType.SetValueAndUpdateAsync(materialType.Value);
            }

            if(materialType.HasValue && fabrication.HasValue)
            {
                await itemCatched.Fabrication.SetValueAndUpdateAsync(fabrication.Value);
            }

            if (fabrication.HasValue && construction.HasValue)
            {
                await itemCatched.Construction.SetValueAndUpdateAsync(construction.Value);
            }

            //Autodesign
            if (construction.HasValue && autoDesign.HasValue)
            {
                await itemCatched.AutoDesign.SetValueAndUpdateAsync(autoDesign.Value);
            }


            /* for some reason it can not be set
            if (autoDesign.Value == true && autoDesignOption.HasValue)
            {
                await itemCatched.AutoDesignOption.SetValueAndUpdateAsync(autoDesignOption.Value);
            }
            */

            //rotation angle
            if (construction.HasValue && rotationOption.HasValue)
            {
                await itemCatched.RotationOption.SetValueAndUpdateAsync(rotationOption.Value);
            }


            /* for some reaso it can not be set
            if (rotationOption.Value == RotationOption.Angle && rotationAngle.HasValue)
            {
                await itemCatched.RotationAngle.SetValueAndUpdateAsync(rotationAngle.Value);
            }
            */

            //Material
            if(construction.HasValue && imaterial != null)
            {
                await itemCatched.Material.SetValueAndUpdateAsync(imaterial);
            }

            //Boundary
            if (construction.HasValue && Fx_start.HasValue && Fy_start.HasValue && Fz_start.HasValue && Mx_start.HasValue && My_start.HasValue && Mz_start.HasValue)
            {
                await itemCatched.StartReleases.Value.DegreeOfFreedom.SetValueAndUpdateAsync(
                    (Fx_start.Value ? DegreeOfFreedom.Fx : DegreeOfFreedom.Free) |
                    (Fy_start.Value ? DegreeOfFreedom.Fy : DegreeOfFreedom.Free) |
                    (Fz_start.Value ? DegreeOfFreedom.Fz : DegreeOfFreedom.Free) |
                    (Mx_start.Value ? DegreeOfFreedom.Mx : DegreeOfFreedom.Free) |
                    (My_start.Value ? DegreeOfFreedom.My : DegreeOfFreedom.Free) |
                    (Mz_start.Value ? DegreeOfFreedom.Mz : DegreeOfFreedom.Free)
                );
            }

            if (construction.HasValue && Fx_end.HasValue && Fy_end.HasValue && Fz_end.HasValue && Mx_end.HasValue && My_end.HasValue && Mz_end.HasValue)
            {
                await itemCatched.EndReleases.Value.DegreeOfFreedom.SetValueAndUpdateAsync(
                    (Fx_end.Value ? DegreeOfFreedom.Fx : DegreeOfFreedom.Free) |
                    (Fy_end.Value ? DegreeOfFreedom.Fy : DegreeOfFreedom.Free) |
                    (Fz_end.Value ? DegreeOfFreedom.Fz : DegreeOfFreedom.Free) |
                    (Mx_end.Value ? DegreeOfFreedom.Mx : DegreeOfFreedom.Free) |
                    (My_end.Value ? DegreeOfFreedom.My : DegreeOfFreedom.Free) |
                    (Mz_end.Value ? DegreeOfFreedom.Mz : DegreeOfFreedom.Free)
                );
            }


            //active or not for some reason not working
            /*
            if (construction.HasValue && active.HasValue)
            {
                await itemCatched.Active.SetValueAndUpdateAsync(active.Value);
            }
            */

            //auto align
            if (construction.HasValue && autoAlign.HasValue && materialType == MaterialType.Concrete)
            {
                await itemCatched.AutoAlign.SetValueAndUpdateAsync(autoAlign.Value);
            }

            //Snap level change
            if (construction.HasValue && snapLevelMajor.HasValue)
            {
                await itemCatched.Alignment.Value.SnapLevelMajor.SetValueAndUpdateAsync(snapLevelMajor.Value);
            }

            if (construction.HasValue && snapLevelMinor.HasValue)
            {
                await itemCatched.Alignment.Value.SnapLevelMinor.SetValueAndUpdateAsync(snapLevelMinor.Value);
            }

            //Auto join does not work
            /*
            if (construction.HasValue && allowAutomaticJoinAtStart.HasValue)
            {
                await itemCatched.AllowAutomaticJoinAtStart.SetValueAndUpdateAsync(allowAutomaticJoinAtStart.Value);
            }
            if (construction.HasValue && allowAutomaticJoinAtEnd.HasValue)
            {
                await itemCatched.AllowAutomaticJoinAtEnd.SetValueAndUpdateAsync(allowAutomaticJoinAtEnd.Value);
            }
            */

            //Global offset not working for some rason
            /*
            if (construction.HasValue && endGlobalOffset.HasValue && materialType == MaterialType.Steel)
            {
                await itemCatched.Alignment.Value.EndGlobalOffset.SetValueAndUpdateAsync(endGlobalOffset.Value);
            }

            if (construction.HasValue && startGlobalOffset.HasValue && materialType == MaterialType.Steel)
            {
                await itemCatched.Alignment.Value.StartGlobalOffset.SetValueAndUpdateAsync(startGlobalOffset.Value);
            }
            */

            //Section not working
            /*
            if(construction.HasValue && iSection != null)
            {
                await (itemCatched.ElementSection.Value as IMemberSection)?.PhysicalSection.SetValueAndUpdateAsync(iSection);
            }
            */


            //Gravity only
            if (construction.HasValue && gravityOnly.HasValue)
            {
                await itemCatched.GravityOnly.SetValueAndUpdateAsync(gravityOnly.Value);
            }








            return itemCatched;






































            /*



            if (offsetMajor.HasValue)
            {
                await itemCatched.Alignment.Value.OffsetMajor.SetValueAndUpdateAsync(offsetMajor.Value);
            }

            if (offsetMinor.HasValue)
            {
                await itemCatched.Alignment.Value.OffsetMinor.SetValueAndUpdateAsync(offsetMinor.Value);
            }





            if (allowanceForOpeningLeft.HasValue)
            {
                await itemCatched.AllowanceForOpeningLeft.SetValueAndUpdateAsync(allowanceForOpeningLeft.Value);
            }

            if (allowanceForOpeningRight.HasValue)
            {
                await itemCatched.AllowanceForOpeningRight.SetValueAndUpdateAsync(allowanceForOpeningRight.Value);
            }




            if (concreteDensityClass.HasValue)
            {
                await itemCatched.ConcreteDensityClass.SetValueAndUpdateAsync(concreteDensityClass.Value);
            }

            if (concreteType.HasValue)
            {
                await itemCatched.ConcreteType.SetValueAndUpdateAsync(concreteType.Value);
            }

            if (considerFlanges.HasValue)
            {
                await itemCatched.ConsiderFlanges.SetValueAndUpdateAsync(considerFlanges.Value);
            }

   

            if (curvedEccentricity.HasValue)
            {
                await itemCatched.CurvedEccentricity.SetValueAndUpdateAsync(curvedEccentricity.Value);
            }

            if (curvedOption.HasValue)
            {
                await itemCatched.CurvedOption.SetValueAndUpdateAsync(curvedOption.Value);
            }

            //await itemCatched.ElementSection.Value.Cast as  SetValueAndUpdateAsync(iSection);

            if (elementType.HasValue)
            {
                await itemCatched.ElementType.SetValueAndUpdateAsync(elementType.Value);
            }









            if (maxForceCompression_start.HasValue)
            {
                await itemCatched.StartReleases.Value.MajorRotationalStiffness.Value.MaxForceCompression.SetValueAndUpdateAsync(maxForceCompression_start.Value);
            }

            if (maxForceTension_start.HasValue)
            {
                await itemCatched.StartReleases.Value.MajorRotationalStiffness.Value.MaxForceTension.SetValueAndUpdateAsync(maxForceTension_start.Value);
            }

            if (nominallyFixedPercentage_start.HasValue)
            {
                await itemCatched.StartReleases.Value.MajorRotationalStiffness.Value.NominallyFixedPercentage.SetValueAndUpdateAsync(nominallyFixedPercentage_start.Value);
            }

            if (nominallyPinnedPercentage_start.HasValue)
            {
                await itemCatched.StartReleases.Value.MajorRotationalStiffness.Value.NominallyPinnedPercentage.SetValueAndUpdateAsync(nominallyPinnedPercentage_start.Value);
            }

            if (partiallyFixedPercentage_start.HasValue)
            {
                await itemCatched.StartReleases.Value.MajorRotationalStiffness.Value.PartiallyFixedPercentage.SetValueAndUpdateAsync(partiallyFixedPercentage_start.Value);
            }

            if (stiffness_start.HasValue)
            {
                await itemCatched.StartReleases.Value.MajorRotationalStiffness.Value.Stiffness.SetValueAndUpdateAsync(stiffness_start.Value);
            }

            if (stiffnessCompression_start.HasValue)
            {
                await itemCatched.StartReleases.Value.MajorRotationalStiffness.Value.StiffnessCompression.SetValueAndUpdateAsync(stiffnessCompression_start.Value);
            }

            if (stiffnessTension_start.HasValue)
            {
                await itemCatched.StartReleases.Value.MajorRotationalStiffness.Value.StiffnessTension.SetValueAndUpdateAsync(stiffnessTension_start.Value);
            }

            if (type_start.HasValue)
            {
                await itemCatched.StartReleases.Value.MajorRotationalStiffness.Value.Type.SetValueAndUpdateAsync(type_start.Value);
            }

            if (maxForceCompression_end.HasValue)
            {
                await itemCatched.EndReleases.Value.MajorRotationalStiffness.Value.MaxForceCompression.SetValueAndUpdateAsync(maxForceCompression_end.Value);
            }

            if (maxForceTension_end.HasValue)
            {
                await itemCatched.EndReleases.Value.MajorRotationalStiffness.Value.MaxForceTension.SetValueAndUpdateAsync(maxForceTension_end.Value);
            }

            if (nominallyFixedPercentage_end.HasValue)
            {
                await itemCatched.EndReleases.Value.MajorRotationalStiffness.Value.NominallyFixedPercentage.SetValueAndUpdateAsync(nominallyFixedPercentage_end.Value);
            }

            if (nominallyPinnedPercentage_end.HasValue)
            {
                await itemCatched.EndReleases.Value.MajorRotationalStiffness.Value.NominallyPinnedPercentage.SetValueAndUpdateAsync(nominallyPinnedPercentage_end.Value);
            }

            if (partiallyFixedPercentage_end.HasValue)
            {
                await itemCatched.EndReleases.Value.MajorRotationalStiffness.Value.PartiallyFixedPercentage.SetValueAndUpdateAsync(partiallyFixedPercentage_end.Value);
            }

            if (stiffness_end.HasValue)
            {
                await itemCatched.EndReleases.Value.MajorRotationalStiffness.Value.Stiffness.SetValueAndUpdateAsync(stiffness_end.Value);
            }

            if (stiffnessCompression_end.HasValue)
            {
                await itemCatched.EndReleases.Value.MajorRotationalStiffness.Value.StiffnessCompression.SetValueAndUpdateAsync(stiffnessCompression_end.Value);
            }

            if (stiffnessTension_end.HasValue)
            {
                await itemCatched.EndReleases.Value.MajorRotationalStiffness.Value.StiffnessTension.SetValueAndUpdateAsync(stiffnessTension_end.Value);
            }

            if (type_end.HasValue)
            {
                await itemCatched.EndReleases.Value.MajorRotationalStiffness.Value.Type.SetValueAndUpdateAsync(type_end.Value);
            }

            if (fabrication.HasValue)




            if (includeFlangesInAnalysis.HasValue)
            {
                await itemCatched.IncludeFlangesInAnalysis.SetValueAndUpdateAsync(includeFlangesInAnalysis.Value);
            }

            if (increaseReinforcementIfDeflectionCheckFails.HasValue)
            {
                await itemCatched.IncreaseReinforcementIfDeflectionCheckFails.SetValueAndUpdateAsync(increaseReinforcementIfDeflectionCheckFails.Value);
            }

            if (isolatedBeam.HasValue)
            {
                await itemCatched.IsolatedBeam.SetValueAndUpdateAsync(isolatedBeam.Value);
            }

          



            if (maxFacetError.HasValue)
            {
                await itemCatched.MaxFacetError.SetValueAndUpdateAsync(maxFacetError.Value);
            }



            if (nominalCoverBeamBottomEdge.HasValue)
            {
                await itemCatched.NominalCoverBeamBottomEdge.SetValueAndUpdateAsync(nominalCoverBeamBottomEdge.Value);
            }

            if (nominalCoverBeamEnds.HasValue)
            {
                await itemCatched.NominalCoverBeamEnds.SetValueAndUpdateAsync(nominalCoverBeamEnds.Value);
            }

            if (nominalCoverBeamTopEdge.HasValue)
            {
                await itemCatched.NominalCoverBeamTopEdge.SetValueAndUpdateAsync(nominalCoverBeamTopEdge.Value);
            }

            if (nominalCoverSectionSide.HasValue)
            {
                await itemCatched.NominalCoverSectionSide.SetValueAndUpdateAsync(nominalCoverSectionSide.Value);
            }

            if (permissibleIncreaseInReinforcement.HasValue)
            {
                await itemCatched.PermissibleIncreaseInReinforcement.SetValueAndUpdateAsync(permissibleIncreaseInReinforcement.Value);
            }



            if (structureSupportingSensitiveFinishes.HasValue)
            {
                await itemCatched.StructureSupportingSensitiveFinishes.SetValueAndUpdateAsync(structureSupportingSensitiveFinishes.Value);
            }

            if (userFlangeDepthLeft.HasValue)
            {
                await itemCatched.UserFlangeDepthLeft.SetValueAndUpdateAsync(userFlangeDepthLeft.Value);
            }

            if (userFlangeDepthRight.HasValue)
            {
                await itemCatched.UserFlangeDepthRight.SetValueAndUpdateAsync(userFlangeDepthRight.Value);
            }

            if (userFlangeLeft.HasValue)
            {
                await itemCatched.UserFlangeLeft.SetValueAndUpdateAsync(userFlangeLeft.Value);
            }

            if (userFlangeRight.HasValue)
            {
                await itemCatched.UserFlangeRight.SetValueAndUpdateAsync(userFlangeRight.Value);
            }

            if (userFlangeWidthLeft.HasValue)
            {
                await itemCatched.UserFlangeWidthLeft.SetValueAndUpdateAsync(userFlangeWidthLeft.Value);
            }

            if (userFlangeWidthRight.HasValue)
            {
                await itemCatched.UserFlangeWidthRight.SetValueAndUpdateAsync(userFlangeWidthRight.Value);
            }

            if (useSlabForStiffnessCalculationEndMajor.HasValue)
            {
                await itemCatched.UseSlabForStiffnessCalculationEndMajor.SetValueAndUpdateAsync(useSlabForStiffnessCalculationEndMajor.Value);
            }

            if (useSlabForStiffnessCalculationEndMinor.HasValue)
            {
                await itemCatched.UseSlabForStiffnessCalculationEndMinor.SetValueAndUpdateAsync(useSlabForStiffnessCalculationEndMinor.Value);
            }

            if (useSlabForStiffnessCalculationStartMajor.HasValue)
            {
                await itemCatched.UseSlabForStiffnessCalculationStartMajor.SetValueAndUpdateAsync(useSlabForStiffnessCalculationStartMajor.Value);
            }

            if (useSlabForStiffnessCalculationStartMinor.HasValue)
            {
                await itemCatched.UseSlabForStiffnessCalculationStartMinor.SetValueAndUpdateAsync(useSlabForStiffnessCalculationStartMinor.Value);
            }*/



        }
    }
}
