using Unity.VisualScripting;
using UnityEngine;

public class BaseSingleton<T> : AutoBehavior where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new(typeof(T).Name);
                _instance = obj.AddComponent<T>();
            }
            return _instance;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        if (_instance != null) Debug.LogError("Instance already: " + name);
        _instance = this as T;
    }
}
