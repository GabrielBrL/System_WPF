using Login_In_WPF_MVVM_C_Sharp_and_SQL_Server.Interface;
using Login_In_WPF_MVVM_C_Sharp_and_SQL_Server.Models;
using Login_In_WPF_MVVM_C_Sharp_and_SQL_Server.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Login_In_WPF_MVVM_C_Sharp_and_SQL_Server.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private IUserRepository _userRepository;
        public UserAccountModel CurrentUserAccount
        {
            get => _currentUserAccount; set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        public MainViewModel()
        {
            _userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = _userRepository.GetByName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName} ;)";
                CurrentUserAccount.ProfilePicture = null;
                return;
            }
            CurrentUserAccount.DisplayName = "Invalid user, not logged in";
        }
    }
}
