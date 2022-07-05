using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Model;
using WordCounter.Stores;
using WordCounter.ViewModels;

namespace WordCounter.Commands
{
    public class BackToFileSelectCommand : CommandBase
    {
        private readonly WordCounterSystem _system;
        private readonly NavigationStore _navigationStore;
        public BackToFileSelectCommand(WordCounterSystem system, NavigationStore navigationStore)
        {
            _system = system;
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new SelectFileViewModel(_system, _navigationStore);
        }
    }
}
