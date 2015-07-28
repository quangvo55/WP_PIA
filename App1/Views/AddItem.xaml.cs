using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using App1.Utils;

namespace App1.Views
{
    public sealed partial class AddItem : UserControl
    {
        public EventHandler<TappedRoutedEventArgs> okBtnTapped;
        public EventHandler<TappedRoutedEventArgs> cancelBtnTapped;
        public string ItemText;
        public string TextInput
        {
            get { return this.txtInput.Text; }
        }

        public AddItem(string itemText)
        {
            this.InitializeComponent();
            this.ItemText = itemText;
            this.txtInput.Header = ItemText;
        }

        public void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if (okBtnTapped != null)
            {
                if (String.IsNullOrEmpty(this.txtInput.Text))
                {
                    GeneralUtil.ShowMessage(String.Format("The {0} text can not be empty.", ItemText));
                    return;
                }
                else
                {
                    okBtnTapped(this, null);
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
            this.txtInput.Focus(FocusState.Pointer);
        }

        public void setInputScopeToNumeric()
        {
            this.txtInput.InputScope = new InputScope
            {
                Names = { new InputScopeName(InputScopeNameValue.Number) }
            };
        }
    }
}
