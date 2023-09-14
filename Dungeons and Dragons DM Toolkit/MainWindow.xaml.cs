// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Dungeons_and_Dragons_DM_Toolkit
{

    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private ObservableCollection<string> itemList = new ObservableCollection<string>();
        public MainWindow()
        {
            this.InitializeComponent();
            itemListView.ItemsSource = itemList;

        }

        private MapDisplayWindow mapDisplayWindow;
        private void OpenMapDisplayWindowButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the second window is already open
            if (mapDisplayWindow == null)
            {
                // Create an instance of the second window
                mapDisplayWindow = new MapDisplayWindow();

                // Subscribe to the Closed event to handle window closure
                mapDisplayWindow.Closed += MapDisplayWindow_Closed;
            }

            // Activate and show the second window
            mapDisplayWindow.Activate();
        }

        private void MapDisplayWindow_Closed(object sender, WindowEventArgs e)
        {
            // Handle the second window being closed
            mapDisplayWindow = null;
        }

        private void CloseMapDisplayWindowButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the second window is open
            if (mapDisplayWindow != null)
            {
                // Close the second window
                mapDisplayWindow.Close();
                mapDisplayWindow = null; // Set to null to allow reopening if needed
            }
        }

        private void AddItemButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            string newItem = newItemTextBox.Text;
            if (!string.IsNullOrWhiteSpace(newItem))
            {
                itemList.Add(newItem);
                newItemTextBox.Text = string.Empty;
            }
        }

        private void RemoveItemButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (itemListView.SelectedItem != null)
            {
                itemList.Remove(itemListView.SelectedItem.ToString());
            }
        }



    }

}
