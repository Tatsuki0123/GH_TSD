using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;

namespace TSD_API_ver101_Set_UserDefinedAttribute_MemberSpan


{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Set_UserDefinedAttribute_MemberSpan", "Set_UDAs_MemberSpan",
            "Setting UserDefinedAttribute to MemberSpan",
            "TSD_API", "Setting_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IMember Span", "IMemberSpan", "Input structure IMemberSpan", GH_ParamAccess.item);

            pManager.AddGenericParameter("IAttributeDefinition", "IAttributeDefinition", "this is List of set Attribute Definition ", GH_ParamAccess.item);

            pManager.AddGenericParameter("Attribute Value", "Attribute Value", "this is List of set Attribute Value ", GH_ParamAccess.item);

            pManager.AddGenericParameter("Activate", "Activate", "When its true, keep running so do not keep connecting true, use bottun component", GH_ParamAccess.item);


        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Status", "Status", "this is List of Create status", GH_ParamAccess.item);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Structure.IMemberSpan input_1 = null;
            IAttributeDefinition input_2 = null;
            string input_3 = null;
            bool input_4 = false;


            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;
            if(!DA.GetData(1, ref input_2)) return;
            if (!DA.GetData(2, ref input_3)) return;
            if(!DA.GetData(3, ref input_4)) return;



            
            

            // We should now validate the data and warn the user if invalid data is supplied.
            string output_1 = "Processing or not started";

            if (input_1 != null && input_2 != null && input_4 == true)
            {

                TSD_API_ver101_Set_UserDefinedAttribute_MemberSpan.Set_UserDefinedAttribute_MemberSpan_output.SetUserDefinedAttribute_MemberSpan(input_1,input_2,input_3);
                output_1 = "UDAs value Set Done";
                DA.SetData(0, output_1);
            }
            else
            {
                output_1 = "Not run yet";
                DA.SetData(0, output_1);

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:

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
            get { return new Guid("B8239965-42E2-48B9-91AB-FEB3A5D2BBFE"); }
        }
    }
}