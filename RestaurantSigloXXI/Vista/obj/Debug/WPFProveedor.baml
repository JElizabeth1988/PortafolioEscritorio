   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5
   	      Vista.WPFProveedor   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5	   	   localclr-namespace:Vista   5
   	   -   5        $��2q�5   	   
���   �  � Title$  Administrar Proveedor��5   	   $��662.312��6'   $��740.651��68    � WindowStartupLocation$ CenterScreen=�6H    � Cursor$ Arrow��6m   $
��Bold"�6|   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6�   ���	#FFDBDFE3.��5      � $
��Left=�6   $	��630��6&   $	��Top=�63   $	��731��6K   .+�5   
   �� -   5         ��Name$ image��5      $	��639��6   $	��Top=�6,   $��Imagenes/about-img.jpg��6D   $
��Fill=�6d    J� Opacity$	 0.3Q�6s   $��
0,0,-13,-9q�6�   $
��Left=�6�   $	��744��6�   �� 5   
   -   5        	 ��Name$	 groupBox��5      $��Información de Proveedor��6%   $��
49,12,51,0q�6G   $	��Top=�6[   $	��237��6s   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�6�   ���	#FFCB5F21.��5      � $
��Left=�6   $	��208��6.   $	��Top=�6;   $	��621��6S   $��0,-2,-0.333,-3.333q�6_   ��6{   Z� .+�5      �� -   5         ��Name$ 
label_Copy��5      $��
Sitio Web:��6,   $
��Left=�6A   $��
23,127,0,0q�6\   $	��Top=�6p   $��12(�6�   �� 5      -   5        $ label_Copy3��5      $��
Teléfono:��6-   $
��Left=�6A   $��	23,65,0,0q�6\   $	��Top=�6o   $��12(�6�   �� 5      -   5         ��Name$ 	txtNombre��5      $
��Left=�6-   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Nombre��6I   $��8��6v   $��	166,3,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��174��6�   $��Normal"�6�      ClearTextButton .  �� SelectionBrush �	#FFCB5F216	  �� 5      -   5        $ txtTelefono��5      $
��Left=�6/   $ Ej: 999888777��6J   $��8��6v   $��
166,65,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��125��6�   $��Normal"�6�    .  �	#FFCB5F216'  �� 5      -   5        $ 	txtCorreo��5      $
��Left=�6-   $ Ingrese Email��6H   $��8��6t   $��
166,34,0,0q�6   $
 Wrap=�6�   $	��Top=�6�   $	��232��6�   $��Normal"�6�    .  J� RenderTransformOrigin$ 0.5,0.5&�6   �	#FFCB5F216(  �� 5      -	   5         ��Name$ 
btnGuardar��5       � ToolTip$ Guardar Registro��6-   $��Guardar��6H   $
��Left=�6Z   $��132,172,0,0q�6u   $	��Top=�6�   $��75��6�   $ Arrow��6�   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  . $ 1.662,0.727&�6"     AccentedSquareButtonStyle#��[  6F  ���	#FFCB5F21$��12(�6�  6�  �� 5      -
   5        $ btnCancelar��5      $ Cancelar��6.   $��Cancelar��6B   $
��Left=�6U   $��508,172,0,0q�6p   $	��Top=�6�   $��75��6�   $��Normal"�6�   $ Arrow��6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6c  6q  �� 5      -   5        $ 
btnLimpiar��5      $ Limpiar Casillas��6-   $��Limpiar��6H   $
��Left=�6Z   $��
27,172,0,0q�6u   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6X  6f  �� 5      -   5        $ image1��5      $
��Left=�6(   $��78��6C   $��
440,10,0,0q�6O   $	��Top=�6c   $	��156��6{   $��Imagenes/logoFinal3.png��6�   $ 1.091,0.822&�6�   �� 5      -   5        $ label_Copy5��5      $��Dirección:��6-   $
��Left=�6B   $��	23,96,0,0q�6]   $	��Top=�6p   $��12(�6�   �� 5      -   5        $ btnModificar��5      $ Actualizar Registro��6/   $��
Actualizar��6M   $
��Left=�6b   $��132,172,0,0q�6}   $	��Top=�6�   $ Arrow��6�   $��80��6�   $��Normal"�6�    . $ 1.662,0.727&�6  #��[  6'  ���	#FFCB5F21$��12(�6q  6  �� 5      -   5        $ LblId��5      $�� ��6'   $y�Hidden=�62   $
��Left=�6F   $��	388,0,0,0q�6a   $	��Top=�6t   $��12(�6�   �� 5       -   5        $ label_Copy1��5       $��Correo Electrónico:��6-   $
��Left=�6K   $��	23,34,0,0q�6f   $	��Top=�6y   $��12(�6�   �� 5!      -   5        $ label_Copy2��5!      $��Nombre:��6-   $
��Left=�6?   $��27,3,0,0q�6Z   $	��Top=�6l   $��12(�6�   �� 5"      -   5        $ txtDireccion��5"      $
��Left=�60   $ Ingrese Dirección��6K   $��8��6{   $��
166,96,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��232��6�   $��Normal"�6�    . $ 0.5,0.5&�6   �	#FFCB5F216/  �� 5#      -   5        $ txtWeb��5#      $
��Left=�6*   $ Ingrese Sitio Web��6E   $��8��6u   $��166,127,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��174��6�   $��Normal"�6�    . $ 0.5,0.5&�6
   �	#FFCB5F216*  �� 5$      -   5        $ 
lbl1_Copy2��5$      $��*��6,   $
��Left=�69   $��	340,3,0,0q�6T   $	��Top=�6g   $��12(�6   ���	#FF9201016�   �� 5%      -   5        $ 	lbl1_Copy��5%      $��*��6+   $
��Left=�68   $��
398,34,0,0q�6S   $	��Top=�6g   $��12(�6   ���	#FF9201016�   �� 5&      -   5        $ 
lbl1_Copy1��5&      $��*��6,   $
��Left=�69   $��
291,65,0,0q�6T   $	��Top=�6h   $��12(�6�   ���	#FF9201016�   5(      5)      �� 5*   
   -   5        $	 	groupBox1��5*      $��Respaldo Caché��6&   $
��Left=�6>   $��69��6Y   $��
49,536,0,0q�6e   $	��Top=�6y   $	��631��6�   ���	#FFCB5F21���	#FFCB5F21.��5+      � .+�5,      �� -   5        $ label2��5,      $��Último Respaldo:��6(   $
��Left=�6C   $��23,1,0,0q�6^   $	��Top=�6p   $
��Bold"�6�   �� 5-      -   5        $ lblCache��5-      $�� ��6*   $
��Left=�65   $��	130,0,0,0q�6P   $	��Top=�6c   $	��215��6{   �� 5.      -   5        $ btnCache��5.      $ Recuperar Caché��6+   $��	Recuperar��6E   $
��Left=�6Y   $��	454,1,0,0q�6t   $	��Top=�6�   $��78��6�   #��[  6�   ���	#FFCB5F21$��12(�6  $��Normal"�6  $
 Normal=�6-  50      51      �� 52   
   -   5        $	 groupBox_Copy��52      $��Listado de Proveedores��6*   $��49,254,51,0q�6J   $	��Top=�6_   $	��277��6w   ���	#FFCB5F21$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��53      � $
��Left=�6   $	��250��6.   $	��Top=�6;   $	��621��6S   $��0,-2,-0.333,-6.667q�6_   ��6{   Z� .+�55      &   System.Windows.Controls.DataGrid  -   5          Name$ dgLista��55         
IsReadOnly . $
��Left=�6>   $��	18,10,0,0q�6Y   $	��Top=�6l   $	��191��6�   $	��583��6�   $��Normal"�6�   ���	#FFCB5F21
���   � � 	Resources 57      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '        �� 58      "  6     59      P� 5:   "    �@ 
IsSelected . . �5;   &   ��  � �� �	#FFFAA5756C   �� 5<   &    � ��
 �   �6C   5=   #   5?      5@      5A      �� 5B      -   5        $ btnRefrescar��5B      $ 	Refrescar��6/   $
��Left=�6C   $	��Top=�6_   $��36��6w    / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  6�   $��35��6�   
���   �$��563,201,0,0q�6  ��5C      �� 5D       �� ImageSource$' !Imagenes/Command-Refresh-blue.png��6%   5F      �� 5G      -   5        $ btnEliminar��5G      $ Eliminar Registro��6.   $��Eliminar��6J   $
��Left=�6]   $��454,208,0,0q�6x   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFDF0D0D$��12(�6]  6k  �� 5H      -   5        $ btnPasar��5H      $ Traspasar Información��6+   $��	Traspasar��6K   $
��Left=�6_   $	��Top=�6{   $��78��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6a  $��
18,208,0,0q�6o  5J      5K      5L      5M      