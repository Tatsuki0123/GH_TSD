using System;
using System.Collections.Generic;
using System.Linq;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace TSD_API_ver101.Utils_List_IEnumerable_NoNeed
{
    public class IEnumerable2List : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public IEnumerable2List()
          : base("IEnumerable2List", "IEnu2List",
              "Convert IEnumerable to List",
              "TSD_API", "Utils")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IEnumerable", "IEnu", "Input IEnumeralbe", GH_ParamAccess.list);
            pManager.AddGenericParameter("Type", "Type", "Input Type", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("List", "List", "Input List", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Get input list
            string input_type = "Null";
            if (!DA.GetData(1, ref input_type)) return;

            switch (input_type)
            {
                case "Analysis_Type":
                    List<TSD.API.Remoting.Solver.AnalysisType> inputList_AT = new List<TSD.API.Remoting.Solver.AnalysisType>();
                    if (!DA.GetDataList(0, inputList_AT)) return;

                    // Convert list to IEnumerable
                    List<TSD.API.Remoting.Solver.AnalysisType> outputIEnumerable_AT = inputList_AT.ToList();

                    // Output the IEnumerable
                    DA.SetDataList(0, outputIEnumerable_AT);
                    break;


                case "Solver_IModel":
                    List<TSD.API.Remoting.Solver.IModel> inputList_SIM = new List<TSD.API.Remoting.Solver.IModel>();
                    if (!DA.GetDataList(0, inputList_SIM)) return;

                    // Convert list to IEnumerable
                    List<TSD.API.Remoting.Solver.IModel> outputIEnumerable_SIM = inputList_SIM.ToList();

                    // Output the IEnumerable
                    DA.SetDataList(0, outputIEnumerable_SIM);
                    break;

                default:
                    return;


            }


        }


        public override void AddedToDocument(GH_Document document)
        {
            base.AddedToDocument(document);

            // Create a Value List
            GH_ValueList valueList = new GH_ValueList();
            valueList.CreateAttributes(); // Necessary to position it on canvas
            valueList.Attributes.Pivot = new System.Drawing.PointF(Attributes.Pivot.X - 250, Attributes.Pivot.Y);

            // Set up the Value List items
            valueList.ListItems.Clear();
            valueList.ListItems.Add(new GH_ValueListItem("Analysis Type", "\"Analysis_Type\""));
            valueList.ListItems.Add(new GH_ValueListItem("Solver IModel", "\"Solver_IModel\""));

            // Add the value list to the document
            document.AddObject(valueList, false);

            // Connect the value list to the second input of your component
            /*document.ScheduleSolution(0, doc =>
            {
                int inputIndex = 1; // Index of the second input param to connect to
                int outputIndex = 0; // Index of the Value List output to connect
                doc.Objects.Connect(valueList.Attributes.GetTopLevel.DocObject.Guid, outputIndex, this.Guid, inputIndex);
            });*/
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
                return Properties.Resources.ListandIEnu;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("C657C0C7-D2D6-4D5A-B0C5-0BFC461F2ABA"); }
        }
    }
}