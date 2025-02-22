using UnityEngine;

public class AutoBehavior : MonoBehaviour
{
    protected virtual void Reset()
    {
        LoadComponents();
    }

    protected virtual void LoadComponents()
    {

    }


    protected virtual void Awake()
    {
        LoadComponents();
    }
}