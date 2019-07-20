using UniRx;
using Zenject;

public class PadlockModel
{
    public ReactiveCollection<DialNumber> DialNumberList { get; } = new ReactiveCollection<DialNumber>();

    public ReactiveProperty<bool> IsCleared { get; } = new ReactiveProperty<bool>(false);

    private readonly PadlockNumber _padlockKeyNumber;
    private readonly PadlockNumber _padlockInitNumber;

    public PadlockModel(
        [Inject(Id = "KeyNumber")] PadlockNumber padlockKeyNumber,
        [Inject(Id = "InitNumber")] PadlockNumber padlockInitNumber)
    {
        _padlockKeyNumber = padlockKeyNumber;
        _padlockInitNumber = padlockInitNumber;

        InitDialNumberList();
    }

    /// <summary>
    /// ダイヤルの初期値を設定する
    /// </summary>
    private void InitDialNumberList()
    {
        for (var i = 0; i < _padlockInitNumber.dialNumberList.Count; i++)
        {
            DialNumberList.Add(_padlockInitNumber.dialNumberList[i]);
        }
    }

    /// <summary>
    /// ダイヤルをカウントアップする
    /// </summary>
    /// <param name="dialIndex"></param>
    public void CountUpDial(int dialIndex)
    {
        if (IsCleared.Value) return;

        if ((int) DialNumberList[dialIndex] < 9)
            DialNumberList[dialIndex] = DialNumberList[dialIndex] + 1;
        else
            DialNumberList[dialIndex] = 0;

        if (GetIsCleared())
            IsCleared.Value = true;
    }

    /// <summary>
    /// クリア状態かどうかを返す
    /// </summary>
    private bool GetIsCleared()
    {
        for (var i = 0; i < _padlockKeyNumber.dialNumberList.Count; i++)
        {
            if (DialNumberList[i] != _padlockKeyNumber.dialNumberList[i])
                return false;
        }

        return true;
    }
}