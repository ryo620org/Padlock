using UniRx;

public class DialPresenter
{
    private int _dialIndex;

    private AddButtonView _addButtonView;
    private NumberView _numberView;
    private PadlockModel _padlockModel;

    public DialPresenter(AddButtonView addButtonView, NumberView numberView, PadlockModel padlockModel, int dialIndex)
    {
        _addButtonView = addButtonView;
        _numberView = numberView;
        _padlockModel = padlockModel;
        _dialIndex = dialIndex;

        InitView();

        SetSubscribe();
    }

    /// <summary>
    /// Viewの初期化
    /// </summary>
    private void InitView()
    {
        _numberView.ChangeNumber((int) _padlockModel.DialNumberList[_dialIndex]);
    }

    private void SetSubscribe()
    {
        _addButtonView.OnClick
            .Subscribe(index => { _padlockModel.CountUpDial(_dialIndex); });

        _padlockModel.DialNumberList
            .ObserveReplace()
            .Where(x => x.Index == _dialIndex)
            .Subscribe(x => { _numberView.ChangeNumber((int) x.NewValue); });
    }
}