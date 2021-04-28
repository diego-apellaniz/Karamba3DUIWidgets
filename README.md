# KarambaUIWidgets
A breakdown example of different UI Widgets from the Grasshopper Plugin Karamba3d, displaying some structural functionalities through code.

![test2](https://user-images.githubusercontent.com/73039064/116399320-18e94b80-a829-11eb-82d7-d78b94852a6e.png)

## Extendable Component
DummyExtendableSwitcher:
An example of an extendable component, built using a GH_SwitcherComponent class from the base Karamba components. The component provides a primary usage of scaling a given geometry and and multiple different extendable menus displaying a variety of menu concepts:

#### Extendable Menu
An extendable menu of inputs and outputs. This section hosts most of the outputs for the extendable component. The parameters for this section are used for a multiplication or additon output.

#### Drop Down Menu
A drop down menu example of values, the output for this section primarily identifies which drop down option was chosen.

#### CheckBoxes
A checkbox example, the output for this checkbox is a boolen determining if the given checkbox has been ticked.

#### RadioButton
Similar to a checkbox, a radiobutton acts as an individual check, meaning other tick boxes cannot be simultaneously ticked. The output for the radiobutton is an identifier for which radiobutton is currently ticked.

#### Slider
A value slider of two decimal places, the output reflects the slider value.

![3](https://user-images.githubusercontent.com/73039064/116399800-9ad97480-a829-11eb-82ab-f260a5712303.png)

## Switcher Component
A switcher component is a menu that adapts inputs and outputs depending on the dropdown list option select. In this case, the list contains an options to create a scalable circle or a scalable square from varying parameters. The two options are defined in code as subcomponent classes and called by a primary class, allowing for individual definition of purposes.

![12](https://user-images.githubusercontent.com/73039064/116400077-e68c1e00-a829-11eb-8071-fddf44f2a6c2.png)


## Extendable Component 2
DummyExtendableComponent:
A proof of concept extendable built with the GH_ExtendableCOmponent class. The method of defining input and output parameters differs to using a GH_SwitcherComponent. The inputs and outputs reflect the same covered in the previous extendable component.
