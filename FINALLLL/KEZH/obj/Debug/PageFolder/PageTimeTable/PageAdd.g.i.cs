﻿#pragma checksum "..\..\..\..\PageFolder\PageTimeTable\PageAdd.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B4897E1A386437CD7BB87B7E109BC13E50C81270AD8E6637BC4E8EF73D3E4692"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using KEZH.PageFolder.PageTimeTable;
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


namespace KEZH.PageFolder.PageTimeTable {
    
    
    /// <summary>
    /// PageAdd
    /// </summary>
    public partial class PageAdd : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\PageFolder\PageTimeTable\PageAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbSemestr;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\PageFolder\PageTimeTable\PageAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbDayWeek;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\PageFolder\PageTimeTable\PageAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbNumber;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\PageFolder\PageTimeTable\PageAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbGroup;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\PageFolder\PageTimeTable\PageAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbDiscipline;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\PageFolder\PageTimeTable\PageAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAddDiscipline;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\PageFolder\PageTimeTable\PageAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btOtmena;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\PageFolder\PageTimeTable\PageAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAdd;
        
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
            System.Uri resourceLocater = new System.Uri("/KEZH;component/pagefolder/pagetimetable/pageadd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\PageFolder\PageTimeTable\PageAdd.xaml"
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
            
            #line 10 "..\..\..\..\PageFolder\PageTimeTable\PageAdd.xaml"
            ((KEZH.PageFolder.PageTimeTable.PageAdd)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CbSemestr = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\..\..\PageFolder\PageTimeTable\PageAdd.xaml"
            this.CbSemestr.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CbSemestr_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CbDayWeek = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.CbNumber = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.CbGroup = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.CbDiscipline = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.BtnAddDiscipline = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\PageFolder\PageTimeTable\PageAdd.xaml"
            this.BtnAddDiscipline.Click += new System.Windows.RoutedEventHandler(this.BtnAddDiscipline_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btOtmena = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\..\PageFolder\PageTimeTable\PageAdd.xaml"
            this.btOtmena.Click += new System.Windows.RoutedEventHandler(this.btOtmena_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btAdd = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\..\PageFolder\PageTimeTable\PageAdd.xaml"
            this.btAdd.Click += new System.Windows.RoutedEventHandler(this.btAdd_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

