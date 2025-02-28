using System;
using System.Collections.Generic;
using System.Linq;
using GH_IO.Types;
using Google.Protobuf.WellKnownTypes;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Geometry;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Materials;
using TSD.API.Remoting.Sections;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_LoadingValueOptions

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("CreateLoadingValueOptions", "C_LoadingValueOptions",
            "Choosing Loading Value options ",
            "TSD_API", "Creating_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Static or Dynamic", "Static/Dynamic", "Input Static or dynamic, just connect to value list", GH_ParamAccess.item);
            pManager.AddGenericParameter("Loading Value Type", "LoadingValueType", "Input LoadingValue Type, just connect to value list", GH_ParamAccess.item);
            pManager.AddGenericParameter("Loading Direction", "LoadingDirection", "Input LoadingDirection, just connect to value list", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Mode", "Mode", "Input int Mode", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("LoadingValueOptions", "LoadingValueOptions", "this is the LoadingValueOptions", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            string input_1 = null;
            string input_2_pre = null;
            LoadingValueType input_2 = LoadingValueType.Unknown;
            string input_3_pre = null;
            LoadingDirection input_3 = LoadingDirection.Unknown;
            int input_4 = 0;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;
            if (!DA.GetData(1, ref input_2_pre)) return;
            if (!DA.GetData(2, ref input_3_pre)) return;
            if (!DA.GetData(3, ref input_4)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            LoadingValueOptions output_options = null;
            


            if (input_1 != null && input_2_pre!= null && input_3_pre != null)
            {
                switch (input_2_pre)
                {
                    case "Force":
                        input_2 = LoadingValueType.Force;
                        break;

                    case "Moment":
                        input_2 = LoadingValueType.Moment;
                        break;

                    case "Displacement":
                        input_2 = LoadingValueType.Displacement;
                        break;

                    case "Deflection":
                        input_2 = LoadingValueType.Deflection;
                        break;

                    case "Camber":
                        input_2 = LoadingValueType.Camber;
                        break;

                    case "CamberedDeflection":
                        input_2 = LoadingValueType.CamberedDeflection;
                        break;

                    case "EccentricityMoment":
                        input_2 = LoadingValueType.EccentricityMoment;
                        break;

                    default:
                        input_2 = LoadingValueType.Force;
                        break;
                }

                switch (input_3_pre)
                {
                    case "Axial":
                        input_3 = LoadingDirection.Axial;
                        break;

                    case "Major":
                        input_3 = LoadingDirection.Major;
                        break;

                    case "Minor":
                        input_3 = LoadingDirection.Minor;
                        break;

                    case "MajorPrincipal":
                        input_3 = LoadingDirection.MajorPrincipal;
                        break;

                    case "MinorPrincipal":
                        input_3 = LoadingDirection.MinorPrincipal;
                        break;

                    default:
                        input_3 = LoadingDirection.Major;
                        break;
                }





                switch (input_1)
                {
                    case  "StaticValue":
                        output_options = LoadingValueOptions.StaticValue(input_2, input_3);
                        break;

                    case "LoadcaseValue":
                        output_options = LoadingValueOptions.LoadcaseValue(input_2, input_3,input_4);
                        break;
                    


                    default:
                        output_options = LoadingValueOptions.StaticValue(input_2, input_3);
                        break;


                }
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetData(0, output_options);




        }

        

        public override void AddedToDocument(GH_Document document)
        {
            base.AddedToDocument(document);


        

            // Create a Value List
            GH_ValueList valueList_1 = new GH_ValueList();
            valueList_1.CreateAttributes(); // Necessary to position it on canvas
            valueList_1.Attributes.Pivot = new System.Drawing.PointF(this.Attributes.Pivot.X - 300, this.Attributes.Pivot.Y - 70);
            GH_ValueList valueList_2 = new GH_ValueList();
            valueList_2.CreateAttributes(); // Necessary to position it on canvas
            valueList_2.Attributes.Pivot = new System.Drawing.PointF(this.Attributes.Pivot.X - 300, this.Attributes.Pivot.Y -40);
            GH_ValueList valueList_3 = new GH_ValueList();
            valueList_3.CreateAttributes(); // Necessary to position it on canvas
            valueList_3.Attributes.Pivot = new System.Drawing.PointF(this.Attributes.Pivot.X - 300, this.Attributes.Pivot.Y - 10);

            // Set up the Value List items
            valueList_1.ListItems.Clear();
            valueList_1.ListItems.Add(new GH_ValueListItem("StaticValue", "\"StaticValue\""));
            valueList_1.ListItems.Add(new GH_ValueListItem("LoadcaseValue", "\"LoadcaseValue\""));

            valueList_2.ListItems.Clear();
            valueList_2.ListItems.Add(new GH_ValueListItem("Force", "\"Force\""));
            valueList_2.ListItems.Add(new GH_ValueListItem("Moment", "\"Moment\""));
            valueList_2.ListItems.Add(new GH_ValueListItem("Displacement", "\"Displacement\""));
            valueList_2.ListItems.Add(new GH_ValueListItem("Deflection", "\"Deflection\""));
            valueList_2.ListItems.Add(new GH_ValueListItem("Camber", "\"Camber\""));
            valueList_2.ListItems.Add(new GH_ValueListItem("CamberedDeflection", "\"CamberedDeflection\""));
            valueList_2.ListItems.Add(new GH_ValueListItem("EccentricityMoment", "\"EccentricityMoment\""));

            valueList_3.ListItems.Clear();
            valueList_3.ListItems.Add(new GH_ValueListItem("Axial", "\"Axial\""));
            valueList_3.ListItems.Add(new GH_ValueListItem("Major", "\"Major\""));
            valueList_3.ListItems.Add(new GH_ValueListItem("Minor", "\"Minor\""));
            valueList_3.ListItems.Add(new GH_ValueListItem("MajorPrincipal", "\"MajorPrincipal\""));
            valueList_3.ListItems.Add(new GH_ValueListItem("MinorPrincipal", "\"MinorPrincipal\""));

            // Add the value list to the document
            document.AddObject(valueList_1, false);
            document.AddObject(valueList_2, false);
            document.AddObject(valueList_3, false);
            

         

            // Connect the value list to the second input of your component
            /*document.ScheduleSolution(0, doc =>
            {
                int inputIndex = 1; // Index of the second input param to connect to
                int outputIndex = 0; // Index of the Value List output to connect
                doc.Objects.Connect(valueList.Attributes.GetTopLevel.DocObject.Guid, outputIndex, this.Guid, inputIndex);
            });*/
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
            get { return new Guid("2EB18402-CA2F-4A6A-996E-7E3FC2378872"); }
        }
    }
}