   M S B A M L   `   `   `  ����Q  MAlert-To-Care-Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:Alert_To_Care_Frontend.ValidationRules&Alert_To_Care_Frontend.ValidationRules  5      3    -Alert_To_Care_Frontend.Views.UpdateVitalsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Pvalidationrules4clr-namespace:Alert_To_Care_Frontend.ValidationRules     5        N� Title$  UpdateVitalsPage��5	      .��5
      ]� $
��True��6   $��Center=�6%   .+�5   
   �� $��0 0 50 0q�6   $	��Top=�6'   .+�5      �� $��Update Vitals��6      HeadingStyle#��[  6-   6a   � 5      $
��Left=�6   $��20q�6)    � RowDefinitions 5      �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64    � ColumnDefinitions 5      �� 5      $
��auto �6'   66   �� 5      $
��auto �6'   66   +�5      �� 5      $��0��6    $��0��6-     
LabelStyle#��[ 6=   BPM (70-150)6{   �� 5      $��1��6    $��0��6-   #��[ 6=   SpO2 (90-100)6|   �� 5      $��2��6    $��0��6-   #��[ 6=   Resp Rate (30-95)6�   �� 5      $��0��6   $��1��6+     ErrorFeedbackStyle#��[ 6;   .��6s   ��5      �� 5       �� Path$	 Bpm�6&    �� NotifyOnValidationError$
 True��61    �� ValidationRules 5    "   F  @Alert_To_Care_Frontend.ValidationRules.VitalValueValidationRules  5!   &   ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated$
 True��6P   6r   5#      .��5$   (   5%      �� 5&      $��1��6   $��1��6+   #��[ 6;   .��6s   ��5'      �� 5(      $
 Spo2�6&   $
 True��62    5)   "     5*   &   $
 True��6P   6r   5,      .��5-   (   5.      �� 5/      $��2��6   $��1��6+   #��[ 6;   .��6s   ��50      �� 51      $ RespRate�6&   $
 True��66    52   "     53   &   $
 True��6P   6r   55      .��56   (   57      �� 59      -   5        $��3��59      $��0��6*   $
��Back��6:     StandardButtonStyle#��[ 6I   6�   �� 5:      $��3��6   $��1��6*   #��[ 6g   ��6:   �� $ UpdateVitalsCommand�.��6�   Update6�   5<      5=      �� 5>   
   $��Center=�62   $��Bottom=�6O   ��6   �� $ Message�6i   5?      5A      