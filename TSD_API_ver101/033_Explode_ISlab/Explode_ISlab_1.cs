using System;
using System.Collections.Generic;
using System.Linq;
using GH_IO.Types;
using Google.Protobuf.WellKnownTypes;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_ISlab_Explode

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_ISlab_1", "E_ISlab_1",
            "Explodeing the ISlab ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ISlab", "ISlab", "Input ISlab", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Name", "N", "this is name", GH_ParamAccess.item);
            pManager.AddGenericParameter("Index", "Index", "this is index", GH_ParamAccess.item);
            pManager.AddGenericParameter("List of Slab Item indicies", "List_SlabItemindicies", "this is the index of ISlabItem", GH_ParamAccess.list);
            pManager.AddGenericParameter("ID", "ID", "this is the ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("Entity Type Name", "TypeName", "this is the Entity type name", GH_ParamAccess.item);
            pManager.AddGenericParameter("ISlabData", "ISlabData", "this is the ISlabData", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Structure.ISlab input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            string output_name = "N.A";
            int output_index = -1;
            List<int> output_slabitem_idx = new List<int>();
            Guid output_id = Guid.Empty;
            string output_type_name = null;
            ISlabData output_slabdata = null;  
          
            

            if (input_1 != null)
            {
                output_name = input_1.Name;
                output_index = input_1.Index;
                output_slabitem_idx = input_1.SlabItemIndices.ToList();
                output_id = input_1.Id;
                output_type_name = input_1.EntityType.ToString();
                output_slabdata = input_1.SlabData.Value;




            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetData(0, output_name);
            DA.SetData(1, output_index);
            DA.SetDataList(2, output_slabitem_idx);
            DA.SetData(3, output_id);
            DA.SetData(4, output_type_name);
            DA.SetData(5, output_slabdata);

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
            get { return new Guid("8ED57882-203F-4C13-8DF9-3C5EC8D8DE91"); }
        }
    }
}