   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5	   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5
   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5   	      Vista.WPFSalida   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	   localclr-namespace:Vista  5   	   -   5        $��2q�5   	   
���   �  � Title$!  Notificar Salida de Cliente��5   	   $��366.716��6-   $��627.341��6>   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � WindowStyle$ 
ToolWindow=�6g   ���	#FFD2DBEC$
��Bold"�6�    � WindowStartupLocation$ CenterScreen=�6�    � Cursor$ Arrow��6�    � Icon$ Imagenes/LogoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6  .��5      � ���	#FFDBDFE3.+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��346��6:   $	��Top=�6G   $	��627��6_   $��Imagenes/about-img.jpg��6k   $
��Fill=�6�   	 J� Opacity$		 0.3Q�6�   $��0,0,-9,-10.667q�6�   �� 5   
   -   5        
 ��Name$
 	gbFiltrar��5      $��Notificación��6&   $��41,10,43,18.333q�6<   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Upper=�6m   $��13.333(�6�   ���	#FFCB5F21.��5      � $
��Left=�6   $	��271��6.   $��0,4,0,-3q�6;   $	��Top=�6M   $	��524��6e   .+�5      �� -   5        $ images��5      $
��Left=�6(   $��408,0,0,221q�6C   $��91��6X   $��Imagenes/logoFinal3.png��6c   &   System.Windows.Controls.DataGrid  5      -   5          Name$ dgLista��5         
IsReadOnly . $��
10,55,25,0q�6>   $	��Top=�6R   $	��169��6j   $��Normal"�6w   ���	#FFCB5F21
���   � � 	Resources 5      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '        �� 5      "  6     5      P� 5   "    �@ 
IsSelected . . �5   &   ��  � �� �	#FFFAA5756C   �� 5   &    � ��
 �   �6C   5   #   5       5!      5"      �� 5#      -   5         ��Name$ btnSalir��5#       � ToolTip$ Cancelar��6+   $��Cancelar��6>   $
��Left=�6Q   $��
10,233,0,0q�6l   $	��Top=�6�   $��75��6�   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  J� RenderTransformOrigin$ 1.662,0.727&�6�      AccentedSquareButtonStyle#��[  6!  ���	#FFCB5F21$��12(�6k  �� 5$      -   5         ��Name$ label��5$      $��Número de Mesa:��6'   $
��Left=�6A   $	��Top=�6\   $��10,6,0,0q�6t   $	��118��6�   $��12(�6�   �� 5%      -   5         ��Name$ 	txtCodigo��5%      *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese N°��6.   $
��Left=�6\   $��23��6w   $��	126,6,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��99��6�   $��Normal"�6�      ClearTextButton .  �� SelectionBrush �	#FFCB5F216  �� 5&      -	   5        $ 	btnCodigo��5&      $ Verificar Número de Mesa��6,   $��	Verificar��6P   $
��Left=�6d   $��240,6,0,238q�6   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6P  6^  �� 5(      -
   5        $ btnRefrescar��5(      $ 	Refrescar��6/   $
��Left=�6D   $��461,229,0,0q�6_   $	��Top=�6t   $��36��6�    / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  6�   $��36��6�   
���   ���5)      �� 5*       �� ImageSource$' !Imagenes/Command-Refresh-Blue.png��6%   5,      �� 5-      -   5        $ 	btnSalida��5-      $! Notificar Salida de Cliente��6,   $��Notificar Salida��6S   $
��Left=�6n   $��321,233,0,0q�6�   $	��Top=�6�   $	��112��6�   $��Normal"�6�    . $ 1.662,0.727&�6   #��[  6D  ���	#FFCB5F21$��12(�6�  �� 5.      -   5        $ btnVer��5.      $ Ver Mesas Ocupadas��6)   $��?��6G   $
��Left=�6S   $��321,6,0,238q�6n   $��32��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6�   ���	#FFCB5F21$��12(�6?  6M  5/      50      52      53      