using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public float maxHealth;
    public float healthDropRate;

    public float healthFromPetting;
    [Range(0f, 1f)]
    public float angryFromPetting;

    public float angryHealthDrop;

    public Vector2 angryPettingSeconds;

    public float maxHunger;
    public float hungerRate;

    [Range(0f, 1f)]
    public float eatThreshold;

    [field: SerializeField]
    public float EatDuration { get; private set; }

    [field: SerializeField]
    public Vector2 EatDurationRange { get; private set; }

    [field: SerializeField]
    public float CurrentHealth { get; private set; }

    [field: SerializeField]
    public float CurrentHunger { get; private set; }

    private float loadedHealth;
    private float loadedHunger;
    private bool isDataLoaded;

    // HideInInspector
    [HideInInspector]
    public Draggable draggable;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        Debug.Log(gameObject.name + ": Start");
#endif

        draggable = GetComponent<Draggable>();

        loadedHealth = PlayerPrefs.GetFloat("Health", maxHealth);
        float awayHealthDecrease = (GameController.Instance.AwaySeconds * healthDropRate);
        float initHealth = loadedHealth - awayHealthDecrease;
        UpdateHealth(initHealth);

        loadedHunger = PlayerPrefs.GetFloat("Hunger", maxHunger);
        float awayHungerDecrease = (GameController.Instance.AwaySeconds * hungerRate);
        float initHunger = loadedHunger - awayHungerDecrease;
        UpdateHunger(initHunger);

        isDataLoaded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth > 0.0f)
        {
            UpdateHealth(-healthDropRate * Time.deltaTime);
        }

        if (CurrentHunger > 0.0f)
        {
            UpdateHunger(-hungerRate * Time.deltaTime);
        }
    }

    void OnApplicationPause()
    {
#if UNITY_EDITOR
        Debug.Log(gameObject.name + ": OnApplicationPause");
#endif

        if (!isDataLoaded)
        { return; }

        SaveData();
    }

    void OnApplicationQuit()
    {
#if UNITY_EDITOR
        Debug.Log(gameObject.name + ": OnApplicationQuit");
#endif

        SaveData();
    }

    public void UpdateHunger(float amount)
    {
        CurrentHunger += amount;
        CurrentHunger = Mathf.Clamp(CurrentHunger, 0.0f, maxHunger);
    }

    public void UpdateHealth(float amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0.0f, maxHealth);
    }

    public void SaveData()
    {
#if UNITY_EDITOR
        Debug.Log("CurrentHealth: " + CurrentHealth + "   CurrentHunger: " + CurrentHunger);
#endif
        
        PlayerPrefs.SetFloat("Health", CurrentHealth);
        PlayerPrefs.SetFloat("Hunger", CurrentHunger);
    }
}
