   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFProveedor   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  6mah,http://metro.mahapps.com/winfx/xaml/controls   localclr-namespace:Vista   -   $��2q�
���   �  � Title$  Administrar Proveedor��$��662.312��$��740.651�� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow��$
��Bold"�(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=����	#FFDBDFE3.��� $
��Left=�$	��630��$	��Top=�$	��731��.+��� -    ��Name$ image��$	��639��$	��Top=�$��Imagenes/about-img.jpg��$
��Fill=� J� Opacity$	 0.3Q�$��
0,0,-13,-9q�$
��Left=�$	��744���� -   	 ��Name$	 groupBox��$��Información de Proveedor��$��
49,12,51,0q�$	��Top=�$	��237�����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=����	#FFCB5F21.��� $
��Left=�$	��208��$	��Top=�$	��621��$��0,-2,-0.333,-3.333q���Z� .+��� -    ��Name$ 
label_Copy��$��
Sitio Web:��$
��Left=�$��
23,127,0,0q�$	��Top=�$��12(��� -   $ label_Copy3��$��
Teléfono:��$
��Left=�$��	23,65,0,0q�$	��Top=�$��12(��� -    ��Name$ 	txtNombre��$
��Left=�*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Nombre��$��8��$��	166,3,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��174��$��Normal"�   ClearTextButton .  �� SelectionBrush �	#FFCB5F21�� -   $ txtTelefono��$
��Left=�$ Ej: 999888777��$��8��$��
166,65,0,0q�$
 Wrap=�$	��Top=�$	��125��$��Normal"� .  �	#FFCB5F21�� -   $ 	txtCorreo��$
��Left=�$ Ingrese Email��$��8��$��
166,34,0,0q�$
 Wrap=�$	��Top=�$	��232��$��Normal"� .  J� RenderTransformOrigin$ 0.5,0.5&� �	#FFCB5F21�� -	    ��Name$ 
btnGuardar�� � ToolTip$ Guardar Registro��$��Guardar��$
��Left=�$��132,172,0,0q�$	��Top=�$��75��$ Arrow��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  . $ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -
   $ btnCancelar��$ Cancelar��$��Cancelar��$
��Left=�$��508,172,0,0q�$	��Top=�$��75��$��Normal"�$ Arrow�� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ 
btnLimpiar��$ Limpiar Casillas��$��Limpiar��$
��Left=�$��
27,172,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ image1��$
��Left=�$��78��$��
440,10,0,0q�$	��Top=�$	��156��$��Imagenes/logoFinal3.png��$ 1.091,0.822&��� -   $ label_Copy5��$��Dirección:��$
��Left=�$��	23,96,0,0q�$	��Top=�$��12(��� -   $ btnModificar��$ Actualizar Registro��$��
Actualizar��$
��Left=�$��132,172,0,0q�$	��Top=�$ Arrow��$��80��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ LblId��$�� ��$y�Hidden=�$
��Left=�$��	388,0,0,0q�$	��Top=�$��12(��� -   $ label_Copy1��$��Correo Electrónico:��$
��Left=�$��	23,34,0,0q�$	��Top=�$��12(��� -   $ label_Copy2��$��Nombre:��$
��Left=�$��27,3,0,0q�$	��Top=�$��12(��� -   $ txtDireccion��$
��Left=�$ Ingrese Dirección��$��8��$��
166,96,0,0q�$
 Wrap=�$	��Top=�$	��232��$��Normal"� . $ 0.5,0.5&� �	#FFCB5F21�� -   $ txtWeb��$
��Left=�$ Ingrese Sitio Web��$��8��$��166,127,0,0q�$
 Wrap=�$	��Top=�$	��174��$��Normal"� . $ 0.5,0.5&� �	#FFCB5F21�� -   $ 
lbl1_Copy2��$��*��$
��Left=�$��	340,3,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 	lbl1_Copy��$��*��$
��Left=�$��
398,34,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy1��$��*��$
��Left=�$��
291,65,0,0q�$	��Top=�$��12(����	#FF920101�� -   $	 	groupBox1��$��Respaldo Caché��$
��Left=�$��69��$��
49,536,0,0q�$	��Top=�$	��631�����	#FFCB5F21���	#FFCB5F21.��� .+��� -   $ label2��$��Último Respaldo:��$
��Left=�$��23,1,0,0q�$	��Top=�$
��Bold"��� -   $ lblCache��$�� ��$
��Left=�$��	130,0,0,0q�$	��Top=�$	��215���� -   $ btnCache��$ Recuperar Caché��$��	Recuperar��$
��Left=�$��	454,1,0,0q�$	��Top=�$��78��#��[  ���	#FFCB5F21$��12(�$��Normal"�$
 Normal=��� -   $	 groupBox_Copy��$��Listado de Proveedores��$��49,254,51,0q�$	��Top=�$	��277�����	#FFCB5F21$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��250��$	��Top=�$	��621��$��0,-2,-0.333,-6.667q���Z� .+�&   System.Windows.Controls.DataGrid  -     Name$ dgLista��   
IsReadOnly . $
��Left=�$��	18,10,0,0q�$	��Top=�$	��191��$	��583��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   ��� -   $ btnRefrescar��$ 	Refrescar��$
��Left=�$	��Top=�$��36�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  $��35��
���   �$��563,201,0,0q�����  �� ImageSource$' !Imagenes/Command-Refresh-blue.png���� -   $ btnEliminar��$ Eliminar Registro��$��Eliminar��$
��Left=�$��454,208,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFDF0D0D$��12(��� -   $ btnPasar��$ Traspasar Información��$��	Traspasar��$
��Left=�$	��Top=�$��78��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��
18,208,0,0q�