using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonAudio : MonoBehaviour
{
  
    private static SingletonAudio _instance;
    public static SingletonAudio Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SingletonAudio>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
