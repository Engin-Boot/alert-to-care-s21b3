   M S B A M L   `   `   `  ���� Q  MAlert-To-Care-Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:Alert_To_Care_Frontend.ValidationRules&Alert_To_Care_Frontend.ValidationRules  3    -Alert_To_Care_Frontend.Views.UpdateVitalsPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Pvalidationrules4clr-namespace:Alert_To_Care_Frontend.ValidationRules       N� Title$  UpdateVitalsPage��.��]� $
��True��$��Center=�.+��� $��0 0 50 0q�$	��Top=�.+��� $��Update Vitals��   HeadingStyle#��[  � $
��Left=�$��20q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��auto ��� $
��auto �+��� $��0��$��0��  
LabelStyle#��[ BPM (70-150)�� $��1��$��0��#��[ SpO2 (90-100)�� $��2��$��0��#��[ Resp Rate (30-95)�� $��0��$��1��  ErrorFeedbackStyle#��[ .������  �� Path$	 Bpm� �� NotifyOnValidationError$
 True�� �� ValidationRules F  @Alert_To_Care_Frontend.ValidationRules.VitalValueValidationRules  ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated$
 True��.���� $��1��$��1��#��[ .������ $
 Spo2�$
 True��   $
 True��.���� $��2��$��1��#��[ .������ $ RespRate�$
 True��   $
 True��.���� -   $��3��$��0��$
��Back��  StandardButtonStyle#��[ �� $��3��$��1��#��[ ���� $ UpdateVitalsCommand�.��Update�� $��Center=�$��Bottom=����� $ Message�