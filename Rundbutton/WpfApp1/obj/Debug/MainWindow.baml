   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  
MainWindow��5   	   $	��397��63   $	��525��6@    � WindowStartupLocation$ CenterScreen=�6b   ��6L   Z� .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��260* �6   �� 5      $
��260* �6    � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $
��180* �6   �� 5      $��80 �6   ��5   
   �� 5       �� EndPoint$ 
0.032,0.96&�6"    �� 
StartPoint$ 
0.99,0.012&�68   .��5      �  � Color$ Black��6    � Offset$ 0.001Q�6-   � 5      $ White��6   $ 0.426Q�6-   5      .+�5   
   �� -   5         ��Name$ label1��5      $��Hello World��6    $
��Left=�66   $��	118,8,0,0q�6Q   $	��Top=�6d   $��280.098��6|   $��62.438��6�   $��2��6�   ���	#FFE8E6C5$��36(�6�   ���	#FF1F49DA$��Center=�6�   �� 5   
   -   5        	 ��Name$	 button_Test��5      $��2��6'   $��0��64   $��Open RoundButton��6D   $��Center=�6`   $	��110��6{   6�   �� 5   
   -   5        $	 button_Close��5      $��2��6'   $��1��64   $��Close��6D   $��Center=�6T   $
��88.0��6o   6|   �� 5   
   -   5        
 ��Name$
 	listView1��5      $��4��6&   $
��Left=�6:   $	��137��6U   $��	10,10,0,0q�6b   $��1��6u   $	��Top=�6�   $��498.6��6�   $��4��6�   ���	#FFE3F1BF �� View 5      �� 5      .P�5       �� 5!      .@�5#      �� $��ListViewItem��6   $��0q�62   ���	#FFE8D8D86=   �� 5$      $��ListViewItem��6   $��0q�62   ���	#FFE5DBC66=   �� 5%      $��ListViewItem��6   $��0q�62   ���	#FFE8D8D86=   5&      5'      5(      