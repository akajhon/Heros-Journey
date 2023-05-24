using UnityEngine;

public class ObjectPersist : MonoBehaviour
{
    private static ObjectPersist instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
