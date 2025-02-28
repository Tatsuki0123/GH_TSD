using System;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Reinforcement;

namespace TSD_API_ver101_IReinforcementShape_Explode
{
    public class Explode_IReinforcementShape : GH_Component
    {
        public Explode_IReinforcementShape()
          : base("Explode_IReinforcementShape_1", "ExplodeReinShape_1",
            "Explodes an IReinforcementShape into its properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IReinforcementShape", "IRS", "Input IReinforcementShape", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Code", "C", "Gets a country- or head code-specific code of the shape", GH_ParamAccess.item);
            pManager.AddGenericParameter("HasBobs", "HB", "Gets a value indicating whether this shape has bobs", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsLink", "IL", "Gets a value indicating whether the shape applies to a shear link", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsUBar", "IUB", "Gets a value indicating whether this shape represents a U-bar (simple or with a crank)", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsUserDefined", "IUD", "Gets a value indicating whether the shape is user-defined", GH_ParamAccess.item);
            pManager.AddGenericParameter("Reference", "Ref", "Gets a unique identifier of the shape", GH_ParamAccess.item);
            pManager.AddGenericParameter("Type", "T", "Gets the type of the shape", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IReinforcementShape inputReinforcementShape = null;

            if (!DA.GetData(0, ref inputReinforcementShape)) return;

            var code = inputReinforcementShape.Code;
            var hasBobs = inputReinforcementShape.HasBobs;
            var isLink = inputReinforcementShape.IsLink;
            var isUBar = inputReinforcementShape.IsUBar;
            var isUserDefined = inputReinforcementShape.IsUserDefined;
            var reference = inputReinforcementShape.Reference;
            var type = inputReinforcementShape.Type;

            DA.SetData(0, code);
            DA.SetData(1, hasBobs);
            DA.SetData(2, isLink);
            DA.SetData(3, isUBar);
            DA.SetData(4, isUserDefined);
            DA.SetData(5, reference);
            DA.SetData(6, type);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("8A90EEB9-85D0-4B16-9A25-7562CABE8EA0");
    }
}
