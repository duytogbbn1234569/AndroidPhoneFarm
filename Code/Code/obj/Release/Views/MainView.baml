   M S B A M L   `   `   `  ���� ?  ;Code, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Code.Views
Code.Views  I)clr-namespace:Code.Views.NenTang.FacebookCode.Views.NenTang.Facebook  E'clr-namespace:Code.Views.NenTang.GoogleCode.Views.NenTang.Google  G(clr-namespace:Code.Views.NenTang.YoutubeCode.Views.NenTang.Youtube  E'clr-namespace:Code.Views.QuanLyTaiKhoanCode.Views.QuanLyTaiKhoan  1clr-namespace:Code.ViewModelsCode.ViewModels      Code.Views.MainView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:Code.Views     =localFB)clr-namespace:Code.Views.NenTang.Facebook     ;localGG'clr-namespace:Code.Views.NenTang.Google     <localYT(clr-namespace:Code.Views.NenTang.Youtube     ;localTK'clr-namespace:Code.Views.QuanLyTaiKhoan     3	viewModelclr-namespace:Code.ViewModels     X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp    � Title$  MainWindowView��$	��700��$
��1300�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�
������  � AllowsTransparency .  � DataContext #   Code.ViewModels.MainViewModel   � 	Resources  �� DataType,   &Code.ViewModels.QuanLyHeThongViewModel"   Code.Views.QuanLyHeThongView,   &Code.ViewModels.QuanLyThietBiViewModel"   Code.Views.QuanLyThietBiView-   'Code.ViewModels.TaiKhoanGoogleViewModel2   ,Code.Views.QuanLyTaiKhoan.TaiKhoanGoogleView.   (Code.ViewModels.TaiKhoanFacbookViewModel4	   .Code.Views.QuanLyTaiKhoan.TaiKhoanFacebookView0
   *Code.ViewModels.TaoTaiKhoanGoogleViewModel5   /Code.Views.NenTang.Google.TaoTaiKhoanGoogleView*   $Code.ViewModels.TangLuotXemViewModel0   *Code.Views.NenTang.Youtube.TangLuotXemView-   'Code.ViewModels.TangLuotDangKyViewModel3   -Code.Views.NenTang.Youtube.TangLuotDangKyView2   ,Code.ViewModels.TaoTaiKhoanFacebookViewModel9   3Code.Views.NenTang.Facebook.TaoTaiKhoanFacebookView.   (Code.ViewModels.TangLuotTheoDoiViewModel5   /Code.Views.NenTang.Facebook.TangLuotTheoDoiView��%2  (��       *, +)(��      *, +)(�� $     *, +)(�� 6     *, +)(�� H     *,
 +)(�� Z     *, +)(�� l     *, +)(�� ~     *, +)(�� �     *, +)�� "  .R�  �� "  .R�  �� "  .R�  �� "  .R�	  �� " 
 .R�  �� "  .R�  �� "  .R�  �� "  .R�  �� "  .R�  .����  �� CornerRadius$ 10��$��1q�����  �� 
StartPoint$	 0,0&�	 �� EndPoint$		 1,1&�.���    winBorderColor1
 � Color#
 [   � Offset$ 0Q��   winBorderColor2#
 [ $
 0.75Q��   winBorderColor3#
 [ $ 1Q�._��  � ColumnDefinitions �� $	��250 ��� $��* �.+��� $ 	0,10,10,0��$��0������ $	 0,0&�$	 1,0.7&�.���   secondaryBackColor1#
 [ $ 0Q�� #
 [ $ 1Q�._��� .+���  �� Orientation$ 
Horizontal=�$��35��$��
15,25,0,40q�.+��� $��/Images/Logo.png��$��30���� $��
PHONE FARM��  titleColor2#��[ $��20(�$��
Moutserrat)�$��Medium"�$��Center=�$��10,0,0,0q��� $��CHỨC NĂNG QUẢN LÝ��#��[ $��20(�$��
Moutserrat)�$��Medium"�$��40��$��20,0,0,0q�	�   
menuButton#��[  
 color1
 � Tag# [  d� 	IsChecked$
 TrueY����� *ShowQuanLyHeThongViewCommand+.���� $ 
Horizontal=�.+�!  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Gear=�  menuButtonIcon#��[ �� $��Quản lý hệ thống��  menuButtonText#��[ 	� #��[  
	 color2# [	 ���� *ShowQuanLyThietBiViewCommand+.���� $ 
Horizontal=�$	��253��.+�  $ 	UserGroup=�#��[  J� RenderTransformOrigin$ 1.197,0.533&��� $��Quản lý thiết bị��#��[ 	� -    	�Name$ btnQuanLyTaiKhoan��#��[  

 color3# [
 .���� $ 
Horizontal=�.+�  $ ShoppingBag=�#��[ �� $��Quản lý tài khoản��#��[ �� -    ��Name$ pnlQuanLyTaiKhoan��$ Vertical=�$y�	Collapsed=�.+�	� #��[  
 color4# [ ���� *ShowTaiKhoanGoogleViewCommand+.���� $ 
Horizontal=�$��20,0,0,0q�.+�  $ Google=�#��[ �� $��Google��#��[ 	� #��[ # [ ���� *!ShowTaiKhoanFacebookViewCommand+.���� $ 
Horizontal=�$��20,0,0,0q�.+�  $ Facebook=�#��[ �� $��Facebook��#��[ �� $��CHỨC NĂNG THAO TÁC��#��[ $��20(�$��
Moutserrat)�$��Medium"�$��40��$��20,0,0,0q�	� -   $ 	btnGoogle��#��[  
 color5# [ .���� $ 
Horizontal=�.+�  $ Google=�#��[ �� $��Google��#��[ �� -   $ 	pnlGoogle��$ Vertical=�$y�	Collapsed=�.+�	� #��[  
 color9# [ ���� *" ShowTaoTaiKhoanGoogleViewCommand+.���� $ 
Horizontal=�$��20,0,0,0q�.+�  $
 User=�#��[ �� $��Tạo tài khoản��#��[ 	� -   $ 
btnYoutube��#��[  
 color6# [ .���� $ 
Horizontal=�.+�  $ Youtube=�#��[ �� $��Youtube��#��[ �� -   $ 
pnlYoutube��$ Vertical=�$y�	Collapsed=�.+�	� #��[ # [ ���� *ShowTangLuotXemViewCommand+.���� $ 
Horizontal=�$��20,0,0,0q�.+�  $ 	ChartLine=�#��[ �� $��Tăng lượt xem��#��[ 	� #��[ # [ ���� *ShowTangDangKyViewCommand+.���� $ 
Horizontal=�$��20,0,0,0q�.+�  $ ArrowUpRightDots=�#��[ �� $��Tăng lượt đăng ký��#��[ 	� -   $ btnFacebook��#��[  
 color7# [ .���� $ 
Horizontal=�.+�  $ Facebook=�#��[ �� $��Facebook��#��[ �� -   $ pnlFacebook��$ Vertical=�$y�	Collapsed=�.+�	� #��[ # [	 ���� *$"ShowTaoTaiKhoanFacebookViewCommand+.���� $ 
Horizontal=�$��20,0,0,0q�.+�  $
 User=�#��[ �� $��Tạo tại khoản��#��[ 	� #��[ # [	 ���� *ShowTangTheoDoiViewCommand+.���� $ 
Horizontal=�$��20,0,0,0q�.+�  $ ArrowUpRightDots=�#��[ �� $��Tăng lượt theo dõi��#��[ �� $ 	10,0,0,10��$��1������ $	 1,1&�$	 1,0.7&�.��� #
 [ $ 0Q��   secondaryBackColor2#
 [ $ 1Q�._��  � RowDefinitions �� $��25 ��� $��25 ��� $��* �.+��� -	   $ pnlControlBar��$��0��$ 
Horizontal=�$��RightToLeft=�
������ $��0,0,5,0q�.+��� -
    ��Name$ btnClose��  controlButton#��[ # [ .��  $ Xmark=�  controlButtonIcon#��[ �� -   $ btnMaximize��#��[ # [ .��  $ Square=�#��[ �� -   $ btnMinimize��#��[  
 color8# [ .��  $ WindowMinimize=�#��[ � $��1�� �� �� .+��� $��0��$ 
Horizontal=�$��Center=�.+�  $��20��$��20��   
Foreground# [ $��	35,0,10,0q� �� *Icon+�� #��[ $��16(�$��
Montserrat)�$��Medium"�$��Center=����� *	Caption+�� $��2��$��25q����� *CurrentChildView+