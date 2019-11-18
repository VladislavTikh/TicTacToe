using DAL;
using DAL.Commands;
using DAL.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using UltimateTicTacToe.Validators;
using Unity;

namespace UltimateTicTacToe.ViewModels
{
    public class RegisterVM : INotifyDataErrorInfo
    {
        private IUserService _service;
        private IValidator _validator;

        private readonly Dictionary<string, ICollection<string>>
        _validationErrors = new Dictionary<string, ICollection<string>>();

        public RegisterVM(IUserService service, IValidator validator)
        {
            _service = service;
            _validator = validator;
        }
        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                ValidateProperty(_login, "Login");
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

        private string _repeatPassword;
        public string RepeatPassword
        {
            get => _repeatPassword;

            set
            {
                _repeatPassword = value;
                ValidateProperty(_repeatPassword, "RepeatPassword");
            }
        }

        private RelayCommand _registerCommand;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public RelayCommand RegisterCommand
        {
            get
            {
                return _registerCommand ??
                  (_registerCommand = new RelayCommand(async obj =>
                  {
                      var newUser = new UserDTO
                      {
                          Login = Login,
                          Password = Password,
                          RepeatPassword = RepeatPassword
                      };
                      var user = await _service.CreateUserAsync(newUser);
                      if (user != null)
                      {
                          App.Container.RegisterInstance(user);
                          var mainForm = new MainWindow();
                          mainForm.Show();
                          (obj as Registration).Close();
                      }
                      else
                      {
                          if (await _service.GetExistingUser(newUser) != null)
                          {
                              _validationErrors.Add("RepeatPassword", new List<string> { "Such user already exist" });
                          }
                          else
                          {
                              _validationErrors.Add("RepeatPassword", new List<string> { "Repeat password differs" });
                          }
                          RaiseErrorsChanged("RepeatPassword");
                      }
                  },
                  new Func<object, bool>(x =>
                  {
                      return !HasErrors&&(!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(RepeatPassword));
                  })));
            }
        }

        private void RaiseErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            try
            {
                if (string.IsNullOrEmpty(propertyName)
                    || !_validationErrors.ContainsKey(propertyName))
                    return null;
            }
            catch { }
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
                return _validator.Validate(propertyValue, propertyName, out validationErrors);
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
