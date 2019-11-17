using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
  public static GameManager instance = null;
  public enum GameState { NullState, MainMenu, Game }
  public delegate void OnStateChangeHandler();
  public event OnStateChangeHandler OnStateChange;
  public GameState gameState { get; private set; }
  // Start is called before the first frame update

  private void Awake() {
    SetStaticInstance();

  }
  void Start() {

  }

  private void SetStaticInstance() {
    if (instance == null) {
      instance = this;
      DontDestroyOnLoad(instance);
    }
    else
      Destroy(this);
    Debug.Log("There are multiple GameManager instances");
  }

  public void SetGameState(GameState gameState) {
    this.gameState = gameState;
    if (OnStateChange != null) {
      OnStateChange();
    }
  }

  public void LoadGame(string gameSceneName) {
    SceneManager.LoadScene(gameSceneName);
  }
  
    


  public void Quit() {
    Application.Quit();
  }
}
