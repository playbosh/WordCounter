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
    public class StartCommand : CommandBase
    {
        private Action<object> _action;

        public StartCommand(Action<object> action)
        {
            _action = action;
        }
        public override void Execute(object parameter)
        {
            _action(new object());
        }
    }
}
