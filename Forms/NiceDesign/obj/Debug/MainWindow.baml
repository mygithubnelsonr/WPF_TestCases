   M S B A M L   `   `   `  ����E  ANiceDesign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:NiceDesign
NiceDesign  5   	       NiceDesign.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:NiceDesign     5   	   -   5          � Title$  
NiceDesign��5   	   $	��237��6   $	��400��6)    � WindowStartupLocation$ CenterScreen=�65      WindowBackgroundBrush#��[  6Z    � 	Resources 5	      ��%    5      .��5      ]� .+�5   
   � $��10q�6     MainGridBackgroundBrush#��[ 6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      ��  �� Orientation$ Vertical=�6   $��10q�60     StackpanelBackgroundBrush#��[ 6<   .+�5      �� $ Vertical=�6   .+�5      �� -   5         ��Name$ checkboxFullpathfromdb��5      $(��"Create full Pathlist from Database��6?    d� IsThreeState .  $��10q�6�   �� 5      -   5        $ checkboxFullpathfromfile��5      $$��Create full Pathlist from File��6A    .  $��10q�6   �� 5      -   5        $ checkboxOpenImporter��5      $��Open Mp3 Importer��6=    .  $��10q�6n   5      5      �� 5      -   5         ��Name$ buttonStart��5   "   $��1��6   $��Start��67   $��6q�6G   $��80��6R   $��24��6]   $��Center=�5      ��5      �� 5       �� 
TargetType" ��6   .�5      �� 	 �� Property	 � ��
 �� Value
 �	#FF03203467   �� 5       	 � ��$
 12(�65   �� 5!      	 � ��$

 Bold"�67   �� 5"      	 � ��
 �	#FF1667AA68   �� 5#      	 � ��$
 2q�6<   �� 5$      	 � ��

 �����67    �� Triggers 5%      P� 5&       P� Property �@J�IsMouseOver P� Value . . �5'   "   �� 	 � ��$
 Normal"�6?   �� 5)   "   	 � ��

 �   �6?   �� 5*   "   	 � ��

 ��  �6@   5+      5-      5/      �� 50      $��2��6   ���	#FF054F66$��1q�6:   ._�51      �� -   5         ��Name$ 	statusbar��51      $��22��6/   
�������
������#��[ 53      .@�54      �� -   5         ��Name$ 
statusText��54   $   $�� ��68   55      56      57      58      5:      