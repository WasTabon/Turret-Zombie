using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private LevelStartController _levelStartController;
    
    public override void InstallBindings()
    {
        Container.Bind<LevelStartController>().FromInstance(_levelStartController).AsSingle();
    }
}