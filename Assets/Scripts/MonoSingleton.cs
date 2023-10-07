using System;
using System.Reflection;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    protected static bool s_Initialized;
    private static T s_instance;
    public static T Instance => s_instance ? s_instance : CreateNew();
    private static T CreateNew()
    {
        var tryFind = FindObjectOfType<T>();  
        if (tryFind)
        {
            s_instance = tryFind;
            s_instance.Initialize();
            return tryFind;
        }
        GameObject newGO = new GameObject();
        newGO.name = typeof(T).ToString();
        var newInstance =  newGO.AddComponent<T>();
        newInstance.Initialize();
        s_instance = newInstance;
        return newInstance;
    }

    public static bool IsExist() => s_instance != null;

    //Initialize shouldn't have any side effect
    protected virtual void Initialize()
    {
        s_Initialized = true;
    }    
    protected virtual void Reset()
    {
        name = typeof(T).Name;
    }
    protected virtual void Awake()
    {
        Initialize();
        DontDestroyOnLoad(this.gameObject);
    }
}
public class Singleton<T>  where T : Singleton<T>, new()
{
    private static T s_instance;
    public static T Instance => s_instance == null ? s_instance : CreateNew();
    private static T CreateNew()
    {
        var newInstance = new T();
        newInstance.Initialize();
        s_instance = newInstance;
        return s_instance;
    }
    public static bool IsExist() => s_instance != null;
    protected virtual void Initialize(){}
}

