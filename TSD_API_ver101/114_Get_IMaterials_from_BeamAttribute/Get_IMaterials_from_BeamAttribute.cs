using System;
using System.Collections.Generic;
using System.Linq;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Materials;
using TSD.API.Remoting.Sections;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_Get_IMaterials_from_BeamAttribute
{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Get_IMaterials_from_BeamAttribute", "G_IMaterials_from_BeamAttribute",
            "Getting the Get IMaterials from BeamAttribute",
            "TSD_API", "Basic_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Structure IModel", "stIModel", "Input structure IModel", GH_ParamAccess.item);
            pManager.AddGenericParameter("MaterialType", "MaterialType", "Input MaterialType", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("IMaterials", "IMaterials", "this is the IMaterials", GH_ParamAccess.list);
            pManager.AddGenericParameter("IMaterials_Name", "Name", "this is the IMaterials Name", GH_ParamAccess.list);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Structure.IModel input_1 = null;
            MaterialType input_2 = MaterialType.Steel;
            

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;
            if (!DA.GetData(1, ref input_2)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            List<IMaterial> output_list = new List<IMaterial>();
            List<string> output_list_name = new List<string>();

            if (input_1 != null)
            {
                output_list = TSD_API_ver101_Get_IMaterials_from_BeamAttribute.Get_IMaterials_from_BeamAttribute_output.GetIMaterialsfromBeamAttribute(input_1,input_2);

                output_list_name = output_list?.Select(i => i.Name).ToList();
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetDataList(0, output_list);
            DA.SetDataList(1, output_list_name);    
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
            get { return new Guid("3A3B0331-D0DB-45AF-9B0F-4E810EBD54C8"); }
        }
    }
}