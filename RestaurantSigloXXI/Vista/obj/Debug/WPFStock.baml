   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5
   	      Vista.WPFStock   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5	   	   localclr-namespace:Vista   5
   	   $��2q�5   	   
���   �  � Title$#  Administrar Stock de Producto��5   	   $��408.311��6/   $��718.985��6@    � WindowStartupLocation$ CenterScreen=�6P    � Cursor$ Arrow��6u   $
��Bold"�6�   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/logoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6�   ���	#FFDBDFE3.��5      � $
��Left=�6   $	��377��6&   $	��Top=�63   $	��709��6K   $��0,0,0,-1q�6W   .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��393��6:   $	��Top=�6G   $	��720��6_   $��Imagenes/about-img.jpg��6k   $
��Fill=�6�    J� Opacity$	 0.5Q�6�   $��0,0,-11,-16q�6�   !   MahApps.Metro.Controls.Tile  5   
   -   5        	 � ToolTip$$	 Administrar Stock de Productos��5      $��80,124,479,143q�6<   $
��Auto��6l   +   %MahApps.Metro.Controls.ControlsHelper
   MouseOverBorderBrush
 �	#FFCB5F21$
��Auto��6�   ���	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�6   J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FFCB5F21��6#      
BlurRadius$ 10Q�65      ShadowDepth$ 8Q�6E   .��5      � $	��110��6   $	��140��6    .+�5      �� -   5        $ image1��5      $��66��6(   $	��Top=�64   $��Imagenes/Product.png��6L   $��
37,12,38,0q�6j    5        5         Opacity$ 0.795Q�6+   $ 	#FF838383��6;   5      �� 5      -   5         ��Name$ label1��5      $��	Productos��6(   $��Center=�6=   
�������$
��Bold"�6m   $��14(�6   $��1q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��
32,76,30,0q�6�   $��34��6�   $	��Top=�6�   $��78��6�    5        5      $ 6Q�6+   $	 0.8Q�6:   $ 2Q�6H   $ 	#FF838383��6X   5      5!      5"        5#   
   -   5        $!	 Administrar Stock de Platos��5#      $��279,123,279,143q�69   $
��Auto��6g   
 �	#FFCB5F21$
��Auto��6�   ���	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�6�    5%        5&      $ 	#FFCB5F21��6#   $ 10Q�65   $ 8Q�6E   .��5(      � $	��110��6   $	��140��6    .+�5)      �� -   5        $ image2��5)      $��76��6(   $	��Top=�64   $��Imagenes/Soup-01.png��6L   $��	31,4,30,0q�6j    5*        5+      $ 0.795Q�6+   $ 	#FF838383��6;   5-      �� 5.      -   5        $ label2��5.      $��Platos��6(   $��Center=�6:   
�������$
��Bold"�6j   $��14(�6|   $��1q�6�   $ 0.5,0.5&�6�   $��
41,76,34,0q�6�   $��34��6�   $	��Top=�6�   $��65��6�    5/        50      $ 6Q�6+   $	 0.8Q�6:   $ 2Q�6H   $ 	#FF838383��6X   52      54      55        56   
   -   5        $"	 Administrar Stock de Bebidas��56      $��476,123,81,143q�6:   $
��Auto��6h   
 �	#FFCB5F21$
��Auto��6�   ���	#FFCB5F21���	#FFCB5F21���	#FF040100$
 0.85Q�6�    58        59      $ 	#FFCB5F21��6#   $ 10Q�65   $ 8Q�6E   .��5;      � $	��110��6   $	��140��6    .+�5<      �� -	   5        $ image3��5<      $��68��6(   $	��Top=�64   $$��Imagenes/Beverage-Juice-01.png��6L   $��	45,8,30,0q�6t    5=        5>      $ 0.795Q�6+   $ 	#FF838383��6;   5@      �� 5A      -
   5        $ label3��5A      $��Bebidas��6(   $��Center=�6;   
�������$
��Bold"�6k   $��14(�6}   $��1q�6�   $ 0.5,0.5&�6�   $��
45,76,30,0q�6�   $��34��6�   $	��Top=�6�   $��65��6�    5B        5C      $ 6Q�6+   $	 0.8Q�6:   $ 2Q�6H   $ 	#FF838383��6X   5E      5G      5H      �� 5I   
   -   5        $ image4��5I      $
��Left=�6    $	��100��6;   $��
513,10,0,0q�6H   $	��Top=�6\   $	��170��6t   $��Imagenes/logoFinal3.png��6�   5K      5L      