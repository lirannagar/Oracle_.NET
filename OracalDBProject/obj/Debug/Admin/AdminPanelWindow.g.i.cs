﻿#pragma checksum "..\..\..\Admin\AdminPanelWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D2F1E42E43A389921657423293A4D98DB28F630C"
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


namespace OracalDBProject {
    
    
    /// <summary>
    /// AdminPanel
    /// </summary>
    public partial class AdminPanel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Admin\AdminPanelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowProductsButton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Admin\AdminPanelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewProductButton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Admin\AdminPanelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteProductButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Admin\AdminPanelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewClumMemberButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Admin\AdminPanelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowClubMemberButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Admin\AdminPanelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowAdminButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Admin\AdminPanelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewAdminButton;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Admin\AdminPanelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteAdminButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Admin\AdminPanelWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteClubMemberButton;
        
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
            System.Uri resourceLocater = new System.Uri("/OracalDBProject;component/admin/adminpanelwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Admin\AdminPanelWindow.xaml"
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
            this.ShowProductsButton = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.AddNewProductButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Admin\AdminPanelWindow.xaml"
            this.AddNewProductButton.Click += new System.Windows.RoutedEventHandler(this.AddNewProductButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DeleteProductButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Admin\AdminPanelWindow.xaml"
            this.DeleteProductButton.Click += new System.Windows.RoutedEventHandler(this.DeleteProductButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddNewClumMemberButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Admin\AdminPanelWindow.xaml"
            this.AddNewClumMemberButton.Click += new System.Windows.RoutedEventHandler(this.AddNewClumMemberButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ShowClubMemberButton = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.ShowAdminButton = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.AddNewAdminButton = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Admin\AdminPanelWindow.xaml"
            this.AddNewAdminButton.Click += new System.Windows.RoutedEventHandler(this.AddNewAdminButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DeleteAdminButton = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.DeleteClubMemberButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
