   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5
   	      Vista.WPFCliente   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5	   	   localclr-namespace:Vista   5
   	   -   5        $��2q�5   	   
���   �  � Title$  Administrar Cliente��5   	   $��580.978��6%   $��695.318��66    � WindowStartupLocation$ CenterScreen=�6F    � Cursor$ Arrow��6k   $
��Bold"�6z   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6�   ���	#FFDBDFE3.��5      � $
��Left=�6   $	��539��6&   $	��Top=�63   $	��695��6K   $��0,0,-5,-4.333q�6W   .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��556��6:   $	��Top=�6G   $	��701��6_   $��Imagenes/about-img.jpg��6k   $
��Fill=�6�    J� Opacity$	 0.3Q�6�   $��
0,0,-6,-17q�6�   �� 5   
   -   5        	 ��Name$	 groupBox��5      $��Información de Cliente��6%   $��
49,10,50,0q�6E   $	��Top=�6Y   $	��451��6q   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5      � $
��Left=�6   $	��436��6.   $	��Top=�6;   $	��586��6S   $��0,-2,0,-0.667q�6_   ��6v   Z� .+�5      �� -   5         ��Name$ label��5      $
��Rut:��6'   $
��Left=�66   $��	23,25,0,0q�6Q   $	��Top=�6d   �� 5      -   5        $ 
label_Copy��5      $��Apellido Paterno:��6,   $
��Left=�6H   $��
23,137,0,0q�6c   $	��Top=�6w   �� 5      -   5        $ label_Copy1��5      $��Primer Nombre:��6-   $
��Left=�6F   $��	23,61,0,0q�6a   $	��Top=�6t   �� 5      -   5        $ label_Copy2��5      $��Email:��6-   $
��Left=�6>   $��
23,213,0,0q�6Y   $	��Top=�6m   �� 5      -   5        $ label_Copy3��5      $��Celular:��6-   $
��Left=�6@   $��
23,253,0,0q�6[   $	��Top=�6o   �� 5      -	   5        $ label_Copy4��5      $��
Teléfono:��6-   $
��Left=�6A   $��
23,290,0,0q�6\   $	��Top=�6p    J� RenderTransformOrigin$ 0.73,-0.613&�6�   �� 5      -
   5         ��Name$ txtRut��5      $
��Left=�6*   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Rut sin DV��6E   $��8��6v   $��
156,25,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��136��6�   $��Normal"�6�      ClearTextButton .  �� SelectionBrush �	#FFCB5F216D  �� 5      -   5        $ 	txtNombre��5      $
��Left=�6-   $ Ingrese Nombres ��6H   $��8��6w   $��
156,61,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��195��6�   $��Normal"�6�    . $ 0.5,0.5&�6   �	#FFCB5F216+  �� 5      -   5        $ txtSegNombre��5      $
��Left=�60   $ Ingrese Seg. Nombre��6K   $��8��6}   $��
156,99,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��196��6�   $��Normal"�6�    .  �	#FFCB5F216  �� 5      -   5        $ txtApPaterno��5      $
��Left=�60   $ Ingrese Apellido Paterno��6K   $��8��6�   $��156,137,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��196��6�   $��Normal"�6�    .  �	#FFCB5F216  �� 5      -   5        $ txtApeMaterno��5      $
��Left=�61   $ Ingrese Apellido Materno ��6L   $��8��6�   $��156,175,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��196��6�   $��Normal"�6�    .  �	#FFCB5F216  �� 5      -   5        $ txtEmail��5      $
��Left=�6,   $ Ingrese Email��6G   $��8��6s   $��156,213,0,0q�6~   $
 Wrap=�6�   $	��Top=�6�   $	��196��6�   $��Normal"�6�    .  �	#FFCB5F216  �� 5       -   5        $ 
txtCelular��5       $
��Left=�6.   $ Ej. 988888888��6I   $��8��6u   $��156,253,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��136��6�   $��Normal"�6�    .  �	#FFCB5F216'  �� 5!      -   5        $ txtTelefono��5!      $
��Left=�6/   $ Ej. 288888888��6J   $��8��6v   $��156,290,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��136��6�   $��Normal"�6�    .  �	#FFCB5F216)  �� 5"      -   5         ��Name$ 
btnGuardar��5"       � ToolTip$ Guardar Registro��6-   $��Guardar��6I   $
��Left=�6[   $��136,368,0,0q�6v   $	��Top=�6�   $��75��6�   $ Arrow��6�   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  . $ 1.662,0.727&�6#     AccentedSquareButtonStyle#��[  6G  ���	#FFCB5F21$��12(�6�  6�  �� 5#      -   5        $ btnCancelar��5#      $ Cancelar��6.   $��Cancelar��6B   $
��Left=�6U   $��472,368,0,0q�6p   $	��Top=�6�   $��75��6�   $��Normal"�6�   $ Arrow��6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6c  6q  �� 5$      -   5        $ btnPregunta��5$      $ Ver Listado de Clientes��6.   $��?��6Q   $
��Left=�6]   $��
370,25,0,0q�6x   $	��Top=�6�   $��33��6�   $��Normal"�6�   $��25��6�   $ Arrow��6�    . $ 1.662,0.727&�6	  #��[  6-  ���	#FFCB5F21$��12(�6w  6�  �� 5%      -   5        $ 	btnBuscar��5%      $ Buscar Cliente��6,   $��Buscar��6F   $
��Left=�6W   $��
418,25,0,0q�6r   $	��Top=�6�   $��25��6�   $��64��6�   $ Arrow��6�   $��Normal"�6�    . $ 1.662,0.727&�6  #��[  6&  ���	#FFCB5F21$��12(�6p  6~  �� 5&      -   5        $ 
btnLimpiar��5&      $ Limpiar Casillas��6-   $��Limpiar��6H   $
��Left=�6Z   $��
28,368,0,0q�6u   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6X  6f  �� 5'      -   5        $ btnModificar��5'      $ Actualizar Registro��6/   $��
Actualizar��6M   $
��Left=�6b   $��136,368,0,0q�6}   $	��Top=�6�   $ Arrow��6�   $��80��6�   $��Normal"�6�    . $ 1.662,0.727&�6  #��[  6'  ���	#FFCB5F21$��12(�6q  6  �� 5(      -   5        $ image1��5(      $
��Left=�6(   $��78��6C   $��
407,76,0,0q�6O   $	��Top=�6c   $	��156��6{   $��Imagenes/logoFinal3.png��6�   $ 1.091,0.822&�6�   �� 5+      -   5        $ txtDV��5+      $
��Left=�6)   $��23��6D   $��
321,25,0,0q�6P   $
 Wrap=�6d   $	��Top=�6x   $��30��6�   $ 0.422,0.462&�6�   $��Normal"�6�   {�.  6�   �� 5,      -   5        $ label1��5,      $��-��6(   $
��Left=�64   $��
298,25,0,0q�6O   $	��Top=�6c   $��18��6{   �� 5-      -   5        $ label_Copy7��5-      $��Apellido Materno:��6-   $
��Left=�6I   $��
23,175,0,0q�6d   $	��Top=�6x   �� 5.      -   5        $ label_Copy5��5.      $��Segundo Nombre:��6-   $
��Left=�6G   $��	23,99,0,0q�6b   $	��Top=�6u   �� 5/      -   5        $ btnEliminar��5/      $ Eliminar Registro��6.   $��Eliminar��6K   $
��Left=�6^   $��251,368,0,0q�6y   $	��Top=�6�   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFDF0D0D$��12(�6^  6l  �� 50      -   5        $
 lbl1��50      $��*��6&   $
��Left=�63   $��
351,25,0,0q�6N   $	��Top=�6b   $��12(�6z   ���	#FF9201016�   �� 51      -   5        $ 	lbl1_Copy��51      $��*��6+   $
��Left=�68   $��
351,62,0,0q�6S   $	��Top=�6g   $��12(�6   ���	#FF9201016�   �� 52      -    5        $ 
lbl1_Copy1��52      $��*��6,   $
��Left=�69   $��292,253,0,0q�6T   $	��Top=�6i   $��12(�6�   ���	#FF9201016�   �� 53      -!   5        $ 
lbl1_Copy2��53      $��*��6,   $
��Left=�69   $��351,137,0,0q�6T   $	��Top=�6i   $��12(�6�   ���	#FF9201016�   �� 54      -"   5        $ 
lbl1_Copy4��54      $��*��6,   $
��Left=�69   $��351,213,0,0q�6T   $	��Top=�6i   $��12(�6�   ���	#FF9201016�   59      5:      �� 5;   
   -#   5        $	 	groupBox1��5;      $��Respaldo Caché��6&   $
��Left=�6>   $��73��6Y   $��
49,466,0,0q�6e   $	��Top=�6y   $	��596��6�   ���	#FFCB5F21���	#FFCB5F21.��5<      � .+�5=      �� -$   5        $ label2��5=      $��Último Respaldo:��6(   $
��Left=�6C   $��27,3,0,0q�6^   $	��Top=�6p   $
��Bold"�6�   �� 5>      -%   5        $ lblCache��5>      $�� ��6*   $
��Left=�65   $��	130,3,0,0q�6P   $	��Top=�6c   $	��215��6{   �� 5?      -&   5        $ btnCache��5?      $ Recuperar Caché��6+   $��	Recuperar��6F   $
��Left=�6Z   $��	472,3,0,0q�6u   $	��Top=�6�   $��75��6�   #��[  6�   ���	#FFCB5F21$��12(�6  $��Normal"�6  $
 Normal=�6.  5A      5B      5C      5D      