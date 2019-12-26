using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ModulCommentator;
using ModulCommentatorViewModel;

namespace ModulCommentator.view
{
    /// <summary>
    /// Interaktionslogik für ModuleView.xaml
    /// </summary>
    public partial class ModuleView : UserControl
    {
        ModuleViewModel viewModel;
        public ModuleView(ModuleViewModel viewModel)
        {
            InitializeComponent();

            this.viewModel = viewModel;
            this.DataContext = viewModel;
        }
    }
}
