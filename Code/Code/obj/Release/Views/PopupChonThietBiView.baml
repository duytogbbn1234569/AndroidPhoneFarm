   M S B A M L   `   `   `  ���� ?  ;Code, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Code.Views
Code.Views  %    Code.Views.PopupChonThietBiView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:Code.Views       � Title$  PopupChonThietBiView��$	��400��$	��400�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�
������  � AllowsTransparency . .����  �� CornerRadius$ 10��$��1q�����  �� 
StartPoint$	 0,0&� �� EndPoint$ 1,0.7&�.���    secondaryBackColor1 � Color# [   � Offset$ 0Q�� # [  $ 1Q�._�� 	 � RowDefinitions	 �� $��* ��� $��4* ��� $��* �.+��� $��CHỌN THIẾT BỊ��$��Center=�$��0��  titleColor2#��[ $��20(�$��
Moutserrat)�$��Medium"�$��Center=�$��10,0,0,0q�&   System.Windows.Controls.DataGrid  -   
  Name$
 	dgThietBi��   CanUserAddRows .     CanUserResizeColumns .     CanUserResizeRows .     HeadersVisibility$ Column=�   AutoGenerateColumns .  ���#200F53$��0q�$��2��$	��250��   SelectionUnit$ FullRow=�   SelectionMode$ Single=�   GridLinesVisibility$
 None=�$��
20,60,20,0q�   ColumnHeaderStyle ��  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  �� Property � �� �� Value
 ���� ��  � �� �#BCBEE0��  � ��$ 0q���  � ��$ 
Montserrat)���  � ��$ 18(���  � ��$ Medium"���  � ��$ Center=�   RowStyle �� )  #System.Windows.Controls.DataGridRow"  .���  � ��$ Center=���  � ��
 ���� ��  � �� �#BCBEE0��  � ��$ 0q���  � ��$ 
Montserrat)���  � ��$ 15(���  � ��$ Center=�   	CellStyle �� *  $System.Windows.Controls.DataGridCell"  .���  � ��$ Center=�   Columns 4  .System.Windows.Controls.DataGridCheckBoxColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
IsSelected+   Header �� -   $��chkSelectAll��0	  *System.Windows.Controls.DataGridTextColumn	  $ 50 $	 STT��   
IsReadOnly .  �� *	SoThuTu+   ElementStyle �� " ��.���  � ��$ Center=�	  $ * $ Mã thiết bị�� .  �� *	MaThietBi+ �� " ��.���  � ��$ Center=�� $��2�� � ColumnDefinitions �� �� .+��� -     ��Name$  btnStart��$��0��  controlButton#��[ $��80��$��30��
������� 
 color2#��[ $��
Thực thi��$��	99,0,20,0q��� -   $  	btnCancel��$��1��#��[ $��80��$��30��
������� 
 color4#��[ $��
Hủy bỏ��$��20,13,99,14q�