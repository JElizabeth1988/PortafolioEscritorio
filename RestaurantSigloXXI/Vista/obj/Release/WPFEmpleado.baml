   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFEmpleado   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  6mah,http://metro.mahapps.com/winfx/xaml/controls   localclr-namespace:Vista   -   $��2q�
���   �  � Title$  Administrar Empleado��$��638.312��$��695.318�� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow��$
��Bold"�(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=����	#FFDBDFE3.��� $
��Left=�$	��640��$	��Top=�$	��695��$��0,0,-9,0q�.+��� -    ��Name$ image��$
��Left=�$	��616��$	��Top=�$	��701��$��Imagenes/about-img.jpg��$
��Fill=� J� Opacity$	 0.3Q�$��0,0,-6,0q��� -   	 ��Name$	 groupBox��$��Información de Empleado��$��
49,10,50,0q�$	��Top=�$	��495�����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��461��$	��Top=�$	��586��$��0,-2,0,0q���Z� .+��� -    ��Name$ label��$
��Rut:��$
��Left=�$��	23,25,0,0q�$	��Top=��� -   $ 
label_Copy��$��Apellido Paterno:��$
��Left=�$��
23,130,0,0q�$	��Top=��� -   $ label_Copy1��$��Primer Nombre:��$
��Left=�$��	23,60,0,0q�$	��Top=��� -   $ label_Copy2��$��Email:��$
��Left=�$��
23,200,0,0q�$	��Top=��� -   $ label_Copy3��$��Celular:��$
��Left=�$��
23,235,0,0q�$	��Top=��� -	   $ label_Copy4��$��
Teléfono:��$
��Left=�$��
23,270,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.73,-0.613&��� -
   $ label_Copy6��$��
Usuario:
��$
��Left=�$��
23,305,0,0q�$	��Top=�$ 0.73,-0.613&�$��26���� -    ��Name$ txtRut��$
��Left=�*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Rut sin DV��$��8��$��
156,25,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��140��$��Normal"�   ClearTextButton .  �� SelectionBrush �	#FFCB5F21�� -   $ 	txtNombre��$
��Left=�$ Ingrese Nombre ��$��8��$��
156,60,0,0q�$
 Wrap=�$	��Top=�$	��195��$��Normal"� . $ 0.5,0.5&� �	#FFCB5F21�� -   $ txtSegNombre��$
��Left=�$ Ingrese Seg. Nombre��$��8��$��
156,95,0,0q�$
 Wrap=�$	��Top=�$	��196��$��Normal"� .  �	#FFCB5F21�� -   $ txtApPaterno��$
��Left=�$ Ingrese Apellido Paterno��$��8��$��156,130,0,0q�$
 Wrap=�$	��Top=�$	��196��$��Normal"� .  �	#FFCB5F21�� -   $ txtApeMaterno��$
��Left=�$ Ingrese Apellido Materno ��$��8��$��156,165,0,0q�$
 Wrap=�$	��Top=�$	��196��$��Normal"� .  �	#FFCB5F21�� -   $ txtEmail��$
��Left=�$ Ingrese Email��$��8��$��156,200,0,0q�$
 Wrap=�$	��Top=�$	��196��$��Normal"� .  �	#FFCB5F21�� -   $ 
txtCelular��$
��Left=�$ Ej. 988888888��$��8��$��156,235,0,0q�$
 Wrap=�$	��Top=�$	��140��$��Normal"� .  �	#FFCB5F21�� -   $ txtTelefono��$
��Left=�$ Ej. 288888888��$��8��$��156,270,0,0q�$
 Wrap=�$	��Top=�$	��140��$��Normal"� .  �	#FFCB5F21�� -   $ txtUser��$
��Left=�$ Nombre de Usuario��{�.  $��8��$��156,305,0,0q�$
 Wrap=�$	��Top=�$	��140��$��Normal"� .   �	#FFCB5F21�� -   $ txtPass��$
��Left=�$ Password��$��8��$��156,340,0,0q�$
 Wrap=�$	��Top=�$	��140��$��Normal"� .  �	#FFCB5F21�� -    ��Name$ cboTipoUser��$
��Left=�$��156,375,0,0q�$	��Top=�$	��195��$��Normal"��� -    ��Name$ 
btnGuardar�� � ToolTip$ Guardar Registro��$��Guardar��$
��Left=�$��131,422,0,0q�$	��Top=�$��75��$ Arrow��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  . $ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -   $ btnCancelar��$ Cancelar��$��Cancelar��$
��Left=�$��473,422,0,0q�$	��Top=�$��75��$��Normal"�$ Arrow�� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ btnPregunta��$ Listado de Empleados��$��?��$
��Left=�$��
370,25,0,0q�$	��Top=�$��33��$��Normal"�$��25��$ Arrow�� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ 	btnBuscar��$ Buscar Cliente��$��Buscar��$
��Left=�$��
418,25,0,0q�$	��Top=�$��25��$��64��$ Arrow��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ 
btnLimpiar��$ Limpiar��$��Limpiar��$
��Left=�$��
23,422,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ btnModificar��$ Actualizar Registro��$��
Actualizar��$
��Left=�$��131,422,0,0q�$	��Top=�$ Arrow��$��80��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ image1��$
��Left=�$��78��$��
407,76,0,0q�$	��Top=�$	��156��$��Imagenes/logoFinal3.png��$ 1.091,0.822&��� -   $ txtDV��$
��Left=�$��23��$��
321,25,0,0q�$
 Wrap=�$	��Top=�$��30��$ 0.422,0.462&�$��Normal"�{�.  �� -   $ label1��$��-��$
��Left=�$��
298,25,0,0q�$	��Top=�$��18���� -   $ label_Copy7��$��Apellido Materno:��$
��Left=�$��
23,165,0,0q�$	��Top=��� -    $ label_Copy5��$��Segundo Nombre:��$
��Left=�$��	23,95,0,0q�$	��Top=��� -!   $ btnEliminar��$ Eliminar Registro��$��Eliminar��$
��Left=�$��244,422,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFDF0D0D$��12(��� -"   $ label_Copy8��$��Contraseña:
��$
��Left=�$��
23,340,0,0q�$	��Top=�$ 0.73,-0.613&�$��32���� -#   $ label_Copy9��$��Cargo:
��$
��Left=�$��
23,375,0,0q�$	��Top=�$ 0.73,-0.613&�$��32���� -$   $ btnGenerarPass��$ Generar Contraseña��$��Generar��$
��Left=�$��321,338,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -%   $ 
lbl1_Copy5��$��*��$
��Left=�$��
351,27,0,0q�$	��Top=�$��12(����	#FF920101�� -&   $ 	lbl1_Copy��$��*��$
��Left=�$��
351,59,0,0q�$	��Top=�$��12(����	#FF920101�� -'   $ 
lbl1_Copy1��$��*��$
��Left=�$��351,130,0,0q�$	��Top=�$��12(����	#FF920101�� -(   $ 
lbl1_Copy2��$��*��$
��Left=�$��351,165,0,0q�$	��Top=�$��12(����	#FF920101�� -)   $ 
lbl1_Copy3��$��*��$
��Left=�$��351,203,0,0q�$	��Top=�$��12(����	#FF920101�� -*   $ 
lbl1_Copy4��$��*��$
��Left=�$��296,235,0,0q�$	��Top=�$��12(����	#FF920101�� -+   $ 
lbl1_Copy6��$��*��$
��Left=�$��296,305,0,0q�$	��Top=�$��12(����	#FF920101�� -,   $ 
lbl1_Copy7��$��*��$
��Left=�$��296,340,0,0q�$	��Top=�$��12(����	#FF920101�� --   $ 
lbl1_Copy8��$��*��$
��Left=�$��352,375,0,0q�$	��Top=�$��12(����	#FF920101�� -.   $	 	groupBox1��$��Respaldo Caché��$
��Left=�$��73��$��
49,514,0,0q�$	��Top=�$	��596�����	#FFCB5F21���	#FFCB5F21.��� .+��� -/   $ label2��$��Último Respaldo:��$
��Left=�$��27,3,0,0q�$	��Top=�$
��Bold"��� -0   $ lblCache��$�� ��$
��Left=�$��	130,3,0,0q�$	��Top=�$	��215���� -1   $ btnCache��$ Recuperar Caché��$��	Recuperar��$
��Left=�$��	474,3,0,0q�$	��Top=�$��75��#��[  ���	#FFCB5F21$��12(�$��Normal"�$
 Normal=�