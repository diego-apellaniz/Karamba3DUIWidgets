using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace KarambaUIWidgets
{
    public class KarambaUIWidgetsInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "KarambaUIWidgets";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("61cfb31f-3bef-4a98-a643-c29e4a175fb4");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
