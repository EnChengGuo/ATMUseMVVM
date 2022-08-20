using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ATMWPF.Models;
namespace ATMWPF.ViewModels
{
    public class GetMoneyViewModel : Screen
    {
        public System.Action<string> OpenTmpView;
        public GetMoneyViewModel(PersonModel selectPerson)
        {
            _selectPerson = selectPerson;
        }

        private PersonModel _selectPerson;
        public bool MoneyEnough(int money)
        {
            if (_selectPerson.Money < money)
            {
                OpenTmpView("餘額不足");
                return false;
            }

            return true;
        }

        public void GetMoney(int money)
        {
            _selectPerson.Money -= money;
            OpenTmpView($"餘額: {_selectPerson.Money} 元");

        }

        #region 快速鍵
        public void Fast1000()
        {
            if (MoneyEnough(1000))
            {
                GetMoney(1000);
            }

        }

        public void Fast3000()
        {
            if (MoneyEnough(3000))
            {
                GetMoney(3000);
            }
        }

        public void Fast5000()
        {
            if (MoneyEnough(5000))
            {
                GetMoney(5000);
            }
        }

        public void Fast20000()
        {
            if (MoneyEnough(20000))
            {
                GetMoney(20000);
            }
        }
        #endregion

        #region 手動輸入金額
        private string _keySelfMoney;
        public string KeySelfMoney
        {
            get { return _keySelfMoney; }
            set
            {
                _keySelfMoney = value;
            }
        }

        public void GetSelfMoney()
        {
            int SelfMoney;
            int.TryParse(KeySelfMoney, out SelfMoney);

            if (MoneyEnough(SelfMoney))
            {
                GetMoney(SelfMoney);
            }
        }

        #endregion
    }
}
