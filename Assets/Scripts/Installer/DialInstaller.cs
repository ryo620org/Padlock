using UnityEngine;
using Zenject;

public class DialInstaller : MonoInstaller
{
    [SerializeField] private int dialIndex;
    
    public override void InstallBindings()
    {
        // ここでDialPresenterクラスを 生成する
        // DialPresenterクラスは依存の頂点（他から参照されていない）ので
        // NonLazy で明示的に生成タイミングを指定する必要がある
        Container
            .Bind<DialPresenter>()
            .AsSingle()
            .NonLazy();

        // もちろん int型もバインドできる
        // インスタンスはインスペクターで指定
        Container
            .Bind<int>()
            .FromInstance(dialIndex);
    }
}