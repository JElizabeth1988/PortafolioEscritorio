   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFListadoEmpleado   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6mah,http://metro.mahapps.com/winfx/xaml/controls   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  localclr-namespace:Vista  -   $��2q�
���   �  � Title$  Lista de Empleados��$��468.166��$	��874��(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � WindowStyle$ 
ToolWindow=����	#FFD2DBEC$
��Bold"� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow�� � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=�.��� ���	#FFDBDFE3.+��� -    ��Name$ image��$
��Left=�$	��437��$	��Top=�$	��879��$��Imagenes/about-img.jpg��$
��Fill=�	 J� Opacity$		 0.3Q�$��0,0,-14.333,-0.333q��� -   
 ��Name$
 btnPasar�� � ToolTip$ Traspasar Información��$��	Traspasar��$
��Left=�$��529,377,0,0q�$	��Top=�$��73��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  J� RenderTransformOrigin$ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(�&   System.Windows.Controls.DataGrid  -     Name$ dgLista��   
IsReadOnly . $��41,145,52.667,0q�$	��Top=�$	��212��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   ��� -   $
 btnSalir��$ Salir��$��Salir��$
��Left=�$��644,377,0,0q�$	��Top=�$��77��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -    ��Name$ 	gbFiltrar��$��Filtrar Información��$
��Left=�$��	41,20,0,0q�$	��Top=�$	��102��$	��577�����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$��96��$��10,0,0,0q�$	��Top=�$	��416��.+��� -    ��Name$ label��$��Rut Empleado:��$
��Left=�$	��Top=�$��	51,-1,0,0q�$	��113��$��12(��� -    ��Name$ txtFiltroRut��*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ej. 11222333-1��$
��Left=�$��23��$��	203,1,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��184��$��Normal"�   ClearTextButton .  �� SelectionBrush �	#FFCB5F21�� -	   $
 btnFiltrarRut��$ Filtrar por Rut��$��Filtrar��$
��Left=�$��420,0,-79,65q�$��Bottom=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -
   $ lblRol��$��Cargo del Empleado:��$
��Left=�$	��Top=�$��	51,34,0,0q�$	��142��$��12(��� -    ��Name$ cboRol��$
��Left=�$��
203,34,0,0q�$	��Top=�$	��184��$��Normal"��� -   $
 btnFiltrarRol��$" Filtrar por Rol del Empleado��$��Filtrar��$
��Left=�$��420,34,-79,33q�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $
 btnFiltrarRutMesa��$ Filtrar por Rut��$��Filtrar��$
��Left=�$��420,3,-79,64q�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $
 btnRefrescar��$ 	Refrescar��$
��Left=�$��776,373,0,0q�$	��Top=�$��36�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  $��36��
���   �����   �� ImageSource$'  !Imagenes/Command-Refresh-Blue.png���� -   $ images��$
��Left=�$��91��$��
663,30,0,0q�$	��Top=�$	��142��$��Imagenes/logoFinal3.png���� -   $
 btnPasarAMesa��$ Traspasar Información��$��	Traspasar��$
��Left=�$��529,377,0,0q�$	��Top=�$��73��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $
 btnRefrescarmesa��$ 	Refrescar��$
��Left=�$��776,373,0,0q�$	��Top=�$��36��#���  $��36��
���   ����� $'  !Imagenes/Command-Refresh-blue.png��