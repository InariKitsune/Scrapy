﻿#pragma checksum "..\..\EditCustomer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "25AD3267635FA1309FB7E4CEBB4508A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
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


namespace PrestamixC {
    
    
    /// <summary>
    /// EditCustomer
    /// </summary>
    public partial class EditCustomer : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox fTextBox;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox mTextBox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addressTextBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button confirmB;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelB;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phoneTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/PrestamixC;component/editcustomer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditCustomer.xaml"
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
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.fTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.mTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.addressTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.confirmB = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\EditCustomer.xaml"
            this.confirmB.Click += new System.Windows.RoutedEventHandler(this.confirmB_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cancelB = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\EditCustomer.xaml"
            this.cancelB.Click += new System.Windows.RoutedEventHandler(this.cancelB_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.phoneTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

