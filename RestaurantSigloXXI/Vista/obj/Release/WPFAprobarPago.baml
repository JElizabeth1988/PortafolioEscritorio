   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFAprobarPago   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6mah,http://metro.mahapps.com/winfx/xaml/controls   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  localclr-namespace:Vista  -   $��2q�
���   �  � Title$"  Visualizar Solicitud de Pago��$��366.716��$��914.762��(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � WindowStyle$ 
ToolWindow=����	#FFD2DBEC$
��Bold"� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow�� � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=�.��� ���	#FFDBDFE3.+��� -    ��Name$ image��$
��Left=�$	��346��$	��Top=�$	��924��$��Imagenes/about-img.jpg��$
��Fill=�	 J� Opacity$		 0.3Q�$��0,0,-18.667,-10.667q��� -   
 ��Name$
 	gbFiltrar��$��Pagos Solicitados��$��41,10,43,18.333q����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��275��$��0,0,0,-3q�$	��Top=�$	��855��.+��� -   $ images��$
��Left=�$��639,0,0,220q�$��98��$��Imagenes/logoFinal3.png��&   System.Windows.Controls.DataGrid  -     Name$ dgLista��   
IsReadOnly . $��
10,55,53,0q�$	��Top=�$	��174��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   ��� -    ��Name$ btnSalir�� � ToolTip$ Cancelar��$��Cancelar��$
��Left=�$��
10,237,0,0q�$	��Top=�$��75��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  J� RenderTransformOrigin$ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -    ��Name$ label��$��Número de Mesa:��$
��Left=�$	��Top=�$��10,6,0,0q�$	��118��$��12(��� -   $ 	btnCodigo��$ Verificar Número de Mesa��$��Filtrar��$
��Left=�$��275,5,0,239q�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -	   $ btnRefrescar��$ 	Refrescar��$
��Left=�$��766,234,0,0q�$	��Top=�$��36�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  $��36��
���   �����  �� ImageSource$' !Imagenes/Command-Refresh-Blue.png���� -
   $ 
btnAprobar��$ Aprobar Pago��$��Aprobar��$
��Left=�$��664,238,0,0q�$	��Top=�$��79��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -    ��Name$ cbMesa��$
��Left=�$��
181,50,0,0q�$	��Top=�$	��120��