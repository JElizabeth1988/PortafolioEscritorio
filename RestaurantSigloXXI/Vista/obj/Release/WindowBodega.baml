   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WindowBodega   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
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
��Fill=� J� Opacity$	 0.4Q�$ Arrow��!   MahApps.Metro.Controls.Tile  -   $ Administrar Productos��$��174,240,800,266q�$
��Auto��+   %MahApps.Metro.Controls.ControlsHelper   MouseOverBorderBrush �	#FFCB5F21$
��Auto�����	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FFCB5F21��   
BlurRadius$ 10Q�   ShadowDepth$ 8Q�.��� $	��110��.+��� -   $ image4��$��67��$	��Top=�$��Imagenes/producto.png��$��35,14,36.667,0q�       Opacity$  1Q�$ 	#FF838383��$ 30Q�!   RenderingBias$! Quality=��� -   " ��Name$" label3��$��	Productos��$��35,77,34.667,0q�$��Center=�
�������$
��Bold"�$��14(�$��1q�# J� RenderTransformOrigin$# 0.5,0.5&�$��33��$	��Top=�   $ 6Q�$	  0.8Q�$ 2Q�$ 	#FF838383���� -	   $" label��$%��Bienvenido, Encargado de Bodega��$��357,82,358,0q�$	��Top=�$
��Bold"�$��24(�  -
   $ Controlar Stock��$��379,241,595,265q�$
��Auto�� �	#FFCB5F21$
��Auto�����	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�   $ 	#FFCB5F21��$ 10Q�$ 8Q�.��� $	��110��$	��140��.+��� -   $ image1��$��66��$	��Top=�$"��Imagenes/listadoProducto.png��$��
45,10,30,0q�   $  0.795Q�$ 	#FF838383���� -   $" label1��$��Stock��$��Center=�
�������$
��Bold"�$��14(�$��1q�$# 0.5,0.5&�$��
46,76,46,0q�$��34��$	��Top=�   $ 6Q�$	  0.8Q�$ 2Q�$ 	#FF838383��  -   $ Administrar Recetas��$��799,240,175,266q�$
��Auto�� �	#FFCB5F21$
��Auto�����	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�   $ 	#FFCB5F21��$ 10Q�$ 8Q�.��� $	��100��$	��140��.+��� -   $ image2��$��60��$	��Top=�$��Imagenes/receta.png��$��
30,10,31,0q�   $  0.795Q�$ 	#FF838383���� -   $" label2��$��Recetas��$��
39,69,39,2q�$��Center=�
�������$
��Bold"�$��14(�$��1q�$# 0.5,0.5&�   $ 6Q�$	  0.8Q�$ 2Q�$ 	#FF838383���� -   $ image2_Copy��$
��Left=�$	��118��$��
845,51,0,0q�$	��Top=�$	��205��$��Imagenes/logoFinal3.png��  -   $! Calcular Pedido a Proveedor��$��595,241,379,265q�$
��Auto�� �	#FFCB5F21$
��Auto�����	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�   $ 	#FFCB5F21��$ 10Q�$ 8Q�.��� $	��110��$	��140��.+��� -   $ image3��$��66��$	��Top=�$��Imagenes/LISTADO2.png��$��
37,10,38,0q�   $  0.795Q�$ 	#FF838383���� -   $" label4��$��Calcular pedido��$��Center=�
�������$
��Bold"�$��14(�$��1q�$# 0.5,0.5&�$��
10,76,10,0q�$��34��$	��Top=�$	��120��   $ 6Q�$	  0.8Q�$ 2Q�$ 	#FF838383��