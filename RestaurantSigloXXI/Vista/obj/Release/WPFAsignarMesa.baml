   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFAsignarMesa   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6mah,http://metro.mahapps.com/winfx/xaml/controls   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  localclr-namespace:Vista  -   $��2q�
���   �  � Title$  Asignar Mesa��$��589.637��$��844.813��(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � WindowStyle$ 
ToolWindow=����	#FFD2DBEC$
��Bold"� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow�� � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=�.��� ���	#FFDBDFE3.+��� -    ��Name$ image��$
��Left=�$	��572��$	��Top=�$	��852��$��Imagenes/about-img.jpg��$
��Fill=�	 J� Opacity$		 0.3Q�$��0,0,-16.667,-13.333q��� -   
 ��Name$
 	gbFiltrar��$��Buscar Información��$��41,7,248.333,436q����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$��73��$��10,4,0,-10.333q�$	��Top=�$	��596��.+��� -    ��Name$ 
label_Copy��$��Rut Cliente:��$
��Left=�$	��Top=�$��-1,1,0,0q�$��93��$��12(��� -    ��Name$ txtRut��*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ej. 11222333-1��$
��Left=�$��23��$��81,1,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��128��$��Normal"�   ClearTextButton .  �� SelectionBrush �	#FFCB5F21�� -    ��Name$ btnRut�� � ToolTip$ Buscar Cliente��$��Buscar��$
��Left=�$��
271,1,0,45q�$��75��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  J� RenderTransformOrigin$ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -   $ label_Copy1��$��Nombre:��$
��Left=�$	��Top=�$��	-1,32,0,0q�$��93��$��12(��� -   $ btnCrear��$ Crear Nuevo Registro��$��Nuevo Cliente��$
��Left=�$��
362,1,0,45q�$��98��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -	   $ 	txtNombre��$  ��{�.  $
��Left=�$��23��$��	81,32,0,0q�$
 Wrap=�$	��Top=�$	��166��$��Normal"� �	#FFCB5F21�� -
   $ 
btnLimpiar��$ Limpiar Casillas��$��Limpiar��$
��Left=�$��
385,33,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ btnPregunta��$ Ver Listado de Clientes��$��?��$
��Left=�$��	229,1,0,0q�$	��Top=�$��33��$��Normal"�$��27��$ Arrow�� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ 
lbl1_Copy2��$��*��$
��Left=�$��	209,2,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ images��$
��Left=�$��603,0,0,448q�$	��156��$��Imagenes/logoFinal3.png��$��99��$��Bottom=��� -   $
 GroupBox_mesas��$��Mesas��$��41,127,53.333,26q����	#FFCB5F21$ Upper=�$��13.333(����	#FFCB5F21.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ dgLista��   
IsReadOnly . $��24,40,23,49q�$��Normal"��� -   $ btnSalir��$ Cancelar��$��Cancelar��$
��Left=�$��
24,335,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ btnRefrescar��$ 	Refrescar��$
��Left=�$	��Top=�$��36�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  $��36��
���   �$��672,327,0,0q�����  �� ImageSource$' !Imagenes/Command-Refresh-blue.png���� -   $ 
btnAsignar��$ Asignar mesa a cliente��$��Asignar��$
��Left=�$��561,335,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ label_Copy2��$��Asignación de Mesa:��$
��Left=�$	��Top=�$��24,7,0,0q�$	��131��$��12(��� -   $ btnFiltrarAsignacion��$$ Filtrar por asignacion de mesa��$��Filtrar��$
��Left=�$��	320,7,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�	� -    	�Name$ RbOnline��$��Online��$
��Left=�$��
156,11,0,0q�$	��Top=�$��66��$
��Bold"� 	� 	GroupName$ 
Asignacion�� d� 	IsChecked$
 TrueY�	� -   $ RbPresencial��$��
Presencial��$
��Left=�$��
227,11,0,0q�$	��Top=�$��89��$
��Bold"�$ 
Asignacion��$
 TrueY�