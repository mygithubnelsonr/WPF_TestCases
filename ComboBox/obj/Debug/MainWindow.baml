   M S B A M L   `   `   `  ����C  ?Combobox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ComboboxCombobox  5   	   b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 5   	       Combobox.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Combobox     5   	   ^ThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     5   	     � Title$  
MainWindow��5	   	   $	��257��6   $	��400��6)   ���	#FF096292 � WindowStartupLocation$ CenterScreen=�6L    � 	Resources 5
       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�  '��       '�� �     '�� @    �� 5   
   " ��6   .�5      ��  � ��
 �  ��6+   �� 5       � ��
 ��  �6+   �� 5       � ��$
 Bold"�6+   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+    5      P� 5       �@��
IsSelected . 60   P� 5       � ��
 � � �60   5      �� 5   
   " ��6   .�5      ��  � �� �	#FF006C976+   �� 5       � ��
 �����6+   �� 5       � �� �	#FF1D39B26,   �� 5       � ��$ 3q�60   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 50��6&   �� 5       � ��$ Right=�64   5      5       .��5!      � $��15q�6   ���	#FF02132F	 � RowDefinitions	 5"   
   �� 5#      $
��Auto �6   �� 5$      $��* �6   �� 5%      $��32 �6   .+�5'   
   �� 
 �� Orientation$
 
Horizontal=�6   $��0 10 0 0q�6.   .+�5(      �� -   5        $��combobox��5(      $	��140��6'   $
��10 0q�63   $
��Left=�6A    �� 
IsEditable .  ��5*      �� 5+      .R�5,      �� ��6$   ��  �� Path$
 Name�5-      5/      �� 50      -   5         ��Name$ 	buttonAdd��50      $	��Add��6(   $��10 0 0 0q�66   6H   �� 51      -   5        $ 
buttonDown��51      $
��Down��6)   $��10 0 0 0q�69   6K   �� 52      -   5        $ buttonUp��52      $��Up��6'   $��50��64   $��10 0 0 0q�6?   6Q   53      �� 54   
   $��1��6   $
 Vertical=�6"   $��10q�69   .+�55      �� -   5         ��Name$ 	textblock��55      $�� ��6+   $	��300��63   $��24��6?   $	��0 4q�6N   $
��Bold"�6[   
����������	#FF0320346�   �� 56      -   5         ��Name$ labelPerson��56      $	��300��6)   $��60��65   $	��0 4q�6D   $
��Bold"�6Q   
����������	#FF0320346}   57      �� 58   
   $��2��6   $
 Vertical=�6"   $��Bottom=�69   .+�59      �� -   5        $ 
buttonTest��59      $
��Test��6)   $��80��68   $��4q�6C   $��Center=�6N   6k   5:      5;      5<      