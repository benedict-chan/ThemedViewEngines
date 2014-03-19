using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemedViewEngines
{
    public interface IThemeSelectorService
    {
        string GetThemeName();
        void SetThemeName(string themeName);
    }
}
