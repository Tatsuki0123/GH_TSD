using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using TSD.API.Remoting.Materials;
using TSD.API.Remoting.Structure;
using TSD_API_ver101_Choose_ConcreteDensityClass;

namespace TSD_API_ver101_IStructuralWallPanelData_Explode
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the Explode_IStructuralWallPanelData class.
        /// </summary>
        public Get_Instance()
          : base("Explode_IStructuralWallPanelData", "E_IStructuralWallPanelData",
            "Exploding the IStructuralWallPanelData interface",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IStructuralWallPanelData", "PanelData", "Input IStructuralWallPanelData", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Alignment", "Alignment", "This is the panel alignment", GH_ParamAccess.item);
            pManager.AddGenericParameter("Alignment Offset", "AlignmentOffset", "This is the alignment offset (in mm)", GH_ParamAccess.item);
            pManager.AddGenericParameter("Bottom Minor Release", "BottomMinorRelease", "This is the bottom minor release", GH_ParamAccess.item);
            pManager.AddGenericParameter("Concrete Density Class", "ConcreteDensity", "This is the panel's concrete density class", GH_ParamAccess.item);
            pManager.AddGenericParameter("Concrete Type", "ConcreteType", "This is the panel's concrete type", GH_ParamAccess.item);
            pManager.AddGenericParameter("Cracked Option", "CrackedOption", "This is the cracked option", GH_ParamAccess.item);
            pManager.AddGenericParameter("Extension Left End", "ExtensionLeftEnd", "This is the extension on the left side (in mm)", GH_ParamAccess.item);
            pManager.AddGenericParameter("Extension Right End", "ExtensionRightEnd", "This is the extension on the right side (in mm)", GH_ParamAccess.item);
            pManager.AddGenericParameter("Grout Spacing", "GroutSpacing", "This is the grout spacing for the masonry wall", GH_ParamAccess.item);
            pManager.AddGenericParameter("Grout Type", "GroutType", "This is the grout type for the masonry wall", GH_ParamAccess.item);
            pManager.AddGenericParameter("Material", "Material", "This is the panel material", GH_ParamAccess.item);
            pManager.AddGenericParameter("Nominal Cover", "NominalCover", "This is the nominal cover (in mm)", GH_ParamAccess.item);
            pManager.AddGenericParameter("Reinforcement Layers", "ReinforcementLayers", "This is the number of reinforcement layers", GH_ParamAccess.item);
            pManager.AddGenericParameter("Thickness", "Thickness", "This is the thickness of the panel (in mm)", GH_ParamAccess.item);
            pManager.AddGenericParameter("Top Minor Release", "TopMinorRelease", "This is the top minor release", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Declare input variables
            IStructuralWallPanelData inputPanelData = null;

            // Retrieve data from the input parameter
            if (!DA.GetData(0, ref inputPanelData)) return;

            // Initialize default output variables
            WallPanelAlignment output_alignment = WallPanelAlignment.Unknown;
            double output_alignmentOffset = -1;
            WallPanelReleaseType output_bottomMinorRelease = WallPanelReleaseType.Unknown;
            ConcreteDensityClass output_concreteDensity = ConcreteDensityClass.Unknown;
            ConcreteType output_concreteType = ConcreteType.Unknown;
            CrackedOption output_crackedOption = CrackedOption.Unknown;
            double output_extensionLeft = -1;
            double output_extensionRight = -1;
            double output_groutSpacing = -1;
            object output_groutType = "N.A";
            IMaterial output_material = null;
            double output_nominalCover = -1;
            int output_reinforcementLayers = -1;
            double output_thickness = -1;
            WallPanelReleaseType output_topMinorRelease = WallPanelReleaseType.Unknown;

            // Validate input and extract data
            if (inputPanelData != null)
            {
                output_alignment = inputPanelData.Alignment.Value;
                output_alignmentOffset = inputPanelData.AlignmentOffset.Value > 0 ? inputPanelData.AlignmentOffset.Value : -1;
                output_bottomMinorRelease = inputPanelData.BottomMinorRelease.IsApplicable ? inputPanelData.BottomMinorRelease.Value : WallPanelReleaseType.Unknown;
                output_concreteDensity = inputPanelData.ConcreteDensityClass.IsApplicable ? inputPanelData.ConcreteDensityClass.Value: ConcreteDensityClass.Unknown;
                output_concreteType = inputPanelData.ConcreteType.IsApplicable ? inputPanelData.ConcreteType.Value:  ConcreteType.Unknown;
                output_crackedOption = inputPanelData.CrackedOption.IsApplicable ? inputPanelData.CrackedOption.Value : CrackedOption.Unknown;
                output_extensionLeft = inputPanelData.ExtensionLeftEnd.IsApplicable ? inputPanelData.ExtensionLeftEnd.Value : -1;
                output_extensionRight = inputPanelData.ExtensionRightEnd.IsApplicable ? inputPanelData.ExtensionRightEnd.Value : -1;
                output_groutSpacing = inputPanelData.GroutSpacing.IsApplicable ? inputPanelData.GroutSpacing.Value : -1;
                output_groutType = inputPanelData.GroutType.IsApplicable ? inputPanelData.GroutType.Value: MasonryWallGroutType.Unknown;
                output_material = inputPanelData.Material.IsApplicable ? inputPanelData.Material.Value : null;
                output_nominalCover = inputPanelData.NominalCover.IsApplicable ? inputPanelData.NominalCover.Value : -1;
                output_reinforcementLayers = inputPanelData.ReinforcementLayers.IsApplicable ? inputPanelData.ReinforcementLayers.Value : -1;
                output_thickness = inputPanelData.Thickness.IsApplicable ? inputPanelData.Thickness.Value : -1;
                output_topMinorRelease = inputPanelData.TopMinorRelease.IsApplicable ? inputPanelData.TopMinorRelease.Value : WallPanelReleaseType.Unknown;
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "IStructuralWallPanelData is not valid.");
            }

            // Assign the output data
            DA.SetData(0, output_alignment);
            DA.SetData(1, output_alignmentOffset);
            DA.SetData(2, output_bottomMinorRelease);
            DA.SetData(3, output_concreteDensity);
            DA.SetData(4, output_concreteType);
            DA.SetData(5, output_crackedOption);
            DA.SetData(6, output_extensionLeft);
            DA.SetData(7, output_extensionRight);
            DA.SetData(8, output_groutSpacing);
            DA.SetData(9, output_groutType);
            DA.SetData(10, output_material);
            DA.SetData(11, output_nominalCover);
            DA.SetData(12, output_reinforcementLayers);
            DA.SetData(13, output_thickness);
            DA.SetData(14, output_topMinorRelease);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return TSD_API_ver101.Properties.Resources.API_icon;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("B4F6325F-EBFB-4BB3-9F2D-B85D9B3A0B4B"); }
        }
    }
}
