   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5
   	      Vista.WPFBebida   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5	   	   localclr-namespace:Vista   5
   	   -   5        $��2q�5   	   
���   �  � Title$  Administrar Bebidas��5   	   $��657.645��6%   $��644.232��66    � WindowStartupLocation$ CenterScreen=�6F    � Cursor$ Arrow��6k   $
��Bold"�6z   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6�   ���	#FFDBDFE3.��5      � $
��Left=�6   $	��628��6&   $	��Top=�63   $	��640��6K   $��0,0,-5.333,-2.667q�6W   .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��639��6:   $	��Top=�6G   $	��652��6_   $��Imagenes/about-img.jpg��6k   $
��Fill=�6�    J� Opacity$	 0.3Q�6�   $��0,0,-12,-11q�6�   �� 5   
   -   5        	 ��Name$	 groupBox��5      $��Información de Bebida��6%   $��
49,10,56,0q�6D   $	��Top=�6X   $	��227��6p   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5      � $
��Left=�6   $	��221��6.   $	��Top=�6;   $	��535��6S   $��0,-2,-10.333,-1.667q�6_   ��6|   Z� .+�5      �� -   5         ��Name$ 
label_Copy��5      $��
Valor ($):��6,   $
��Left=�6A   $��	23,67,0,0q�6\   $	��Top=�6o   $��12(�6�   �� 5      -   5         ��Name$ 	txtNombre��5      $
��Left=�6-   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese un Nombre��6H   $��8��6x   $��	166,5,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��156��6�   $��Normal"�6�      ClearTextButton .  J� RenderTransformOrigin$ 0.5,0.5&�6   �� SelectionBrush �	#FFCB5F216+  �� 5      -   5        $ txtMl��5      $
��Left=�6)   $ Ingrese Cantidad��6D   $��8��6s   $��
166,36,0,0q�6~   $
 Wrap=�6�   $	��Top=�6�   $	��156��6�   $��Normal"�6�    .  �	#FFCB5F216$  �� 5      -   5        $ txtValor��5      $
��Left=�6,   $ Ingrese Valor��6G   $��8��6�   $��
166,67,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��156��6�   $��Normal"�6�    .  �	#FFCB5F216$  �� 5      -   5        $ txtStock��5      $
��Left=�6,   $ Ingrese Stock��6G   $��8��6�   $��
166,98,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��156��6�   $��Normal"�6�    .  �	#FFCB5F216$  �� 5      -	   5         ��Name$ cboTipo��5      $
��Left=�6,   $��166,129,0,0q�6G   $	��Top=�6\   $	��156��6t   $��Normal"�6�   �� 5      -
   5         ��Name$ 
btnGuardar��5       � ToolTip$ Guardar Registro��6-   $��Guardar��6H   $
��Left=�6Z   $��120,160,0,0q�6u   $	��Top=�6�   $��75��6�   $ Arrow��6�   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  . $ 1.662,0.727&�6"     AccentedSquareButtonStyle#��[  6F  ���	#FFCB5F21$��12(�6�  6�  �� 5      -   5        $ btnCancelar��5      $ Cancelar��6.   $��Cancelar��6A   $
��Left=�6T   $��426,160,0,0q�6o   $	��Top=�6�   $��75��6�   $��Normal"�6�   $ Arrow��6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6b  6p  �� 5      -   5        $ 
btnLimpiar��5      $ Limpiar Casillas��6-   $��Limpiar��6H   $
��Left=�6Z   $��
23,160,0,0q�6u   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6X  6f  �� 5      -   5        $ btnModificar��5      $ Actualizar Registro��6/   $��
Actualizar��6N   $
��Left=�6c   $��120,160,0,0q�6~   $	��Top=�6�   $ Arrow��6�   $��80��6�   $��Normal"�6�    . $ 1.662,0.727&�6  #��[  6(  ���	#FFCB5F21$��12(�6r  6�  �� 5      -   5        $ image1��5      $
��Left=�6(   $��78��6C   $��
367,10,0,0q�6O   $	��Top=�6c   $	��156��6{   $��Imagenes/logoFinal3.png��6�   $ 1.091,0.822&�6�   �� 5      -   5        $ label_Copy7��5      $��Stock:��6-   $
��Left=�6>   $��	23,98,0,0q�6Y   $	��Top=�6l   $��12(�6�   �� 5      -   5        $ label_Copy5��5      $��Mililitros (Ml):��6-   $
��Left=�6H   $��	23,36,0,0q�6c   $	��Top=�6v   $��12(�6�   �� 5       -   5        $ lblId��5       $y�Hidden=�6'   $�� ��6;   $
��Left=�6F   $��23,1,0,0q�6a   $	��Top=�6s   $��12(�6�   �� 5!      -   5        $ label_Copy1��5!      $��Nombre:��6-   $
��Left=�6?   $��23,5,0,0q�6Z   $	��Top=�6l   $��12(�6�   �� 5"      -   5        $ label_Copy3��5"      $��Tipo de Bebida:��6-   $
��Left=�6G   $��
23,129,0,0q�6b   $	��Top=�6v   $��12(�6�   �� 5#      -   5        $ 
lbl1_Copy2��5#      $��*��6,   $
��Left=�69   $��	329,6,0,0q�6T   $	��Top=�6g   $��12(�6   ���	#FF9201016�   �� 5$      -   5        $ 	lbl1_Copy��5$      $��*��6+   $
��Left=�68   $��
329,36,0,0q�6S   $	��Top=�6g   $��12(�6   ���	#FF9201016�   �� 5%      -   5        $ 
lbl1_Copy1��5%      $��*��6,   $
��Left=�69   $��
329,67,0,0q�6T   $	��Top=�6h   $��12(�6�   ���	#FF9201016�   �� 5&      -   5        $ 
lbl1_Copy3��5&      $��*��6,   $
��Left=�69   $��
329,98,0,0q�6T   $	��Top=�6h   $��12(�6�   ���	#FF9201016�   �� 5'      -   5        $ 
lbl1_Copy4��5'      $��*��6,   $
��Left=�69   $��329,128,0,0q�6T   $	��Top=�6i   $��12(�6�   ���	#FF9201016�   5*      5+      �� 5,   
   -   5        $	 	groupBox1��5,      $��Respaldo Caché��6&   $
��Left=�6>   $��69��6Y   $��
49,536,0,0q�6e   $	��Top=�6y   $	��535��6�   ���	#FFCB5F21���	#FFCB5F21.��5-      � .+�5.      �� -   5        $ label2��5.      $��Último Respaldo:��6(   $
��Left=�6C   $��27,1,0,0q�6^   $	��Top=�6p   $
��Bold"�6�   �� 5/      -   5        $ lblCache��5/      $�� ��6*   $
��Left=�65   $��	155,1,0,0q�6P   $	��Top=�6c   $	��215��6{   �� 50      -   5        $ btnCache��50      $ Recuperar Caché��6+   $��	Recuperar��6F   $
��Left=�6Z   $��	398,1,0,0q�6u   $	��Top=�6�   $��78��6�   #��[  6�   ���	#FFCB5F21$��12(�6  $��Normal"�6  $
 Normal=�6.  52      53      �� 54   
   -   5        $	 groupBox_Copy��54      $��Listado de Bebidas��6*   $��49,242,56,0q�6F   $	��Top=�6[   $	��289��6s   ���	#FFCB5F21$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��55      � $
��Left=�6   $	��263��6.   $	��Top=�6;   $	��525��6S   $��0,-2,-0.333,-7.667q�6_   ��6{   Z� .+�57      &   System.Windows.Controls.DataGrid  -   5          Name$ dgLista��57         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6,      
IsReadOnly . $
��Left=�6N   $��	10,48,0,0q�6i   $	��Top=�6|   $	��163��6�   $	��505��6�   $��Normal"�6�   ���	#FFCB5F21
���   � � 	Resources 59      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '        �� 5:      "  6     5;      P� 5<   "    �@ 
IsSelected . . �5=   &   ��  � �� �	#FFFAA5756C   �� 5>   &    � ��
 �   �6C   5?   #   5A      5B      5C      �� 5D      -   5        $ btnRefrescar��5D      $ Refrecar��6/   $
��Left=�6C   $	��Top=�6_   $��36��6w    / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  6�   $��36��6�   
���   �$��479,218,0,-32q�6  ��5E      �� 5F        �� ImageSource$'  !Imagenes/Command-Refresh-blue.png��6%   5H      �� 5I      -    5        $ btnEliminar��5I      $ Eliminar��6.   $��Eliminar��6B   $
��Left=�6U   $��379,221,0,-28q�6p   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFDF0D0D$��12(�6W  $��29��6  �� 5J      -!   5        $ btnPasar��5J      $ Traspasar Información��6+   $��	Traspasar��6L   $
��Left=�6`   $	��Top=�6|   $��78��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6b  $��13,221,0,-28q�6p  �� 5K      -"   5        $ 	cbofiltro��5K      $
��Left=�6.   $��
130,10,0,0q�6I   $	��Top=�6]   $	��156��6u   $��Normal"�6�   �� 5L      -#   5        $ 
btnFiltrar��5L      $ Filtrar Información��6-   $��Filtrar��6L   $
��Left=�6^   $��
315,10,0,0q�6y   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6\  6j  �� 5M      -$   5        $ label_Copy2��5M      $��Tipo de Bebida:��6-   $
��Left=�6G   $��	13,10,0,0q�6b   $	��Top=�6u   $��12(�6�   5O      5P      5Q      5R      