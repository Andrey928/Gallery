   M S B A M L   `   `   `  ����  gallery_mk4)    #gallery_mk4.Windows.AddMediumWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$%  Добавить технику��5   	   $	��300��5   	   $	��400��5	   	   ���#F5F5DC � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $&�� Название техники:��6   $��0��6,   �� 5   
   $��1��5      $��0,0,0,20q�5      ��5      �� *NewMedium.MediumName+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $��4��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5      �� -   5        $��Отмена��5      $	��100��5      $��25��5      $��0,0,10,0q�5      ���#F44336
�������
������  � Cursor$
 Hand��5$       �� IsCancel . $��1q�5&       � ToolTip$) #Отменить изменения��5'       � 	Resources 5(      	 �� 
TargetType
 �� Property �� Value��%^   '��       �� 5)      "	 ��6   .�5*      �� 
 �@��CornerRadius$ 5��69   5+      5,      5-      �� 5.      -   5        $��Добавить��5.      $	��100��5/      $��25��50      ���#4CAF50
����������#45A049$��1q�54      $
 Hand��55       �� 	IsDefault . $+ %Сохранить изменения��57       59      ��%^   '��       �� 5:      "	 ��6   .�5;      �� 
 �@��CornerRadius$ 5��69   5<      5=      5>      5?      5@      5A      