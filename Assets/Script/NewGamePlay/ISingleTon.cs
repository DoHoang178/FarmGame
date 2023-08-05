using UnityEngine;

public class ISingleton<T> where T : class, new()
{
    protected static volatile T m_instance;
    private static readonly object syncRoot = new object();

    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                lock (syncRoot)
                {
                    m_instance ??= new T();
                }
            }

            return m_instance;
        }
    }

    public static void DestroyInstance()
    {
        m_instance = null;
    }

}


public class ISingletonMonoBehaviour<T> : MonoBehaviour where T : ISingletonMonoBehaviour<T>
{
    public static T Instance { get; private set; }
    public static bool IsInstantiated => Instance != null;

    protected virtual void Awake()
    {
        if (IsInstantiated && Instance != (T)this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = (T)this;
    }
    public void DestroyInstance()
    {
        Destroy(gameObject);
        Instance = null;
    }

    protected virtual void OnDestroy()
    {
        if (Instance == (T)this)
        {
            Instance = null;
        }
    }
}