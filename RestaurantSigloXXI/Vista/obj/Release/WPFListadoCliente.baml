   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFListadoCliente   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6mah,http://metro.mahapps.com/winfx/xaml/controls   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  localclr-namespace:Vista  -   $��2q�
���   �  � Title$  Lista de Clientes��$��488.335��$��916.813��(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � WindowStyle$ 
ToolWindow=����	#FFD2DBEC$
��Bold"� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow�� � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=�.��� ���	#FFDBDFE3.+��� -    ��Name$ image��$
��Left=�$	��457��$	��Top=�$	��925��$��Imagenes/about-img.jpg��$
��Fill=�	 J� Opacity$		 0.3Q�$��0,0,-17.667,0q��� -   
 ��Name$
 btnPasar�� � ToolTip$ Traspasar Información��$��	Traspasar��$
��Left=�$��561,400,0,0q�$	��Top=�$��73��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  J� RenderTransformOrigin$ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(�&   System.Windows.Controls.DataGrid  -     Name$ dgLista��   
IsReadOnly . $��41,132,43.333,0q�$	��Top=�$	��239��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   ��� -   $
 btnSalir��$ Salir��$��Salir��$
��Left=�$��699,400,0,0q�$	��Top=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -    ��Name$ 	gbFiltrar��$��Filtrar Información��$
��Left=�$��	41,21,0,0q�$	��Top=�$��85��$	��542�����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$��43��$��10,4,0,0q�$	��Top=�$	��354��.+��� -    ��Name$ label��$��Rut Cliente:��$
��Left=�$	��Top=�$��46,1,0,0q�$��93���� -    ��Name$ txtFiltroRut��*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ej. 11222333-1��$
��Left=�$��23��$��160,3,-14,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��208��$��Normal"�   ClearTextButton .  �� SelectionBrush �	#FFCB5F21�� -	   $
 btnFiltrarRut��$ Filtrar por Rut��$��Filtrar��$
��Left=�$��393,0,-114,14q�$��Bottom=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -
   $
 btnFiltrarRut2��$��Filtrar��$ Filtrar por Rut��$
��Left=�$��393,0,-114,14.333q�$��Bottom=�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $
 btnRefrescar��$ 	Refrescar��$
��Left=�$��815,396,0,0q�$	��Top=�$��36�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  $��36��
���   �����  �� ImageSource$' !Imagenes/Command-Refresh-Blue.png���� -   $ images��$
��Left=�$��633,21,0,348.333q�$	��197��$��Imagenes/logoFinal3.png���� -   $
 	btnPasar2��$ Traspasar Información��$��	Traspasar��$
��Left=�$��561,400,0,0q�$	��Top=�$��73��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $
 btnRefrescar2��$ 	Refrescar��$
��Left=�$��815,396,0,0q�$	��Top=�$��36��#���  $��36��
���   ����� $' !Imagenes/Command-Refresh-blue.png���� -   $
 	btnPasar3��$ Traspasar Información��$��	Traspasar��$
��Left=�$��561,400,0,0q�$	��Top=�$��73��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�