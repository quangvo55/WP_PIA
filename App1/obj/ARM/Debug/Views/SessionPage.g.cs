﻿

#pragma checksum "C:\Users\james.vo\Documents\Visual Studio 2013\Projects\App1\App1\Views\SessionPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C30EF97167B86D40E3E533E8623BC396"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App1.Views
{
    partial class SessionPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 12 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.StartButton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 13 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.DeleteButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 14 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.SaveButton_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 15 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.CancelButton_Click;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 71 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.Controls.TimePicker)(target)).TimeChanged += this.timePicker_TimeChanged;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


