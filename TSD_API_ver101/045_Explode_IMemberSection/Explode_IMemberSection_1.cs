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
using TSD.API.Remoting.Materials;
using TSD.API.Remoting.Sections;
using TSD.API.Remoting.Solver;
using TSD.API.Remoting.Structure;
using TSD.API.Remoting.Sections;

namespace TSD_API_ver101_IMemberSection
{
    public class Get_MemberSectionProperties : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the Get_MemberSectionProperties class.
        /// </summary>
        public Get_MemberSectionProperties()
          : base("Explode_IMemberSection_1", "E_IMemberSection_1",
            "Exploding the IMemberSection ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IMemberSection", "IMemSec", "Input IMemberSection object", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("CrossSectionalArea", "A", "Cross sectional area [mm²]", GH_ParamAccess.item);
            pManager.AddNumberParameter("MajorAxisSecondMomentOfArea", "Ixx", "Major axis second moment of area [mm⁴]", GH_ParamAccess.item);
            pManager.AddNumberParameter("MinorAxisSecondMomentOfArea", "Iyy", "Minor axis second moment of area [mm⁴]", GH_ParamAccess.item);
            pManager.AddGenericParameter("ISection", "ISec", "Physical section", GH_ParamAccess.item);
            pManager.AddNumberParameter("ShearAreaParallelToMajorAxis", "Axy", "Shear area parallel to major axis [mm²]", GH_ParamAccess.item);
            pManager.AddNumberParameter("ShearAreaParallelToMinorAxis", "Ayx", "Shear area parallel to minor axis [mm²]", GH_ParamAccess.item);
            pManager.AddNumberParameter("TorsionConstant", "J", "Torsion constant [mm⁴]", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            IMemberSection memberSection = null;

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref memberSection)) return;

            // We should now validate the data and warn the user if invalid data is supplied.

            double crossSectionalArea = 0.0;
            double majorAxisSecondMomentOfArea = 0.0;
            double minorAxisSecondMomentOfArea = 0.0;
            TSD.API.Remoting.Sections.ISection physicalSection = null;
            double shearAreaParallelToMajorAxis = 0.0;
            double shearAreaParallelToMinorAxis = 0.0;
            double torsionConstant = 0.0;

            if (memberSection != null)
            {
                // Assuming 'memberSection' is your input object which contains the required properties.
                crossSectionalArea = memberSection.CrossSectionalArea.Value;
                majorAxisSecondMomentOfArea = memberSection.MajorAxisSecondMomentOfArea.Value;
                minorAxisSecondMomentOfArea = memberSection.MinorAxisSecondMomentOfArea.Value;
                physicalSection = memberSection.PhysicalSection.Value;
                shearAreaParallelToMajorAxis = memberSection.ShearAreaLoadedParallelToMajorAxis.Value;
                shearAreaParallelToMinorAxis = memberSection.ShearAreaLoadedParallelToMinorAxis.Value;
                torsionConstant = memberSection.TorsionConstant.Value;
            }
            else
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "IMemberSection is null or invalid");
            }

            // Setting the output parameters
            DA.SetData(0, crossSectionalArea);
            DA.SetData(1, majorAxisSecondMomentOfArea);
            DA.SetData(2, minorAxisSecondMomentOfArea);
            DA.SetData(3, physicalSection);
            DA.SetData(4, shearAreaParallelToMajorAxis);
            DA.SetData(5, shearAreaParallelToMinorAxis);
            DA.SetData(6, torsionConstant);
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
            get { return new Guid("F6F89666-24BD-4733-8E07-F56D24A39A3B"); }
        }
    }
}
