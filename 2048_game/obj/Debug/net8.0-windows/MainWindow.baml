   M S B A M L   `   `   `  ����  	2048_game    _2048_game.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  	2048_game��5   	   $	��540��6   $	��960��6(   .��5      � ���#fbf8ef � RowDefinitions 5   
   �� 5	      $��0.15* �6   �� 5
      $��0.75* �6   �� 5      $��0.13* �6    � ColumnDefinitions 5   
   �� 5      $��0.15* �6   �� 5      $��0.30* �6   �� 5      $��0.15* �6   .+�5   
   (� .��5      �� $
��2048��6   $��70(�6$   $
��Bold"�62   ���#776e63$��Center=�5      $
��Left=�63   5      (� 5   
   $��0��6   $��1��6   .��5      ��  �� Orientation$ Vertical=�6   $��Center=�60   $��Center=�6M   $��0q�6h   .+�5      �� -   5         ��Name$ ScoreTextBlock��5      $��Score: 0��64   $
��Bold"�6D   $��20(�6V   $��10q�6d   ���#907a65$��Right=�5   1   �� 5      -   5        $ BestScoreTextBlock��5      $��Best: 0��68   $
��Bold"�6G   $��20(�6Y   $��10q�6g   ���#907a65$��Right=�5   1   5      5      (� 5   
   $��0��6   $��2��6   .��5      �� -   5         ��Name$ NewGameButton��5      $
��Bold"�6,   $��New Game��6>   $��15(�6Q   $��Right=�5       $��10q�5!   Q   $��30��6]   $	��100��6i   $��40��5"       �� 	IsDefault$
 True��5#      
����������#A9A9A9���#907a65 � 	Resources 6f    �� 
TargetType	 �� Property
 �� Value��%b   '��       �� 5$      " ��6   .�5%      �� 	 �@��CornerRadius$
 3��5&      5'      5(      6#   5)      (� 5*   
   $��1��6   $��1��6   .��5+   
   � 
������ .+�5,      �� -   5         ��Name$ Border��5,      $��6q�6%   
�������$��30q�6M    �� CornerRadius$ 5��6Y   ._�5-      � -   5         �Name$ 	HerniPole��5-       � ShowGridLines$ False��6*    5.      �� 5/      $	��100 �6+   �� 50      $	��100 �6+   �� 51      $	��100 �6+   �� 52      $	��100 �6+    54      �� 55      $	��100 �6(   �� 56      $	��100 �6(   �� 57      $	��100 �6(   �� 58      $	��100 �6(   5:      5;      5<      5=      (� 5>   
   $��2��6   $��1��6   $��5q�6/   .��5?      �� $ Vertical=�6   $
��Left=�60   $��Center=�6K   .+�5@      �� $C��=HOW TO PLAY: Move tiles using arrow keys or WSAD, reach 2048!��6   $
��Bold"�6a   $��14(�5A      $��5q�6*   ���#907a655B      �� 5C      $3��-- restart game pressing ENTER or click button��6   $
��Bold"�6Q   $��14(�6c   $��5q�5D      ���#907a655E      5F      5G      5I      5J      