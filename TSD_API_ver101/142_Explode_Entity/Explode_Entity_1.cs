using System;
using Grasshopper.Kernel;
using TSD.API.Remoting.Common;

public class Explode_EntityInfo : GH_Component
{
    public Explode_EntityInfo()
      : base("Explode_EntityInfo", "E_EntityInfo",
          "Explodes an EntityInfo structure to expose its properties.",
          "TSD_API", "Exploding_functions")
    {
    }

    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        pManager.AddGenericParameter("EntityInfo", "EntityInfo", "Input EntityInfo structure to explode.", GH_ParamAccess.item);
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
        pManager.AddGenericParameter("Id", "Id", "Gets the Id of the entity", GH_ParamAccess.item);
        pManager.AddGenericParameter("Index", "Index", "Gets or sets the index of the entity", GH_ParamAccess.item);
        pManager.AddGenericParameter("Type", "Type", "Gets or sets the EntityType", GH_ParamAccess.item);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
        EntityInfo entityInfo = default;
        if (!DA.GetData(0, ref entityInfo)) return;

        DA.SetData("Id", entityInfo.Id);
        DA.SetData("Index", entityInfo.Index);
        DA.SetData("Type", entityInfo.Type);
    }

    public override GH_Exposure Exposure => GH_Exposure.primary;
    protected override System.Drawing.Bitmap Icon
    {
        get
        {
            //You can add image files to your project resources and access them like this:
            // return Resources.IconForThisComponent;
            return TSD_API_ver101.Properties.Resources.API_icon;
        }
    }
    public override Guid ComponentGuid => new Guid("2E8F1E71-6EF0-4EA8-BB16-6E8CF0658BE8");
}
