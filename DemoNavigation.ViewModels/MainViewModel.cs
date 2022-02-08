using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tools.Patterns.Mvvm.Commands;
using Tools.Patterns.Mvvm.ViewModels;

namespace DemoNavigation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<ViewModelBase> _viewModels;

        public ObservableCollection<ViewModelBase> ViewModels
        {
            get => _viewModels ??= new ObservableCollection<ViewModelBase>(
                new ViewModelBase[]
                {
                    new ViewModel1(),
                    new ViewModel2()
                });           
        }

        private ViewModelBase _selectedViewModel;
        public ViewModelBase SelectedViewModel 
        { 
            get => _selectedViewModel; 
            set
            {
                _selectedViewModel = value;
                RaisePropertyChanged(nameof(SelectedViewModel));
            }             
        }

        private ICommand _changeContentCommand;
        public ICommand ChangeContentCommand 
        { 
            get => _changeContentCommand ??= new Command<ViewModelBase>(ChangeContent, null);
        }

        private void ChangeContent(ViewModelBase selectedViewModel)
        {
            SelectedViewModel = selectedViewModel;
        }
    }
}
