   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFReceta   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  6mah,http://metro.mahapps.com/winfx/xaml/controls   localclr-namespace:Vista   -   $��2q�
���   �  � Title$  Administrar Recetas��$��656.414��$��1172.926�� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow��$
��Bold"�(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=����	#FFDBDFE3.��� $
��Left=�$	��625��$	��Top=�$
��1174��$��0,0,-10.667,-0.333q�.+��� -    ��Name$ image��$	��638��$	��Top=�$��Imagenes/about-img.jpg��$
��Fill=� J� Opacity$	 0.3Q�$��0,0,-12,-13q�$
��Left=�$
��1186���� -   	 ��Name$	 groupBox��$��Información de Receta��$��	22,7,37,0q�$	��Top=�$	��211�����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=����	#FFCB5F21.��� $
��Left=�$	��180��$	��Top=�$
��1105��$��0,-2,-0.333,-2q���Z� .+��� -    ��Name$ txtNom_receta��$
��Left=�$��8��$��	161,6,0,0q� �� TextWrapping$
 Wrap=�*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Nombre��$	��Top=�$	��220��$��Normal"�   ClearTextButton .  �� SelectionBrush �	#FFCB5F21�� -   $ 	txtTi_Coc��$
��Left=�$ Ingrese Minutos��$��8��$��
161,43,0,0q�$
 Wrap=�$	��Top=�$	��131��$��Normal"� .  �	#FFCB5F21�� -   $ txtTPrep��$
��Left=�$ Ingrese Minutos��$��8��$��
161,79,0,0q�$
 Wrap=�$	��Top=�$	��131��$��Normal"� .  �	#FFCB5F21�� -   $ 
txtPorcion��$
��Left=�$ Ingrese Cantidad��$��8��$��161,114,0,0q�$
 Wrap=�$	��Top=�$	��131��$��Normal"� .  �	#FFCB5F21�� -    ��Name$ 
btnGuardar�� � ToolTip$ Guardar Registro��$��Guardar��$
��Left=�$��117,147,0,0q�$	��Top=�$��75��$ Arrow��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  .  J� RenderTransformOrigin$ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -	   $ btnCancelar��$ Cancelar��$��Cancelar��$
��Left=�$��301,146,0,0q�$	��Top=�$��75��$��Normal"�$ Arrow�� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -
   $ 
btnLimpiar��$ Limpiar Casillas��$��Limpiar��$
��Left=�$��
10,146,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -    ��Name$ label_Copy5��$��
Capacidad:��$
��Left=�$��-262,162,0,0q�$	��Top=�$��12(��� -   $ btnModificar��$ Actualizar Registro��$��
Actualizar��$
��Left=�$��115,146,0,0q�$	��Top=�$ Arrow��$��80��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ lblId��$�� ��$y�Hidden=�$
��Left=�$��	405,2,0,0q�$	��Top=�$��12(��� -   $ label_Copy1��$��T. de Cocción (Min.):��$
��Left=�$��6,42,0,0q�$	��Top=�$��12(��� -   $ label_Copy3��$��Asignada Para:��$
��Left=�$��-272,122,0,0q�$	��Top=�$��12(��� -   $ label_Copy2��$��Nombre de Receta:��$
��Left=�$��6,6,0,0q�$	��Top=�$��12(��� -   $ 
label_Copy��$ ��T. de Preparación (Min.):��$
��Left=�$��6,79,0,0q�$	��Top=�$��12(��� -   $ label_Copy6��$��Instrucciones:��$
��Left=�$��	392,2,0,0q�$	��Top=�$��12(��� -   $ label_Copy7��$��
Porciones:��$
��Left=�$��	6,114,0,0q�$	��Top=�$��12(��� -   $ label_Copy8��$��Ingredientes:��$
��Left=�$��750,2,-38,0q�$	��Top=�$��12(��� -   $ txtInstrucciones�� �� AcceptsReturn . $��Visible=�$
��Left=�$	��141��$��
392,33,0,0q�$
 Wrap=�$	��Top=�$	��342��$��Normal"� �	#FFCB5F21�� -   $ txtIngrediente�� . $��Visible=�$
��Left=�$	��141��$��750,33,-296,0q�$
 Wrap=�$	��Top=�$	��342��$��Normal"� �	#FFCB5F21�� -   $ 
lbl1_Copy2��$��*��$
��Left=�$��	381,6,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 	lbl1_Copy��$��*��$
��Left=�$��
292,79,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy1��$��*��$
��Left=�$��292,114,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy3��$��*��$
��Left=�$��	479,6,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy4��$��*��$
��Left=�$��	839,2,0,0q�$	��Top=�$��12(����	#FF920101�� -   $	 	groupBox1��$��Respaldo Caché��$
��Left=�$��69��$��
22,533,0,0q�$	��Top=�$	��588�����	#FFCB5F21���	#FFCB5F21.��� .+��� -   $ label2��$��Último Respaldo:��$
��Left=�$��36,2,0,0q�$	��Top=�$
��Bold"��� -   $ lblCache��$�� ��$
��Left=�$��	142,2,0,0q�$	��Top=�$	��218���� -   $ btnCache��$ Recuperar Caché��$��	Recuperar��$
��Left=�$��	417,0,0,0q�$	��Top=�$��78��#��[  ���	#FFCB5F21$��12(�$��Normal"�$
 Normal=��� -    $	 groupBox_Copy��$��Listado de Recetas��$��22,222,37,0q�$	��Top=�$	��302�����	#FFCB5F21$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��273��$	��Top=�$
��1105��$��0,-2,-0.333,-4.333q���Z� .+�&   System.Windows.Controls.DataGrid  -!     Name$ dgLista��   
IsReadOnly . $
��Left=�$��18,6,0,0q�$	��Top=�$	��221��$
��1074��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   ��� -"   $ btnRefrescar��$ 	Refrescar��$
��Left=�$	��Top=�$��36�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  $��36��
���   �$��1052,232,0,0q�����  �� ImageSource$' !Imagenes/Command-Refresh-blue.png���� -#   $ btnEliminar��$ Eliminar Registro��$��Eliminar��$
��Left=�$��943,238,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFDF0D0D$��12(��� -$   $ btnPasar��$ Traspasar Información��$��	Traspasar��$
��Left=�$	��Top=�$��78��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��
18,238,0,0q��� -%   $ image1��$
��Left=�$��80��$��1001,524,0,0q�$	��Top=�$	��136��$��Imagenes/logoFinal3.png��$ 1.091,0.822&�