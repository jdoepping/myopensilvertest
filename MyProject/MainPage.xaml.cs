using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyProject
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Enter construction logic here...
             string PreviousDealResource = Properties.Resource.Text01;
             this.DataContext = this;
        }

        public string Text01 => Properties.Resource.Text01;
    }
}
