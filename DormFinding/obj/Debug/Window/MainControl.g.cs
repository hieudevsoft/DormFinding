﻿#pragma checksum "..\..\..\Window\MainControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "895303E69675D0C58543546A0AC442BA039AF7DEBAEBD08E0EEFD456A5D80CB3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DormFinding;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace DormFinding {
    
    
    /// <summary>
    /// MainControl
    /// </summary>
    public partial class MainControl : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 73 "..\..\..\Window\MainControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WebBrowser wbLogout;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Window\MainControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSignOut;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\..\Window\MainControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExitApp;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\Window\MainControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border GridMenu;
        
        #line default
        #line hidden
        
        
        #line 193 "..\..\..\Window\MainControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCloseMenu;
        
        #line default
        #line hidden
        
        
        #line 206 "..\..\..\Window\MainControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOpenMenu;
        
        #line default
        #line hidden
        
        
        #line 222 "..\..\..\Window\MainControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Transitions.TransitioningContent TransitioningContentSlide;
        
        #line default
        #line hidden
        
        
        #line 232 "..\..\..\Window\MainControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border SlideCursor;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\..\Window\MainControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewSideBar;
        
        #line default
        #line hidden
        
        
        #line 354 "..\..\..\Window\MainControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Transitions.TransitioningContent TransitioningContentSlideAdd;
        
        #line default
        #line hidden
        
        
        #line 356 "..\..\..\Window\MainControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainHomeLayout;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DormFinding;component/window/maincontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Window\MainControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\Window\MainControl.xaml"
            ((DormFinding.MainControl)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.wbLogout = ((System.Windows.Controls.WebBrowser)(target));
            
            #line 80 "..\..\..\Window\MainControl.xaml"
            this.wbLogout.Navigated += new System.Windows.Navigation.NavigatedEventHandler(this.wbLogout_Navigated);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnSignOut = ((System.Windows.Controls.Button)(target));
            
            #line 103 "..\..\..\Window\MainControl.xaml"
            this.btnSignOut.Click += new System.Windows.RoutedEventHandler(this.btnSignOut_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnExitApp = ((System.Windows.Controls.Button)(target));
            
            #line 146 "..\..\..\Window\MainControl.xaml"
            this.btnExitApp.Click += new System.Windows.RoutedEventHandler(this.btnExitApp_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.GridMenu = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.btnCloseMenu = ((System.Windows.Controls.Button)(target));
            
            #line 196 "..\..\..\Window\MainControl.xaml"
            this.btnCloseMenu.Click += new System.Windows.RoutedEventHandler(this.btnCloseMenu_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnOpenMenu = ((System.Windows.Controls.Button)(target));
            
            #line 209 "..\..\..\Window\MainControl.xaml"
            this.btnOpenMenu.Click += new System.Windows.RoutedEventHandler(this.btnOpenMenu_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TransitioningContentSlide = ((MaterialDesignThemes.Wpf.Transitions.TransitioningContent)(target));
            return;
            case 9:
            this.SlideCursor = ((System.Windows.Controls.Border)(target));
            return;
            case 10:
            this.ListViewSideBar = ((System.Windows.Controls.ListView)(target));
            
            #line 239 "..\..\..\Window\MainControl.xaml"
            this.ListViewSideBar.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListViewSideBar_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.TransitioningContentSlideAdd = ((MaterialDesignThemes.Wpf.Transitions.TransitioningContent)(target));
            return;
            case 12:
            this.MainHomeLayout = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

