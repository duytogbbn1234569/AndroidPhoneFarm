   M S B A M L   `   `   `  ���� ?  ;Code, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Code.ViewModelsCode.ViewModels  E'clr-namespace:Code.Views.QuanLyTaiKhoanCode.Views.QuanLyTaiKhoan  2    ,Code.Views.QuanLyTaiKhoan.TaiKhoanGoogleView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  .
viewmodelsclr-namespace:Code.ViewModels  3local'clr-namespace:Code.Views.QuanLyTaiKhoan  .���   � RowDefinitions  �� $��70 ��� $��50 ��� .+�� $��0��.+���  �� Orientation$ 
Horizontal=�.+�	� -    	�Name$ 
btnRefresh��   
mainButton#��[  $	��130��.���� $ 
Horizontal=�.+�!  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ RotateRight=�  menuButtonIcon#��[    
Foreground
 �����$��	10,0,10,0q��� $��
Làm mới��  titleColor2#��[ $��18(�$��
Moutserrat)�$��Medium"�	� -   $ btnDeleteError��#��[  .���� $ 
Horizontal=�.+�  $ Trash=�  mainButtonIcon#��[ 
 ������� $��Xóa tài khoản lỗi��#��[ $��18(�$��
Moutserrat)�$��Medium"�$��40��$��	0,15,10,0q�� $��1�� � ColumnDefinitions �� $��* ��� $	��120 �.+��� $ 
Horizontal=�$	��Top=�$��0��.+��� $$��Danh sách tài khoản Google��#��[ $��20(�$��
Moutserrat)�$��Medium"�$��40��$��20,0,0,0q��� $��2�����#200F53 �� CornerRadius$ 10�� �� Padding$ 10q�._�&   System.Windows.Controls.DataGrid  -     Name$ 
dgTaiKhoan��	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 
   AutoGenerateColumns
 .     
IsReadOnly . ���#200F53$��0q�   CanUserAddRows .     CanUserResizeColumns .     CanUserResizeRows .     HeadersVisibility$ Column=�   GridLinesVisibility$
 None=�   ColumnHeaderStyle ��  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  �� Property � �� �� Value
 ���� ��  � �� �#BCBEE0��  � ��$ 0q���  � ��$ 
Montserrat)���  � ��$ 18(���  � ��$ Medium"���  � ��$ Center=�   RowStyle �� )  #System.Windows.Controls.DataGridRow"  .���  � ��$ Center=���  � ��
 ���� ��  � �� �#BCBEE0��  � ��$ 0q���  � ��$ 
Montserrat)���  � ��$ 15(���  � ��$ Center=�   	CellStyle �� *  $System.Windows.Controls.DataGridCell"  .���  � ��$ Center=���  � ��$ 
Montserrat)���  � ��$ 15(�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Width$ 50  	  Header$	 STT��1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *STT+ 
  ClipboardContentBinding Z�   $ Tài khoản�� �� *TenDangNhap+ Z�   $ Mật khẩu�� �� *	MatKhau+ Z�   $ Họ và tên�� �� *HoTen+ Z�   $ Giới tính�� �� *
GioiTinh+ Z�   $ 
Ngày sinh�� �� *
NgaySinh+ Z�   $ Trạng thái�� �� *	TrangThai+ Z�   $ Mã thiết bị�� �� *	MaThietBi+ Z� 