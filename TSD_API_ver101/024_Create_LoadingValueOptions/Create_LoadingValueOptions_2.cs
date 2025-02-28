using System;
using System.Linq;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Rhino.Geometry;
using System.Drawing;
using TSD.API.Remoting.Loading;

namespace TSD_API_ver101_LoadingValueOptions2
{
    public class Get_Instance : GH_Component
    {
        public Get_Instance()
          : base("CreateLoadingValueOptions_2", "C_LoadingValueOptions_2",
              "Choosing Loading Value options ver2 ",
              "TSD_API", "Creating_Functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Static or Dynamic", "Static/Dynamic", "Input Static or dynamic, just connect to value list", GH_ParamAccess.item);
            pManager.AddGenericParameter("Loading Value Type", "LoadingValueType", "Input LoadingValue Type, just connect to value list", GH_ParamAccess.item);
            pManager.AddGenericParameter("Loading Direction", "LoadingDirection", "Input LoadingDirection, just connect to value list", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Mode", "Mode", "Input int Mode", GH_ParamAccess.item, 1);
            Params.Input[3].Optional = true;
            pManager.AddGenericParameter("SeismicCombinationValueType", "SeismicCombinationValueType", "Input SeismicCombinationValueType", GH_ParamAccess.item);
            Params.Input[4].Optional = true;
            pManager.AddGenericParameter("Reduced", "Reduced", "Input reduced", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("LoadingValueOptions", "LoadingValueOptions", "This is the LoadingValueOptions", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string input_1 = null;
            string input_2_pre = null;
            LoadingValueType input_2 = LoadingValueType.Unknown;
            string input_3_pre = null;
            LoadingDirection input_3 = LoadingDirection.Unknown;
            int input_4 = 0;
            SeismicCombinationValueType input_5 = SeismicCombinationValueType.Unknown;
            string input_5_pre = null;
            bool input_6 = false;

            if (!DA.GetData(0, ref input_1)) return;
            if (!DA.GetData(1, ref input_2_pre)) return;
            if (!DA.GetData(2, ref input_3_pre)) return;
            if (!DA.GetData(3, ref input_4)) return;
            if (!DA.GetData(4, ref input_5_pre)) return;
            if (!DA.GetData(5, ref input_6)) return;

            LoadingValueOptions output_options = null;

            if (input_1 != null && input_2_pre != null && input_3_pre != null)
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

                input_5 = (SeismicCombinationValueType)Enum.Parse(typeof(SeismicCombinationValueType), input_5_pre);

                switch (input_1)
                {
                    case "StaticValue":
                        output_options = LoadingValueOptions.StaticValue(input_2, input_3,input_6);
                        break;
                    case "LoadcaseValue":
                        output_options = LoadingValueOptions.LoadcaseValue(input_2, input_3, input_4,input_6);
                        break;
                    case "CombinationValue":
                        output_options = LoadingValueOptions.CombinationValue(input_2,input_3,input_5,input_6);
                        break;


                    default:
                        output_options = LoadingValueOptions.StaticValue(input_2, input_3, input_6);
                        break;
                }

                

            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "It's not activated");
            }

            DA.SetData(0, output_options);
        }


        //Adding components
        private bool _valueListsAdded = false;

        public override void AddedToDocument(GH_Document document)
        {
            base.AddedToDocument(document);

            if (_valueListsAdded) return;

                AddValueLists(document);
                _valueListsAdded = true;
           
        }

        private void AddValueLists(GH_Document doc)
        {
            if (!InputHasConnections(0))
            {
                var valueList_1 = CreateValueList1();
                doc.AddObject(valueList_1, false);
                Params.Input[0].AddSource(valueList_1);

            }

            if (!InputHasConnections(1))
            {
                var valueList_2 = CreateValueList2();
                doc.AddObject(valueList_2, false);
                Params.Input[1].AddSource(valueList_2);

            }

            if (!InputHasConnections(2))
            {
                var valueList_3 = CreateValueList3();
                doc.AddObject(valueList_3, false);
                Params.Input[2].AddSource(valueList_3);

            }


            if (!InputHasConnections(4))
            {
                var valueList_4 = CreateValueList4();
                doc.AddObject(valueList_4, false);
                Params.Input[4].AddSource(valueList_4);

            }


            if (!InputHasConnections(5))
            {
                var valueList_5 = CreateBooleanToggle5();
                doc.AddObject(valueList_5, false);
                Params.Input[5].AddSource(valueList_5);

            }



 
        }

        private bool InputHasConnections(int inputIndex)
        {
            if (inputIndex >= Params.Input.Count)
                return false;

            var inputParam = Params.Input[inputIndex];
            return inputParam.SourceCount > 0;
        }

        private GH_ValueList CreateValueList1()
        {
            var valueList_1 = new GH_ValueList
            {
                NickName = "ValueList1"
            };
            valueList_1.CreateAttributes();

            valueList_1.ListItems.Clear();
            valueList_1.ListItems.Add(new GH_ValueListItem("StaticValue", "\"StaticValue\""));
            valueList_1.ListItems.Add(new GH_ValueListItem("LoadcaseValue", "\"LoadcaseValue\""));
            valueList_1.ListItems.Add(new GH_ValueListItem("CombinationValue", "\"CombinationValue\""));
            valueList_1.Attributes.Pivot = new PointF(this.Attributes.Pivot.X - Params.OutputWidth - Params.InputWidth - 100, this.Attributes.Pivot.Y + Params.Input[0].Attributes.Pivot.Y - 11);
            //remember one input param takes 39 

            return valueList_1;
        }

        private GH_ValueList CreateValueList2()
        {
            var valueList_2 = new GH_ValueList
            {
                NickName = "ValueList2"
            };
            valueList_2.CreateAttributes();

            valueList_2.ListItems.Clear();
            valueList_2.ListItems.Add(new GH_ValueListItem("Force", "\"Force\""));
            valueList_2.ListItems.Add(new GH_ValueListItem("Moment", "\"Moment\""));
            valueList_2.ListItems.Add(new GH_ValueListItem("Displacement", "\"Displacement\""));
            valueList_2.ListItems.Add(new GH_ValueListItem("Deflection", "\"Deflection\""));
            valueList_2.ListItems.Add(new GH_ValueListItem("Camber", "\"Camber\""));
            valueList_2.ListItems.Add(new GH_ValueListItem("CamberedDeflection", "\"CamberedDeflection\""));
            valueList_2.ListItems.Add(new GH_ValueListItem("EccentricityMoment", "\"EccentricityMoment\""));
            valueList_2.Attributes.Pivot = new PointF(this.Attributes.Pivot.X - Params.OutputWidth - Params.InputWidth - 100, this.Attributes.Pivot.Y + Params.Input[1].Attributes.Pivot.Y - 11);

            return valueList_2;
        }

        private GH_ValueList CreateValueList3()
        {
            var valueList_3 = new GH_ValueList
            {
                NickName = "ValueList3"
            };
            valueList_3.CreateAttributes();

            valueList_3.ListItems.Clear();
            valueList_3.ListItems.Add(new GH_ValueListItem("Axial", "\"Axial\""));
            valueList_3.ListItems.Add(new GH_ValueListItem("Major", "\"Major\""));
            valueList_3.ListItems.Add(new GH_ValueListItem("Minor", "\"Minor\""));
            valueList_3.ListItems.Add(new GH_ValueListItem("MajorPrincipal", "\"MajorPrincipal\""));
            valueList_3.ListItems.Add(new GH_ValueListItem("MinorPrincipal", "\"MinorPrincipal\""));
            valueList_3.Attributes.Pivot = new PointF(this.Attributes.Pivot.X - Params.OutputWidth - Params.InputWidth - 100, this.Attributes.Pivot.Y + Params.Input[2].Attributes.Pivot.Y - 11);

            return valueList_3;
        }



        private GH_ValueList CreateValueList4()
        {
            var valueList_4 = new GH_ValueList
            {
                NickName = "ValueList4"
            };
            valueList_4.CreateAttributes();

            valueList_4.ListItems.Clear();
            valueList_4.ListItems.Add(new GH_ValueListItem("Design", "\"Design\""));
            valueList_4.ListItems.Add(new GH_ValueListItem("Static", "\"Static\""));
            valueList_4.ListItems.Add(new GH_ValueListItem("Seismic", "\"Seismic\""));
            valueList_4.ListItems.Add(new GH_ValueListItem("StaticPlusSeismic", "\"StaticPlusSeismic\""));
            valueList_4.ListItems.Add(new GH_ValueListItem("StaticMinusSeismic", "\"StaticMinusSeismic\""));
            valueList_4.Attributes.Pivot = new PointF(this.Attributes.Pivot.X - Params.OutputWidth - Params.InputWidth - 100, this.Attributes.Pivot.Y + Params.Input[4].Attributes.Pivot.Y - 11);

            return valueList_4;
        }

        private GH_BooleanToggle CreateBooleanToggle5()
        {
            var valueList_5 = new GH_BooleanToggle();
            valueList_5.CreateAttributes();

            valueList_5.Attributes.Pivot = new PointF(this.Attributes.Pivot.X - Params.OutputWidth - Params.InputWidth - 100, this.Attributes.Pivot.Y + Params.Input[5].Attributes.Pivot.Y - 11);

            return valueList_5;
        }


        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return TSD_API_ver101.Properties.Resources.API_icon;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("D1513676-C55A-42B7-8D1E-E591FCF35FC0"); }
        }
    }
}

