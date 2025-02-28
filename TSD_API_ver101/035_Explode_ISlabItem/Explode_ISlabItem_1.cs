using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using GH_IO.Types;
using Google.Protobuf.WellKnownTypes;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Geometry;
using Grasshopper.Kernel.Parameters.Hints;
using Grasshopper.Kernel.Types;
using Rhino.DocObjects;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;

namespace TSD_API_ver101_ISlabItem_Explode

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_ISlabItem_1", "E_ISlabItem_1",
            "Explodeing the ISlabItem ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ISlabItem", "ISlabItem", "Input ISlabItem", GH_ParamAccess.item);
            pManager.AddGenericParameter("IConstructionPoint", "IConstructionPoint", "Input IConstructionPoint", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {

            pManager.AddGenericParameter("Slab Endge Curve", "SlabEdge", "this is the slab Endge", GH_ParamAccess.item);

            pManager.AddGenericParameter("Corner Points", "Corner Points", "the Corner Points", GH_ParamAccess.list);


            pManager.AddGenericParameter("Name", "N", "this is name", GH_ParamAccess.item);
            pManager.AddGenericParameter("Index", "Index", "this is index", GH_ParamAccess.item);
            pManager.AddGenericParameter("List of Construction Point indicies", "List_ConstPtindicies", "this is the index of IConstructionPoint", GH_ParamAccess.list);
            pManager.AddGenericParameter("ID", "ID", "this is the ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("Entity Type Name", "TypeName", "this is the Entity type name", GH_ParamAccess.item);
            pManager.AddGenericParameter("ISlabItemData", "ISlabItemData", "this is the ISlabItemData", GH_ParamAccess.item);
            pManager.AddGenericParameter("Rotation Angle [rad]", "Rotation angle[rad]", "this is the rotation angle of the slab, used for one way slab", GH_ParamAccess.item);
            pManager.AddGenericParameter("Construction Plane Index", "Construction Plane Index", "this is the corresponding construction plane index", GH_ParamAccess.item);
            pManager.AddGenericParameter("Construction Plane ID", "Construction Plane ID", "this is the corresponding construction plane id", GH_ParamAccess.item);

            pManager.AddGenericParameter("Slab Surface", "SlabSurface", "this is the slab Surface", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Structure.ISlabItem input_1 = null;
            List<TSD.API.Remoting.Structure.IConstructionPoint> input_2 = new List<IConstructionPoint>();

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;
            if (!DA.GetDataList(1, input_2)) return;

            // We should now validate the data and warn the user if invalid data is supplied.

            Polyline output_slab_edge = null;
            List<Point3d> output_points = new List<Point3d>(); 
            List<Point3d> output_points_temp = new List<Point3d>();
            string output_name = "N.A";
            int output_index = -1;
            List<int> output_constpt_idx = new List<int>();
          
            Guid output_id = Guid.Empty;
            string output_type_name = null;
            ISlabItemData output_slabdata = null;
            double output_angle = 0;
            int output_constplane_index = -1;
            Guid output_constplane_id = Guid.Empty;
            Surface output_slab_surface = null;

            ICheckResult output_checkresult = null;
            ICheckResult output_checkresultBearingPressure = null;
            ICheckResult output_checkresultDeflection = null;
            ICheckResult output_checkresultslabdepth = null;

          
            

            if (input_1 != null)
            {
                
                output_name = input_1.Name;
                output_index = input_1.Index;
                output_constpt_idx = input_1.ConstructionPointIndices.ToList();
                output_id = input_1.Id;
                output_type_name = input_1.EntityType.ToString();
                output_slabdata = input_1.SlabItemData.Value;
                output_angle = input_1.RotationAngle.Value;
                output_constplane_index = input_1.ConstructionPlaneInfo.Index;
                output_constplane_id = input_1.ConstructionPlaneInfo.Id;

                

                foreach(var item in output_constpt_idx)
                {
                    var x = input_2.First(i => i.Index == item).Coordinates.Value.X;
                    var y = input_2.First(i => i.Index == item).Coordinates.Value.Y;
                    var z = input_2.First(i => i.Index == item).Coordinates.Value.Z;

                    Point3d point_temp = new Point3d(x,y,z);

                    output_points.Add(point_temp);
                  
                }

                
                foreach(var item in output_points)
                {
                    output_points_temp.Add(item);
                }
                output_points_temp.Add(output_points[0]);

                output_slab_edge = new Polyline(output_points_temp);
                PolylineCurve polycurve_temp = new PolylineCurve(output_slab_edge);
                Curve curve_temp = polycurve_temp;

                output_slab_surface = Brep.CreatePlanarBreps(curve_temp)[0].Surfaces[0];
                




            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetData(0, output_slab_edge);
            DA.SetDataList(1, output_points);
            DA.SetData(2, output_name);
            DA.SetData(3, output_index);
            DA.SetDataList(4, output_constpt_idx);
            DA.SetData(5, output_id);
            DA.SetData(6, output_type_name);
            DA.SetData(7, output_slabdata);
            DA.SetData(8, output_angle);
            DA.SetData(9, output_constplane_index);
            DA.SetData(10, output_constplane_id);
            DA.SetData(11, output_slab_surface);

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
            get { return new Guid("6FA76291-B327-4E84-A8C1-B2352601BEB5"); }
        }
    }
}