   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5	   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5
   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5   	      Vista.WPFReserva   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	   localclr-namespace:Vista  5   	   -   5        $��2q�5   	   
���   �  � Title$  Verificar Reserva��5   	   $��397.002��6#   $��844.813��64   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � WindowStyle$ 
ToolWindow=�6]   ���	#FFD2DBEC$
��Bold"�6�    � WindowStartupLocation$ CenterScreen=�6�    � Cursor$ Arrow��6�    � Icon$ Imagenes/LogoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6	  .��5      � ���	#FFDBDFE3.+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��384��6:   $	��Top=�6G   $	��852��6_   $��Imagenes/about-img.jpg��6k   $
��Fill=�6�   	 J� Opacity$		 0.3Q�6�   $��0,0,-16.667,-18q�6�   �� 5   
   -   5        
 ��Name$
 	gbFiltrar��5      $��Buscar Información��6&   $��41,21,42.333,31q�6B   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Upper=�6s   $��13.333(�6�   ���	#FFCB5F21.��5      � $
��Left=�6   $	��260��6.   $��10,4,0,0q�6;   $	��Top=�6M   $	��732��6e   .+�5      �� -   5        $ images��5      $
��Left=�6(   $��544,0,0,185q�6C   $	��164��6X   $��Imagenes/logoFinal3.png��6d   &   System.Windows.Controls.DataGrid  5      -   5          Name$ dgLista��5         
IsReadOnly . $��
10,80,21,0q�6>   $	��Top=�6R   $	��123��6j   $��Normal"�6w   ���	#FFCB5F21
���   � � 	Resources 5      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '        �� 5      "  6     5      P� 5   "    �@ 
IsSelected . . �5   &   ��  � �� �	#FFFAA5756C   �� 5   &    � ��
 �   �6C   5   #   5       5!      5"      �� 5#      -   5         ��Name$ btnSalir��5#       � ToolTip$ Cancelar��6+   $��Cancelar��6>   $
��Left=�6Q   $��
10,228,0,0q�6l   $	��Top=�6�   $��75��6�   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  J� RenderTransformOrigin$ 1.662,0.727&�6�      AccentedSquareButtonStyle#��[  6!  ���	#FFCB5F21$��12(�6k  �� 5$      -   5         ��Name$ label��5$      $��Código de Reserva:��6'   $
��Left=�6D   $	��Top=�6_   $��46,3,0,0q�6w   $	��123��6�   $��12(�6�   �� 5%      -   5         ��Name$ 	txtCodigo��5%      *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Código��6.   $
��Left=�6`   $��23��6{   $��	169,3,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��145��6�   $��Normal"�6�      ClearTextButton .  �� SelectionBrush �	#FFCB5F216  �� 5&      -	   5        $ 	btnCodigo��5&      $# Verificar Reserva por Código��6,   $��	Verificar��6S   $
��Left=�6g   $��339,3,0,232q�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6	  ���	#FFCB5F21$��12(�6S  6a  �� 5'      -
   5        $ 
label_Copy��5'      $��Rut Cliente:��6,   $
��Left=�6C   $	��Top=�6^   $��	46,36,0,0q�6v   $��93��6�   $��12(�6�   �� 5(      -   5        $ txtRut��5(      $ Ej. 11222333-1��6+   $
��Left=�6]   $��23��6x   $��
170,36,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��144��6�   $��Normal"�6�    .  �	#FFCB5F216  �� 5)      -   5        $ btnRut��5)      $* $Verificar Reserva por Rut de Cliente��6)   $��	Verificar��6Y   $
��Left=�6m   $��339,36,0,198q�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6Z  6h  �� 5+      -   5        $ btnRefrescar��5+      $ 	Refrescar��6/   $
��Left=�6C   $��675,226,0,-2q�6^   $	��Top=�6t   $��36��6�    / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  6�   $��36��6�   
���   ���5,      �� 5-       �� ImageSource$' !Imagenes/Command-Refresh-Blue.png��6%   5/      �� 50      -   5        $ 
btnIngreso��50      $" Notificar Ingreso de Cliente��6-   $��Notificar Ingreso��6U   $
��Left=�6q   $��525,228,0,0q�6�   $	��Top=�6�   $	��112��6�   $��Normal"�6�    . $ 1.662,0.727&�6#  #��[  6G  ���	#FFCB5F21$��12(�6�  �� 51      -   5        $ btnReservas��51      $ Verificar Reservas��6.   $��?��6K   $
��Left=�6W   $��426,3,0,232q�6r   $��25��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6�   ���	#FFCB5F21$��12(�6C  6Q  52      53      55      56      