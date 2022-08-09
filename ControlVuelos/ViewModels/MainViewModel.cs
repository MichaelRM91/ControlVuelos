using ControlVuelos.Core;
using ControlVuelos.Models;
using ControlVuelos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlVuelos.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private IUserRepository _userRepository;

        public UserAccountModel CurrentUserAccount 
        { 
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                RaisePropertyChanged(nameof(CurrentUserAccount));
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
            var user = _userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName} ";               
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                
            }
        }
    }
}
