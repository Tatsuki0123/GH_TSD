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

namespace TSD_API_ver101_IColdFormed_Explode
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_IColdFormed_1", "E_IColdFormed_1",
            "Exploding the IColdFormed ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IColdFormed", "IColdFormed", "Input IColdFormed", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Density", "Density", "Gets the density of the material (in [kg/mm³])", GH_ParamAccess.item);
            pManager.AddGenericParameter("ElasticModulus", "E", "Gets the elastic modulus (in [N/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("HasYieldStrengthChangePoint", "YSCP", "Gets a value indicating whether a change point for the yield strength is applicable to this object", GH_ParamAccess.item);
            pManager.AddGenericParameter("HeadCode", "HC", "Gets the head code the material applies to", GH_ParamAccess.item);
            pManager.AddGenericParameter("Id", "ID", "Gets the ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("Name", "Name", "Gets the name", GH_ParamAccess.item);
            pManager.AddGenericParameter("PoissonsRatio", "PR", "Gets the Poisson's ratio (unitless)", GH_ParamAccess.item);
            pManager.AddGenericParameter("ShearModulus", "G", "Gets the shear modulus (in [N/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("TensileStrength", "TS", "Gets the tensile strength for the specified thickness (in [N/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("ThermalExpansionCoefficient", "CTE", "Gets the coefficient of thermal expansion (in [1/K])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Thickness", "T", "Gets the thickness change point for the strength value (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Type", "Type", "Gets the type of the material", GH_ParamAccess.item);
            pManager.AddGenericParameter("YieldStrengthAfterChangePoint", "YSACP", "Gets the yield strength for a thickness greater than that stored in the Thickness property (in [N/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("YieldStrengthBeforeChangePoint", "YSBCP", "Gets the yield strength for a thickness value less than that stored in the Thickness property (in [N/mm²])", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Materials.IColdFormed input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.

            double output_density = 0.0;
            double output_elasticModulus = 0.0;
            bool output_hasYieldStrengthChangePoint = false;
            string output_headcode = "N.A";
            Guid output_id = Guid.Empty;
            string output_name = "N.A";
            double output_poissonsRatio = 0.0;
            double output_shearModulus = 0.0;
            double output_tensileStrength = 0.0;
            double output_thermalExpansionCoefficient = 0.0;
            double output_thickness = 0.0;
            string output_type = "N.A";
            double output_yieldStrengthAfterChangePoint = 0.0;
            double output_yieldStrengthBeforeChangePoint = 0.0;

            if (input_1 != null)
            {
                // Assuming 'input_1' is your input object which contains the required properties.
                output_density = input_1.Density;
                output_elasticModulus = input_1.ElasticModulus;
                output_hasYieldStrengthChangePoint = input_1.HasYieldStrengthChangePoint;
                output_headcode = input_1.HeadCode.ToString();
                output_id = input_1.Id;
                output_name = input_1.Name;
                output_poissonsRatio = input_1.PoissonsRatio;
                output_shearModulus = input_1.ShearModulus;
                output_tensileStrength = input_1.TensileStrength;
                output_thermalExpansionCoefficient = input_1.ThermalExpansionCoefficient;
                output_thickness = input_1.Thickness;
                output_type = input_1.Type.ToString();
                output_yieldStrengthAfterChangePoint = input_1.YieldStrengthAfterChangePoint;
                output_yieldStrengthBeforeChangePoint = input_1.YieldStrengthBeforeChangePoint;
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");
            }

            // Setting the output parameters
            DA.SetData(0, output_density);
            DA.SetData(1, output_elasticModulus);
            DA.SetData(2, output_hasYieldStrengthChangePoint);
            DA.SetData(3, output_headcode);
            DA.SetData(4, output_id);
            DA.SetData(5, output_name);
            DA.SetData(6, output_poissonsRatio);
            DA.SetData(7, output_shearModulus);
            DA.SetData(8, output_tensileStrength);
            DA.SetData(9, output_thermalExpansionCoefficient);
            DA.SetData(10, output_thickness);
            DA.SetData(11, output_type);
            DA.SetData(12, output_yieldStrengthAfterChangePoint);
            DA.SetData(13, output_yieldStrengthBeforeChangePoint);
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
            get { return new Guid("5E1E367A-76D1-455A-993C-D4BCAF5B488C"); }
        }
    }
}
