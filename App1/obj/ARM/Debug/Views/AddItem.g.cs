﻿

#pragma checksum "C:\Users\james.vo\Documents\Visual Studio 2013\Projects\App1\App1\Views\AddItem.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0B1C2F0AFC97C2015745FEA5C6A55AFB"
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
    partial class AddItem : global::Windows.UI.Xaml.Controls.UserControl, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 20 "..\..\..\Views\AddItem.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.okBtn_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 21 "..\..\..\Views\AddItem.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.cancelBtn_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


