   M S B A M L   `   `   `  ����  gallery_mk4-    'gallery_mk4.Windows.AddExhibitionWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$'  !Добавить выставку��5   	   $	��400��5   	   $	��600��5	   	   ���#F5F5DC � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $(��"Название выставки:��6   $��0��6-   �� 5   
   $��1��5      $��0,0,0,10q�5      ��5      �� *NewExhibition.Title+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $��Дата начала:��6   $��2��6'   (  "System.Windows.Controls.DatePicker  5   
   $��3��5      $��0,0,0,10q�5          SelectedDate 5      �� *NewExhibition.StartDate+$ PropertyChanged=�5       �� 5"   
   $"��Дата окончания:��6   $��4��6*     5#   
   $��5��5$      $��0,0,0,10q�5%       5#      �� *NewExhibition.EndDate+$ PropertyChanged=�5%      �� 5'   
   $��6��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $
��0,10q�6W   .+�5(      �� -   5        $��Отмена��5(      $	��120��5)      $��36��5*      $��0,0,12,0q�5+      $��14(�5,       �� IsCancel . ���#F44336
�������
������ $��1q�52       � Cursor$
 Hand��53       � ToolTip$) #Отменить изменения��54      	 � 	Resources	 55      
 �� 
TargetType �� Property �� Value��%^   '��       �� 56      "
 ��6   .�57      ��  �@��CornerRadius$ 4��69   58      59      5:      �� 5<      -   5        $��Добавить��5<      $	��120��5=      $��36��5>      $��14(�5?      ���#4CAF50
����������#45A049$��1q�5D      $
 Hand��5E       �� 	IsDefault . $. (Добавить новую запись��5G      	 5H      ��%^   '��       �� 5I      "
 ��6   .�5J      ��  �@��CornerRadius$ 4��69   5K      5L      5M      5N      5O      5P      