using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Types;
using KarambaUIWidgets.Properties;
using KarambaUIWidgets.UIWidgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace KarambaUIWidgets.GUI
{
    public class SubComponent_Circle : SubComponent
    {
        //private static int default_loadcase = 0;
        //private static Vector3d default_gravity = new Vector3d(0.0, 0.0, -1.0);


        public override string name()
        {
            return "Circle";
        }

        public override string display_name()
        {
            return "Circle";
        }

        public override void registerEvaluationUnits(EvaluationUnitManager mngr)
        {
            //IL_002b: Unknown result type (might be due to invalid IL or missing references)
            //IL_0040: Unknown result type (might be due to invalid IL or missing references)
            //IL_0045: Unknown result type (might be due to invalid IL or missing references)
            //IL_004f: Expected O, but got Unknown
            //IL_004f: Expected O, but got Unknown
            //IL_0067: Unknown result type (might be due to invalid IL or missing references)
            //IL_0081: Unknown result type (might be due to invalid IL or missing references)
            //IL_008b: Expected O, but got Unknown
            //IL_008b: Expected O, but got Unknown
            EvaluationUnit evaluationUnit = new EvaluationUnit(name(), display_name(), "Creates a square from the input variables");
            evaluationUnit.Icon = Resources.Minion_reading;
            mngr.RegisterUnit(evaluationUnit);
            evaluationUnit.RegisterInputParam(new Param_Number(), "Radius", "R", "Radius in meters", GH_ParamAccess.item);
            evaluationUnit.Inputs[0].Parameter.Optional = false;
        }

        public override void SolveInstance(IGH_DataAccess DA, out string msg, out GH_RuntimeMessageLevel level)
        {
            //IL_000b: Unknown result type (might be due to invalid IL or missing references)
            //IL_0010: Unknown result type (might be due to invalid IL or missing references)
            //IL_0016: Expected O, but got Unknown
            //IL_0025: Unknown result type (might be due to invalid IL or missing references)
            //IL_002b: Expected O, but got Unknown
            //IL_0036: Unknown result type (might be due to invalid IL or missing references)

            msg = "";
            level = (GH_RuntimeMessageLevel)10;

            //GH_Vector val = new GH_Vector(default_gravity);
            //DA.GetData<GH_Vector>(0, ref val);
            //GH_Integer val2 = new GH_Integer(default_loadcase);
            //DA.GetData<GH_Integer>(1, ref val2);
            //GravityLoad gr = new GravityLoad(((GH_Goo<Vector3d>)(object)val).get_Value().Convert(), ((GH_Goo<int>)(object)val2).get_Value());
            //DA.SetData(0, (object)new GH_Load(gr));

            Point3d centre = new Point3d(0, 0, 0);
            double radius = 1.0;

            DA.GetData(0, ref centre);
            DA.GetData(1, ref radius);

            Circle circle = new Circle(centre, radius);

            DA.SetData(0, circle);
        }
    }

}

