using UnityEngine;
using Zenject;

public class BulletSpawnerInstaller : MonoInstaller
{
    [SerializeField] private BooletSpawner _booletSpawner;
    
    public override void InstallBindings()
    {
        Container.Bind<BooletSpawner>().FromInstance(_booletSpawner).AsSingle();
    }
}