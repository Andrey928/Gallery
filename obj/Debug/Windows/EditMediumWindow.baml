   M S B A M L   `   `   `  ����  gallery_mk4*    $gallery_mk4.Windows.EditMediumWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$1  +Редактирование техники��5   	   $	��350��5   	   $	��450��5	   	   ���#F5F5DC � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $&�� Название техники:��6   $��0��6,   �� 5   
   $��1��5      $��0,0,0,15q�5      ��5      �� *CurrentMedium.MediumName+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $��4��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5      �� -   5        $��Отмена��5      $	��100��5      $��30��5       $��0,0,10,0q�5!      ���#F44336
�������
������ $��1q�5%       �� IsCancel .  � ToolTip$) #Отменить изменения��5'       � 	Resources 5)      	 �� 
TargetType
 �� Property �� Value��%^   '��       �� 5*      "	 ��6   .�5+      �� 
 �@��CornerRadius$ 5��69   5,      5-      5.      �� 5/      -   5        $��Сохранить��5/      $	��100��50      $��30��51      ���#4CAF50
����������#45A049$��1q�55       � Cursor$
 Hand��56       �� 	IsDefault . $+ %Сохранить изменения��58       5:      ��%^   '��       �� 5;      "	 ��6   .�5<      �� 
 �@��CornerRadius$ 5��69   5=      5>      5?      5@      5A      5B      