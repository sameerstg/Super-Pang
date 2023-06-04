using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public float time = 0.7f;
    private void Awake()
    {
        Time.timeScale = time;
    }
   
}
