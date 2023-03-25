using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public GameObject[] windows;
    public Vector2 dayHourRange;

    public GameObject[] preloads;

    public GameObject quitPanel;

    //
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

        Debug.Log(timeNow.Hour);

        if (PlayerPrefs.HasKey("savedTime"))
        {
            string timeAsString = PlayerPrefs.GetString("savedTime");
            _LastPlayedTime = DateTime.Parse(timeAsString);

            Debug.Log("LastPlayedTime: " + _LastPlayedTime);

            TimeSpan awayTime = timeNow - _LastPlayedTime;

            AwaySeconds = (float) awayTime.TotalSeconds;
        }

        // Spawn Window
        if (timeNow.Hour >= dayHourRange.x && timeNow.Hour < dayHourRange.y)
        {
            Instantiate(windows[0]);
        }
        else
        {
            Instantiate(windows[1]);
        }

        // Enable Preloads
        foreach (GameObject item in preloads)
        {
            item.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            quitPanel.SetActive(true);
        }
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

    public void QuitButton()
    {
        Application.Quit();
    }
}
