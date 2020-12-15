﻿#pragma checksum "..\..\..\TournamentViewerWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "81C4FA37519AE1AFD320DF0CBB6D713A4DDCEB83"
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
using TrackerLibrary;
using TrackerUI;


namespace TrackerUI {
    
    
    /// <summary>
    /// TournamentViewerForm
    /// </summary>
    public partial class TournamentViewerForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\TournamentViewerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TrackerUI.TournamentViewerForm Tournament_Viewer_Form;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\TournamentViewerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label tournamentLabel;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\TournamentViewerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label tournamentNameLabel;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\TournamentViewerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label roundLabel;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\TournamentViewerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox matchupListBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\TournamentViewerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox unplayedRoundCheckBx;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\TournamentViewerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox roundComboBx;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\TournamentViewerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label teamOneLabel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\TournamentViewerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label teamTwoLabel;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\TournamentViewerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label teamOneScoreLabel;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\TournamentViewerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label teamTwoScoreLabel;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\TournamentViewerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox teamOneScore_textbx;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\TournamentViewerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox teamTwoScoreValue;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\TournamentViewerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label vsLabel;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\TournamentViewerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button scoreBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/TrackerUI;component/tournamentviewerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TournamentViewerWindow.xaml"
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
            this.Tournament_Viewer_Form = ((TrackerUI.TournamentViewerForm)(target));
            return;
            case 2:
            this.tournamentLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.tournamentNameLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.roundLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.matchupListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.unplayedRoundCheckBx = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.roundComboBx = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.teamOneLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.teamTwoLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.teamOneScoreLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.teamTwoScoreLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.teamOneScore_textbx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.teamTwoScoreValue = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.vsLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.scoreBtn = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

