   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFCalcularPedido   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  6mah,http://metro.mahapps.com/winfx/xaml/controls   localclr-namespace:Vista   -   $��2q�
���   �  � Title$!  Calcular Pedido a Proveedor��$��610.645��$��1199.508�� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow��$
��Bold"�(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/logoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=����	#FFDBDFE3.��� $
��Left=�$	��577��$	��Top=�$
��1190��.+��� -    ��Name$ image��$
��Left=�$	��597��$	��Top=�$
��1202��$��Imagenes/about-img.jpg��$
��Fill=� J� Opacity$	 0.3Q�$��0,0,-12,-20q��� -   	 ��Name$	 	groupBox1��$��Detalle Pedido��$
��Left=�$	��Top=�$��	23,10,0,0q�$	��706�����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�$��13.333(����	#FFCB5F21$	��534��.��� .+��� -   $	 groupBox��$��Información de Producto��$��8,314,9.667,0q�$	��Top=�$	��166�����	#FFCB5F21$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��137��$	��Top=�$	��561��$��0,-2,-0.333,-4.333q���Z� .+��� -    ��Name$ 
label_Copy��$��
Valor ($):��$
��Left=�$��	27,34,0,0q�$	��Top=�$��12(��� -   $ label_Copy1��$��Nombre Producto:��$
��Left=�$��27,4,0,0q�$	��Top=�$��12(��� -    ��Name$ 
txtNomProd��$
��Left=�$��8��$��	160,4,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��195��$��Normal"�*   $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton .  {�.   J� RenderTransformOrigin$ 0.5,0.5&� �� SelectionBrush �	#FFCB5F21�� -   $ txtValorUnidad��$
��Left=�$��8��$��
160,34,0,0q�$
 Wrap=�$	��Top=�{�.  $	��134��$��Normal"� .   �	#FFCB5F21�� -	    ��Name$ btnPasar�� � ToolTip$ Agregar Producto��$��Agregar��$
��Left=�$��
322,96,0,0q�$	��Top=�$��75��$ Arrow��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  . $ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -
   $ image1��$
��Left=�$��90��$��	425,4,0,0q�$	��Top=�$	��123��$��Imagenes/logoFinal3.png��$ 1.091,0.822&��� -   $ 
lbl1_Copy2��$��*��$
��Left=�$��	355,4,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy1��$��*��$
��Left=�$��
294,34,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy3��$��*��$
��Left=�$��
294,65,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ txtCantidad��$
��Left=�   	Watermark$ Ingrese Cantidad��$��8��$��
160,64,0,0q�$
 Wrap=�$	��Top=�$	��134��$��Normal"� .  �	#FFCB5F21�� -   $ label_Copy3��$��	Cantidad:��$
��Left=�$��	27,64,0,0q�$	��Top=�$��12(��� -   $ 
btnAgregar��$ Agregar Artículos��$��Agregar��$
��Left=�$��
322,96,0,0q�$	��Top=�$��77��$ Arrow��$��Normal"� .  . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $	 groupBox_Copy��$��Productos con Bajo Stock ��$��
8,54,333,0q�$	��Top=�$	��255�����	#FFCB5F21$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��222��$	��Top=�$	��346��$��0,-2,0,0q���Z� .+�&   System.Windows.Controls.DataGrid  -     Name$ dgListaProducto��   
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * $
��Left=�$��0,10,0,0q�$	��Top=�$	��170��$	��346��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   ��� -   $ btnRefrescar��$ 	Refrescar��$
��Left=�$��34�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  
���   �$��302,185,0,0q�$��34��$	��Top=�����  �� ImageSource$' !Imagenes/Command-Refresh-blue.png���� -   $ btnSeleccionarProd��$ Seleccionar un Registro��$��Seleccionar��$
��Left=�$	��Top=�$��78��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��
10,190,0,0q�$��29���� -   $	 groupBox_Copy1��$��Bebidas con Bajo Stock ��$��369,54,9.667,0q�$	��Top=�$	��255�����	#FFCB5F21$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��221��$	��Top=�$	��308��$��0,-2,0,0q���Z� .+�  -   $ dgListaBebida��$ *  . $
��Left=�$��0,10,0,0q�$	��Top=�$	��170��$	��308��$��Normal"����	#FFCB5F21
���   � ��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   ��� -   $ btnRefrescar1��$ 	Refrescar��$
��Left=�$��34��#���  
���   �$��264,185,0,0q�$��34��$	��Top=����� $' !Imagenes/Command-Refresh-blue.png���� -   $ btnSeleccionarBebida��$ Seleccionar un Registro��$��Seleccionar��$
��Left=�$	��Top=�$��78��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��
10,190,0,0q�$��29���� -   $ label_Copy5��$��Seleccione Proveedor:��$
��Left=�$��	10,10,0,0q�$	��Top=�$��12(��� -     ��Name$  cbProveedor��$
��Left=�$��
162,10,0,0q�$	��Top=�$	��171��$��Normal"��� -   $	 groupBox_Copy2��$��Verificar Pedido��$��734,10,23,0q�$	��Top=�$	��534�����	#FFCB5F21$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��503��$	��Top=�$	��424��$��0,-2,0,-2.333q���Z� .+�  -   $ dgListaPedido�� . $ * $
��Left=�$��	10,45,0,0q�$	��Top=�$	��353��$	��404��$��Normal"����	#FFCB5F21
���   � ��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   ��� -   $ 
btnGuardar��$ Guardar Pedido��$��Guardar��$
��Left=�$	��Top=�$��78��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��239,446,0,0q�$��29���� -   $ label_Copy2��$��Total del Pedido:��$
��Left=�$��
19,403,0,0q�$	��Top=�$��12(��� -   $ lblTotal��$��-��$
��Left=�$��128,403,0,0q�$	��Top=�$��12(��� -    $ btnEliminar��$+ %Quitar registro de la lista de Pedido��$��Quitar��$
��Left=�$	��Top=�$��78��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��
19,446,0,0q�$��29���� -!   $ label_Copy4��$��Número de Pedido:��$
��Left=�$��	10,10,0,0q�$	��Top=�$��12(��� -"   $ 	lblNumero��$��-��$
��Left=�$��
134,10,0,0q�$	��Top=�$��12(��� -#   $ btnCancelar��$ Cancelar Operación��$��Cancelar��$
��Left=�$��339,446,0,0q�$	��Top=�$��75��$��Normal"�$ Arrow�� . $ 1.662,0.727&�#��[  ���	#FFA11400$��12(�