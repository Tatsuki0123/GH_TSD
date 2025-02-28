using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_ILoad_Corresponding

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Get_ILoad_Corresponding", "G_ILoad_Corresponding",
            "Getting the ILoad of corresponding one. ",
            "TSD_API", "Basic_Functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ILoad", "ILoad", "Input ILoad", GH_ParamAccess.item);
            pManager.AddGenericParameter("LoadType", "LoadType", "Input LoadType", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("ILoad_Corresponding", "ILoad_Corresponding", "this is ILoad Corresponding object", GH_ParamAccess.item);
            pManager.AddGenericParameter("Type", "Type", "this is Type", GH_ParamAccess.item);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Loading.ILoad input_1 = null;
            LoadType input_2 = LoadType.Unknown;


            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;
            if (!DA.GetData(1, ref input_2)) return;


            // We should now validate the data and warn the user if invalid data is supplied.

            if (input_1 != null && input_2 !=LoadType.Unknown)
            {
                switch (input_2)
                {
                    case LoadType.Point:
                        IPointLoad output_point = input_1 as IPointLoad;
                        DA.SetData(0, output_point);
                        DA.SetData(1, output_point.GetType());
                        break;
                    case LoadType.UniformLine:
                        IUniformLineLoad output_ul = input_1 as IUniformLineLoad;
                        DA.SetData(0, output_ul);
                        DA.SetData(1, output_ul.GetType());
                        break;
                    case LoadType.UniformRectangular:
                        IUniformRectangularLoad output_ur = input_1 as IUniformRectangularLoad;
                        DA.SetData(0, output_ur);
                        DA.SetData(1, output_ur.GetType());
                        break;
                    case LoadType.UniformAreaElement:
                        IUniformAreaElementLoad output_uae = input_1 as IUniformAreaElementLoad;
                        DA.SetData(0, output_uae);
                        DA.SetData(1, output_uae.GetType());
                        break;
                    case LoadType.VariableAreaElement:
                        IVariableAreaElementLoad output_vae = input_1 as IVariableAreaElementLoad;
                        DA.SetData(0, output_vae);
                        DA.SetData(1, output_vae.GetType());
                        break;
                    case LoadType.Member:
                        IMemberLoad output_m = input_1 as IMemberLoad;
                        DA.SetData(0, output_m);
                        DA.SetData(1, output_m.GetType());
                        break;
                    case LoadType.Nodal:
                        INodalLoad output_n = input_1 as INodalLoad;
                        DA.SetData(0, output_n);
                        DA.SetData(1, output_n.GetType());
                        break;
                    case LoadType.VariablePolygonal:
                        IVariablePolygonalLoad output_vp = input_1 as IVariablePolygonalLoad;
                        DA.SetData(0, output_vp);
                        DA.SetData(1, output_vp.GetType());
                        break;
                    case LoadType.ConstructionPlane:
                        IConstructionPlaneLoad output_cp = input_1 as IConstructionPlaneLoad;
                        DA.SetData(0, output_cp);
                        DA.SetData(1, output_cp.GetType());
                        break;
                    case LoadType.Slab:
                        ISlabLoad output_s = input_1 as ISlabLoad;
                        DA.SetData(0, output_s);
                        DA.SetData(1, output_s.GetType());
                        break;
                    case LoadType.Settlement:
                        ISettlementLoad output_se = input_1 as ISettlementLoad;
                        DA.SetData(0, output_se);
                        DA.SetData(1, output_se.GetType());
                        break;
                    case LoadType.Temperature:
                        ITemperatureLoad output_t = input_1 as ITemperatureLoad;
                        DA.SetData(0, output_t);
                        DA.SetData(1, output_t.GetType());
                        break;
                    case LoadType.UniformPolygonal:
                        IUniformPolygonalLoad output_up = input_1 as IUniformPolygonalLoad;
                        DA.SetData(0, output_up);
                        DA.SetData(1, output_up.GetType());
                        break;
                    case LoadType.Perimeter:
                        IPerimeterLoad output_p = input_1 as IPerimeterLoad;
                        DA.SetData(0, output_p);
                        DA.SetData(1, output_p.GetType());
                        break;
                    case LoadType.Snow:
                        ISnowLoad output_snow = input_1 as ISnowLoad;
                        DA.SetData(0, output_snow);
                        DA.SetData(1, output_snow.GetType());
                        break;
                    case LoadType.Diaphragm:
                        IDiaphragmLoad output_d = input_1 as IDiaphragmLoad;
                        DA.SetData(0, output_d);
                        DA.SetData(1, output_d.GetType());
                        break;
                    case LoadType.LineAncillary:
                        ILineAncillaryLoad output_la = input_1 as ILineAncillaryLoad;
                        DA.SetData(0, output_la);
                        DA.SetData(1, output_la.GetType());
                        break;
                    case LoadType.Equipment:
                        IEquipmentLoad output_e = input_1 as IEquipmentLoad;
                        DA.SetData(0, output_e);
                        DA.SetData(1, output_e.GetType());
                        break;
                    default:
                        throw new ArgumentException("Invalid load type");
                }
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            
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
            get { return new Guid("2D0FAA01-32FC-4A62-872A-9077647DE959"); }
        }
    }
}