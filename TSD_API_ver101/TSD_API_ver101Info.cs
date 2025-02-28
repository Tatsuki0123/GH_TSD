using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace TSD_API_ver101
{
    public class TSD_API_ver101Info : GH_AssemblyInfo
    {
        public override string Name => "TSD_API_ver101";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("b00c2e36-6382-4749-b8db-ad1b2ff0485d");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}