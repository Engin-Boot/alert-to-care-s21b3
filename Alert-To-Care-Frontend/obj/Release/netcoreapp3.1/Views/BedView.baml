   M S B A M L   `   `   `  ���� Q  MAlert-To-Care-Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Alert_To_Care_Frontend.Converters!Alert_To_Care_Frontend.Converters  *    $Alert_To_Care_Frontend.Views.BedView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     F
converters/clr-namespace:Alert_To_Care_Frontend.Converters       � 	Resources  M  GAlert_To_Care_Frontend.Converters.BedStatusToAdmitPatienStatusConverter   AdmitStatusRefG  AAlert_To_Care_Frontend.Converters.BedStatusToImageSourceConverter  ImageSourceRefH  BAlert_To_Care_Frontend.Converters.AlertMessageToStopAlertConverter  StopAlertRef6  0Alert_To_Care_Frontend.Converters.BedIdConverter  BedIdRef�� %<   &	        &	      &	 
     &	              .��� $��Center=�$��Center=�$��25q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��auto ��� $
��auto �+��� $	��125��$	��125��$��0��$��0��$��2������  �� Path$ 	BedStatus� �� Mode$ OneWay=� �� 	Converter# [ �� $��Center=�$��Center=�$��12(�$��1��$��0������ $ BedId�$ OneWay=�# [ �� -   $��Update Vitals��  BedButtonStyle#��[ $��2��$��0��{��� $ 	BedStatus�$ OneWay=��� -    ��Name$ AdmitPatientBtn��$��Admit Patient��#��[ $��2��$��1��{��� $ 	BedStatus�$ OneWay=�# [  �� $��Check Vitals��#��[ $��3��$��0��{��� $ 	BedStatus�$ OneWay=����� $ CheckPatientVitalsCommand��� $��Discharge Patient��#��[ $��3��$��1��{��� $ 	BedStatus�$ OneWay=����� $ DischargePatientCommand��� $��
Stop Alert��#��[ $��4��$��0������ $ StopAlertCommand�{��� $ AlertMessage�$ OneWay=�# [ �� $��
Undo Alert��#��[ $��4��$��1������ $ UndoAlertCommand�{��� $ AlertMessageHistory�$ OneWay=�# [ �� $��Center=�$	��200��$��20��$��6��$��0��$��2������ $ Message��� $
��Wrap=�
���  ��$��Center=�$	��200��$��60��$��5��$��0��$��2������ $ AlertMessage�