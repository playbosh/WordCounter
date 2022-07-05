using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter.Model;

namespace WordCounter.ViewModels
{
    public class SelectFileGridViewModel : ViewModelBase
    {
        private readonly Files _files;
        public string FilePath => _files.FilePath;
        public long FileSize => _files.FileSize;

        public SelectFileGridViewModel(Files files)
        {
            _files = files;
        }
    }
}
