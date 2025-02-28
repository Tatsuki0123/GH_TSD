using System;
using Grasshopper.Kernel;
using TSD.API.Remoting.Common.Interfaces;
using TSD_API_ver101.Properties;

public class Explode_ISelectedEntity : GH_Component
{
    public Explode_ISelectedEntity()
      : base("Explode_ISelectedEntity", "E_ISelectedEntity",
          "Explodes an ISelectedEntity object to expose its properties.",
          "TSD_API", "Exploding_functions")
    {
    }

    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        pManager.AddGenericParameter("ISelectedEntity", "Entity", "Input ISelectedEntity object to explode.", GH_ParamAccess.item);
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
        pManager.AddGenericParameter("Entity", "Entity", "Gets the selected entity info", GH_ParamAccess.item);
        pManager.AddGenericParameter("Type", "Type", "Gets the type of the selection", GH_ParamAccess.item);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
        ISelectedEntity selectedEntity = null;
        if (!DA.GetData(0, ref selectedEntity)) return;

        if (selectedEntity != null)
        {
            DA.SetData("Entity", selectedEntity.Entity);
            DA.SetData("Type", selectedEntity.Type);
        }
        else
        {
            AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Invalid ISelectedEntity input.");
        }
    }

    public override GH_Exposure Exposure => GH_Exposure.primary;
    protected override System.Drawing.Bitmap Icon => Resources.API_icon;
    public override Guid ComponentGuid => new Guid("D7743432-24A0-46AC-9F44-2630653BF7BF");
}
