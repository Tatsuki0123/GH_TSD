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
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_IMaterial_Explode

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_IMaterial_1", "E_IMaterial_1",
            "Explodeing the IMaterial ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IMaterial", "IMaterial", "Input IMaterial", GH_ParamAccess.item);
            
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {




            pManager.AddGenericParameter("Headcode", "HC", "Output headcode", GH_ParamAccess.item);
            pManager.AddGenericParameter("ID", "ID", "Output ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("Name", "Name", "Output name", GH_ParamAccess.item);
            pManager.AddGenericParameter("Poisson's Ratio", "PR", "Output Poisson's ratio", GH_ParamAccess.item);
            pManager.AddGenericParameter("Shear Modulus", "SM", "Output shear modulus", GH_ParamAccess.item);
            pManager.AddGenericParameter("Thermal", "T", "Output thermal", GH_ParamAccess.item);
            pManager.AddGenericParameter("Type", "Type", "Output type", GH_ParamAccess.item);

            // Adding output parameters for each material type
            pManager.AddGenericParameter("ISteel", "ISteel", "Output ISteel", GH_ParamAccess.item);
            pManager.AddGenericParameter("IConcrete", "IConcrete", "Output IConcrete", GH_ParamAccess.item);
            pManager.AddGenericParameter("IColdFormed", "IColdFormed", "Output IColdFormed", GH_ParamAccess.item);
            pManager.AddGenericParameter("IColdRolled", "IColdRolled", "Output IColdRolled", GH_ParamAccess.item);
            pManager.AddGenericParameter("IGeneralMaterial", "IGeneralMaterial", "Output IGeneralMaterial", GH_ParamAccess.item);
            pManager.AddGenericParameter("ITimber", "ITimber", "Output ITimber", GH_ParamAccess.item);
        }


        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Materials.IMaterial input_1 = null;
           

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;
           

            // We should now validate the data and warn the user if invalid data is supplied.

            string output_headcode = null;
            Guid output_id = Guid.Empty;
            string output_name = null;  
            double output_poisonsratio = 0.0;
            double output_shearmodulus = 0.0;
            double output_thermal = 0.0;
            string output_type = "N.A";

            TSD.API.Remoting.Materials.ISteel output_Isteel = null;
            TSD.API.Remoting.Materials.IConcrete output_Iconcrete = null;
            TSD.API.Remoting.Materials.IColdFormed output_coldformed = null;
            TSD.API.Remoting.Materials.IColdRolled output_Icoldrolled = null;
            TSD.API.Remoting.Materials.IGeneralMaterial output_Igeneralmat = null;
            TSD.API.Remoting.Materials.ITimber output_ITimber = null;   
            // actually more materials are in api but not implemented everything for now




            if (input_1 != null)
            {
                
                output_headcode = input_1.HeadCode.ToString();
                output_id = input_1.Id;
                output_name = input_1.Name;
                output_poisonsratio = input_1.PoissonsRatio;
                output_shearmodulus = input_1.ShearModulus;
                output_thermal = input_1.ThermalExpansionCoefficient;
                output_type = input_1.Type.ToString();


                output_Isteel = input_1 as TSD.API.Remoting.Materials.ISteel;
                output_Iconcrete = input_1 as TSD.API.Remoting.Materials.IConcrete;
                output_coldformed = input_1 as TSD.API.Remoting.Materials.IColdFormed;
                output_Icoldrolled = input_1 as TSD.API.Remoting.Materials.IColdRolled;
                output_Igeneralmat = input_1 as TSD.API.Remoting.Materials.IGeneralMaterial;
                output_ITimber = input_1 as TSD.API.Remoting.Materials.ITimber;






            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Set the data for each material type
            DA.SetData(0, output_headcode);
            DA.SetData(1, output_id);
            DA.SetData(2, output_name);
            DA.SetData(3, output_poisonsratio);
            DA.SetData(4, output_shearmodulus);
            DA.SetData(5, output_thermal);
            DA.SetData(6, output_type);

            DA.SetData(7, output_Isteel);
            DA.SetData(8, output_Iconcrete);
            DA.SetData(9, output_coldformed);
            DA.SetData(10, output_Icoldrolled);
            DA.SetData(11, output_Igeneralmat);
            DA.SetData(12, output_ITimber);

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
            get { return new Guid("6DA2280C-DBBC-4F3E-9EBE-5DDB049A3B72"); }
        }
    }
}