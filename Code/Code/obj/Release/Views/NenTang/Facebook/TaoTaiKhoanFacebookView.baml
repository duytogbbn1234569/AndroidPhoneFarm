   M S B A M L   `   `   `  ���� ?  ;Code, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Code.Views.NenTang.FacebookCode.Views.NenTang.Facebook  9    3Code.Views.NenTang.Facebook.TaoTaiKhoanFacebookView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;local)clr-namespace:Code.Views.NenTang.Facebook     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  .���   � RowDefinitions  �� $��70 ��� $��50 ��� �� $��80 �.+�� $��0��.+���  �� Orientation$ 
Horizontal=�.+�	�    
mainButton#��[  ���� *ShowPopUpWindowCommand+.���� $ 
Horizontal=�.+�!  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Play=�  mainButtonIcon#��[    
Foreground
 �/����� $��
Thực thi��  titleColor2#��[ $��18(�$��
Moutserrat)�$��Medium"�$��40��$��	0,15,10,0q�	� #��[  ���� *
StopAction+.���� $ 
Horizontal=�.+�  $
 Stop=�#��[ 
 �  ���� $��Dừng��#��[ $��18(�$��
Moutserrat)�$��Medium"�$��40��$��	0,15,10,0q�� $��1��.+��� $ 
Horizontal=�$	��Top=�.+��� $$��Quá trình tạo tài khoản��#��[ $��18(�$��
Moutserrat)�$��Medium"�$��40��$��20,0,0,0q��� $��2�����#200F53 �� CornerRadius$ 10�� �� Padding$ 10q�._�&   System.Windows.Controls.DataGrid  -     Name$ deviceStatus��   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    AutoGenerateColumns .  	   
IsReadOnly	 . ���#200F53$��0q�
   CanUserAddRows
 .     CanUserResizeColumns .     CanUserResizeRows .     HeadersVisibility$ Column=�   GridLinesVisibility$
 None=����� *	devices+   ColumnHeaderStyle ��  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  �� Property � �� �� Value
 ���� ��  � �� �#BCBEE0��  � ��$ 0q���  � ��$ 
Montserrat)���  � ��$ 18(���  � ��$ Medium"���  � ��$ Center=�   RowStyle �� )  #System.Windows.Controls.DataGridRow"  .���  � ��$ Center=���  � ��
 ���� ��  � �� �#BCBEE0��  � ��$ 0q���  � ��$ 
Montserrat)���  � ��$ 15(���  � ��$ Center=�   	CellStyle �� *  $System.Windows.Controls.DataGridCell"  .���  � ��$ Center=���  � ��$ 
Montserrat)���  � ��$ 15(�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header$	 STT�� 	  Width$ 50 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *Stt+ 
  ClipboardContentBinding Z�   $ Mã thiết bị��$	 150  �� *
DeviceId+ Z�   $ Trạng thái��$ *  �� *Status+ Z� � $��3��.+��� $ Vertical=�$	��Top=�.+��� $ 
Horizontal=�.+��� $*��$Số tài khoản tạo thành công��#��[ $��14(�$��
Moutserrat)�$��Medium"�$��40��$��	20,10,0,0q��� #��[ $��14(�$��
Moutserrat)�$��Medium"�$��40��$��	80,10,0,0q����� *	ThanhCong+�� $ 
Horizontal=�.+��� $1��+Số tài khoản tạo không thành công��#��[ $��14(�$��
Moutserrat)�$��Medium"�$��40��$��20,0,0,0q��� #��[ $��14(�$��
Moutserrat)�$��Medium"�$��40��$��36,0,0,0q����� *	ThatBai+