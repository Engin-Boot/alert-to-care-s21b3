﻿using AlertToCareFrontend.Models;
using AlertToCareFrontend.ViewModel;
using System.Windows;

namespace AlertToCareFrontend.Views
{
    /// <summary>
    /// Interaction logic for BedView.xaml
    /// </summary>
    public partial class BedView
    {
        public BedView(BedDataModel bed)
        {
            InitializeComponent();
            DataContext = new BedViewModel(bed);

        }
        // This defines the custom event
        public static readonly RoutedEvent AdmitButtonClickedEvent = EventManager.RegisterRoutedEvent(
            "AdmitButtonClicked", // Event name
            RoutingStrategy.Bubble, // Bubble means the event will bubble up through the tree
            typeof(RoutedEventHandler), // The event type
            typeof(BedView)); // Belongs to BedView
                              
        // Allows add and remove of event handlers to handle the custom event
        public event RoutedEventHandler AdmitButtonClicked
        {
            add { AddHandler(AdmitButtonClickedEvent, value); }
            remove { RemoveHandler(AdmitButtonClickedEvent, value); }
        }

        private void AdmitPatientButton_Click(object sender, RoutedEventArgs e)
        {
            // This actually raises the custom event
            var newEventArgs = new RoutedEventArgs(AdmitButtonClickedEvent);
            RaiseEvent(newEventArgs);
        }

        public static readonly RoutedEvent UpdateVitalsButtonClickedEvent = EventManager.RegisterRoutedEvent(
            "UpdateVitalsButtonClicked",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(BedView));

        public event RoutedEventHandler UpdateVitalsButtonClicked
        {
            add { AddHandler(UpdateVitalsButtonClickedEvent, value); }
            remove { RemoveHandler(UpdateVitalsButtonClickedEvent, value); }
        }

        private void UpdateVitalsButton_Click(object sender, RoutedEventArgs e)
        {
            var newEventArgs = new RoutedEventArgs(UpdateVitalsButtonClickedEvent);
            RaiseEvent(newEventArgs);
        }
    }
}
