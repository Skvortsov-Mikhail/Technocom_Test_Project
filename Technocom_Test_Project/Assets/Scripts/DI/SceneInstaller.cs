using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private ExampleSceneClass m_exampleSceneObject;

    public override void InstallBindings()
    {
        BindSmth();
    }

    private void BindSmth()
    {
        Container.
            Bind<ExampleSceneClass>().FromInstance(m_exampleSceneObject).AsSingle();
    }
}
