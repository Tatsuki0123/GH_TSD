using System;
using System.Collections.Generic;
using System.Linq;
using GH_IO.Types;
using Grasshopper.Kernel;
using Rhino.Geometry;
using TSD.API.Remoting.Geometry;

namespace TSD_API_ver101_IPlane_Explode
{
    public class Explode_IPlane : GH_Component
    {
        public Explode_IPlane()
          : base("Explode_IPlane_1", "E_IPlane_1",
            "Explodes an IPlane into its properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IPlane", "IPlane", "Input IPlane", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("LocalCoordSystem X", "LCS_X", "Gets the local coordinate system X", GH_ParamAccess.item);
            pManager.AddGenericParameter("LocalCoordSystem Y", "LCS_Y", "Gets the local coordinate system Y", GH_ParamAccess.item);
            pManager.AddGenericParameter("LocalCoordSystem Z", "LCS_Z", "Gets the local coordinate system Z", GH_ParamAccess.item);
            pManager.AddGenericParameter("Normal", "Normal", "Gets the normal", GH_ParamAccess.item);
            pManager.AddGenericParameter("Origin", "Origin", "Gets the origin", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IPlane inputPlane = null;

            if (!DA.GetData(0, ref inputPlane)) return;

            Vector3d outputLCS_x = new Vector3d();
            Vector3d outputLCS_y = new Vector3d();
            Vector3d outputLCS_z = new Vector3d();
            Vector3d outputNormal = new Vector3d();
            Point3d outputOrigin = new Point3d();

            if (inputPlane != null)
            {
                outputLCS_x = new Vector3d(inputPlane.LCS.Value.Axes.XAxis.X, inputPlane.LCS.Value.Axes.XAxis.Y, inputPlane.LCS.Value.Axes.XAxis.Z);
                outputLCS_y = new Vector3d(inputPlane.LCS.Value.Axes.YAxis.X, inputPlane.LCS.Value.Axes.YAxis.Y, inputPlane.LCS.Value.Axes.YAxis.Z);
                outputLCS_z = new Vector3d(inputPlane.LCS.Value.Axes.ZAxis.X, inputPlane.LCS.Value.Axes.ZAxis.Y, inputPlane.LCS.Value.Axes.ZAxis.Z);

                outputNormal = new Vector3d(inputPlane.Normal.Value.X, inputPlane.Normal.Value.Y, inputPlane.Normal.Value.Z);
                outputOrigin = new Point3d(inputPlane.Origin.Value.X, inputPlane.Origin.Value.Y, inputPlane.Origin.Value.Z);
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "Input plane is not activated");
            }

            DA.SetData(0, outputLCS_x);
            DA.SetData(1, outputLCS_y);
            DA.SetData(2, outputLCS_z);
            DA.SetData(3, outputNormal);
            DA.SetData(4, outputOrigin);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("C443F170-278E-4F1D-8D56-DEDF89DA551D");
    }
}
