   M S B A M L   `   `   `  ����  gallery_mk4)    #gallery_mk4.Windows.AddAuthorWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$#  Добавить автора��5   	   $	��400��5   	   $	��600��5	   	   ���#F5F5DC � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0,0,0,20q�6"   .+�5      �� $��Имя автора:��6   �� 5      $��0,0,0,10q�66   ��6   �� *NewAuthor.Name+66   �� 5      $��Год рождения:��6   �� 5      $��0,0,0,10q�6;   ��6   �� *NewAuthor.BirthYear+6;   �� 5      $��Год смерти��6   �� 5      ��6   �� *NewAuthor.DeathYear+5      �� 5"   
   $��4��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5$      �� -   5        $��Отмена��5$      $	��100��5%      $��30��5&      $��0,0,12,0q�5'      $��12(�5(       �� IsCancel . ���#F44336
�������
������ $��1q�5.       � Cursor$
 Hand��5/       � ToolTip$) #Отменить изменения��50       � 	Resources 51       �� 
TargetType	 �� Property
 �� Value��%^   '��       �� 52      " ��6   .�53      �� 	 �@��CornerRadius$
 3��69   54      55      56      �� 59      -   5        $��Добавить��59      $	��100��5:      $��30��5;      $��12(�5<      ���#4CAF50
����������#45A049$��1q�5A      $
 Hand��5B       �� 	IsDefault . $+ %Сохранить изменения��5D       5E      ��%^   '��       �� 5F      " ��6   .�5G      �� 	 �@��CornerRadius$
 3��69   5H      5I      5J      5K      5L      5M      