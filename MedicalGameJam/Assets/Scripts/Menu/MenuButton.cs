using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MenuButton : MonoBehaviour
{
  public string sceneToSwapName;

    public void Play() {
        MenuManager.instance.SwapToScene(sceneToSwapName);
    }
    public void Return() {
        MenuManager.instance.Return();
    }

    public void SwapPage(MenuPage to) {
        MenuManager.instance.SwapUIMenu(to);
    }
}
