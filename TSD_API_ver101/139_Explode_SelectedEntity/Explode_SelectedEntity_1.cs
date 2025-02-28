using System;
using Grasshopper.Kernel;
using TSD.API.Remoting.Common.Interfaces;
using TSD_API_ver101.Properties;

public class Explode_ISelectedSubEntity : GH_Component
{
    public Explode_ISelectedSubEntity()
      : base("Explode_ISelectedSubEntity", "E_ISelectedSubEntity",
          "Explodes an ISelectedSubEntity object to expose its properties.",
          "TSD_API", "Exploding_functions")
    {
    }

    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        pManager.AddGenericParameter("ISelectedSubEntity", "SubEntity", "Input ISelectedSubEntity object to explode.", GH_ParamAccess.item);
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
        pManager.AddTextParameter("SubEntity", "SubEntity", "Gets the selected sub-entity info", GH_ParamAccess.item);
        pManager.AddTextParameter("Type", "Type", "Gets the type of the selection", GH_ParamAccess.item);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
        ISelectedSubEntity selectedSubEntity = null;
        if (!DA.GetData(0, ref selectedSubEntity)) return;

        if (selectedSubEntity != null)
        {
            DA.SetData("SubEntity", selectedSubEntity.SubEntity);
            DA.SetData("Type", selectedSubEntity.Type.ToString());
        }
        else
        {
            AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Invalid ISelectedSubEntity input.");
        }
    }

    public override GH_Exposure Exposure => GH_Exposure.primary;
    protected override System.Drawing.Bitmap Icon => Resources.API_icon;
    public override Guid ComponentGuid => new Guid("212ACC2F-5C0E-470D-929D-2B86628B8736");
}
