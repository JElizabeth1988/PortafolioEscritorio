   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5
   	      Vista.WPFReceta   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5	   	   localclr-namespace:Vista   5
   	   -   5        $��2q�5   	   
���   �  � Title$  Administrar Recetas��5   	   $��656.414��6%   $��1172.926��66    � WindowStartupLocation$ CenterScreen=�6G    � Cursor$ Arrow��6l   $
��Bold"�6{   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6�   ���	#FFDBDFE3.��5      � $
��Left=�6   $	��625��6&   $	��Top=�63   $
��1174��6K   $��0,0,-10.667,-0.333q�6X   .+�5   
   �� -   5         ��Name$ image��5      $	��638��6   $	��Top=�6,   $��Imagenes/about-img.jpg��6D   $
��Fill=�6d    J� Opacity$	 0.3Q�6s   $��0,0,-12,-13q�6�   $
��Left=�6�   $
��1186��6�   �� 5   
   -   5        	 ��Name$	 groupBox��5      $��Información de Receta��6%   $��	22,7,37,0q�6D   $	��Top=�6W   $	��211��6o   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�6�   ���	#FFCB5F21.��5      � $
��Left=�6   $	��180��6.   $	��Top=�6;   $
��1105��6S   $��0,-2,-0.333,-2q�6`   ��6x   Z� .+�5      �� -   5         ��Name$ txtNom_receta��5      $
��Left=�61   $��8��6M   $��	161,6,0,0q�6X    �� TextWrapping$
 Wrap=�6k   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Nombre��6   $	��Top=�6�   $	��220��6�   $��Normal"�6�      ClearTextButton .  �� SelectionBrush �	#FFCB5F216  �� 5      -   5        $ 	txtTi_Coc��5      $
��Left=�6-   $ Ingrese Minutos��6H   $��8��6v   $��
161,43,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��131��6�   $��Normal"�6�    .  �	#FFCB5F216'  �� 5      -   5        $ txtTPrep��5      $
��Left=�6,   $ Ingrese Minutos��6G   $��8��6u   $��
161,79,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��131��6�   $��Normal"�6�    .  �	#FFCB5F216&  �� 5      -   5        $ 
txtPorcion��5      $
��Left=�6.   $ Ingrese Cantidad��6I   $��8��6x   $��161,114,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��131��6�   $��Normal"�6�    .  �	#FFCB5F216*  �� 5      -   5         ��Name$ 
btnGuardar��5       � ToolTip$ Guardar Registro��6-   $��Guardar��6H   $
��Left=�6Z   $��117,147,0,0q�6u   $	��Top=�6�   $��75��6�   $ Arrow��6�   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  .  J� RenderTransformOrigin$ 1.662,0.727&�6"     AccentedSquareButtonStyle#��[  6F  ���	#FFCB5F21$��12(�6�  6�  �� 5      -	   5        $ btnCancelar��5      $ Cancelar��6.   $��Cancelar��6A   $
��Left=�6T   $��301,146,0,0q�6o   $	��Top=�6�   $��75��6�   $��Normal"�6�   $ Arrow��6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6b  6p  �� 5      -
   5        $ 
btnLimpiar��5      $ Limpiar Casillas��6-   $��Limpiar��6H   $
��Left=�6Z   $��
10,146,0,0q�6u   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6X  6f  �� 5      -   5         ��Name$ label_Copy5��5      $��
Capacidad:��6-   $
��Left=�6B   $��-262,162,0,0q�6]   $	��Top=�6s   $��12(�6�   �� 5      -   5        $ btnModificar��5      $ Actualizar Registro��6/   $��
Actualizar��6M   $
��Left=�6b   $��115,146,0,0q�6}   $	��Top=�6�   $ Arrow��6�   $��80��6�   $��Normal"�6�    . $ 1.662,0.727&�6  #��[  6'  ���	#FFCB5F21$��12(�6q  6  �� 5      -   5        $ lblId��5      $�� ��6'   $y�Hidden=�62   $
��Left=�6F   $��	405,2,0,0q�6a   $	��Top=�6t   $��12(�6�   �� 5      -   5        $ label_Copy1��5      $��T. de Cocción (Min.):��6-   $
��Left=�6M   $��6,42,0,0q�6h   $	��Top=�6z   $��12(�6�   �� 5      -   5        $ label_Copy3��5      $��Asignada Para:��6-   $
��Left=�6F   $��-272,122,0,0q�6a   $	��Top=�6w   $��12(�6�   �� 5       -   5        $ label_Copy2��5       $��Nombre de Receta:��6-   $
��Left=�6I   $��6,6,0,0q�6d   $	��Top=�6u   $��12(�6�   �� 5"      -   5        $ 
label_Copy��5"      $ ��T. de Preparación (Min.):��6,   $
��Left=�6P   $��6,79,0,0q�6k   $	��Top=�6}   $��12(�6�   �� 5$      -   5        $ label_Copy6��5$      $��Instrucciones:��6-   $
��Left=�6F   $��	392,2,0,0q�6a   $	��Top=�6t   $��12(�6�   �� 5&      -   5        $ label_Copy7��5&      $��
Porciones:��6-   $
��Left=�6B   $��	6,114,0,0q�6]   $	��Top=�6p   $��12(�6�   �� 5(      -   5        $ label_Copy8��5(      $��Ingredientes:��6-   $
��Left=�6E   $��750,2,-38,0q�6`   $	��Top=�6u   $��12(�6�   �� 5)      -   5        $ txtInstrucciones��5)       �� AcceptsReturn . $��Visible=�6I   $
��Left=�6}   $	��141��6�   $��
392,33,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��342��6�   $��Normal"�6�    �	#FFCB5F216  �� 5*      -   5        $ txtIngrediente��5*       . $��Visible=�6H   $
��Left=�6{   $	��141��6�   $��750,33,-296,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��342��6�   $��Normal"�6�    �	#FFCB5F216  �� 5+      -   5        $ 
lbl1_Copy2��5+      $��*��6,   $
��Left=�69   $��	381,6,0,0q�6T   $	��Top=�6g   $��12(�6   ���	#FF9201016�   �� 5,      -   5        $ 	lbl1_Copy��5,      $��*��6+   $
��Left=�68   $��
292,79,0,0q�6S   $	��Top=�6g   $��12(�6   ���	#FF9201016�   �� 5-      -   5        $ 
lbl1_Copy1��5-      $��*��6,   $
��Left=�69   $��292,114,0,0q�6T   $	��Top=�6i   $��12(�6�   ���	#FF9201016�   �� 5.      -   5        $ 
lbl1_Copy3��5.      $��*��6,   $
��Left=�69   $��	479,6,0,0q�6T   $	��Top=�6g   $��12(�6   ���	#FF9201016�   �� 5/      -   5        $ 
lbl1_Copy4��5/      $��*��6,   $
��Left=�69   $��	839,2,0,0q�6T   $	��Top=�6g   $��12(�6   ���	#FF9201016�   51      52      �� 53   
   -   5        $	 	groupBox1��53      $��Respaldo Caché��6&   $
��Left=�6>   $��69��6Y   $��
22,533,0,0q�6e   $	��Top=�6y   $	��588��6�   ���	#FFCB5F21���	#FFCB5F21.��54      � .+�55      �� -   5        $ label2��55      $��Último Respaldo:��6(   $
��Left=�6C   $��36,2,0,0q�6^   $	��Top=�6p   $
��Bold"�6�   �� 56      -   5        $ lblCache��56      $�� ��6*   $
��Left=�65   $��	142,2,0,0q�6P   $	��Top=�6c   $	��218��6{   �� 57      -   5        $ btnCache��57      $ Recuperar Caché��6+   $��	Recuperar��6E   $
��Left=�6Y   $��	417,0,0,0q�6t   $	��Top=�6�   $��78��6�   #��[  6�   ���	#FFCB5F21$��12(�6  $��Normal"�6  $
 Normal=�6-  59      5:      �� 5;   
   -    5        $	 groupBox_Copy��5;      $��Listado de Recetas��6*   $��22,222,37,0q�6F   $	��Top=�6[   $	��302��6s   ���	#FFCB5F21$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5<      � $
��Left=�6   $	��273��6.   $	��Top=�6;   $
��1105��6S   $��0,-2,-0.333,-4.333q�6`   ��6|   Z� .+�5>      &   System.Windows.Controls.DataGrid  -!   5          Name$ dgLista��5>         
IsReadOnly . $
��Left=�6>   $��18,6,0,0q�6Y   $	��Top=�6k   $	��221��6�   $
��1074��6�   $��Normal"�6�   ���	#FFCB5F21
���   � � 	Resources 5@      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '        �� 5A      "  6     5B      P� 5C   "    �@ 
IsSelected . . �5D   &   ��  � �� �	#FFFAA5756C   �� 5E   &    � ��
 �   �6C   5F   #   5H      5I      5J      �� 5K      -"   5        $ btnRefrescar��5K      $ 	Refrescar��6/   $
��Left=�6C   $	��Top=�6_   $��36��6w    / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  6�   $��36��6�   
���   �$��1052,232,0,0q�6  ��5L      �� 5M       �� ImageSource$' !Imagenes/Command-Refresh-blue.png��6%   5O      �� 5P      -#   5        $ btnEliminar��5P      $ Eliminar Registro��6.   $��Eliminar��6J   $
��Left=�6]   $��943,238,0,0q�6x   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFDF0D0D$��12(�6]  6k  �� 5Q      -$   5        $ btnPasar��5Q      $ Traspasar Información��6+   $��	Traspasar��6K   $
��Left=�6_   $	��Top=�6{   $��78��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6a  $��
18,238,0,0q�6o  5S      5T      �� 5U   
   -%   5        $ image1��5U      $
��Left=�6    $��80��6;   $��1001,524,0,0q�6G   $	��Top=�6]   $	��136��6u   $��Imagenes/logoFinal3.png��6�   $ 1.091,0.822&�6�   5W      5X      