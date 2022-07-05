using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.ViewModels;

namespace WordCounter.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrenViewModleChanged;
        private void OnCurrentViewModelChanged()
        {
            CurrenViewModleChanged?.Invoke();
        }


       

        
    }
}
