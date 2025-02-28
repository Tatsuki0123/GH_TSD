using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting;
using TSD.API.Remoting.Document;
using TSD.API.Remoting.Loading;
using TSD.API.Remoting.Solver;

namespace TSD_API_ver101_ILoad_Corresponding_Explode

{
    public class Get_Instance : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MyComponent1 class.
        /// </summary>
        public Get_Instance()
          : base("Explode_IMemberLoad_1", "E_IMemberLoad_1",
            "Explodeing the ILoad whose Load Type is Member ver1.",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("ILoad", "ILoad", "Input ILoad whose LoadType is Member", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Direction", "Direction", "this is Direction", GH_ParamAccess.item);
            pManager.AddGenericParameter("ID", "ID", "this is ID", GH_ParamAccess.item);
            pManager.AddGenericParameter("Index", "Index", "this is Index", GH_ParamAccess.item);
            pManager.AddGenericParameter("Mesuring", "Mesuring", "this is Mesuring system", GH_ParamAccess.item);
            pManager.AddGenericParameter("MemberID", "MemberID", "this is MemberID of the member which has the load", GH_ParamAccess.item);
            pManager.AddGenericParameter("MemberLoadType", "MemberLoadType", "this is MemberLoadType", GH_ParamAccess.item);
            pManager.AddGenericParameter("Projection", "Projection", "this is Projecton system", GH_ParamAccess.item);
            pManager.AddGenericParameter("Source", "Source", "this is Source", GH_ParamAccess.item);
            pManager.AddGenericParameter("SpanID", "SpanID", "this is SpanID", GH_ParamAccess.item);
            pManager.AddGenericParameter("Distance", "Distance", "this is Distance from the start point of the member", GH_ParamAccess.item);
            pManager.AddGenericParameter("Length", "Length", "this is Length of the Load", GH_ParamAccess.item);
            pManager.AddGenericParameter("Start Load or Load [N, N/mm or Nmm/mm]", "StartLoad/Load[N,N/mm,Nmm/mm]", "this is the Load value [N], [N/mm], [Nmm/mm] of the load instance or start load value", GH_ParamAccess.item);
            pManager.AddGenericParameter("End Load[N, N/mm or Nmm/mm]", "EndLoad[N,N/mm,Nmm/mm]", "this is the Load value [N], [N/mm], [Nmm/mm] of the load instance of the End point of the load", GH_ParamAccess.item);











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



            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref input_1)) return;
            LoadType input_2 = input_1.Type;


            // We should now validate the data and warn the user if invalid data is supplied.

            if (input_1 != null && input_2 ==LoadType.Member)
            {
                IMemberLoad input_1_mod = input_1 as IMemberLoad;
                DA.SetData(0, input_1_mod.Direction);
                DA.SetData(1, input_1_mod.Id);
                DA.SetData(2, input_1_mod.Index);
                DA.SetData(3, input_1_mod.Measuring);
                DA.SetData(4, input_1_mod.MemberId);
                DA.SetData(5, input_1_mod.MemberLoadType);
                DA.SetData(6, input_1_mod.Projection);
                DA.SetData(7, input_1_mod.Source);
                DA.SetData(8, input_1_mod.SpanId);


                switch (input_1_mod.MemberLoadType)
                {
                    case MemberLoadType.EccMoment:
                        var output_Ecc = input_1_mod as IMemberEccentricityMomentLoad;
                        DA.SetData(9, output_Ecc.Distance);
                        DA.SetData(10, null);
                        DA.SetData(11, output_Ecc.Load);
                        DA.SetData(12, null);

                        break;
                    case MemberLoadType.Force:
                        var output_Force = input_1 as IMemberForceLoad;
                        DA.SetData(9, output_Force.Distance);
                        DA.SetData(10, null);
                        DA.SetData(11, output_Force.Load);
                        DA.SetData(12, null);
                        break;
                    case MemberLoadType.FullUdl:
                        var output_fulludl = input_1 as IMemberFullUniformlyDistributedLoad;
                        DA.SetData(9, null);
                        DA.SetData(10, null);
                        DA.SetData(11, output_fulludl.Load);
                        DA.SetData(12, null);
                        break;
                    case MemberLoadType.Moment:
                        var output_moment = input_1 as IMemberMomentLoad;
                        DA.SetData(9, output_moment.Distance);
                        DA.SetData(10, null);
                        DA.SetData(11, output_moment.Load);
                        DA.SetData(12, null);
                        break;
                    case MemberLoadType.Trapezoidal:
                        var output_trape = input_1 as IMemberTrapezoidalLoad;
                        DA.SetData(9, output_trape.Distance);
                        DA.SetData(10, null);
                        DA.SetData(11, output_trape.Load);
                        DA.SetData(12, null);
                        break;
                    case MemberLoadType.Udl:
                        var output_udl = input_1 as IMemberUniformlyDistributedLoad;
                        DA.SetData(9, output_udl.Distance);
                        DA.SetData(10, output_udl.Length);
                        DA.SetData(11, output_udl.Load);
                        DA.SetData(12, null);
                        break;
                    case MemberLoadType.UdTorsionMoment:
                        var output_udt = input_1 as IMemberUniformlyDistributedTorsionMomentLoad;
                        DA.SetData(9, output_udt.Distance);
                        DA.SetData(10, output_udt.Length);
                        DA.SetData(11, output_udt.Load);
                        DA.SetData(12, null);

                        break;
                    case MemberLoadType.Vdl:
                        var output_vdl = input_1 as IMemberVariablyDistributedLoad;
                        DA.SetData(9, output_vdl.Distance);
                        DA.SetData(10, output_vdl.Length);
                        DA.SetData(11, output_vdl.StartLoad);
                        DA.SetData(12, output_vdl.EndLoad);
                        break;
                    case MemberLoadType.VdTorsionMoment:
                        var output_vdt = input_1 as IMemberVariablyDistributedTorsionMomentLoad;
                        DA.SetData(9, output_vdt.Distance);
                        DA.SetData(10, output_vdt.Length);
                        DA.SetData(11, output_vdt.StartLoad);
                        DA.SetData(12, output_vdt.EndLoad);
                        break;
                   
                    default:
                        throw new ArgumentException("Invalid load type");
                }
            }
            else
            {
                DA.SetData(0,null);
                DA.SetData(1, null);
                DA.SetData(2, null);
                DA.SetData(3, null);
                DA.SetData(4, null);
                DA.SetData(5, null);
                DA.SetData(6, null);
                DA.SetData(7, null);
                DA.SetData(8, null);
                DA.SetData(9, null);
                DA.SetData(10, null);
                DA.SetData(11, null);
                DA.SetData(12, null);


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
            get { return new Guid("B343BA47-41EE-40AC-9734-3BEE7BBEB6F4"); }
        }
    }
}