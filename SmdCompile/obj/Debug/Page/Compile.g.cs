﻿#pragma checksum "..\..\..\Page\Compile.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "168902CFB01F9362F034AE8F60ADEC6F8373D777A1E292A39A2EB5ABED56E865"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SmdCompile.Controls;
using SmdCompile.Page;
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
using UI.SyntaxBox;


namespace SmdCompile.Page {
    
    
    /// <summary>
    /// Compile
    /// </summary>
    public partial class Compile : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Page\Compile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox list_projects;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Page\Compile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border conv_o;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Page\Compile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border conv_a;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Page\Compile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Compile_Editors;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Page\Compile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border editor_save;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Page\Compile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Log;
        
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
            System.Uri resourceLocater = new System.Uri("/SmdCompile;component/page/compile.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Page\Compile.xaml"
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
            
            #line 9 "..\..\..\Page\Compile.xaml"
            ((SmdCompile.Page.Compile)(target)).Drop += new System.Windows.DragEventHandler(this.UserControl_Drop);
            
            #line default
            #line hidden
            return;
            case 2:
            this.list_projects = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.conv_o = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.conv_a = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.Compile_Editors = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.editor_save = ((System.Windows.Controls.Border)(target));
            
            #line 39 "..\..\..\Page\Compile.xaml"
            this.editor_save.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.editor_save_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TextBox_Log = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

