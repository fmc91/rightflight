﻿#pragma checksum "..\..\..\..\UserControls\SuggestionBox.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EEEBA39E142822C6BC3889AAA79B9D2457F80107"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RightFlight;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace RightFlight {
    
    
    /// <summary>
    /// SuggestionBox
    /// </summary>
    public partial class SuggestionBox : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\UserControls\SuggestionBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal RightFlight.SuggestionBox Root;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\UserControls\SuggestionBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EntryBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\UserControls\SuggestionBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup SuggestionPopup;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\UserControls\SuggestionBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox SuggestionListBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RightFlight;component/usercontrols/suggestionbox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\SuggestionBox.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Root = ((RightFlight.SuggestionBox)(target));
            
            #line 9 "..\..\..\..\UserControls\SuggestionBox.xaml"
            this.Root.Loaded += new System.Windows.RoutedEventHandler(this.RootLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.EntryBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\..\..\UserControls\SuggestionBox.xaml"
            this.EntryBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.EntryBoxTextChanged);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\UserControls\SuggestionBox.xaml"
            this.EntryBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.EntryBoxPreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SuggestionPopup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 4:
            this.SuggestionListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 24 "..\..\..\..\UserControls\SuggestionBox.xaml"
            this.SuggestionListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SuggestionBoxSelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

