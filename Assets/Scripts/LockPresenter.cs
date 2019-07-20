using UniRx;

public class LockPresenter
{
    private PadlockModel _padlockModel;
    private LockView _lockView;
    
    private LockPresenter(PadlockModel padlockModel, LockView lockView)
    {
        _padlockModel = padlockModel;
        _lockView = lockView;

        SetSubscribe();
    }

    private void SetSubscribe()
    {
        _padlockModel.IsCleared
            .DistinctUntilChanged()
            .Where(x => x)
            .Subscribe(x => _lockView.ChangeUnlock());
    }
}