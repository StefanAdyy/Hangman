   M S B A M L   `   `   `  ����  WpfApplication1)    #WpfApplication1.Views.NewUserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  NewUser��5   	   $	��240��6   $	��440��6&   .��5      � $��Center=�6   $��Center=�6(   $	��179��6C   $	��396��6P    � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   $	��184��6,   �� 5      $
��172* �6   �� 5      $
��131* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��20 �6   .+�5   
   �� $��0��6   $��1��6"   .+�5      �� -   5         ��Name$ avatar��5      $
��Fill=�6$   $	��100��63   $	��100��6?    J� RenderTransformOrigin$ 0.5,0.5&�6L   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.567Q�6*   T� 5      5      5      5       �� 5!   
   $��1��6   $��0��6   $��0,0,0,26q�6-   $��2��6?   .��6P   Name:6W   �� 5"   
   -   5        $��
playerName��5"      $��1��6%   $��1��62   $��0,2,5,2q�6B   �� 5#   
   $��2��6   $��0��6   $��0,0,0,20q�6-   $��2��6?   $��Avatar Path:��6P   �� 5$   
   -   5        $��
avatarPath��5$   $    �� 
IsReadOnly . $��2��66   $��1��6C   $��0,2,5,2q�6S   �� 5%   
   -   5         ��Name$ btnBrowseImage��5%      $��2��6)   $��2��66   $��92��6F   $��Center=�6Q   $��Browse Avatar��5&   )   $��22��6A   $��Center=�6M   �� 5'   
   -   5        $��btnAdd��5'      $��1��6   $��2��6,   $��91��6<   $��Center=�6G   $��0,2,0,2q�5(       .��62   Add67   �� 5)   
   -   5        $��	btnCancel��5)      $��3��6"   $��91��6/   $��Center=�6:   $��2��5*   #   $��0,3,0,-2q�63   .��6E   Cancel6M   5+      5,      