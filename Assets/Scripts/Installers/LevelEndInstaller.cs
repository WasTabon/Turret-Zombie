using UnityEngine;
using Zenject;

public class LevelEndInstaller : MonoInstaller
{
    [SerializeField] private LevelEndController _levelEndController;
    
    public override void InstallBindings()
    {
        Container.Bind<LevelEndController>().FromInstance(_levelEndController).AsSingle();
    }
}