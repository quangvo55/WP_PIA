﻿

#pragma checksum "C:\Users\james.vo\Documents\Visual Studio 2013\Projects\WP_PIA\App1\Views\AllSessions.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C0CA493A33D60EA0E56AEAA221D77F68"
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
    partial class AllSessions : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 45 "..\..\..\Views\AllSessions.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.AddButton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 46 "..\..\..\Views\AllSessions.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.HomeButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 57 "..\..\..\Views\AllSessions.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.ListViewClick;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


