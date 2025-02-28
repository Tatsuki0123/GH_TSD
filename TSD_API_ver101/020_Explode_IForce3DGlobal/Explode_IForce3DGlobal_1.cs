using System;
using System.Collections.Generic;
using System.Linq;
using GH_IO.Types;
using Google.Protobuf.WellKnownTypes;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Geometry;
using TSD.API.Remoting.Materials;
using TSD.API.Remoting.Sections;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_IFOrce3DGlobal_Explode

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_IForce3DGlobal_1", "E_IForce3DGlobal_1",
            "Explodeing the IForce3DGlobal ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IForce3DGlobal", "IForce3DGlobal", "Input IForce3DGlobal", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Forces vector", "Vector_Force", "this is force vector", GH_ParamAccess.item);
            pManager.AddGenericParameter("Fx[N]", "Fx[N]","this is force Fx", GH_ParamAccess.item);
            pManager.AddGenericParameter("Fy[N]", "Fy[N]", "this is force Fy", GH_ParamAccess.item);
            pManager.AddGenericParameter("Fz[N]", "Fz[N]", "this is force Fz", GH_ParamAccess.item);
            pManager.AddGenericParameter("Moment vector", "Vector_Moment", "this is Moment vector", GH_ParamAccess.item);
            pManager.AddGenericParameter("Mx[Nmm]", "Mx[Nmm]", "this is Moment about x axis", GH_ParamAccess.item);
            pManager.AddGenericParameter("My[Nmm]", "My[Nmm]", "this is Moment about y axis", GH_ParamAccess.item);
            pManager.AddGenericParameter("Mz[Nmm]", "Mz[Nmm]", "this is Moment about z axis", GH_ParamAccess.item);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            TSD.API.Remoting.Loading.IForce3DGlobal input_1 = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;

            // We should now validate the data and warn the user if invalid data is supplied.
            Vector3d output_force_vec = new Vector3d();
            double output_fx = 0.0;
            double output_fy = 0.0;
            double output_fz= 0.0;
            Vector3d output_moment_vec = new Vector3d();
            double output_mx = 0.0;
            double output_my = 0.0;
            double output_mz = 0.0;






            if (input_1 != null)
            {
                output_force_vec = new Vector3d(input_1.Forces.X,input_1.Forces.Y,input_1.Forces.Z);
                output_fx = input_1.Fx;
                output_fy = input_1.Fy;
                output_fz = input_1.Fz;
                output_moment_vec = new Vector3d(input_1.Moments.X,input_1.Moments.Y,input_1.Moments.Z);
                output_mx = input_1.Mx;
                output_my = input_1.My;
                output_mz = input_1.Mz;
                


            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "its not activated");

            }

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:


            // Finally assign the spiral to the output parameter.
            DA.SetData(0, output_force_vec);
            DA.SetData(1, output_fx);
            DA.SetData(2, output_fy);
            DA.SetData(3, output_fz);
            DA.SetData(4, output_moment_vec);
            DA.SetData(5, output_mx);
            DA.SetData(6, output_my);
            DA.SetData(7, output_mz);



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
            get { return new Guid("359B2261-2880-4A8C-9739-76CB8E6C0792"); }
        }
    }
}