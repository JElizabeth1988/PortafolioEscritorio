   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5	   	      Vista.WindowFinanza   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   localclr-namespace:Vista  5	   	     � Title$    RESTAURANT SIGLO XXI��5   	   $	��648��6)   $��1143.334��66   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � 
ResizeMode$ NoResize=�6a    � Icon$ imagenes/logoFinal2 .png��6w      IconEdgeMode$ Aliased=�6�    � WindowStartupLocation$ CenterScreen=�6�      TitleCharacterCasing$ Normal=�6�   #��� ��6�      	GlowBrush
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
   -   5        $ Aprobar Solicitud de Pago��5V      $��225,266,749,241q�6<   $
��Auto��6m   +   %MahApps.Metro.Controls.ControlsHelper   MouseOverBorderBrush �	#FFCB5F21$
��Auto��6�   ���	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�6   J� Effect 5X      3  -System.Windows.Media.Effects.DropShadowEffect  5Y         Color$ 	#FFCB5F21��6#      
BlurRadius$ 10Q�65      ShadowDepth$ 8Q�6E   .��5\      � $	��109��6   $	��149��6    .+�5]      �� -   5        $ image4��5]      $��74��6(   $	��Top=�64   $��Imagenes/codigo.png��6L   $��
33,13,33,0q�6i    5^        5_          Opacity$  0.795Q�6+   $ 	#FF838383��6;   5a      �� 5b      -   5        ! ��Name$! label3��5b      $��Solicitud de Pago��6(   $��
10,73,10,0q�6D   $��Center=�6X   
�������$
��Bold"�6�   $��14(�6�   $��1q�6�   " J� RenderTransformOrigin$" 0.5,0.5&�6�   $	��129��6�    5c        5d      $ 6Q�6+   $	  0.8Q�6:   $ 2Q�6H   $ 	#FF838383��6X   5f      5h      5i      �� 5j   
   -	   5        $! label��5j      $(��"Bienvenido, Enacragado de Finanzas��6   $��346,82,347,0q�6L   $	��Top=�6b   $
��Bold"�6z   $��24(�6�     5k   
   -
   5        $ Administrar Pagos��5k      $��487,266,487,241q�64   $
��Auto��6a    �	#FFCB5F21$
��Auto��6�   ���	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�6�    5m        5n      $ 	#FFCB5F21��6#   $ 10Q�65   $ 8Q�6E   .��5q      � $	��109��6   $	��154��6    .+�5r      �� -   5        $ image1��5r      $��66��6(   $	��Top=�64   $$��Imagenes/Money-Credit-Card.png��6L   $��
38,11,38,0q�6t    5s        5t      $  0.795Q�6+   $ 	#FF838383��6;   5v      �� 5w      -   5        $! label1��5w      $��Pagos��6(   
�������$
��Bold"�6K   $��14(�6]   $��1q�6k   $" 0.5,0.5&�6   $��
51,74,51,0q�6�    5x        5y      $ 6Q�6+   $	  0.8Q�6:   $ 2Q�6H   $ 	#FF838383��6X   5{      5}      5~      �� 5   
   -   5        $ image2��5      $	��118��6    $��844,82,75,0q�6-   $	��Top=�6B   $��Imagenes/logoFinal3.png��6Z     5�   
   -   5        $ Ver Utilidades��5�      $��748,266,226,241q�61   $
��Auto��6_    �	#FFCB5F21$
��Auto��6�   ���	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�6�    5�        5�      $ 	#FFCB5F21��6#   $ 10Q�65   $ 8Q�6E   .��5�      � $	��109��6   $	��154��6    .+�5�      �� -   5        $ image3��5�      $��77��6(   $	��Top=�64   $��Imagenes/boleta.png��6L   $��	31,6,32,0q�6i    5�        5�      $  0.795Q�6+   $ 	#FF838383��6;   5�      �� 5�      -   5        $! label2��5�      $��
Utilidades��6(   
�������$
��Bold"�6P   $��14(�6b   $��1q�6p   $" 0.5,0.5&�6�   $��
40,77,32,0q�6�    5�        5�      $ 6Q�6+   $	  0.8Q�6:   $ 2Q�6H   $ 	#FF838383��6X   5�      5�      5�      5�      5�      