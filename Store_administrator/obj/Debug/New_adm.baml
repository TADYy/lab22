   M S B A M L   `   `   `  ����N  JStore_administrator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Store_administratorStore_administrator  5   	   !    Store_administrator.New_adm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Store_administrator     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  admin��5	   	   $	��720��6   $
��1080��6$   
������  � 
ResizeMode$ NoResize=�6J   $��-2,0,0,0q�5
   	   $��0q�6    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency .  � WindowStyle$
 None=�6H   .��5      � .+�5   
   �� -   5         ��Name$ s1��5      $	��720��6   $	��Top=�6-    �� Padding$ 10q�6E   $
��1200��6R    �� CornerRadius$ 25��6b   $	��359��6t   $
��Left=�6�   $	��742��6�   $��194,168,0,0q�6�   ��5      �� 5      .��5      �  � Color$ #7be9f6��6#   	 � Offset$		 0.0Q�63   � 5      $ #f083da��6#   $	 1Q�63   5      
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6#      Color$ 	LightGray��63      ShadowDepth$ 0Q�6E   5      �� 5   
   -   5         ��Name$ textBoxLogin��5      $
��Left=�6(   $��	Helvetica)�6C   $��Light"�6Z   $��49��6m   $��280,337,0,0q�6y    �� TextWrapping$
 Wrap=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите логин��6�   $	��Top=�6�   $	��259��6�   $��20(�6�   �� 5   
   -   5        $ textBoxPassword��5      $
��Left=�6+   $��	Helvetica)�6F   $��Light"�6]   $��49��6p   $��597,337,0,0q�6|   $
 Wrap=�6�   $! Введите пароль��6�   $	��Top=�6�   $	��259��6�   $��20(�6�   ��6  �� *	AddGood+ �� Mode$ TwoWay=� �� StringFormat$ N2�� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   -   5        $��Добавить��5      $
��Left=�6$   $��	Helvetica)�6?   $��Light"�6V   $��438,451,0,0q�6i   $	��Top=�6~   $	��222��6�   $��39��6�   $��20(�6�   6�   �� 5   
   $��Пароль:��6   $
��Left=�6"   $��598,289,0,0q�6=   $	��Top=�6R   $��33��6j   $	��124��6v   $��20(�6�   $��	Helvetica)�6�   $��Light"�6�   �� 5   
   $8��2Добавление администратора:��6   $��	Helvetica)�65   $��Light"�6L   $
��Left=�6_   $��381,205,0,0q�6z   $	��Top=�6�   $��24(�6�   �� 5   
   $��Логин:��6   $��	Helvetica)�6!   $��Light"�68   $
��Left=�6K   $��280,289,0,0q�6f   $	��Top=�6{   $��33��6�   $	��124��6�   $��20(�6�   5!      5"      