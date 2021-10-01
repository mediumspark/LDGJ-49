using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    /// <summary>
    /// This is only used where there is no detected controller
    /// </summary>
    public class BlankController : ICommand
    {
        public void Execute() { }
    }
}
