   M S B A M L   `   `   `  ����A  =ADOwpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ADOwpfADOwpf  5   	       ADOwpf.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:ADOwpf     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ 
MainWindow��5	   	   $	��450��6   $	��600��6)   $
��1000��69   $
��1000��6I   .��5
      �  � 	Resources 5   
    �� MergedDictionaries �� Source�� 5       5      �� 5      $u opack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.green.xaml?�6)   %    5       � RowDefinitions 5   
   �� 5      $	��45* �6   �� 5      $
��292* �6   �� 5      $	��82* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Клиенты��6    �� TextAlignment$ Center=�6#   $��30(�6:   �� 5   
   $��Заказы��6   $ Center=�6"   $��30(�69   $��1��6G   �� 5   
   -   5         ��Name$ btnClear��5      $��1��6#   $��2��63   $	��5,5q�6@   $%��Очистить таблицы��6M   $��15(�6h   $
��Auto��6�   �� 5    
   -   5        $ btnAddRequest��5       $��0��6(   $��2��68   $
��5, 5q�6E   $!��Оформить Заказ��6S   $��15(�6l   $
��Auto��6�   &   System.Windows.Controls.DataGrid  5"   
   -   5        	  Name$	 
dataPerson��5"      $
 �� IsSynchronizedWithCurrentItem$

 TrueY�5#         SelectionMode$ Single=�5$         AutoGenerateColumns .     
IsReadOnly . $��1��5(      ��5&      ��    Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      -   5        id��,  &System.Windows.Controls.DataGridColumn   Header$ Id��5,   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5+   %   �� *Id+5,   %     5.      -   5        lastName��$ Фамилия��50   %    5/   %   �� *
lastName+50   %     52      -   5        	firstName��$ Имя��54   %    53   %   �� *	firstName+54   %     56      -   5        
patronymic��$ Очество��58   %    57   %   �� *
patronymic+58   %     5:      -   5        phoneNumber��$ Телефон��5<   %    5;   %   �� *phoneNumber+5<   %     5>      -	   5        	email��$ 
Почта��5@   %    5?   %   �� *email+5@   %    � ContextMenu 5C      �� 5D      .@�5E      m� -
   5        $��Добавить��5E      61   m� 5F      -   5        $��Удалить��5F      60   5G      5I        5K   
   -   5        $	 dataRequest��5K      $��1��5L      $

 TrueY�5M      $ Single=�5N       .   . $��1��5R      ��5P      ��  5S        5T      -   5        Id��$ Id��5V   %      
IsReadOnly .  5U   %   �� *Id+5W   %     5Y      -   5        
email2��$ 
Почта��5[   %    5Z   %   �� *email+5[   %     5]      -   5        codeProduct��$ Код Продукта��5_   %    5^   %   �� *codeProduct+5_   %     5a      -   5        nameProduct��$ Имя Продукта��5c   %    5b   %   �� *nameProduct+5c   %   5e      5f      5g      