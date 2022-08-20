using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace ATMWPF.ViewModels
{
    public class TmpViewModel:Screen
    {
        public System.Action OpenWaitingView { get; set; }
        public System.Action CarisLocked { get; set; }

        public TmpViewModel(string message)
        {
            _tmpMesssage = message;
        }

        private string _tmpMesssage;

        public string TmpMessage
        {
            get { return _tmpMesssage; }
            set 
            {
                _tmpMesssage = value;
            }
        }

        public void CheckClick()
        {
            CarisLocked();
            OpenWaitingView();       
        }
    }
}
