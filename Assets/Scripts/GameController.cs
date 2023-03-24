using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [field: SerializeField]
    public float AwaySeconds { get; private set; }

    private DateTime _LastPlayedTime { get; set; }

    void Awake()
    {
#if UNITY_EDITOR
        Debug.Log(gameObject.name + ": Awake");
#endif

        Instance = this;

        DateTime timeNow = DateTime.Now;

        if (PlayerPrefs.HasKey("savedTime"))
        {
            string timeAsString = PlayerPrefs.GetString("savedTime");
            _LastPlayedTime = DateTime.Parse(timeAsString);

            Debug.Log("LastPlayedTime: " + _LastPlayedTime);

            TimeSpan awayTime = timeNow - _LastPlayedTime;

            AwaySeconds = (float) awayTime.TotalSeconds;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationPause()
    {
#if UNITY_EDITOR
        Debug.Log(gameObject.name + ": OnApplicationPause");
#endif

        SaveData();
    }

    void OnApplicationQuit()
    {
#if UNITY_EDITOR
        Debug.Log(gameObject.name + ": OnApplicationQuit");
#endif

        SaveData();
    }

    private void SaveData()
    {
        DateTime savedTime = DateTime.Now;

#if UNITY_EDITOR
        Debug.Log("savedTime: " + savedTime);
#endif

        PlayerPrefs.SetString("savedTime", savedTime.ToString());
    }
}
