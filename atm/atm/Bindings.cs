using atm;
using Ninject.Modules;

public class Bindings : NinjectModule
{
    public override void Load()
    {
        Bind<IDBConnection>().To<DBConnection>();
        Bind<IInputValidator>().To<InputValidator>();
        Bind<IUserInput>().To<UserInput>();
    }
}