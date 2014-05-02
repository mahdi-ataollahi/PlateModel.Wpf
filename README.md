PlateModel.Wpf
==============

A vehicle license plate -as it defined in wikipedia- is a metal or plastic plate attached to a motor vehicle or trailer for official identification purposes.
If you want to build a WPF program that shows license plates, you can use this project to demonstrate high quality license plates which are similar to the real plates.

<h2>Project structure</h1>
There are some main parts in the project:
<ol>
  <li>Flags</li>
  <li>Fonts</li>
  <li>Vectors</li>
  <li>Pic</li>
  <li>Plates</li>
</ol>

<h3>Flags</h3>
The flag of the countries whose plates are contained in the project are in this folder seperately. The flags are created by WPF graphics so they are vectors.

<h3>Fonts</h3>
The embedded fonts that are used to make the plates similar to their real ones are copied in this folder.

<h3>Vectors</h3>
Any vector parts of the plates that are created in a seperate file are copied in this folder.

<h3>Pic</h3>
Any images that are used in the plates are copied in this folder.

<h3>Plates</h3>
The plates' controls are in this folder and developers can use these controls in their projects.

The project is not limited to a specific country, and there are country categories in each part. For example I have created my country plates, Iran, in this project. If you want to create your country plates you should add your country folder in each part.

<h2>How to use plates</h2>
It's very easy to use plates in your WPF project. Just add the corresponding plate to your XAML file:
><Viewbox Width="240" xmlns:irplate="clr-namespace:PlateModel.Wpf.Plates.Iran;assembly=PlateModel.Wpf">
>   <irplate:IRNationalPlate Plate="{Binding MyPlate, Mode=OneWay}" />
></Viewbox>

<b>Note:</b> The only way to change the size of the plate is to use a _Viewbox_.
The most important property of each plate control is the _Plate_ property. In the last example I bound it to _MyPlate_ property.
If you want to set it manually you should write plate's characters respectively and without any spaces, commas, etc.
For example:
><irplate:IRNationalPlate Plate="12X34567" />

<h2>Plate Inputs</h2>
Plate inputs are simple textboxes decorated with some featuers of the corresponding plate. See this example:
><StackPanel xmlns:irplate="clr-namespace:PlateModel.Wpf.Plates.Iran;assembly=PlateModel.Wpf"
>            xmlns:irplateInput="clr-namespace:PlateModel.Wpf.Plates.Iran.Input;assembly=PlateModel.Wpf">
>   <irplate:IRNationalPlate Plate="{Binding Plate, ElementName=myPlateInput, Mode=OneWay}" />
>   <irplateInput:IRNationalPlateInput x:Name="myPlateInput" />
></StackPanel>

What you type in the input control is shown in the plate control immediately.
