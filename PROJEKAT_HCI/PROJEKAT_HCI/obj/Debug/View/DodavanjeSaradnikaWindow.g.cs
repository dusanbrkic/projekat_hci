﻿#pragma checksum "..\..\..\View\DodavanjeSaradnikaWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8A2DF1F042F27D5D9E976284BB451DFB35410214FECE98DE22639CF9EDB9761C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Apex.Controls;
using PROJEKAT_HCI.View;
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


namespace PROJEKAT_HCI.View {
    
    
    /// <summary>
    /// DodavanjeSaradnikaWindow
    /// </summary>
    public partial class DodavanjeSaradnikaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\..\View\DodavanjeSaradnikaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Naziv;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\View\DodavanjeSaradnikaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tip;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\View\DodavanjeSaradnikaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Lokacija;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\View\DodavanjeSaradnikaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Opis;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\View\DodavanjeSaradnikaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button odustao;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\View\DodavanjeSaradnikaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Dodaj_saradnika;
        
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
            System.Uri resourceLocater = new System.Uri("/PROJEKAT_HCI;component/view/dodavanjesaradnikawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\DodavanjeSaradnikaWindow.xaml"
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
            this.Naziv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Tip = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Lokacija = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Opis = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.odustao = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\View\DodavanjeSaradnikaWindow.xaml"
            this.odustao.Click += new System.Windows.RoutedEventHandler(this.odustao_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Dodaj_saradnika = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\View\DodavanjeSaradnikaWindow.xaml"
            this.Dodaj_saradnika.Click += new System.Windows.RoutedEventHandler(this.registruj_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

