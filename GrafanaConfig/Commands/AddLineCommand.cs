using GrafanaConfig.Models;
using System.Collections.ObjectModel;

namespace GrafanaConfig.Commands
{
    class AddLineCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            return parameter != null && parameter is ObservableCollection<ConfigLine>;
        }
        public override void Execute(object parameter)
        {
            if (parameter is ObservableCollection<ConfigLine> configs)
            {
                configs?.Add(new ConfigLine
                {
                    Name = "Vvedite",
                    Num = 1,
                    Status = 0,
                    Link = 0,
                    A = 0,
                    B = 0,
                    C = 0,
                    D = 0,
                    E = 0,
                    F = 0,
                    G = 0,
                    H = 0,
                    I = 0,
                    K = 0,
                });
            }
        }
    }
}
