using System;
using Grasshopper.Kernel;
using TSD.API.Remoting.Structure;

public class ExplodeIMemberNodeComponent : GH_Component
{
    public ExplodeIMemberNodeComponent()
      : base("Explode_IMemberNode", "E_IMemberNode",
          "Explodes an IMemberNode object into its properties",
          "TSD_API", "Exploding_functions")
    {
    }

    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        pManager.AddGenericParameter("IMemberNode", "IMN", "The IMemberNode object to explode", GH_ParamAccess.item);
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
        pManager.AddBooleanParameter("ApplyImposedLoadReduction", "AILR", "Indicates whether to apply the imposed load reduction at the column floor", GH_ParamAccess.item);
        pManager.AddIntegerParameter("ConstructionPointIndex", "CPI", "The index of the construction point", GH_ParamAccess.item);
        pManager.AddBooleanParameter("CountFloorAsBeingSupported", "CFABS", "Indicates whether to count the column floor as being supported", GH_ParamAccess.item);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
        IMemberNode memberNode = null;
        if (!DA.GetData(0, ref memberNode))
            return;

        // Default values
        bool applyImposedLoadReduction = false;
        int constructionPointIndex = -1;
        bool countFloorAsBeingSupported = false;

        if (memberNode != null)
        {
            try
            {
                applyImposedLoadReduction = memberNode.ApplyImposedLoadReduction.Value;
            }
            catch
            {
                applyImposedLoadReduction = applyImposedLoadReduction; // or some appropriate default value
            }

            try
            {
                constructionPointIndex = memberNode.ConstructionPointIndex.Value;
            }
            catch
            {
                constructionPointIndex = constructionPointIndex; // or some appropriate default value
            }

            try
            {
                countFloorAsBeingSupported = memberNode.CountFloorAsBeingSupported.Value;
            }
            catch
            {
                countFloorAsBeingSupported = countFloorAsBeingSupported; // or some appropriate default value
            }

        }

        // Set data
        DA.SetData(0, applyImposedLoadReduction);
        DA.SetData(1, constructionPointIndex);
        DA.SetData(2, countFloorAsBeingSupported);
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
        get { return new Guid("071F6E53-B90A-46A7-B1BE-09E80A04FB15"); }
    }
}
