using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BindToListViewDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Meds : Page
    {
        private string DBPath { get; set; }

        public Meds()
        {
            this.InitializeComponent();
            // Create the Database
            DBPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "meds.sqlite");
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DBPath))
            {
                //conn.DropTable<Medications>();
                conn.CreateTable<Medications>();
                // Set ItemsSource to the sqlite data for ListView
                myList.ItemsSource = conn.Table<Medications>();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DBPath))
            {
                // Add Medications
                conn.Insert(new Medications
                {
                    MedName = medname_box.Text,
                    MedDose = meddose_box.Text,
                    WhatFor = whatfor_box.Text
                });
                // Update the ItemsSource for ListView
                myList.ItemsSource = conn.Table<Medications>();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}