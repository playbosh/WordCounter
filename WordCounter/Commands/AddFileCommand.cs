using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Model;

namespace WordCounter.Commands
{
    public class AddFileCommand : CommandBase
    {
        private Action<object> _action;
        public AddFileCommand(Action<object> action)
        {
            _action = action;
        }

        public override void Execute(object parameter)
        {
            _action(new object());
        }
    }
}