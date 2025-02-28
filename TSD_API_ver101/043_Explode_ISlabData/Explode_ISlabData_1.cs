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
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_ISlabData_Explode
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_ISlabData_1", "E_ISlabData_1",
            "Exploding the ISlabData ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ISlabData", "ISlabData", "Input ISlabData", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("AnalyseSlab", "AnalyseSlab", "Gets a value indicating whether the slab is analysed", GH_ParamAccess.item);
            pManager.AddGenericParameter("ConcreteDensityClass", "DensityClass", "Gets the concrete density class", GH_ParamAccess.item);
            pManager.AddGenericParameter("ConcreteDryDensity", "DryDensity", "Gets the concrete dry density (in [kg/mm³])", GH_ParamAccess.item);
            pManager.AddGenericParameter("ConcreteDryWeightPerArea", "DryWeightPerArea", "Gets the dry weight per area (in [N/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("ConcreteType", "ConcreteType", "Gets the concrete type", GH_ParamAccess.item);
            pManager.AddGenericParameter("ConcreteWetDensity", "WetDensity", "Gets the concrete wet density (in [kg/mm³])", GH_ParamAccess.item);
            pManager.AddGenericParameter("ConcreteWetWeightPerArea", "WetWeightPerArea", "Gets the wet weight per area (in [N/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Deck", "Deck", "Gets the deck", GH_ParamAccess.item);
            pManager.AddGenericParameter("DeckType", "DeckType", "Gets the deck type", GH_ParamAccess.item);
            pManager.AddGenericParameter("DecompositionType", "DecompositionType", "Gets the decomposition type", GH_ParamAccess.item);
            pManager.AddGenericParameter("Depth", "Depth", "Gets the depth of the slab (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("DiaphragmOption", "DiaphragmOption", "Gets the diaphragm option", GH_ParamAccess.item);
            pManager.AddGenericParameter("LongTermMultiple", "LongTermMultiple", "Gets the factor by which the short term elastic modulus is divided to obtain the long term modulus", GH_ParamAccess.item);
            pManager.AddGenericParameter("IMaterial", "IMaterial", "Gets the IMaterial", GH_ParamAccess.item);
            pManager.AddGenericParameter("ShortTermElasticModulus", "ShortTermE", "Gets the short term elastic modulus (in [N/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("SlabType", "SlabType", "Gets the type of the slab", GH_ParamAccess.item);
            pManager.AddGenericParameter("ToppingDepth", "ToppingDepth", "Gets the depth of topping (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("ToppingOption", "ToppingOption", "Gets the type of topping", GH_ParamAccess.item);
            pManager.AddGenericParameter("UserDefinedMaterial", "UserDefinedMaterial", "Gets the user-defined material", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Structure.ISlabData input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.

            bool output_analyseSlab = false;
            ConcreteDensityClass output_concreteDensityClass = ConcreteDensityClass.Unknown;
            double output_concreteDryDensity = -1.0;
            double output_concreteDryWeightPerArea = -1.0;
            ConcreteType output_concreteType = ConcreteType.Unknown;
            double output_concreteWetDensity = -1.0;
            double output_concreteWetWeightPerArea = -1.0;
            IDeck output_deck = null;
            DeckType output_deckType = DeckType.Unknown;
            DecompositionType output_decompositionType = DecompositionType.Unknown;
            double output_depth = -1.0;
            DiaphragmOption output_diaphragmOption = DiaphragmOption.Unknown;
            double output_longTermMultiple = -1.0;
            IMaterial output_material = null;
            double output_shortTermElasticModulus = -1.0;
            SlabType output_slabType = SlabType.Unknown;
            double output_toppingDepth = -1.0;
            ToppingOption output_toppingOption = ToppingOption.None;
            IUserDefinedMaterial output_userDefinedMaterial = null;

            if (input_1 != null)
            {
                // Check each property before accessing it
                // Assuming 'input_1' is your input object which contains the required properties.
                if (output_decompositionType == DecompositionType.OneWay)
                {output_analyseSlab = input_1.AnalyseSlab.Value;}
                else{ output_analyseSlab = true; }


                try { output_concreteDensityClass = input_1.ConcreteDensityClass.Value; }
                catch { output_concreteDensityClass = ConcreteDensityClass.Unknown; }

                try { output_concreteDryDensity = input_1.ConcreteDryDensity.Value; }
                catch { output_concreteDryDensity = 0.0; }
                

                try
                {
                    output_concreteDryWeightPerArea = input_1.ConcreteDryWeightPerArea.Value;
                }
                catch(Exception ex)
                {
                    output_concreteDryWeightPerArea = 0.0;
                }

                try { output_concreteType = input_1.ConcreteType.Value; }
                catch { output_concreteType = ConcreteType.Unknown; }

                try { output_concreteWetDensity = input_1.ConcreteWetDensity.Value; }
                catch { output_concreteWetDensity= 0.0; }


                try { output_concreteWetWeightPerArea = input_1.ConcreteWetWeightPerArea.Value; }
                catch { output_concreteWetWeightPerArea = 0.0; }
                

                try { output_deck = input_1.Deck.Value; }
                catch { output_deck = null; }


                try { output_deckType = input_1.DeckType.Value; }
                catch { output_deckType = DeckType.Unknown; }


                try { output_decompositionType = input_1.DecompositionType.Value; }
                catch { output_decompositionType = DecompositionType.Unknown; }

                try { output_depth = input_1.Depth.Value; }
                catch { output_depth = 0.0; }

                try { output_diaphragmOption = input_1.DiaphragmOption.Value; }
                catch { output_diaphragmOption = DiaphragmOption.Unknown; }

                try { output_longTermMultiple = input_1.LongTermMultiple.Value; }
                catch { output_longTermMultiple = 0.0; }

                try { output_material = input_1.Material.Value; }
                catch { output_material = null; }

                try { output_shortTermElasticModulus = input_1.ShortTermElasticModulus.Value; }
                catch { output_shortTermElasticModulus = 0.0; }

                try { output_slabType = input_1.SlabType.Value; }
                catch { output_slabType = SlabType.Unknown; }

                try { output_toppingOption = input_1.ToppingOption.Value; }
                catch { output_toppingOption = ToppingOption.Unknown; }

                try { output_toppingDepth = input_1.ToppingDepth.Value; }
                catch { output_toppingDepth= 0.0; }

                try { output_userDefinedMaterial = input_1.UserDefinedMaterial.Value; }
                catch { output_userDefinedMaterial = null; }
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");
            }

            // Setting the output parameters
            DA.SetData(0, output_analyseSlab);
            DA.SetData(1, output_concreteDensityClass);
            DA.SetData(2, output_concreteDryDensity);
            DA.SetData(3, output_concreteDryWeightPerArea);
            DA.SetData(4, output_concreteType);
            DA.SetData(5, output_concreteWetDensity);
            DA.SetData(6, output_concreteWetWeightPerArea);
            DA.SetData(7, output_deck);
            DA.SetData(8, output_deckType);
            DA.SetData(9, output_decompositionType);
            DA.SetData(10, output_depth);
            DA.SetData(11, output_diaphragmOption);
            DA.SetData(12, output_longTermMultiple);
            DA.SetData(13, output_material);
            DA.SetData(14, output_shortTermElasticModulus);
            DA.SetData(15, output_slabType);
            DA.SetData(16, output_toppingDepth);
            DA.SetData(17, output_toppingOption);
            DA.SetData(18, output_userDefinedMaterial);
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
            get { return new Guid("A39F6C0F-463C-48FA-8ED4-9C2B98621ACD"); }
        }

    }

}












