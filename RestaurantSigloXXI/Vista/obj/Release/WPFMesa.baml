   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFMesa   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  6mah,http://metro.mahapps.com/winfx/xaml/controls   localclr-namespace:Vista   -   $��2q�
���   �  � Title$  Administrar Mesas��$��648.312��$��785.651�� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow��$
��Bold"�(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=����	#FFDBDFE3.��� $
��Left=�$	��605��$	��Top=�$	��776��.+��� -    ��Name$ image��$	��620��$	��Top=�$��Imagenes/about-img.jpg��$
��Fill=� J� Opacity$	 0.3Q�$��0,0,-18,-15q�$
��Left=�$	��794���� -   	 ��Name$	 groupBox��$��Información de Mesa��$��
49,12,51,0q�$	��Top=�$	��252�����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=����	#FFCB5F21.��� $
��Left=�$	��223��$	��Top=�$	��621��$��0,-2,-0.333,-3.667q���Z� .+��� -    ��Name$ 
label_Copy��$��Rut Empleado a Cargo:��$
��Left=�$��
23,121,0,0q�$	��Top=�$��12(�	� -    	�Name$ rb_disponible�� d� 	IsChecked$
 TrueY�$��Si��$
��Left=�$��
166,33,0,0q�$	��Top=�$
��Bold"� 	� 	GroupName$ 
disponible��	� -   $ rb_NoDisponible��$��No��$
��Left=�$��
216,33,0,0q�$	��Top=�$
��Bold"�$ 
disponible���� -   $ label_Copy3��$��Asignada Para:��$
��Left=�$��	23,62,0,0q�$	��Top=�$��12(�	� -   $ rbOnLine��$��OnLine��$
��Left=�$��
166,62,0,0q�$	��Top=�$
��Bold"�$ 
Asignacion��$
 TrueY�	� -	   $ rbPresencial��$��
Presencial��$
��Left=�$��
246,62,0,0q�$	��Top=�$
��Bold"�$ 
Asignacion���� -
    ��Name$ txtNum��$
��Left=�$��8��$��	166,2,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��91��$��Normal"�*   $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton .   �� SelectionBrush �	#FFCB5F21{�.  �� -   $ txtCapacidad��$
��Left=�   	Watermark$ Ingrese Cantidad��$��8��$��
166,88,0,0q�$
 Wrap=�$	��Top=�$	��163��$��Normal"� .  �	#FFCB5F21�� -   $ txtRut��$
��Left=�$ Ej: 11222333-k��$��8��$��166,121,0,0q�$
 Wrap=�$	��Top=�$	��163��$��Normal"� .  �	#FFCB5F21�� -   $ 	txtNombre��$
��Left=�$ Nombre de Garzón��$��8��$��166,154,0,0q�$
 Wrap=�$	��Top=�$	��221��$��Normal"� .   J� RenderTransformOrigin$ 0.5,0.5&� �	#FFCB5F21{�.  �� -    ��Name$ 
btnGuardar�� � ToolTip$ Guardar Registro��$��Guardar��$
��Left=�$��137,185,0,0q�$	��Top=�$��75��$ Arrow��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  . $ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -   $ btnCancelar��$ Cancelar��$��Cancelar��$
��Left=�$��508,185,0,0q�$	��Top=�$��75��$��Normal"�$ Arrow�� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ btnPregunta��$ Ver Listado de Empleados��$��?��$��351,121,234,75q�$��Normal"�$ Arrow�� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ 	btnBuscar��$ Buscar Empleado��$��Buscar��$
��Left=�$��405,121,0,0q�$	��Top=�$��27��$��64��$ Arrow��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ 
btnLimpiar��$ Limpiar Casillas��$��Limpiar��$
��Left=�$��
27,185,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ image1��$
��Left=�$��78��$��
440,10,0,0q�$	��Top=�$	��156��$��Imagenes/logoFinal3.png��$ 1.091,0.822&��� -   $ label_Copy7��$��Nombre Empleado:��$
��Left=�$��
23,154,0,0q�$	��Top=�$��12(��� -   $ label_Copy5��$��
Capacidad:��$
��Left=�$��	23,88,0,0q�$	��Top=�$��12(��� -   $ btnModificar��$ Actualizar Registro��$��
Actualizar��$
��Left=�$��132,185,0,0q�$	��Top=�$ Arrow��$��80��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ label_Copy2��$��Número de Mesa:��$
��Left=�$��23,2,0,0q�$	��Top=�$��12(��� -   $ label_Copy1��$��Disponible:��$
��Left=�$��	23,33,0,0q�$	��Top=�$��12(��� -   $ 
lbl1_Copy7��$��*��$
��Left=�$��	257,2,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 	lbl1_Copy��$��*��$
��Left=�$��
262,31,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy1��$��*��$
��Left=�$��
332,61,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy2��$��*��$
��Left=�$��
329,88,0,0q�$	��Top=�$��12(����	#FF920101�� -   $	 	groupBox1��$��Respaldo Caché��$
��Left=�$��69��$��
49,536,0,0q�$	��Top=�$	��676�����	#FFCB5F21���	#FFCB5F21.��� .+��� -   $ label2��$��Último Respaldo:��$
��Left=�$��26,1,0,0q�$	��Top=�$
��Bold"��� -   $ lblCache��$�� ��$
��Left=�$��	156,1,0,0q�$	��Top=�$	��215���� -    $ btnCache��$ Recuperar Caché��$��	Recuperar��$
��Left=�$��	454,0,0,0q�$	��Top=�$��78��#��[  ���	#FFCB5F21$��12(�$��Normal"�$
 Normal=��� -!   $	 groupBox_Copy��$��Listado de mesas��$��49,267,51,0q�$	��Top=�$	��264�����	#FFCB5F21$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��240��$	��Top=�$	��666��$��0,-2,0,-8.667q���Z� .+�&   System.Windows.Controls.DataGrid  -"     Name$ dgLista��   
IsReadOnly . $
��Left=�$��	10,10,0,0q�$	��Top=�$	��163��$	��646��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property  �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���  � ��  �	#FFFAA575��  � ��
  �   ��� -#   $ btnRefrescar��$ 	Refrescar��$
��Left=�$	��Top=�$��36�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  $��36��
���   �$��620,182,0,0q����� ! �� ImageSource$'! !Imagenes/Command-Refresh-blue.png���� -$   $ btnEliminar��$ Eliminar Registro��$��Eliminar��$
��Left=�$��511,189,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFDF0D0D$��12(��� -%   $ btnPasar��$ Traspasar Información��$��	Traspasar��$
��Left=�$	��Top=�$��78��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��
10,189,0,0q�