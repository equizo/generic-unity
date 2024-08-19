using UnityEngine;
using configuration;
using device;
using infrastructure.services.dependent;
using infrastructure.states.implementations;
using static facades.StaticsFacade;

namespace infrastructure
{
  public class GameBootstrapper : MonoBehaviour
  {
    private Game _game;

    private void Awake()
    {
      InitStaticData();
      InitPlatformType();
      SetFramerate();
      InitGame();
      EnterBootstrapperState();
      DontDestroyOnLoad(this);
    }

    private void InitStaticData() =>
      StaticData.Init();

    private void InitPlatformType()
    {
      var platformTypes = PlatformTypeChecker.SetPlatformType();
      PlatformDependentServices.Init(platformTypes);
    }

    private static void SetFramerate() =>
      Application.targetFrameRate = StaticConfiguration.Screen.Fps;

    private void InitGame() =>
      _game = new Game();

    private void EnterBootstrapperState() =>
      _game.StateMachine.Enter<BootstrapState>();

    private void Update() =>
      _game.Update(Time.deltaTime);

    // ICoroutineRunner code sample
    
    // public void StopAll() =>
    //   StopAllCoroutines();

    // public void SkipFramesAndInvoke(Action action, int frames = 1)
    // {
    //   StartCoroutine(SkipFramesAndInvokeCoroutine());
    //   IEnumerator SkipFramesAndInvokeCoroutine()
    //   {
    //     for (int i = 0; i < frames; i++)
    //     {
    //       yield return null;
    //     }
    //     action.Invoke();
    //   }
    // }
  }
}