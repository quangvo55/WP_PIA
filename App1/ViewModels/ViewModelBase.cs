using System.ComponentModel;
using System.Collections.Generic;

using App1.Models;

namespace App1.ViewModels
{
    public class ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        string _SelectedOption1;
        public string SelectedOption1
        {
            get
            {
                return _SelectedOption1;
            }
            set
            {
                if (_SelectedOption1 != value)
                {
                    _SelectedOption1 = value;
                    RaisePropertyChanged("SelectedOption1");
                }
            }
        }
    }
}
