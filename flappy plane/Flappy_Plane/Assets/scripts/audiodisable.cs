using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiodisable : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    static audiodisable instance = null;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
    public void Togglesound()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.GetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.GetInt("Muted", 0);
        }
    }
}
