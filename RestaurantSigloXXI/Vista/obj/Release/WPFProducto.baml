   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFProducto   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  6mah,http://metro.mahapps.com/winfx/xaml/controls   localclr-namespace:Vista   -   $��2q�
���   �  � Title$  Administrar Producto��$��648.311��$��723.985�� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow��$
��Bold"�(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/logoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=����	#FFDBDFE3.��� $
��Left=�$	��617��$	��Top=�$	��714��$��0,0,0,-1q�.+��� -    ��Name$ image��$
��Left=�$	��634��$	��Top=�$	��728��$��Imagenes/about-img.jpg��$
��Fill=� J� Opacity$	 0.3Q�$��0,0,-14,-17q��� -   	 ��Name$	 groupBox��$��Información de Producto��$��	22,3,20,0q�$	��Top=�$	��256�����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��223��$	��Top=�$	��657��$��0,-2,0,0q���Z� .+��� -    ��Name$ 
label_Copy��$��
Valor ($):��$
��Left=�$��	27,78,0,0q�$	��Top=�$��12(��� -   $ label_Copy1��$��Nombre Producto:��$
��Left=�$��27,4,0,0q�$	��Top=�$��12(��� -   $ label_Copy2��$��Stock:��$
��Left=�$��
27,114,0,0q�$	��Top=�$��12(��� -    ��Name$ 
txtNomProd��$
��Left=�*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Nombre Producto��$��8��$��	160,4,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��195��$��Normal"�   ClearTextButton .  J� RenderTransformOrigin$ 0.5,0.5&� �� SelectionBrush �	#FFCB5F21�� -   $ txtCantidad��$
��Left=�$ Ingrese Cantidad��$��8��$��
160,41,0,0q�$
 Wrap=�$	��Top=�$	��134��$��Normal"� .  �	#FFCB5F21	� -	    	�Name$
 RbKg��$	��Kg.��$
��Left=�$��
305,44,0,0q�$	��Top=�$��50��$��Normal"� 	� 	GroupName$ UMedida�� d� 	IsChecked$
 TrueY�$��10.667(�	� -
   $
 RbGr��$	��Gr.��$
��Left=�$��
351,44,0,0q�$	��Top=�$��41��$��Normal"�$ UMedida��$��10.667(�	� -   $
 RbMl��$	��Ml.��$
��Left=�$��
392,44,0,0q�$	��Top=�$��43��$��Normal"�$ UMedida��$��10.667(�	� -   $	 RbL��$��L.��$
��Left=�$��
436,44,0,0q�$	��Top=�$��37��$��Normal"�$ UMedida��$��10.667(�	� -   $	 RbU��$��U.��$
��Left=�$��
474,44,0,0q�$	��Top=�$��39��$��Normal"�$ UMedida��$��10.667(��� -   $ txtValorUnidad��$
��Left=�$ Ingrese Valor (U)��$��8��$��
160,78,0,0q�$
 Wrap=�$	��Top=�$	��134��$��Normal"� .  �	#FFCB5F21�� -   $ txtStock��$
��Left=�$ Ingrese Stock��$��8��$��160,114,0,0q�$
 Wrap=�$	��Top=�$	��134��$��Normal"� .  �	#FFCB5F21�� -    ��Name$ cboTipoProducto��$
��Left=�$��160,151,0,0q�$	��Top=�$	��196��$��Normal"��� -    ��Name$ 
btnGuardar�� � ToolTip$ Guardar Registro��$��Guardar��$
��Left=�$��119,191,0,0q�$	��Top=�$��75��$ Arrow��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  . $ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -   $ btnCancelar��$ Cancelar��$��Cancelar��$
��Left=�$��495,191,0,0q�$	��Top=�$��75��$��Normal"�$ Arrow�� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ 
btnLimpiar��$ Limpiar Casillas��$��Limpiar��$
��Left=�$��
24,191,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ btnModificar��$ Actualizar Registro��$��
Actualizar��$
��Left=�$��119,191,0,0q�$	��Top=�$ Arrow��$��80��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ label_nom_tipo��$��Tipo de Producto:��$
��Left=�$��
27,151,0,0q�$	��Top=�$ 0.253,0.463&�$��12(��� -   $ lblId��$�� ��$
��Left=�$��
387,10,0,0q�$	��Top=�$��12(�$��18���� -   $ image1��$
��Left=�$��82��$��
493,71,0,0q�$	��Top=�$	��130��$��Imagenes/logoFinal3.png��$ 1.091,0.822&��� -   $ label_Copy5��$��Cantidad por Envase:��$
��Left=�$��	27,41,0,0q�$	��Top=�$��12(��� -   $ 
lbl1_Copy2��$��*��$
��Left=�$��	355,4,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 	lbl1_Copy��$��*��$
��Left=�$��
292,41,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy1��$��*��$
��Left=�$��
294,78,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy3��$��*��$
��Left=�$��294,114,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy4��$��*��$
��Left=�$��361,151,0,0q�$	��Top=�$��12(����	#FF920101�� -   $	 	groupBox1��$��Respaldo Caché��$
��Left=�$��64��$��
22,524,0,0q�$	��Top=�$	��672�����	#FFCB5F21���	#FFCB5F21.��� $��0,0,0.333,-6.667q�.+��� -   $ label2��$��Último Respaldo:��$
��Left=�$��47,1,0,10.667q�$
��Bold"��� -    $ lblCache��$�� ��$
��Left=�$��161,1,0,10.667q�$	��193���� -!   $ btnCache��$ Recuperar Caché��$��	Recuperar��$
��Left=�$��	510,1,0,0q�$	��Top=�$��75��#��[  ���	#FFCB5F21$��12(�$��Normal"�$
 Normal=��� -"   $	 groupBox_Copy��$��Listado de Productos��$��22,264,20,0q�$	��Top=�$	��255�����	#FFCB5F21$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��225��$	��Top=�$	��657��$��	0,-2,0,-3q���Z� .+�&   System.Windows.Controls.DataGrid  -#     Name$ dgLista��   
IsReadOnly . $
��Left=�$��	10,33,0,0q�$	��Top=�$	��147��$	��637��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value  �� Property! �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���   � ��! �	#FFFAA575��   � ��
! �   ��� -$   $ btnRefrescar��$ 	Refrescar��$
��Left=�$��34�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  
���   �$��610,185,0,0q�$��34��$	��Top=����� " �� ImageSource$'" !Imagenes/Command-Refresh-blue.png���� -%   $ btnEliminar��$ Eliminar Registro��$��Eliminar��$
��Left=�$��509,190,0,6q�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFDF0D0D$��12(��� -&   $ btnPasar��$ Traspasar Información��$��	Traspasar��$
��Left=�$	��Top=�$��78��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��
10,190,0,0q�$��29���� -'   $ 
btnFiltrar��$" Filtrar por Tipo de Producto��$��Filtrar��$
��Left=�$��	385,2,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -(   $ cboTipFiltro��$
��Left=�$��	160,2,0,0q�$	��Top=�$	��196��$��Normal"��� -)   $ label_nom_tipo_Copy��$��Tipo de Producto:��$
��Left=�$��35,2,0,0q�$	��Top=�$ 0.253,0.463&�$��12(�