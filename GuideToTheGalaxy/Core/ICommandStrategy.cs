using GuideToTheGalaxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Core
{
    public interface ICommandStrategy
    {
        bool CanExecute(string content);
        GuideResponse Execute(string content);
    }
}
