   M S B A M L   `   `   `  ����F  BDatabinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DatabindingDatabinding  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       Databinding.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Databinding     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  Databinding Demo��5	   	   $	��199��6"   $	��400��6/    � WindowStartupLocation$ CenterScreen=�6;    � DataContext 5
      ��5   
   Hallo Welt!��6"   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��Center=�6   
����ح�.+�5      �� -   5         ��Name$ 	textblock��5      $��Textsize��6+   $��5q�6o   
���������6;   ��  �� Path$
 Text� �� ElementName$ eingabe��6z   �� 5      $��Fontsize eingeben:��6   �� 5      -   5         ��Name$ eingabe��5      $��24��6'   $��5q�63   5      �� 5   
   $��1��6   $��Center=�6%   $��88��6@   
�������.+�5      �� $��5q�5      
���������5      �� $ Value�$ slider��	 �� StringFormat$	 #0.#0��
 �� ConverterCulture$
 de-DE��5   #   �� 5      -   5         ��Name$ slider��5      $��24��6%   $��5q�61    � Value$ 5Q�6<    � SmallChange$	 0.5Q�6F    � LargeChange$	 0.5Q�6X    � Cursor$
 Hand��6j    �� TickFrequency$ 5Q�6x    �� TickPlacement$
 Both=�6�   5       �� 5!   
   $��2��6   
�������$��88��6<   .+�5"      �� $��5q�6)   $��14(�64   $
��Bold"�6B   $��Center=�6T   ��6   �� 6T   �� 5#      $��5q�65   ��6   �� $ Length�65   �� 5$      $��5q�6-   ��6   �� *[6]+6-   5%      �� 5&   
   $��1��6   $��0��6"   $��Center=�62   $��88��6M   
������ 5'      ��5(      2021/01/29 19:40��61   .+�5*      �� ��6   �� $
 Year��� 5+      ��6   �� $ Month��� 5,      ��6   �� $	 Day��� 5-      ��6   �� $ 	DayOfYear��� 5.      ��6   �� $ 	DayOfWeek�5/      �� 50   
   $��1��6   $��1��6"   $��Center=�62   
������� 51         Databinding.Person  52         Vorname$ Robert��6      Nachame$ Nelson��60      Alter$ 67��6A      
Geburtstag$ 
1954/01/09��6L   .+�54      �� $��3q�61   ��6   �� *	Vorname+61   �� 55      $��3q�61   ��6   �� *	Nachame+61   �� 56      $��3q�6/   ��6   �� *Alter+6/   �� 57      $��3q�6e   ��6   �� *
Geburtstag+$	 
dd.MM.yyyy��$
 de-DE��6e   58      59      5:      