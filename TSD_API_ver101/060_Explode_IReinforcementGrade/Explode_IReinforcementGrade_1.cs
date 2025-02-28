using System;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Reinforcement;

namespace TSD_API_ver101_IReinforcementGrade_Explode
{
    public class Explode_IReinforcementGrade : GH_Component
    {
        public Explode_IReinforcementGrade()
          : base("Explode_IReinforcementGrade_1", "ExplodeReinGrade_1",
            "Explodes an IReinforcementGrade into its various properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IReinforcementGrade", "IRG", "Input IReinforcementGrade", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("DetailingPrefix", "DP", "Gets the detailing prefix", GH_ParamAccess.item);
            pManager.AddGenericParameter("ElasticModulus", "EM", "Gets the elastic modulus, E_{s} (in [N/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Geometry", "G", "Gets the geometry of the grade", GH_ParamAccess.item);
            pManager.AddGenericParameter("Id", "ID", "Gets the ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsUserDefined", "IUD", "Gets a value indicating whether the grade is user-defined", GH_ParamAccess.item);
            pManager.AddGenericParameter("Name", "N", "Gets the name", GH_ParamAccess.item);
            pManager.AddGenericParameter("PartialSafetyFactor", "PSF", "Gets the partial safety factor, gamma_{s} (unitless)", GH_ParamAccess.item);
            pManager.AddGenericParameter("RibType", "RT", "Gets the surface/rib type", GH_ParamAccess.item);
            pManager.AddGenericParameter("Strength", "S", "Gets the reinforcement strength, F_{yk} (in [N/mm²])", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IReinforcementGrade inputReinforcementGrade = null;

            if (!DA.GetData(0, ref inputReinforcementGrade)) return;

            var detailingPrefix = inputReinforcementGrade.DetailingPrefix;
            var elasticModulus = inputReinforcementGrade.ElasticModulus;
            var geometry = inputReinforcementGrade.Geometry;
            var id = inputReinforcementGrade.Id;
            var isUserDefined = inputReinforcementGrade.IsUserDefined;
            var name = inputReinforcementGrade.Name;
            var partialSafetyFactor = inputReinforcementGrade.PartialSafetyFactor;
            var ribType = inputReinforcementGrade.RibType;
            var strength = inputReinforcementGrade.Strength;

            DA.SetData(0, detailingPrefix);
            DA.SetData(1, elasticModulus);
            DA.SetData(2, geometry);
            DA.SetData(3, id);
            DA.SetData(4, isUserDefined);
            DA.SetData(5, name);
            DA.SetData(6, partialSafetyFactor);
            DA.SetData(7, ribType);
            DA.SetData(8, strength);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("3E627DAD-1753-4BBA-89E4-F006568A0B5C");
    }
}
