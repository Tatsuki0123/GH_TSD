﻿using System;
using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Geometry;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Loading.Create;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;
using TSD.API.Remoting.Structure.Create;
using TSD.API.Remoting.UserDefinedAttributes;
using TSD.API.Remoting.UserDefinedAttributes.Create;

namespace TSD_API_ver101_Create_MemberForceLoadParams


{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Create_MemberForceLoadParams", "C_MemberForceLoadParams",
            "Creating the MemberForceLoadParams",
            "TSD_API", "Creating_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            //pManager.AddGenericParameter("Structure IModel", "stIModel", "Input structure IModel", GH_ParamAccess.item);

            pManager.AddGenericParameter("MemberSpanInfo", "MemberSpanInfo", "this is MemberSpanInfo", GH_ParamAccess.item);

            pManager.AddGenericParameter("Load[N]", "Load[N]", "The Load (in [N])", GH_ParamAccess.item);
            pManager[1].Optional = true;
            pManager.AddGenericParameter("Distance", "Distance", "The Distance", GH_ParamAccess.item);
            pManager[2].Optional = true;
            pManager.AddGenericParameter("MemberLoadParamsLoadDirectionGlobal", "MemberLoadParamsLoadDirectionGlobal", "MemberLoadParamsLoadDirectionGlobal", GH_ParamAccess.item);
            pManager[3].Optional = true;
            pManager.AddGenericParameter("MemberLoadParamsApplicableMeasuring", "MemberLoadParamsApplicableMeasuring", "MemberLoadParamsApplicableMeasuring", GH_ParamAccess.item);
            pManager[4].Optional = true;





            //pManager.AddGenericParameter("Activate", "Activate", "When its true, keep running so do not keep connecting true, use bottun component", GH_ParamAccess.item);


        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("MemberForceLoadParams", "MemberForceLoadParams", "this is MemberForceLoadParams", GH_ParamAccess.item);
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
            // Define variables to hold the input data
            MemberSpanInfo input_1 = new MemberSpanInfo();
            double input_2 = 0.0;
            double input_3 = 0.0;
            MemberLoadParams.LoadDirectionGlobal input_4 = MemberLoadParams.LoadDirectionGlobal.Z;
            MemberLoadParams.ApplicableMeasuring input_5 = MemberLoadParams.ApplicableMeasuring.AlongElement;


            // Access the input parameters individually and abort if data cannot be extracted
            if (!DA.GetData(0, ref input_1)) return;
            DA.GetData(1, ref input_2) ;
            DA.GetData(2, ref input_3) ;
            DA.GetData(3, ref input_4) ;
            DA.GetData(4, ref input_5) ;



            // We should now validate the data and warn the user if invalid data is supplied.
            TSD.API.Remoting.Loading.Create.MemberForceLoadParams output = null;
            string output_1 = "Processing or not started";



            if (1 == 1)
            {

                output = Create_MemberForceLoadParams_output.CreateMemberForceLoadParams(input_1,input_2,input_3,input_4,input_5);
                output_1 = "Succeeded";
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




        /*public override void AddedToDocument(GH_Document document)
        {
            base.AddedToDocument(document);

            if (!InputHasConnections(4))
            {
                // Create a Value List
                GH_BooleanToggle valueList_1 = new GH_BooleanToggle();
                valueList_1.CreateAttributes(); // Necessary to position it on canvas
                valueList_1.Attributes.Pivot = new System.Drawing.PointF(this.Attributes.Pivot.X - Params.OutputWidth - Params.InputWidth - 100, this.Attributes.Pivot.Y + Params.Input[4].Attributes.Pivot.Y - 12);


                // Add the value list to the document
                document.AddObject(valueList_1, false);

                //Connect
                Params.Input[4].AddSource(valueList_1);

            }

        }


        private bool InputHasConnections(int inputIndex)
        {
            if (inputIndex >= Params.Input.Count)
                return false;

            var inputParam = Params.Input[inputIndex];
            return inputParam.SourceCount > 0;
        }*/


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
            get { return new Guid("94384517-D795-4AA1-B048-7275BC10DD68"); }
        }
    }
}