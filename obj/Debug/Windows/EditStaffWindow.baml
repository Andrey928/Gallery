   M S B A M L   `   `   `  ����  gallery_mk4)    #gallery_mk4.Windows.EditStaffWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$7  1Редактирование сотрудника��5   	   $	��500��5   	   $	��500��5	   	   ���#F5F5DC � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��ФИО:��6   $��0��6   �� 5   
   $��1��5       $��0,0,0,10q�5!      ��5      �� *CurrentStaff.FIO+ �� UpdateSourceTrigger$ PropertyChanged=�5!      �� 5#   
   $��Должность:��6   $��2��6%   �� 5$   
   $��3��5%      $��0,0,0,10q�5&      ��5$      �� *CurrentStaff.Position+$ PropertyChanged=�5&      �� 5(   
   $��Дата приема:��6   $��4��6'   (  "System.Windows.Controls.DatePicker  5)   
   $��5��5*      $��0,0,0,10q�5+         SelectedDate 5)      �� *CurrentStaff.HireDate+$ PropertyChanged=�5+      �� 5-   
   $��Email:��6   $��6��6!   �� 5.   
   $��7��5/      $��0,0,0,10q�50      ��5.      �� *CurrentStaff.Email+$ PropertyChanged=�50      �� 52   
   $��Телефон:��6   $��8��6#   �� 53   
   $��9��54      $��0,0,0,20q�55      ��53      �� *CurrentStaff.Phone+$ PropertyChanged=�55      �� 57   
   $��11��6    �� Orientation$ 
Horizontal=�6#   $��Right=�6<   .+�58      �� -   5        $��Отмена��58      $	��100��59      $��30��5:      $��0,0,10,0q�5;      ���#F44336
�������
������ $��1q�5?       �� IsCancel .  � ToolTip$) #Отменить изменения��5A      	 � 	Resources	 5C      
 �� 
TargetType �� Property �� Value��%^   '��       �� 5D      "
 ��6   .�5E      ��  �@��CornerRadius$ 5��69   5F      5G      5H      �� 5I      -   5        $��Сохранить��5I      $	��100��5J      $��30��5K      ���#4CAF50
����������#45A049$��1q�5O       � Cursor$
 Hand��5P       �� 	IsDefault . $+ %Сохранить изменения��5R      	 5T      ��%^   '��       �� 5U      "
 ��6   .�5V      ��  �@��CornerRadius$ 5��69   5W      5X      5Y      5Z      5[      5\      