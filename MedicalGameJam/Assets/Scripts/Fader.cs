using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {
  Animator animator;  

  void Start() {
    animator = GetComponent<Animator>();
  }

  public void FadeOut(){
    animator.SetTrigger("FadeOut");
  }
}
