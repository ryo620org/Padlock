using Zenject;

public class PadlockInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // PadlockModelを生成してバインドする
        Container.Bind<PadlockModel>().AsSingle();

        // LockPresenterを生成してバインドする
        // DialPresenterと同様に、 NonLazyで明示的に生成タイミングを指定している
        Container.Bind<LockPresenter>().AsSingle().NonLazy();
    }
}