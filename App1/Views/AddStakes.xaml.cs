﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using App1.Utils;

namespace App1.Views
{
    public sealed partial class AddStakes : UserControl
    {
        public EventHandler<TappedRoutedEventArgs> confirmBtnTapped;
        public EventHandler<TappedRoutedEventArgs> cancelBtnTapped;
        public string LowAmount 
        {
            get { return this.lowAmount.Text; }
        }
        public string HighAmount 
        {
            get { return this.highAmount.Text; } 
        }

        public AddStakes()
        {
            this.InitializeComponent();
        }

        public void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if (confirmBtnTapped != null)
            {
                if (String.IsNullOrEmpty(this.lowAmount.Text) || String.IsNullOrEmpty(this.highAmount.Text))
                {
                    GeneralUtil.ShowMessage("The high and low amount can not be empty.");
                    return;
                }
                else
                {
                    confirmBtnTapped(this, null);
                }
            }
        }

        public void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (cancelBtnTapped != null)
                cancelBtnTapped(this, null);
        }

        public void FocusInputBox()
        {
            this.lowAmount.Focus(FocusState.Pointer);
        }
    }
}
