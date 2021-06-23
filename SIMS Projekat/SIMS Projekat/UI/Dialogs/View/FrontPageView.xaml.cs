﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SIMS_Projekat.UI.Dialogs.ViewModel;

namespace SIMS_Projekat.UI.Dialogs.View
{
    /// <summary>
    /// Interaction logic for FrontPageView.xaml
    /// </summary>
    public partial class FrontPageView : Window
    {
        public FrontPageView()
        {
            InitializeComponent();
            DataContext = new FrontPageViewModel(this);


        }
    }
}
