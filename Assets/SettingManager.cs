using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public static SettingManager instance = null;

    public Image SettingHub;
    public Image SettingHubImage;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SettingHub.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Off();
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (!ToolsDaraLinhObj.instance.IsPointerOverUIObject(SettingHubImage))
            {
                Off();
            }
        }
    }

    public void On()
    {
        SettingHub.gameObject.SetActive(true);
        instance.enabled = true;
    }

    public void Off()
    {
        SettingHub.gameObject.SetActive(false);
        instance.enabled = false;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Menu.instance.enabled = true;
        }
    }
}
