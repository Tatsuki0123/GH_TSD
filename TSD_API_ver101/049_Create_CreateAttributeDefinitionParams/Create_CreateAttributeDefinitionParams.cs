using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Rhino.Geometry;
using Rhino.UI;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.UserDefinedAttributes;

namespace TSD_API_ver101_CreateAttributeDefinitionParams


{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Create_CreateAttributeDefinitionParams", "C_CreateAttributeDefinitionParams",
            "Creating the CreateAttributeDefinitionParams",
            "TSD_API", "Creating_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Structure IModel", "stIModel", "Input structure IModel", GH_ParamAccess.item);
            pManager.AddGenericParameter("Name of the UserDefined Attribute", "NameOfUDA", "Input name of the user defined attribute", GH_ParamAccess.item);
            pManager.AddGenericParameter("Attribute Value Type", "AValueType", "Attribute Value Type", GH_ParamAccess.item);
            pManager.AddGenericParameter("Attribute Value Source", "AValueSource", "Attribute Value Source", GH_ParamAccess.item);

            pManager.AddGenericParameter("Attribute Value List", "AValueList", "Attribute Value List for predefined source", GH_ParamAccess.list);
            
            pManager[4].Optional = true;

        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("CreateAttributeDefinitionParams", "CreateAttributeDefinitionParams", "this is List of Create Attribute Definition Param", GH_ParamAccess.item);

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
            string input_2 = string.Empty;
            string input_3 = "AttributeValueType.Unknown"; 
            AttributeValueType input_3_mod =AttributeValueType.Unknown;

            string input_4 = "AttributeValueSource.Unknown";
            AttributeValueSource input_4_mod = AttributeValueSource.Unknown;
            List<string> input_5 = new List<string>();

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;
            if(!DA.GetData(1, ref input_2)) return;
            if (!DA.GetData(2, ref input_3)) return;
            if (!DA.GetData(3, ref input_4)) return;

            if( input_4 == "PredefinedList")
            {
                DA.GetDataList(4, input_5);
            }
            

            
            

            // We should now validate the data and warn the user if invalid data is supplied.
            TSD.API.Remoting.UserDefinedAttributes.Create.CreateAttributeDefinitionParams output = null;

            if (input_1 != null && input_2 != null && input_3 != "AttributeValueType.Unknown" && input_4 != "AttributeValueSource.Unknown")
            {

                switch (input_3)
                {
                    case "AttributeValueType.String":
                        input_3_mod = AttributeValueType.String;
                        break;

                    case "AttributeValueType.Number":
                        input_3_mod = AttributeValueType.Number;
                        break;

                    default:
                        input_3_mod = AttributeValueType.String;
                        break;
                }


                switch (input_4)
                {
                    case "AttributeValueSource.UserDefined":
                        input_4_mod = AttributeValueSource.UserDefined;
                        break;

                    case "AttributeValueSource.PredefinedList":
                        input_4_mod = AttributeValueSource.PredefinedList;
                        break;

                    default:
                        input_4_mod = AttributeValueSource.UserDefined;
                        break;
                }


                output = TSD_API_ver101_CreateAttributeDefinitionParams.Create_IAttributeDefinition_output.CreateCreateAttributeDefinitionParams(input_1,input_2,input_3_mod,input_4_mod,input_5);
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetData(0, output);
        }


        public override void AddedToDocument(GH_Document document)
        {
            base.AddedToDocument(document);

            if (!InputHasConnections(2))
            {
                GH_ValueList valueList_1 = new GH_ValueList();
                valueList_1.CreateAttributes(); // Necessary to position it on canvas
                valueList_1.Attributes.Pivot = new System.Drawing.PointF(this.Attributes.Pivot.X - Params.OutputWidth - Params.InputWidth - 100, this.Attributes.Pivot.Y + Params.Input[2].Attributes.Pivot.Y - 12);
               
                // Set up the Value List items
                valueList_1.ListItems.Clear();
                valueList_1.ListItems.Add(new GH_ValueListItem("AttributeValueType.String", "\"String\""));
                valueList_1.ListItems.Add(new GH_ValueListItem("AttributeValueType.Number", "\"Number\""));


               

                // Add the value list to the document
                document.AddObject(valueList_1, false);
               

                //Connect
                Params.Input[2].AddSource(valueList_1);

            }

            if (!InputHasConnections(3))
            {
                GH_ValueList valueList_2 = new GH_ValueList();
                valueList_2.CreateAttributes(); // Necessary to position it on canvas
                valueList_2.Attributes.Pivot = new System.Drawing.PointF(this.Attributes.Pivot.X - Params.OutputWidth - Params.InputWidth - 100, this.Attributes.Pivot.Y + Params.Input[3].Attributes.Pivot.Y - 12);

                valueList_2.ListItems.Clear();
                valueList_2.ListItems.Add(new GH_ValueListItem("AttributeValueSource.UserDefined", "\"UserDefined\""));
                valueList_2.ListItems.Add(new GH_ValueListItem("AttributeValueSource.PredefinedList", "\"PredefinedList\""));


                document.AddObject(valueList_2, false);

                //Connect
                Params.Input[3].AddSource(valueList_2);
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
            get { return new Guid("99515D64-E541-4DF8-AF20-A3FC35E9ACE2"); }
        }
    }
}