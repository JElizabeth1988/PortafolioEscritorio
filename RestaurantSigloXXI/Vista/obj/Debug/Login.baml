   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5      V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5	   	      Vista.Login   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5      JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      localclr-namespace:Vista  5	   	     � Title$   ��5   	   $��414.562��6   $��530.536��6#   (   "MahApps.Metro.Controls.MetroWindow   TitleCharacterCasing$ Normal=�63      WindowTitleBrush
 �   � � Icon$ Imagenes/logoFinal2 .png��6j   $��0q�6�    � 
ResizeMode$ NoResize=�6�    � WindowStartupLocation$ CenterScreen=�6�   #��� ��6�      	GlowBrush
 �   �   NonActiveBorderBrush �	#FF0A0202   WindowTransitionsEnabled .  .��5      � ���	#FFDBDFE3	 � ColumnDefinitions	 5   
   �� 5      $
��151* �6   �� 5      $
��375* �6   .+�5   
   �� -   5        
 ��Name$
 image1��5       J� Opacity$	 0.5Q�6    $
��Left=�6.   $	��387��6I   $	��Top=�6V   $	��539��6n   $��0,0,-13.667,-0.333q�6z   $��Imagenes/about-img.jpg��6�   $��UniformToFill=�6�   $��2��6�   � 5   
   $
��Left=�6   $	��367��6*   $��	32,10,0,0q�67   $	��Top=�6J   $	��467��6b   $��2��6n   .+�5      �� -   5         ��Name$ 
txtUsuario��5      *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Nombre de Usuario��6*      ClearTextButton . $��23��6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   
���   �$��137,194,137,0q�6�   G� 5      -   5         G�Name$ TxtContrasenia��5      $ Ingrese Contraseña��62    . $
��Left=�6�   $��137,240,0,0q�6�   $	��Top=�6�   $	��194��6�   
���   �6�   �� 5      -   5        $
 image��5      $	��128��6#   $��163,47,164,0q�60   $	��Top=�6F   $!��Imagenes/Business-Man02.png��6^   $
��Fill=�6�   �� 5      -   5         ��Name$ btnLogin��5       � ToolTip$ Iniciar Sesion��6'   $��Ingresar��6@   $��196,289,196,0q�6S   $	��Top=�6j   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  J� RenderTransformOrigin$ 1.662,0.727&�6�      AccentedSquareButtonStyle#��[  6�   ���	#FFCB5F216  �� 5      -   5        $
 image2��5      $
��Left=�6$   $	��104��6?   $��	308,0,0,0q�6L   $	��Top=�6_   $	��149��6w   $��Imagenes/logoFinal3.png��6�   5      5      5      