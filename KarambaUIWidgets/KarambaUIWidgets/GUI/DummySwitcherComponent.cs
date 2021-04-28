using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Types;
using KarambaUIWidgets.Properties;
using KarambaUIWidgets.UIWidgets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace KarambaUIWidgets.GUI
{
    public class DummySwitcherComponent : GH_SwitcherComponent
    {
        private List<SubComponent> subcomponents_ = new List<SubComponent>();

        public override string UnitMenuName => "Geometry Option:";

        protected override string DefaultEvaluationUnit => subcomponents_[0].name();

        public override Guid ComponentGuid => new Guid("85c4795c-910b-40d7-8e7f-a202fa0ab797");

        public override GH_Exposure Exposure => (GH_Exposure)2;

        protected override Bitmap Icon => Resources.Minion_reading;
        //protected override Bitmap Icon => Resources.Minion_Lautsprecher;

        public DummySwitcherComponent()
            : base("SwitcherComponent", "SwitchComp",
              "A Test Component",
              "B+G Toolbox", "UIWidgets")
        {
            ((GH_Component)this).Hidden = true;
        }

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Centre Point", "Centre", "A given centre point for experimentation", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.RegisterParam(new Param_Curve(), "Output Geometry", "Geometry", "Geometry Output");
        }

        protected override void RegisterEvaluationUnits(EvaluationUnitManager mngr)
        {
            subcomponents_.Add(new SubComponent_Circle());
            subcomponents_.Add(new SubComponent_Square());

            //subcomponents_.Add(new SubComponent_Gravity());
            //subcomponents_.Add(new SubComponent_PointLoad());
            //subcomponents_.Add(new SubComponent_Imperfection());
            //subcomponents_.Add(new SubComponent_Strain());
            //subcomponents_.Add(new SubComponent_Temperature());
            //subcomponents_.Add(new SubComponent_UniformLineLoad(this));
            //subcomponents_.Add(new SubComponent_MeshLoad(this, is_constant: true));
            //subcomponents_.Add(new SubComponent_MeshLoad(this, is_constant: false));
            foreach (SubComponent item in subcomponents_)
            {
                item.registerEvaluationUnits(mngr);
            }
        }

        protected override void OnComponentLoaded()
        {
            base.OnComponentLoaded();
            foreach (SubComponent item in subcomponents_)
            {
                item.OnComponentLoaded();
            }
        }

        protected override void SolveInstance(IGH_DataAccess DA, EvaluationUnit unit)
        {
            //IL_0046: Unknown result type (might be due to invalid IL or missing references)
            if (unit == null)
            {
                return;
            }
            foreach (SubComponent item in subcomponents_)
            {
                if (unit.Name.Equals(item.name()))
                {
                    item.SolveInstance(DA, out var msg, out var level);
                    if (msg != "")
                    {
                        ((GH_ActiveObject)this).AddRuntimeMessage(level, msg + " May cause errors in exported models.");
                    }
                    return;
                }
            }
            throw new Exception("Invalid sub-component");
        }
    }

}
