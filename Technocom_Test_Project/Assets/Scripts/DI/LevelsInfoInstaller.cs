using UnityEngine;
using Zenject;

public class LevelsInfoInstaller : MonoInstaller
{
    [SerializeField] private LevelsInfo m_levelsInfo;

    public override void InstallBindings()
    {
        BindLevelsInfo();
    }

    private void BindLevelsInfo()
    {
        Container.
            Bind<LevelsInfo>().FromInstance(m_levelsInfo).AsSingle();
    }
}
