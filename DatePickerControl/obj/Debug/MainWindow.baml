   M S B A M L   `   `   `  ����L  HDatePickerControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DatePickerControlDatePickerControl  5   	   "    DatePickerControl.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:DatePickerControl     5   	   -   5          � Title$  	InputDate��5   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�6:    � 	Resources 5	         placeHolder �� 
TargetType �� BasedOn �� Property �� Value �� 
TargetType	 ��Name
 K� ZIndex �� Path �� RelativeSource �� Mode �� UpdateSourceTrigger
 � Tag �� Triggers �� Binding �� Source%  System.Windows.Markup.Reference �� Value��%�  &	        7���� 5   
   " ��6$   8   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $	 
textSource��5   "   
������ $
 2��5   "   ��5   &   �� $
 Text� �� *TemplatedParent+$ TwoWay=�$ PropertyChanged=�5   "   �� 5      #��z 6&   #��z��6C   $
 1��6m   .��6~   ��5   "   �� 5   &   " ��6,   .�5   *   ��  � ��
 ���� 6G    5   *   �� 5   .    6:   �� $
 Text�   *
textSource+  6y   .a�5   2   ��  � ��$ Center=�6_   �� 5   2    � ��
 �����6O   5   /   5!   '   .��5"   1   5#      5$      5%      5'      5(      5)       J� CommandBindings 5*      )  #System.Windows.Input.CommandBinding  5+   
   -   5           Command$ ApplicationCommands.Close��5+      6=     5,   
   -   5        $ ApplicationCommands.Save��5,      5.      .��51      ��  �� Orientation$ Vertical=�6   $��10q�6(   .+�52   
   �� $ 
Horizontal=�6   .+�53      �� $ Vertical=�6   .+�54      �� $��Enter Start Date��6   $
��Bold"�64   �� 55      -   5        $	 	startDate��55      $	��0 5q�6-   $ Enter start Date��6:   #��[  6Q   56      �� 57      $ Vertical=�6   $
��20 0q�60   .+�58      �� $��Enter Start Time��6   $
��Bold"�64   �� 59      -   5        $	 	starttime��59      $	��0 5q�6-   $ Enter start Time��6:   #��[  6Q   5:      5;      (  "System.Windows.Controls.DatePicker  5<   
   -   5          Name$ 
datepicker��5<         SelectedDateFormat$ Short=�6)      SelectedDate$ 
2006/05/22X�6D   5=      �� 5>   
   $ 
Horizontal=�6   $��Center=�6.   .+�5?      �� -   5         ��Name$ OK��5?      $��OK��6!   $��ApplicationCommands.Save��6.   �� 5@      -   5        $ cancel��5@      $��Cancel��6%   $��ApplicationCommands.Close��66   5A      5B      5C      