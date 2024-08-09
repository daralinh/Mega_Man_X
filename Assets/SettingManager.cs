using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public static SettingManager instance = null;

    [Header("---- Image ----")]
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
        instance.gameObject.SetActive(true);
    }

    public void Off()
    {
        SettingHub.gameObject.SetActive(false);
        instance.gameObject.SetActive(false);;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Menu.instance.enabled = true;
        }
    }
}
