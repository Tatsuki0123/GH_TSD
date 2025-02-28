using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Loading.Create;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure.Create;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;

namespace TSD_API_ver101_Create_Load_with_ILoadcase


{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Create_Load_with_ILoadcase", "C_Load_with_ILoadcase",
            "Creating the Load_with_ILoadcase",
            "TSD_API", "Creating_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ILoadcase", "ILoadcase", "Input ILoadcase", GH_ParamAccess.item);

            pManager.AddGenericParameter("LoadParams", "LoadParams", "this is LoadParams", GH_ParamAccess.item);

            pManager.AddGenericParameter("Activate", "Activate", "When its true, keep running so do not keep connecting true, use bottun component", GH_ParamAccess.item);


        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("ILoad", "ILoad", "this is ILoad", GH_ParamAccess.item);
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
            ILoadcase input_1 = null;
            LoadParams input_2 = null;
            bool activate = false;


            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;
            if (!DA.GetData(1, ref input_2)) return;
            if (!DA.GetData(2, ref activate)) return;






            // We should now validate the data and warn the user if invalid data is supplied.
            TSD.API.Remoting.Loading.ILoad output = null;
            string output_1 = "Processing or not started";

            if (input_1 != null && input_2 != null && activate == true)
            {
                try
                {
                    output = TSD_API_ver101_Create_Load_with_ILoadcase.Create_Load_with_ILoadcase_output.CreateLoadwithILoadcase(input_1, input_2);
                    output_1 = "Succeeded";
                }
                catch
                {
                    output = null;
                    output_1 = "Input Load might be 0";
                }

                
                
            }
            else
            {
                output_1 = "Process Done or Not Yet Activated";

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetData(0, output);
            DA.SetData(1, output_1);
        }




        public override void AddedToDocument(GH_Document document)
        {
            base.AddedToDocument(document);

            if (!InputHasConnections(2))
            {
                // Create a Value List
                GH_BooleanToggle valueList_1 = new GH_BooleanToggle();
                valueList_1.CreateAttributes(); // Necessary to position it on canvas
                valueList_1.Attributes.Pivot = new System.Drawing.PointF(this.Attributes.Pivot.X - Params.OutputWidth - Params.InputWidth - 100, this.Attributes.Pivot.Y + Params.Input[2].Attributes.Pivot.Y - 12);


                // Add the value list to the document
                document.AddObject(valueList_1, false);

                //Connect
                Params.Input[2].AddSource(valueList_1);

            }

        }


        private bool InputHasConnections(int inputIndex)
        {
            if (inputIndex >= Params.Input.Count)
                return false;

            var inputParam = Params.Input[inputIndex];
            return inputParam.SourceCount > 0;
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
            get { return new Guid("C6A57BB1-5E43-4F94-8C49-AD1F085A9387"); }
        }
    }
}