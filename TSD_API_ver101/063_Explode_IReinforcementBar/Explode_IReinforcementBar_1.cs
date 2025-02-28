using System;
using GH_IO.Types;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;
using TSD.API.Remoting.Reinforcement;

namespace TSD_API_ver101_IReinforcementBar_Explode
{
    public class Explode_IReinforcementBar : GH_Component
    {
        public Explode_IReinforcementBar()
          : base("Explode_IReinforcementBar_1", "ExplodeReinBar_1",
            "Explodes an IReinforcementBar into its various properties ver1",
            "TSD_API", "Exploding_functions")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("IReinforcementBar", "IRB", "Input IReinforcementBar", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("A", "A", "Gets the value of the A parameter (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("B", "B", "Gets the value of the B parameter (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("BarGeometry(IReinforcementBarGeometry)", "BG(IReinforcementBarGeometry)", "Gets the bar geometry", GH_ParamAccess.item);
            pManager.AddGenericParameter("BobPosition", "BP", "Gets the position of bobs on this bar", GH_ParamAccess.item);
            pManager.AddGenericParameter("C", "C", "Gets the value of the C parameter (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("ContributesToArea", "CTA", "Gets a value indicating whether the bar contributes to the provided area", GH_ParamAccess.item);
            pManager.AddGenericParameter("Curve(ICompositeCurve2D)", "Curve(ICompositeCurve2D)", "Gets the composite curve of the bar", GH_ParamAccess.item);
            pManager.AddGenericParameter("D", "D", "Gets the value of the D parameter (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Depth", "Depth", "Gets the bar 'depth' (distance of opposite ends; only valid for U-bars) (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Direction(Vector)", "Direction(Vector)", "Gets the direction of the bar relative to the direction of the element it belongs to", GH_ParamAccess.item);
            pManager.AddGenericParameter("E", "E", "Gets the value of the E parameter (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("F", "F", "Gets the value of the F parameter (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("G", "G", "Gets the value of the G parameter (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Geometry", "Geometry", "Gets the geometry of the reinforcement object", GH_ParamAccess.item);
            pManager.AddGenericParameter("H", "H", "Gets the value of the H parameter (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("HasAnchorage", "HA", "Gets a value indicating whether any anchorage lengths are defined for this bar", GH_ParamAccess.item);
            pManager.AddGenericParameter("HasLaps", "HL", "Gets a value indicating whether any lap lengths are defined for this bar", GH_ParamAccess.item);
            pManager.AddGenericParameter("Id", "ID", "Gets the unique ID of the bar", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsMirroredHorizontally", "IMH", "Gets a value indicating whether the bar shape is mirrored horizontally relative to its base position", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsMirroredVertically", "IMV", "Gets a value indicating whether the bar shape is mirrored vertically relative to its base position", GH_ParamAccess.item);
            pManager.AddGenericParameter("IsTrueUBar", "ITUB", "Gets a value indicating whether this bar is a true U-bar defined in both zones", GH_ParamAccess.item);
            pManager.AddGenericParameter("J", "J", "Gets the value of the J parameter (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("K", "K", "Gets the value of the K parameter (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("L", "L", "Gets the value of the L parameter (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("LayerIndex", "LI", "Gets the index of the layer the bar is placed in", GH_ParamAccess.item);
            pManager.AddGenericParameter("Length", "Length", "Gets the total length of the bar (along its centre line) (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("LinearLength", "LL", "Gets the linear length of the bar (ie. the maximum extent along its direction) (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("LinearLengthWithoutCranks", "LLWC", "Gets the linear length of the bar without cranks (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("LinkTipLength", "LTL", "Gets the length of the tips (hooks/extensions) of a link bar (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Location", "Location", "Gets the bar location in the section", GH_ParamAccess.item);
            pManager.AddGenericParameter("M", "M", "Gets the value of the M parameter (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("Mark", "Mark", "Gets the object mark (an arbitrary number used in drawings)", GH_ParamAccess.item);
            pManager.AddGenericParameter("OppositeLayerIndex", "OLI", "Gets the index of the layer the bar is placed in the opposite zone", GH_ParamAccess.item);
            pManager.AddGenericParameter("P", "P", "Gets the value of the P parameter (depends on the bar diameter) (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("P90Degrees", "P90", "Gets the value of the P parameter for bends with 90 degree angle (depends on the bar diameter) (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("PShallowBend", "PSB", "Gets the value of the P parameter for shallow bends (less than 150 degrees; depends on the bar diameter) (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("R", "R", "Gets the value of the R parameter (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("RCalculated", "RC", "Gets the value of the R parameter (the bend radius; depends on the bar diameter) (in [mm])", GH_ParamAccess.item);
            pManager.AddGenericParameter("RotationAngle", "RA", "Gets the angle of the bar rotation (in [rad], measured counterclockwise)", GH_ParamAccess.item);
            pManager.AddGenericParameter("Shape(IReinforcementShape)", "Shape(IReinforcementShape)", "Gets the shape of the reinforcement bar", GH_ParamAccess.item);
            pManager.AddGenericParameter("Size(IReinforcementVBarSize)", "Size(IReinforcementVBarSize)", "Gets the size of the reinforcement bar", GH_ParamAccess.item);
            pManager.AddGenericParameter("StartPosition", "SP", "Gets the start position of the bar relative to the bottom-left point of the start face of the start span", GH_ParamAccess.item);
            pManager.AddGenericParameter("StartSpanIndex", "SSI", "Gets the index of the span in the parent object the reinforcement starts in", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            IReinforcementBar inputReinforcementBar = null;

            if (!DA.GetData(0, ref inputReinforcementBar)) return;

            var A = inputReinforcementBar.A.Value;
            var B = inputReinforcementBar.B.Value;
            var barGeometry = inputReinforcementBar.BarGeometry.Value;
            var bobPosition = inputReinforcementBar.BobPosition.Value;
            var C = inputReinforcementBar.C.Value;
            var contributesToArea = inputReinforcementBar.ContributesToArea.Value;
            var curve = inputReinforcementBar.Curve.Value;
            var D = inputReinforcementBar.D.Value;
            var depth = inputReinforcementBar.Depth.Value;
            var direction = new Vector3d(inputReinforcementBar.Direction.Value.X, inputReinforcementBar.Direction.Value.Y, inputReinforcementBar.Direction.Value.Z);
            var E = inputReinforcementBar.E.Value;
            var F = inputReinforcementBar.F.Value;
            var G = inputReinforcementBar.G.Value;
            var geometry = inputReinforcementBar.Geometry.Value;
            var H = inputReinforcementBar.H.Value;
            var hasAnchorage = inputReinforcementBar.HasAnchorage.Value;
            var hasLaps = inputReinforcementBar.HasLaps.Value;
            var id = inputReinforcementBar.Id.Value;
            var isMirroredHorizontally = inputReinforcementBar.IsMirroredHorizontally.Value;
            var isMirroredVertically = inputReinforcementBar.IsMirroredVertically.Value;
            var isTrueUBar = inputReinforcementBar.IsTrueUBar.Value;
            var J = inputReinforcementBar.J.Value;
            var K = inputReinforcementBar.K.Value;
            var L = inputReinforcementBar.L.Value;
            var layerIndex = inputReinforcementBar.LayerIndex.Value;
            var length = inputReinforcementBar.Length.Value;
            var linearLength = inputReinforcementBar.LinearLength.Value;
            var linearLengthWithoutCranks = inputReinforcementBar.LinearLengthWithoutCranks.Value;
            var linkTipLength = inputReinforcementBar.LinkTipLength.Value;
            var location = inputReinforcementBar.Location.Value;
            var M = inputReinforcementBar.M.Value;
            var mark = inputReinforcementBar.Mark.Value;
            var oppositeLayerIndex = inputReinforcementBar.OppositeLayerIndex.Value;
            var P = inputReinforcementBar.P.Value;
            var P90Degrees = inputReinforcementBar.P90Degrees.Value;
            var PShallowBend = inputReinforcementBar.PShallowBend.Value;
            var R = inputReinforcementBar.R.Value;
            var RCalculated = inputReinforcementBar.RCalculated.Value;
            var rotationAngle = inputReinforcementBar.RotationAngle.Value;
            var shape = inputReinforcementBar.Shape.Value;
            var size = inputReinforcementBar.Size.Value;
            var startPosition = new Point3d(inputReinforcementBar.StartPosition.Value.X, inputReinforcementBar.StartPosition.Value.Y, inputReinforcementBar.StartPosition.Value.Z);
            var startSpanIndex = inputReinforcementBar.StartSpanIndex.Value;

            DA.SetData(0, A);
            DA.SetData(1, B);
            DA.SetData(2, barGeometry);
            DA.SetData(3, bobPosition);
            DA.SetData(4, C);
            DA.SetData(5, contributesToArea);
            DA.SetData(6, curve);
            DA.SetData(7, D);
            DA.SetData(8, depth);
            DA.SetData(9, direction);
            DA.SetData(10, E);
            DA.SetData(11, F);
            DA.SetData(12, G);
            DA.SetData(13, geometry);
            DA.SetData(14, H);
            DA.SetData(15, hasAnchorage);
            DA.SetData(16, hasLaps);
            DA.SetData(17, id);
            DA.SetData(18, isMirroredHorizontally);
            DA.SetData(19, isMirroredVertically);
            DA.SetData(20, isTrueUBar);
            DA.SetData(21, J);
            DA.SetData(22, K);
            DA.SetData(23, L);
            DA.SetData(24, layerIndex);
            DA.SetData(25, length);
            DA.SetData(26, linearLength);
            DA.SetData(27, linearLengthWithoutCranks);
            DA.SetData(28, linkTipLength);
            DA.SetData(29, location);
            DA.SetData(30, M);
            DA.SetData(31, mark);
            DA.SetData(32, oppositeLayerIndex);
            DA.SetData(33, P);
            DA.SetData(34, P90Degrees);
            DA.SetData(35, PShallowBend);
            DA.SetData(36, R);
            DA.SetData(37, RCalculated);
            DA.SetData(38, rotationAngle);
            DA.SetData(39, shape);
            DA.SetData(40, size);
            DA.SetData(41, startPosition);
            DA.SetData(42, startSpanIndex);
        }

        protected override System.Drawing.Bitmap Icon => TSD_API_ver101.Properties.Resources.API_icon;

        public override Guid ComponentGuid => new Guid("1579836B-523D-4FA4-8F81-BD2E280EDC96");
    }
}
