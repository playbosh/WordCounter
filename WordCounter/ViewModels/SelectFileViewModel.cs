using LIB.FileWordAnalyzer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WordCounter.Commands;
using WordCounter.Model;
using WordCounter.Stores;
using WordCounter.Utilities;

namespace WordCounter.ViewModels
{
    public class SelectFileViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly WordCounterSystem _system;
        public ICommand AddFileCommand { get;  }
        public ICommand RemoveFilesCommand { get; }
        public ICommand StartCounting { get; }
        public ICommand CancleProgressCommand { get; }
        public IEnumerable<SelectFileGridViewModel> WordFilesSelect => _filesSelected;
        private readonly ObservableCollection<SelectFileGridViewModel> _filesSelected;
        private ISectionStatus _sectionStatus;
        public ISectionStatus SectionStatus
        {
            get => _sectionStatus;
            set
            {
                if (Equals(value, _sectionStatus))
                {
                    return;
                }

                _sectionStatus = value;
                OnPropertyChanged("SectionStatus");
            }
        }
        private CancellationTokenSource _cancellationTokenSource;
        private bool _activProcess = false;
        public bool ActiveProzess
        {
            get => _activProcess;
            private set
            {
                if (value == _activProcess)
                {
                    return;
                }

                _activProcess = value;
                OnPropertyChanged("ActiveProzess");
            }
        }
        public int FileCount
        {
            get
            {
                return _system._wordFiles._wordFilesToSearch.Count;
            }
        }
        private long _size;
        public string FileSize
        {
            get
            {
                _size = 0;
                foreach (Files file in _system._wordFiles._wordFilesToSearch)
                {
                    _size += file.FileSize;
                }
                return ByteCalculator.SizeSuffix(_size,2);
            }
        }


        public SelectFileViewModel(WordCounterSystem system, NavigationStore navigationStore)
        {
            _system = system;
            _navigationStore = navigationStore;

            AddFileCommand = new AddFileCommand(new Action<object>(AddFiles));
            RemoveFilesCommand = new RemoveFileCommand(system, new Action<object>(UpdateCurrentFiles));
            StartCounting = new StartCommand(new Action<object>(SearchProcess));
            CancleProgressCommand = new CancleProgressCommand(new Action<object>(CancleProgress));
           
            _filesSelected = new ObservableCollection<SelectFileGridViewModel>();

            UpdateCurrentFiles(new object());
        }
        
        public void CancleProgress(object obj)
        {
            _cancellationTokenSource.Cancel();
        }
        public void AddFiles(object obj)
        {
            var dialog = new OpenFileDialog
            {
                Multiselect = true,
                CheckFileExists = true,
                ValidateNames = true,
                Filter = "Text files (*.txt)|*.txt",
                InitialDirectory = Directory.GetCurrentDirectory()
            };
            if ((dialog.ShowDialog() ?? false) && !string.IsNullOrEmpty(dialog.FileName))
            {
                foreach (string filename in dialog.FileNames)
                {
                    _system._wordFiles._wordFilesToSearch.Add(
                        new Files(
                            filename,
                            new FileInfo(filename).Length,
                            string.Empty
                            )
                        );
                }
            }

            UpdateCurrentFiles(new object());
        }
        public void UpdateCurrentFiles(object obj)
        {
            _filesSelected.Clear();

            foreach(Files file in _system._wordFiles._wordFilesToSearch)
            {
                SelectFileGridViewModel selectFileGridViewModel = new SelectFileGridViewModel(file);

                _filesSelected.Add(
                    new SelectFileGridViewModel(
                        new Files(
                            file.FilePath, 
                            file.FileSize, 
                            file.FileContent
                            )
                        )
                    );
            }

            OnPropertyChanged("FileCount"); 
            OnPropertyChanged("FileSize");
        }
        public async void SearchProcess(object obj)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _system._wordResults._result = new Dictionary<string, int>();

            ActiveProzess = true;
            foreach (Files entry in _system._wordFiles._wordFilesToSearch)
            {
                Stream fs = File.OpenRead(entry.FilePath);
                await Task.Run(() =>
                {
                    using (fs)
                    using (var parser = new SectionParser(fs).EnableStatusUpdates())
                    using (var analyser = new SectionAnalyser(parser))
                    {
                        SectionStatus = parser.StatusObject;
                        _system._wordResults._result = analyser.Analyze(_cancellationTokenSource.Token);
                       
                    }
                });
            }
            ActiveProzess = false;

            if (_system._wordResults._result != null)
            {
                _navigationStore.CurrentViewModel = new ResultViewModel(_system, _navigationStore);
            }
            else
            {

            }
        }
    }
}
