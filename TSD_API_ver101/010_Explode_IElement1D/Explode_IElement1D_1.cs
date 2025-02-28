using System;
using System.Collections.Generic;
using System.Linq;
using GH_IO.Types;
using Google.Protobuf.WellKnownTypes;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Geometry;
using Rhino.Geometry;
using Rhino.Render;
using TSD.API.Remoting;
using TSD.API.Remoting.Common;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Sections;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_IElement1D_Explode

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_IElement1D_1", "E_IElem1D_1",
            "Explodeing the IElement1D ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IElement1D", "IElem1D", "Input IElement", GH_ParamAccess.item);
            pManager.AddGenericParameter("List_INode", "List_INode", "Input All INodes as a List", GH_ParamAccess.list);

        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Element1D", "Elem1D", "this is 2D element", GH_ParamAccess.item);
            pManager.AddGenericParameter("Index", "Index", "this is INode index", GH_ParamAccess.item);
            pManager.AddGenericParameter("Start Point", "SP", "this is INode Point", GH_ParamAccess.item);
            pManager.AddGenericParameter("End Point", "EP", "this is INode Point", GH_ParamAccess.item);
            pManager.AddGenericParameter("Start Point_INode_Index", "SP_idx", "this is INode Point index start", GH_ParamAccess.item);
            pManager.AddGenericParameter("End Point_INode_Index", "EP_idx", "this is INode Point index end", GH_ParamAccess.item);
            pManager.AddGenericParameter("Material", "Mat", "this is the material", GH_ParamAccess.item);
            pManager.AddGenericParameter("Section", "Sec", "this is the Section", GH_ParamAccess.item);
            pManager.AddGenericParameter("Dof_start", "Dot_s", "this is Dof start point", GH_ParamAccess.item);
            pManager.AddGenericParameter("Dof_end", "Dot_end", "this is Dof end point", GH_ParamAccess.item);
            pManager.AddGenericParameter("RigidZone_length_start", "Rigid_Start", "this is the length of rigid zone from the start", GH_ParamAccess.item);
            pManager.AddGenericParameter("RigidZone_length_end", "Rigid_End", "this is the length of rigid zone from the end", GH_ParamAccess.item);
            pManager.AddGenericParameter("Element Type", "Type", "this is the Element Type", GH_ParamAccess.item);


        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Solver.IElement1D input_1 = null;
            List<TSD.API.Remoting.Solver.INode> input_2 = new List<INode>();

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;
            if (!DA.GetDataList(1,input_2)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            int output_start_INode_index = -1;
            int output_end_INode_index = -1;
            int output_index = -1;
            Point3d output_start_point = new Point3d();
            Point3d output_end_point = new Point3d();
            Line output_element1D = new Line();
            string output_material = "N.A";
            ISolverElementSection output_section_pre = null;
            string output_section = "Can not get from IELement1D cuz of API bug?. use IMemberSpan to get the section profile";
            DegreeOfFreedom dof_start = DegreeOfFreedom.Free | DegreeOfFreedom.Fx | DegreeOfFreedom.Fy | DegreeOfFreedom.Fz | DegreeOfFreedom.Mx | DegreeOfFreedom.My| DegreeOfFreedom.Mz;
            DegreeOfFreedom dof_end = DegreeOfFreedom.Free | DegreeOfFreedom.Fx | DegreeOfFreedom.Fy | DegreeOfFreedom.Fz | DegreeOfFreedom.Mx | DegreeOfFreedom.My | DegreeOfFreedom.Mz;
            IMemberSection output_section_pre_1 = null;
            IAnalysisElementSection output_section_pre_0 = null;
            double output_rigid_start = 0.0;
            double output_rigid_end = 0.0;
            string output_type = "N.A";






            if (input_1 != null && input_2 != null)
            {
                output_start_INode_index = input_1.GetNodeIndex(0);
                output_end_INode_index = input_1.GetNodeIndex(1);
                output_index = input_1.Index;


                output_start_point = new Point3d(input_2.FirstOrDefault(item => item.Index == output_start_INode_index).Coordinates.X, input_2.FirstOrDefault(item => item.Index == output_start_INode_index).Coordinates.Y, input_2.FirstOrDefault(item => item.Index == output_start_INode_index).Coordinates.Z);
                output_end_point = new Point3d(input_2.FirstOrDefault(item => item.Index == output_end_INode_index).Coordinates.X, input_2.FirstOrDefault(item => item.Index == output_end_INode_index).Coordinates.Y, input_2.FirstOrDefault(item => item.Index == output_end_INode_index).Coordinates.Z);
                output_element1D = new Line(output_start_point, output_end_point);
                output_material = input_1.Material.Name;
                output_section_pre = input_1.ElementSection as ISolverElementSection;
                output_section_pre_0 = output_section_pre as IAnalysisElementSection;
                output_section_pre_1 = output_section_pre as IMemberSection;
                //output_section = output_section_pre_1.PhysicalSection.Value.ShortName;
                dof_start = input_1.GetDegreeOfFreedom(0);
                dof_end = input_1.GetDegreeOfFreedom(1);
                output_rigid_start = input_1.GetRigidZone(0);   
                output_rigid_end = input_1.GetRigidZone(1);
                output_type = input_1.ElementType.ToString();
                
                
                
                
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetData(0, output_element1D);
            DA.SetData(1, output_index);
            DA.SetData(2, output_start_point);
            DA.SetData(3, output_end_point);
            DA.SetData(4, output_start_INode_index);
            DA.SetData(5, output_end_INode_index);
            DA.SetData(6, output_material);
            DA.SetData(7, output_section);
            DA.SetData(8, dof_start);
            DA.SetData(9, dof_end);
            DA.SetData(10, output_rigid_start);
            DA.SetData(11, output_rigid_end);
            DA.SetData(12, output_type);
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
            get { return new Guid("009288C5-3F6B-488A-9797-08853EBB70C0"); }
        }
    }
}