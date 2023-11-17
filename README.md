PlateModel.Wpf
==============

17 November 2023

A vehicle license plate -as it's defined in Wikipedia- is a metal or plastic plate attached to a motor vehicle or trailer for official identification purposes.
If you want to build a WPF program that shows license plates, you can use this project to demonstrate high quality license plates which are similar to the real plates.

<h3>Project structure</h3>
There are some main parts in the project:
<ol>
  <li>Flags</li>
  <li>Fonts</li>
  <li>Vectors</li>
  <li>Pic</li>
  <li>Plates</li>
</ol>

<h4>Flags</h4>
The flag of the countries whose plates are contained in the project are in this folder separately. The flags are created by WPF graphics so they are vectors.

<h4>Fonts</h4>
The embedded fonts that are used to make the plates similar to their real ones are copied in this folder.

<h4>Vectors</h4>
Any vector parts of the plates that are created in a separate file are copied in this folder.

<h4>Pic</h4>
Any images that are used in the plates are copied in this folder.

<h4>Plates</h4>
The plates' controls are in this folder and developers can use these controls in their projects.

The project is not limited to a specific country, and there are country categories in each part. For example I have created my country plates, Iran, in this project. If you want to create your country plates you should add your country folder in each part.

<h3>How to use plates</h3>
It's very easy to use plates in your WPF project. Just add the corresponding plate to your XAML file:

> &lt;Viewbox Width="240" xmlns:irplate="clr-namespace:IRPlateModel.Wpf.Plates.Iran;assembly=IRPlateModel.Wpf"&gt;<br/>
> &nbsp;&nbsp;&lt;irplate:IRNationalPlate Plate="{Binding MyPlate, Mode=OneWay}" /&gt;<br/>
> &lt;/Viewbox&gt;

<b>Note:</b> The only way to change the size of the plate is to use a _Viewbox_.
The most important property of each plate control is the _Plate_ property. In the last example I bound it to _MyPlate_ property.
If you want to set it manually you should write plate's characters respectively and without any spaces, commas, etc.
For example:
> &lt;irplate:IRNationalPlate Plate="12X34567" /&gt;

<h3>Plate Inputs</h3>
Plate inputs are simple textboxes decorated with some features of the corresponding plate. See this example:

> &lt;StackPanel xmlns:irplate="clr-namespace:IRPlateModel.Wpf.Plates.Iran;assembly=IRPlateModel.Wpf"<br/>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns:irplateInput="clr-namespace:IRPlateModel.Wpf.Plates.Iran.Input;assembly=IRPlateModel.Wpf"&gt;<br/>
> &nbsp;&nbsp;&lt;irplate:IRNationalPlate Plate="{Binding Plate, ElementName=myPlateInput, Mode=OneWay}" /&gt;<br/>
> &nbsp;&nbsp;&lt;irplateInput:IRNationalPlateInput x:Name="myPlateInput" /&gt;<br/>
> &lt;/StackPanel&gt;

What you type in the input control is shown in the plate control immediately.

