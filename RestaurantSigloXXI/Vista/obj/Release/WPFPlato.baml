   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFPlato   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  6mah,http://metro.mahapps.com/winfx/xaml/controls   localclr-namespace:Vista   -   $��2q�
���   �  � Title$  Administrar Platos��$��513.645��$��1096.984�� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow��$
��Bold"�(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=����	#FFDBDFE3.��� $
��Left=�$	��482��$	��Top=�$
��1149��$��0,0,-61.667,-0.667q�.+��� -    ��Name$ image��$	��498��$	��Top=�$��Imagenes/about-img.jpg��$
��Fill=� J� Opacity$	 0.3Q�$��
0,0,50,-16q��� -   	 ��Name$	 groupBox��$��Información de Platos��$��34,10,706,0q�$	��Top=�$	��444�����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��442��$	��Top=�$	��409��$��0,-29,-9.667,-3.667q���Z� .+��� -    ��Name$ 
label_Copy��$��Descripción:��$
��Left=�$��	10,88,0,0q�$	��Top=�$��12(��� -    ��Name$ txtNomb��$
��Left=�$��23��$��
152,32,0,0q�*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Nombre�� �� TextWrapping$
 Wrap=�$	��Top=�$	��144��   ClearTextButton . $��Normal"��� -   $ 	txtPrecio��$
��Left=�$ Ingrese Precio��$��8��$��
152,60,0,0q�$
 Wrap=�$	��Top=�$	��125��$��Normal"� .  �� SelectionBrush �	#FFCB5F21�� -   $ txtDescripcion��" �� VerticalScrollBarVisibility$ Visible=�$
��Left=�$ Ingrese una Descripción��$��62��$��
152,88,0,0q�$
 Wrap=�$	��Top=�$	��230��$��Normal"� .   �	#FFCB5F21�� -    ��Name$ 	cboReceta��$
��Left=�$��152,182,0,0q�$	��Top=�$	��144��$��Normal"��� -	   $ cboCategoria��$
��Left=�$��152,211,0,0q�$	��Top=�$	��144��$��Normal"��� -
    ��Name$ 
btnGuardar�� � ToolTip$ Guardar Registro��$��Guardar��$
��Left=�$��
99,408,0,0q�$	��Top=�$��75��$ Arrow��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  .  J� RenderTransformOrigin$ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -   $ btnCancelar��$ Cancelar��$��Cancelar��$
��Left=�$��307,408,0,0q�$	��Top=�$��75��$��Normal"�$ Arrow�� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ 
btnLimpiar��$ Limpiar Casillas��$��Limpiar��$
��Left=�$��
10,408,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ label_Copy5��$��Precio ($):��$
��Left=�$��	10,60,0,0q�$	��Top=�$��12(��� -   $ btnModificar��$ Actualizar Registro��$��
Actualizar��$
��Left=�$��
99,408,0,0q�$	��Top=�$ Arrow��$��80��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ lblId��$y�Hidden=�$�� ��$
��Left=�$��10,6,0,0q�$	��Top=�$��12(��� -   $ label_Copy1��$��Nombre:��$
��Left=�$��	10,32,0,0q�$	��Top=�$��12(��� -   $ label_Copy3��$��
Stock (U):��$
��Left=�$��
10,153,0,0q�$	��Top=�$��12(��� -   $ label_Copy4��$��Receta:��$
��Left=�$��
10,182,0,0q�$	��Top=�$��12(��� -   $ label_Copy6��$��Categoría:��$
��Left=�$��
10,211,0,0q�$	��Top=�$��12(��� -   $ txtStock��$
��Left=�$ Ingrese Stock��$��8��$��152,153,0,0q�$
 Wrap=�$	��Top=�$	��125��$��Normal"� .  �	#FFCB5F21�� -   $ btnSeleccionar��$ Seleccionar Imagen��$��Examinar��$
��Left=�$��
10,243,0,0q�$	��Top=�$��79��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�� $
��Left=�$	��139��$��152,243,0,0q�$	��Top=�$	��216��.+��� $
��Left=�$	��139��
���   �$	��Top=�$	��216��
�������$	 0.7Q��� -   $ imgPlato��$
��Left=�$	��216��/   )MahApps.Metro.Controls.ScrollViewerHelper%   IsHorizontalScrollWheelEnabled . $
��Fill=��� -   $ FileNameLabel��$��Right=�$��10,382,27,34q�$��9.333(�$��26��$
��Bold"��� -   $
 lbl1��$��*��$
��Left=�$��
301,32,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 	lbl1_Copy��$��*��$
��Left=�$��
282,63,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy1��$��*��$
��Left=�$��281,153,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy2��$��*��$
��Left=�$��301,182,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy3��$��*��$
��Left=�$��301,211,0,0q�$	��Top=�$��12(����	#FF920101�� -   $	 	groupBox1��$��Respaldo Caché��$
��Left=�$��69��$��448,385,0,0q�$	��Top=�$	��609�����	#FFCB5F21���	#FFCB5F21.��� .+��� -   $ label2��$��Último Respaldo:��$
��Left=�$��67,2,0,0q�$	��Top=�$
��Bold"��� -   $ lblCache��$�� ��$
��Left=�$��	185,2,0,0q�$	��Top=�$	��215���� -    $ btnCache��$ Recuperar Caché��$��	Recuperar��$
��Left=�$��	479,2,0,0q�$	��Top=�$��78��#��[  ���	#FFCB5F21$��12(�$��Normal"�$
 Normal=��� -!   $	 groupBox_Copy��$��Listado de Platos��$��448,89,91,0q�$	��Top=�$	��291�����	#FFCB5F21$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��260��$	��Top=�$	��606��$��
0,-2,-6,-2q���Z� .+�&   System.Windows.Controls.DataGrid  -"     Name$ dgLista��   
IsReadOnly . $
��Left=�$��	18,38,0,0q�$	��Top=�$	��173��$	��565��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property  �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���  � ��  �	#FFFAA575��  � ��
  �   ��� -#   $ btnRefrescar��$ 	Refrescar��$
��Left=�$	��Top=�$��36�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  $��36��
���   �$��547,220,0,0q����� ! �� ImageSource$'! !Imagenes/Command-Refresh-blue.png���� -$   $ btnEliminar��$ Eliminar Registro��$��Eliminar��$
��Left=�$��454,225,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFDF0D0D$��12(��� -%   $ btnPasar��$ Traspasar Información��$��	Traspasar��$
��Left=�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��
18,225,0,0q��� -&   $ 	cboFiltro��$
��Left=�$��94,4,0,0q�$	��Top=�$	��144��$��Normal"��� -'   $ 
btnFiltrar��$ Filtrar por Categoría��$��Filtrar��$
��Left=�$��	252,4,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -(   $ label_Copy2��$��Categoría:��$
��Left=�$��19,4,0,0q�$	��Top=�$��12(��� -)   $ image1��$
��Left=�$��72��$��
497,15,0,0q�$	��Top=�$	��154��$��Imagenes/logoFinal3.png��$ 1.091,0.822&�