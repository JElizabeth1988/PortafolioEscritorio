   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5	   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5
   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5   	      Vista.WPFTableroEjecucion   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	   localclr-namespace:Vista  5   	   -   5        $��2q�5   	   
���   �  � Title$&   Visualizar Tablero de Ejecución��5   	   $��546.336��61   $��1121.48��6B   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � WindowStyle$ 
ToolWindow=�6k   ���	#FFD2DBEC$
��Bold"�6�    � WindowStartupLocation$ CenterScreen=�6�    � Cursor$ Arrow��6�    � Icon$ Imagenes/LogoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6     TitleCharacterCasing$ Normal=�6  .��5      � ���	#FFDBDFE3.+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��533��6:   $	��Top=�6G   $
��1127��6_   $��Imagenes/about-img.jpg��6l   $
��Fill=�6�   	 J� Opacity$		 0.3Q�6�   $��0,0,-15,-17.667q�6�   �� 5   
   -   5        
 ��Name$
 	gbFiltrar��5      $��Tablero de Ejecución��6&   $��41,21,42.333,31q�6D   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper   ContentCharacterCasing$ Upper=�6u   $��13.333(�6�   ���	#FFCB5F21.��5      � $
��Left=�6   $	��416��6.   $��10,4,-0.333,0q�6;   $	��Top=�6R   $
��1009��6j   .+�5      �� -   5        $ images��5      $
��Left=�6(   $��625,0,0,356q�6C   $	��156��6X   $��Imagenes/logoFinal3.png��6d   &   System.Windows.Controls.DataGrid  5      -   5          Name$ dgLista��5         
IsReadOnly . $��
29,65,42,0q�6>   $	��Top=�6R   $	��281��6j   $��Normal"�6w   ���	#FFCB5F21
���   � � 	Resources 5      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '        �� 5      "  6     5      P� 5   "    �@ 
IsSelected . . �5   &   ��  � �� �	#FFFAA5756C   �� 5   &    � ��
 �   �6C   5   #   5       5!      5"      �� 5#      -   5         ��Name$ btnSalir��5#       � ToolTip$ Cancelar��6+   $��Cancelar��6?   $
��Left=�6R   $��
29,372,0,0q�6m   $	��Top=�6�   $��75��6�   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  J� RenderTransformOrigin$ 1.662,0.727&�6�      AccentedSquareButtonStyle#��[  6"  ���	#FFCB5F21$��12(�6l  �� 5$      -   5         ��Name$ 
label_Copy��5$      $��Rut Cliente:��6,   $
��Left=�6C   $	��Top=�6^   $��46,9,0,0q�6v   $��93��6�   $��12(�6�   �� 5%      -   5         ��Name$ txtRut��5%      *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ej. 11222333-1��6+   $
��Left=�6]   $��23��6x   $��	163,9,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��151��6�   $��Normal"�6�      ClearTextButton .  �� SelectionBrush �	#FFCB5F216  �� 5&      -	   5        $ btnRut��5&      $  Filtrar por Rut de Cliente��6)   $��Filtrar��6N   $
��Left=�6`   $��339,9,0,381q�6{   $��75��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6L  6Z  �� 5(      -
   5        $ btnRefrescar��5(      $ 	Refrescar��6/   $
��Left=�6C   $��931,370,0,0q�6^   $	��Top=�6s   $��36��6�    / +MahApps.Metro.Styles.MetroCircleButtonStyle#���  6�   $��36��6�   
���   �$ 2.157,3.796&�6  ��5)      �� 5*       �� ImageSource$' !Imagenes/Command-Refresh-Blue.png��6%   5,      �� 5-      -   5        $ 
btnCambiar��5-      $  Cambiar Estado de la Orden��6-   $��Cambiar Estado��6S   $
��Left=�6l   $��595,372,0,0q�6�   $	��Top=�6�   $	��112��6�   $��Normal"�6�    . $ 1.662,0.727&�6  #��[  6@  ���	#FFCB5F21$��12(�6�  �� 5.      -   5        $ label1��5.      $��Seleccione Estado: ��6(   $
��Left=�6F   $��242,376,0,0q�6a   $	��Top=�6v   $	��124��6�   $��12(�6�   	� 5/      -   5          	�Name$  rbListo��5/      $��Listo��6/   $
��Left=�6?   $��24��6Z   $��514,376,0,0q�6f   $	��Top=�6{   ! 	� 	GroupName$! estado��6�   	� 50      -   5        $  rbPreparación��50      $��En Preparación��65   $
��Left=�6N   $��24��6i   $��386,376,0,0q�6u   $	��Top=�6�   $! estado��6�   " d� 	IsChecked$
" TrueY�6�   51      52      54      55      