   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.MainWindowAdmin   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  localclr-namespace:Vista    � Title$    RESTAURANT SIGLO XXI��$	��648��$��1143.334��(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � 
ResizeMode$ NoResize=� � Icon$ Imagenes/logoFinal2 .png��   IconEdgeMode$ Aliased=� � WindowStartupLocation$ CenterScreen=�   TitleCharacterCasing$ Normal=�#��� ��   	GlowBrush
 �   �   NonActiveBorderBrush �	#FF0A0202	   WindowTransitionsEnabled	 .  $��2q�
   	TitleCaps
 .   � Cursor$ Arrow��   LeftWindowCommands +   %MahApps.Metro.Controls.WindowCommands  .@��� -   $��FacebookButton�� � ToolTip$ Facebook��.���� $��22��$��22������  �� RelativeSource ��  �� AncestorType$ ButtonL� �� Path$ 
Foreground� J� OpacityMask !�  j� Stretch$ Uniform=�   appbar_social_facebook !� Visual# [  �� -   $��TwitterButton��$ Twitter��.���� $��22��$��22������  �� $ ButtonL�$ 
Foreground� !� $ Uniform=�  appbar_twitter_bird# [ �� -   $��GoogleButton��$ 	Instagram��.���� $��22��$��22������  �� $ ButtonL�$ 
Foreground� !� $ Uniform=�  appbar_camera# [ ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF87A6DA�� � Offset$ 0Q�� $ 	#FFC6D6F2��$ 0.994Q�   RightWindowCommands   .@��� -   $��CerrarSesionButton��$ Cerrar Sesión��.���� $��22��$��22������  �� $ ButtonL�$ 
Foreground� !� $ Uniform=�  appbar_door_leave# [ .��� $��10,0,0,0q�.+��� -    ��Name$ image��$
��Left=�$	��620��$	��Top=�$
��1151��$��Imagenes/about-img.jpg��$��
-17,0,-6,0q�$
��Fill=� J� Opacity$	 0.4Q�$ Arrow��!   MahApps.Metro.Controls.Tile  -   $ Administrar Clientes��$��159,216,815,288q�$
��Auto��+   %MahApps.Metro.Controls.ControlsHelper   MouseOverBorderBrush �	#FFCB5F21$
��Auto�����	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FFCB5F21��   
BlurRadius$ 10Q�   ShadowDepth$ 8Q�.��� $	��102��.+��� -   $ image4��$��66��$	��Top=�$��Imagenes/User-Group.png��$
��36,0q�       Opacity$  0.795Q�$ 	#FF838383���� -   ! ��Name$! label3��$��Clientes��$��
37,70,37,3q�$��Center=�
�������$
��Bold"�$��14(�$��1q�$��29��" J� RenderTransformOrigin$" 0.5,0.5&�   $ 6Q�$	  0.8Q�$ 2Q�$ 	#FF838383���� -	   $! label��$��Bienvenido, Administrador��$��404,81,403,0q�$	��Top=�$
��Bold"�$��24(�  -
   $ Listar Clientes��$��378,216,596,288q�$
��Auto�� �	#FFCB5F21$
��Auto�����	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�   $ 	#FFCB5F21��$ 10Q�$ 8Q�.��� $	��112��.+��� -   $ image1��$��61��$	��Top=�$"��Imagenes/ListadoClientes.png��$��36,12,35.333,0q�   $  0.795Q�$ 	#FF838383���� -   $! label1��$��Listar Clientes��$��Center=�
�������$
��Bold"�$��14(�$��1q�$��29��$" 0.5,0.5&�$��23,79,23.333,4q�   $ 6Q�$	  0.8Q�$ 2Q�$ 	#FF838383��  -   $ Administrar Empleados��$��597,214,377,289q�$
��Auto�� �	#FFCB5F21$
��Auto�����	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�   $ 	#FFCB5F21��$ 10Q�$ 8Q�.��� $	��147��.+��� -   $ image2��$��72��$	��Top=�$��Center=�$��Imagenes/empleados.png��$
��10,0q�   $  0.795Q�$ 	#FF838383���� -   $! label2��$��	Empleados��$��36,64,28,-12.333q�$��Center=�
�������$
��Bold"�$��14(�$��1q�$" 0.5,0.5&�$��31��$	��Top=�   $ 6Q�$	  0.8Q�$ 2Q�$ 	#FF838383��  -   $ Listar Empleados��$��816,215,158,289q�$
��Auto�� �	#FFCB5F21$
��Auto�����	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�   $ 	#FFCB5F21��$ 10Q�$ 8Q�.��� $	��102��$	��144��.+��� -   $ image3��$��80��$	��Top=�$��Imagenes/employee.png��$��	27,0,28,0q�   $  0.795Q�$ 	#FF838383���� -   $! label4��$��Listar Empleados��$	��Top=�
�������$
��Bold"�$��14(�$��1q�$��29��$" 0.5,0.5&�$��
10,70,10,0q�   $ 6Q�$	  0.8Q�$ 2Q�$ 	#FF838383���� -   $ image2_Copy��$	��118��$��836,57,83,0q�$	��Top=�$��Imagenes/logoFinal3.png��  -   $ Administrar Platos��$��105,411,869,93q�$
��Auto�� �	#FFCB5F21$
��Auto�����	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�   $ 	#FFCB5F21��$ 10Q�$ 8Q�.��� $	��112��$	��140��.+��� -   $ image5��$��68��$	��Top=�$��Center=�$��Imagenes/Bowl.png��$��
36,10,22,0q�   $  0.795Q�$ 	#FF838383���� -   $! label5��$��Platos��$��
44,78,44,3q�$��Center=�
�������$
��Bold"�$��14(�$��1q�$" 0.5,0.5&�   $ 6Q�$	  0.8Q�$ 2Q�$ 	#FF838383��  -   $ Administrar Mesas��$��296,411,678,93q�$
��Auto�� �	#FFCB5F21$
��Auto�����	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�   $ 	#FFCB5F21��$ 10Q�$ 8Q�.��� $	��102��$	��157��.+��� -   $ image6��$��61��$	��Top=�$��Imagenes/mesa.png��$��
36,10,36,0q�   $  0.795Q�$ 	#FF838383���� -   $! label6��$��Mesas��$��52,74,52,-3q�$��Center=�
�������$
��Bold"�$��14(�$��1q�$" 0.5,0.5&�   $ 6Q�$	  0.8Q�$ 2Q�$ 	#FF838383��  -   $ Administrar Proveedor��$��675,410,299,94q�$
��Auto�� �	#FFCB5F21$
��Auto�����	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�   $ 	#FFCB5F21��$ 10Q�$ 8Q�.��� $	��112��.+��� -   $ image8��$��66��$	��Top=�$��Imagenes/Basket.png��$��
40,11,32,0q�   $  0.795Q�$ 	#FF838383���� -   $! label8��$	��Top=�$��	Proveedor��$��19,77,18.667,3q�$��Center=�
�������$
��Bold"�$��14(�$��1q�$" 0.5,0.5&�   $ 6Q�$	  0.8Q�$ 2Q�$ 	#FF838383��  -   $ Administrar Bebidas��$��868,410,106,94q�$
��Auto�� �	#FFCB5F21$
��Auto�����	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�   $ 	#FFCB5F21��$ 10Q�$ 8Q�.��� $	��102��$	��147��.+��� -   $ image9��$��66��$	��Top=�$#��Imagenes/Beverage-Alcohol.png��$��	38,5,34,0q�   $  0.795Q�$ 	#FF838383���� -   $! label9��$��Bebidas��$��
42,71,42,2q�$��Center=�
�������$
��Bold"�$��14(�$��1q�$��29��$" 0.5,0.5&�   $ 6Q�$	  0.8Q�$ 2Q�$ 	#FF838383��  -    $ Administrar Agenda��$��487,410,487,94q�$
��Auto�� �	#FFCB5F21$
��Auto�����	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�   $ 	#FFCB5F21��$ 10Q�$ 8Q�.��� $	��112��.+��� -!   $ image7��$��66��$	��Top=�$ ��Imagenes/Agenda-Blanco.png��$��36,11,35.667,0q�   $  0.795Q�$ 	#FF838383���� -"   $! label7��$	��Top=�$��Agenda��$��19,77,18.667,3q�$��Center=�
�������$
��Bold"�$��14(�$��1q�$" 0.5,0.5&�   $ 6Q�$	  0.8Q�$ 2Q�$ 	#FF838383��