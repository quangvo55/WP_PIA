﻿

#pragma checksum "C:\Users\james.vo\Documents\Visual Studio 2013\Projects\App1\App1\Views\AllTournaments.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "23FC0C0DE8E96F3D92E299A7ED0B4407"
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
    partial class AllTournaments : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 38 "..\..\..\Views\AllTournaments.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.HomeButton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 39 "..\..\..\Views\AllTournaments.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.AddButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 44 "..\..\..\Views\AllTournaments.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.ListViewClick;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


