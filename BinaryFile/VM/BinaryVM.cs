using BinaryFile.VM.Commands;
using BinaryModel;
using System.Windows;
using System.Windows.Input;

namespace BinaryFile.VM
{
#nullable disable
    internal class BinaryVM : ViewModelBase, IVMContract
    {
        public BinaryVM()
        {
            Position = 0;
        }
        public int Position { get; set; }

        private string _middleSource;
        public string MiddleSource
        {
            get => _middleSource;
            set
            {
                _middleSource = value;
                OnPropertyChanged(nameof(MiddleSource));
            }
        }

        public string _topSource;
        public string TopSource
        {
            get => _topSource;
            set
            {
                _topSource = value;
                OnPropertyChanged(nameof(TopSource));
            }

        }

        private string _bottomSource;

        public string BottomSource
        {
            get => _bottomSource;
            set
            {
                _bottomSource = value;
                OnPropertyChanged(nameof(BottomSource));
            }
        }

        private string _source;
        public string Source 
        { 
            get => _source; 
            set
            {
                _source = value;
                OnPropertyChanged(nameof(Source));
            } 
        }

        #region COMMANDS    
        public ICommand GetFile => new GetFileCommand(this);

        #endregion
    }
}
