using System;
using Grasshopper.Kernel;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;

public class Explode_ISpanReleasesComponent : GH_Component
{
    public Explode_ISpanReleasesComponent()
      : base("Explode_ISpanReleases", "E_ISpanReleases",
          "Explodes an ISpanReleases object into its properties",
          "TSD_API", "Exploding_functions")
    {
    }

    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
        pManager.AddGenericParameter("ISpanReleases", "ISR", "The ISpanReleases object to explode", GH_ParamAccess.item);
    }

    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
        pManager.AddGenericParameter("AxialRelease", "AR", "Indicates whether the end has axial release", GH_ParamAccess.item);
        pManager.AddGenericParameter("Cantilever", "C", "Indicates whether the end is cantilever", GH_ParamAccess.item);
        pManager.AddGenericParameter("DegreeOfFreedom", "DoF", "Gets the DegreeOfFreedom", GH_ParamAccess.item);
        pManager.AddGenericParameter("MajorRotationalStiffness", "MRS", "Gets the major rotational IStiffnessData", GH_ParamAccess.item);
        pManager.AddGenericParameter("MinorRotationalStiffness", "mRS", "Gets the minor rotational IStiffnessData", GH_ParamAccess.item);
        pManager.AddGenericParameter("TorsionalRelease", "TR", "Indicates whether the end has torsional release", GH_ParamAccess.item);
    }

    protected override void SolveInstance(IGH_DataAccess DA)
    {
        ISpanReleases spanReleases = null;
        if (!DA.GetData(0, ref spanReleases))
            return;

        // Default values
        bool axialRelease = false;
        bool cantilever = false;
        DegreeOfFreedom degreeOfFreedom = DegreeOfFreedom.Free;
        IStiffnessData majorRotationalStiffness = null;
        IStiffnessData minorRotationalStiffness = null;
        bool torsionalRelease = false;

        if (spanReleases != null)
        {
            axialRelease = spanReleases.AxialRelease.IsApplicable == true ? spanReleases.AxialRelease.Value: false ;
            cantilever = spanReleases.Cantilever.IsApplicable == true ? spanReleases.Cantilever.Value : false ;
            degreeOfFreedom = spanReleases.DegreeOfFreedom.IsApplicable == true? spanReleases.DegreeOfFreedom.Value: DegreeOfFreedom.Free;
            majorRotationalStiffness = spanReleases?.MajorRotationalStiffness?.IsApplicable == true ? spanReleases.MajorRotationalStiffness.Value : null;
            minorRotationalStiffness = spanReleases?.MinorRotationalStiffness?.IsApplicable == true ? spanReleases.MinorRotationalStiffness.Value : null;
            torsionalRelease = spanReleases.TorsionalRelease.IsApplicable == true ? spanReleases.TorsionalRelease.Value : false;
        }

        // Set data
        DA.SetData(0, axialRelease);
        DA.SetData(1, cantilever);
        DA.SetData(2, degreeOfFreedom);
        DA.SetData(3, majorRotationalStiffness);
        DA.SetData(4, minorRotationalStiffness);
        DA.SetData(5, torsionalRelease);
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
        get { return new Guid("9DFAD6B2-CCE4-4A03-9C9C-6BF7ED781BFB"); }
    }
}
