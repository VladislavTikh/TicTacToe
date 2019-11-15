using DAL;
using DAL.Context;
using DAL.IService;
using DAL.Models;
using DAL.Service;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using System.Windows;
using UltimateTicTacToe.Validators;
using UltimateTicTacToe.ViewModels;
using Unity;
using Unity.Injection;

namespace UltimateTicTacToe
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnityContainer Container { get; } = new UnityContainer().AddExtension(new Diagnostic());
        protected override void OnStartup(StartupEventArgs e)
        {
            
            Container.RegisterType(typeof(User));   
            Container.RegisterType(typeof(UserDbContext));
            Container.RegisterType<IOwinContext, DAL.Context.AppContext>();
            Container.RegisterType<IUserStore<User>,Microsoft.AspNet.Identity.EntityFramework.UserStore<User>>();
            Container.RegisterType<Microsoft.AspNet.Identity.EntityFramework.UserStore<User>>(new InjectionConstructor(new UserDbContext()));
            Container.RegisterType(typeof(UserManager));     
            Container.RegisterType<IUserService, UserService>();
            Container.RegisterType<IGameService, GameService>();
            Container.RegisterType<IValidator, AuthorizationValidator>();
            Container.RegisterType(typeof(RegisterVM));
            Container.RegisterType(typeof(LoginVM));
            Container.RegisterType(typeof(MainWindowVM));
            Container.RegisterType(typeof(PageVM));
            Container.RegisterType(typeof(RulesPageVM));
            Container.RegisterType(typeof(GamePageVM));
            Container.RegisterInstance(typeof(IUnityContainer), Container);
            Login loginWindow = Container.Resolve<Login>();
            Registration registerWindow = Container.Resolve<Registration>();
            MainWindow mainWindow = Container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
