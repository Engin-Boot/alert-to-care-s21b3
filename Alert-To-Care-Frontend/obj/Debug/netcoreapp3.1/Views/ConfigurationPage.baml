   M S B A M L   `   `   `  ����Q  MAlert-To-Care-Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Alert_To_Care_Frontend.ViewModel Alert_To_Care_Frontend.ViewModel  5      _4clr-namespace:Alert_To_Care_Frontend.ValidationRules&Alert_To_Care_Frontend.ValidationRules  5      4    .Alert_To_Care_Frontend.Views.ConfigurationPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      E
viewmodels.clr-namespace:Alert_To_Care_Frontend.ViewModel     5      Pvalidationrules4clr-namespace:Alert_To_Care_Frontend.ValidationRules     5        N� Title$  ConfigurationPage��5
       � DataContext 5      =  7Alert_To_Care_Frontend.ViewModel.ConfigurationViewModel  5   
   6.   .��5      ]� $
��True��6   .+�5   
   �� $��Configure ICU��6      HeadingStyle#��[  6)   $	��Top=�6[   6r   � 5   
   $��Center=�6   $	��Top=�6,   $��20q�6A    � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60    � ColumnDefinitions 5      �� 5      $
��auto �6#   62   �� 5      $
��auto �6#   62   +�5      �� 5      $��0��6   $��0��6)     
LabelStyle#��[ 69   ICU Id6q   �� 5      $��1��6   $��0��6)   #��[ 69   Number of beds6y   �� 5      $��2��6   $��0��6)   #��[ 69   
ICU Layout6u   �� 5       $��0��6   $��1��6'     ErrorFeedbackStyle#��[ 67   .��6o   ��5!      �� 5"       �� Path$ IcuId�6"    �� NotifyOnValidationError$
 True��6/    �� ValidationRules 5#      >  8Alert_To_Care_Frontend.ValidationRules.IdValidationRules  5$   "   ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated$
 True��6D   6f   5&      .��5'   $   5(      �� 5)      $��1��6   $��1��6'   #��[ 67   .��6o   ��5*      �� 5+      $ TotalNoOfBeds�6"   $
 True��67    5,      I  CAlert_To_Care_Frontend.ValidationRules.TotalNoOfBedsValidationRules  5-   "   $
 True��6O   6q   5/      .��50   $   51      �� 52      $��2��6e   $��1��6r     ComboBoxStyle#��[ 6�   ��6   �� $ Layouts� �� SelectedItem 6@   �� $ Layout�6�   �� 54      -   5          StandardButtonStyle#��[ 54      $��3��6k   $��0��6x   .��55      �� 	 �� Orientation$	 
Horizontal=�6!   .+�56      �� $!��../Resources/icons/home.png��6    $��20��6E   $��20��6P   6^   �� 57      $��Back to home��6$   $��Center=�68   6U   58      59      �� 5;      $��3��6   $��1��6&   #��[ 66   ��6o   �� *AddIcuCommand+.��6�   Configure ICU6�   5>      �� 5?   
   $��Center=�62   $��Bottom=�6O   ��6   �� $ Message�6i   5@      5A      