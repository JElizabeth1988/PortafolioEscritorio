   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFStockProducto   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  6mah,http://metro.mahapps.com/winfx/xaml/controls   localclr-namespace:Vista   -   $��2q�
���   �  � Title$#  Administrar Stock de Producto��$��568.739��$��702.898�� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow��$
��Bold"�(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=����	#FFDBDFE3.��� $
��Left=�$	��535��$	��Top=�$	��693��.+��� -    ��Name$ image��$
��Left=�$	��553��$	��Top=�$	��711��$��Imagenes/about-img.jpg��$
��Fill=� J� Opacity$	 0.3Q�$��
0,0,-18,-4q��� -   	 ��Name$	 groupBox��$"��Actualizar Stock de Producto��$��39,304,41,0q�$	��Top=�$	��139�����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��106��$	��Top=�$	��564��$��	39,-2,0,0q���Z� .+��� -    ��Name$ 	txtNombre��$
��Left=�*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$  ��$��8��$��95,5,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��156��$��Normal"�   ClearTextButton .   J� RenderTransformOrigin$ 0.5,0.5&� �� SelectionBrush �	#FFCB5F21{�.  �� -   $ txtStock��$
��Left=�$ Ingrese Stock��$��8��$��	95,35,0,0q�$
 Wrap=�$	��Top=�$	��156��$��Normal"� .  �	#FFCB5F21�� -    ��Name$ btnCancelar�� � ToolTip$ Cancelar��$��Cancelar��$
��Left=�$��
293,71,0,0q�$	��Top=�$��75��$��Normal"�$ Arrow��)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase . $ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -   $ 
btnLimpiar��$ Limpiar Casillas��$��Limpiar��$
��Left=�$��	23,71,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ btnModificar��$ Guardar Registro��$��Guardar��$
��Left=�$��
120,71,0,0q�$	��Top=�$ Arrow��$��80��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -	   $ image1��$
��Left=�$��95��$��	412,1,0,0q�$	��Top=�$	��142��$��Imagenes/logoFinal3.png��$ 1.091,0.822&��� -
    ��Name$ label_Copy7��$��Stock:��$
��Left=�$��	23,35,0,0q�$	��Top=�$��12(��� -   $ lblId��$y�Hidden=�$�� ��$
��Left=�$��23,1,0,0q�$	��Top=�$��12(��� -   $ label_Copy1��$��Nombre:��$
��Left=�$��23,5,0,0q�$	��Top=�$��12(��� -   $	 	groupBox1��$��Respaldo Caché��$
��Left=�$��69��$��
39,446,0,0q�$	��Top=�$	��613�����	#FFCB5F21���	#FFCB5F21.��� .+��� -   $ label2��$��Último Respaldo:��$
��Left=�$��27,1,0,0q�$	��Top=�$
��Bold"��� -   $ lblCache��$�� ��$
��Left=�$��	136,1,0,0q�$	��Top=�$	��215���� -   $ btnCache��$ Recuperar Caché��$��	Recuperar��$
��Left=�$��	409,1,0,0q�$	��Top=�$��78��#��[  ���	#FFCB5F21$��12(�$��Normal"�$
 Normal=��� -   $	 groupBox_Copy��$��Seleccionar Producto��$��
39,10,41,0q�$	��Top=�$	��289�����	#FFCB5F21$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��263��$	��Top=�$	��603��$��0,-2,0,-7.667q���Z� .+�&   System.Windows.Controls.DataGrid  -     Name$ dgLista��   
IsReadOnly . $
��Left=�$��	10,48,0,0q�$	��Top=�$	��163��$	��583��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   ��� -   $ btnRefrescar��$ Refrecar��$
��Left=�$	��Top=�$��36�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  $��36��
���   �$��557,214,0,0q�����  �� ImageSource$' !Imagenes/Command-Refresh-blue.png���� -   $ btnPasar��$ Traspasar Información��$��Seleccionar��$
��Left=�$	��Top=�$��78��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��13,221,0,-28q��� -    ��Name$ 	cbofiltro��$
��Left=�$��
130,10,0,0q�$	��Top=�$	��156��$��Normal"��� -   $ 
btnFiltrar��$ Filtrar Información��$��Filtrar��$
��Left=�$��
315,10,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ label_Copy2��$��Tipo de Producto:��$
��Left=�$��	13,10,0,0q�$	��Top=�$��12(�