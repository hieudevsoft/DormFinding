﻿#pragma checksum "..\..\..\UserController\MyDorm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "080763028D2A5A665A8ACE4DD96B72F60970F20F3B16C18F4B3F6AAC1F0D055A"
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
    /// MyDorm
    /// </summary>
    public partial class MyDorm : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\UserController\MyDorm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DormFinding.MyDorm myDorm;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\UserController\MyDorm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Transitions.TransitioningContent TransitioningContentSlide;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\UserController\MyDorm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid layoutMainDorm;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\UserController\MyDorm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNotify;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\UserController\MyDorm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse notifyMyDorm;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\UserController\MyDorm.xaml"
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
            System.Uri resourceLocater = new System.Uri("/DormFinding;component/usercontroller/mydorm.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserController\MyDorm.xaml"
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
            this.myDorm = ((DormFinding.MyDorm)(target));
            return;
            case 2:
            this.TransitioningContentSlide = ((MaterialDesignThemes.Wpf.Transitions.TransitioningContent)(target));
            return;
            case 3:
            this.layoutMainDorm = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.btnNotify = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\UserController\MyDorm.xaml"
            this.btnNotify.Click += new System.Windows.RoutedEventHandler(this.btnNotify_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.notifyMyDorm = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 6:
            this.listViewVerti = ((System.Windows.Controls.ListView)(target));
            
            #line 100 "..\..\..\UserController\MyDorm.xaml"
            this.listViewVerti.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listViewVerti_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

