   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5
   	      Vista.WPFPlato   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5	   	   localclr-namespace:Vista   5
   	   -   5        $��2q�5   	   
���   �  � Title$  Administrar Platos��5   	   $��513.645��6$   $��1096.984��65    � WindowStartupLocation$ CenterScreen=�6F    � Cursor$ Arrow��6k   $
��Bold"�6z   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6�   ���	#FFDBDFE3.��5      � $
��Left=�6   $	��482��6&   $	��Top=�63   $
��1149��6K   $��0,0,-61.667,-0.667q�6X   .+�5   
   �� -   5         ��Name$ image��5      $	��498��6   $	��Top=�6,   $��Imagenes/about-img.jpg��6D   $
��Fill=�6d    J� Opacity$	 0.3Q�6s   $��
0,0,50,-16q�6�   �� 5   
   -   5        	 ��Name$	 groupBox��5      $��Información de Platos��6%   $��34,10,706,0q�6D   $	��Top=�6Y   $	��444��6q   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5      � $
��Left=�6   $	��442��6.   $	��Top=�6;   $	��409��6S   $��0,-29,-9.667,-3.667q�6_   ��6|   Z� .+�5      �� -   5         ��Name$ 
label_Copy��5      $��Descripción:��6,   $
��Left=�6C   $��	10,88,0,0q�6^   $	��Top=�6q   $��12(�6�   �� 5      -   5         ��Name$ txtNomb��5      $
��Left=�6+   $��23��6F   $��
152,32,0,0q�6R   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Nombre��6f    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��144��6�      ClearTextButton . $��Normal"�6�   �� 5      -   5        $ 	txtPrecio��5      $
��Left=�6-   $ Ingrese Precio��6H   $��8��6u   $��
152,60,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��125��6�   $��Normal"�6�    .  �� SelectionBrush �	#FFCB5F216&  �� 5      -   5        $ txtDescripcion��5      " �� VerticalScrollBarVisibility$ Visible=�62   $
��Left=�6X   $ Ingrese una Descripción��6s   $��62��6�   $��
152,88,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��230��6�   $��Normal"�6   .   �	#FFCB5F216?  �� 5      -   5         ��Name$ 	cboReceta��5      $
��Left=�6.   $��152,182,0,0q�6I   $	��Top=�6^   $	��144��6v   $��Normal"�6�   �� 5      -	   5        $ cboCategoria��5      $
��Left=�61   $��152,211,0,0q�6L   $	��Top=�6a   $	��144��6y   $��Normal"�6�   �� 5      -
   5         ��Name$ 
btnGuardar��5       � ToolTip$ Guardar Registro��6-   $��Guardar��6H   $
��Left=�6Z   $��
99,408,0,0q�6u   $	��Top=�6�   $��75��6�   $ Arrow��6�   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  .  J� RenderTransformOrigin$ 1.662,0.727&�6!     AccentedSquareButtonStyle#��[  6E  ���	#FFCB5F21$��12(�6�  6�  �� 5      -   5        $ btnCancelar��5      $ Cancelar��6.   $��Cancelar��6A   $
��Left=�6T   $��307,408,0,0q�6o   $	��Top=�6�   $��75��6�   $��Normal"�6�   $ Arrow��6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6b  6p  �� 5      -   5        $ 
btnLimpiar��5      $ Limpiar Casillas��6-   $��Limpiar��6H   $
��Left=�6Z   $��
10,408,0,0q�6u   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6X  6f  �� 5      -   5        $ label_Copy5��5      $��Precio ($):��6-   $
��Left=�6C   $��	10,60,0,0q�6^   $	��Top=�6q   $��12(�6�   �� 5      -   5        $ btnModificar��5      $ Actualizar Registro��6/   $��
Actualizar��6M   $
��Left=�6b   $��
99,408,0,0q�6}   $	��Top=�6�   $ Arrow��6�   $��80��6�   $��Normal"�6�    . $ 1.662,0.727&�6  #��[  6&  ���	#FFCB5F21$��12(�6p  6~  �� 5      -   5        $ lblId��5      $y�Hidden=�6'   $�� ��6;   $
��Left=�6F   $��10,6,0,0q�6a   $	��Top=�6s   $��12(�6�   �� 5       -   5        $ label_Copy1��5       $��Nombre:��6-   $
��Left=�6?   $��	10,32,0,0q�6Z   $	��Top=�6m   $��12(�6�   �� 5"      -   5        $ label_Copy3��5"      $��
Stock (U):��6-   $
��Left=�6B   $��
10,153,0,0q�6]   $	��Top=�6q   $��12(�6�   �� 5#      -   5        $ label_Copy4��5#      $��Receta:��6-   $
��Left=�6?   $��
10,182,0,0q�6Z   $	��Top=�6n   $��12(�6�   �� 5$      -   5        $ label_Copy6��5$      $��Categoría:��6-   $
��Left=�6B   $��
10,211,0,0q�6]   $	��Top=�6q   $��12(�6�   �� 5%      -   5        $ txtStock��5%      $
��Left=�6,   $ Ingrese Stock��6G   $��8��6s   $��152,153,0,0q�6~   $
 Wrap=�6�   $	��Top=�6�   $	��125��6�   $��Normal"�6�    .  �	#FFCB5F216%  �� 5'      -   5        $ btnSeleccionar��5'      $ Seleccionar Imagen��61   $��Examinar��6N   $
��Left=�6a   $��
10,243,0,0q�6|   $	��Top=�6�   $��79��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6_  6m  � 5(      $
��Left=�6   $	��139��62   $��152,243,0,0q�6?   $	��Top=�6T   $	��216��6l   .+�5)      �� $
��Left=�6    $	��139��6;   
���   �$	��Top=�6W   $	��216��6o   
�������$	 0.7Q�6�   �� 5*      -   5        $ imgPlato��5*      $
��Left=�6.   $	��216��6I   /   )MahApps.Metro.Controls.ScrollViewerHelper%   IsHorizontalScrollWheelEnabled . $
��Fill=�6�   5+      �� 5,      -   5        $ FileNameLabel��5,      $��Right=�60   $��10,382,27,34q�6S   $��9.333(�6i   $��26��6z   $
��Bold"�6�   �� 5-      -   5        $
 lbl1��5-      $��*��6&   $
��Left=�63   $��
301,32,0,0q�6N   $	��Top=�6b   $��12(�6z   ���	#FF9201016�   �� 5.      -   5        $ 	lbl1_Copy��5.      $��*��6+   $
��Left=�68   $��
282,63,0,0q�6S   $	��Top=�6g   $��12(�6   ���	#FF9201016�   �� 5/      -   5        $ 
lbl1_Copy1��5/      $��*��6,   $
��Left=�69   $��281,153,0,0q�6T   $	��Top=�6i   $��12(�6�   ���	#FF9201016�   �� 50      -   5        $ 
lbl1_Copy2��50      $��*��6,   $
��Left=�69   $��301,182,0,0q�6T   $	��Top=�6i   $��12(�6�   ���	#FF9201016�   �� 51      -   5        $ 
lbl1_Copy3��51      $��*��6,   $
��Left=�69   $��301,211,0,0q�6T   $	��Top=�6i   $��12(�6�   ���	#FF9201016�   54      55      �� 56   
   -   5        $	 	groupBox1��56      $��Respaldo Caché��6&   $
��Left=�6>   $��69��6Y   $��448,385,0,0q�6e   $	��Top=�6z   $	��609��6�   ���	#FFCB5F21���	#FFCB5F21.��57      � .+�58      �� -   5        $ label2��58      $��Último Respaldo:��6(   $
��Left=�6C   $��67,2,0,0q�6^   $	��Top=�6p   $
��Bold"�6�   �� 59      -   5        $ lblCache��59      $�� ��6*   $
��Left=�65   $��	185,2,0,0q�6P   $	��Top=�6c   $	��215��6{   �� 5:      -    5        $ btnCache��5:      $ Recuperar Caché��6+   $��	Recuperar��6E   $
��Left=�6Y   $��	479,2,0,0q�6t   $	��Top=�6�   $��78��6�   #��[  6�   ���	#FFCB5F21$��12(�6  $��Normal"�6  $
 Normal=�6-  5<      5=      �� 5>   
   -!   5        $	 groupBox_Copy��5>      $��Listado de Platos��6*   $��448,89,91,0q�6E   $	��Top=�6Z   $	��291��6r   ���	#FFCB5F21$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5?      � $
��Left=�6   $	��260��6.   $	��Top=�6;   $	��606��6S   $��
0,-2,-6,-2q�6_   ��6s   Z� .+�5A      &   System.Windows.Controls.DataGrid  -"   5          Name$ dgLista��5A         
IsReadOnly . $
��Left=�6>   $��	18,38,0,0q�6Y   $	��Top=�6l   $	��173��6�   $	��565��6�   $��Normal"�6�   ���	#FFCB5F21
���   � � 	Resources 5C      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property  �� Value��%�   '        �� 5D      "  6     5E      P� 5F   "    �@ 
IsSelected . . �5G   &   ��  � ��  �	#FFFAA5756C   �� 5H   &    � ��
  �   �6C   5I   #   5K      5L      5M      �� 5N      -#   5        $ btnRefrescar��5N      $ 	Refrescar��6/   $
��Left=�6C   $	��Top=�6_   $��36��6w    / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  6�   $��36��6�   
���   �$��547,220,0,0q�6  ��5O      �� 5P      ! �� ImageSource$'! !Imagenes/Command-Refresh-blue.png��6%   5R      �� 5S      -$   5        $ btnEliminar��5S      $ Eliminar Registro��6.   $��Eliminar��6J   $
��Left=�6]   $��454,225,0,0q�6x   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFDF0D0D$��12(�6]  6k  �� 5T      -%   5        $ btnPasar��5T      $ Traspasar Información��6+   $��	Traspasar��6K   $
��Left=�6_   $	��Top=�6{   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6a  $��
18,225,0,0q�6o  �� 5U      -&   5        $ 	cboFiltro��5U      $
��Left=�6.   $��94,4,0,0q�6I   $	��Top=�6[   $	��144��6s   $��Normal"�6   �� 5V      -'   5        $ 
btnFiltrar��5V      $ Filtrar por Categoría��6-   $��Filtrar��6M   $
��Left=�6_   $��	252,4,0,0q�6z   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6\  6j  �� 5W      -(   5        $ label_Copy2��5W      $��Categoría:��6-   $
��Left=�6B   $��19,4,0,0q�6]   $	��Top=�6o   $��12(�6�   5Y      5Z      �� 5[   
   -)   5        $ image1��5[      $
��Left=�6    $��72��6;   $��
497,15,0,0q�6G   $	��Top=�6[   $	��154��6s   $��Imagenes/logoFinal3.png��6   $ 1.091,0.822&�6�   5\      5]      