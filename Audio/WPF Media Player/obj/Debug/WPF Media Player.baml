   M S B A M L   `   `   `  ����@  <Audio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:AudioAudio  5   	       Audio.WPF_Media_Player   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Audio     5   	     � Title$  WPF Media Player��5   	   $	��192��6"   $	��300��6/    � SizeToContent$ Width=�5	       � WindowStartupLocation$ CenterScreen=�6#    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Open��5      6Y     5   
   -   5        $ MediaCommands.Play��5      6S     5   
   -   5        $ MediaCommands.Pause��5      6U     5   
   -   5        $ MediaCommands.Stop��5      6S   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   c� .@�5      �� $
��Open��6   $��5 0 5 0q�6$   $��ApplicationCommands.Open��65   �� 5      �� 5      $
��Play��6   $��5 0 5 0q�6$   $��MediaCommands.Play��65   �� 5      $��Pause��6   $��5 0 5 0q�6%   $��MediaCommands.Pause��66   �� 5      $
��Stop��6   $��5 0 5 0q�6$   $��MediaCommands.Stop��65   � 5      .+�5      � -   5        $��pbVolume��5      $��80��6.   $
��25 0q�69    � Maximum$ 1Q�6G    � Value 6S   ��  �� ElementName$ mePlayer��	 �� Path$	 Volume��� 5       -   5        
 ��Name$
 sliderVolume��5       $ 1Q�6/    � Minimum$ 0Q�6;   $��80��6G   $
��25 0q�6R   $ 0Q�6`    �� TickPlacement$ TopLeft=�5!       �� TickFrequency$
 0.05Q�5"       �� Ticks$  0, 0.2, 0.4, 0.6, 0.8, 1.0R�5'   $   5(      5)      5*      r� 5,   
   -   5        $��mePlayer��5,      $��1��6'    r� LoadedBehavior$ Manual=�64    r� Stretch$
 None=�6L    r� Volume$ 0Q�6[   5-   8   �� 5/   
   $��2��6   ��50      �� 51      .R�52      �  � ColumnDefinitions 53      �� 54      $
��Auto �6/   �� 55      $��* �6/   �� 56      $
��Auto �6/   58      59      .@�5;      �� .��5<      �� -   5        $��lblProgressStatus��5<      
00:00:006?   5=      �� 5>      $��1��6   $��Stretch=�6,   .��5?      �� -	   5        $��sliProgress��5?      5B      5C      5D      5E      5F      