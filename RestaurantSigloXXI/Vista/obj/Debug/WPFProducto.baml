   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5
   	      Vista.WPFProducto   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5	   	   localclr-namespace:Vista   5
   	   -   5        $��2q�5   	   
���   �  � Title$  Administrar Producto��5   	   $��648.311��6&   $��723.985��67    � WindowStartupLocation$ CenterScreen=�6G    � Cursor$ Arrow��6l   $
��Bold"�6{   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/logoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6�   ���	#FFDBDFE3.��5      � $
��Left=�6   $	��617��6&   $	��Top=�63   $	��714��6K   $��0,0,0,-1q�6W   .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��634��6:   $	��Top=�6G   $	��728��6_   $��Imagenes/about-img.jpg��6k   $
��Fill=�6�    J� Opacity$	 0.3Q�6�   $��0,0,-14,-17q�6�   �� 5   
   -   5        	 ��Name$	 groupBox��5      $��Información de Producto��6%   $��	22,3,20,0q�6F   $	��Top=�6Y   $	��256��6q   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5      � $
��Left=�6   $	��223��6.   $	��Top=�6;   $	��657��6S   $��0,-2,0,0q�6_   ��6q   Z� .+�5      �� -   5         ��Name$ 
label_Copy��5      $��
Valor ($):��6,   $
��Left=�6A   $��	27,78,0,0q�6\   $	��Top=�6o   $��12(�6�   �� 5      -   5        $ label_Copy1��5      $��Nombre Producto:��6-   $
��Left=�6H   $��27,4,0,0q�6c   $	��Top=�6u   $��12(�6�   �� 5      -   5        $ label_Copy2��5      $��Stock:��6-   $
��Left=�6>   $��
27,114,0,0q�6Y   $	��Top=�6m   $��12(�6�   �� 5      -   5         ��Name$ 
txtNomProd��5      $
��Left=�6.   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Nombre Producto��6I   $��8��6   $��	160,4,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��195��6�   $��Normal"�6�      ClearTextButton .  J� RenderTransformOrigin$ 0.5,0.5&�6   �� SelectionBrush �	#FFCB5F2162  �� 5      -   5        $ txtCantidad��5      $
��Left=�6/   $ Ingrese Cantidad��6g   $��8��6�   $��
160,41,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��134��6�   $��Normal"�6�    .  �	#FFCB5F216*  	� 5      -	   5         	�Name$
 RbKg��5      $	��Kg.��6,   $
��Left=�6:   $��
305,44,0,0q�6U   $	��Top=�6i   $��50��6�   $��Normal"�6�    	� 	GroupName$ UMedida��6�    d� 	IsChecked$
 TrueY�6�   $��10.667(�6�   	� 5      -
   5        $
 RbGr��5      $	��Gr.��6,   $
��Left=�6:   $��
351,44,0,0q�6U   $	��Top=�6i   $��41��6�   $��Normal"�6�   $ UMedida��6�   $��10.667(�6�   	� 5      -   5        $
 RbMl��5      $	��Ml.��6,   $
��Left=�6:   $��
392,44,0,0q�6U   $	��Top=�6i   $��43��6�   $��Normal"�6�   $ UMedida��6�   $��10.667(�6�   	� 5      -   5        $	 RbL��5      $��L.��6+   $
��Left=�68   $��
436,44,0,0q�6S   $	��Top=�6g   $��37��6   $��Normal"�6�   $ UMedida��6�   $��10.667(�6�   	� 5      -   5        $	 RbU��5      $��U.��6+   $
��Left=�68   $��
474,44,0,0q�6S   $	��Top=�6g   $��39��6   $��Normal"�6�   $ UMedida��6�   $��10.667(�6�   �� 5      -   5        $ txtValorUnidad��5      $
��Left=�62   $ Ingrese Valor (U)��6j   $��8��6�   $��
160,78,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��134��6�   $��Normal"�6�    .  �	#FFCB5F216.  �� 5      -   5        $ txtStock��5      $
��Left=�6,   $ Ingrese Stock��6G   $��8��6�   $��160,114,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��134��6�   $��Normal"�6�    .  �	#FFCB5F216%  �� 5      -   5         ��Name$ cboTipoProducto��5      $
��Left=�64   $��160,151,0,0q�6O   $	��Top=�6d   $	��196��6|   $��Normal"�6�   �� 5      -   5         ��Name$ 
btnGuardar��5       � ToolTip$ Guardar Registro��6-   $��Guardar��6H   $
��Left=�6Z   $��119,191,0,0q�6u   $	��Top=�6�   $��75��6�   $ Arrow��6�   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  . $ 1.662,0.727&�6"     AccentedSquareButtonStyle#��[  6F  ���	#FFCB5F21$��12(�6�  6�  �� 5       -   5        $ btnCancelar��5       $ Cancelar��6.   $��Cancelar��6A   $
��Left=�6T   $��495,191,0,0q�6o   $	��Top=�6�   $��75��6�   $��Normal"�6�   $ Arrow��6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6b  6p  �� 5!      -   5        $ 
btnLimpiar��5!      $ Limpiar Casillas��6-   $��Limpiar��6H   $
��Left=�6Z   $��
24,191,0,0q�6u   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6X  6f  �� 5"      -   5        $ btnModificar��5"      $ Actualizar Registro��6/   $��
Actualizar��6M   $
��Left=�6b   $��119,191,0,0q�6}   $	��Top=�6�   $ Arrow��6�   $��80��6�   $��Normal"�6�    . $ 1.662,0.727&�6  #��[  6'  ���	#FFCB5F21$��12(�6q  6  �� 5$      -   5        $ label_nom_tipo��5$      $��Tipo de Producto:��60   $
��Left=�6L   $��
27,151,0,0q�6g   $	��Top=�6{   $ 0.253,0.463&�6�   $��12(�6�   �� 5&      -   5        $ lblId��5&      $�� ��6'   $
��Left=�62   $��
387,10,0,0q�6M   $	��Top=�6a   $��12(�6y   $��18��6�   �� 5'      -   5        $ image1��5'      $
��Left=�6(   $��82��6C   $��
493,71,0,0q�6O   $	��Top=�6c   $	��130��6{   $��Imagenes/logoFinal3.png��6�   $ 1.091,0.822&�6�   �� 5(      -   5        $ label_Copy5��5(      $��Cantidad por Envase:��6-   $
��Left=�6L   $��	27,41,0,0q�6g   $	��Top=�6z   $��12(�6�   �� 5)      -   5        $ 
lbl1_Copy2��5)      $��*��6,   $
��Left=�69   $��	355,4,0,0q�6T   $	��Top=�6g   $��12(�6   ���	#FF9201016�   �� 5*      -   5        $ 	lbl1_Copy��5*      $��*��6+   $
��Left=�68   $��
292,41,0,0q�6S   $	��Top=�6g   $��12(�6   ���	#FF9201016�   �� 5+      -   5        $ 
lbl1_Copy1��5+      $��*��6,   $
��Left=�69   $��
294,78,0,0q�6T   $	��Top=�6h   $��12(�6�   ���	#FF9201016�   �� 5,      -   5        $ 
lbl1_Copy3��5,      $��*��6,   $
��Left=�69   $��294,114,0,0q�6T   $	��Top=�6i   $��12(�6�   ���	#FF9201016�   �� 5-      -   5        $ 
lbl1_Copy4��5-      $��*��6,   $
��Left=�69   $��361,151,0,0q�6T   $	��Top=�6i   $��12(�6�   ���	#FF9201016�   5/      50      �� 51   
   -   5        $	 	groupBox1��51      $��Respaldo Caché��6&   $
��Left=�6>   $��64��6Y   $��
22,524,0,0q�6e   $	��Top=�6y   $	��672��6�   ���	#FFCB5F21���	#FFCB5F21.��52      � $��0,0,0.333,-6.667q�6   .+�54      �� -   5        $ label2��54      $��Último Respaldo:��6(   $
��Left=�6C   $��47,1,0,10.667q�6^   $
��Bold"�6u   �� 55      -    5        $ lblCache��55      $�� ��6*   $
��Left=�65   $��161,1,0,10.667q�6P   $	��193��6h   �� 56      -!   5        $ btnCache��56      $ Recuperar Caché��6+   $��	Recuperar��6E   $
��Left=�6Y   $��	510,1,0,0q�6t   $	��Top=�6�   $��75��6�   #��[  6�   ���	#FFCB5F21$��12(�6  $��Normal"�6  $
 Normal=�6-  58      59      �� 5:   
   -"   5        $	 groupBox_Copy��5:      $��Listado de Productos��6*   $��22,264,20,0q�6H   $	��Top=�6]   $	��255��6u   ���	#FFCB5F21$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5;      � $
��Left=�6   $	��225��6.   $	��Top=�6;   $	��657��6S   $��	0,-2,0,-3q�6_   ��6r   Z� .+�5=      &   System.Windows.Controls.DataGrid  -#   5          Name$ dgLista��5=         
IsReadOnly . $
��Left=�6>   $��	10,33,0,0q�6Y   $	��Top=�6l   $	��147��6�   $	��637��6�   $��Normal"�6�   ���	#FFCB5F21
���   � � 	Resources 5?      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value  �� Property! �� Value��%�   '        �� 5@      "  6     5A      P� 5B   "    �@ 
IsSelected . . �5C   &   ��   � ��! �	#FFFAA5756C   �� 5D   &     � ��
! �   �6C   5E   #   5G      5H      5I      �� 5J      -$   5        $ btnRefrescar��5J      $ 	Refrescar��6/   $
��Left=�6C   $��34��6^    / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  6j   
���   �$��610,185,0,0q�6�   $��34��6�   $	��Top=�6   ��5K      �� 5L      " �� ImageSource$'" !Imagenes/Command-Refresh-blue.png��6%   5N      �� 5O      -%   5        $ btnEliminar��5O      $ Eliminar Registro��6.   $��Eliminar��6J   $
��Left=�6]   $��509,190,0,6q�6x   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6�   ���	#FFDF0D0D$��12(�6E  6S  �� 5P      -&   5        $ btnPasar��5P      $ Traspasar Información��6+   $��	Traspasar��6K   $
��Left=�6_   $	��Top=�6{   $��78��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6a  $��
10,190,0,0q�6o  $��29��6�  �� 5Q      -'   5        $ 
btnFiltrar��5Q      $" Filtrar por Tipo de Producto��6-   $��Filtrar��6T   $
��Left=�6f   $��	385,2,0,0q�6�   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6c  6q  �� 5R      -(   5        $ cboTipFiltro��5R      $
��Left=�61   $��	160,2,0,0q�6L   $	��Top=�6_   $	��196��6w   $��Normal"�6�   �� 5S      -)   5        $ label_nom_tipo_Copy��5S      $��Tipo de Producto:��65   $
��Left=�6Q   $��35,2,0,0q�6l   $	��Top=�6~   $ 0.253,0.463&�6�   $��12(�6�   5U      5V      5X      5Y      