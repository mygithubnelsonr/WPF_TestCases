   M S B A M L   `   `   `  ����I  E(De) Serialize, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:_De__Serialize_De__Serialize  5   	       _De__Serialize.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:_De__Serialize     5   	     � Title$  XML Serialize��5   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�6>   ���	#FF070763 � 
ResizeMode$ NoResize=�5	   $   .��5
      ]� .+�5   
   � $��Bottom=�6   $��
10 0 10 10q�6'   
������� � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� -   5         ��Name$ 	buttonAdd��5      $��1��6(   $	��New��68   $��24��6F   $��60��6R   $��0 6 44 6q�6]   $
��Bold"�5      $��Center=�6'   6D   �� 5      -   5        $ 
buttonSave��5      $��1��6)   $
��Save��69   $��24��6H   $��60��6T   $��0 6 44 6q�6_   $
��Bold"�5      $��Right=�6'   6C   5      � 5   
   $��
10 10 10 0q�6    5      �� 5      $	��270 �6#   �� 5      $	��20* �6#   .+�5      �� $��0��6   $��0��6&   
�������.+�5      �� -   5         ��Name$ listBox��5      $	��280��6+   $��
10 10 10 0q�68   6L   5      �� 5      $��1��6   
������� � 	Resources 5       �� 
TargetType	 �� Property
 �� Value��%�   '��       '�� p     �� 5      " ��6   .�5       �� 	 � ��$	
 200��62   �� 5!      	 � {�$
 False��66   5"      �� 5#      " ��6   .�5$      �� 	 � ��$	
 4 2q�64   5%      5&      .+�5'      �� $��1��6   $��10q�6-   .+�5(      �� .+�5)      �� $	��ID:��6    $
��Bold"�6.   �� 5*      -   5         ��Name$ textID��5*   "   $��24��62   5+      �� 5,      .+�5-      �� $��Vorname:��6    $
��Bold"�63   �� 5.      -   5        $ textVorname��5.   "   $��24��67   5/      �� 50      .+�51      �� $��	Nachname:��6    $
��Bold"�64   �� 52      -   5        $ textNachname��52   "   $��24��68   53      �� 54      .+�55      �� $��Alter:��6    $
��Bold"�61   �� 56      -   5        $ 	textAlter��56   "   $��24��65   57      �� 58      .+�59      �� $��Image:��6    $
��Bold"�61   � 5:      .+�5;      �� -   5         ��Name$ picture��5;   $   $��60��65   $��60��6@   $y�Visible=�6L   $
��Left=�5<   $   $	��Top=�6?   �� 5=      -	   5        $ 	textImage��5=   &   $��24��69   $y�Hidden=�6E   $
��Left=�5>   &   $	��Top=�6A   5?      5@      5A      5B      5C      5D      5E      