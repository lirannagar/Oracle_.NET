﻿#pragma checksum "..\..\..\Admin\DeleteAdminWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7493152AA60D222E19929D430FF81BF39EA94CFA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using OracalDBProject;
using OracalDBProject.Admin;
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


namespace OracalDBProject.Admin {
    
    
    /// <summary>
    /// DeleteAdminWindow
    /// </summary>
    public partial class DeleteAdminWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\Admin\DeleteAdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Admin\DeleteAdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchButtonDeleteWindow;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Admin\DeleteAdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox searchComboBoxDeleteAdmin;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Admin\DeleteAdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxSearchDeleteAdmin;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Admin\DeleteAdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label searchLabelAdmin;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Admin\DeleteAdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label deleteLabel;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Admin\DeleteAdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox deleteTextBox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Admin\DeleteAdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButtonAdmin;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Admin\DeleteAdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button showAllAdminsButton;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Admin\DeleteAdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
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
            System.Uri resourceLocater = new System.Uri("/OracalDBProject;component/admin/deleteadminwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Admin\DeleteAdminWindow.xaml"
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
            
            #line 10 "..\..\..\Admin\DeleteAdminWindow.xaml"
            ((OracalDBProject.Admin.DeleteAdminWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.searchButtonDeleteWindow = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Admin\DeleteAdminWindow.xaml"
            this.searchButtonDeleteWindow.Click += new System.Windows.RoutedEventHandler(this.searchButtonDeleteWindow_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.searchComboBoxDeleteAdmin = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.textBoxSearchDeleteAdmin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.searchLabelAdmin = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.deleteLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.deleteTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.deleteButtonAdmin = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Admin\DeleteAdminWindow.xaml"
            this.deleteButtonAdmin.Click += new System.Windows.RoutedEventHandler(this.deleteButtonAdmin_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.showAllAdminsButton = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\Admin\DeleteAdminWindow.xaml"
            this.showAllAdminsButton.Click += new System.Windows.RoutedEventHandler(this.showAllAdminsButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Admin\DeleteAdminWindow.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.backButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

