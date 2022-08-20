using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ATMWPF.Models;
namespace ATMWPF.ViewModels
{
    public class ATMViewModel : Conductor<object>
    {
        public ATMViewModel()
        {
            LoadWaitingForm();
            Clients.Add(new PersonModel { UserName = "Tim", UserPassword = "305260",Money=100000 });
            Clients.Add(new PersonModel { UserName = "Zoy", UserPassword = "260053",Money = 1000 });
            Clients.Add(new PersonModel { UserName = "Ian", UserPassword = "302847", Money = 5000 });
        }

        private string _clientName="";
        public string ClientName
        {
            get { return _clientName; }
            set 
            {
                _clientName = value;
            }
        }

        private string _clientPassword = "";
        public string ClientPassword
        {
            get { return _clientPassword; }
            set
            {
                _clientPassword = value;
            }
        }

        //客戶資料
        private BindableCollection<PersonModel> _clients = new BindableCollection<PersonModel>();

        public BindableCollection<PersonModel> Clients
        {
            get { return _clients; }
            set { _clients = value; }
        }

        private PersonModel _selectPerson = new PersonModel();
        public PersonModel SelectPerson
        {
            get { return _selectPerson; }

            set { _selectPerson = value; }
        }

        #region 模擬插卡
        public void InsetTimCard()
        {
            
            SelectPerson = SearchClient("Tim");

            if (SelectPerson.ErrorTimes >= 3)
            {
                LoadTmpView("Sorry 您已被鎖卡 卡片退出");
                CarNotInside = false;
                return;
            }

            if (SelectPerson.UserName != "none")
            {
                LoadPasswordView();
                CarNotInside = false;
            }
        }

        public void InsetZoyCard()
        {

            SelectPerson = SearchClient("Zoy");

            if (SelectPerson.UserName != "none")
            {
                LoadPasswordView();
                CarNotInside = false;

            }
        }

        public void InsetIanCard()
        {

            SelectPerson = SearchClient("Ian");

            if (SelectPerson.UserName != "none")
            {
                LoadPasswordView();
                CarNotInside = false;
            }
        }

        public PersonModel SearchClient(string clientName)
        {
            for (int i = 0; i < Clients.LongCount(); i++)
            {
                if (clientName == Clients[i].UserName)
                {
                    return Clients[i];
                }
            }

            return new PersonModel { UserName = "none" };
        }

        private bool _carNotInside = true;

        public bool CarNotInside
        {
            get { return _carNotInside; }
            set
            {
                _carNotInside = value;
                NotifyOfPropertyChange(() => CarNotInside);
            }
        }

        public void CarisLocked()
        {
            CarNotInside = true;
        }
        #endregion

        #region 視窗切換
        public void LoadWaitingForm()
        {
            ActivateItemAsync(new WaitingViewModel());        
        }

        public void LoadPasswordView()
        {
            PasswordViewModel _passwordViewModel = new PasswordViewModel(SelectPerson)
            {
                OpenLoginView = new System.Action (LoadLoginView),
                CarisLocked=new System.Action(CarisLocked)
            };

            ActivateItemAsync(_passwordViewModel);
            
        }

        public void LoadLoginView()
        {
            LoginViewModel _loginViewModel = new LoginViewModel()
            {
                OpenGetMoneyView = new System.Action(LoadGetMoneyView),
                OpenSaveMoneyView = new System.Action(LoadSaveMoneyView)
            };
            ActivateItemAsync(_loginViewModel);
        }

        public void LoadGetMoneyView()
        {
            GetMoneyViewModel _getMoneyViewModel = new GetMoneyViewModel(_selectPerson)
            {
                OpenTmpView= new System.Action<string>(LoadTmpView)
            };

            ActivateItemAsync(_getMoneyViewModel);


        }

        public void LoadSaveMoneyView()
        {
            SaveMoneyViewModel _saveMoneyViewModel = new SaveMoneyViewModel(_selectPerson)
            {
                OpenTmpView = new System.Action<string>(LoadTmpView)
            };
            ActivateItemAsync(_saveMoneyViewModel);

        }

        public void LoadTmpView(string message)
        {
            TmpViewModel _tmpViewModel = new TmpViewModel(message)
            {
                OpenWaitingView = new System.Action(LoadWaitingForm),
                CarisLocked = new System.Action(CarisLocked)
            };

            ActivateItemAsync(_tmpViewModel);
        }
        #endregion

    }
}
