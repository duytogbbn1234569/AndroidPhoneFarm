   M S B A M L   `   `   `  ���� ?  ;Code, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Code.ViewModelsCode.ViewModels  "    Code.Views.QuanLyThietBiView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  :d2http://schemas.microsoft.com/expression/blend/2008  )localclr-namespace:Code.ViewModels    � DataContext  ,   &Code.ViewModels.QuanLyThietBiViewModel  .���  � RowDefinitions �� $��70 ��� $��* �.+�� $��0��.+���  �� Orientation$ 
Horizontal=�.+�	� -    	�Name$ 
btnRefresh��   
mainButton#��[  $	��130��.���� $ 
Horizontal=�.+�!  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ RotateRight=�  menuButtonIcon#��[    
Foreground
 �����$��	10,0,10,0q��� $��
Làm mới��  titleColor2#��[ $��18(�$��
Moutserrat)�$��Medium"��� $��2�����#200F53 �� CornerRadius$ 10�� �� Padding$ 10q�._�&   System.Windows.Controls.DataGrid  -     Name$ 	dgThietBi��	   CanUserAddRows	 .  
   CanUserResizeColumns
 .     CanUserResizeRows .     HeadersVisibility$ Column=�   AutoGenerateColumns .  ���#200F53$��0q�$��2��   SelectionUnit$ FullRow=�   SelectionMode$ Single=�   GridLinesVisibility$
 None=�$��20,-2,20,25q�   ColumnHeaderStyle ��  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  �� Property � �� �� Value
 ���� ��  � �� �#BCBEE0��  � ��$ 0q���  � ��$ 
Montserrat)���  � ��$ 18(���  � ��$ Medium"���  � ��$ Center=�   RowStyle �� )  #System.Windows.Controls.DataGridRow"  .���  � ��$ Center=���  � ��
 ���� ��  � �� �#BCBEE0��  � ��$ 0q���  � ��$ 
Montserrat)���  � ��$ 15(���  � ��$ Center=�   	CellStyle �� *  $System.Windows.Controls.DataGridCell"  .���  � ��$ Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ 50
  	  Header$	 STT��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	SoThuTu+   ClipboardContentBinding Z�   $ 2*
 $ Mã thiết bị�� �� *	MaThietBi+ Z�   $ 2*
 $ Trạng thái�� �� *	TrangThai+ Z� 