   M S B A M L   `   `   `  ����?  ;Code, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Code.Views
Code.Views  5   	   %    Code.Views.PopupChonThietBiView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Code.Views     5   	     � Title$  PopupChonThietBiView��5   	   $	��400��6&   $	��400��63    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�5
   	   
������  � AllowsTransparency . .��5      ��  �� CornerRadius$ 10��6   $��1q�5   	   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$ 1,0.7&�63   .��5      �    secondaryBackColor1 � Color# [  6    � Offset$ 0Q�6L   � 5      # [  6   $ 1Q�6L   5      ._�5   
   � 	 � RowDefinitions	 5      �� 5      $��* �6    �� 5      $��4* �6    �� 5      $��* �6    .+�5      �� $��CHỌN THIẾT BỊ��6   $��Center=�5      $��0��5        titleColor2#��[ 5      $��20(�5      $��
Moutserrat)�5       $��Medium"�5!      $��Center=�5"      $��10,0,0,0q�5#      &   System.Windows.Controls.DataGrid  5$      -   5        
  Name$
 	dgThietBi��5)         CanUserAddRows .     CanUserResizeColumns .     CanUserResizeRows .     HeadersVisibility$ Column=�5(         AutoGenerateColumns .  ���#200F53$��0q�5,      $��2��5-      $	��250��5.         SelectionUnit$ FullRow=�5/         SelectionMode$ Single=�50         GridLinesVisibility$
 None=�52      $��
20,60,20,0q�53         ColumnHeaderStyle 54      �� 55       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�56      ��  �� Property � �� �� Value
 ���� 67   �� 57       � �� �#BCBEE067   �� 58       � ��$ 0q�64   �� 59       � ��$ 
Montserrat)�67   �� 5:       � ��$ 18(�65   �� 5;       � ��$ Medium"�67   �� 5<       � ��$ Center=�6@   5=         RowStyle 5?      �� 5@      )  #System.Windows.Controls.DataGridRow"  6   .�5A      ��  � ��$ Center=�6G   �� 5B       � ��
 ���� 67   �� 5C       � �� �#BCBEE067   �� 5D       � ��$ 0q�64   �� 5E       � ��$ 
Montserrat)�67   �� 5F       � ��$ 15(�65   �� 5G       � ��$ Center=�6G   5H         	CellStyle 5J      �� 5K      *  $System.Windows.Controls.DataGridCell"  6   .�5L      ��  � ��$ Center=�6G   5M         Columns 5O      4  .System.Windows.Controls.DataGridCheckBoxColumn  5P      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *
IsSelected+   Header 5Q      �� 5R      -   5        $��chkSelectAll��5R   '   6Z   5T      0	  *System.Windows.Controls.DataGridTextColumn	  5U      $ 50 6)   $	 STT��6P      
IsReadOnly .  64   �� *	SoThuTu+   ElementStyle 5V      �� 5W      " ��6$   .�5X   "   ��  � ��$ Center=�6H   5Y      5[      	  5\      $ * 6)   $ Mã thiết bị��6Q    .  63   �� *	MaThietBi+ 5]      �� 5^      " ��6$   .�5_   "   ��  � ��$ Center=�6H   5`      5b      5d      � 5e      $��2��6    � ColumnDefinitions 5f      �� 5g      �� 5h      .+�5j      �� -   5          ��Name$  btnStart��5q      $��0��5j        controlButton#��[ 5k      $��80��5l      $��30��5m      
������� 
 color2#��[ 5o      $��
Thực thi��5p      $��	99,0,20,0q�6,   5q   +   �� 5r      -   5        $  	btnCancel��5y      $��1��5r      #��[ 5s      $��80��5t      $��30��5u      
������� 
 color4#��[ 5w      $��
Hủy bỏ��5x      $��20,13,99,14q�6*   5y   ,   5z      5{      5|      5}      