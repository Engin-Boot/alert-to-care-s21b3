   M S B A M L   `   `   `  ����Q  MAlert-To-Care-Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Alert_To_Care_Frontend.Converters!Alert_To_Care_Frontend.Converters  5      *    $Alert_To_Care_Frontend.Views.BedView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      F
converters/clr-namespace:Alert_To_Care_Frontend.Converters     5        � 	Resources  5	      M  GAlert_To_Care_Frontend.Converters.BedStatusToAdmitPatienStatusConverter   AdmitStatusRefG  AAlert_To_Care_Frontend.Converters.BedStatusToImageSourceConverter  ImageSourceRefH  BAlert_To_Care_Frontend.Converters.AlertMessageToStopAlertConverter  StopAlertRef6  0Alert_To_Care_Frontend.Converters.BedIdConverter  BedIdRef�� 5
   
   %t   &	        &	      &	 &     &	 9       5      6X     5      6R     5      6Q     5      6;   5      .��5      � $��Center=�6   $��Center=�6(   $��25q�6C    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      $
��auto �6   6.   �� 5      $
��auto �6   6.   +�5   
   �� 5       $	��125��6z   $	��125��6�   $��0��6�   $��0��6�   $��2��6�   ��6   ��  �� Path$ 	BedStatus� �� Mode$ OneWay=� �� 	Converter# [ 6�   �� 5"      $��Center=�6r   $��Center=�6�   $��12(�6�   $��1��6�   $��0��6�   ��6   �� $ BedId�$ OneWay=�# [ 6�   �� 5$      -   5        $��Update Vitals��5$   G     BedButtonStyle#��[ 6_   $��2��6�   $��0��6�   {�6   �� $ 	BedStatus�$ OneWay=�6�   �� 5%      -   5         ��Name$ AdmitPatientBtn��5%      $��Admit Patient��6�   #��[ 6�   $��2��6�   $��1��6�   {�6.   �� $ 	BedStatus�$ OneWay=�# [  6#  �� 5'      $��Check Vitals��6   #��[ 6�   $��3��6�   $��0��6�   {�6,   �� $ 	BedStatus�$ OneWay=���6^   �� $ CheckPatientVitalsCommand�6�   �� 5(      $��Discharge Patient��6   #��[ 6�   $��3��6�   $��1��6�   {�61   �� $ 	BedStatus�$ OneWay=���6c   �� $ DischargePatientCommand�6�   �� 5*      $��
Stop Alert��6   #��[ 6�   $��4��6�   $��0��6�   ��6*   �� $ StopAlertCommand�{�6T   �� $ AlertMessage�$ OneWay=�# [ 6  �� 5+      $��
Undo Alert��6   #��[ 6�   $��4��6�   $��1��6  ��6*   �� $ UndoAlertCommand�{�6T   �� $ AlertMessageHistory�$ OneWay=�# [ 6  �� 5-      $��Center=�66   $	��200��6S   $��20��6_   $��6��6k   $��0��6x   $��2��6�   ��6   �� $ Message�6�   �� 5.      $
��Wrap=�6;   
���  ��$��Center=�6`   $	��200��6}   $��60��6�   $��5��6�   $��0��6�   $��2��6�   ��6   �� $ AlertMessage�6�   51      52      