   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5	   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5
   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5   	      Vista.WPFVerPedidosListos   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	   localclr-namespace:Vista  5   	   -   5        $��2q�5   	   
���   �  � Title$  Visualizar Pedidos��5   	   $��468.166��6$   $	��995��65   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � WindowStyle$ 
ToolWindow=�6Z   ���	#FFD2DBEC$
��Bold"�6�    � WindowStartupLocation$ CenterScreen=�6�    � Cursor$ Arrow��6�    � Icon$ Imagenes/LogoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6  .��5      � ���	#FFDBDFE3.+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��453��6:   $	��Top=�6G   $
��1002��6_   $��Imagenes/about-img.jpg��6l   $
��Fill=�6�   	 J� Opacity$		 0.3Q�6�   $��0,0,-16.667,-16.333q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 dgLista��5         
IsReadOnly . $��41,121,53,0q�66   $	��Top=�6K   $	��236��6c   $��Normal"�6p   ���	#FFCB5F21
���   � � 	Resources 5      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '        �� 5      "  6    5      P� 5       �@ 
IsSelected . . �5      ��  � �� �	#FFFAA5756;   �� 5       � ��
 �   �6;   5      5      5      5      �� 5    
   -   5         ��Name$ btnSalir��5        � ToolTip$ Salir��6#   $��Salir��63   $
��Left=�6C   $��777,377,0,0q�6^   $	��Top=�6s   $��77��6�   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  J� RenderTransformOrigin$ 1.662,0.727&�6�      AccentedSquareButtonStyle#��[  6  ���	#FFCB5F21$��12(�6^  �� 5!   
   -   5         ��Name$ 	gbFiltrar��5!      $��Filtrar Información��6&   $
��Left=�6C   $��	41,20,0,0q�6^   $	��Top=�6q   $��84��6�   $	��528��6�   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5"      � $
��Left=�6   $��70��6.   $��10,0,0,-3.333q�6:   $	��Top=�6Q   $	��557��6i   .+�5#      �� -   5         ��Name$ label��5#      $��Rut Cliente:��6'   $
��Left=�6>   $	��Top=�6Y   $��51,8,0,0q�6q   $	��113��6�   $��12(�6�   �� 5$      -   5         ��Name$ txtFiltroRut��5$      *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ej. 11222333-1��61   $
��Left=�6c   $��23��6~   $��
173,10,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��152��6�   $��Normal"�6�      ClearTextButton .  �� SelectionBrush �	#FFCB5F216  �� 5%      -   5        $ 	btnFiltro��5%      $  Filtrar por Rut de Cliente��6,   $��Filtrar��6R   $
��Left=�6d   $��360,10,0,32q�6   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6P  6^  5&      5'      �� 5(   
   -	   5        $ images��5(      $
��Left=�6    $	��101��6;   $��
757,10,0,0q�6H   $	��Top=�6\   $	��175��6t   $��Imagenes/logoFinal3.png��6�   �� 5)   
   -
   5        $ btnRefrescar��5)      $ 	Refrescar��6'   $
��Left=�6<   $��896,377,0,0q�6W   $	��Top=�6l   $��36��6�    / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  6�   $��36��6�   
���   ���5*      �� 5+       �� ImageSource$' !Imagenes/Command-Refresh-blue.png��6   5-      5/      50      