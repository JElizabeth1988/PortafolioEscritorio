   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5
   	      Vista.WPFCalcularPedido   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5	   	   localclr-namespace:Vista   5
   	   -   5        $��2q�5   	   
���   �  � Title$!  Calcular Pedido a Proveedor��5   	   $��610.645��6-   $��1199.508��6>    � WindowStartupLocation$ CenterScreen=�6O    � Cursor$ Arrow��6t   $
��Bold"�6�   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/logoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6�   ���	#FFDBDFE3.��5      � $
��Left=�6   $	��577��6&   $	��Top=�63   $
��1190��6K   .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��597��6:   $	��Top=�6G   $
��1202��6_   $��Imagenes/about-img.jpg��6l   $
��Fill=�6�    J� Opacity$	 0.3Q�6�   $��0,0,-12,-20q�6�   �� 5   
   -   5        	 ��Name$	 	groupBox1��5      $��Detalle Pedido��6&   $
��Left=�6>   $	��Top=�6Y   $��	23,10,0,0q�6q   $	��706��6�   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21$	��534��6  .��5      � .+�5      �� -   5        $	 groupBox��5      $��Información de Producto��6-   $��8,314,9.667,0q�6N   $	��Top=�6e   $	��166��6}   ���	#FFCB5F21$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5      � $
��Left=�6   $	��137��66   $	��Top=�6C   $	��561��6[   $��0,-2,-0.333,-4.333q�6g   ��6�   Z� .+�5      �� -   5         ��Name$ 
label_Copy��5       $��
Valor ($):��64   $
��Left=�6I   $��	27,34,0,0q�6d   $	��Top=�6w   $��12(�6�   �� 5      -   5        $ label_Copy1��5       $��Nombre Producto:��65   $
��Left=�6P   $��27,4,0,0q�6k   $	��Top=�6}   $��12(�6�   �� 5      -   5         ��Name$ 
txtNomProd��5   "   $
��Left=�66   $��8��6R   $��	160,4,0,0q�6]    �� TextWrapping$
 Wrap=�6p   $	��Top=�6�   $	��195��6�   $��Normal"�6�   *   $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton .  {�.   J� RenderTransformOrigin$ 0.5,0.5&�6�    �� SelectionBrush �	#FFCB5F216  �� 5      -   5        $ txtValorUnidad��5   "   $
��Left=�6:   $��8��6r   $��
160,34,0,0q�6}   $
 Wrap=�6�   $	��Top=�6�   {�.  $	��134��6�   $��Normal"�6�    .   �	#FFCB5F216  �� 5      -	   5         ��Name$ btnPasar��5   !    � ToolTip$ Agregar Producto��63   $��Agregar��6N   $
��Left=�6`   $��
322,96,0,0q�6{   $	��Top=�6�   $��75��6�   $ Arrow��6�   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  . $ 1.662,0.727&�6'     AccentedSquareButtonStyle#��[  6K  ���	#FFCB5F21$��12(�6�  6�  �� 5      -
   5        $ image1��5       $
��Left=�60   $��90��6K   $��	425,4,0,0q�6W   $	��Top=�6j   $	��123��6�   $��Imagenes/logoFinal3.png��6�   $ 1.091,0.822&�6�   �� 5      -   5        $ 
lbl1_Copy2��5       $��*��64   $
��Left=�6A   $��	355,4,0,0q�6\   $	��Top=�6o   $��12(�6�   ���	#FF9201016�   �� 5      -   5        $ 
lbl1_Copy1��5       $��*��64   $
��Left=�6A   $��
294,34,0,0q�6\   $	��Top=�6p   $��12(�6�   ���	#FF9201016�   �� 5      -   5        $ 
lbl1_Copy3��5       $��*��64   $
��Left=�6A   $��
294,65,0,0q�6\   $	��Top=�6p   $��12(�6�   ���	#FF9201016�   �� 5      -   5        $ txtCantidad��5   "   $
��Left=�67      	Watermark$ Ingrese Cantidad��6R   $��8��6�   $��
160,64,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��134��6�   $��Normal"�6�    .  �	#FFCB5F2162  �� 5      -   5        $ label_Copy3��5       $��	Cantidad:��65   $
��Left=�6I   $��	27,64,0,0q�6d   $	��Top=�6w   $��12(�6�   �� 5       -   5        $ 
btnAgregar��5    !   $ Agregar Artículos��65   $��Agregar��6Q   $
��Left=�6c   $��
322,96,0,0q�6~   $	��Top=�6�   $��77��6�   $ Arrow��6�   $��Normal"�6�    .  . $ 1.662,0.727&�6*  #��[  6N  ���	#FFCB5F21$��12(�6�  6�  5"      5#      �� 5$      -   5        $	 groupBox_Copy��5$      $��Productos con Bajo Stock ��62   $��
8,54,333,0q�6U   $	��Top=�6i   $	��255��6�   ���	#FFCB5F21$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5%      � $
��Left=�6   $	��222��66   $	��Top=�6C   $	��346��6[   $��0,-2,0,0q�6g   ��6y   Z� .+�5'      &   System.Windows.Controls.DataGrid  -   5          Name$ dgListaProducto��5'   #      
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6N   $
��Left=�6^   $��0,10,0,0q�6y   $	��Top=�6�   $	��170��6�   $	��346��6�   $��Normal"�6�   ���	#FFCB5F21
���   � � 	Resources 5)      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '        �� 5*   "   "  6(    5+   &   P� 5,   *    �@ 
IsSelected . . �5-   .   ��  � �� �	#FFFAA5756K   �� 5.   .    � ��
 �   �6K   5/   +   51   #   52      53      �� 54      -   5        $ btnRefrescar��54   !   $ 	Refrescar��67   $
��Left=�6K   $��34��6f    / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  6r   
���   �$��302,185,0,0q�6�   $��34��6�   $	��Top=�6  ��55      �� 56   "    �� ImageSource$' !Imagenes/Command-Refresh-blue.png��6-   58      �� 59      -   5        $ btnSeleccionarProd��59   !   $ Seleccionar un Registro��6=   $��Seleccionar��6_   $
��Left=�6u   $	��Top=�6�   $��78��6�   $��Normal"�6�    . $ 1.662,0.727&�6  #��[  66  ���	#FFCB5F21$��12(�6�  $��
10,190,0,0q�6�  $��29��6�  5;      5<      �� 5=      -   5        $	 groupBox_Copy1��5=      $��Bebidas con Bajo Stock ��63   $��369,54,9.667,0q�6T   $	��Top=�6l   $	��255��6�   ���	#FFCB5F21$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5>      � $
��Left=�6   $	��221��66   $	��Top=�6C   $	��308��6[   $��0,-2,0,0q�6g   ��6y   Z� .+�5@        -   5        $ dgListaBebida��5@   #   $ * 6:    . $
��Left=�6\   $��0,10,0,0q�6w   $	��Top=�6�   $	��170��6�   $	��308��6�   $��Normal"�6�   ���	#FFCB5F21
���   � 5B      ��%�   '        �� 5C   "   "  6(    5D   &   P� 5E   *    �@ 
IsSelected . . �5F   .   ��  � �� �	#FFFAA5756K   �� 5G   .    � ��
 �   �6K   5H   +   5J   #   5K      5L      �� 5M      -   5        $ btnRefrescar1��5M   !   $ 	Refrescar��68   $
��Left=�6L   $��34��6g   #���  6s   
���   �$��264,185,0,0q�6�   $��34��6�   $	��Top=�6
  ��5N      �� 5O   "   $' !Imagenes/Command-Refresh-blue.png��6-   5Q      �� 5R      -   5        $ btnSeleccionarBebida��5R   !   $ Seleccionar un Registro��6?   $��Seleccionar��6a   $
��Left=�6w   $	��Top=�6�   $��78��6�   $��Normal"�6�    . $ 1.662,0.727&�6  #��[  60  ���	#FFCB5F21$��12(�6z  $��
10,190,0,0q�6�  $��29��6�  5T      5U      �� 5V      -   5        $ label_Copy5��5V      $��Seleccione Proveedor:��6-   $
��Left=�6M   $��	10,10,0,0q�6h   $	��Top=�6{   $��12(�6�   �� 5W      -   5          ��Name$  cbProveedor��5W      $
��Left=�60   $��
162,10,0,0q�6K   $	��Top=�6_   $	��171��6w   $��Normal"�6�   5Y      5Z      �� 5\   
   -   5        $	 groupBox_Copy2��5\      $��Verificar Pedido��6+   $��734,10,23,0q�6E   $	��Top=�6Z   $	��534��6r   ���	#FFCB5F21$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5]      � $
��Left=�6   $	��503��6.   $	��Top=�6;   $	��424��6S   $��0,-2,0,-2.333q�6_   ��6v   Z� .+�5_        -   5        $ dgListaPedido��5_       . $ * 6D   $
��Left=�6T   $��	10,45,0,0q�6o   $	��Top=�6�   $	��353��6�   $	��404��6�   $��Normal"�6�   ���	#FFCB5F21
���   � 5a      ��%�   '        �� 5b      "  6     5c      P� 5d   "    �@ 
IsSelected . . �5e   &   ��  � �� �	#FFFAA5756C   �� 5f   &    � ��
 �   �6C   5g   #   5i      5j      5k      �� 5l      -   5        $ 
btnGuardar��5l      $ Guardar Pedido��6-   $��Guardar��6F   $
��Left=�6X   $	��Top=�6t   $��78��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6\  $��239,446,0,0q�6j  $��29��6  �� 5m      -   5        $ label_Copy2��5m      $��Total del Pedido:��6-   $
��Left=�6I   $��
19,403,0,0q�6d   $	��Top=�6x   $��12(�6�   �� 5n      -   5        $ lblTotal��5n      $��-��6*   $
��Left=�66   $��128,403,0,0q�6Q   $	��Top=�6f   $��12(�6~   �� 5o      -    5        $ btnEliminar��5o      $+ %Quitar registro de la lista de Pedido��6.   $��Quitar��6^   $
��Left=�6o   $	��Top=�6�   $��78��6�   $��Normal"�6�    . $ 1.662,0.727&�6  #��[  6(  ���	#FFCB5F21$��12(�6r  $��
19,446,0,0q�6�  $��29��6�  �� 5p      -!   5        $ label_Copy4��5p      $��Número de Pedido:��6-   $
��Left=�6I   $��	10,10,0,0q�6d   $	��Top=�6w   $��12(�6�   �� 5q      -"   5        $ 	lblNumero��5q      $��-��6+   $
��Left=�67   $��
134,10,0,0q�6R   $	��Top=�6f   $��12(�6~   �� 5r      -#   5        $ btnCancelar��5r      $ Cancelar Operación��6.   $��Cancelar��6K   $
��Left=�6^   $��339,446,0,0q�6y   $	��Top=�6�   $��75��6�   $��Normal"�6�   $ Arrow��6�    . $ 1.662,0.727&�6�   #��[  6"  ���	#FFA11400$��12(�6l  6z  5u      5v      5x      5y      