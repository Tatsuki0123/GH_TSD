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
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Materials;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_ISteel_Explode

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_ISteel_1", "E_ISteel_1",
            "Explodeing the ISteel ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ISteel", "ISteel", "Input ISteel", GH_ParamAccess.item);
            
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("BearingStrengthOfConnectedParts", "PBS", "Gets the bearing strength of connected parts, pbs", GH_ParamAccess.item);
            pManager.AddGenericParameter("Density", "Density", "Gets the density of the steel (in [kg/mm³])", GH_ParamAccess.item);
            pManager.AddGenericParameter("EffectiveNetAreaCoefficient", "Ke", "Gets the effective nett area coefficient, Ke", GH_ParamAccess.item);
            pManager.AddGenericParameter("ElasticModulus", "E", "Gets the elastic modulus, E (in [N/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("ExpectedToMinimumTensileStrength", "Rt", "Gets the ratio of the expected tensile strength to the specified minimum tensile strength, Rt", GH_ParamAccess.item);
            pManager.AddGenericParameter("ExpectedToMinimumYieldStrength", "Ry", "Gets the ratio of the expected yield strength to the specified minimum yield strength, Ry", GH_ParamAccess.item);
            pManager.AddGenericParameter("HeadCode", "HC", "Gets the head code the material applies to", GH_ParamAccess.item);
            pManager.AddGenericParameter("Id", "ID", "Gets the ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("MinimumTensileStrength", "Us", "Gets the minimum tensile strength, Us (in [N/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("MinimumYieldStrength", "Ys", "Gets the minimum yield strength, Ys (in [N/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Name", "Name", "Gets the name", GH_ParamAccess.item);
            pManager.AddGenericParameter("PoissonsRatio", "PR", "Gets the Poisson's ratio (unitless)", GH_ParamAccess.item);
            pManager.AddGenericParameter("ShearModulus", "G", "Gets the shear modulus (in [N/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("StrengthProperties", "SP", "Gets a collection of ISteelStrengthProperty instances representing the design strengths", GH_ParamAccess.list);
            pManager.AddGenericParameter("ThermalExpansionCoefficient", "CTE", "Gets the coefficient of thermal expansion (in [1/K])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Type", "Type", "Gets the type of the material", GH_ParamAccess.item);


        }


        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Materials.ISteel input_1 = null;
           

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;


            // We should now validate the data and warn the user if invalid data is supplied.

            double output_bearingstrength = 0.0;
            double output_density = 0.0;
            double output_areacoeft = 0.0;
            double output_elasticmodulus = 0.0;
            double output_minten = 0.0;
            double output_minyield = 0.0;
            string output_headcode = "N.A";
            Guid output_id = Guid.Empty;
            double output_mintenstrength = 0.0;
            double output_minyiedlstrength = 0.0;
            string output_name = "N.A";
            double output_pois = 0.0;
            double output_shearmod = 0.0;
            List<ISteelStrengthProperty> output_strengthprop = new List<ISteelStrengthProperty>();
            double output_thermal = 0.0;
            string type = "N.A";


            





            if (input_1 != null)
            {

                // Assuming 'input_1' is your input object which contains the required properties.
                output_bearingstrength = input_1.BearingStrengthOfConnectedParts;
                output_density = input_1.Density;
                output_areacoeft = input_1.EffectiveNetAreaCoefficient;
                output_elasticmodulus = input_1.ElasticModulus;
                output_minten = input_1.ExpectedToMinimumTensileStrength;
                output_minyield = input_1.ExpectedToMinimumYieldStrength;
                output_headcode = input_1.HeadCode.ToString();
                output_id = input_1.Id;
                output_mintenstrength = input_1.MinimumTensileStrength;
                output_minyiedlstrength = input_1.MinimumYieldStrength;
                output_name = input_1.Name;
                output_pois = input_1.PoissonsRatio;
                output_shearmod = input_1.ShearModulus;
                output_strengthprop = input_1.StrengthProperties.ToList();
                output_thermal = input_1.ThermalExpansionCoefficient;
                type = input_1.Type.ToString();






            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Setting the output parameters
            DA.SetData(0, output_bearingstrength);
            DA.SetData(1, output_density);
            DA.SetData(2, output_areacoeft);
            DA.SetData(3, output_elasticmodulus);
            DA.SetData(4, output_minten);
            DA.SetData(5, output_minyield);
            DA.SetData(6, output_headcode);
            DA.SetData(7, output_id);
            DA.SetData(8, output_mintenstrength);
            DA.SetData(9, output_minyiedlstrength);
            DA.SetData(10, output_name);
            DA.SetData(11, output_pois);
            DA.SetData(12, output_shearmod);
            DA.SetDataList(13, output_strengthprop);
            DA.SetData(14, output_thermal);
            DA.SetData(15, type);

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
            get { return new Guid("9AE066D8-7954-4851-85BF-C2722F272029"); }
        }
    }
}