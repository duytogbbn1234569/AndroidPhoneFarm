   M S B A M L   `   `   `  ����?  ;Code, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Code.Views.QuanLyTaiKhoanCode.Views.QuanLyTaiKhoan  5      4    .Code.Views.QuanLyTaiKhoan.TaiKhoanFacebookView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      3local'clr-namespace:Code.Views.QuanLyTaiKhoan  5      .��5
      �   � RowDefinitions  5   
   �� 5      $��70 �6   �� 5      $��50 �6   �� 5      .+�5   
   � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      	� -   5         	�Name$ 
btnRefresh��5         
mainButton#��[  62   $	��130��6V   .��5      �� $ 
Horizontal=�6!   .+�5      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ RotateRight=�6'     menuButtonIcon#��[ 6:      
Foreground
 �����$��	10,0,10,0q�6u   �� 5      $��
Làm mới��6%     titleColor2#��[ 5      $��18(�5      $��
Moutserrat)�5      $��Medium"�5      5      5      	� 5      -   5        $ btnDeleteError��5   B   #��[  6   .��5      �� $ 
Horizontal=�6!   .+�5        $ Trash=�6'     mainButtonIcon#��[ 64   
 �����6\   �� 5      $��Xóa tài khoản lỗi��6$   #��[ 5    $   $��18(�5!   $   $��
Moutserrat)�5"   $   $��Medium"�5#   $   $��40��68   $��	0,15,10,0q�5$   $   5%      5&      5'      5(      � 5)   
   $��1��6    � ColumnDefinitions 5*      �� 5+      $��* �6#   �� 5,      $	��120 �6#   .+�5.      �� $ 
Horizontal=�6   $	��Top=�5/      $��0��50      .+�51      �� $&�� Danh sách tài khoản Facebook��6   #��[ 52   $   $��20(�53   $   $��
Moutserrat)�54   $   $��Medium"�55   $   $��40��68   $��20,0,0,0q�56   $   57      58      �� 59   
   $��2��6   ���#200F53 �� CornerRadius$ 10��5;       �� Padding$ 10q�5<      ._�5=      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgTaiKhoan��5=   '   	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 6     datagrid#��[ 5>      ���#200F53$��0q�5@      
   ColumnHeaderStyle
 5A      �� 5B       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5C      ��  �� Property � �� �� Value
 ���� 67   �� 5D       � �� �#BCBEE067   �� 5E       � ��$ 	10,0,0,10q�64   �� 5F       � ��$ 
Montserrat)�67   �� 5G       � ��$ 18(�65   �� 5H       � ��$ Medium"�67   �� 5I       � ��$ Center=�6@   5J         	CellStyle 5L      �� 5M      *  $System.Windows.Controls.DataGridCell"  6   .�5N      ��  � ��$ Center=�6G   �� 5O       � ��$ 
Montserrat)�67   �� 5P       � ��$ 15(�65   5Q         Columns 5S      0  *System.Windows.Controls.DataGridTextColumn  5T      ,  &System.Windows.Controls.DataGridColumn   Width$ 50 6)      Header$	 STT��6o   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 64   �� *STT+ 	  ClipboardContentBinding 6L   Z� 6o     5U      $ Tài khoản��6l    6)   �� *TenDangNhap+ 6I   Z� 6l     5V      $ Mật khẩu��6h    6)   �� *	MatKhau+ 6E   Z� 6h     5W      $ Họ và tên��6f    6)   �� *HoTen+ 6C   Z� 6f     5X      $ Giới tính��6i    6)   �� *
GioiTinh+ 6F   Z� 6i     5Y      $ 
Ngày sinh��6i    6)   �� *
NgaySinh+ 6F   Z� 6i     5Z      $ Trạng thái��6j    6)   �� *	TrangThai+ 6G   Z� 6j     5[      $ Mã thiết bị��6j    6)   �� *	MaThietBi+ 6G   Z� 6j   5]      5^      5_      5`      