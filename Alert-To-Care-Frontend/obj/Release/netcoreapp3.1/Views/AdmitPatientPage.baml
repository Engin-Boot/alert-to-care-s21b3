   M S B A M L   `   `   `  ���� Q  MAlert-To-Care-Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:Alert_To_Care_Frontend.ValidationRules&Alert_To_Care_Frontend.ValidationRules  3    -Alert_To_Care_Frontend.Views.AdmitPatientPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Pvalidationrules4clr-namespace:Alert_To_Care_Frontend.ValidationRules       N� Title$  AdmitPatientPage��.��]� $
��True��$��Center=�.+��� $��0 0 50 0q�$	��Top=�.+��� $��Admit New Patient��   HeadingStyle#��[  � $
��Left=�$��20q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��auto ��� $
��auto �+��� $��0��$��0��  
LabelStyle#��[ 
Patient Id�� $��1��$��0��#��[ Patient Name�� $��2��$��0��#��[ Patient Age�� $��3��$��0��#��[ Email�� $��4��$��0��#��[ Contact Number�� $��5��$��0��#��[ 	Address�� $��0��$��1��  ErrorFeedbackStyle#��[ .������  �� Path$ 	PatientId� �� NotifyOnValidationError$
 True�� �� ValidationRules >  8Alert_To_Care_Frontend.ValidationRules.IdValidationRules  ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated$
 True��.���� $��1��$��1��  TextboxStyle#��[ ���� $ PatientName� �� Mode$ OneWayToSource=��� $��2��$��1��#��[ .������ $ 
PatientAge�$
 True�� ?  9Alert_To_Care_Frontend.ValidationRules.AgeValidationRules  $
 True��.���� $��3��$��1��#��[ ���� $ Email�$ OneWayToSource=��� $��4��$��1��#��[ .������ $ 	ContactNo�$
 True�� I  CAlert_To_Care_Frontend.ValidationRules.ContactNumberValidationRules  $
 True��.���� $��5��$��1��#��[ ���� $ Address�$ OneWayToSource=��� -   $��6��$��0��$
��Back��  StandardButtonStyle#��[ �� -   $��6��$��1��#��[ .��Admit Patient�� $��Center=�$��Bottom=����� $ Message�