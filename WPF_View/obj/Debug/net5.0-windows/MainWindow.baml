   M S B A M L   `   `   `  ����C  ?WPF_View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WPF_ViewWPF_View  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   G CClassLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:ClassLibrary;assembly=ClassLibraryClassLibrary 5   	       WPF_View.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WPF_View     5   	   9system&clr-namespace:System;assembly=mscorlib     5   	   R NOxyPlot.Wpf, Version=2.1.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0Y	 UOxyPlot.Wpf.Shared, Version=2.1.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0"oxyhttp://oxyplot.org/wpf  	 5
   	   ;zz0clr-namespace:ClassLibrary;assembly=ClassLibrary  	 5   	     � Title$  
MainWindow��5	   	   $	��650��6   $
��1100��6)    � 
ResizeMode$ NoResize=�5   E    � 	Resources 5         key_EnumFun S� 
ObjectTypeU
 QSystem.Runtime, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a 
 System.Enum S� 
MethodName S� MethodParameters M� TypeName��%u   &	        S� 5   
   "  5      $ 	GetValues��5       5      M� 5      $ zz:Spf��6   5      5      .��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      $
��350* �6#   �� 5      $
��450* �6#   .+�5      � $��0��6   $	��210��6$   $	��150��61   $
��Left=�6=   $	��Top=�6X   ���	#FFA6FFE1$��20, 5, 0, 0q�6�   .+�5      ��  �� Orientation$ Vertical=�6   $��Center=�64   $��Center=�6O   $	��214��6l   .+�5      �� $��Measure Function��6   $��Italic$�67   
����  �$��Center=�6]   6}   �� 5      	 �� SelectedIndex$	 0��6z   ��6   �� 
 �� Source#
 [   �� SelectedItem 6[   �� *F_Fun+6�   �� 5      6"   �� 5!      $ 
Horizontal=�6!   .+�5"      �� $
��n = ��6    
����  �$��31��6A   6N   �� 5#      $��20��6�   $��70��6�   ��6"   ��  �� Path$ M_Data_0� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors$
 True��6�   5$      �� 5&      $ 
Horizontal=�6!   .+�5'      �� $
��a = ��6    
����  �$��31��6A   6N   �� 5(      $��20��6]   $��70��6i   ��6"   �� $ M_Data_1�$
 True��6i   5)      �� 5+      $ 
Horizontal=�6!   .+�5,      �� $
��b = ��6    
����  �$��31��6A   6N   �� 5-      $��20��6]   $��70��6i   ��6"   �� $ M_Data_2�$
 True��6i   5.      �� 5/      $��Type of nodes on x axis��6   $��Italic$�6>   
����  �$��25��6c   $��12(�6o   6   � 50      .+�51      	� $��Uniform��6&    d� 	IsChecked$
 TrueY�68   $��10(�6J   $
��Left=�6X   $	��Top=�6s   $��69��6�   	� 52      $��Random��6&   $��10(�6Y   $
��Left=�6g   $��65,0,0,0q�6�   $��Center=�6�    67   �� *not_Uniform+6�   53      �� 54      $��7��6    6-   �� 55      $��20��6   $��Make MeasuredData��6)   ��6E   �� *MakeMeasureCommand+56      57      �� 58      $��0��6   $	��400��6)   $	��200��66   $
��Left=�6B   $��Bottom=�6]   .+�59      �� $��MeasuredData��6   $��Italic$�6/   
����  �$��Center=�6T   6s   �� 5:      $��10, 0, 0, 20q�6A   $	��350��6W   ��6   �� *Measured_Items+6g   5;      � 5<      -   5        $��OxyPlot��5<      $��1��6"   .+�5=        OxyPlot.Wpf.PlotView   	 OxyPlot.Wpf.PlotViewBase   Model 6   �� *OxyPlot_D.plotModel+6G   5>      �� 5@      -   5        $��
Spline_Par��5@      $ Vertical=�6+   $	��Top=�6B   $��Right=�6Z   $	��210��6v   $��0, 5, 50, 0q�6�   ���	#FFD3FFCC$	��150��6�   .+�5A      �� $��Spline Parametres��6   $��Italic$�64   
����  �$��Center=�6Y   6y   �� 5C      $ 
Horizontal=�6   .+�5D      �� $
��n = ��6   
����  �$��31��6=   6J   �� 5E      -   5        $��Spline_N��5E      $��20��6�   $��70��6�   ��6.   �� $ nx_spl�$ PropertyChanged=�$
 True��6�   5F      �� 5H      6   �� 5I      $��Integral Parametres��6   $��Italic$�66   
����  �$��Center=�6[   6{   �� 5K      $ 
Horizontal=�6   .+�5L      �� $��x1 = ��6   
����  �$��31��6>   6K   �� 5M      -   5        $	��X_1��5M      $��20��6b   $��70��6n   ��6)   �� $ Sp_I_0�$
 True��6n   5N      �� 5P      $ 
Horizontal=�6   .+�5Q      �� $��x2 = ��6   
����  �$��31��6>   6K   �� 5R      -   5        $	��X_2��5R      $��20��6b   $��70��6n   ��6)   �� $ Sp_I_1�$
 True��6n   5S      �� 5U      $ 
Horizontal=�6   .+�5V      �� $��x3 = ��6   
����  �$��31��6>   6K   �� 5W      -   5        $	��X_3��5W      $��20��6b   $��70��6n   ��6)   �� $ Sp_I_2�$
 True��6n   5X      �� 5Z      $��7��6   6)   �� 5[      $��20��6   $��Make Spline��6%   ��6;   �� *MakeSplineCommand+�� 5]      $��50��6   6*   5^      �� 5`      $��0��6   $	��400��6)   $	��200��66   $��Right=�6B   $��Bottom=�6^   $��0, 0, 30, 0q�6y   .+�5a      �� $��
SplineData��6   $��Italic$�6-   
����  �$��Center=�6R   6q   �� 5b      $��10, 0, 0, 20q�6=   $	��350��6S   ��6   �� *
Spline_Der+6c   5c      5d      5e      5f      