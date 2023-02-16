using BinaryFile.VM.Commands;
using BinaryModel;
using BinaryModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;

//умещается 18 элементов
namespace BinaryFile.VM
{
#nullable disable
    internal class BinaryVM : ViewModelBase, IVMContract, IVMPositionContract
    {
        public BinaryVM()
        {
            Position = 0;
            Times = 100;
            Index = 0;
            Update += new FileManager(this).GetFile;
            UserInputPosition = "Введите номер строки";
        }
        public int Position { get; set; }
        public string FilePath { get; set; }

        private int _index;
        public int Index 
        { 
            get => _index;
            set
            { 
                _index = value; 
                if(BasicEntities != null)
                {
                    if(Index == 50)
                    {
                        Update(false);
                        OnPropertyChanged(nameof(Index));
                    }
                    if(Index == 49 && Position!=0)
                    {
                        Update(true);
                        OnPropertyChanged(nameof(Index));
                    }
                }
            } 
        }

        public string UserInputPosition { get; set; }

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

        #region COMMANDS    
        public ICommand GetFile => new GetFileCommand(this);
        public ICommand SetPosition => new SetPositionCommand(this);
        #endregion

        #region EVENTS
        public delegate void UpdateDelegate(bool position);
        public event UpdateDelegate Update;
        #endregion
    }
}
