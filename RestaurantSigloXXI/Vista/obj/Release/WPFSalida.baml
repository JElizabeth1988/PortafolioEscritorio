   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFSalida   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6mah,http://metro.mahapps.com/winfx/xaml/controls   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  localclr-namespace:Vista  -   $��2q�
���   �  � Title$!  Notificar Salida de Cliente��$��366.716��$��627.341��(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � WindowStyle$ 
ToolWindow=����	#FFD2DBEC$
��Bold"� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow�� � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=�.��� ���	#FFDBDFE3.+��� -    ��Name$ image��$
��Left=�$	��346��$	��Top=�$	��627��$��Imagenes/about-img.jpg��$
��Fill=�	 J� Opacity$		 0.3Q�$��0,0,-9,-10.667q��� -   
 ��Name$
 	gbFiltrar��$��Notificación��$��41,10,43,18.333q����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��271��$��0,4,0,-3q�$	��Top=�$	��524��.+��� -   $ images��$
��Left=�$��408,0,0,221q�$��91��$��Imagenes/logoFinal3.png��&   System.Windows.Controls.DataGrid  -     Name$ dgLista��   
IsReadOnly . $��
10,55,25,0q�$	��Top=�$	��169��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   ��� -    ��Name$ btnSalir�� � ToolTip$ Cancelar��$��Cancelar��$
��Left=�$��
10,233,0,0q�$	��Top=�$��75��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  J� RenderTransformOrigin$ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -    ��Name$ label��$��Número de Mesa:��$
��Left=�$	��Top=�$��10,6,0,0q�$	��118��$��12(��� -    ��Name$ 	txtCodigo��*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese N°��$
��Left=�$��23��$��	126,6,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��99��$��Normal"�   ClearTextButton .  �� SelectionBrush �	#FFCB5F21�� -	   $ 	btnCodigo��$ Verificar Número de Mesa��$��	Verificar��$
��Left=�$��240,6,0,238q�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -
   $ btnRefrescar��$ 	Refrescar��$
��Left=�$��461,229,0,0q�$	��Top=�$��36�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  $��36��
���   �����  �� ImageSource$' !Imagenes/Command-Refresh-Blue.png���� -   $ 	btnSalida��$! Notificar Salida de Cliente��$��Notificar Salida��$
��Left=�$��321,233,0,0q�$	��Top=�$	��112��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ btnVer��$ Ver Mesas Ocupadas��$��?��$
��Left=�$��321,6,0,238q�$��32��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�