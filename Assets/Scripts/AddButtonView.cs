using System;
using System.Collections;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using Zenject;

public class AddButtonView : MonoBehaviour
{
    private readonly Subject<Unit> _subject = new Subject<Unit>();

    public IObservable<Unit> OnClick => _subject;

    [Inject] private RectTransform _bodyRectTransform;

    private void Start()
    {
        GetComponent<Button>()
            .OnClickAsObservable()
            .Subscribe(_ =>
            {
                _subject.OnNext(Unit.Default);
                StartCoroutine(nameof(PushButton));
            })
            .AddTo(gameObject);
    }

    /// <summary>
    /// ボタンの見た目を押下状態にする
    /// </summary>
    private IEnumerator PushButton()
    {
        _bodyRectTransform.localPosition = new Vector3(0, -1, 0);

        yield return new WaitForSeconds(0.1f);

        _bodyRectTransform.localPosition = new Vector3(0, 0, 0);
    }
}