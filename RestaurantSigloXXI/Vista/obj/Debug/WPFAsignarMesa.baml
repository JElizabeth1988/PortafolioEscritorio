   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5	   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5
   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5   	      Vista.WPFAsignarMesa   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	   localclr-namespace:Vista  5   	   -   5        $��2q�5   	   
���   �  � Title$  Asignar Mesa��5   	   $��589.637��6   $��844.813��6/   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � WindowStyle$ 
ToolWindow=�6X   ���	#FFD2DBEC$
��Bold"�6�    � WindowStartupLocation$ CenterScreen=�6�    � Cursor$ Arrow��6�    � Icon$ Imagenes/LogoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6  .��5      � ���	#FFDBDFE3.+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��572��6:   $	��Top=�6G   $	��852��6_   $��Imagenes/about-img.jpg��6k   $
��Fill=�6�   	 J� Opacity$		 0.3Q�6�   $��0,0,-16.667,-13.333q�6�   �� 5   
   -   5        
 ��Name$
 	gbFiltrar��5      $��Buscar Información��6&   $��41,7,248.333,436q�6B   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Upper=�6t   $��13.333(�6�   ���	#FFCB5F21.��5      � $
��Left=�6   $��73��6.   $��10,4,0,-10.333q�6:   $	��Top=�6R   $	��596��6j   .+�5      �� -   5         ��Name$ 
label_Copy��5      $��Rut Cliente:��6,   $
��Left=�6C   $	��Top=�6^   $��-1,1,0,0q�6v   $��93��6�   $��12(�6�   �� 5      -   5         ��Name$ txtRut��5      *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ej. 11222333-1��6+   $
��Left=�6]   $��23��6x   $��81,1,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��128��6�   $��Normal"�6�      ClearTextButton .  �� SelectionBrush �	#FFCB5F216  �� 5      -   5         ��Name$ btnRut��5       � ToolTip$ Buscar Cliente��6)   $��Buscar��6B   $
��Left=�6S   $��
271,1,0,45q�6n   $��75��6�   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  J� RenderTransformOrigin$ 1.662,0.727&�6�      AccentedSquareButtonStyle#��[  6�   ���	#FFCB5F21$��12(�6>  6L  �� 5      -   5        $ label_Copy1��5      $��Nombre:��6-   $
��Left=�6?   $	��Top=�6Z   $��	-1,32,0,0q�6r   $��93��6�   $��12(�6�   �� 5      -   5        $ btnCrear��5      $ Crear Nuevo Registro��6+   $��Nuevo Cliente��6J   $
��Left=�6b   $��
362,1,0,45q�6}   $��98��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6M  6[  �� 5      -	   5        $ 	txtNombre��5      $  ��6.   {�.  $
��Left=�6d   $��23��6   $��	81,32,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��166��6�   $��Normal"�6�    �	#FFCB5F216�   �� 5      -
   5        $ 
btnLimpiar��5      $ Limpiar Casillas��6-   $��Limpiar��6H   $
��Left=�6Z   $��
385,33,0,0q�6u   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6  #��[  6,  ���	#FFCB5F21$��12(�6v  �� 5      -   5        $ btnPregunta��5      $ Ver Listado de Clientes��6.   $��?��6P   $
��Left=�6\   $��	229,1,0,0q�6w   $	��Top=�6�   $��33��6�   $��Normal"�6�   $��27��6�   $ Arrow��6�    . $ 1.662,0.727&�6  #��[  60  ���	#FFCB5F21$��12(�6z  6�  �� 5      -   5        $ 
lbl1_Copy2��5      $��*��6,   $
��Left=�69   $��	209,2,0,0q�6T   $	��Top=�6g   $��12(�6   ���	#FF9201016�   5      5      �� 5    
   -   5        $ images��5       $
��Left=�6    $��603,0,0,448q�6;   $	��156��6P   $��Imagenes/logoFinal3.png��6\   $��99��6}   $��Bottom=�6�   �� 5!   
   -   5        $
 GroupBox_mesas��5!      $��Mesas��6+   $��41,127,53.333,26q�6:   ���	#FFCB5F21$ Upper=�6l   $��13.333(�6�   ���	#FFCB5F21.��5"      � .+�5#      &   System.Windows.Controls.DataGrid  -   5          Name$ dgLista��5#         
IsReadOnly . $��24,40,23,49q�6>   $��Normal"�6S   6i   �� 5$      -   5        $ btnSalir��5$      $ Cancelar��6+   $��Cancelar��6>   $
��Left=�6Q   $��
24,335,0,0q�6l   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6!  ���	#FFCB5F21$��12(�6k  �� 5%      -   5        $ btnRefrescar��5%      $ 	Refrescar��6/   $
��Left=�6C   $	��Top=�6_   $��36��6w    / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  6�   $��36��6�   
���   �$��672,327,0,0q�6  ��5&      �� 5'       �� ImageSource$' !Imagenes/Command-Refresh-blue.png��6%   5)      �� 5*      -   5        $ 
btnAsignar��5*      $ Asignar mesa a cliente��6-   $��Asignar��6N   $
��Left=�6`   $��561,335,0,0q�6{   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6  #��[  63  ���	#FFCB5F21$��12(�6}  �� 5+      -   5        $ label_Copy2��5+      $��Asignación de Mesa:��6-   $
��Left=�6K   $	��Top=�6f   $��24,7,0,0q�6~   $	��131��6�   $��12(�6�   �� 5,      -   5        $ btnFiltrarAsignacion��5,      $$ Filtrar por asignacion de mesa��67   $��Filtrar��6`   $
��Left=�6r   $��	320,7,0,0q�6�   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6"  #��[  6F  ���	#FFCB5F21$��12(�6�  	� 5-      -   5         	�Name$ RbOnline��5-      $��Online��60   $
��Left=�6A   $��
156,11,0,0q�6\   $	��Top=�6p   $��66��6�   $
��Bold"�6�    	� 	GroupName$ 
Asignacion��6�    d� 	IsChecked$
 TrueY�6�   	� 5.      -   5        $ RbPresencial��5.      $��
Presencial��64   $
��Left=�6I   $��
227,11,0,0q�6d   $	��Top=�6x   $��89��6�   $
��Bold"�6�   $ 
Asignacion��6�   $
 TrueY�6�   5/      50      53      54      