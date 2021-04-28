# KarambaUIWidgets
A breakdown example of different UI Widgets from the Grasshopper Plugin Karamba3d, displaying some structural functionalities through code.

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

## Switcher Component
A switcher component is a menu that adapts inputs and outputs depending on the dropdown list option select. In this case, the list contains an options to create a scalable circle or a scalable square from varying parameters. The two options are defined in code as subcomponent classes and called by a primary class, allowing for individual definition of purposes.

## Extendable Component 2
DummyExtendableComponent:
A proof of concept extendable built with the GH_ExtendableCOmponent class. The method of defining input and output parameters differs to using a GH_SwitcherComponent. The inputs and outputs reflect the same covered in the previous extendable component.
