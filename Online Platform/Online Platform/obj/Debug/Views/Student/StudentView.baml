   M S B A M L   `   `   `  ����J  FOnline Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Online_Platform.ViewsOnline_Platform.Views  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   G(clr-namespace:Online_Platform.ViewModelsOnline_Platform.ViewModels  5	   	   '    !Online_Platform.Views.StudentView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Online_Platform.Views     5   	   9system&clr-namespace:System;assembly=mscorlib     5   	   <context(clr-namespace:Online_Platform.ViewModels     5	   	     � Title$  StudentView��5
   	   $	��450��6   $	��800��6*   .��5      � 
����ح� � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   �� $��0��6   $��0��6$    �� TextAlignment$ Center=�61   B� 6I   .�6S   	Materii6\   6h   �� 5   
   $��1��6   $��0��6$   $ Center=�62   B� 6J   .�6T   Note6Z   6f   �� 5   
   $��2��6   $��0��6$   $ Center=�62   B� 6J   .�6T   	Absente6]   6i   �� 5   
   $��3��6   $��0��6$   $ Center=�62   B� 6J   .�6T   Medie6[   6g   �� 5   
   $��4��6   $��0��6$   $ Center=�62   B� 6J   .�6T   Materiale didactice6i   6u   �� 5   
   $��2��6   $ Center=�6"   $��3��69   $
��Bold"�6N   $��0,0.4,158,0q�6`   $��20(�6u   Media generala:6�   �� 5   
   $��2��6   $
��Bold"�6I   $��2��6[   $��85,0.4,61,0q�6o   $��1��6�   $��20(�6�   ��6!   �� *studentBL.general_mark+6�   �� 5!   
   -   5        $��
icTodoList��5!      $��0��6Y   $��1��6i   ��6)   �� *studentBL.subject_marks+��5"      �� 5#      .R�5$      �� $ Center=�65   ��6    �� *Key+65   5%      5'      �� 5(   
   -   5        $��icTodoList2��5(      $��1��6L   $��1��6\   ��6*   �� *	MarksList+��5)      �� 5*      .R�5+      �� $ Center=�62   ��6    �� 62   5,      5.      �� 5/   
   -   5        $��icTodoList3��5/      $��2��6P   $��1��6`   ��6*   �� *AbsenteesList+��50      �� 51      .R�52      �� $ Center=�61   ��6    �� 61   53      55      �� 56   
   -   5        $��icTodoList4��56      $��3��6P   $��1��6`   ��6*   �� *FinalMarkList+��57      �� 58      .R�59      �� $ Center=�61   ��6    �� 61   5:      5<      �� 5=   
   -   5        $��icTodoList5��5=      $��4��6W   $��1��6g   ��6*   �� *SubjectMaterialsList+��5>      �� 5?      .R�5@      �� $ Center=�6    �� 5A      -   5        ��5A       �� .�6e   .�5B      �� $ Center=�66   ��6%   �� 66   5C      5D      5E      5G      5H      5J      