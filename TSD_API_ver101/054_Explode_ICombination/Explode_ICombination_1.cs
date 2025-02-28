using System;
using System.Collections.Generic;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Common;
using System.Linq;

namespace TSD_API_ver101_ICombination_Explode
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_ICombination_1", "E_ICombination_1",
            "Exploding the ICombination ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ICombination", "ICombination", "Input ICombination", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("AppliesLiveLoadReductions", "LiveLoadReductions", "Gets a value indicating whether live load reductions are applied", GH_ParamAccess.item);
            pManager.AddGenericParameter("CombinationClass", "CombClass", "Gets the class of the combination", GH_ParamAccess.item);
            pManager.AddGenericParameter("CombinationSpeciality", "CombSpeciality", "Gets the speciality of the combination", GH_ParamAccess.item);
            pManager.AddGenericParameter("ElementGroupName", "ElementGroupName", "Gets the name of the element group", GH_ParamAccess.item);
            pManager.AddGenericParameter("EntityType", "EntityType", "Gets the type of the entity", GH_ParamAccess.item);
            pManager.AddGenericParameter("FactoringType", "FactoringType", "Gets the factoring type", GH_ParamAccess.item);
            pManager.AddGenericParameter("HasAutoKAmplifier", "AutoKAmplifier", "Gets a value indicating whether the k amplifier should be calculated automatically", GH_ParamAccess.item);
            pManager.AddGenericParameter("ID", "ID", "Gets the ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("Index", "Index", "Gets the index", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsActive", "IsActive", "Gets a value indicating whether the combination is on or off for analysis and design", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsService", "IsService", "Gets a value indicating whether the combination is assessed for deflection", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsStrength", "IsStrength", "Gets a value indicating whether the combination is assessed for design", GH_ParamAccess.item);
            pManager.AddGenericParameter("KAmplifier", "KAmplifier", "Gets the k amplifier", GH_ParamAccess.item);
            pManager.AddGenericParameter("KAmplifierSource", "KAmplifierSource", "Gets the source for k amplifier", GH_ParamAccess.item);
            pManager.AddGenericParameter("KAmplifierTarget", "KAmplifierTarget", "Gets the target for k amplifier", GH_ParamAccess.item);
            pManager.AddGenericParameter("ILoadcaseFactors", "ILoadcaseFactors", "Gets the list of loadcases with their factors", GH_ParamAccess.list);
            pManager.AddGenericParameter("Name", "Name", "Gets the name", GH_ParamAccess.item);
            pManager.AddGenericParameter("NhlServiceFactorX", "NhlServiceFactorX", "Gets the service notional horizontal loads factor in X direction", GH_ParamAccess.item);
            pManager.AddGenericParameter("NhlServiceFactorY", "NhlServiceFactorY", "Gets the service notional horizontal loads factor in Y direction", GH_ParamAccess.item);
            pManager.AddGenericParameter("NhlStrengthFactorX", "NhlStrengthFactorX", "Gets the strength notional horizontal loads factor in X direction", GH_ParamAccess.item);
            pManager.AddGenericParameter("NhlStrengthFactorY", "NhlStrengthFactorY", "Gets the strength notional horizontal loads factor in Y direction", GH_ParamAccess.item);
            pManager.AddGenericParameter("NhlX", "NhlX", "Gets the notional horizontal loads in X direction", GH_ParamAccess.item);
            pManager.AddGenericParameter("NhlY", "NhlY", "Gets the notional horizontal loads in Y direction", GH_ParamAccess.item);
            pManager.AddGenericParameter("ReferenceIndex", "ReferenceIndex", "Gets the reference index of the loading case", GH_ParamAccess.item);
            pManager.AddGenericParameter("SlsId", "SlsId", "Gets the ID of the corresponding SLS combination", GH_ParamAccess.item);
            pManager.AddGenericParameter("UserName", "UserName", "Gets the username of the loading case", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Loading.ICombination input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            bool output_appliesLiveLoadReductions = false;
            CombinationClass output_combinationClass = CombinationClass.Unknown;
            CombinationSpeciality output_combinationSpeciality = CombinationSpeciality.None;
            string output_elementGroupName = string.Empty;
            EntityType output_entityType = EntityType.Unknown;
            FactoringType output_factoringType = FactoringType.Unknown;
            bool output_hasAutoKAmplifier = false;
            Guid output_ID = Guid.Empty;
            int output_index = -1;
            bool output_isActive = false;
            bool output_isService = false;
            bool output_isStrength = false;
            double output_kAmplifier = 0.0;
            KAmplifierSource output_kAmplifierSource = KAmplifierSource.Unknown;
            KAmplifierTarget output_kAmplifierTarget = KAmplifierTarget.Unknown;
            List<ILoadcaseFactors> output_loadcaseFactors = null;
            string output_name = "N.A";
            double output_nhlServiceFactorX = 0.0;
            double output_nhlServiceFactorY = 0.0;
            double output_nhlStrengthFactorX = 0.0;
            double output_nhlStrengthFactorY = 0.0;
            Tristate output_nhlX = Tristate.Unknown;
            Tristate output_nhlY = Tristate.Unknown;
            int output_referenceIndex = -1;
            Guid output_slsId = Guid.Empty;
            string output_userName = string.Empty;

            if (input_1 != null)
            {
                try { output_appliesLiveLoadReductions = input_1.AppliesLiveLoadReductions.Value; }
                catch { output_appliesLiveLoadReductions = false; }

                try { output_combinationClass = input_1.CombinationClass.Value; }
                catch { output_combinationClass = CombinationClass.Unknown; }

                try { output_combinationSpeciality = input_1.CombinationSpeciality.Value; }
                catch { output_combinationSpeciality = CombinationSpeciality.None; }

                try { output_elementGroupName = input_1.ElementGroupName; }
                catch { output_elementGroupName = string.Empty; }

                try { output_entityType = input_1.EntityType; }
                catch { output_entityType = EntityType.Unknown; }

                try { output_factoringType = input_1.FactoringType.Value; }
                catch { output_factoringType = FactoringType.Unknown; }

                try { output_hasAutoKAmplifier = input_1.HasAutoKAmplifier.Value; }
                catch { output_hasAutoKAmplifier = false; }

                try { output_ID = input_1.Id; }
                catch { output_ID = Guid.Empty; }

                try { output_index = input_1.Index; }
                catch { output_index = -1; }

                try { output_isActive = input_1.IsActive.Value; }
                catch { output_isActive = false; }

                try { output_isService = input_1.IsService.Value; }
                catch { output_isService = false; }

                try { output_isStrength = input_1.IsStrength.Value; }
                catch { output_isStrength = false; }

                try { output_kAmplifier = input_1.KAmplifier.Value; }
                catch { output_kAmplifier = 0.0; }

                try { output_kAmplifierSource = input_1.KAmplifierSource.Value; }
                catch { output_kAmplifierSource = KAmplifierSource.Unknown; }

                try { output_kAmplifierTarget = input_1.KAmplifierTarget.Value; }
                catch { output_kAmplifierTarget = KAmplifierTarget.Unknown; }

                try { output_loadcaseFactors = input_1.LoadcaseFactors.Value.Select(i => i.Value).ToList(); }
                catch { output_loadcaseFactors = null; }

                try { output_name = input_1.Name; }
                catch { output_name = "N.A"; }

                try { output_nhlServiceFactorX = input_1.NhlServiceFactorX.Value; }
                catch { output_nhlServiceFactorX = 0.0; }

                try { output_nhlServiceFactorY = input_1.NhlServiceFactorY.Value; }
                catch { output_nhlServiceFactorY = 0.0; }

                try { output_nhlStrengthFactorX = input_1.NhlStrengthFactorX.Value; }
                catch { output_nhlStrengthFactorX = 0.0; }

                try { output_nhlStrengthFactorY = input_1.NhlStrengthFactorY.Value; }
                catch { output_nhlStrengthFactorY = 0.0; }

                try { output_nhlX = input_1.NhlX.Value; }
                catch { output_nhlX = 0.0; }

                try { output_nhlY = input_1.NhlY.Value; }
                catch { output_nhlY = 0.0; }

                try { output_referenceIndex = input_1.ReferenceIndex; }
                catch { output_referenceIndex = -1; }

                try { output_slsId = input_1.SlsId.Value; }
                catch { output_slsId = Guid.Empty; }

                try { output_userName = input_1.UserName.Value; }
                catch { output_userName = string.Empty; }
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "ICombination is not provided or invalid.");
            }

            // Setting the output parameters
            DA.SetData(0, output_appliesLiveLoadReductions);
            DA.SetData(1, output_combinationClass);
            DA.SetData(2, output_combinationSpeciality);
            DA.SetData(3, output_elementGroupName);
            DA.SetData(4, output_entityType);
            DA.SetData(5, output_factoringType);
            DA.SetData(6, output_hasAutoKAmplifier);
            DA.SetData(7, output_ID);
            DA.SetData(8, output_index);
            DA.SetData(9, output_isActive);
            DA.SetData(10, output_isService);
            DA.SetData(11, output_isStrength);
            DA.SetData(12, output_kAmplifier);
            DA.SetData(13, output_kAmplifierSource);
            DA.SetData(14, output_kAmplifierTarget);
            DA.SetDataList(15, output_loadcaseFactors);
            DA.SetData(16, output_name);
            DA.SetData(17, output_nhlServiceFactorX);
            DA.SetData(18, output_nhlServiceFactorY);
            DA.SetData(19, output_nhlStrengthFactorX);
            DA.SetData(20, output_nhlStrengthFactorY);
            DA.SetData(21, output_nhlX);
            DA.SetData(22, output_nhlY);
            DA.SetData(23, output_referenceIndex);
            DA.SetData(24, output_slsId);
            DA.SetData(25, output_userName);
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
            get { return new Guid("F1895A88-5C27-4AB4-8D06-54D6E37C4E3E"); }
        }
    }
}



