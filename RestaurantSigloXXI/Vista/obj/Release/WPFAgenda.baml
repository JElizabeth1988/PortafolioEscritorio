   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFAgenda   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  6mah,http://metro.mahapps.com/winfx/xaml/controls   localclr-namespace:Vista   -   $��2q�
���   �  � Title$  Administrar Agenda��$��557.312��$��884.231�� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow��$
��Bold"�(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=����	#FFDBDFE3.��� $
��Left=�$	��528��$	��Top=�$	��891��$��	0,0,0,-10q�.+��� -    ��Name$ image��$	��553��$	��Top=�$��Imagenes/about-img.jpg��$
��Fill=� J� Opacity$	 0.3Q�$��
0,-7,0,-18q�	 J� RenderTransformOrigin$	 0.5,0.5&�$
��Left=�$	��881��z�V� .~��� �� 
 �� AngleY$
 0.303Q��� T�  T� Y$ 1.995Q��� -    ��Name$ groupBox��$��Información de Agenda��$��37,10,469,0q�$	��Top=�$	��415�����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��376��$	��Top=�$	��375��$��0,-2,-0.333,0q���Z� .+��� -    ��Name$ 
label_Copy��$��Disponible:��$
��Left=�$��
21,284,0,0q�$	��Top=�$��12(�&   System.Windows.Controls.Calendar  -     Name$ dpFecha��$
��Left=�$��94,8,0,0q�$	��Top=�$��Normal"�$	��183��$	��208�����	#FFCB5F21 � ToolTip$ Seleccione Fecha���� -    ��Name$ 
btnGuardar��$ Guardar Registro��$��Guardar��$
��Left=�$��107,345,0,0q�$	��Top=�$��75��$ Arrow��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase . *   $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton . $	 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(�$��29���� -   $ btnCancelar��$ Cancelar��$��Cancelar��$
��Left=�$��283,345,0,0q�$��75��$��Normal"�$ Arrow�� . $	 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��29��$	��Top=��� -   $ 
btnLimpiar��$ Limpiar casillas��$��Limpiar��$
��Left=�$��
10,345,0,2q�$��75��$��Normal"� . $	 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -	   $ label_Copy5��$��Hora Inicio:��$
��Left=�$��
21,250,0,0q�$	��Top=�$��12(��� -
   $ btnModificar��$ Actualizar registro��$��
Actualizar��$
��Left=�$��107,345,0,0q�$	��Top=�$ Arrow��$��80��$��Normal"� . $	 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��29���� -   $ lblId��$y�Hidden=�$�� ��$
��Left=�$��23,2,0,0q�$	��Top=�$��12(��� -   $ label_Copy1��$��Fecha:��$
��Left=�$��23,8,0,0q�$	��Top=�$��12(��� -   $ label_Copy3��$��Mesa:��$
��Left=�$��
21,315,0,0q�$	��Top=�$��12(��� -    ��Name$ cboMesa��$
��Left=�$��
94,312,0,0q�$	��Top=�$	��103��$��Normal"��� -    ��Name$ txtHora��$
��Left=�$��23��$��
94,250,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��37��{�.  �� -   $ 	txtMinuto��$
��Left=�$��23��$��198,250,0,0q�$
 Wrap=�$	��Top=�$��37��{�.  �� -   $ 
btnMasHora��$ Aumentar Hora��$	��▲��$
��Left=�$��136,249,0,0q�$	��Top=�$��20��$��Normal"� . $	 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ btnMenosHora��$ Disminuir Hora��$	��▼��$
��Left=�$��160,250,0,0q�$	��Top=�$��20��$��Normal"� . $	 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ 	btnMasMin��$ Aumentar Minutos��$	��▲��$
��Left=�$��240,249,0,0q�$	��Top=�$��20��$��Normal"� . $	 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ btnMenosMin��$ Didminuir Minutos��$	��▼��$
��Left=�$��265,249,0,0q�$	��Top=�$��20��$��Normal"� . $	 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -   $ label_Copy4��$��:��$
��Left=�$	��Top=�$��183,250,0,0q�$	 0.425,-0.798&�	� -    	�Name$
 rbSi��$��Si��$
��Left=�$��107,288,0,0q�$	��Top=� d� 	IsChecked$
 TrueY�	� -   $
 RbNo��$��No��$
��Left=�$��155,288,0,0q�$	��Top=��� -   $ label_Copy2��$����* Las mesas tienen una disponibilidad de 1 hora desde su hora de Inicio 
 Considere que el horario de atención del local es de 11:00 a 22:00 hrs.��$
��Left=�$��
21,213,0,0q�$	��Top=�$��9.333(�$��Normal"�$��Italic$�$	��314���� -   $ label_Copy6��$��24 Hrs.��$
��Left=�$��296,250,0,0q�$	��Top=�$��12(��� -   $ 	groupBox1��$��Respaldo Caché��$
��Left=�$��69��$��
37,430,0,0q�$	��Top=�$	��385�����	#FFCB5F21���	#FFCB5F21.��� .+��� -   $ label2��$��Último Respaldo:��$
��Left=�$��10,1,0,0q�$	��Top=�$
��Bold"��� -   $ lblCache��$�� ��$
��Left=�$��	118,1,0,0q�$	��Top=�$	��152���� -   $ btnCache��$ Recuperar Caché��$��	Recuperar��$
��Left=�$��	288,0,0,0q�$	��Top=�$��78��#��[  ���	#FFCB5F21$��12(�$��Normal"�$��29���� -   $ groupBox_Copy��$��Listado de Agenda��$��427,99,53,0q�$	��Top=�$	��400�����	#FFCB5F21$ Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��370��$	��Top=�$	��401��$��0,-2,-0.333,-2.667q���Z� .+�&   System.Windows.Controls.DataGrid  -     Name$ dgLista��   
IsReadOnly . $
��Left=�$��	10,55,0,0q�$	��Top=�$	��241��$	��382��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value  �� Property! �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���   � ��! �	#FFFAA575��   � ��
! �   ��� -    $ btnRefrescar��$ 	Refrescar��$
��Left=�$��34�� / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  
���   �$��358,311,0,0q�$��32��$	��Top=����� " �� ImageSource$'" !Imagenes/Command-Refresh-blue.png���� -!   $ btnEliminar��$ Eliminar Registro��$��Eliminar��$
��Left=�$��218,311,0,30q�$��75��$��Normal"� . $	 1.662,0.727&�#��[  ���	#FFDF0D0D$��12(��� -"   $ btnPasar��$ Traspasar información��$��	Traspasar��$
��Left=�$	��Top=�$��78��$��Normal"� . $	 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��
11,311,0,0q�$��29���� -#   $ labels��$��Seleccione Fecha:��$��19,10,269,329q�$��12(�(  "System.Windows.Controls.DatePicker  -$   #  Name$# dpFiltro��$
��Left=�$	��Top=�$	��163��$��Normal"�$��
136,11,0,0q��� -%   $ 	btnFiltro��$ Filtrar por fecha��$��Filtrar��$
��Left=�$��304,10,0,331q�$��75��$��Normal"� . $	 1.662,0.727&�#��[  ���	#FFCB5F21$��12(��� -&   $ image1��$
��Left=�$��84��$��
438,10,0,0q�$	��Top=�$	��160��$��Imagenes/logoFinal3.png��$	 1.091,0.822&��� -'   $ 
lbl1_Copy1��$��*��$
��Left=�$��
323,51,0,0q�$	��Top=�$��12(����	#FF920101�� -(   $ 	lbl1_Copy��$��*��$
��Left=�$��386,288,0,0q�$	��Top=�$��12(����	#FF920101�� -)   $ 
lbl1_Copy2��$��*��$
��Left=�$��245,323,0,0q�$	��Top=�$��12(����	#FF920101�� -*   $ 
lbl1_Copy3��$��*��$
��Left=�$��245,349,0,0q�$	��Top=�$��12(����	#FF920101