   M S B A M L   `   `   `  ����C  ?Listbox2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Listbox2Listbox2  5   	       Listbox2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Listbox2     5   	   -   5          � Title$  
MainWindow��5   	   $	��302��6   $	��300��6)    � WindowStartupLocation$ CenterScreen=�65   
����  �.��5
      � $��10q�6   
����ح� � RowDefinitions 5   
   �� 5      -   5         ��Name$ rdgenre��5      $��* �6-   �� 5      -   5        $ 	rdcatalog��5      $��* �6/   �� 5      -   5        $ rdalbum��5      $��* �6-   .+�5   
   9� -   5         9�Name$ expanderGenre��5       $��0��6   $��Genre��67   
����  � 9� ExpandDirection$
 Down=�6\    9� 
IsExpanded . .��5      �� -   5         ��Name$ listboxGenre��5      $
��10 5q�6,   .@�5      �� $��	qweqweqwe��6   �� 5      $��	qweqweqwe��6   �� 5      $��	qweqweqwe��6   �� 5      $��	qweqweqwe��6   �� 5      $��	qweqweqwe��6   5      5      9� 5   
   -   5        $ expanderCatalog��5       $��1��6   $��Catalog��69   
����  �$
 Down=�6`    . .��5      �� -   5        $ listboxCatalog��5      $
��10 5q�6.   .@�5      �� $��	ertefgdfg��6   �� 5      $��	ertefgdfg��6   �� 5      $��	ertefgdfg��6   �� 5       $��	ertefgdfg��6   �� 5!      $��	ertefgdfg��6   �� 5"      $��	ertefgdfg��6   5#      5$      9� 5%   
   -	   5        $ expanderAlbum��5%       $��2��6   $��Album��67   
����  �$
 Down=�6\    . .��5'      �� -
   5        $ listboxAlbum��5'      $
��10 5q�6,   .@�5(      �� $��	asdasadad��6   �� 5)      $��	asdasadad��6   �� 5*      $��	asdasadad��6   �� 5+      $��	asdasadad��6   5,      5-      5.      5/      