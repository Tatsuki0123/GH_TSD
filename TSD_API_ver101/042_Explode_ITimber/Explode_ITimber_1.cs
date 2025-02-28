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

namespace TSD_API_ver101_ITimber_Explode
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_ITimber_1", "E_ITimber_1",
            "Exploding the ITimber ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ITimber", "ITimber", "Input ITimber", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("AnalysisElasticModulus", "E_analysis", "Gets the analysis elastic modulus, E_{analysis} (in [N/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Density", "Density", "Gets the timber density (in [kg/mm³])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Fabrication", "Fabrication", "Gets the fabrication of the grade", GH_ParamAccess.item);
            pManager.AddGenericParameter("HeadCode", "HC", "Gets the head code the material applies to", GH_ParamAccess.item);
            pManager.AddGenericParameter("Id", "ID", "Gets the ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("MeanElasticModulus", "E_mean", "Gets the mean elastic modulus, E_{mean} (in [N/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("MinimumElasticModulus", "E_min", "Gets the minimum elastic modulus, E_{min} (in [N/mm²])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Name", "Name", "Gets the name", GH_ParamAccess.item);
            pManager.AddGenericParameter("PoissonsRatio", "PR", "Gets the Poisson's ratio (unitless)", GH_ParamAccess.item);
            pManager.AddGenericParameter("ShearModulus", "G", "Gets the shear modulus (in [N/mm²])", GH_ParamAccess.item);
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
            TSD.API.Remoting.Materials.ITimber input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.

            double output_analysisElasticModulus = 0.0;
            double output_density = 0.0;
            string output_fabrication = "N.A";
            string output_headcode = "N.A";
            Guid output_id = Guid.Empty;
            double output_meanElasticModulus = 0.0;
            double output_minimumElasticModulus = 0.0;
            string output_name = "N.A";
            double output_poissonsRatio = 0.0;
            double output_shearModulus = 0.0;
            double output_thermalExpansionCoefficient = 0.0;
            string output_type = "N.A";

            if (input_1 != null)
            {
                // Assuming 'input_1' is your input object which contains the required properties.
                output_analysisElasticModulus = input_1.AnalysisElasticModulus;
                output_density = input_1.Density;
                output_fabrication = input_1.Fabrication.ToString();
                output_headcode = input_1.HeadCode.ToString();
                output_id = input_1.Id;
                output_meanElasticModulus = input_1.MeanElasticModulus;
                output_minimumElasticModulus = input_1.MinimumElasticModulus;
                output_name = input_1.Name;
                output_poissonsRatio = input_1.PoissonsRatio;
                output_shearModulus = input_1.ShearModulus;
                output_thermalExpansionCoefficient = input_1.ThermalExpansionCoefficient;
                output_type = input_1.Type.ToString();
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");
            }

            // Setting the output parameters
            DA.SetData(0, output_analysisElasticModulus);
            DA.SetData(1, output_density);
            DA.SetData(2, output_fabrication);
            DA.SetData(3, output_headcode);
            DA.SetData(4, output_id);
            DA.SetData(5, output_meanElasticModulus);
            DA.SetData(6, output_minimumElasticModulus);
            DA.SetData(7, output_name);
            DA.SetData(8, output_poissonsRatio);
            DA.SetData(9, output_shearModulus);
            DA.SetData(10, output_thermalExpansionCoefficient);
            DA.SetData(11, output_type);
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
            get { return new Guid("AA8CFDA8-D758-499C-99B9-55EB5D0FD82D"); }
        }
    }
}
