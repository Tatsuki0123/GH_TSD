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

namespace TSD_API_ver101_IMember_Explode

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_IMember_1", "E_IMember_1",
            "Explodeing the IMember ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IMember", "IMember", "Input IMember", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Name", "N", "this is name of the loadcase", GH_ParamAccess.item);
            pManager.AddGenericParameter("Index", "Index", "this is Loadcase index in tsd", GH_ParamAccess.item);
            pManager.AddGenericParameter("Span count", "Span_Count", "this is the number of the span", GH_ParamAccess.item);
            pManager.AddGenericParameter("ID", "ID", "this is the ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("Entity Type Name", "TypeName", "this is the Entity type name", GH_ParamAccess.item);
            pManager.AddGenericParameter("Construction point index", "Construction point index", "this is the construction point index", GH_ParamAccess.list);
            pManager.AddGenericParameter("IMemberData", "IMemberData", "this is the IMemberData of the corresponding member", GH_ParamAccess.item);
            pManager.AddGenericParameter("Member Type", "MemberType", "this is the MemberType of the correspoinding member", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Structure.IMember input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            string output_name = "N.A";
            int output_index = -1;
            int output_span = -1;
            Guid output_id = Guid.Empty;
            string output_type_name = null;
            List<int> output_constpoint_idx = new List<int>();
            IMemberData output_data = null;
            string output_memberType = "N.A";
          
            

            if (input_1 != null)
            {
                output_name = input_1.Name;
                output_index = input_1.Index;
                output_span = input_1.SpanCount.Value;
                output_id = input_1.Id;
                output_type_name = input_1.EntityType.ToString();
                output_constpoint_idx = input_1.MemberNodes.Select(item => item.Value.ConstructionPointIndex.Value).ToList();
                output_data = input_1.Data.Value;
                output_memberType = output_data.MemberType.Value.ToString();




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
            DA.SetData(2, output_span);
            DA.SetData(3, output_id);
            DA.SetData(4, output_type_name);
            DA.SetDataList(5, output_constpoint_idx);
            DA.SetData(6, output_data);
            DA.SetData(7, output_memberType);

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
            get { return new Guid("7231A580-71BE-4666-92F2-347F97529275"); }
        }
    }
}