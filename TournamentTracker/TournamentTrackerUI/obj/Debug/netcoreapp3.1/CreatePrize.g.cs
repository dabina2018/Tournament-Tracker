﻿#pragma checksum "..\..\..\CreatePrize.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BC8EAD78927B0D1EAA3D89EE115EFAF18C8CE7A2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using TournamentTrackerUI;


namespace TournamentTrackerUI {
    
    
    /// <summary>
    /// CreatePrize
    /// </summary>
    public partial class CreatePrize : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\CreatePrize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox placeNumber_textbx;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\CreatePrize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox placeName_textbx;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\CreatePrize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox prizeAmt_textbx;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\CreatePrize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox prizePercentage_textbx;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\CreatePrize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreatePrize_Btn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TournamentTrackerUI;component/createprize.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CreatePrize.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.placeNumber_textbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.placeName_textbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.prizeAmt_textbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.prizePercentage_textbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.CreatePrize_Btn = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\CreatePrize.xaml"
            this.CreatePrize_Btn.Click += new System.Windows.RoutedEventHandler(this.CreatePrize_Btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

