   M S B A M L   `   `   `  ����B  >TextBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TextBoxTextBox  5   	       TextBox.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:TextBox     5   	     � Title$  
MainWindow��5   	   $	��202��6   $	��400��6)    � WindowStartupLocation$ CenterScreen=�65   ���	#FF0D3359.��5	      � $��10q�6   ���	#FF3E76EC � RowDefinitions 5
   
   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��24 �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ textbox��5      $��0��6#   $��24��63   $��4q�6?   6J   �� 5   
   -   5         ��Name$ combobox��5      $��1��6%   $��24��65   $��4q�6A   .@�5      �� $�� ��6   �� 5      $��qwertz��6   �� 5      $��asdfg��6   �� 5      $��yxcvb��6   5      �� 5   
   -   5        $ textboxDrop��5      $��1��6'   $��2��64   $��4q�6H   ���	#FFBDBD95 J� 	AllowDrop . 5      �� 5   
   -   5         ��Name$ textboxInfo��5      $��2��6)   $��2��66   �� 5    
   -   5        $��3��5       $��2��6   $
��Test��62   $��60��6A   6L   5!      5"      