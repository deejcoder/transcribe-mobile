using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transcribe.Controls.ViewModels
{

    public enum NavBarItemIndex
    {
        None,
        Me,
        Explore,
        Favourites,
        Profile
    }

    public class NavBarItem
    {
        public NavBarItemIndex Id { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }
        public bool IsSelected { get; set; }
    }
}
