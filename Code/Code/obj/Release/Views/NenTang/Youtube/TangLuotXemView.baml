   M S B A M L   `   `   `  ���� ?  ;Code, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Code.Views.NenTang.YoutubeCode.Views.NenTang.Youtube  0    *Code.Views.NenTang.Youtube.TangLuotXemView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:Code.Views.NenTang.Youtube     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  .���   � RowDefinitions  �� $��70 ��� $��4* ��� $��5* �.+�� $��0��.+���  �� Orientation$ 
Horizontal=�.+��� $ 
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
Moutserrat)�$��Medium"�$��40��$��	0,15,10,0q�	� #��[  ���� *GetInformation+.���� $ 
Horizontal=�.+�  $
 Link=�#��[ 
 ������� $��Lấy thông tin��#��[ $��18(�$��
Moutserrat)�$��Medium"�$��40��$��	0,15,10,0q�� $��1��.+��� $ 
Horizontal=�$	��Top=�.+��   �� $��40 ��� $��40 ��� $��40 ��� $��40 � � ColumnDefinitions �� $	��130 ��� $��* �.+��� $��Đường dẫn��$��0��$��0��#��[ $��14(�$��
Moutserrat)�$��Medium"�$��25��$��20,0,0,0q��� $��Số lượt cần tăng��$��0��$��1��#��[ $��14(�$��
Moutserrat)�$��Medium"�$��25��$��	20,10,0,0q��� $��Thời gian xem��$��0��$��2��#��[ $��14(�$��
Moutserrat)�$��Medium"�$��25��$��	20,10,0,0q��� $��Số lượt đã xem��$��0��$��3��#��[ $��14(�$��
Moutserrat)�$��Medium"�$��25��$��	20,10,0,0q��� $��1��$��0��$	��300��$��30������ *
DuongDan+�� $��1��$��1��$	��300��$��30������ *SoLuotCanTang+�� $��1��$��2��$	��300��$��30������ *ThoiGianXem+�� $��1��$��3��#��[ $��14(�$	��300��$��30��$��
Moutserrat)�$��Medium"����� *	TrangThai+�   �� $��40 ��� $��40 ��� $��40 ��� $��40 � �� $	��130 ��� $��* �.+��� $��Thông tin video��$��0��$��0��#��[ $��14(�$��
Moutserrat)�$��Medium"�$��25��$��20,0,0,0q��� $��Tiêu đề��$��0��$��1��#��[ $��14(�$��
Moutserrat)�$��Medium"�$��25��$��20,0,0,0q��� $��Thời lượng��$��0��$��2��#��[ $��14(�$��
Moutserrat)�$��Medium"�$��25��$��20,0,0,0q��� $��Số lượt xem��$��0��$��3��#��[ $��14(�$��
Moutserrat)�$��Medium"�$��25��$��20,0,0,0q��� $��1��$��1��#��[ $��14(�$��
Moutserrat)�$��Medium"�$��25��$��20,0,0,0q����� *TieuDe+�� $��1��$��2��#��[ $��14(�$��
Moutserrat)�$��Medium"�$��25��$��20,0,0,0q����� *	ThoiLuong+�� $��1��$��3��#��[ $��14(�$��
Moutserrat)�$��Medium"�$��25��$��20,0,0,0q����� *	SoLuotXem+�� $��2�����#200F53 �� CornerRadius$ 10�� �� Padding$ 10q�._�&   System.Windows.Controls.DataGrid  -     Name$ deviceStatus��   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *   datagrid#��[ ���#200F53$��0q����� *	devices+	   ColumnHeaderStyle	 �� 
 �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"
  .���  �� Property � �� �� Value
 ���� ��  � �� �#BCBEE0��  � ��$ 0q���  � ��$ 
Montserrat)���  � ��$ 18(���  � ��$ Medium"���  � ��$ Center=�   RowStyle �� )  #System.Windows.Controls.DataGridRow"
  .���  � ��$ Center=���  � ��
 ���� ��  � �� �#BCBEE0��  � ��$ 0q���  � ��$ 
Montserrat)���  � ��$ 15(���  � ��$ Center=�   	CellStyle �� *  $System.Windows.Controls.DataGridCell"
  .���  � ��$ Center=���  � ��$ 
Montserrat)���  � ��$ 15(�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header$	 STT�� 	  Width$ 50 1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding �� *Stt+ 
  ClipboardContentBinding Z�   $ Mã thiết bị��$	 150  �� *
DeviceId+ Z�   $ Trạng thái��$ *  �� *Status+ Z�   $ Đường Dẫn��$ *  �� *Url+ Z� 