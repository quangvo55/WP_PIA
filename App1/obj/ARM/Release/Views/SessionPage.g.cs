﻿

#pragma checksum "C:\Users\james.vo\Documents\Visual Studio 2013\Projects\WP_PIA\App1\Views\SessionPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1CAB125169532C4CD6DCD03713CED187"
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
                #line 40 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.StakesOnLoad;
                 #line default
                 #line hidden
                #line 41 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.Stakes_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 42 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.GameNameOnLoad;
                 #line default
                 #line hidden
                #line 43 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.Games_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 44 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.LocationOnLoad;
                 #line default
                 #line hidden
                #line 45 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.Location_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 8:
                #line 78 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.Controls.DatePicker)(target)).DateChanged += this.DatePicker_Changed;
                 #line default
                 #line hidden
                break;
            case 9:
                #line 79 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.Controls.TimePicker)(target)).TimeChanged += this.TimePicker_Changed;
                 #line default
                 #line hidden
                break;
            case 10:
                #line 64 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.Controls.DatePicker)(target)).DateChanged += this.DatePicker_Changed;
                 #line default
                 #line hidden
                break;
            case 11:
                #line 65 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.Controls.TimePicker)(target)).TimeChanged += this.TimePicker_Changed;
                 #line default
                 #line hidden
                break;
            case 12:
                #line 54 "..\..\..\Views\SessionPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.RebuyButton_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

