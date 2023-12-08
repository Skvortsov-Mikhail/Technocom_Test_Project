using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private TicketsController m_ticketsController;

    public override void InstallBindings()
    {
        Container.
            Bind<TicketsController>()
            .FromComponentInNewPrefab(m_ticketsController)
            .AsSingle();
    }
}