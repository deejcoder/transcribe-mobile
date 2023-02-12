using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transcribe.ViewModels.Base;

namespace Transcribe.Controls.ViewModels
{

    public enum NavBarItemIndex
    {
        None,
        MySpace,
        Explore,
        Saved,
        Profile
    }

    public class NavBarItem : BaseViewModel
    {
        /// <summary>
        /// A unique identifer for the menu item - that cannot be changed
        /// </summary>
        public NavBarItemIndex Id { get; set; }

        private string _label;
        /// <summary>
        /// The visible label of the menu item
        /// </summary>
        public string Label
        {
            get => _label;
            set
            {
                if (_label != value)
                {
                    _label = value;
                    OnPropertyChanged(nameof(Label));
                }
            }
        }

        private string _icon;
        /// <summary>
        /// An image used for the menu item's icon
        /// </summary>
        public string Icon
        {
            get => _icon;
            set
            {
                if(_icon != value )
                {
                    _icon = value;
                    OnPropertyChanged(nameof(Icon));
                }
            }
        }

        private bool _isSelected;
        /// <summary>
        /// Selected state of the menu item
        /// </summary>
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }
    }
}
