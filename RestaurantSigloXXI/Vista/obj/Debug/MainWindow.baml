   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5	   	      Vista.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   localclr-namespace:Vista  5	   	     � Title$   ��5   	   $	��648��6   $��1143.334��6    (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � 
ResizeMode$ NoResize=�6K    � Icon$ imagenes/logoFinal.png��6a    � WindowStartupLocation$ CenterScreen=�6      TitleCharacterCasing$ Normal=�6�   #��� ��6�      	GlowBrush
 �   �   NonActiveBorderBrush �	#FF0A0202   WindowTransitionsEnabled .  $��0q�6i  ��5      �� 5   
   	 �� EndPoint$	 0.5,1&�6   
 �� 
StartPoint$
 0.5,0&�6/   .��5      �  � Color$ 	#FF87A6DA��6    � Offset$ 0Q�6-   � 5      $ 	#FFC6D6F2��6   $ 0.994Q�6-   5      .��5      � $��10,0,0,0q�6   .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��620��6:   $	��Top=�6G   $
��1151��6_   $��imagenes/logoFinal.png��6l   $��
-17,0,-6,0q�6�   !   MahApps.Metro.Controls.Tile  5   
   -   5        $��17,10,972,565q�5      $
��Auto��6/   $
��Auto��6=   #��� ��6a   $��1q�6�   /   )MahApps.Metro.Controls.ScrollViewerHelper%   IsHorizontalScrollWheelEnabled .    KeepDragging .   � ForceCursor . ��6J   Z� +   %MahApps.Metro.Controls.ControlsHelper   MouseOverBorderBrush 5      �� 5      $	 0.5,1&�6&   $
 0.5,0&�67   .��5      � $ Black��6#   $ 0Q�61   � 5      $ 	#FF040528��6#   $ 1Q�65   5      .��5      � $	��142��6   .+�5       �� -   5        $ image1��5       $��7,6,99,10.333q�6(   $��Imagenes/Logout.png��6?   �� 5!      -   5         ��Name$ label��5!      $��Cerrar Sesión��6'   $
��Left=�6?   $��33,4,0,0q�6Z   $	��Top=�6l   $
��Bold"�6�   $��14.667(�6�   5"      5#        5$   
   -   5        $��175,175,843,217q�5$      $
��Auto��6O    �	#FF11233F$
��Auto��6�    J� Effect 5%      3  -System.Windows.Media.Effects.DropShadowEffect  5&         
BlurRadius$ 6Q�6#      Color$ 	#FF11233F��62   ��5(      �� 5)      $	 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67   $	
 0,0&�6[   .��5*      � $ 	#FF00FFC9��6#   $ 1Q�65   � 5+      $ 	#FF0F00FF��6#   � 5,      $ 	#FF059EDD��6#   $ 0.636Q�65   � 5-      $ 	#FF0863E9��6#   $ 0.336Q�65   5.      .��50      � $	��228��6   $	��110��6    .+�51      �� -   5        $ image4��51      $
��Left=�6(   $��82��6C   $��	21,50,0,0q�6O   $	��Top=�6b   $��75��6z   $��imagenes/logoFinal.png��6�    52        53         Opacity$	 0.8Q�6+   55      �� 56      -   5        $ label3��56      $��Administrar 
   Clientes��6(   $
��Left=�6O   $��	9,145,0,0q�6j   $	��Top=�6}   
�������$
��Bold"�6�   $��14(�6�   $��1q�6�    57        58      $ 6Q�6+   $	 0.9Q�6:      ShadowDepth$ 2Q�6H   5:      5<      5=      5A      5C      