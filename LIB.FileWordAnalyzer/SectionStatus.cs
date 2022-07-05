using AP.WordParser.Lib.Annotations;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LIB.FileWordAnalyzer
{
    public class SectionStatus : INotifyPropertyChanged, ISectionStatus
    {
        private long _currentPosition;
        private long _totalLength = 1;

        public long CurrentPosition
        {
            get => _currentPosition;
            set
            {
                if (value == _currentPosition)
                {
                    return;
                }

                _currentPosition = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Progress));
            }
        }
        public long TotalLength
        {
            get => _totalLength;
            set
            {
                if (value == _totalLength)
                {
                    return;
                }

                _totalLength = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Progress));
            }
        }
        public decimal Progress => TotalLength != 0 ? (CurrentPosition * 100 / TotalLength) : 0;

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}