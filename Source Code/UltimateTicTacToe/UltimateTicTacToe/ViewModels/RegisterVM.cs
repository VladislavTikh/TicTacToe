using DAL;
using DAL.Commands;
using DAL.Service;

namespace UltimateTicTacToe.ViewModels
{
    public class RegisterVM
    {
        private IUserService _service;
        public RegisterVM(IUserService service)
        {
            _service = service;
        }
        public string Login { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }

        private RelayCommand _registerCommand;
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
                      if (await _service.CreateUserAsync(newUser) == true)
                      {
                          var mainForm = new MainWindow();
                          mainForm.Show();
                          (obj as Registration).Close();
                      }
                  }));
            }
        }

    }    
}
