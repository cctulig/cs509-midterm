using Ninject.Modules;

namespace atm;

public class Bindings : NinjectModule
{
    public override void Load()
    {
        Bind<IDBConnection>().To<DBConnection>().InSingletonScope();
        Bind<IInputValidator>().To<InputValidator>();
        Bind<IUserInput>().To<UserInput>();
        Bind<IDate>().To<Date>();
    }
}