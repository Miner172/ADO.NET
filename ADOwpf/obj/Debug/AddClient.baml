   M S B A M L   `   `   `  ����A  =ADOwpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ADOwpfADOwpf  5   	       ADOwpf.AddClient   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:ADOwpf     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$) #Добавление Клиента��5
   	   $	��400��5   	   $	��500��6   $	��400��5   	   $	��500��6   .��5      �  � 	Resources 5   
    �� MergedDictionaries �� Source�� 5       5      �� 5      $u opack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.green.xaml?�6)   %    5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5"   
   �� -   5         ��Name$ txtLastName��5"   �   $��0��6   $��2��6   $��10q�63   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Фамилия��6?   $��20(�6h   	 �� TextAlignment$	 Center=�6v   6�   �� 5#   
   -   5        $ txtFirstName��5#   �   $��1��6   $��2��6   $��10q�63   $ Имя��6?   $��20(�6d   $	 Center=�6r   6�   �� 5$   
   -   5        $ txtPatronomic��5$   �   $��2��6   $��2��6   $��10q�63   $ Очество��6?   $��20(�6h   $	 Center=�6v   6�   �� 5%   
   -   5        $ txtTelephone��5%   �   $��3��6   $��2��6   $��10q�63   $ Телефон��6?   $��20(�6h   $	 Center=�6v   6�   �� 5&   
   -   5        $ txtEmail��5&   �   $��4��6   $��2��6   $��10q�63   $ 
Почта��6?   $��20(�6f   $	 Center=�6t   6�   �� 5(   
   -   5        
 ��Name$
 okBtn��5(   \   $��Добавить��6   $��0��6$   $��5��64   $	��5.5q�6A   $��25(�6N   $
��auto��6k   �� 5)   
   -   5        $
 	cancelBtn��5)   Z   $��Отмена��6   $��1��6"   $��5��62   $	��5.5q�6?   $��25(�6L   $
��auto��6m   5*      5+      