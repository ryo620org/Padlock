using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public enum DialNumber
{
    Num0,
    Num1,
    Num2,
    Num3,
    Num4,
    Num5,
    Num6,
    Num7,
    Num8,
    Num9
}

[Serializable]
public class PadlockNumber
{
    public List<DialNumber> dialNumberList;
}

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Padlock/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public PadlockNumber padLockKeyNumber;
    public PadlockNumber padLockInitNumber;

    public override void InstallBindings()
    {
        // PadlockNumberのインスタンス、 padLockKeyNumber を、Id = "KeyNumber" と指定された場合にバインドする
        Container.BindInstance(padLockKeyNumber).WithId("KeyNumber").IfNotBound();

        // PadlockNumberのインスタンス、 padLockInitNumber を、Id = "InitNumber" と指定された場合にバインドする
        Container.BindInstance(padLockInitNumber).WithId("InitNumber").IfNotBound();
    }
}