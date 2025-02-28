using System;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Common;

namespace TSD_API_ver101_ILoadcase_2_Explode
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_ILoadcase_2", "E_ILoadcase_2",
            "Exploding the ILoadcase ver2",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ILoadcase", "ILoadcase", "Input ILoadcase", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Name", "Name", "Gets the name of the loadcase", GH_ParamAccess.item);
            pManager.AddGenericParameter("Index", "Index", "Gets the loadcase index in TSD", GH_ParamAccess.item);
            pManager.AddGenericParameter("ID", "ID", "Gets the loadcase ID in TSD", GH_ParamAccess.item);
            pManager.AddGenericParameter("AppliesLiveLoadReductions", "LiveLoadReductions", "Gets a value indicating whether live load reductions are applied", GH_ParamAccess.item);
            pManager.AddGenericParameter("AustralianCombinationFactors", "AusCombFactors", "Gets the combination factors specific to Australian head code", GH_ParamAccess.item);
            pManager.AddGenericParameter("AustralianLoadingCategory", "AusLoadCategory", "Gets the type of Australian loading category", GH_ParamAccess.item);
            pManager.AddGenericParameter("AutomaticLoading", "AutoLoading", "Gets a value indicating that the loading is generated automatically", GH_ParamAccess.item);
            pManager.AddGenericParameter("Ec3LoadingCategory", "Ec3LoadCategory", "Gets the type of EC3 loading category", GH_ParamAccess.item);
            pManager.AddGenericParameter("EcCombinationFactors", "EcCombFactors", "Gets the combination factors specific to EC head code", GH_ParamAccess.item);
            pManager.AddGenericParameter("ElementGroupName", "ElementGroupName", "Gets the name of the element group", GH_ParamAccess.item);
            pManager.AddGenericParameter("EntityType", "EntityType", "Gets the type of the entity", GH_ParamAccess.item);
            pManager.AddGenericParameter("GeneralType", "GeneralType", "Gets the type of the loadcase", GH_ParamAccess.item);
            pManager.AddGenericParameter("HasPatternEccentricityMomentsForPrecastColumns", "PatternEccMomentsPrecast", "Gets a value indicating whether the loadcase should pattern eccentricity moments for precast columns", GH_ParamAccess.item);
            pManager.AddGenericParameter("HasPatternEccentricityMomentsForSteelColumns", "PatternEccMomentsSteel", "Gets a value indicating whether the loadcase should pattern eccentricity moments for steel columns", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsPatterned", "IsPatterned", "Gets a value indicating whether the loadcase is patterned", GH_ParamAccess.item);
            pManager.AddGenericParameter("LongTerm", "LongTerm", "Gets the long term percentage", GH_ParamAccess.item);
            pManager.AddGenericParameter("PriorToBrittleFinishes", "PriorToBrittleFinishes", "Gets the prior to brittle finishes", GH_ParamAccess.item);
            pManager.AddGenericParameter("ReferenceIndex", "ReferenceIndex", "Gets the reference index of the loading case", GH_ParamAccess.item);
            pManager.AddGenericParameter("Speciality", "Speciality", "Gets the loadcase speciality", GH_ParamAccess.item);
            pManager.AddGenericParameter("Type", "Type", "Gets the extended type of the loadcase", GH_ParamAccess.item);
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
            TSD.API.Remoting.Loading.ILoadcase input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            string output_name = "N.A";
            int output_index = -1;
            Guid output_ID = Guid.Empty;
            bool output_appliesLiveLoadReductions = false;
            IAustralianCombinationFactors output_australianCombinationFactors = null;
            AustralianLoadingCategory output_australianLoadingCategory = AustralianLoadingCategory.Unknown;
            bool output_automaticLoading = false;
            Ec3LoadingCategory output_ec3LoadingCategory = Ec3LoadingCategory.Unknown;
            IEcCombinationFactors output_ecCombinationFactors = null;
            string output_elementGroupName = string.Empty;
            EntityType output_entityType = EntityType.Unknown;
            LoadcaseGeneralType output_generalType = LoadcaseGeneralType.Unknown;
            bool output_hasPatternEccentricityMomentsForPrecastColumns = false;
            bool output_hasPatternEccentricityMomentsForSteelColumns = false;
            bool output_isPatterned = false;
            double output_longTerm = 0.0;
            double output_priorToBrittleFinishes = -1;
            int output_referenceIndex = -1;
            LoadcaseSpeciality output_speciality = LoadcaseSpeciality.Unknown;
            LoadcaseType output_type = LoadcaseType.Unknown;
            string output_userName = string.Empty;

            if (input_1 != null)
            {
                try { output_name = input_1.Name.Substring(2); }
                catch { output_name = "N.A"; }

                try { output_index = input_1.Index; }
                catch { output_index = -1; }

                try { output_ID = input_1.Id; }
                catch { output_ID = Guid.Empty; }

                try { output_appliesLiveLoadReductions = input_1.AppliesLiveLoadReductions.Value; }
                catch { output_appliesLiveLoadReductions = false; }

                try { output_australianCombinationFactors = input_1.AustralianCombinationFactors.Value; }
                catch { output_australianCombinationFactors = null; }

                try { output_australianLoadingCategory = input_1.AustralianLoadingCategory.Value; }
                catch { output_australianLoadingCategory = AustralianLoadingCategory.Unknown; }

                try { output_automaticLoading = input_1.AutomaticLoading.Value; }
                catch { output_automaticLoading = false; }

                try { output_ec3LoadingCategory = input_1.Ec3LoadingCategory.Value; }
                catch { output_ec3LoadingCategory = Ec3LoadingCategory.Unknown; }

                try { output_ecCombinationFactors = input_1.EcCombinationFactors.Value; }
                catch { output_ecCombinationFactors = null; }

                try { output_elementGroupName = input_1.ElementGroupName; }
                catch { output_elementGroupName = string.Empty; }

                try { output_entityType = input_1.EntityType; }
                catch { output_entityType = EntityType.Unknown; }

                try { output_generalType = input_1.GeneralType.Value; }
                catch { output_generalType = LoadcaseGeneralType.Unknown; }

                try { output_hasPatternEccentricityMomentsForPrecastColumns = input_1.HasPatternEccentricityMomentsForPrecastColumns.Value; }
                catch { output_hasPatternEccentricityMomentsForPrecastColumns = false; }

                try { output_hasPatternEccentricityMomentsForSteelColumns = input_1.HasPatternEccentricityMomentsForSteelColumns.Value; }
                catch { output_hasPatternEccentricityMomentsForSteelColumns = false; }

                try { output_isPatterned = input_1.IsPatterned.Value; }
                catch { output_isPatterned = false; }

                try { output_longTerm = input_1.LongTerm.Value; }
                catch { output_longTerm = 0.0; }

                try { output_priorToBrittleFinishes = input_1.PriorToBrittleFinishes.Value; }
                catch { output_priorToBrittleFinishes = -1; }

                try { output_referenceIndex = input_1.ReferenceIndex; }
                catch { output_referenceIndex = -1; }

                try { output_speciality = input_1.Speciality.Value; }
                catch { output_speciality = LoadcaseSpeciality.Unknown; }

                try { output_type = input_1.Type.Value; }
                catch { output_type = LoadcaseType.Unknown; }

                try { output_userName = input_1.UserName.Value; }
                catch { output_userName = string.Empty; }
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "ILoadcase is not provided or invalid.");
            }

            // Setting the output parameters
            DA.SetData(0, output_name);
            DA.SetData(1, output_index);
            DA.SetData(2, output_ID);
            DA.SetData(3, output_appliesLiveLoadReductions);
            DA.SetData(4, output_australianCombinationFactors);
            DA.SetData(5, output_australianLoadingCategory);
            DA.SetData(6, output_automaticLoading);
            DA.SetData(7, output_ec3LoadingCategory);
            DA.SetData(8, output_ecCombinationFactors);
            DA.SetData(9, output_elementGroupName);
            DA.SetData(10, output_entityType);
            DA.SetData(11, output_generalType);
            DA.SetData(12, output_hasPatternEccentricityMomentsForPrecastColumns);
            DA.SetData(13, output_hasPatternEccentricityMomentsForSteelColumns);
            DA.SetData(14, output_isPatterned);
            DA.SetData(15, output_longTerm);
            DA.SetData(16, output_priorToBrittleFinishes);
            DA.SetData(17, output_referenceIndex);
            DA.SetData(18, output_speciality);
            DA.SetData(19, output_type);
            DA.SetData(20, output_userName);
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
            get { return new Guid("203B09F3-820F-4472-A6E2-1ADD99FCB8AD"); }
        }
    }
}





