   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5	   	      Vista.WindowBodega   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   localclr-namespace:Vista  5	   	     � Title$    RESTAURANT SIGLO XXI��5   	   $	��648��6)   $��1143.334��66   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � 
ResizeMode$ NoResize=�6a    � Icon$ Imagenes/logoFinal2 .png��6w      IconEdgeMode$ Aliased=�6�    � WindowStartupLocation$ CenterScreen=�6�      TitleCharacterCasing$ Normal=�6�   #��� ��6�      	GlowBrush
 �   �   NonActiveBorderBrush �	#FF0A0202	   WindowTransitionsEnabled	 .  $��2q�6�  
   	TitleCaps
 .   � Cursor$ Arrow��6�     LeftWindowCommands 5      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� -   5        $��FacebookButton��5   (    � ToolTip$ Facebook��6   .��5      �� $��22��6   $��22��6'   ��63   ��  �� RelativeSource ��  �� AncestorType$ ButtonL� �� Path$ 
Foreground� J� OpacityMask 5      !� 5       j� Stretch$ Uniform=�6&      appbar_social_facebook !� Visual# [  5   &   5      5      �� 5      -   5        $��TwitterButton��5   '   $ Twitter��6   .��5      �� $��22��6   $��22��6'   ��63   ��  �� $ ButtonL�$ 
Foreground� 5      !� 5      $ Uniform=�6&     appbar_twitter_bird# [ 5   &   5!      5"      �� 5%      -   5        $��GoogleButton��5%   *   $ 	Instagram��6   .��5'      �� $��22��6   $��22��6(   ��64   ��  �� $ ButtonL�$ 
Foreground� 5(      !� 5)      $ Uniform=�6&     appbar_camera# [ 5*   &   5-      5.      5/      ��52      �� 53   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��54      �  � Color$ 	#FF87A6DA��6    � Offset$ 0Q�6-   � 55      $ 	#FFC6D6F2��6   $ 0.994Q�6-   56         RightWindowCommands 59        5:   
   .@�5<      �� -   5        $��CerrarSesionButton��5<   -   $ Cerrar Sesión��6   .��5=      �� $��22��6   $��22��6'   ��63   ��  �� $ ButtonL�$ 
Foreground� 5>      !� 5?      $ Uniform=�6&     appbar_door_leave# [ 5@   &   5B      5C      5N      .��5Q      � $��10,0,0,0q�6   .+�5S   
   �� -   5         ��Name$ image��5S      $
��Left=�6   $	��620��6:   $	��Top=�6G   $
��1151��6_   $��Imagenes/about-img.jpg��6l   $��
-17,0,-6,0q�6�   $
��Fill=�6�    J� Opacity$	 0.4Q�6�   $ Arrow��6�   !   MahApps.Metro.Controls.Tile  5V   
   -   5        $ Administrar Productos��5V      $��174,240,800,266q�68   $
��Auto��6i   +   %MahApps.Metro.Controls.ControlsHelper   MouseOverBorderBrush �	#FFCB5F21$
��Auto��6�   ���	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�6   J� Effect 5W      3  -System.Windows.Media.Effects.DropShadowEffect  5X         Color$ 	#FFCB5F21��6#      
BlurRadius$ 10Q�65      ShadowDepth$ 8Q�6E   .��5[      � $	��110��6   .+�5\      �� -   5        $ image4��5\      $��67��6(   $	��Top=�64   $��Imagenes/producto.png��6L   $��35,14,36.667,0q�6k    5]        5^          Opacity$  1Q�6+   $ 	#FF838383��67   $ 30Q�6I   !   RenderingBias$! Quality=�6Y   5`      �� 5a      -   5        " ��Name$" label3��5a      $��	Productos��6(   $��35,77,34.667,0q�6<   $��Center=�6T   
�������$
��Bold"�6�   $��14(�6�   $��1q�6�   # J� RenderTransformOrigin$# 0.5,0.5&�6�   $��33��6�   $	��Top=�6�    5b        5c      $ 6Q�6+   $	  0.8Q�6:   $ 2Q�6H   $ 	#FF838383��6X   5e      5g      5h      �� 5i   
   -	   5        $" label��5i      $%��Bienvenido, Encargado de Bodega��6   $��357,82,358,0q�6I   $	��Top=�6_   $
��Bold"�6w   $��24(�6�     5j   
   -
   5        $ Controlar Stock��5j      $��379,241,595,265q�62   $
��Auto��6_    �	#FFCB5F21$
��Auto��6�   ���	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�6�    5l        5m      $ 	#FFCB5F21��6#   $ 10Q�65   $ 8Q�6E   .��5o      � $	��110��6   $	��140��6    .+�5p      �� -   5        $ image1��5p      $��66��6(   $	��Top=�64   $"��Imagenes/listadoProducto.png��6L   $��
45,10,30,0q�6r    5q        5r      $  0.795Q�6+   $ 	#FF838383��6;   5t      �� 5u      -   5        $" label1��5u      $��Stock��6(   $��Center=�69   
�������$
��Bold"�6i   $��14(�6{   $��1q�6�   $# 0.5,0.5&�6�   $��
46,76,46,0q�6�   $��34��6�   $	��Top=�6�    5v        5w      $ 6Q�6+   $	  0.8Q�6:   $ 2Q�6H   $ 	#FF838383��6X   5y      5{      5|        5}   
   -   5        $ Administrar Recetas��5}      $��799,240,175,266q�66   $
��Auto��6e    �	#FFCB5F21$
��Auto��6�   ���	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�6    5        5�      $ 	#FFCB5F21��6#   $ 10Q�65   $ 8Q�6E   .��5�      � $	��100��6   $	��140��6    .+�5�      �� -   5        $ image2��5�      $��60��6(   $	��Top=�64   $��Imagenes/receta.png��6L   $��
30,10,31,0q�6i    5�        5�      $  0.795Q�6+   $ 	#FF838383��6;   5�      �� 5�      -   5        $" label2��5�      $��Recetas��6(   $��
39,69,39,2q�6:   $��Center=�6N   
�������$
��Bold"�6~   $��14(�6�   $��1q�6�   $# 0.5,0.5&�6�    5�        5�      $ 6Q�6+   $	  0.8Q�6:   $ 2Q�6H   $ 	#FF838383��6X   5�      5�      5�      �� 5�   
   -   5        $ image2_Copy��5�      $
��Left=�6%   $	��118��6@   $��
845,51,0,0q�6M   $	��Top=�6a   $	��205��6y   $��Imagenes/logoFinal3.png��6�     5�   
   -   5        $! Calcular Pedido a Proveedor��5�      $��595,241,379,265q�6>   $
��Auto��6l    �	#FFCB5F21$
��Auto��6�   ���	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�6   5�        5�      $ 	#FFCB5F21��6#   $ 10Q�65   $ 8Q�6E   .��5�      � $	��110��6   $	��140��6    .+�5�      �� -   5        $ image3��5�      $��66��6(   $	��Top=�64   $��Imagenes/LISTADO2.png��6L   $��
37,10,38,0q�6k    5�        5�      $  0.795Q�6+   $ 	#FF838383��6;   5�      �� 5�      -   5        $" label4��5�      $��Calcular pedido��6(   $��Center=�6C   
�������$
��Bold"�6s   $��14(�6�   $��1q�6�   $# 0.5,0.5&�6�   $��
10,76,10,0q�6�   $��34��6�   $	��Top=�6�   $	��120��6�    5�        5�      $ 6Q�6+   $	  0.8Q�6:   $ 2Q�6H   $ 	#FF838383��6X   5�      5�      5�      5�      5�      