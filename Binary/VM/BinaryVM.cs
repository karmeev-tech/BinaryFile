using Binary.VM.Commands;
using Binary.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Windows;
using System.Windows.Input;

namespace Binary.VM
{
#nullable disable
    internal class BinaryVM : ViewModelBase, IVMContract
    {
        public BinaryVM()
        {
            Position = 0;
            Height = 0;
            Times = 100;
        }
        public int Position { get; set; }
        public string FilePath { get; set; }

        private int height;
        public int Height 
        { 
            get => height;
            set
            { 
                height = value; 
                OnPropertyChanged(nameof(Height));
            } 
        }

        private List<BasicEntity> _basicEntities;

        public List<BasicEntity> BasicEntities
        {
            get => _basicEntities;
            set
            {
                _basicEntities = value;
                OnPropertyChanged(nameof(BasicEntities));
            }
        }
        public int Times { get; set; }

        public delegate void UdpateDelegate();
        public event UdpateDelegate Update;

        #region COMMANDS    
        public ICommand GetFile => new GetFileCommand(this);

        #endregion
        public void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            new FileManager(this).GetFile();
            BasicEntities.RemoveRange(Position-Times,Times);
        }
        public int PositionInList { get; set; }

    }
}
