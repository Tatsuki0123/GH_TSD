using System;
using Grasshopper.Kernel;
using Rhino;
using Rhino.Geometry;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Geometry;
using TSD.API.Remoting.Materials;
using TSD.API.Remoting.Sections;

namespace TSD_API_ver101_INonParametricSection_Explode
{
    public class Explode_INonParametricSection : GH_Component
    {
        public Explode_INonParametricSection()
          : base("Explode_INonParametricSection_1", "E_INPS_1",
            "Explodes an INonParametricSection into its properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("INonParametricSection", "INPS", "Input INonParametricSection", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Country", "Country", "Gets the country this section belongs to", GH_ParamAccess.item);
            pManager.AddNumberParameter("CrossSectionalArea", "Area", "Gets the cross-sectional area (in mm²)", GH_ParamAccess.item);
            pManager.AddTextParameter("HeadCode", "HeadCode", "Gets the head code this section belongs to", GH_ParamAccess.item);
            pManager.AddTextParameter("LongName", "LongName", "Gets the long name of the section", GH_ParamAccess.item);
            pManager.AddNumberParameter("MajorAxisSecondMomentOfArea", "Ixx", "Gets the major axis second moment of area (in mm⁴)", GH_ParamAccess.item);
            pManager.AddTextParameter("MaterialType", "Material", "Gets the material type", GH_ParamAccess.item);
            pManager.AddNumberParameter("MinorAxisSecondMomentOfArea", "Iyy", "Gets the minor axis second moment of area (in mm⁴)", GH_ParamAccess.item);
            pManager.AddGenericParameter("SectionGeometry", "Geometry", "Gets the section geometry", GH_ParamAccess.item);
            pManager.AddTextParameter("SectionGroup", "Group", "Gets the section group", GH_ParamAccess.item);
            pManager.AddTextParameter("SectionType", "Type", "Gets the section type", GH_ParamAccess.item);
            pManager.AddNumberParameter("ShearAreaMajorAxis", "ShearAreaX", "Gets the shear area loaded parallel to the major axis (in mm²)", GH_ParamAccess.item);
            pManager.AddNumberParameter("ShearAreaMinorAxis", "ShearAreaY", "Gets the shear area loaded parallel to the minor axis (in mm²)", GH_ParamAccess.item);
            pManager.AddTextParameter("ShortName", "ShortName", "Gets the short name of the section", GH_ParamAccess.item);
            pManager.AddNumberParameter("TorsionConstant", "J", "Gets the torsion constant (in mm⁴)", GH_ParamAccess.item);
            pManager.AddTextParameter("UnitSystem", "UnitSystem", "Gets the unit system this section is defined in", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            INonParametricSection inputSection = null;

            if (!DA.GetData(0, ref inputSection)) return;

            Country country = inputSection.Country;
            double area = inputSection.CrossSectionalArea;
            HeadCode headCode = inputSection.HeadCode;
            string longName = inputSection.LongName;
            double Ixx = inputSection.MajorAxisSecondMomentOfArea;
            MaterialType materialType = inputSection.MaterialType;
            double Iyy = inputSection.MinorAxisSecondMomentOfArea;
            var geometry = inputSection.SectionGeometry;
            SectionGroup group = inputSection.SectionGroup;
            SectionType type = inputSection.SectionType;
            double shearAreaX = inputSection.ShearAreaLoadedParallelToMajorAxis;
            double shearAreaY = inputSection.ShearAreaLoadedParallelToMinorAxis;
            string shortName = inputSection.ShortName;
            double torsionConstant = inputSection.TorsionConstant;
            SystemType unitSystem = inputSection.UnitSystem;

            DA.SetData(0, country);
            DA.SetData(1, area);
            DA.SetData(2, headCode);
            DA.SetData(3, longName);
            DA.SetData(4, Ixx);
            DA.SetData(5, materialType);
            DA.SetData(6, Iyy);
            DA.SetData(7, geometry);
            DA.SetData(8, group);
            DA.SetData(9, type);
            DA.SetData(10, shearAreaX);
            DA.SetData(11, shearAreaY);
            DA.SetData(12, shortName);
            DA.SetData(13, torsionConstant);
            DA.SetData(14, unitSystem);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon; // You can set an icon here

        public override Guid ComponentGuid => new Guid("B09032DB-BB65-4846-BBBB-1513BFB91A15");
    }
}