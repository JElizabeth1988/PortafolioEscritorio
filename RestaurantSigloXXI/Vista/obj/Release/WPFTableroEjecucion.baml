   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFTableroEjecucion   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6mah,http://metro.mahapps.com/winfx/xaml/controls   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  localclr-namespace:Vista  -   $��2q�
���   �  � Title$&   Visualizar Tablero de Ejecución��$��546.336��$��1121.48��(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � WindowStyle$ 
ToolWindow=����	#FFD2DBEC$
��Bold"� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow�� � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=�.��� ���	#FFDBDFE3.+��� -    ��Name$ image��$
��Left=�$	��533��$	��Top=�$
��1127��$��Imagenes/about-img.jpg��$
��Fill=�	 J� Opacity$		 0.3Q�$��0,0,-15,-17.667q��� -   
 ��Name$
 	gbFiltrar��$��Tablero de Ejecución��$��41,21,42.333,31q����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��416��$��10,4,-0.333,0q�$	��Top=�$
��1009��.+��� -   $ images��$
��Left=�$��625,0,0,356q�$	��156��$��Imagenes/logoFinal3.png��&   System.Windows.Controls.DataGrid  -     Name$ dgLista��   
IsReadOnly . $��
29,65,42,0q�$	��Top=�$	��281��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   ��� -    ��Name$ btnSalir�� � ToolTip$ Cancelar��$��Cancelar��$
��Left=�$��
29,372,0,0q�$	��Top=�$��75��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  J� RenderTransformOrigin$ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(��� -    ��Name$ 
label_Copy��$��Rut Cliente:��$
��Left=�$	��Top=�$��46,9,0,0q�$��93��$��12(��� -    ��Name$ txtRut��*   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ej. 11222333-1��$
��Left=�$��23��$��	163,9,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��151��$��Normal"�   ClearTextButton .  �� SelectionBrush �	#FFCB5F21�� -	   $ btnRut��$  Filtrar por Rut de Cliente��$��Filtrar��$
��Left=�$��339,9,0,381q�$��75��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -
   $ btnRefrescar��$ 	Refrescar��$
��Left=�$��931,370,0,0q�$	��Top=�$��36�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  $��36��
���   �$ 2.157,3.796&�����  �� ImageSource$' !Imagenes/Command-Refresh-Blue.png���� -   $ 
btnCambiar��$  Cambiar Estado de la Orden��$��Cambiar Estado��$
��Left=�$��595,372,0,0q�$	��Top=�$	��112��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ label1��$��Seleccione Estado: ��$
��Left=�$��242,376,0,0q�$	��Top=�$	��124��$��12(�	� -     	�Name$  rbListo��$��Listo��$
��Left=�$��24��$��514,376,0,0q�$	��Top=�! 	� 	GroupName$! estado��	� -   $  rbPreparación��$��En Preparación��$
��Left=�$��24��$��386,376,0,0q�$	��Top=�$! estado��" d� 	IsChecked$
" TrueY�