   M S B A M L   `   `   `  ���� Q  MAlert-To-Care-Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Alert_To_Care_Frontend.ViewModel Alert_To_Care_Frontend.ViewModel  _4clr-namespace:Alert_To_Care_Frontend.ValidationRules&Alert_To_Care_Frontend.ValidationRules  4    .Alert_To_Care_Frontend.Views.ConfigurationPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     @d2http://schemas.microsoft.com/expression/blend/2008     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     E
viewmodels.clr-namespace:Alert_To_Care_Frontend.ViewModel     Pvalidationrules4clr-namespace:Alert_To_Care_Frontend.ValidationRules       N� Title$  ConfigurationPage�� � DataContext =  7Alert_To_Care_Frontend.ViewModel.ConfigurationViewModel  .��]� $
��True��.+��� $��Configure ICU��   HeadingStyle#��[  $	��Top=�� $��Center=�$	��Top=�$��20q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��auto ��� $
��auto �+��� $��0��$��0��  
LabelStyle#��[ ICU Id�� $��1��$��0��#��[ Number of beds�� $��2��$��0��#��[ 
ICU Layout�� $��0��$��1��  ErrorFeedbackStyle#��[ .������  �� Path$ IcuId� �� NotifyOnValidationError$
 True�� �� ValidationRules >  8Alert_To_Care_Frontend.ValidationRules.IdValidationRules  ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated$
 True��.���� $��1��$��1��#��[ .������ $ TotalNoOfBeds�$
 True�� I  CAlert_To_Care_Frontend.ValidationRules.TotalNoOfBedsValidationRules  $
 True��.���� $��2��$��1��  ComboBoxStyle#��[ ���� $ Layouts� �� SelectedItem �� $ Layout��� -     StandardButtonStyle#��[ $��3��$��0��.���� 	 �� Orientation$	 
Horizontal=�.+��� $!��../Resources/icons/home.png��$��20��$��20���� $��Back to home��$��Center=��� $��3��$��1��#��[ ���� *AddIcuCommand+.��Configure ICU�� $��Center=�$��Bottom=����� $ Message�