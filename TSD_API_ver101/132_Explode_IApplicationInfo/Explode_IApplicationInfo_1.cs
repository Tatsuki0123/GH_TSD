using System;
using Grasshopper.Kernel;
using TSD.API.Remoting;

public class Explode_IApplicationInfo : GH_Component
{
    public Explode_IApplicationInfo()
      : base("Explode_IApplicationInfo", "E_IApplicationInfo",
             "Explodes the IApplicationInfo interface into its individual properties",
             "TSD_API", "Exploding_functions")
    {
    }

    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        pManager.AddGenericParameter("IApplicationInfo", "IA", "The IApplicationInfo object to explode", GH_ParamAccess.item);
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
        pManager.AddGenericParameter("HostName", "Host", "Gets the name of the host of the application", GH_ParamAccess.item);
        pManager.AddGenericParameter("Port", "Port", "Gets the number of the port the application runs on", GH_ParamAccess.item);
        pManager.AddGenericParameter("Title", "Title", "Gets the title of the application", GH_ParamAccess.item);
        pManager.AddGenericParameter("Version", "Version", "Gets the version of the application", GH_ParamAccess.item);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
        IApplicationInfo appInfo = null;

        if (!DA.GetData(0, ref appInfo) || appInfo == null)
        {
            AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid IApplicationInfo input.");
            return;
        }

        // Retrieve and output each property
        DA.SetData(0, appInfo.HostName);
        DA.SetData(1, appInfo.Port);
        DA.SetData(2, appInfo.Title);
        DA.SetData(3, appInfo.Version);
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
    public override Guid ComponentGuid => new Guid("E669BC40-0E5B-474D-81C0-D6B792982702");
}
