   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5
   	      Vista.WPFAgenda   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5	   	   localclr-namespace:Vista   5
   	   -   5        $��2q�5   	   
���   �  � Title$  Administrar Agenda��5   	   $��557.312��6$   $��884.231��65    � WindowStartupLocation$ CenterScreen=�6E    � Cursor$ Arrow��6j   $
��Bold"�6y   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6�   ���	#FFDBDFE3.��5      � $
��Left=�6   $	��528��6&   $	��Top=�63   $	��891��6K   $��	0,0,0,-10q�6W   .+�5   
   �� -   5         ��Name$ image��5      $	��553��6   $	��Top=�6,   $��Imagenes/about-img.jpg��6D   $
��Fill=�6d    J� Opacity$	 0.3Q�6s   $��
0,-7,0,-18q�6�   	 J� RenderTransformOrigin$	 0.5,0.5&�6�   $
��Left=�6�   $	��881��6�   z�5      V� 5      .~�5      �� �� 5      
 �� AngleY$
 0.303Q�6$   �� 5      T� 5       T� Y$ 1.995Q�6)   5      5      �� 5   
   -   5         ��Name$ groupBox��5      $��Información de Agenda��6%   $��37,10,469,0q�6D   $	��Top=�6Y   $	��415��6q   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5      � $
��Left=�6   $	��376��6.   $	��Top=�6;   $	��375��6S   $��0,-2,-0.333,0q�6_   ��6v   Z� .+�5      �� -   5         ��Name$ 
label_Copy��5      $��Disponible:��6,   $
��Left=�6B   $��
21,284,0,0q�6]   $	��Top=�6q   $��12(�6�   &   System.Windows.Controls.Calendar  5      -   5          Name$ dpFecha��5      $
��Left=�6,   $��94,8,0,0q�6G   $	��Top=�6Y   $��Normal"�6q   $	��183��6�   $	��208��6�   ���	#FFCB5F21 � ToolTip$ Seleccione Fecha��6�   �� 5      -   5         ��Name$ 
btnGuardar��5      $ Guardar Registro��6-   $��Guardar��6H   $
��Left=�6Z   $��107,345,0,0q�6u   $	��Top=�6�   $��75��6�   $ Arrow��6�   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase . *   $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton . $	 1.662,0.727&�6"     AccentedSquareButtonStyle#��[  6F  ���	#FFCB5F21$��12(�6�  $��29��6�  �� 5      -   5        $ btnCancelar��5      $ Cancelar��6.   $��Cancelar��6A   $
��Left=�6T   $��283,345,0,0q�6o   $��75��6�   $��Normal"�6�   $ Arrow��6�    . $	 1.662,0.727&�6�   #��[  6   ���	#FFCB5F21$��12(�6J  $��29��6r  $	��Top=�6~  �� 5       -   5        $ 
btnLimpiar��5       $ Limpiar casillas��6-   $��Limpiar��6H   $
��Left=�6Z   $��
10,345,0,2q�6u   $��75��6�   $��Normal"�6�    . $	 1.662,0.727&�6�   #��[  6�   ���	#FFCB5F21$��12(�6@  6N  �� 5!      -	   5        $ label_Copy5��5!      $��Hora Inicio:��6-   $
��Left=�6D   $��
21,250,0,0q�6_   $	��Top=�6s   $��12(�6�   �� 5"      -
   5        $ btnModificar��5"      $ Actualizar registro��6/   $��
Actualizar��6M   $
��Left=�6b   $��107,345,0,0q�6}   $	��Top=�6�   $ Arrow��6�   $��80��6�   $��Normal"�6�    . $	 1.662,0.727&�6  #��[  6'  ���	#FFCB5F21$��12(�6q  $��29��6�  �� 5#      -   5        $ lblId��5#      $y�Hidden=�6'   $�� ��6;   $
��Left=�6F   $��23,2,0,0q�6a   $	��Top=�6s   $��12(�6�   �� 5$      -   5        $ label_Copy1��5$      $��Fecha:��6-   $
��Left=�6>   $��23,8,0,0q�6Y   $	��Top=�6k   $��12(�6�   �� 5%      -   5        $ label_Copy3��5%      $��Mesa:��6-   $
��Left=�6=   $��
21,315,0,0q�6X   $	��Top=�6l   $��12(�6�   �� 5&      -   5         ��Name$ cboMesa��5&      $
��Left=�6,   $��
94,312,0,0q�6G   $	��Top=�6[   $	��103��6s   $��Normal"�6   �� 5'      -   5         ��Name$ txtHora��5'      $
��Left=�6+   $��23��6F   $��
94,250,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $��37��6�   {�.  6�   �� 5(      -   5        $ 	txtMinuto��5(      $
��Left=�6-   $��23��6H   $��198,250,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $��37��6�   {�.  6�   �� 5)      -   5        $ 
btnMasHora��5)      $ Aumentar Hora��6-   $	��▲��6E   $
��Left=�6Q   $��136,249,0,0q�6l   $	��Top=�6�   $��20��6�   $��Normal"�6�    . $	 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6P  6^  �� 5*      -   5        $ btnMenosHora��5*      $ Disminuir Hora��6/   $	��▼��6H   $
��Left=�6T   $��160,250,0,0q�6o   $	��Top=�6�   $��20��6�   $��Normal"�6�    . $	 1.662,0.727&�6�   #��[  6	  ���	#FFCB5F21$��12(�6S  6a  �� 5+      -   5        $ 	btnMasMin��5+      $ Aumentar Minutos��6,   $	��▲��6G   $
��Left=�6S   $��240,249,0,0q�6n   $	��Top=�6�   $��20��6�   $��Normal"�6�    . $	 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6R  6`  �� 5,      -   5        $ btnMenosMin��5,      $ Didminuir Minutos��6.   $	��▼��6J   $
��Left=�6V   $��265,249,0,0q�6q   $	��Top=�6�   $��20��6�   $��Normal"�6�    . $	 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6U  6c  �� 5-      -   5        $ label_Copy4��5-      $��:��6-   $
��Left=�69   $	��Top=�6T   $��183,250,0,0q�6l   $	 0.425,-0.798&�6�   	� 5.      -   5         	�Name$
 rbSi��5.      $��Si��6,   $
��Left=�69   $��107,288,0,0q�6T   $	��Top=�6i    d� 	IsChecked$
 TrueY�6�   	� 5/      -   5        $
 RbNo��5/      $��No��6,   $
��Left=�69   $��155,288,0,0q�6T   $	��Top=�6i   �� 50      -   5        $ label_Copy2��50      $����* Las mesas tienen una disponibilidad de 1 hora desde su hora de Inicio 
 Considere que el horario de atención del local es de 11:00 a 22:00 hrs.��6-   $
��Left=�6�   $��
21,213,0,0q�6�   $	��Top=�6�   $��9.333(�6  $��Normal"�6%  $��Italic$�69  $	��314��6L  �� 51      -   5        $ label_Copy6��51      $��24 Hrs.��6-   $
��Left=�6?   $��296,250,0,0q�6Z   $	��Top=�6o   $��12(�6�   53      54      �� 55   
   -   5        $ 	groupBox1��55      $��Respaldo Caché��6&   $
��Left=�6>   $��69��6Y   $��
37,430,0,0q�6e   $	��Top=�6y   $	��385��6�   ���	#FFCB5F21���	#FFCB5F21.��56      � .+�57      �� -   5        $ label2��57      $��Último Respaldo:��6(   $
��Left=�6C   $��10,1,0,0q�6^   $	��Top=�6p   $
��Bold"�6�   �� 58      -   5        $ lblCache��58      $�� ��6*   $
��Left=�65   $��	118,1,0,0q�6P   $	��Top=�6c   $	��152��6{   �� 59      -   5        $ btnCache��59      $ Recuperar Caché��6+   $��	Recuperar��6E   $
��Left=�6Y   $��	288,0,0,0q�6t   $	��Top=�6�   $��78��6�   #��[  6�   ���	#FFCB5F21$��12(�6  $��Normal"�6  $��29��6-  5;      5<      �� 5=   
   -   5        $ groupBox_Copy��5=      $��Listado de Agenda��6*   $��427,99,53,0q�6E   $	��Top=�6Z   $	��400��6r   ���	#FFCB5F21$ Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5>      � $
��Left=�6   $	��370��6.   $	��Top=�6;   $	��401��6S   $��0,-2,-0.333,-2.667q�6_   ��6{   Z� .+�5@      &   System.Windows.Controls.DataGrid  -   5          Name$ dgLista��5@         
IsReadOnly . $
��Left=�6>   $��	10,55,0,0q�6Y   $	��Top=�6l   $	��241��6�   $	��382��6�   $��Normal"�6�   ���	#FFCB5F21
���   � � 	Resources 5B      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value  �� Property! �� Value��%�   '        �� 5C      "  6     5D      P� 5E   "    �@ 
IsSelected . . �5F   &   ��   � ��! �	#FFFAA5756C   �� 5G   &     � ��
! �   �6C   5H   #   5J      5K      5L      �� 5M      -    5        $ btnRefrescar��5M      $ 	Refrescar��6/   $
��Left=�6C   $��34��6^    / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  6j   
���   �$��358,311,0,0q�6�   $��32��6�   $	��Top=�6   ��5N      �� 5O      " �� ImageSource$'" !Imagenes/Command-Refresh-blue.png��6%   5Q      �� 5R      -!   5        $ btnEliminar��5R      $ Eliminar Registro��6.   $��Eliminar��6J   $
��Left=�6]   $��218,311,0,30q�6x   $��75��6�   $��Normal"�6�    . $	 1.662,0.727&�6�   #��[  6�   ���	#FFDF0D0D$��12(�6F  6T  �� 5S      -"   5        $ btnPasar��5S      $ Traspasar información��6+   $��	Traspasar��6K   $
��Left=�6_   $	��Top=�6{   $��78��6�   $��Normal"�6�    . $	 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6a  $��
11,311,0,0q�6o  $��29��6�  �� 5T      -#   5        $ labels��5T      $��Seleccione Fecha:��6(   $��19,10,269,329q�6D   $��12(�6[   (  "System.Windows.Controls.DatePicker  5U      -$   5        #  Name$# dpFiltro��5U      $
��Left=�6/   $	��Top=�6K   $	��163��6c   $��Normal"�6o   $��
136,11,0,0q�6�   �� 5V      -%   5        $ 	btnFiltro��5V      $ Filtrar por fecha��6,   $��Filtrar��6H   $
��Left=�6Z   $��304,10,0,331q�6u   $��75��6�   $��Normal"�6�    . $	 1.662,0.727&�6�   #��[  6�   ���	#FFCB5F21$��12(�6B  6P  5\      5]      �� 5^   
   -&   5        $ image1��5^      $
��Left=�6    $��84��6;   $��
438,10,0,0q�6G   $	��Top=�6[   $	��160��6s   $��Imagenes/logoFinal3.png��6   $	 1.091,0.822&�6�   �� 5_   
   -'   5        $ 
lbl1_Copy1��5_      $��*��6$   $
��Left=�61   $��
323,51,0,0q�6L   $	��Top=�6`   $��12(�6x   ���	#FF9201016�   �� 5`   
   -(   5        $ 	lbl1_Copy��5`      $��*��6#   $
��Left=�60   $��386,288,0,0q�6K   $	��Top=�6`   $��12(�6x   ���	#FF9201016�   �� 5a   
   -)   5        $ 
lbl1_Copy2��5a      $��*��6$   $
��Left=�61   $��245,323,0,0q�6L   $	��Top=�6a   $��12(�6y   ���	#FF9201016�   �� 5b   
   -*   5        $ 
lbl1_Copy3��5b      $��*��6$   $
��Left=�61   $��245,349,0,0q�6L   $	��Top=�6a   $��12(�6y   ���	#FF9201016�   5c      5d      