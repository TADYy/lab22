   M S B A M L   `   `   `  ����N  JStore_administrator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Store_administratorStore_administrator  5   	       Store_administrator.Goods   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Store_administrator     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  goods��5	   	   $	��768��6   $
��1608��6$   
������  � 
ResizeMode$ NoResize=�6J   $��-2,0,0,0q�5
   	   $��0q�6    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency .  � WindowStyle$
 None=�5   :   .��5      � $��2��6   $
��10,0q�6   ��5   
   �� 5      .��5      �  � Color$ #7be9f6��6    � Offset$	 0.0Q�6/   � 5      $ #f083da��6   $ 1Q�6/   5      .+�5   
   �� -   5         ��Name$ s1��5   #    �� CornerRadius$ 10��6   $	��720��6/   $	��Top=�6>   	 �� Padding$	 10q�6V   $
��1200��6c   $	��486��6s   $
��Left=�6�   $
��1065��6�   $��	69,27,0,0q�6�   
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6#      Color$ 	LightGray��63      ShadowDepth$ 0Q�6E   ._�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	goodsGrid��5         AutoGenerateColumns .  $��18(�6t   $��	Helvetica)�6�   $��Light"�6�      HorizontalGridLinesBrush �	#FF080707   VerticalGridLinesBrush �	#FF030303$��0.4,0.4,-0.6,0q�6�      CanUserAddRows .     
IsReadOnly . ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      � $ 	#FFCB8EEE��6'   $ 1Q�69   � 5       $ 	#FFFFBCBC��6'   5!         Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6B      Width5  /System.Windows.Controls.DataGridLengthConverter$	 240 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Name+6T     5&      $ 
Объем��6F   $	 120 6U    6)   �� *
Capacity+6U     5'      $ Количество��6D   $	 150 6X    6)   �� *Amount+6X     5(      $ Цена��6C   $	 140 6Q    6)   �� *Price+6Q     5)      $  Производитель��6J   $	 250 6a    6)   �� *Manufacturer+6a     5*      $ Тип��6B   $	 120 6O    6)   �� *Type+6O   5,      5-      �� 5.   
   -   5        $ s1_Copy��5.      $	��720��6"   $	��Top=�61   $	 10q�6I   $
��1200��6V   $ 25��6f   $	��187��6x   $
��Left=�6�   $
��1064��6�   $��
70,533,0,0q�6�   ��5/      �� 50      $ 0.5,1&�6&   $ 0.5,0&�67   .��51      � $ 	#FFFFBCBC��6#   $ 1Q�65   � 52      $ 	#FFCB8EEE��6#   53      
 55        56      $ 30Q�6#   $ 	LightGray��63   $ 0Q�6E   ._�58      �� -   5        $��
Назад��58      $
��Left=�6%   $��	Helvetica)�6@   $��Light"�6W   $	��Top=�6j   $	��222��6�   $��49��6�   $��24(�6�   ���	#FFFF8F8F$��800.4,92.4,0,0q�6�   ���	#FFEE33336�   59      �� 5:   
   -   5        $��	Helvetica)�5:      $��Light"�6(   $��Обновить��6;   $
��Left=�6N   $��
94,566,0,0q�6i   $	��Top=�6}   $	��222��6�   $��52��6�   $��20(�6�   ���	#FFCC61D66�   �� 5;   
   -   5        $��	Helvetica)�5;      $��Light"�6(   $��Удалить��6;   $
��Left=�6M   $��358,566,0,0q�6h   $	��Top=�6}   $	��223��6�   $��52��6�   $��20(�6�   ���	#FFCC61D66�   �� 5<   
   -   5        $��	Helvetica)�5<      $��Light"�6(   $ ��Сорт. по кол-во��6;   $
��Left=�6U   $��621,566,0,0q�6p   $	��Top=�6�   $	��222��6�   $��52��6�   $��20(�6�   ���	#FFCC61D66�   �� 5=   
   -	   5        $��	Helvetica)�5=      $��Light"�6(   $��Сорт. по цене��6;   $
��Left=�6S   $��879,566,0,0q�6n   $	��Top=�6�   $	��222��6�   $��52��6�   $��20(�6�   ���	#FFCC61D66�   �� 5>   
   -
   5        $��	Helvetica)�5>      $��Light"�6(   $��
Склад��6;   $
��Left=�6K   $��358,635,0,0q�6f   $	��Top=�6{   $	��223��6�   $��49��6�   $��20(�6�   ���	#FFCC61D66�   �� 5?   
   -   5        $��	Helvetica)�5?      $��Light"�6(   $��Добавить��6;   $
��Left=�6N   $��
94,635,0,0q�6i   $	��Top=�6}   $	��222��6�   $��49��6�   $��20(�6�   ���	#FFCC61D66�   �� 5@   
   -   5        $ s1_Copy1��5@      $	��300��6#   $	��Top=�62   $	 10q�6J   $
��1200��6W   $ 25��6g   $	��693��6y   $
��Left=�6�   $	��368��6�   $��1159,32,0,0q�6�   ��5A      �� 5B      $ 0.5,1&�6&   $ 0.5,0&�67   .��5C      � $ 	#FFFFBCBC��6#   $ 0Q�65   � 5D      $ 	#FFFFBCBC��6#   $ 1Q�65   � 5E      $ 	#FFCB8EEE��6#   $	 0.5Q�65   5F      
 5H        5I      $ 30Q�6#   $ 	LightGray��63   $ 0Q�6E   5L      �� 5M   
   $&�� Поиск по названию��6   $��	Helvetica)�6,   $��Light"�6C   $
��Left=�6V   $��1225,58,0,0q�6q   $	��Top=�6�   $��20(�6�   �� 5O   
   $0��*Поиск по производителю��6   $
��Left=�61   $��	Helvetica)�6L   $��Light"�6c   $��1226,295,0,0q�6v   $	��Top=�6�   $��20(�6�   �� 5P   
   -   5        $��
Поиск��5P      $��	Helvetica)�6!   $��Light"�68   $
��Left=�6K   $��1230,420,0,0q�6f   $	��Top=�6|   $	��222��6�   $��39��6�   $��20(�6�   ���	#FFCC61D66�   �� 5Q   
   -   5        $��
Поиск��5Q      $��	Helvetica)�6!   $��Light"�68   $
��Left=�6K   $��1230,181,0,0q�6f   $	��Top=�6|   $	��222��6�   $��39��6�   $��20(�6�   ���	#FFCC61D66�   �� 5R   
   $S��M-----------------------------------------------------------------------------��6   $
��Left=�6h   $��1155,206,0,0q�6�   $	��Top=�6�   $��Franklin Gothic Medium)�6�   $��72(�6�   $	��376��6�   $��59��6�   �� 5S   
   -   5         ��Name$ textBoxManafacture��5S      $��	Helvetica)�6.   $��Light"�6E   $
��Left=�6X   $��36��6s   $��1230,353,0,0q�6    �� TextWrapping$
 Wrap=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$/ )Введите производителя��6�   $	��Top=�6�   $	��222��6�   $��20(�6  �� 5T   
   -   5        $ textBoxSearch��5T      $��	Helvetica)�6)   $��Light"�6@   $
��Left=�6S   $��36��6n   $��1230,111,0,0q�6z   $
 Wrap=�6�   $% Введите название��6�   $	��Top=�6�   $	��222��6�   $��20(�6�   6  �� 5U   
   $S��M-----------------------------------------------------------------------------��6   $
��Left=�6h   $��1155,212,0,0q�6�   $	��Top=�6�   $��Franklin Gothic Medium)�6�   $��72(�6�   $	��376��6�   $��59��6�   �� 5V   
   -   5        $��Нет в наличии��5V      $
��Left=�6)   $��	Helvetica)�6D   $��Light"�6[   $��621,635,0,0q�6n   $	��Top=�6�   $	��222��6�   $��49��6�   $��20(�6�   ���	#FFCC61D66�   �� 5W   
   $S��M-----------------------------------------------------------------------------��6   $
��Left=�6h   $��1155,450,0,0q�6�   $	��Top=�6�   $��Franklin Gothic Medium)�6�   $��72(�6�   $	��376��6�   $��59��6�   �� 5X   
   $S��M-----------------------------------------------------------------------------��6   $
��Left=�6h   $��1155,445,0,0q�6�   $	��Top=�6�   $��Franklin Gothic Medium)�6�   $��72(�6�   $	��376��6�   $��59��6�   �� 5Y   
   $(��"Поиск по категории��6   $��	Helvetica)�6-   $��Light"�6D   $
��Left=�6W   $��1232,529,0,0q�6r   $	��Top=�6�   $��20(�6�   �� 5Z   
   -   5        $ textBoxCategory��5Z      $
��Left=�6+   $��	Helvetica)�6F   $��Light"�6]   $��36��6p   $��1235,587,0,0q�6|   $
 Wrap=�6�   $' !Введите категорию��6�   $	��Top=�6�   $	��222��6�   $��20(�6�   �� 5[   
   -   5        $��
Поиск��5[      $
��Left=�6!   $��	Helvetica)�6<   $��Light"�6S   $��1233,656,0,0q�6f   $	��Top=�6|   $	��222��6�   $��39��6�   $��20(�6�   ���	#FFCC61D65\      5]      5^      