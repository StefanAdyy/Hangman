   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WpfApplication1.ViewModelsWpfApplication1.ViewModels  5   	   G(clr-namespace:WpfApplication1.ViewModelsWpfApplication1.ViewModels  5   	   1clr-namespace:WpfApplication1WpfApplication1  5   	   !    WpfApplication1.FirstWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Aav2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7vm(clr-namespace:WpfApplication1.ViewModels     5   	   8ctx(clr-namespace:WpfApplication1.ViewModels     5   	   /localclr-namespace:WpfApplication1     5   	     � Title$  Welcome��5   	   $	��330��5   	   $	��393��5   	    � DataContext 5      .  (WpfApplication1.ViewModels.FirstWindowVM  5   
   .��5      � $��2,0,1,0q�6   $	��308��6   $	��Top=�6)    � ColumnDefinitions 5   
   �� 5      $	��159 �6   �� 5      $��36 �6   �� 5      $	��167 �6   �� 5      $	��238 �6    � RowDefinitions 5   
   �� 5      $	��221 �6   �� 5      $
��Auto �6   $��32��6*   �� 5      $��30 �6   $��30��6(   �� 5      $��30 �6   $��30��6(   .+�5   
   �� -   5        $��Delete User��5      $
��Left=�6'   $��10,0,0,0q�6B   $��2��6T   $��Center=�6a   $	��146��6|   $��26��6�   6�   �� 5   
   -   5        $��2��5      $
��Play��6!   $��Center=�60   $��1��6M   $��Center=�6Z   $	��164��6u   $��26��6�   6�   �� 5    
   -   5        $
��Exit��5       $��Center=�6    $��2��6=   $��Center=�6J   $	��164��6e   $��26��6q   $��2��6�   �� 5!   
   -   5        $��New User��5!      $
��Left=�6$   $��10,0,0,0q�6?   $��1��6Q   $��Center=�6^   $	��146��6y   $��26��6�   6�   &   System.Windows.Controls.DataGrid  5"   
   -   5        $��UserGrid��5"         GridLinesVisibility$
 None=�5#         AutoGenerateColumns .     RowBackground
 ���� 
������    HeadersVisibility$ Column=�5(      $   HorizontalScrollBarVisibility$ Hidden=�5)      $��Center=�5*      $��Center=�5+      $��
10,10,3,10q�67   ��5$      �� *
PlayerList+	 �� UpdateSourceTrigger$	 PropertyChanged=�
   Columns
 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn   Header$ Players��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *Name+6a   5/      �� 50   
   $��2��6   $��Center=�51      $	��200��52      $��Center=�53      $	��166��54      ��55      �� *SelectedItem.AvatarPath+ �� ElementName$ UserGrid��$	 PropertyChanged=��� 58   
   $��2��6   $
��Left=�6%   $��26��6@   $��	0,198,0,0q�6L   $	��Top=�6_   $��90��6w   $��2��6�   .+�59      �� $��44��6    J� RenderTransformOrigin$ 0.575,0.541&�6   $��Name:��6C   5:      �� 5;   
   $ 0.527,0.385&�6q   $��2��6�   $��75,198,10,29q�6�   $��2��6�   ��6   �� *SelectedItem.Name+$ UserGrid��$	 PropertyChanged=�6�   5<      5=      