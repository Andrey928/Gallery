   M S B A M L   `   `   `  ����  gallery_mk4*    $gallery_mk4.Windows.EditAuthorWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$/  )Редактирование автора��5   	   $	��350��5   	   $	��400��5	   	   ���#F5F5DC � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Имя автора:��6   $��0��6&   �� 5   
   $��1��5      $��0,0,0,10q�5      ��5      �� *CurrentAuthor.Name+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5!   
   $��Год рождения:��6   $��2��6(   �� 5"   
   $��3��5#      $��0,0,0,10q�5$      ��5"      �� *CurrentAuthor.BirthYear+$ PropertyChanged=�5$      �� 5&   
   $��Год смерти:��6   $��4��6&   �� 5'   
   $��5��5(      $��0,0,0,20q�5)      ��5'      �� *CurrentAuthor.DeathYear+$ PropertyChanged=�5)      �� 5,   
   $��7��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5-      �� -   5        $��Отмена��5-      $	��100��5.      $��25��5/      $��0,0,10,0q�50      ���#F44336
�������
������ $��1q�54       �� IsCancel .  � ToolTip$) #Отменить изменения��56       � 	Resources 58      	 �� 
TargetType
 �� Property �� Value��%^   '��       �� 59      "	 ��6   .�5:      �� 
 �@��CornerRadius$ 5��69   5;      5<      5=      �� 5>      -   5        $��Сохранить��5>      $	��100��5?      $��25��5@      ���#4CAF50
����������#45A049$��1q�5D       � Cursor$
 Hand��5E       �� 	IsDefault . $+ %Сохранить изменения��5G       5I      ��%^   '��       �� 5J      "	 ��6   .�5K      �� 
 �@��CornerRadius$ 5��69   5L      5M      5N      5O      5P      5Q      