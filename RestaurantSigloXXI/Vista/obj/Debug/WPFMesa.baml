   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5
   	      Vista.WPFMesa   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5	   	   localclr-namespace:Vista   5
   	   -   5        $��2q�5   	   
���   �  � Title$  Administrar Mesas��5   	   $��648.312��6#   $��785.651��64    � WindowStartupLocation$ CenterScreen=�6D    � Cursor$ Arrow��6i   $
��Bold"�6x   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6�   ���	#FFDBDFE3.��5      � $
��Left=�6   $	��605��6&   $	��Top=�63   $	��776��6K   .+�5   
   �� -   5         ��Name$ image��5      $	��620��6   $	��Top=�6,   $��Imagenes/about-img.jpg��6D   $
��Fill=�6d    J� Opacity$	 0.3Q�6s   $��0,0,-18,-15q�6�   $
��Left=�6�   $	��794��6�   �� 5   
   -   5        	 ��Name$	 groupBox��5      $��Información de Mesa��6%   $��
49,12,51,0q�6B   $	��Top=�6V   $	��252��6n   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�6�   ���	#FFCB5F21.��5      � $
��Left=�6   $	��223��6.   $	��Top=�6;   $	��621��6S   $��0,-2,-0.333,-3.667q�6_   ��6{   Z� .+�5      �� -   5         ��Name$ 
label_Copy��5      $��Rut Empleado a Cargo:��6,   $
��Left=�6L   $��
23,121,0,0q�6g   $	��Top=�6{   $��12(�6�   	� 5      -   5         	�Name$ rb_disponible��5       d� 	IsChecked$
 TrueY�65   $��Si��6F   $
��Left=�6S   $��
166,33,0,0q�6n   $	��Top=�6�   $
��Bold"�6�    	� 	GroupName$ 
disponible��6�   	� 5      -   5        $ rb_NoDisponible��5      $��No��67   $
��Left=�6D   $��
216,33,0,0q�6_   $	��Top=�6s   $
��Bold"�6�   $ 
disponible��6�   �� 5      -   5        $ label_Copy3��5      $��Asignada Para:��6-   $
��Left=�6F   $��	23,62,0,0q�6a   $	��Top=�6t   $��12(�6�   	� 5      -   5        $ rbOnLine��5      $��OnLine��61   $
��Left=�6B   $��
166,62,0,0q�6]   $	��Top=�6q   $
��Bold"�6�   $ 
Asignacion��6�   $
 TrueY�6�   	� 5      -	   5        $ rbPresencial��5      $��
Presencial��64   $
��Left=�6I   $��
246,62,0,0q�6d   $	��Top=�6x   $
��Bold"�6�   $ 
Asignacion��6�   �� 5      -
   5         ��Name$ txtNum��5      $
��Left=�6*   $��8��6F   $��	166,2,0,0q�6Q    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $��91��6�   $��Normal"�6�   *   $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton .   �� SelectionBrush �	#FFCB5F21{�.  6�   �� 5      -   5        $ txtCapacidad��5      $
��Left=�60      	Watermark$ Ingrese Cantidad��6K   $��8��6z   $��
166,88,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��163��6�   $��Normal"�6�    .  �	#FFCB5F216+  �� 5      -   5        $ txtRut��5      $
��Left=�6*   $ Ej: 11222333-k��6E   $��8��6r   $��166,121,0,0q�6}   $
 Wrap=�6�   $	��Top=�6�   $	��163��6�   $��Normal"�6�    .  �	#FFCB5F216  �� 5      -   5        $ 	txtNombre��5      $
��Left=�6-   $ Nombre de Garzón��6H   $��8��6w   $��166,154,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��221��6�   $��Normal"�6�    .   J� RenderTransformOrigin$ 0.5,0.5&�6   �	#FFCB5F21{�.  6H  �� 5      -   5         ��Name$ 
btnGuardar��5       � ToolTip$ Guardar Registro��6-   $��Guardar��6H   $
��Left=�6Z   $��137,185,0,0q�6u   $	��Top=�6�   $��75��6�   $ Arrow��6�   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  . $ 1.662,0.727&�6"     AccentedSquareButtonStyle#��[  6F  ���	#FFCB5F21$��12(�6�  6�  �� 5      -   5        $ btnCancelar��5      $ Cancelar��6.   $��Cancelar��6B   $
��Left=�6U   $��508,185,0,0q�6p   $	��Top=�6�   $��75��6�   $��Normal"�6�   $ Arrow��6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6c  6q  �� 5      -   5        $ btnPregunta��5      $ Ver Listado de Empleados��6.   $��?��6Q   $��351,121,234,75q�6]   $��Normal"�6v   $ Arrow��6�    . $ 1.662,0.727&�6�   #��[  6�   ���	#FFCB5F21$��12(�61  6?  �� 5      -   5        $ 	btnBuscar��5      $ Buscar Empleado��6,   $��Buscar��6F   $
��Left=�6W   $��405,121,0,0q�6r   $	��Top=�6�   $��27��6�   $��64��6�   $ Arrow��6�   $��Normal"�6�    . $ 1.662,0.727&�6  #��[  6'  ���	#FFCB5F21$��12(�6q  6  �� 5       -   5        $ 
btnLimpiar��5       $ Limpiar Casillas��6-   $��Limpiar��6H   $
��Left=�6Z   $��
27,185,0,0q�6u   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6X  6f  �� 5!      -   5        $ image1��5!      $
��Left=�6(   $��78��6C   $��
440,10,0,0q�6O   $	��Top=�6c   $	��156��6{   $��Imagenes/logoFinal3.png��6�   $ 1.091,0.822&�6�   �� 5"      -   5        $ label_Copy7��5"      $��Nombre Empleado:��6-   $
��Left=�6H   $��
23,154,0,0q�6c   $	��Top=�6w   $��12(�6�   �� 5#      -   5        $ label_Copy5��5#      $��
Capacidad:��6-   $
��Left=�6B   $��	23,88,0,0q�6]   $	��Top=�6p   $��12(�6�   �� 5%      -   5        $ btnModificar��5%      $ Actualizar Registro��6/   $��
Actualizar��6M   $
��Left=�6b   $��132,185,0,0q�6}   $	��Top=�6�   $ Arrow��6�   $��80��6�   $��Normal"�6�    . $ 1.662,0.727&�6  #��[  6'  ���	#FFCB5F21$��12(�6q  6  �� 5&      -   5        $ label_Copy2��5&      $��Número de Mesa:��6-   $
��Left=�6G   $��23,2,0,0q�6b   $	��Top=�6t   $��12(�6�   �� 5(      -   5        $ label_Copy1��5(      $��Disponible:��6-   $
��Left=�6C   $��	23,33,0,0q�6^   $	��Top=�6q   $��12(�6�   �� 5)      -   5        $ 
lbl1_Copy7��5)      $��*��6,   $
��Left=�69   $��	257,2,0,0q�6T   $	��Top=�6g   $��12(�6   ���	#FF9201016�   �� 5*      -   5        $ 	lbl1_Copy��5*      $��*��6+   $
��Left=�68   $��
262,31,0,0q�6S   $	��Top=�6g   $��12(�6   ���	#FF9201016�   �� 5+      -   5        $ 
lbl1_Copy1��5+      $��*��6,   $
��Left=�69   $��
332,61,0,0q�6T   $	��Top=�6h   $��12(�6�   ���	#FF9201016�   �� 5,      -   5        $ 
lbl1_Copy2��5,      $��*��6,   $
��Left=�69   $��
329,88,0,0q�6T   $	��Top=�6h   $��12(�6�   ���	#FF9201016�   �� 5-      -   5        $ 
lbl1_Copy3��5-      $��*��6,   $
��Left=�69   $��329,121,0,0q�6T   $	��Top=�6i   $��12(�6�   ���	#FF9201016�   5/      50      �� 51   
   -   5        $	 	groupBox1��51      $��Respaldo Caché��6&   $
��Left=�6>   $��69��6Y   $��
49,536,0,0q�6e   $	��Top=�6y   $	��676��6�   ���	#FFCB5F21���	#FFCB5F21.��52      � .+�53      �� -   5        $ label2��53      $��Último Respaldo:��6(   $
��Left=�6C   $��26,1,0,0q�6^   $	��Top=�6p   $
��Bold"�6�   �� 54      -    5        $ lblCache��54      $�� ��6*   $
��Left=�65   $��	156,1,0,0q�6P   $	��Top=�6c   $	��215��6{   �� 55      -!   5        $ btnCache��55      $ Recuperar Caché��6+   $��	Recuperar��6E   $
��Left=�6Y   $��	454,0,0,0q�6t   $	��Top=�6�   $��78��6�   #��[  6�   ���	#FFCB5F21$��12(�6  $��Normal"�6  $
 Normal=�6-  57      58      �� 59   
   -"   5        $	 groupBox_Copy��59      $��Listado de mesas��6*   $��49,267,51,0q�6D   $	��Top=�6Y   $	��264��6q   ���	#FFCB5F21$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5:      � $
��Left=�6   $	��240��6.   $	��Top=�6;   $	��666��6S   $��0,-2,0,-8.667q�6_   ��6v   Z� .+�5<      &   System.Windows.Controls.DataGrid  -#   5          Name$ dgLista��5<         
IsReadOnly . $
��Left=�6>   $��	10,10,0,0q�6Y   $	��Top=�6l   $	��163��6�   $	��646��6�   $��Normal"�6�   ���	#FFCB5F21
���   � � 	Resources 5>      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property  �� Value��%�   '        �� 5?      "  6     5@      P� 5A   "    �@ 
IsSelected . . �5B   &   ��  � ��  �	#FFFAA5756C   �� 5C   &    � ��
  �   �6C   5D   #   5F      5G      5H      �� 5I      -$   5        $ btnRefrescar��5I      $ 	Refrescar��6/   $
��Left=�6C   $	��Top=�6_   $��36��6w    / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  6�   $��36��6�   
���   �$��620,182,0,0q�6  ��5J      �� 5K      ! �� ImageSource$'! !Imagenes/Command-Refresh-blue.png��6%   5M      �� 5N      -%   5        $ btnEliminar��5N      $ Eliminar Registro��6.   $��Eliminar��6J   $
��Left=�6]   $��511,189,0,0q�6x   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFDF0D0D$��12(�6]  6k  �� 5O      -&   5        $ btnPasar��5O      $ Traspasar Información��6+   $��	Traspasar��6K   $
��Left=�6_   $	��Top=�6{   $��78��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6a  $��
10,189,0,0q�6o  5Q      5R      5S      5T      