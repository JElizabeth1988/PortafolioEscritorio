   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFBebida   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  6mah,http://metro.mahapps.com/winfx/xaml/controls   localclr-namespace:Vista   -   $��2q�
���   �  � Title$  Administrar Bebidas��$��657.645��$��644.232�� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow��$
��Bold"�(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=����	#FFDBDFE3.��� $
��Left=�$	��628��$	��Top=�$	��640��$��0,0,-5.333,-2.667q�.+��� -    ��Name$ image��$
��Left=�$	��639��$	��Top=�$	��652��$��Imagenes/about-img.jpg��$
��Fill=� J� Opacity$	 0.3Q�$��0,0,-12,-11q��� -   	 ��Name$	 groupBox��$��Información de Bebida��$��
49,10,56,0q�$	��Top=�$	��227�����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��221��$	��Top=�$	��535��$��0,-2,-10.333,-1.667q���Z� .+��� -    ��Name$ 
label_Copy��$��
Valor ($):��$
��Left=�$��	23,67,0,0q�$	��Top=�$��12(��� -    ��Name$ 	txtNombre��$
��Left=�*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese un Nombre��$��8��$��	166,5,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��156��$��Normal"�   ClearTextButton .  J� RenderTransformOrigin$ 0.5,0.5&� �� SelectionBrush �	#FFCB5F21�� -   $ txtMl��$
��Left=�$ Ingrese Cantidad��$��8��$��
166,36,0,0q�$
 Wrap=�$	��Top=�$	��156��$��Normal"� .  �	#FFCB5F21�� -   $ txtValor��$
��Left=�$ Ingrese Valor��$��8��$��
166,67,0,0q�$
 Wrap=�$	��Top=�$	��156��$��Normal"� .  �	#FFCB5F21�� -   $ txtStock��$
��Left=�$ Ingrese Stock��$��8��$��
166,98,0,0q�$
 Wrap=�$	��Top=�$	��156��$��Normal"� .  �	#FFCB5F21�� -	    ��Name$ cboTipo��$
��Left=�$��166,129,0,0q�$	��Top=�$	��156��$��Normal"��� -
    ��Name$ 
btnGuardar�� � ToolTip$ Guardar Registro��$��Guardar��$
��Left=�$��120,160,0,0q�$	��Top=�$��75��$ Arrow��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  . $ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -   $ btnCancelar��$ Cancelar��$��Cancelar��$
��Left=�$��426,160,0,0q�$	��Top=�$��75��$��Normal"�$ Arrow�� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ 
btnLimpiar��$ Limpiar Casillas��$��Limpiar��$
��Left=�$��
23,160,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ btnModificar��$ Actualizar Registro��$��
Actualizar��$
��Left=�$��120,160,0,0q�$	��Top=�$ Arrow��$��80��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ image1��$
��Left=�$��78��$��
367,10,0,0q�$	��Top=�$	��156��$��Imagenes/logoFinal3.png��$ 1.091,0.822&��� -   $ label_Copy7��$��Stock:��$
��Left=�$��	23,98,0,0q�$	��Top=�$��12(��� -   $ label_Copy5��$��Mililitros (Ml):��$
��Left=�$��	23,36,0,0q�$	��Top=�$��12(��� -   $ lblId��$y�Hidden=�$�� ��$
��Left=�$��23,1,0,0q�$	��Top=�$��12(��� -   $ label_Copy1��$��Nombre:��$
��Left=�$��23,5,0,0q�$	��Top=�$��12(��� -   $ label_Copy3��$��Tipo de Bebida:��$
��Left=�$��
23,129,0,0q�$	��Top=�$��12(��� -   $ 
lbl1_Copy2��$��*��$
��Left=�$��	329,6,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 	lbl1_Copy��$��*��$
��Left=�$��
329,36,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy1��$��*��$
��Left=�$��
329,67,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy3��$��*��$
��Left=�$��
329,98,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 
lbl1_Copy4��$��*��$
��Left=�$��329,128,0,0q�$	��Top=�$��12(����	#FF920101�� -   $	 	groupBox1��$��Respaldo Caché��$
��Left=�$��69��$��
49,536,0,0q�$	��Top=�$	��535�����	#FFCB5F21���	#FFCB5F21.��� .+��� -   $ label2��$��Último Respaldo:��$
��Left=�$��27,1,0,0q�$	��Top=�$
��Bold"��� -   $ lblCache��$�� ��$
��Left=�$��	155,1,0,0q�$	��Top=�$	��215���� -   $ btnCache��$ Recuperar Caché��$��	Recuperar��$
��Left=�$��	398,1,0,0q�$	��Top=�$��78��#��[  ���	#FFCB5F21$��12(�$��Normal"�$
 Normal=��� -   $	 groupBox_Copy��$��Listado de Bebidas��$��49,242,56,0q�$	��Top=�$	��289�����	#FFCB5F21$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��263��$	��Top=�$	��525��$��0,-2,-0.333,-7.667q���Z� .+�&   System.Windows.Controls.DataGrid  -     Name$ dgLista��   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    
IsReadOnly . $
��Left=�$��	10,48,0,0q�$	��Top=�$	��163��$	��505��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   ��� -   $ btnRefrescar��$ Refrecar��$
��Left=�$	��Top=�$��36�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  $��36��
���   �$��479,218,0,-32q�����   �� ImageSource$'  !Imagenes/Command-Refresh-blue.png���� -    $ btnEliminar��$ Eliminar��$��Eliminar��$
��Left=�$��379,221,0,-28q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFDF0D0D$��12(�$��29���� -!   $ btnPasar��$ Traspasar Información��$��	Traspasar��$
��Left=�$	��Top=�$��78��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��13,221,0,-28q��� -"   $ 	cbofiltro��$
��Left=�$��
130,10,0,0q�$	��Top=�$	��156��$��Normal"��� -#   $ 
btnFiltrar��$ Filtrar Información��$��Filtrar��$
��Left=�$��
315,10,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -$   $ label_Copy2��$��Tipo de Bebida:��$
��Left=�$��	13,10,0,0q�$	��Top=�$��12(�