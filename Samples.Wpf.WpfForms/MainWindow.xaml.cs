using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Samples.Wpf.WpfForms
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Parameters = new ObservableCollection<FormElement>();
            DataContext = this;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Parameters.Add(new StringElement() { Name = "Texte " + Parameters.Count });
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Parameters.Add(new DateElement() { Name = "Date " + Parameters.Count });
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Parameters.Add(new MultiElement()
            {
                Name = "Multi " + Parameters.Count,
                Options = new List<FormElement<int>>()
                {
                    new FormElement<int>() {Value = 1, Name = "Multi 1"},
                    new FormElement<int>() {Value = 2, Name = "Multi 2"},
                    new FormElement<int>() {Value = 3, Name = "Multi 3"},
                }
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dump = "";

            foreach (var parm in Parameters)
            {
                Dump += string.Format("{0} -> {1}", parm.Name, parm.Value) + Environment.NewLine;
            }
        }

        public string Dump
        {
            get { return (string)GetValue(DumpProperty); }
            set { SetValue(DumpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Dump.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DumpProperty =
            DependencyProperty.Register("Dump", typeof(string), typeof(MainWindow), new UIPropertyMetadata(""));

        public ObservableCollection<FormElement> Parameters { get; set; }
    }
}

