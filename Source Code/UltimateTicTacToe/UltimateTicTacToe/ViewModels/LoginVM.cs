using DAL;
using DAL.Commands;
using DAL.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using UltimateTicTacToe.Validators;

namespace UltimateTicTacToe.ViewModels
{
    public class LoginVM:INotifyDataErrorInfo
    {
        public LoginVM(IUserService service, IValidator validator)
        {
            _service = service;
            _validator = validator;
        }

        private IValidator _validator;
        private IUserService _service;

        private readonly Dictionary<string, ICollection<string>>
        _validationErrors = new Dictionary<string, ICollection<string>>();

        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                ValidateProperty(_login,"Login");
            }
        }

        private string _password;
        public string Password
        {
            get => _password;

            set
            {
                _password = value;
                ValidateProperty(_password, "Password");
            }
        }

        private RelayCommand _loginCommand;       

        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ??
                  (_loginCommand = new RelayCommand(async obj =>
                  {
                      var userDTO = new UserDTO
                      {
                          Login = Login,
                          Password = Password,
                          RepeatPassword = null
                      };
                      if (await _service.IsUserExistAsync(userDTO))
                      {
                          var mainWindow = new MainWindow();
                          mainWindow.Show();
                          (obj as Login).Close();
                      }
                      else
                      {
                          _validationErrors.Add("Password", new List<string> { "No such user in database" });
                          RaiseErrorsChanged("Password");
                      }
                  },
                  new Func<object,bool>(x=>
                  {
                      return !HasErrors;
                  })));
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void RaiseErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)
                || !_validationErrors.ContainsKey(propertyName))
                return null;

            return _validationErrors[propertyName];
        }

        public bool HasErrors
        {
            get { return _validationErrors.Count > 0; }
        }

        public async void ValidateProperty(string propertyValue, string propertyName)
        {
            ICollection<string> validationErrors = null;
            /* Call service asynchronously */
            bool isValid = await Task<bool>.Run(() =>
            {
                return _validator.Validate(propertyValue,propertyName, out validationErrors);
            })
            .ConfigureAwait(false);

            if (!isValid)
            {
                /* Update the collection in the dictionary returned by the GetErrors method */
                _validationErrors[propertyName] = validationErrors;
                /* Raise event to tell WPF to execute the GetErrors method */
                RaiseErrorsChanged(propertyName);
            }
            else if (_validationErrors.ContainsKey(propertyName))
            {
                /* Remove all errors for this property */
                _validationErrors.Remove(propertyName);
                /* Raise event to tell WPF to execute the GetErrors method */
                RaiseErrorsChanged(propertyName);
            }
        }

    }
}