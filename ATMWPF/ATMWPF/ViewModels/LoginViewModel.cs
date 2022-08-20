using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace ATMWPF.ViewModels
{
    public class LoginViewModel:Screen
    {
        public System.Action OpenGetMoneyView { get; set; }
        public System.Action OpenSaveMoneyView { get; set; }


        public void GetMoney()
        {
            OpenGetMoneyView();
        }

        public void SaveMoney()
        {
            OpenSaveMoneyView();
        }
    }
}
