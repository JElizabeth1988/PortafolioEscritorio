   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFReserva   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6mah,http://metro.mahapps.com/winfx/xaml/controls   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  localclr-namespace:Vista  -   $��2q�
���   �  � Title$  Verificar Reserva��$��397.002��$��844.813��(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � WindowStyle$ 
ToolWindow=����	#FFD2DBEC$
��Bold"� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow�� � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=�.��� ���	#FFDBDFE3.+��� -    ��Name$ image��$
��Left=�$	��384��$	��Top=�$	��852��$��Imagenes/about-img.jpg��$
��Fill=�	 J� Opacity$		 0.3Q�$��0,0,-16.667,-18q��� -   
 ��Name$
 	gbFiltrar��$��Buscar Información��$��41,21,42.333,31q����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��260��$��10,4,0,0q�$	��Top=�$	��732��.+��� -   $ images��$
��Left=�$��544,0,0,185q�$	��164��$��Imagenes/logoFinal3.png��&   System.Windows.Controls.DataGrid  -     Name$ dgLista��   
IsReadOnly . $��
10,80,21,0q�$	��Top=�$	��123��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   ��� -    ��Name$ btnSalir�� � ToolTip$ Cancelar��$��Cancelar��$
��Left=�$��
10,228,0,0q�$	��Top=�$��75��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  J� RenderTransformOrigin$ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -    ��Name$ label��$��Código de Reserva:��$
��Left=�$	��Top=�$��46,3,0,0q�$	��123��$��12(��� -    ��Name$ 	txtCodigo��*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Código��$
��Left=�$��23��$��	169,3,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��145��$��Normal"�   ClearTextButton .  �� SelectionBrush �	#FFCB5F21�� -	   $ 	btnCodigo��$# Verificar Reserva por Código��$��	Verificar��$
��Left=�$��339,3,0,232q�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -
   $ 
label_Copy��$��Rut Cliente:��$
��Left=�$	��Top=�$��	46,36,0,0q�$��93��$��12(��� -   $ txtRut��$ Ej. 11222333-1��$
��Left=�$��23��$��
170,36,0,0q�$
 Wrap=�$	��Top=�$	��144��$��Normal"� .  �	#FFCB5F21�� -   $ btnRut��$* $Verificar Reserva por Rut de Cliente��$��	Verificar��$
��Left=�$��339,36,0,198q�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ btnRefrescar��$ 	Refrescar��$
��Left=�$��675,226,0,-2q�$	��Top=�$��36�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  $��36��
���   �����  �� ImageSource$' !Imagenes/Command-Refresh-Blue.png���� -   $ 
btnIngreso��$" Notificar Ingreso de Cliente��$��Notificar Ingreso��$
��Left=�$��525,228,0,0q�$	��Top=�$	��112��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ btnReservas��$ Verificar Reservas��$��?��$
��Left=�$��426,3,0,232q�$��25��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�