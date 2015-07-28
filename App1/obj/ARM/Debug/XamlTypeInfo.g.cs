﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace App1
{
    public partial class App : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
        private global::App1.App1_XamlTypeInfo.XamlTypeInfoProvider _provider;

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            if(_provider == null)
            {
                _provider = new global::App1.App1_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByType(type);
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            if(_provider == null)
            {
                _provider = new global::App1.App1_XamlTypeInfo.XamlTypeInfoProvider();
            }
            return _provider.GetXamlTypeByName(fullName);
        }

        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return new global::Windows.UI.Xaml.Markup.XmlnsDefinition[0];
        }
    }
}

namespace App1.App1_XamlTypeInfo
{
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal partial class XamlTypeInfoProvider
    {
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByType(global::System.Type type)
        {
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByType.TryGetValue(type, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByType(type);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            var userXamlType = xamlType as global::App1.App1_XamlTypeInfo.XamlUserType;
            if(xamlType == null || (userXamlType != null && userXamlType.IsReturnTypeStub && !userXamlType.IsLocalType))
            {
                global::Windows.UI.Xaml.Markup.IXamlType libXamlType = CheckOtherMetadataProvidersForType(type);
                if (libXamlType != null)
                {
                    if(libXamlType.IsConstructible || xamlType == null)
                    {
                        xamlType = libXamlType;
                    }
                }
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByName(typeName);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            var userXamlType = xamlType as global::App1.App1_XamlTypeInfo.XamlUserType;
            if(xamlType == null || (userXamlType != null && userXamlType.IsReturnTypeStub && !userXamlType.IsLocalType))
            {
                global::Windows.UI.Xaml.Markup.IXamlType libXamlType = CheckOtherMetadataProvidersForName(typeName);
                if (libXamlType != null)
                {
                    if(libXamlType.IsConstructible || xamlType == null)
                    {
                        xamlType = libXamlType;
                    }
                }
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlMember GetMemberByLongName(string longMemberName)
        {
            if (string.IsNullOrEmpty(longMemberName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlMember xamlMember;
            if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
            {
                return xamlMember;
            }
            xamlMember = CreateXamlMember(longMemberName);
            if (xamlMember != null)
            {
                _xamlMembers.Add(longMemberName, xamlMember);
            }
            return xamlMember;
        }

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByName = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByType = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>
                _xamlMembers = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>();

        string[] _typeNameTable = null;
        global::System.Type[] _typeTable = null;

        private void InitTypeTables()
        {
            _typeNameTable = new string[21];
            _typeNameTable[0] = "App1.Views.AddItem";
            _typeNameTable[1] = "Windows.UI.Xaml.Controls.UserControl";
            _typeNameTable[2] = "String";
            _typeNameTable[3] = "App1.Views.AddStakes";
            _typeNameTable[4] = "App1.Utils.AlternatingIndexConverter";
            _typeNameTable[5] = "Object";
            _typeNameTable[6] = "Windows.UI.Xaml.Media.Brush";
            _typeNameTable[7] = "App1.Views.AllPlayers";
            _typeNameTable[8] = "Windows.UI.Xaml.Controls.Page";
            _typeNameTable[9] = "App1.Utils.DateToStringConverter";
            _typeNameTable[10] = "App1.Utils.CurrencyForegroundConverter";
            _typeNameTable[11] = "App1.Utils.StringToCurrencyConverter";
            _typeNameTable[12] = "App1.Views.AllSessions";
            _typeNameTable[13] = "App1.Views.PlayerPage";
            _typeNameTable[14] = "App1.Views.RebuyWindow";
            _typeNameTable[15] = "Int32";
            _typeNameTable[16] = "App1.Utils.TimespanToStringConverter";
            _typeNameTable[17] = "App1.Views.Report";
            _typeNameTable[18] = "App1.Views.SessionPage";
            _typeNameTable[19] = "App1.Views.MainPage";
            _typeNameTable[20] = "App1.Views.TourneyPage";

            _typeTable = new global::System.Type[21];
            _typeTable[0] = typeof(global::App1.Views.AddItem);
            _typeTable[1] = typeof(global::Windows.UI.Xaml.Controls.UserControl);
            _typeTable[2] = typeof(global::System.String);
            _typeTable[3] = typeof(global::App1.Views.AddStakes);
            _typeTable[4] = typeof(global::App1.Utils.AlternatingIndexConverter);
            _typeTable[5] = typeof(global::System.Object);
            _typeTable[6] = typeof(global::Windows.UI.Xaml.Media.Brush);
            _typeTable[7] = typeof(global::App1.Views.AllPlayers);
            _typeTable[8] = typeof(global::Windows.UI.Xaml.Controls.Page);
            _typeTable[9] = typeof(global::App1.Utils.DateToStringConverter);
            _typeTable[10] = typeof(global::App1.Utils.CurrencyForegroundConverter);
            _typeTable[11] = typeof(global::App1.Utils.StringToCurrencyConverter);
            _typeTable[12] = typeof(global::App1.Views.AllSessions);
            _typeTable[13] = typeof(global::App1.Views.PlayerPage);
            _typeTable[14] = typeof(global::App1.Views.RebuyWindow);
            _typeTable[15] = typeof(global::System.Int32);
            _typeTable[16] = typeof(global::App1.Utils.TimespanToStringConverter);
            _typeTable[17] = typeof(global::App1.Views.Report);
            _typeTable[18] = typeof(global::App1.Views.SessionPage);
            _typeTable[19] = typeof(global::App1.Views.MainPage);
            _typeTable[20] = typeof(global::App1.Views.TourneyPage);
        }

        private int LookupTypeIndexByName(string typeName)
        {
            if (_typeNameTable == null)
            {
                InitTypeTables();
            }
            for (int i=0; i<_typeNameTable.Length; i++)
            {
                if(0 == string.CompareOrdinal(_typeNameTable[i], typeName))
                {
                    return i;
                }
            }
            return -1;
        }

        private int LookupTypeIndexByType(global::System.Type type)
        {
            if (_typeTable == null)
            {
                InitTypeTables();
            }
            for(int i=0; i<_typeTable.Length; i++)
            {
                if(type == _typeTable[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private object Activate_3_AddStakes() { return new global::App1.Views.AddStakes(); }
        private object Activate_4_AlternatingIndexConverter() { return new global::App1.Utils.AlternatingIndexConverter(); }
        private object Activate_7_AllPlayers() { return new global::App1.Views.AllPlayers(); }
        private object Activate_9_DateToStringConverter() { return new global::App1.Utils.DateToStringConverter(); }
        private object Activate_10_CurrencyForegroundConverter() { return new global::App1.Utils.CurrencyForegroundConverter(); }
        private object Activate_11_StringToCurrencyConverter() { return new global::App1.Utils.StringToCurrencyConverter(); }
        private object Activate_12_AllSessions() { return new global::App1.Views.AllSessions(); }
        private object Activate_13_PlayerPage() { return new global::App1.Views.PlayerPage(); }
        private object Activate_14_RebuyWindow() { return new global::App1.Views.RebuyWindow(); }
        private object Activate_16_TimespanToStringConverter() { return new global::App1.Utils.TimespanToStringConverter(); }
        private object Activate_17_Report() { return new global::App1.Views.Report(); }
        private object Activate_18_SessionPage() { return new global::App1.Views.SessionPage(); }
        private object Activate_19_MainPage() { return new global::App1.Views.MainPage(); }
        private object Activate_20_TourneyPage() { return new global::App1.Views.TourneyPage(); }

        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(int typeIndex)
        {
            global::App1.App1_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::App1.App1_XamlTypeInfo.XamlUserType userType;
            string typeName = _typeNameTable[typeIndex];
            global::System.Type type = _typeTable[typeIndex];

            switch (typeIndex)
            {

            case 0:   //  App1.Views.AddItem
                userType = new global::App1.App1_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
                userType.AddMemberName("TextInput");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 1:   //  Windows.UI.Xaml.Controls.UserControl
                xamlType = new global::App1.App1_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 2:   //  String
                xamlType = new global::App1.App1_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 3:   //  App1.Views.AddStakes
                userType = new global::App1.App1_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
                userType.Activator = Activate_3_AddStakes;
                userType.AddMemberName("LowAmount");
                userType.AddMemberName("HighAmount");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 4:   //  App1.Utils.AlternatingIndexConverter
                userType = new global::App1.App1_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_4_AlternatingIndexConverter;
                userType.AddMemberName("Even");
                userType.AddMemberName("Odd");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 5:   //  Object
                xamlType = new global::App1.App1_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 6:   //  Windows.UI.Xaml.Media.Brush
                xamlType = new global::App1.App1_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 7:   //  App1.Views.AllPlayers
                userType = new global::App1.App1_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_7_AllPlayers;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 8:   //  Windows.UI.Xaml.Controls.Page
                xamlType = new global::App1.App1_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 9:   //  App1.Utils.DateToStringConverter
                userType = new global::App1.App1_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_9_DateToStringConverter;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 10:   //  App1.Utils.CurrencyForegroundConverter
                userType = new global::App1.App1_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_10_CurrencyForegroundConverter;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 11:   //  App1.Utils.StringToCurrencyConverter
                userType = new global::App1.App1_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_11_StringToCurrencyConverter;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 12:   //  App1.Views.AllSessions
                userType = new global::App1.App1_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_12_AllSessions;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 13:   //  App1.Views.PlayerPage
                userType = new global::App1.App1_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_13_PlayerPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 14:   //  App1.Views.RebuyWindow
                userType = new global::App1.App1_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.UserControl"));
                userType.Activator = Activate_14_RebuyWindow;
                userType.AddMemberName("RebuyAmount");
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 15:   //  Int32
                xamlType = new global::App1.App1_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 16:   //  App1.Utils.TimespanToStringConverter
                userType = new global::App1.App1_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_16_TimespanToStringConverter;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 17:   //  App1.Views.Report
                userType = new global::App1.App1_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_17_Report;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 18:   //  App1.Views.SessionPage
                userType = new global::App1.App1_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_18_SessionPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 19:   //  App1.Views.MainPage
                userType = new global::App1.App1_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_19_MainPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 20:   //  App1.Views.TourneyPage
                userType = new global::App1.App1_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_20_TourneyPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;
            }
            return xamlType;
        }

        private global::System.Collections.Generic.List<global::Windows.UI.Xaml.Markup.IXamlMetadataProvider> _otherProviders;
        private global::System.Collections.Generic.List<global::Windows.UI.Xaml.Markup.IXamlMetadataProvider> OtherProviders
        {
            get
            {
                if(_otherProviders == null)
                {
                    _otherProviders = new global::System.Collections.Generic.List<global::Windows.UI.Xaml.Markup.IXamlMetadataProvider>();
                    global::Windows.UI.Xaml.Markup.IXamlMetadataProvider provider;
                    provider = new global::Microsoft.Advertising.Mobile.UI.UI_XamlTypeInfo.XamlMetaDataProvider() as global::Windows.UI.Xaml.Markup.IXamlMetadataProvider;
                    _otherProviders.Add(provider); 
                }
                return _otherProviders;
            }
        }

        private global::Windows.UI.Xaml.Markup.IXamlType CheckOtherMetadataProvidersForName(string typeName)
        {
            global::Windows.UI.Xaml.Markup.IXamlType xamlType = null;
            global::Windows.UI.Xaml.Markup.IXamlType foundXamlType = null;
            foreach(global::Windows.UI.Xaml.Markup.IXamlMetadataProvider xmp in OtherProviders)
            {
                xamlType = xmp.GetXamlType(typeName);
                if(xamlType != null)
                {
                    if(xamlType.IsConstructible)    // not Constructible means it might be a Return Type Stub
                    {
                        return xamlType;
                    }
                    foundXamlType = xamlType;
                }
            }
            return foundXamlType;
        }

        private global::Windows.UI.Xaml.Markup.IXamlType CheckOtherMetadataProvidersForType(global::System.Type type)
        {
            global::Windows.UI.Xaml.Markup.IXamlType xamlType = null;
            global::Windows.UI.Xaml.Markup.IXamlType foundXamlType = null;
            foreach(global::Windows.UI.Xaml.Markup.IXamlMetadataProvider xmp in OtherProviders)
            {
                xamlType = xmp.GetXamlType(type);
                if(xamlType != null)
                {
                    if(xamlType.IsConstructible)    // not Constructible means it might be a Return Type Stub
                    {
                        return xamlType;
                    }
                    foundXamlType = xamlType;
                }
            }
            return foundXamlType;
        }

        private object get_0_AddItem_TextInput(object instance)
        {
            var that = (global::App1.Views.AddItem)instance;
            return that.TextInput;
        }
        private object get_1_AddStakes_LowAmount(object instance)
        {
            var that = (global::App1.Views.AddStakes)instance;
            return that.LowAmount;
        }
        private object get_2_AddStakes_HighAmount(object instance)
        {
            var that = (global::App1.Views.AddStakes)instance;
            return that.HighAmount;
        }
        private object get_3_AlternatingIndexConverter_Even(object instance)
        {
            var that = (global::App1.Utils.AlternatingIndexConverter)instance;
            return that.Even;
        }
        private void set_3_AlternatingIndexConverter_Even(object instance, object Value)
        {
            var that = (global::App1.Utils.AlternatingIndexConverter)instance;
            that.Even = (global::Windows.UI.Xaml.Media.Brush)Value;
        }
        private object get_4_AlternatingIndexConverter_Odd(object instance)
        {
            var that = (global::App1.Utils.AlternatingIndexConverter)instance;
            return that.Odd;
        }
        private void set_4_AlternatingIndexConverter_Odd(object instance, object Value)
        {
            var that = (global::App1.Utils.AlternatingIndexConverter)instance;
            that.Odd = (global::Windows.UI.Xaml.Media.Brush)Value;
        }
        private object get_5_RebuyWindow_RebuyAmount(object instance)
        {
            var that = (global::App1.Views.RebuyWindow)instance;
            return that.RebuyAmount;
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::App1.App1_XamlTypeInfo.XamlMember xamlMember = null;
            global::App1.App1_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "App1.Views.AddItem.TextInput":
                userType = (global::App1.App1_XamlTypeInfo.XamlUserType)GetXamlTypeByName("App1.Views.AddItem");
                xamlMember = new global::App1.App1_XamlTypeInfo.XamlMember(this, "TextInput", "String");
                xamlMember.Getter = get_0_AddItem_TextInput;
                xamlMember.SetIsReadOnly();
                break;
            case "App1.Views.AddStakes.LowAmount":
                userType = (global::App1.App1_XamlTypeInfo.XamlUserType)GetXamlTypeByName("App1.Views.AddStakes");
                xamlMember = new global::App1.App1_XamlTypeInfo.XamlMember(this, "LowAmount", "String");
                xamlMember.Getter = get_1_AddStakes_LowAmount;
                xamlMember.SetIsReadOnly();
                break;
            case "App1.Views.AddStakes.HighAmount":
                userType = (global::App1.App1_XamlTypeInfo.XamlUserType)GetXamlTypeByName("App1.Views.AddStakes");
                xamlMember = new global::App1.App1_XamlTypeInfo.XamlMember(this, "HighAmount", "String");
                xamlMember.Getter = get_2_AddStakes_HighAmount;
                xamlMember.SetIsReadOnly();
                break;
            case "App1.Utils.AlternatingIndexConverter.Even":
                userType = (global::App1.App1_XamlTypeInfo.XamlUserType)GetXamlTypeByName("App1.Utils.AlternatingIndexConverter");
                xamlMember = new global::App1.App1_XamlTypeInfo.XamlMember(this, "Even", "Windows.UI.Xaml.Media.Brush");
                xamlMember.Getter = get_3_AlternatingIndexConverter_Even;
                xamlMember.Setter = set_3_AlternatingIndexConverter_Even;
                break;
            case "App1.Utils.AlternatingIndexConverter.Odd":
                userType = (global::App1.App1_XamlTypeInfo.XamlUserType)GetXamlTypeByName("App1.Utils.AlternatingIndexConverter");
                xamlMember = new global::App1.App1_XamlTypeInfo.XamlMember(this, "Odd", "Windows.UI.Xaml.Media.Brush");
                xamlMember.Getter = get_4_AlternatingIndexConverter_Odd;
                xamlMember.Setter = set_4_AlternatingIndexConverter_Odd;
                break;
            case "App1.Views.RebuyWindow.RebuyAmount":
                userType = (global::App1.App1_XamlTypeInfo.XamlUserType)GetXamlTypeByName("App1.Views.RebuyWindow");
                xamlMember = new global::App1.App1_XamlTypeInfo.XamlMember(this, "RebuyAmount", "Int32");
                xamlMember.Getter = get_5_RebuyWindow_RebuyAmount;
                xamlMember.SetIsReadOnly();
                break;
            }
            return xamlMember;
        }
    }

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType
    {
        string _fullName;
        global::System.Type _underlyingType;

        public XamlSystemBaseType(string fullName, global::System.Type underlyingType)
        {
            _fullName = fullName;
            _underlyingType = underlyingType;
        }

        public string FullName { get { return _fullName; } }

        public global::System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        virtual public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name) { throw new global::System.NotImplementedException(); }
        virtual public bool IsArray { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsCollection { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsConstructible { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsDictionary { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsMarkupExtension { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsBindable { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsReturnTypeStub { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsLocalType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType ItemType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType KeyType { get { throw new global::System.NotImplementedException(); } }
        virtual public object ActivateInstance() { throw new global::System.NotImplementedException(); }
        virtual public void AddToMap(object instance, object key, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void AddToVector(object instance, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void RunInitializer()   { throw new global::System.NotImplementedException(); }
        virtual public object CreateFromString(string input)   { throw new global::System.NotImplementedException(); }
    }
    
    internal delegate object Activator();
    internal delegate void AddToCollection(object instance, object item);
    internal delegate void AddToDictionary(object instance, object key, object item);

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlUserType : global::App1.App1_XamlTypeInfo.XamlSystemBaseType
    {
        global::App1.App1_XamlTypeInfo.XamlTypeInfoProvider _provider;
        global::Windows.UI.Xaml.Markup.IXamlType _baseType;
        bool _isArray;
        bool _isMarkupExtension;
        bool _isBindable;
        bool _isReturnTypeStub;
        bool _isLocalType;

        string _contentPropertyName;
        string _itemTypeName;
        string _keyTypeName;
        global::System.Collections.Generic.Dictionary<string, string> _memberNames;
        global::System.Collections.Generic.Dictionary<string, object> _enumValues;

        public XamlUserType(global::App1.App1_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
            :base(fullName, fullType)
        {
            _provider = provider;
            _baseType = baseType;
        }

        // --- Interface methods ----

        override public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { return _baseType; } }
        override public bool IsArray { get { return _isArray; } }
        override public bool IsCollection { get { return (CollectionAdd != null); } }
        override public bool IsConstructible { get { return (Activator != null); } }
        override public bool IsDictionary { get { return (DictionaryAdd != null); } }
        override public bool IsMarkupExtension { get { return _isMarkupExtension; } }
        override public bool IsBindable { get { return _isBindable; } }
        override public bool IsReturnTypeStub { get { return _isReturnTypeStub; } }
        override public bool IsLocalType { get { return _isLocalType; } }

        override public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty
        {
            get { return _provider.GetMemberByLongName(_contentPropertyName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType ItemType
        {
            get { return _provider.GetXamlTypeByName(_itemTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType KeyType
        {
            get { return _provider.GetXamlTypeByName(_keyTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name)
        {
            if (_memberNames == null)
            {
                return null;
            }
            string longName;
            if (_memberNames.TryGetValue(name, out longName))
            {
                return _provider.GetMemberByLongName(longName);
            }
            return null;
        }

        override public object ActivateInstance()
        {
            return Activator(); 
        }

        override public void AddToMap(object instance, object key, object item) 
        {
            DictionaryAdd(instance, key, item);
        }

        override public void AddToVector(object instance, object item)
        {
            CollectionAdd(instance, item);
        }

        override public void RunInitializer() 
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(UnderlyingType.TypeHandle);
        }

        override public object CreateFromString(string input)
        {
            if (_enumValues != null)
            {
                int value = 0;

                string[] valueParts = input.Split(',');

                foreach (string valuePart in valueParts) 
                {
                    object partValue;
                    int enumFieldValue = 0;
                    try
                    {
                        if (_enumValues.TryGetValue(valuePart.Trim(), out partValue))
                        {
                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                        }
                        else
                        {
                            try
                            {
                                enumFieldValue = global::System.Convert.ToInt32(valuePart.Trim());
                            }
                            catch( global::System.FormatException )
                            {
                                foreach( string key in _enumValues.Keys )
                                {
                                    if( string.Compare(valuePart.Trim(), key, global::System.StringComparison.OrdinalIgnoreCase) == 0 )
                                    {
                                        if( _enumValues.TryGetValue(key.Trim(), out partValue) )
                                        {
                                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        value |= enumFieldValue; 
                    }
                    catch( global::System.FormatException )
                    {
                        throw new global::System.ArgumentException(input, FullName);
                    }
                }

                return value; 
            }
            throw new global::System.ArgumentException(input, FullName);
        }

        // --- End of Interface methods

        public Activator Activator { get; set; }
        public AddToCollection CollectionAdd { get; set; }
        public AddToDictionary DictionaryAdd { get; set; }

        public void SetContentPropertyName(string contentPropertyName)
        {
            _contentPropertyName = contentPropertyName;
        }

        public void SetIsArray()
        {
            _isArray = true; 
        }

        public void SetIsMarkupExtension()
        {
            _isMarkupExtension = true;
        }

        public void SetIsBindable()
        {
            _isBindable = true;
        }

        public void SetIsReturnTypeStub()
        {
            _isReturnTypeStub = true;
        }

        public void SetIsLocalType()
        {
            _isLocalType = true;
        }

        public void SetItemTypeName(string itemTypeName)
        {
            _itemTypeName = itemTypeName;
        }

        public void SetKeyTypeName(string keyTypeName)
        {
            _keyTypeName = keyTypeName;
        }

        public void AddMemberName(string shortName)
        {
            if(_memberNames == null)
            {
                _memberNames =  new global::System.Collections.Generic.Dictionary<string,string>();
            }
            _memberNames.Add(shortName, FullName + "." + shortName);
        }

        public void AddEnumValue(string name, object value)
        {
            if (_enumValues == null)
            {
                _enumValues = new global::System.Collections.Generic.Dictionary<string, object>();
            }
            _enumValues.Add(name, value);
        }
    }

    internal delegate object Getter(object instance);
    internal delegate void Setter(object instance, object value);

    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]    
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember
    {
        global::App1.App1_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::App1.App1_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
        {
            _name = name;
            _typeName = typeName;
            _provider = provider;
        }

        public string Name { get { return _name; } }

        public global::Windows.UI.Xaml.Markup.IXamlType Type
        {
            get { return _provider.GetXamlTypeByName(_typeName); }
        }

        public void SetTargetTypeName(string targetTypeName)
        {
            _targetTypeName = targetTypeName;
        }
        public global::Windows.UI.Xaml.Markup.IXamlType TargetType
        {
            get { return _provider.GetXamlTypeByName(_targetTypeName); }
        }

        public void SetIsAttachable() { _isAttachable = true; }
        public bool IsAttachable { get { return _isAttachable; } }

        public void SetIsDependencyProperty() { _isDependencyProperty = true; }
        public bool IsDependencyProperty { get { return _isDependencyProperty; } }

        public void SetIsReadOnly() { _isReadOnly = true; }
        public bool IsReadOnly { get { return _isReadOnly; } }

        public Getter Getter { get; set; }
        public object GetValue(object instance)
        {
            if (Getter != null)
                return Getter(instance);
            else
                throw new global::System.InvalidOperationException("GetValue");
        }

        public Setter Setter { get; set; }
        public void SetValue(object instance, object value)
        {
            if (Setter != null)
                Setter(instance, value);
            else
                throw new global::System.InvalidOperationException("SetValue");
        }
    }
}


