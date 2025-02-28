using System;
using System.Linq;
using Grasshopper.Kernel;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Geometry;
using TSD.API.Remoting.Materials;
using TSD.API.Remoting.Sections;
using TSD.API.Remoting.Structure;

public class ExplodeIMemberSpanComponent : GH_Component
{
    public ExplodeIMemberSpanComponent()
      : base("Explode_IMemberSpan_2", "E_IMemberSpan_2",
            "Explodeing the IMemberSpan ver1",
            "TSD_API", "Exploding_functions")
    {
    }

    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        pManager.AddGenericParameter("IMemberSpan", "IMemberSpan", "The IMemberSpan object to explode", GH_ParamAccess.item);
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
        pManager.AddGenericParameter("BuildingDirection", "BuildingDirection", "BuildingDirection of the first span of the member", GH_ParamAccess.item);
        pManager.AddGenericParameter("CheckResultType", "CheckResultType", "Results of the check/design of this member span", GH_ParamAccess.item);
        pManager.AddGenericParameter("ICheckResults", "ICheckResults", "Results of the check/design of this member span", GH_ParamAccess.item);
        pManager.AddGenericParameter("ConcreteDensityClass", "ConcreteDensityClass", "ConcreteDensityClass", GH_ParamAccess.item);
        pManager.AddGenericParameter("ConcreteType", "ConcreteType", "ConcreteType", GH_ParamAccess.item);
        pManager.AddGenericParameter("CurvedEccentricity", "CurvedEccentricity", "CurvedEccentricity (in mm)", GH_ParamAccess.item);
        pManager.AddGenericParameter("CurvedOption", "CurvedOption", "CurvedOption", GH_ParamAccess.item);
        pManager.AddGenericParameter("Data", "Data", "Data of this span", GH_ParamAccess.item);
        pManager.AddGenericParameter("DesignSegment", "DesignSegment", "Design segment", GH_ParamAccess.item);
        pManager.AddGenericParameter("ElementSection", "ElementSection", "IElementSection", GH_ParamAccess.item);
        pManager.AddGenericParameter("EndMajorTotalOffset", "EndMajorTotalOffset", "End major axis offset (in mm)", GH_ParamAccess.item);
        pManager.AddGenericParameter("EndMemberNode", "EndMemberNode", "End IMemberNode", GH_ParamAccess.item);
        pManager.AddGenericParameter("EndMinorTotalOffset", "EndMinorTotalOffset", "End minor axis offset (in mm)", GH_ParamAccess.item);
        pManager.AddGenericParameter("EndReleases", "EndReleases", "End ISpanReleases", GH_ParamAccess.item);
        pManager.AddGenericParameter("EntityId", "EntityId", "Entity ID", GH_ParamAccess.item);
        pManager.AddGenericParameter("EntityIndex", "EntityIndex", "Entity index", GH_ParamAccess.item);
        pManager.AddGenericParameter("EntityType", "EntityType", "Entity type", GH_ParamAccess.item);
        pManager.AddGenericParameter("GlobalRotationAngle", "GlobalRotationAngle", "Global rotation angle (in rad)", GH_ParamAccess.item);
        pManager.AddGenericParameter("Id", "Id", "ID", GH_ParamAccess.item);
        pManager.AddGenericParameter("Index", "Index", "Index", GH_ParamAccess.item);
        pManager.AddGenericParameter("IsSectionAwaitingDesign", "IsSectionAwaitingDesign", "Whether the section is awaiting design", GH_ParamAccess.item);
        pManager.AddGenericParameter("Kll", "Kll", "Kll", GH_ParamAccess.item);
        pManager.AddGenericParameter("Length", "Length", "Length of the span (in mm)", GH_ParamAccess.item);
        pManager.AddGenericParameter("Material", "Material", "IMaterial", GH_ParamAccess.item);
        pManager.AddGenericParameter("MaxFacetError", "MaxFacetError", "Max facet error (in mm)", GH_ParamAccess.item);
        pManager.AddGenericParameter("Name", "Name", "Name", GH_ParamAccess.item);
        pManager.AddGenericParameter("RotationAngle", "RotationAngle", "Rotation angle (in rad)", GH_ParamAccess.item);
        pManager.AddGenericParameter("RotationOption", "RotationOption", "Rotation option", GH_ParamAccess.item);
        pManager.AddGenericParameter("StartMajorTotalOffset", "StartMajorTotalOffset", "Start major axis offset (in mm)", GH_ParamAccess.item);
        pManager.AddGenericParameter("StartMemberNode", "StartMemberNode", "Start IMemberNode", GH_ParamAccess.item);
        pManager.AddGenericParameter("StartMinorTotalOffset", "StartMinorTotalOffset", "Start minor axis offset (in mm)", GH_ParamAccess.item);
        pManager.AddGenericParameter("StartReleases", "StartReleases", "Start ISpanReleases", GH_ParamAccess.item);
        pManager.AddGenericParameter("Type", "Type", "SubEntityType", GH_ParamAccess.item);
        pManager.AddGenericParameter("UserLoadReductionFactorImposed", "UserLoadReductionFactorImposed", "User defined imposed loads reduction factor", GH_ParamAccess.item);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
        IMemberSpan memberSpan = null;
        if (!DA.GetData(0, ref memberSpan))
            return;

        // Default values
        BuildingDirection buildingDirection = BuildingDirection.Unknown;
        CheckResultType checkResultType = CheckResultType.Unknown;
        ICheckResult icheckResult = null;
        ConcreteDensityClass concreteDensityClass = ConcreteDensityClass.Unknown;
        ConcreteType concreteType = ConcreteType.Unknown;
        double curvedEccentricity = -1;
        CurvedOption curvedOption = CurvedOption.Unknown;
        IMemberSpanData data = null;
        ISegment3D designSegment = null;
        IMemberSection elementSection = null;
        double endMajorTotalOffset = -1;
        IMemberNode endMemberNode = null;
        double endMinorTotalOffset = -1;
        ISpanReleases endReleases = null;
        Guid entityId = Guid.Empty;
        int entityIndex = -1;
        EntityType entityType = EntityType.Unknown;
        double globalRotationAngle = 0;
        Guid id = Guid.Empty;
        int index = -1;
        bool isSectionAwaitingDesign = false;
        double kll = -1;
        double length = -1;
        IMaterial material = null;
        double maxFacetError = -1;
        string name = "N.A";
        double rotationAngle = 0;
        RotationOption rotationOption = RotationOption.Unknown;
        double startMajorTotalOffset = -1;
        IMemberNode startMemberNode = null;
        double startMinorTotalOffset = -1;
        ISpanReleases startReleases = null;
        SubEntityType type = SubEntityType.Unknown;
        double userLoadReductionFactorImposed = -1;

        if (memberSpan != null)
        {
            try
            {
                buildingDirection = memberSpan.BuildingDirection.Value;
            }
            catch (Exception)
            {
                buildingDirection = buildingDirection;
            }

            try
            {
                checkResultType = memberSpan.CheckResults.Value.FirstOrDefault().Key;
            }
            catch (Exception)
            {
                checkResultType = checkResultType;
            }

            try
            {
                icheckResult = memberSpan?.CheckResults?.Value?.FirstOrDefault()?.Value?.Value;
            }
            catch (Exception)
            {
                icheckResult = icheckResult;
            }

            try
            {
                concreteDensityClass = memberSpan.ConcreteDensityClass.Value;
            }
            catch (Exception)
            {
                concreteDensityClass = concreteDensityClass;
            }

            try
            {
                concreteType = memberSpan.ConcreteType.Value;
            }
            catch (Exception)
            {
                concreteType = concreteType;
            }

            try
            {
                curvedEccentricity = memberSpan.CurvedEccentricity.Value;
            }
            catch (Exception)
            {
                curvedEccentricity = curvedEccentricity;
            }

            try
            {
                curvedOption = memberSpan.CurvedOption.Value;
            }
            catch (Exception)
            {
                curvedOption = curvedOption;
            }

            try
            {
                data = memberSpan.Data.Value;
            }
            catch (Exception)
            {
                data = data;
            }

            try
            {
                designSegment = memberSpan.DesignSegment.Value;
            }
            catch (Exception)
            {
                designSegment = designSegment;
            }

            try
            {
                elementSection = (memberSpan.ElementSection.Value as IMemberSection);
            }
            catch (Exception)
            {
                elementSection = elementSection;
            }

            try
            {
                endMajorTotalOffset = memberSpan.EndMajorTotalOffset.Value;
            }
            catch (Exception)
            {
                endMajorTotalOffset = endMajorTotalOffset;
            }

            try
            {
                endMemberNode = memberSpan.EndMemberNode;
            }
            catch (Exception)
            {
                endMemberNode = endMemberNode;
            }

            try
            {
                endMinorTotalOffset = memberSpan.EndMinorTotalOffset.Value;
            }
            catch (Exception)
            {
                endMinorTotalOffset = endMinorTotalOffset;
            }

            try
            {
                endReleases = memberSpan.EndReleases.Value;
            }
            catch (Exception)
            {
                endReleases = endReleases;
            }

            try
            {
                entityId = memberSpan.EntityId;
            }
            catch (Exception)
            {
                entityId = entityId;
            }

            try
            {
                entityIndex = memberSpan.EntityIndex;
            }
            catch (Exception)
            {
                entityIndex = entityIndex;
            }

            try
            {
                entityType = memberSpan.EntityType;
            }
            catch (Exception)
            {
                entityType = entityType;
            }

            try
            {
                globalRotationAngle = memberSpan.GlobalRotationAngle.Value;
            }
            catch (Exception)
            {
                globalRotationAngle = globalRotationAngle;
            }

            try
            {
                id = memberSpan.Id;
            }
            catch (Exception)
            {
                id = id;
            }

            try
            {
                index = memberSpan.Index;
            }
            catch (Exception)
            {
                index = index;
            }

            try
            {
                isSectionAwaitingDesign = memberSpan.IsSectionAwaitingDesign.Value;
            }
            catch (Exception)
            {
                isSectionAwaitingDesign = isSectionAwaitingDesign;
            }

            try
            {
                kll = memberSpan.Kll.Value;
            }
            catch (Exception)
            {
                kll = kll;
            }

            try
            {
                length = memberSpan.Length.Value;
            }
            catch (Exception)
            {
                length = length;
            }

            try
            {
                material = memberSpan.Material.Value;
            }
            catch (Exception)
            {
                material = material;
            }

            try
            {
                maxFacetError = memberSpan.MaxFacetError.Value;
            }
            catch (Exception)
            {
                maxFacetError = maxFacetError;
            }

            try
            {
                name = memberSpan.Name;
            }
            catch (Exception)
            {
                name = name;
            }

            try
            {
                rotationAngle = memberSpan.RotationAngle.Value;
            }
            catch (Exception)
            {
                rotationAngle = rotationAngle;
            }

            try
            {
                rotationOption = memberSpan.RotationOption.Value;
            }
            catch (Exception)
            {
                rotationOption = rotationOption;
            }

            try
            {
                startMajorTotalOffset = memberSpan.StartMajorTotalOffset.Value;
            }
            catch (Exception)
            {
                startMajorTotalOffset = startMajorTotalOffset;
            }

            try
            {
                startMemberNode = memberSpan.StartMemberNode;
            }
            catch (Exception)
            {
                startMemberNode = startMemberNode;
            }

            try
            {
                startMinorTotalOffset = memberSpan.StartMinorTotalOffset.Value;
            }
            catch (Exception)
            {
                startMinorTotalOffset = startMinorTotalOffset;
            }

            try
            {
                startReleases = memberSpan.StartReleases.Value;
            }
            catch (Exception)
            {
                startReleases = startReleases;
            }

            try
            {
                type = memberSpan.Type;
            }
            catch (Exception)
            {
                type = type;
            }

            try
            {
                userLoadReductionFactorImposed = memberSpan.UserLoadReductionFactorImposed.Value;
            }
            catch (Exception)
            {
                userLoadReductionFactorImposed = userLoadReductionFactorImposed;
            }
        }

        // Set data
        DA.SetData(0, buildingDirection);
        DA.SetData(1, checkResultType);
        DA.SetData(2, icheckResult);
        DA.SetData(3, concreteDensityClass);
        DA.SetData(4, concreteType);
        DA.SetData(5, curvedEccentricity);
        DA.SetData(6, curvedOption);
        DA.SetData(7, data);
        DA.SetData(8, designSegment);
        DA.SetData(9, elementSection);
        DA.SetData(10, endMajorTotalOffset);
        DA.SetData(11, endMemberNode);
        DA.SetData(12, endMinorTotalOffset);
        DA.SetData(13, endReleases);
        DA.SetData(14, entityId);
        DA.SetData(15, entityIndex);
        DA.SetData(16, entityType);
        DA.SetData(17, globalRotationAngle);
        DA.SetData(18, id);
        DA.SetData(19, index);
        DA.SetData(20, isSectionAwaitingDesign);
        DA.SetData(21, kll);
        DA.SetData(22, length);
        DA.SetData(23, material);
        DA.SetData(24, maxFacetError);
        DA.SetData(25, name);
        DA.SetData(26, rotationAngle);
        DA.SetData(27, rotationOption);
        DA.SetData(28, startMajorTotalOffset);
        DA.SetData(29, startMemberNode);
        DA.SetData(30, startMinorTotalOffset);
        DA.SetData(31, startReleases);
        DA.SetData(32, type);
        DA.SetData(33, userLoadReductionFactorImposed);
    }

    public override GH_Exposure Exposure
    {
        get { return GH_Exposure.primary; }
    }

    protected override System.Drawing.Bitmap Icon
    {
        get
        {
            // You can add an icon image here
            return TSD_API_ver101.Properties.Resources.API_icon;
        }
    }

    public override Guid ComponentGuid
    {
        get { return new Guid("C63D5CD3-9723-40FB-AA20-6E3DE70E3D09"); }
    }
}
