   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFPago   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  6mah,http://metro.mahapps.com/winfx/xaml/controls   localclr-namespace:Vista   -   $��2q�
���   �  � Title$  Administrar Pagos��$��648.312��$��1149.984�� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow��$
��Bold"�(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=����	#FFDBDFE3.��� $
��Left=�$	��618��$	��Top=�$
��1140��$��0,0,0,-2q�.+��� -    ��Name$ image��$	��629��$	��Top=�$��Imagenes/about-img.jpg��$
��Fill=� J� Opacity$	 0.3Q�$��0,0,-19,-11q�$
��Left=�$
��1159���� -   	 ��Name$	 groupBox��$��
Nuevo Pago��$��49,12,462,0q�$	��Top=�$	��285�����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=����	#FFCB5F21.��� $
��Left=�$	��269��$	��Top=�$	��621��$��0,-2,-1.667,-49.667q���Z� .+��� -    ��Name$ label_Copy3��$��Cliente:��$
��Left=�$��
23,134,0,0q�$	��Top=�$��12(��� -    ��Name$ txtTotal��$
��Left=�*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Cantidad��$��8��$��	166,2,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��136��$��Normal"�   ClearTextButton .  �� SelectionBrush �	#FFCB5F21�� -   $ txtDcto��$
��Left=�$  ��{�.  $��8��$��
166,35,0,0q�$
 Wrap=�$	��Top=�$	��136��$��Normal"� .   �	#FFCB5F21�� -    ��Name$ 
btnGuardar�� � ToolTip$ Guardar Registro��$��Guardar��$
��Left=�$��137,213,0,0q�$	��Top=�$��75��$ Arrow��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  .  J� RenderTransformOrigin$ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -   $ btnCancelar��$ Cancelar��$��Cancelar��$
��Left=�$��508,213,0,0q�$	��Top=�$��75��$��Normal"�$ Arrow�� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -	   $ 
btnLimpiar��$ Limpiar Casillas��$��Limpiar��$
��Left=�$��
27,213,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -
   $ image1��$
��Left=�$��78��$��
440,10,0,0q�$	��Top=�$	��156��$��Imagenes/logoFinal3.png��$ 1.091,0.822&��� -   $ label_Copy5��$��Número de Pedido:��$
��Left=�$��
23,170,0,0q�$	��Top=�$��12(��� -   $ label_Copy2��$��Total a Pagar $:��$
��Left=�$��23,2,0,0q�$	��Top=�$��12(��� -   $ label_Copy1��$��Descuento $:��$
��Left=�$��	23,35,0,0q�$	��Top=�$��12(��� -   $ 
lbl1_Copy7��$��*��$
��Left=�$��	307,2,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy1��$��*��$
��Left=�$��533,134,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ txtRut��$
��Left=�$ Rut de Cliente��$��8��$��166,134,0,0q�$
 Wrap=�$	��Top=�$	��136��$��Normal"� .   �	#FFCB5F21{�.  �� -   $ 	txtNombre��$
��Left=�$ Nombre de Cliente��$��8��$��307,134,0,0q�$
 Wrap=�$	��Top=�$	��221��$��Normal"� .  $ 0.5,0.5&� �	#FFCB5F21{�.  �� -   $ 	txtPagado��$
��Left=�$ Ingrese Cantidad��$��8��$��
166,68,0,0q�$
 Wrap=�$	��Top=�$	��136��$��Normal"� .  �	#FFCB5F21�� -   $ 	txtVuelto��$
��Left=�{�.  $  ��$��8��$��166,101,0,0q�$
 Wrap=�$	��Top=�$	��136��$��Normal"� .   �	#FFCB5F21�� -   $ 
label_Copy��$��Monto Pagado $:��$
��Left=�$��	23,68,0,0q�$	��Top=�$��12(��� -   $ label_Copy7��$��	Vuelto $:��$
��Left=�$��
23,101,0,0q�$	��Top=�$��12(��� -   $ 
lbl1_Copy8��$��*��$
��Left=�$��
307,68,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 	txtPedido��$
��Left=�{�.  $  ��$��8��$��166,170,0,0q�$
 Wrap=�$	��Top=�$	��136��$��Normal"� .   �	#FFCB5F21�� -   $ 	btnBoleta��$ Generar Boleta��$��Visualizar Boleta��$
��Left=�$��137,213,0,0q�$	��Top=�$ Arrow��$��99��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ 	lbl1_Copy��$��*��$
��Left=�$��307,170,0,0q�$	��Top=�$��12(����	#FF920101�� -   $	 groupBox_Copy��$��Listado de Órdenes��$��49,315,462,0q�$	��Top=�$	��279�����	#FFCB5F21$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��249��$	��Top=�$	��619��$��	0,-2,0,-3q���Z� .+�&   System.Windows.Controls.DataGrid  -     Name$ dgLista��   
IsReadOnly . $
��Left=�$��	10,10,0,0q�$	��Top=�$	��194��$	��599��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   ��� -   $ btnPasar��$ Traspasar Información��$��Seleccionar��$
��Left=�$	��Top=�$��78��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��10,209,0,-5q��� -   $	 groupBox_Copy1��$��Visualizar Boleta��$��	0,12,49,0q�$	��Top=�$	��582�����	#FFCB5F21$
 Upper=����	#FFCB5F21$��Right=�$	��402��.��� $
��Left=�$	��548��$	��Top=�$	��392��$��-1,0,0,-1.333q���Z� .+��� ���	#FFF4F4F5$
��Left=�$	��500��
���   �$	��Top=�$	��392���� -   $ label_Copy4��$��
Descuento:��$
��Left=�$��
25,275,0,0q�$	��Top=�$��12(��� -   $ label_Copy8��$O��I-------------------------------------------------------------------------��$
��Left=�$��
23,192,0,0q�$	��Top=�$��12(�$	��350���� -    $ label_Copy10��$��Número de Boleta: ��$��136,58,137,0q�$	��Top=�$��12(��� -!   $ 	lblNumero��$��-��$��158,78,162,0q�$��Center=�$��Center=�$	��Top=�$��12(�$��72���� -"   $ lblDcto��$��-��$
��Left=�$��309,275,0,0q�$	��Top=�$��12(�$��64���� -#   $ label_Copy12��$��
Sub-total:��$
��Left=�$��
25,303,0,0q�$	��Top=�$��12(��� -$   $ label_Copy14��$��Total:��$
��Left=�$��
25,366,0,0q�$	��Top=�$��12(��� -%   $ label_Copy15��$��Efectivo Entregado:��$
��Left=�$��
25,403,0,0q�$	��Top=�$��12(��� -&   $ label_Copy16��$��Efectivo Devuelto:��$
��Left=�$��
25,427,0,0q�$	��Top=�$��12(��� -'   $ label_Copy17��$��Atendido Por:��$
��Left=�$��
25,102,0,0q�$	��Top=�$��12(��� -(   $ lblSubTotal��$��-��$
��Left=�$��309,303,0,0q�$	��Top=�$��12(�$��64���� -)   $ lblTotal��$��-��$
��Left=�$��309,366,0,0q�$	��Top=�$��12(�$��64���� -*   $ lblMonto��$��-��$
��Left=�$��309,403,0,0q�$	��Top=�$��12(�$��64���� -+   $ 	lblVuelto��$��-��$
��Left=�$��309,427,0,0q�$	��Top=�$��12(�$��64���� -,   $ lblEmpleado��$��-��$
��Left=�$��118,102,0,0q�$	��Top=�$��12(�$	��187���� --   $ label_Copy18��$��Restaurant Siglo XXI��$��133,6,134,0q�$	��Top=�$��12(�$
��Bold"��� -.   $ label_Copy19��$'��!Calle Los Laureles #241, Santiago��$��
95,30,94,0q�$	��Top=�$��12(�$
��Bold"��� -/   $ label_Copy6��$��Hora:��$
��Left=�$��216,126,0,0q�$	��Top=�$��12(��� -0   $ label_Copy11��$��Fecha:��$
��Left=�$��
25,126,0,0q�$	��Top=�$��12(��� -1   $ lblFecha��$��-��$
��Left=�$��118,126,0,0q�$	��Top=�$��12(�$��81���� -2   $ lblHora��$��-��$
��Left=�$��262,126,0,0q�$	��Top=�$��12(�$	��101���� -3   $ label_Copy20��$O��I-------------------------------------------------------------------------��$
��Left=�$��	23,42,0,0q�$	��Top=�$��12(�$	��350���� -4   $ label_Copy24��$��Detalle del Pago��$��144,211,144,0q�$	��Top=�$��12(��� -5   $ label_Copy25��$O��I-------------------------------------------------------------------------��$
��Left=�$��
23,228,0,0q�$	��Top=�$��12(�$	��350���� -6   $ label_Copy13��$
��IVA:��$
��Left=�$��
25,330,0,0q�$	��Top=�$��12(��� -7   $ lblIva��$��-��$
��Left=�$��309,330,0,0q�$	��Top=�$��12(�$��64���� -8   $ label_Copy27��$O��I-------------------------------------------------------------------------��$
��Left=�$��
23,349,0,0q�$	��Top=�$��12(�$	��350���� -9   $ label_Copy9��$��Propina:��$
��Left=�$��
25,248,0,0q�$	��Top=�$��12(��� -:   $ 
lblPropina��$��-��$
��Left=�$��309,248,0,0q�$	��Top=�$��12(�$��64���� -;   $ label_Copy28��$��N° de Pedido:��$
��Left=�$��
25,151,0,0q�$	��Top=�$��12(��� -<   $ 	lblPedido��$��-��$
��Left=�$��118,151,0,0q�$	��Top=�$��12(�$��97���� -=   $ label_Copy29��$��N° de Mesa:��$
��Left=�$��
25,177,0,0q�$	��Top=�$��12(��� ->   $ lblMesa��$��-��$
��Left=�$��118,177,0,0q�$	��Top=�$��12(�$��51���� -?   $ label_Copy21��$O��I-------------------------------------------------------------------------��$
��Left=�$��
23,443,0,0q�$	��Top=�$��12(�$	��350���� -@   $ label_Copy22��$ ��Gracias por su preferencia��$��116,461,116,0q�$	��Top=�$��12(��� -A   $ label_Copy23��$O��I-------------------------------------------------------------------------��$
��Left=�$��
23,385,0,0q�$	��Top=�$��12(�$	��350���� -B   $ btnTxt��$ Generar Archivo��$��Generar Archivo��$
��Left=�$��149,510,0,0q�$	��Top=�$ Arrow��$��99��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�