   M S B A M L   `   `   `  ����F  BLesson10-v2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Lesson10_v2Lesson10_v2  5   	       Lesson10_v2.MainWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Lesson10_v2     5   	     � Title$  ТелеграмБот��5   	   $	��480��5	   	   $	��640��6   $	��640��5
   	   $	��480��6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ IncomingListBox��5      $��0��5      $��5��6"   $��5q�5      $��5q�6    �� SelectionMode$ Single=�5      ��5      �� 5      .R�5       �� $��5q�6!   .+�5!      �� $��15(�6?   ��6$   �� *	FirstName+6?   �� 5"      
�������$��10(�6S   ��6$   �� *DateTimeMes+6S   �� 5#      $��15(�6=   ��6$   �� *	TextMes+6=   5$      5%      5'      �� 5)   
   -   5         ��Name$ InfoTextBlock��5)      $��2��5*      $��0��6$   $��5q�5+       �� Padding$ 5q�6   $��Имя��5,      �� 5.   
   -   5         ��Name$ MessageTextBox��5.      $��2��5/      $��2��6"   $��5q�50      $��5q�6   $��40��51      $	��Top=�52      	 �� TextWrapping$
	 Wrap=�53      $�� ��54      �� 56   
   -   5        
 ��Name$
 SendMessageBotton��56      $��2��57      $��2��6!   $��5q�58      $��5q�6   $��40��59      $	��120��6   $��Center=�5:      $��Center=�6.   .��5;      �� $
��Wrap=�6    �� TextAlignment$ Center=�6,   $��Center=�5<      $��Center=�65   $)��#Отправка сообщения��5=      5>      �� 5@   
   -   5        $
 LoadLogButton��5@      $��2��5A      $��2��6!   $��5q�5B      $��5q�6   $��40��5C      $	��120��6   $
��Left=�5D      $��Bottom=�6,   $��Загрузить лог��5E      6)   �� 5G   
   -   5        $
 SaveLogButton��5G      $��2��5H      $��2��6!   $��5q�5I      $��5q�6   $��40��5J      $	��120��6   $��Right=�5K      $��Bottom=�6-   $��Сохранить лог��5L      6)   R� 5N   
   $��2��6   $��4��6#   $��5q�5O      5Y      5Z      