using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using GH_IO.Types;
using Google.Protobuf.WellKnownTypes;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Geometry;
using Grasshopper.Kernel.Parameters.Hints;
using Grasshopper.Kernel.Types;
using Rhino.DocObjects;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Common.Properties;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Materials;
using TSD.API.Remoting.Reinforcement;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_IMemberData
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_IMemberData_1", "E_IMemberData_1",
            "Exploding the IMemberData_1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IMemberData", "IMemberData", "Input IMemberData", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Active", "Active", "Gets a value indicating whether the member is active", GH_ParamAccess.item);
            pManager.AddGenericParameter("Alignment", "Alignment", "Gets the ISpanAlignment", GH_ParamAccess.item);
            pManager.AddGenericParameter("AllowAutomaticJoinAtEnd", "AllowAutoJoinEnd", "Gets a value indicating whether the member automatically joins at end", GH_ParamAccess.item);
            pManager.AddGenericParameter("AllowAutomaticJoinAtStart", "AllowAutoJoinStart", "Gets a value indicating whether the member automatically joins at start", GH_ParamAccess.item);
            pManager.AddGenericParameter("AutoDesign", "AutoDesign", "Gets a value indicating whether sections from the design section order will be considered during the design process", GH_ParamAccess.item);
            pManager.AddGenericParameter("AutoDesignOption", "AutoDesignOpt", "Gets the AutoDesignOption", GH_ParamAccess.item);
            pManager.AddGenericParameter("Construction", "Construction", "Gets the MemberConstruction", GH_ParamAccess.item);
            pManager.AddGenericParameter("ElementType", "ElementType", "Gets the ElementType", GH_ParamAccess.item);
            pManager.AddGenericParameter("Fabrication", "Fabrication", "Gets the MemberFabrication", GH_ParamAccess.item);
            pManager.AddGenericParameter("GravityOnly", "GravityOnly", "Gets a value indicating whether the beam is designed for gravity combinations only", GH_ParamAccess.item);
            pManager.AddGenericParameter("LinkReinforcementGrade", "LinkReinGrade", "Gets the links reinforcement grade", GH_ParamAccess.item);
            pManager.AddGenericParameter("LinkReinforcementGradeName", "LinkReinGradeName", "Gets the links reinforcement grade Name", GH_ParamAccess.item);
            pManager.AddGenericParameter("LinkReinforcementRibType", "LinkReinRibType", "Gets the links rib type", GH_ParamAccess.item);
            pManager.AddGenericParameter("MainReinforcementGrade", "MainReinGrade", "Gets the longitudinal bars reinforcement grade", GH_ParamAccess.item);
            pManager.AddGenericParameter("MainReinforcementGradeName", "MainReinGradeName", "Gets the longitudinal bars reinforcement grade Name", GH_ParamAccess.item);
            pManager.AddGenericParameter("MainReinforcementRibType", "MainReinRibType", "Gets the longitudinal bars rib type", GH_ParamAccess.item);
            pManager.AddGenericParameter("MaterialType", "MaterialType", "Gets the MaterialType", GH_ParamAccess.item);
            pManager.AddGenericParameter("MemberType", "MemberType", "Gets the MemberType", GH_ParamAccess.item);
            pManager.AddGenericParameter("RotationAngle", "RotationAngle", "Gets the rotation angle of the member (in [rad])", GH_ParamAccess.item);
            pManager.AddGenericParameter("RotationOption", "RotationOpt", "Gets the RotationOption", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Structure.IMemberData input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.

            bool output_active = false;
            ISpanAlignment output_alignment = null;
            bool output_allowAutomaticJoinAtEnd = false;
            bool output_allowAutomaticJoinAtStart = false;
            bool output_autoDesign = false;
            AutoDesignOption output_autoDesignOption = AutoDesignOption.Unknown;
            MemberConstruction output_construction = MemberConstruction.Unknown;
            ElementType output_elementType = ElementType.Unknown;
            MemberFabrication output_fabrication = MemberFabrication.Unknown;
            bool output_gravityOnly = false;
            IReinforcementGrade output_linkReinforcementGrade = null;
            string output_linkReinforcementGrade_name = string.Empty;
            ReinforcementRibType output_linkReinforcementRibType = ReinforcementRibType.Unknown;
            IReinforcementGrade output_mainReinforcementGrade = null;
            string output_mainReinforcementGrade_name = string.Empty;
            ReinforcementRibType output_mainReinforcementRibType = ReinforcementRibType.Unknown;
            MaterialType output_materialType = MaterialType.Unknown;
            MemberType output_memberType = MemberType.Unknown;
            double output_rotationAngle = 0.0;
            RotationOption output_rotationOption = RotationOption.Unknown;

            if (input_1 != null)
            {
                // Check each property before accessing it
                try { output_active = input_1.Active.Value; }
                catch { output_active = true; }

                try { output_alignment = input_1.Alignment.Value; }
                catch { output_alignment = null; }

                try { output_allowAutomaticJoinAtEnd = input_1.AllowAutomaticJoinAtEnd.Value; }
                catch { output_allowAutomaticJoinAtEnd = false; }

                try { output_allowAutomaticJoinAtStart = input_1.AllowAutomaticJoinAtStart.Value; }
                catch { output_allowAutomaticJoinAtStart = false; }

                try { output_autoDesign = input_1.AutoDesign.Value; }
                catch { output_autoDesign = false; }

                try { output_autoDesignOption = input_1.AutoDesignOption.Value; }
                catch { output_autoDesignOption = AutoDesignOption.Unknown; }

                try { output_construction = input_1.Construction.Value; }
                catch { output_construction = MemberConstruction.Unknown; }

                try { output_elementType = input_1.ElementType.Value; }
                catch { output_elementType = ElementType.Unknown; }

                try { output_fabrication = input_1.Fabrication.Value; }
                catch { output_fabrication = MemberFabrication.Unknown; }

                try { output_gravityOnly = input_1.GravityOnly.Value; }
                catch { output_gravityOnly = false; }

                try { output_linkReinforcementGrade = input_1.LinkReinforcementGrade.Value; }
                catch { output_linkReinforcementGrade = null; }

                try { output_linkReinforcementGrade_name = output_linkReinforcementGrade?.Name; }
                catch { output_linkReinforcementGrade_name = string.Empty; }

                try { output_linkReinforcementRibType = input_1.LinkReinforcementRibType.Value; }
                catch { output_linkReinforcementRibType = ReinforcementRibType.Unknown; }

                try { output_mainReinforcementGrade = input_1.MainReinforcementGrade.Value; }
                catch { output_mainReinforcementGrade = null; }

                try { output_mainReinforcementGrade_name = output_mainReinforcementGrade?.Name; }
                catch { output_mainReinforcementGrade_name = string.Empty; }

                try { output_mainReinforcementRibType = input_1.MainReinforcementRibType.Value; }
                catch { output_mainReinforcementRibType = ReinforcementRibType.Unknown; }

                try { output_materialType = input_1.MaterialType.Value; }
                catch { output_materialType = MaterialType.Unknown; }

                try { output_memberType = input_1.MemberType.Value; }
                catch { output_memberType = MemberType.Unknown; }

                try { output_rotationAngle = input_1.RotationAngle.Value; }
                catch { output_rotationAngle = 0.0; }

                try { output_rotationOption = input_1.RotationOption.Value; }
                catch { output_rotationOption = RotationOption.Unknown; }
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "IMemberData is not provided or invalid.");
            }

            // Setting the output parameters
            DA.SetData(0, output_active);
            DA.SetData(1, output_alignment);
            DA.SetData(2, output_allowAutomaticJoinAtEnd);
            DA.SetData(3, output_allowAutomaticJoinAtStart);
            DA.SetData(4, output_autoDesign);
            DA.SetData(5, output_autoDesignOption);
            DA.SetData(6, output_construction);
            DA.SetData(7, output_elementType);
            DA.SetData(8, output_fabrication);
            DA.SetData(9, output_gravityOnly);
            DA.SetData(10, output_linkReinforcementGrade);
            DA.SetData(11, output_linkReinforcementGrade_name);
            DA.SetData(12, output_linkReinforcementRibType);
            DA.SetData(13, output_mainReinforcementGrade);
            DA.SetData(14, output_mainReinforcementGrade_name);
            DA.SetData(15, output_mainReinforcementRibType);
            DA.SetData(16, output_materialType);
            DA.SetData(17, output_memberType);
            DA.SetData(18, output_rotationAngle);
            DA.SetData(19, output_rotationOption);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return TSD_API_ver101.Properties.Resources.API_icon;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("D5BF3661-389E-439D-B350-A1179F28F700"); }
        }

    }
}
