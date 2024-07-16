using Bootstrapper.Data;
using UnityEngine;

namespace Bootstrapper.StateMachine
{
  public abstract class GameSystem : MonoBehaviour
  {
    protected GameData gameData;
    protected PlayerData playerData;
    protected GameBlueprint blueprint;

    public GameBlueprint GetBlueprint => blueprint;
    public PlayerData GetPlayerDate => playerData;
    public GameData GetGameData => gameData;

    public void InjectData(PlayerData playerData, GameData gameData, GameBlueprint blueprint)
    {
      this.playerData = playerData;
      this.gameData = gameData;
      this.blueprint = blueprint;
    }

    public void ToTutorial()
    {
      HyperBootstrapper.Instance.ChangeState(GameStateID.Tutorial);
    }

    public void ToGame()
    {
      HyperBootstrapper.Instance.ChangeState(GameStateID.Game);
    }

    public void ToResult()
    {
      HyperBootstrapper.Instance.ChangeState(GameStateID.Result);
    }

    public void ToMenu()
    {
      HyperBootstrapper.Instance.ChangeState(GameStateID.Menu);
    }

    internal virtual void Init()
    {
    }

    internal virtual void EnterState()
    {
    }

    internal virtual void Loop()
    {
    }

    internal virtual void LateLoop()
    {
    }

    internal virtual void PhysicsLoop()
    {
    }

    internal virtual void ExitState()
    {
    }

    internal virtual void EndGame()
    {
    }
  }
}