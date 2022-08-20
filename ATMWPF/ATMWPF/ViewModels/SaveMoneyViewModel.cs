using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ATMWPF.Models;
namespace ATMWPF.ViewModels
{
    class SaveMoneyViewModel:Screen
    {
        #region 委派事件
        public System.Action<string> OpenTmpView;
        #endregion

        private PersonModel _selectPerson;

        public SaveMoneyViewModel(PersonModel selectPerson)
        {
            _selectPerson = selectPerson;
        }

        private string _money;
        public string Money
        {
            get { return _money; }
            set 
            {
                _money = value;
            }
        }

        public void Save()
        {
            int money;
            int.TryParse(Money, out money);
            _selectPerson.Money += money;

            OpenTmpView($"餘額: {_selectPerson.Money} 元");
        }


    }
}
