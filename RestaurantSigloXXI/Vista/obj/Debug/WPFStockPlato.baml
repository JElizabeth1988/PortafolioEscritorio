   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5
   	      Vista.WPFStockPlato   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5	   	   localclr-namespace:Vista   5
   	   -   5        $��2q�5   	   
���   �  � Title$   Administrar Stock de Plato��5   	   $��568.739��6,   $��818.232��6=    � WindowStartupLocation$ CenterScreen=�6M    � Cursor$ Arrow��6r   $
��Bold"�6�   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6�   ���	#FFDBDFE3.��5      � $
��Left=�6   $	��549��6&   $	��Top=�63   $	��808��6K   $��0,0,0,-12.333q�6W   .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��553��6:   $	��Top=�6G   $	��823��6_   $��Imagenes/about-img.jpg��6k   $
��Fill=�6�    J� Opacity$	 0.3Q�6�   $��
0,0,-15,-4q�6�   �� 5   
   -   5        	 ��Name$	 groupBox��5      $��Actualizar Stock de Plato��6%   $��39,304,41,0q�6H   $	��Top=�6]   $	��139��6u   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5      � $
��Left=�6   $	��106��6.   $	��Top=�6;   $	��663��6S   $��	39,0,0,-2q�6_   ��6r   Z� .+�5      �� -   5         ��Name$ 	txtNombre��5      $
��Left=�6-   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$  ��6H   $��8��6g   $��95,5,0,0q�6r    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��156��6�   $��Normal"�6�      ClearTextButton .   J� RenderTransformOrigin$ 0.5,0.5&�6�    �� SelectionBrush �	#FFCB5F21{�.  65  �� 5      -   5        $ txtStock��5      $
��Left=�6,   $ Ingrese Stock��6G   $��8��6�   $��	95,35,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��156��6�   $��Normal"�6�    .  �	#FFCB5F216#  �� 5      -   5         ��Name$ btnCancelar��5       � ToolTip$ Cancelar��6.   $��Cancelar��6A   $
��Left=�6T   $��
475,72,0,0q�6o   $	��Top=�6�   $��75��6�   $��Normal"�6�   $ Arrow��6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase . $ 1.662,0.727&�6�      AccentedSquareButtonStyle#��[  6  ���	#FFCB5F21$��12(�6a  6o  �� 5      -   5        $ 
btnLimpiar��5      $ Limpiar Casillas��6-   $��Limpiar��6H   $
��Left=�6Z   $��	23,71,0,0q�6u   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6W  6e  �� 5      -   5        $ btnModificar��5      $ Guardar Registro��6/   $��Guardar��6K   $
��Left=�6]   $��
120,71,0,0q�6x   $	��Top=�6�   $ Arrow��6�   $��80��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6!  ���	#FFCB5F21$��12(�6k  6y  �� 5      -	   5        $ image1��5      $
��Left=�6(   $��86��6C   $��	285,5,0,0q�6O   $	��Top=�6b   $	��151��6z   $��Imagenes/logoFinal3.png��6�   $ 1.091,0.822&�6�   �� 5      -
   5         ��Name$ label_Copy7��5      $��Stock:��6-   $
��Left=�6>   $��	23,35,0,0q�6Y   $	��Top=�6l   $��12(�6�   �� 5      -   5        $ lblId��5      $y�Hidden=�6'   $�� ��6;   $
��Left=�6F   $��23,1,0,0q�6a   $	��Top=�6s   $��12(�6�   �� 5      -   5        $ label_Copy1��5      $��Nombre:��6-   $
��Left=�6?   $��23,5,0,0q�6Z   $	��Top=�6l   $��12(�6�   5      5      �� 5    
   -   5        $	 	groupBox1��5       $��Respaldo Caché��6&   $
��Left=�6>   $��69��6Y   $��
39,446,0,0q�6e   $	��Top=�6y   $	��728��6�   ���	#FFCB5F21���	#FFCB5F21.��5!      � .+�5"      �� -   5        $ label2��5"      $��Último Respaldo:��6(   $
��Left=�6C   $��39,1,0,0q�6^   $	��Top=�6p   $
��Bold"�6�   �� 5#      -   5        $ lblCache��5#      $�� ��6*   $
��Left=�65   $��	163,1,0,0q�6P   $	��Top=�6c   $	��215��6{   �� 5$      -   5        $ btnCache��5$      $ Recuperar Caché��6+   $��	Recuperar��6F   $
��Left=�6Z   $��	560,1,0,0q�6u   $	��Top=�6�   $��78��6�   #��[  6�   ���	#FFCB5F21$��12(�6  $��Normal"�6  $
 Normal=�6.  5&      5'      �� 5(   
   -   5        $	 groupBox_Copy��5(      $��Seleccionar Plato��6*   $��
39,10,41,0q�6E   $	��Top=�6Y   $	��289��6q   ���	#FFCB5F21$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5)      � $
��Left=�6   $	��263��6.   $	��Top=�6;   $	��718��6S   $��0,-2,0,-7.667q�6_   ��6v   Z� .+�5+      &   System.Windows.Controls.DataGrid  -   5          Name$ dgLista��5+         
IsReadOnly . $
��Left=�6>   $��	10,48,0,0q�6Y   $	��Top=�6l   $	��163��6�   $	��698��6�   $��Normal"�6�   ���	#FFCB5F21
���   � � 	Resources 5-      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '        �� 5.      "  6     5/      P� 50   "    �@ 
IsSelected . . �51   &   ��  � �� �	#FFFAA5756C   �� 52   &    � ��
 �   �6C   53   #   55      56      57      �� 58      -   5        $ btnRefrescar��58      $ Refrecar��6/   $
��Left=�6C   $	��Top=�6_   $��36��6w    / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  6�   $��36��6�   
���   �$��672,214,0,0q�6  ��59      �� 5:       �� ImageSource$' !Imagenes/Command-Refresh-blue.png��6%   5<      �� 5=      -   5        $ btnPasar��5=      $ Traspasar Información��6+   $��Seleccionar��6L   $
��Left=�6b   $	��Top=�6~   $��78��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6d  $��13,221,0,-28q�6r  �� 5>      -   5         ��Name$ 	cbofiltro��5>      $
��Left=�6.   $��
102,10,0,0q�6I   $	��Top=�6]   $	��156��6u   $��Normal"�6�   �� 5?      -   5        $ 
btnFiltrar��5?      $ Filtrar Información��6-   $��Filtrar��6L   $
��Left=�6^   $��
282,10,0,0q�6y   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6\  6j  �� 5@      -   5        $ label_Copy2��5@      $��
Categoria:��6-   $
��Left=�6B   $��	13,10,0,0q�6]   $	��Top=�6p   $��12(�6�   5B      5C      5D      5E      