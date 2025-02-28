using System;
using Grasshopper.Kernel;
using TSD.API.Remoting.Structure;
using TSD_API_ver101.Properties;

public class Explode_SubEntityInfo : GH_Component
{
    public Explode_SubEntityInfo()
      : base("Explode_SubEntityInfo", "E_SubEntityInfo",
          "Explodes a SubEntityInfo structure to expose its properties.",
          "TSD_API", "Exploding_functions")
    {
    }

    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        pManager.AddGenericParameter("SubEntityInfo", "SubEntityInfo", "Input SubEntityInfo structure to explode.", GH_ParamAccess.item);
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
        pManager.AddGenericParameter("EntityId", "EntityId", "ID of the parent entity", GH_ParamAccess.item);
        pManager.AddGenericParameter("EntityIndex", "EntityIndex", "Index of the parent entity", GH_ParamAccess.item);
        pManager.AddGenericParameter("EntityType", "EntityType", "Type of the parent entity", GH_ParamAccess.item);
        pManager.AddGenericParameter("Id", "Id", "ID of the sub-entity", GH_ParamAccess.item);
        pManager.AddGenericParameter("Index", "Index", "Index of the sub-entity", GH_ParamAccess.item);
        pManager.AddGenericParameter("Type", "Type", "Type of the sub-entity", GH_ParamAccess.item);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
        SubEntityInfo subEntityInfo = default;
        if (!DA.GetData(0, ref subEntityInfo)) return;

        DA.SetData("EntityId", subEntityInfo.EntityId);
        DA.SetData("EntityIndex", subEntityInfo.EntityIndex);
        DA.SetData("EntityType", subEntityInfo.EntityType);
        DA.SetData("Id", subEntityInfo.Id);
        DA.SetData("Index", subEntityInfo.Index);
        DA.SetData("Type", subEntityInfo.Type);
    }

    public override GH_Exposure Exposure => GH_Exposure.primary;
    protected override System.Drawing.Bitmap Icon => Resources.API_icon;
    public override Guid ComponentGuid => new Guid("5B47A4FB-3800-40C2-BBC4-D0017D731169") ;
}
