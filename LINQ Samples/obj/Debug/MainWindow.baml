   M S B A M L   `   `   `  ����G  CLINQ Samples, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:LINQ_SamplesLINQ_Samples  5   	       LINQ_Samples.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:LINQ_Samples     5   	     � Title$  LINQ Samples��5   	   $	��220��6   $	��604��6+    � WindowStartupLocation$ CenterScreen=�67      WindowBackgroundBrush#��[  6\    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�  '��       '�� n     '�� �     �� 5
   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 85��6&   5      �� 5   
   " ��6   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$
 10 5q�6'   �� 5       �@d�IsThreeState .  6-   5      5      .��5      ]� $��10q�6     MainGridBackgroundBrush#��[ 6   .+�5      �� $	��Top=�6    �� Orientation$ 
Horizontal=�6+   $��Right=�6D   .+�5      �� $��Choose Text��6   $��10 1 0 0q�6*   $
��Bold"�6<   �� 5      -   5         ��Name$ combobox��5      $��20��6)   $	��120��65   $��0 5 0 0q�6A   ��5      �� 5      .R�5      �� $
��Bold"�6?   $��Center=�6Q   ��6$   ��  �� Path$
 Name�6Q   5      5!      �� 5"      -   5        	 ��Name$	 buttonStart��5"      $��Start��6*   $��20��6:   $��60��6F   $��	10 5 10 0q�6Q   6d   5#      �� 5$   
   $��Bottom=�6   .+�5%      �� -   5        
 ��Name$
 textblockStatus��5%      $��.....��61   $
��10 0q�6>   5&      � 5'   
   -   5         �Name$
 grid��5'      #��[ 6   .+�5(      �� $��10q�6     StackpanelBackgroundBrush#��[ 6%   .+�5)      �� -   5         ��Name$ checkboxAnyContains��5)      $��Usage of Any and Contains��68   �� 5*      -   5        $ checkboxIndexOf��5*      $��Usage of IndexOf��64   �� 5+      -   5        $ checkboxMinMax��5+      $��Usage of Min and Max��63   5,      5-      5.      5/      