   M S B A M L   `   `   `  ����Q  MAlert-To-Care-Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:Alert_To_Care_Frontend.ValidationRules&Alert_To_Care_Frontend.ValidationRules  5      3    -Alert_To_Care_Frontend.Views.AdmitPatientPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Pvalidationrules4clr-namespace:Alert_To_Care_Frontend.ValidationRules     5        N� Title$  AdmitPatientPage��5	      .��5
      ]� $
��True��6   $��Center=�6%   .+�5   
   �� $��0 0 50 0q�6   $	��Top=�6'   .+�5      �� $��Admit New Patient��6      HeadingStyle#��[  61   6e   � 5      $
��Left=�6   $��20q�6)    � RowDefinitions 5      �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64    � ColumnDefinitions 5      �� 5      $
��auto �6'   66   �� 5      $
��auto �6'   66   +�5      �� 5      $��0��6    $��0��6-     
LabelStyle#��[ 6=   
Patient Id6y   �� 5      $��1��6    $��0��6-   #��[ 6=   Patient Name6{   �� 5      $��2��6    $��0��6-   #��[ 6=   Patient Age6z   �� 5      $��3��6    $��0��6-   #��[ 6=   Email6t   �� 5       $��4��6    $��0��6-   #��[ 6=   Contact Number6}   �� 5!      $��5��6    $��0��6-   #��[ 6=   	Address6v   �� 5#      $��0��6   $��1��6+     ErrorFeedbackStyle#��[ 6;   .��6s   ��5$      �� 5%       �� Path$ 	PatientId�6&    �� NotifyOnValidationError$
 True��67    �� ValidationRules 5&   "   >  8Alert_To_Care_Frontend.ValidationRules.IdValidationRules  5'   &   ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated$
 True��6H   6j   5)      .��5*   (   5+      �� 5,      $��1��6U   $��1��6b     TextboxStyle#��[ 6r   ��6   �� $ PatientName� �� Mode$ OneWayToSource=�6�   �� 5-      $��2��6   $��1��6+   #��[ 6;   .��6s   ��5.      �� 5/      $ 
PatientAge�6&   $
 True��68    50   "   ?  9Alert_To_Care_Frontend.ValidationRules.AgeValidationRules  51   &   $
 True��6I   6k   53      .��54   (   55      �� 56      $��3��6O   $��1��6\   #��[ 6l   ��6   �� $ Email�$ OneWayToSource=�6�   �� 57      $��4��6   $��1��6+   #��[ 6;   .��6s   ��58      �� 59      $ 	ContactNo�6&   $
 True��67    5:   "   I  CAlert_To_Care_Frontend.ValidationRules.ContactNumberValidationRules  5;   &   $
 True��6S   6u   5=      .��5>   (   5?      �� 5@      $��5��6Q   $��1��6^   #��[ 6n   ��6   �� $ Address�$ OneWayToSource=�6�   �� 5B      -   5        $��6��5B      $��0��6*   $
��Back��6:     StandardButtonStyle#��[ 6I   6�   �� 5C      -   5        $��6��5C      $��1��6*   #��[ 6[   .��6�   Admit Patient6�   5E      5F      �� 5G   
   $��Center=�62   $��Bottom=�6O   ��6   �� $ Message�6i   5H      5I      