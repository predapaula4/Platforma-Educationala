   M S B A M L   `   `   `  ����J  FOnline Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Online_Platform.ViewsOnline_Platform.Views  5   	   G(clr-namespace:Online_Platform.ViewModelsOnline_Platform.ViewModels  5   	   '    !Online_Platform.Views.TeacherView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Online_Platform.Views     5   	   ?
viewmodels(clr-namespace:Online_Platform.ViewModels     5   	     � Title$  TeacherView��5	   	   $	��450��6   $	��800��6*    � 	Resources 5
       �� DataType3  -Online_Platform.ViewModels.TeacherAbsenteesVM,   &Online_Platform.Views.TeacherAbsentees � DataContext0  *Online_Platform.ViewModels.TeacherGradesVM)   #Online_Platform.Views.TeacherGrades1  +Online_Platform.ViewModels.TeacherSubjectVM*   $Online_Platform.Views.TeacherSubject.  (Online_Platform.ViewModels.HDAbsenteesVM'   !Online_Platform.Views.HDAbsentees6	  0Online_Platform.ViewModels.GradesVisualisationVM/
   )Online_Platform.Views.GradesVisualisation��%C  (��       5   =   *, +)(�� a     5   :   *, +)(�� �     5   ;   *, +)(��     5   ,   *, +)(�� n    5   4   *,	 +)�� 5   
    TeacherAbsenteesViewTemplate��"  6=   .R�5         6%   �� 5      �� 5   
   TeacherGradesViewTemplate��"  6:   .R�5         6"   �� 5      �� 5   
   TeacherSubjectViewTemplate��"  6;   .R�5         6#   �� 5      �� 5   
   HDAbsentees��"  6,   .R�5         6    �� 5      �� 5   
   GradesVisualisation��" 	 64   .R�5      
   6(   �� 5      5      .��5      � 
����ح� � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5       $��1* �6   �� 5!      $��1* �6    � RowDefinitions 5#   
   �� 5$      $��50 �6   �� 5%      $��1* �6   �� 5&      $��1* �6   �� 5'      $��1* �6   �� 5(      $��1* �6   .+�5+   
   ]� $��0��6   $��0��6$   $��5��61   
�������.+�5-      �� -   5        $	��160��5-   :   
�������.��6Y   Absentele unui elev6n   �� 5.      -   5        $	��160��5.   8   
�������.��6W   Notele unui elev6i   �� 5/      -   5        $	��160��5/   9   
�������.��6X   Modificare materiale6n   �� 50      -   5        $��
checkabsHT��50      $	��160��6j   
�������y�6D   �� *IsHeadTeacher+.��6�   Motivare Absente6�   �� 51      -   5        $��v2��51      $	��150��6j   
�������y�6E   �� *IsHeadTeacher+.��6�   Ierarhie Clasa6�   53      �� 54   
   $��1��6   $��5��6&   $��4��6:   ��6K   �� 55      56      