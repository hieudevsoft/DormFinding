﻿#pragma checksum "..\..\..\UserController\HomeControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AE758B84DCB6DAC3D7CF2F83667DAD42888465FC5335213645C5F259D5638FC2"
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
using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
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
    /// HomeControl
    /// </summary>
    public partial class HomeControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\UserController\HomeControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Transitions.TransitioningContent TransitioningContentSlide;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UserController\HomeControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid layoutMainDorm;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\UserController\HomeControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchQuery;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\UserController\HomeControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbGender;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\UserController\HomeControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewHori;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\..\UserController\HomeControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewVerti;
        
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
            System.Uri resourceLocater = new System.Uri("/DormFinding;component/usercontroller/homecontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserController\HomeControl.xaml"
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
            this.TransitioningContentSlide = ((MaterialDesignThemes.Wpf.Transitions.TransitioningContent)(target));
            return;
            case 2:
            this.layoutMainDorm = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.searchQuery = ((System.Windows.Controls.TextBox)(target));
            
            #line 61 "..\..\..\UserController\HomeControl.xaml"
            this.searchQuery.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.searchQuery_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbGender = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.listViewHori = ((System.Windows.Controls.ListView)(target));
            
            #line 134 "..\..\..\UserController\HomeControl.xaml"
            this.listViewHori.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listViewHori_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.listViewVerti = ((System.Windows.Controls.ListView)(target));
            
            #line 184 "..\..\..\UserController\HomeControl.xaml"
            this.listViewVerti.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listViewVerti_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

