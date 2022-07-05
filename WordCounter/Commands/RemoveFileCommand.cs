using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Model;

namespace WordCounter.Commands
{
    public class RemoveFileCommand : CommandBase
    {
        private readonly WordCounterSystem _system;
        private Action<object> _action;
        public RemoveFileCommand(WordCounterSystem system, Action<object> action)
        {
            _system = system;
            _action = action;
        }

        public override void Execute(object parameter)
        {
            _system._wordFiles.RemoveFiles();
            _action(new object());
        }
    }
}
