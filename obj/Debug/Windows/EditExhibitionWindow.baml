   M S B A M L   `   `   `  ����  gallery_mk4.    (gallery_mk4.Windows.EditExhibitionWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$3  -Редактирование выставки��5   	   $	��400��5   	   $	��600��5	   	   ���#F5F5DC � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��15,15,15,15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $(��"Название выставки:��6   $��0��6-   �� 5   
   $��1��5      $��0,0,0,10q�5      ��5      �� *CurrentExhibition.Title+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5"   
   $��Дата начала:��6   $��2��6'   (  "System.Windows.Controls.DatePicker  5#   
   $��3��5$      $��0,0,0,10q�5%         SelectedDate 5#      �� *CurrentExhibition.StartDate+$ PropertyChanged=�5%      �� 5(   
   $"��Дата окончания:��6   $��4��6*     5)   
   $��5��5*      $��0,0,0,20q�5+       5)      �� *CurrentExhibition.EndDate+$ PropertyChanged=�5+      �� 5.   
   -   5        $��Отмена��5.      $��7��5/      $	��100��50      $��30��51      $��	0,0,110,0q�52      ���#F44336
�������
������ $��1q�56       �� IsCancel .  � ToolTip$) #Отменить изменения��58      $��Right=�59       � 	Resources 5;      	 �� 
TargetType
 �� Property �� Value��%^   '��       �� 5<      "	 ��6   .�5=      �� 
 �@��CornerRadius$ 5��65   5>      5?      5@      �� 5B   
   -   5        $��Сохранить��5B      $��7��5C      $	��100��5D      $��30��5E      ���#4CAF50
����������#45A049$��1q�5I       � Cursor$
 Hand��5J       �� 	IsDefault . $+ %Сохранить изменения��5L      $��Right=�5M       5O      ��%^   '��       �� 5P      "	 ��6   .�5Q      �� 
 �@��CornerRadius$ 5��65   5R      5S      5T      5U      5V      