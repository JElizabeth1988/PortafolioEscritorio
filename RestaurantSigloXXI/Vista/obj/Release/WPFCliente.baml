   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFCliente   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  6mah,http://metro.mahapps.com/winfx/xaml/controls   localclr-namespace:Vista   -   $��2q�
���   �  � Title$  Administrar Cliente��$��580.978��$��695.318�� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow��$
��Bold"�(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=����	#FFDBDFE3.��� $
��Left=�$	��539��$	��Top=�$	��695��$��0,0,-5,-4.333q�.+��� -    ��Name$ image��$
��Left=�$	��556��$	��Top=�$	��701��$��Imagenes/about-img.jpg��$
��Fill=� J� Opacity$	 0.3Q�$��
0,0,-6,-17q��� -   	 ��Name$	 groupBox��$��Información de Cliente��$��
49,10,50,0q�$	��Top=�$	��451�����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��436��$	��Top=�$	��586��$��0,-2,0,-0.667q���Z� .+��� -    ��Name$ label��$
��Rut:��$
��Left=�$��	23,25,0,0q�$	��Top=��� -   $ 
label_Copy��$��Apellido Paterno:��$
��Left=�$��
23,137,0,0q�$	��Top=��� -   $ label_Copy1��$��Primer Nombre:��$
��Left=�$��	23,61,0,0q�$	��Top=��� -   $ label_Copy2��$��Email:��$
��Left=�$��
23,213,0,0q�$	��Top=��� -   $ label_Copy3��$��Celular:��$
��Left=�$��
23,253,0,0q�$	��Top=��� -	   $ label_Copy4��$��
Teléfono:��$
��Left=�$��
23,290,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.73,-0.613&��� -
    ��Name$ txtRut��$
��Left=�*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Rut sin DV��$��8��$��
156,25,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��136��$��Normal"�   ClearTextButton .  �� SelectionBrush �	#FFCB5F21�� -   $ 	txtNombre��$
��Left=�$ Ingrese Nombres ��$��8��$��
156,61,0,0q�$
 Wrap=�$	��Top=�$	��195��$��Normal"� . $ 0.5,0.5&� �	#FFCB5F21�� -   $ txtSegNombre��$
��Left=�$ Ingrese Seg. Nombre��$��8��$��
156,99,0,0q�$
 Wrap=�$	��Top=�$	��196��$��Normal"� .  �	#FFCB5F21�� -   $ txtApPaterno��$
��Left=�$ Ingrese Apellido Paterno��$��8��$��156,137,0,0q�$
 Wrap=�$	��Top=�$	��196��$��Normal"� .  �	#FFCB5F21�� -   $ txtApeMaterno��$
��Left=�$ Ingrese Apellido Materno ��$��8��$��156,175,0,0q�$
 Wrap=�$	��Top=�$	��196��$��Normal"� .  �	#FFCB5F21�� -   $ txtEmail��$
��Left=�$ Ingrese Email��$��8��$��156,213,0,0q�$
 Wrap=�$	��Top=�$	��196��$��Normal"� .  �	#FFCB5F21�� -   $ 
txtCelular��$
��Left=�$ Ej. 988888888��$��8��$��156,253,0,0q�$
 Wrap=�$	��Top=�$	��136��$��Normal"� .  �	#FFCB5F21�� -   $ txtTelefono��$
��Left=�$ Ej. 288888888��$��8��$��156,290,0,0q�$
 Wrap=�$	��Top=�$	��136��$��Normal"� .  �	#FFCB5F21�� -    ��Name$ 
btnGuardar�� � ToolTip$ Guardar Registro��$��Guardar��$
��Left=�$��136,368,0,0q�$	��Top=�$��75��$ Arrow��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  . $ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -   $ btnCancelar��$ Cancelar��$��Cancelar��$
��Left=�$��472,368,0,0q�$	��Top=�$��75��$��Normal"�$ Arrow�� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ btnPregunta��$ Ver Listado de Clientes��$��?��$
��Left=�$��
370,25,0,0q�$	��Top=�$��33��$��Normal"�$��25��$ Arrow�� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ 	btnBuscar��$ Buscar Cliente��$��Buscar��$
��Left=�$��
418,25,0,0q�$	��Top=�$��25��$��64��$ Arrow��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ 
btnLimpiar��$ Limpiar Casillas��$��Limpiar��$
��Left=�$��
28,368,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ btnModificar��$ Actualizar Registro��$��
Actualizar��$
��Left=�$��136,368,0,0q�$	��Top=�$ Arrow��$��80��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ image1��$
��Left=�$��78��$��
407,76,0,0q�$	��Top=�$	��156��$��Imagenes/logoFinal3.png��$ 1.091,0.822&��� -   $ txtDV��$
��Left=�$��23��$��
321,25,0,0q�$
 Wrap=�$	��Top=�$��30��$ 0.422,0.462&�$��Normal"�{�.  �� -   $ label1��$��-��$
��Left=�$��
298,25,0,0q�$	��Top=�$��18���� -   $ label_Copy7��$��Apellido Materno:��$
��Left=�$��
23,175,0,0q�$	��Top=��� -   $ label_Copy5��$��Segundo Nombre:��$
��Left=�$��	23,99,0,0q�$	��Top=��� -   $ btnEliminar��$ Eliminar Registro��$��Eliminar��$
��Left=�$��251,368,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFDF0D0D$��12(��� -   $
 lbl1��$��*��$
��Left=�$��
351,25,0,0q�$	��Top=�$��12(����	#FF920101�� -   $ 	lbl1_Copy��$��*��$
��Left=�$��
351,62,0,0q�$	��Top=�$��12(����	#FF920101�� -    $ 
lbl1_Copy1��$��*��$
��Left=�$��292,253,0,0q�$	��Top=�$��12(����	#FF920101�� -!   $ 
lbl1_Copy2��$��*��$
��Left=�$��351,137,0,0q�$	��Top=�$��12(����	#FF920101�� -"   $ 
lbl1_Copy4��$��*��$
��Left=�$��351,213,0,0q�$	��Top=�$��12(����	#FF920101�� -#   $	 	groupBox1��$��Respaldo Caché��$
��Left=�$��73��$��
49,466,0,0q�$	��Top=�$	��596�����	#FFCB5F21���	#FFCB5F21.��� .+��� -$   $ label2��$��Último Respaldo:��$
��Left=�$��27,3,0,0q�$	��Top=�$
��Bold"��� -%   $ lblCache��$�� ��$
��Left=�$��	130,3,0,0q�$	��Top=�$	��215���� -&   $ btnCache��$ Recuperar Caché��$��	Recuperar��$
��Left=�$��	472,3,0,0q�$	��Top=�$��75��#��[  ���	#FFCB5F21$��12(�$��Normal"�$
 Normal=�