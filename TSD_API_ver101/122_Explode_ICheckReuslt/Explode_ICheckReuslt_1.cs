using System;
using Grasshopper.Kernel;
using TSD.API.Remoting.Common;

public class Explode_ICheckResultComponent : GH_Component
{
    public Explode_ICheckResultComponent()
      : base("Explode_ICheckResult", "E_ICheckResult",
          "Explodes an ICheckResult object into its properties",
          "TSD_API", "Exploding_functions")
    {
    }

    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        pManager.AddGenericParameter("ICheckResult", "ICR", "The ICheckResult object to explode", GH_ParamAccess.item);
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
        pManager.AddTextParameter("CheckStatus", "CS", "Gets the check status", GH_ParamAccess.item);
        pManager.AddNumberParameter("UtilizationRatio", "UR", "Gets the utilization ratio", GH_ParamAccess.item);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
        ICheckResult checkResult = null;
        if (!DA.GetData(0, ref checkResult))
            return;

        // Default values
        CheckStatus checkStatus = CheckStatus.Unknown;
        double utilizationRatio = 0.0;

        if (checkResult != null)
        {
            checkStatus = checkResult.CheckStatus.Value;
            utilizationRatio = checkResult.UtilizationRatio.Value;
        }

        // Set data
        DA.SetData(0, checkStatus);
        DA.SetData(1, utilizationRatio);
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
        get { return new Guid("BC133A41-1589-4C9F-A83C-10153769979B"); }
    }
}
