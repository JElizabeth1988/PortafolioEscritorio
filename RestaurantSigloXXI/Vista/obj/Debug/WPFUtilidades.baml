   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista 5
   	      Vista.WPFUtilidades   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5	   	   localclr-namespace:Vista   5
   	   -   5        $��2q�5   	   
���   �  � Title$  Visualizar Utilidades��5   	   $��625.312��6'   $��874.984��68    � WindowStartupLocation$ CenterScreen=�6H    � Cursor$ Arrow��6m   $
��Bold"�6|   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png��6�    � 
ResizeMode$ NoResize=�6�      TitleCharacterCasing$ Normal=�6�   ���	#FFDBDFE3.��5      � $
��Left=�6   $	��594��6&   $	��Top=�63   $	��874��6K   $��0,0,-5.333,-0.667q�6W   .+�5   
   �� -   5         ��Name$ image��5      $	��610��6   $	��Top=�6,   $��Imagenes/about-img.jpg��6D   $
��Fill=�6d    J� Opacity$	 0.3Q�6s   $��0,0,-21,-16q�6�   $
��Left=�6�   $	��895��6�   �� 5   
   -   5        	 ��Name$	 groupBox_Copy��5      $��VISUALIZAR INGRESOS��6*   $��49,12,471,0q�6G   $	��Top=�6\   $	��536��6t   ���	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5      � $
��Left=�6   $	��505��6.   $	��Top=�6;   $	��354��6S   $��0,-2,-10,-1.667q�6_   ��6x   Z� .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgListaIng��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6/      
IsReadOnly . $
��Left=�6Q   $��
10,112,0,0q�6l   $	��Top=�6�   $	��332��6�   $	��320��6�   $��Normal"�6�   ���	#FFCB5F21
���   � � 	Resources 5      *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '        �� 5      "  6     5      P� 5   "    �@ 
IsSelected . . �5   &   ��  � �� �	#FFFAA5756C   �� 5   &    � ��
 �   �6C   5   #   5      5      5      (  "System.Windows.Controls.DatePicker  5       -   5          Name$ dpHastaI��5       $
��Left=�60   $��	83,75,0,0q�6K   $	��Top=�6^      Text$ Fecha Desde��6v    � ToolTip$ Seleccione Fecha Desde��6�     5!      -   5        $ dpDesdeI��5!      $
��Left=�60   $��	83,41,0,0q�6K   $	��Top=�6^   $ Fecha Desde��6v   $ Seleccione Fecha Hasta��6�   �� 5"      -   5         ��Name$ 
label_Copy��5"      $��Desde:��6,   $
��Left=�6=   $��8,41,0,0q�6X   $	��Top=�6j   �� 5#      -   5        $ label_Copy1��5#      $��Hasta:��6-   $
��Left=�6>   $��8,75,0,0q�6Y   $	��Top=�6k   �� 5$      -	   5        $ label��5$      $��Seleccione un Periodo:��6'   $
��Left=�6H   $��83,0,0,0q�6c   $	��Top=�6u   �� 5%      -
   5         ��Name$ btnFiltrarIn��5%      $ Filtrar Periodo��6/   $��Filtrar��6I   $
��Left=�6[   $	��Top=�6w   $��78��6�   $��Normal"�6�   )   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  J� RenderTransformOrigin$ 1.662,0.727&�6�      AccentedSquareButtonStyle#��[  6  ���	#FFCB5F21$��12(�6e  $��
252,41,0,0q�6s  �� 5&      -   5        $ label_Copy4��5&      $��Total del Periodo:��6-   $
��Left=�6J   $��10,453,0,24q�6e   �� 5'      -   5        $ lblIngresos��5'      $��-��6-   $
��Left=�69   $��132,453,0,23q�6T   �� 5(      -   5        $ 
btnCalcIng��5(      $  Calcular Total de Ingresos��6-   $��Calcular��6R   $
��Left=�6e   $��78��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6
  ���	#FFCB5F21$��12(�6T  $��252,453,0,24q�6b  5*      5+      �� 5,   
   -   5        $	 groupBox_Copy1��5,      $��VISUALIZAR EGRESOS��6+   $��408,12,59,0q�6G   $	��Top=�6\   $	��536��6t   ���	#FFCB5F21$
 Upper=�6�   $��13.333(�6�   ���	#FFCB5F21.��5-      � $
��Left=�6   $	��505��6.   $	��Top=�6;   $	��398��6S   $��0,-2,0,-1.667q�6_   ��6v   Z� .+�5/        -   5        $ 
dgListaEgr��5/       . $
��Left=�6A   $��
10,112,0,0q�6\   $	��Top=�6p   $	��334��6�   $	��370��6�   $��Normal"�6�   ���	#FFCB5F21
���   � 51      ��%�   '        �� 52      "  6     53      P� 54   "    �@ 
IsSelected . . �55   &   ��  � �� �	#FFFAA5756C   �� 56   &    � ��
 �   �6C   57   #   59      5:      5;        5<      -   5        $ dpHastaE��5<      $
��Left=�60   $��
103,75,0,0q�6K   $	��Top=�6_   $ Fecha Desde��6w   $ Seleccione Fecha Desde��6�     5=      -   5        $ dpDesdeE��5=      $
��Left=�60   $��
103,41,0,0q�6K   $	��Top=�6_   $ Fecha Desde��6w   $ Seleccione Fecha Hasta��6�   �� 5>      -   5        $ label_Copy2��5>      $��Desde:��6-   $
��Left=�6>   $��	28,41,0,0q�6Y   $	��Top=�6l   �� 5?      -   5        $ label_Copy3��5?      $��Hasta:��6-   $
��Left=�6>   $��	28,75,0,0q�6Y   $	��Top=�6l   �� 5@      -   5        $ label1��5@      $��Seleccione un Periodo:��6(   $
��Left=�6I   $��	103,0,0,0q�6d   $	��Top=�6w   �� 5A      -   5        $ btnFiltrarEgr��5A      $ Filtrar Periodo��60   $��Filtrar��6J   $
��Left=�6\   $	��Top=�6x   $��78��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6  ���	#FFCB5F21$��12(�6e  $��
282,41,0,0q�6s  �� 5B      -   5        $ label_Copy5��5B      $��Total del Periodo:��6-   $
��Left=�6J   $��10,453,0,24q�6e   �� 5C      -   5        $ 
lblEgresos��5C      $��-��6,   $
��Left=�68   $��135,453,0,23q�6S   �� 5D      -   5        $ btnCalcEgre��5D      $ Calcular Total de Egresos��6.   $��Calcular��6R   $
��Left=�6e   $��78��6�   $��Normal"�6�    . $ 1.662,0.727&�6�   #��[  6	  ���	#FFCB5F21$��12(�6S  $��302,452,0,24q�6a  5F      5G      5I      5J      