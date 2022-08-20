using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ATMWPF.Models;

namespace ATMWPF.ViewModels
{
    public class PasswordViewModel:Screen
    {
        public PasswordViewModel(PersonModel selectPerson)
        {
            _selectPerson = selectPerson;
            InitialForm();
        }

        public void InitialForm()
        {
            _errorTimes = _selectPerson.ErrorTimes;

            if (_errorTimes < 3)
            {
                Message = $"Hi {_selectPerson.UserName} 請輸入密碼";
            }
            else
            {
                Message = $"Sorry 您已被鎖卡";
                ComparePassword_Enable = false;
            }
        }

        #region 委派事件
        public System.Action CarisLocked { get; set; }
        public System.Action OpenLoginView { get; set; }
        #endregion

        private PersonModel _selectPerson;

        private int _errorTimes; //錯誤次數
        public int ErrorTimes
        {
            get { return _errorTimes; }
            set
            {
                _errorTimes = value;
                NotifyOfPropertyChange(() => ErrorTimes);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }

            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        private string _message; //顯示訊息
        public string Message
        {
            get { return _message; }
            set 
            { 
                _message = value;
                NotifyOfPropertyChange(() => Message);

            }
        }

        private bool _comparePassword_enable = true;//鎖住button

        public bool ComparePassword_Enable
        {
            get { return _comparePassword_enable; }
            set
            {
                _comparePassword_enable = value;
                NotifyOfPropertyChange(() => ComparePassword_Enable);
            }
        }


        public void ComparePassword()
        {
            if (Password == _selectPerson.UserPassword)
            {
                Message = "密碼正確";
                OpenLoginView();
            }
            else
            {
                ErrorTimes++;
                _selectPerson.ErrorTimes = ErrorTimes;

                if (ErrorTimes < 3)
                {
                    ComparePassword_Enable = true;
                    Message = $"密碼錯誤您還有{3- ErrorTimes}次機會";
                    return;
                }
                Message = "您已被鎖卡 請聯繫客服 卡片退出";
                CarisLocked();
                ComparePassword_Enable = false;
            }    
        }
    }
}
