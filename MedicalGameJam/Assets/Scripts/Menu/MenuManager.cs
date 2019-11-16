﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
  public static MenuManager instance;
  public GameObject startingMenuPage;
  public Fader Fader;
  private MenuPage currentlyActiveMenuPage;

  void Start() {
    SetStaticInstance();
    currentlyActiveMenuPage = startingMenuPage.GetComponent<MenuPage>();
  }

  private void SetStaticInstance() {
    if (instance == null) {
      instance = this;
    }
    else
      Debug.Log("There are multiple MenuManager instances");
  }

  // Affiche la page demandée
  public void SwapUIMenu(MenuPage to) {
    if (!to.isOverlay)
      RemoveMenuPage(currentlyActiveMenuPage);
    DisplayMenuPage(to);
    currentlyActiveMenuPage = to;
  }

  // Retourne sur la page précédente
  public void Return() {
    if (currentlyActiveMenuPage.isOverlay) {
      RemoveMenuPage(currentlyActiveMenuPage);
      currentlyActiveMenuPage = currentlyActiveMenuPage.returnMenu;
    }
    else if (currentlyActiveMenuPage.returnMenu != null) {
      SwapUIMenu(currentlyActiveMenuPage.returnMenu);
    }
  }

  private void RemoveMenuPage(MenuPage page) {
    page.gameObject.SetActive(false);
  }

  private void DisplayMenuPage(MenuPage page) {
    page.gameObject.SetActive(true);
  }
  // Lance le jeu en changeant de scène
  public void SwapToScene(string gameSceneName) {
    Fader.FadeOut();
    GameManager.instance.LoadGame(gameSceneName);
  }

}
