using BinaryModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BinaryFile.VM.Commands
{
    internal class SetPositionCommand : BaseCommands
    {
        private IVMPositionContract _VM;

        public SetPositionCommand(IVMPositionContract vm)
        {
            _VM = vm;
        }

        public override void Execute(object parameter)
        {
            try
            {
                Convert.ToInt32(_VM.UserInputPosition);
                if (_VM.FilePath == null)
                {
                    MessageBox.Show("Загрузите файл");
                }
                else
                {
                    _VM.Position = Convert.ToInt32(_VM.UserInputPosition);
                    _VM.Index = Convert.ToInt32(50);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректный ввод");
            }
        }
    }
}
