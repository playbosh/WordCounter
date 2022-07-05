using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WordCounter.Commands;
using WordCounter.Model;
using WordCounter.Stores;

namespace WordCounter.ViewModels
{
    public class ResultViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly WordCounterSystem _system;

        
        public ICommand BackToFileSelectCommand { get; }
        public IEnumerable<ResultGridViewModel> ResultWords => _calculatedWords;
        private readonly ObservableCollection<ResultGridViewModel> _calculatedWords;

        public ResultViewModel(WordCounterSystem system, NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _system = system;

            BackToFileSelectCommand = new BackToFileSelectCommand(system, navigationStore);
            _calculatedWords = new ObservableCollection<ResultGridViewModel>();

            UpdateCurrentFiles();
        }


        public void UpdateCurrentFiles()
        {
            _calculatedWords.Clear();

            foreach (KeyValuePair<string, int> entry in _system._wordResults._result)
            {
                ResultGridViewModel selectFileGridViewModel = new ResultGridViewModel(entry);

                _calculatedWords.Add(
                    new ResultGridViewModel(
                        entry
                    ));
            }
        }
    }
}
