   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <RSXXI, Version=1.0.0.1, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista    Vista.WPFUtilidades   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  6mah,http://metro.mahapps.com/winfx/xaml/controls   localclr-namespace:Vista   -   $��2q�
���   �  � Title$  Visualizar Utilidades��$��625.312��$��874.984�� � WindowStartupLocation$ CenterScreen=� � Cursor$ Arrow��$
��Bold"�(   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � Icon$ Imagenes/LogoFinal2 .png�� � 
ResizeMode$ NoResize=�   TitleCharacterCasing$ Normal=����	#FFDBDFE3.��� $
��Left=�$	��594��$	��Top=�$	��874��$��0,0,-5.333,-0.667q�.+��� -    ��Name$ image��$	��610��$	��Top=�$��Imagenes/about-img.jpg��$
��Fill=� J� Opacity$	 0.3Q�$��0,0,-21,-16q�$
��Left=�$	��895���� -   	 ��Name$	 groupBox_Copy��$��VISUALIZAR INGRESOS��$��49,12,471,0q�$	��Top=�$	��536�����	#FFCB5F21+   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��505��$	��Top=�$	��354��$��0,-2,-10,-1.667q���Z� .+�&   System.Windows.Controls.DataGrid  -     Name$ 
dgListaIng��   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    
IsReadOnly . $
��Left=�$��
10,112,0,0q�$	��Top=�$	��332��$	��320��$��Normal"����	#FFCB5F21
���   � � 	Resources *  $System.Windows.Controls.DataGridCell �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   �(  "System.Windows.Controls.DatePicker  -     Name$ dpHastaI��$
��Left=�$��	83,75,0,0q�$	��Top=�   Text$ Fecha Desde�� � ToolTip$ Seleccione Fecha Desde��  -   $ dpDesdeI��$
��Left=�$��	83,41,0,0q�$	��Top=�$ Fecha Desde��$ Seleccione Fecha Hasta���� -    ��Name$ 
label_Copy��$��Desde:��$
��Left=�$��8,41,0,0q�$	��Top=��� -   $ label_Copy1��$��Hasta:��$
��Left=�$��8,75,0,0q�$	��Top=��� -	   $ label��$��Seleccione un Periodo:��$
��Left=�$��83,0,0,0q�$	��Top=��� -
    ��Name$ btnFiltrarIn��$ Filtrar Periodo��$��Filtrar��$
��Left=�$	��Top=�$��78��$��Normal"�)   #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase .  J� RenderTransformOrigin$ 1.662,0.727&�   AccentedSquareButtonStyle#��[  ���	#FFCB5F21$��12(�$��
252,41,0,0q��� -   $ label_Copy4��$��Total del Periodo:��$
��Left=�$��10,453,0,24q��� -   $ lblIngresos��$��-��$
��Left=�$��132,453,0,23q��� -   $ 
btnCalcIng��$  Calcular Total de Ingresos��$��Calcular��$
��Left=�$��78��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��252,453,0,24q��� -   $	 groupBox_Copy1��$��VISUALIZAR EGRESOS��$��408,12,59,0q�$	��Top=�$	��536�����	#FFCB5F21$
 Upper=�$��13.333(����	#FFCB5F21.��� $
��Left=�$	��505��$	��Top=�$	��398��$��0,-2,0,-1.667q���Z� .+�  -   $ 
dgListaEgr�� . $
��Left=�$��
10,112,0,0q�$	��Top=�$	��334��$	��370��$��Normal"����	#FFCB5F21
���   � ��%p   '        �� "   P�  �@ 
IsSelected . . ���  � �� �	#FFFAA575��  � ��
 �   �  -   $ dpHastaE��$
��Left=�$��
103,75,0,0q�$	��Top=�$ Fecha Desde��$ Seleccione Fecha Desde��  -   $ dpDesdeE��$
��Left=�$��
103,41,0,0q�$	��Top=�$ Fecha Desde��$ Seleccione Fecha Hasta���� -   $ label_Copy2��$��Desde:��$
��Left=�$��	28,41,0,0q�$	��Top=��� -   $ label_Copy3��$��Hasta:��$
��Left=�$��	28,75,0,0q�$	��Top=��� -   $ label1��$��Seleccione un Periodo:��$
��Left=�$��	103,0,0,0q�$	��Top=��� -   $ btnFiltrarEgr��$ Filtrar Periodo��$��Filtrar��$
��Left=�$	��Top=�$��78��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��
282,41,0,0q��� -   $ label_Copy5��$��Total del Periodo:��$
��Left=�$��10,453,0,24q��� -   $ 
lblEgresos��$��-��$
��Left=�$��135,453,0,23q��� -   $ btnCalcEgre��$ Calcular Total de Egresos��$��Calcular��$
��Left=�$��78��$��Normal"� . $ 1.662,0.727&�#��[  ���	#FFCB5F21$��12(�$��302,452,0,24q�