using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using KarambaUIWidgets.UIWidgets;
using Grasshopper.Kernel.Parameters;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace GUI
{
    public class KarambaUIWidgetsComponent : GH_SwitcherComponent
    {
        private MenuDropDown _dropdownmenu;
        private MenuCheckBox _checkbox1;
        private MenuCheckBox _checkbox2;
        private string _valuecheckbox1 = "Initial Value";
        private string _valuecheckbox2 = "Initial Value";
        private MenuRadioButtonGroup _colorGrp;
        private string radiovariable = "radiovar";

        //private void _loadDrop__valueChanged(object sender, EventArgs e)
        //{
        //    _ = (MenuDropDown)sender;
        //    setModelProps();
        //}

        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public KarambaUIWidgetsComponent()
          : base("Extendable Component", "ExtComp",
              "A Test Component",
              "B+G Toolbox", "UIWidgets")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Given Number", "Scale", "A given scale number for experimentation", GH_ParamAccess.item, 1.0);
            pManager.AddGeometryParameter("Given Geometry", "Goem", "A given test geometry for experimentation", GH_ParamAccess.item);

            pManager[0].Optional = true;
            pManager[1].Optional = false;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            //pManager.AddTextParameter("Output Text", "Otext", "A given output text formed from input parameters", GH_ParamAccess.item);
            pManager.AddGeometryParameter("Output Geometry", "OGeom", "A given output geometry calculated after scaling", GH_ParamAccess.item);
        }




        protected override void RegisterEvaluationUnits(EvaluationUnitManager mngr)
        {

            EvaluationUnit evaluationUnit = new EvaluationUnit("ExtendableComponent", "ExtComp", "A Test Component");
            mngr.RegisterUnit(evaluationUnit);

            // First Extendable Menu (Multiplication and Summation)

            evaluationUnit.RegisterInputParam(new Param_Number(), "P1", "Parameter1", "A parameter value", GH_ParamAccess.item);
            evaluationUnit.RegisterInputParam(new Param_Number(), "P2", "Parameter2", "A second parameter value", GH_ParamAccess.item);
            evaluationUnit.Inputs[0].Parameter.Optional = true;
            evaluationUnit.Inputs[1].Parameter.Optional = true;


            evaluationUnit.RegisterOutputParam(new Param_Number(), "MultResult", "Multiplication Output", "Output of multiplication");
            evaluationUnit.RegisterOutputParam(new Param_Number(), "SumResult", "Addition Output", "Output of addition");

            evaluationUnit.RegisterOutputParam(new Param_String(), "Checkboxresult", "Checkbox Output", "Output of Boolean");
            evaluationUnit.RegisterOutputParam(new Param_String(), "Checkboxresult2", "Checkbox Output 2", "Output of Boolean");

            evaluationUnit.RegisterOutputParam(new Param_String(), "RadioButtonResult", "RadioButton Output", "Output of RadioButton");


            GH_ExtendableMenu gH_ExtendableMenu0 = new GH_ExtendableMenu(0, "Extendable Menu");
            gH_ExtendableMenu0.Name = "Extendable Menu";
            gH_ExtendableMenu0.Expand();
            evaluationUnit.AddMenu(gH_ExtendableMenu0);
            gH_ExtendableMenu0.RegisterInputPlug(evaluationUnit.Inputs[0]);
            gH_ExtendableMenu0.RegisterInputPlug(evaluationUnit.Inputs[1]);

            gH_ExtendableMenu0.RegisterOutputPlug(evaluationUnit.Outputs[0]);
            gH_ExtendableMenu0.RegisterOutputPlug(evaluationUnit.Outputs[1]);

            //checkbox
            gH_ExtendableMenu0.RegisterOutputPlug(evaluationUnit.Outputs[2]);
            gH_ExtendableMenu0.RegisterOutputPlug(evaluationUnit.Outputs[3]);

            //radiobutton
            gH_ExtendableMenu0.RegisterOutputPlug(evaluationUnit.Outputs[4]);

            // Second Extendable Menu (Drop Down Menu)

            GH_ExtendableMenu gH_ExtendableMenu1 = new GH_ExtendableMenu(1, "Drop Down Menu");
            gH_ExtendableMenu1.Name = "Drop Down Menu";
            gH_ExtendableMenu1.Expand();
            evaluationUnit.AddMenu(gH_ExtendableMenu1);

            MenuPanel dropdownmenupanel = new MenuPanel(1, "dropdowntest");
            dropdownmenupanel.Header = "random words";

            MenuStaticText menuStaticText0 = new MenuStaticText();
            menuStaticText0.Text = "Drop Down";
            menuStaticText0.Header = "Load Case";
            dropdownmenupanel.AddControl(menuStaticText0);

            _dropdownmenu = new MenuDropDown(0, "drop_down_menu", "ddm");
            _dropdownmenu.VisibleItemCount = 5;
            _dropdownmenu.Header = "A random header hehe";

            _dropdownmenu.AddItem("key1", "value1");
            _dropdownmenu.AddItem("key2", "value2");
            _dropdownmenu.AddItem("key3", "value3");

            dropdownmenupanel.AddControl(_dropdownmenu);
            gH_ExtendableMenu1.AddControl(dropdownmenupanel);

            // Third Extendable Menu (Tick Box Menu)

            GH_ExtendableMenu gH_ExtendableMenu2 = new GH_ExtendableMenu(2, "Tick Box Menu");
            gH_ExtendableMenu2.Name = "TickBoxes";
            evaluationUnit.AddMenu(gH_ExtendableMenu2);

            MenuPanel dropdownmenupanel2 = new MenuPanel(2, "dropdownmenupanel");
            dropdownmenupanel2.Header = "A set of pointless ticboxes";

            _checkbox1 = new MenuCheckBox(0, "check the pointless tickbox", "tickbox 1");
            _checkbox1.ValueChanged += _dispCheck__valueChanged;
            _checkbox1.Active = false;
            _checkbox1.Header = "have fun ticking the boxes";

            _checkbox2 = new MenuCheckBox(1, "check the pointless tickbox", "tickbox 2");
            _checkbox2.ValueChanged += _dispCheck2__valueChanged;
            _checkbox2.Active = false;
            _checkbox2.Header = "have fun ticking more of the boxes";


            dropdownmenupanel2.AddControl(_checkbox1);
            dropdownmenupanel2.AddControl(_checkbox2);

            gH_ExtendableMenu2.AddControl(dropdownmenupanel2);


            // RadioButton

            _colorGrp = new MenuRadioButtonGroup(2, "radiogrp_color");
            _colorGrp.Direction = MenuRadioButtonGroup.LayoutDirection.Vertical;
            _colorGrp.ValueChanged += _colorGrp__valueChanged;
            _colorGrp.MaxActive = 1;
            _colorGrp.MinActive = 0;

            GH_ExtendableMenu gH_ExtendableMenu3 = new GH_ExtendableMenu(3, "RadioButton Menu");
            gH_ExtendableMenu3.Name = "RadioButton Menu";
            gH_ExtendableMenu3.Expand();
            evaluationUnit.AddMenu(gH_ExtendableMenu3);

            MenuPanel radiomenupanel3 = new MenuPanel(3, "radiobuttontest");
            dropdownmenupanel.Header = "random radio words";

            MenuRadioButton menuRadioButton = new MenuRadioButton(0, "Button1", "Button1 Description", MenuRadioButton.Alignment.Horizontal);
            menuRadioButton.Name = "Button1";
            MenuRadioButton menuRadioButton2 = new MenuRadioButton(1, "Button2", "Button2 Description", MenuRadioButton.Alignment.Horizontal);
            menuRadioButton2.Name = "Button2";
            MenuRadioButton menuRadioButton3 = new MenuRadioButton(2, "Button3", "Button3 Description", MenuRadioButton.Alignment.Horizontal);
            menuRadioButton3.Name = "Button3";

            _colorGrp.AddButton(menuRadioButton);
            _colorGrp.AddButton(menuRadioButton2);
            _colorGrp.AddButton(menuRadioButton3);
            radiomenupanel3.AddControl(_colorGrp);

            gH_ExtendableMenu3.AddControl(radiomenupanel3);


            //_colorGrp = new MenuRadioButtonGroup(2, "radiogrp_color");
            //_colorGrp.Direction = MenuRadioButtonGroup.LayoutDirection.Vertical;
            //_colorGrp.ValueChanged += _colorGrp__valueChanged;
            //_colorGrp.MaxActive = 1;
            //_colorGrp.MaxActive = 0;

            //// Load Cases and Combos
            //GH_ExtendableMenu gH_ExtendableMenu1 = new GH_ExtendableMenu(1, "Load Cases and Combos");
            //gH_ExtendableMenu1.Name = "Load Cases and Combos";
            //gH_ExtendableMenu1.Expand();
            //evaluationUnit.AddMenu(gH_ExtendableMenu1);
            //MenuPanel menuPanel = new MenuPanel(1, "panel_load");
            //menuPanel.Header = "Set here the load case for display.\n";
            //MenuStaticText menuStaticText0 = new MenuStaticText();
            //menuStaticText0.Text = "Select Load Case or Combo";
            //menuStaticText0.Header = "Load Case";
            //menuPanel.AddControl(menuStaticText0);
            //_loadDrop = new MenuDropDown(1, "dropdown_loads_1", "loading type");
            //_loadDrop.ValueChanged += _loadDrop__valueChanged;
            //_loadDrop.Header = "Set here the loading type for display.\n";
            //menuPanel.AddControl(_loadDrop);
            //MenuStaticText menuStaticText1 = new MenuStaticText();
            //menuStaticText1.Text = "Select Result Type";
            //menuStaticText1.Header = "Result Type";
            //menuPanel.AddControl(menuStaticText1);
            //_resulttypeDrop = new MenuDropDown(2, "dropdown_result_1", "result type");
            //_resulttypeDrop.ValueChanged += _loadDrop__valueChanged2;
            //_resulttypeDrop.Header = "Set here the loading type for display.\n";
            //menuPanel.AddControl(_resulttypeDrop);
            //gH_ExtendableMenu1.AddControl(menuPanel);



            //// Overwrite
            //GH_ExtendableMenu gH_ExtendableMenu2 = new GH_ExtendableMenu(2, "Overwrite");
            //gH_ExtendableMenu2.Name = "Overwrite";
            //evaluationUnit.RegisterInputParam(new Param_String(), "Overwrite Load Case or Combo", "Load Case", "Overwrite selected load case or combo from the dropdown menu.", GH_ParamAccess.item);
            //evaluationUnit.Inputs[1].Parameter.Optional = true;
            //gH_ExtendableMenu2.RegisterInputPlug(evaluationUnit.Inputs[1]);
            //evaluationUnit.RegisterInputParam(new Param_Integer(), "Overwrite Result type", "Result Type", UtilLibrary.DescriptionRFTypes(typeof(ResultsValueType)), GH_ParamAccess.item);
            //evaluationUnit.Inputs[2].Parameter.Optional = true;
            //evaluationUnit.Inputs[2].EnumInput = UtilLibrary.ListRFTypes(typeof(ResultsValueType));
            //gH_ExtendableMenu2.RegisterInputPlug(evaluationUnit.Inputs[2]);
            //evaluationUnit.AddMenu(gH_ExtendableMenu2);



            //// Select results
            //GH_ExtendableMenu gH_ExtendableMenu3 = new GH_ExtendableMenu(3, "Select Results");
            //gH_ExtendableMenu3.Name = "Select Results";
            //evaluationUnit.AddMenu(gH_ExtendableMenu3);
            //MenuPanel menuPanel2 = new MenuPanel(2, "panel_results");
            //menuPanel2.Header = "Select output results.\n";
            //_memberForcesCheck = new MenuCheckBox(0, "check member forces", "Member Forces");
            //_memberForcesCheck.ValueChanged += _memberForcesCheck__valueChanged;
            //_memberForcesCheck.Active = true;
            //_memberForcesCheck.Header = "Add member forces to output results.";
            //_surfaceForcesCheck = new MenuCheckBox(1, "check surface forces", "Surface Forces");
            //_surfaceForcesCheck.ValueChanged += _surfaceForcesCheck__valueChanged;
            //_surfaceForcesCheck.Active = true;
            //_surfaceForcesCheck.Header = "Add surface forces to output results.";
            //_nodalReactionsCheck = new MenuCheckBox(2, "check nodal reactions", "Nodal Reactions");
            //_nodalReactionsCheck.ValueChanged += _nodalReactionsCheck__valueChanged;
            //_nodalReactionsCheck.Active = true;
            //_nodalReactionsCheck.Header = "Add nodal reactions to output results.";
            //menuPanel2.AddControl(_memberForcesCheck);
            //menuPanel2.AddControl(_surfaceForcesCheck);
            //menuPanel2.AddControl(_nodalReactionsCheck);
            //gH_ExtendableMenu3.AddControl(menuPanel2);



            //// Advanced
            //evaluationUnit.RegisterInputParam(new Param_RFEM(), "Trigger", "Trigger", "Input to trigger the optimization", GH_ParamAccess.tree);
            //evaluationUnit.Inputs[3].Parameter.Optional = true;
            //evaluationUnit.RegisterInputParam(new Param_String(), "Model Name", "Model Name", "Segment of the name of the RFEM Model to get information from", GH_ParamAccess.item);
            //evaluationUnit.Inputs[4].Parameter.Optional = true;
            //GH_ExtendableMenu gH_ExtendableMenu4 = new GH_ExtendableMenu(4, "Advanced");
            //gH_ExtendableMenu4.Name = "Advanced";
            //gH_ExtendableMenu4.Collapse();
            //evaluationUnit.AddMenu(gH_ExtendableMenu4);
            //for (int i = 3; i < 3 + 2; i++)
            //{
            //    gH_ExtendableMenu4.RegisterInputPlug(evaluationUnit.Inputs[i]);
            //}
        }


        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA, EvaluationUnit unit)
        {

            // Declare a variable for the input String
            double scale = 1.0;
            GeometryBase geom = null;

            double pam1 = 0.0;
            double pam2 = 0.0;
            double mult = 0.0;
            double sum = 0.0;

            // Use the DA object to retrieve the data inside the first input parameter.
            // If the retieval fails (for example if there is no data) we need to abort.
            DA.GetData(0, ref scale);
            DA.GetData(1, ref geom);
            DA.GetData(2, ref pam1);
            DA.GetData(3, ref pam2);

            //scaling geometry
            geom.Scale(scale);
            DA.SetData(0, geom);

            //multiplication and addition
            mult = pam1 * pam2;
            sum = pam1 + pam2;

            DA.SetData(1, mult);
            DA.SetData(2, sum);

            //checkbox boolean

            DA.SetData(3, _valuecheckbox1);
            DA.SetData(4, _valuecheckbox2);

            //radiobutton
            DA.SetData(5, radiovariable);

            //            public bool Scale(
            //    double scaleFactor
            //)

        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        //list functionality


        //tickbox functionality
        private void _dispCheck__valueChanged(object sender, EventArgs e)
        {
            if (((MenuCheckBox)sender).Active)
            {
                _valuecheckbox1 = "Value has been changed to true";
            }
            else
            {
                _valuecheckbox1 = "Value has been changed to false";
            }
            setModelProps();
        }

        private void _dispCheck2__valueChanged(object sender, EventArgs e)
        {
            if (((MenuCheckBox)sender).Active)
            {
                _valuecheckbox2 = "Value of checkbox 2 is true";
            }
            else
            {
                _valuecheckbox2 = "Value of checkbox 2 is false";
            }
            setModelProps();
        }

        //radiobutton functionality



        private void _colorGrp__valueChanged(object sender, EventArgs e)
        {
           int radioindex = _colorGrp.GetActiveInt()[0];
            radiovariable = radioindex.ToString() + ". Radiobutton Active";
            setModelProps();
        }

        //To recompute component/solve instance method.
        protected void setModelProps()
        {
            ((GH_DocumentObject)this).ExpireSolution(true);
        }


        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("ea2617ce-3983-49ed-8b58-607c772c899c"); }
        }
    }
}
