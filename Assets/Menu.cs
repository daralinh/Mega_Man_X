using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu instance = null;
    private Vector3 _scaleOriginBigButton;
    private Vector3 _scaleOriginSmallButton;

    [Header("---- Button ----")]
    public float ScaleRateButton;
    public Button PlayButton;
    public Button SettingButton;
    public Button ExitButton;
    public Button AboutMeButton;

    void Start()
    {
        _scaleOriginBigButton = PlayButton.GetComponent<RectTransform>().localScale;
        _scaleOriginSmallButton = AboutMeButton.GetComponent<RectTransform>().localScale;

        AboutMe.instance.gameObject.SetActive(false);
        SettingManager.instance.gameObject.SetActive(false);
        AudioManager.instance.PlayBackground(AudioManager.instance.IntroMenu);
    }

    void Update()
    {
        ToolsDaraLinhObj.instance.ScaleButtonWhenMousePointerFameByFame(PlayButton, ScaleRateButton, _scaleOriginBigButton);
        ToolsDaraLinhObj.instance.ScaleButtonWhenMousePointerFameByFame(SettingButton, ScaleRateButton, _scaleOriginBigButton);
        ToolsDaraLinhObj.instance.ScaleButtonWhenMousePointerFameByFame(ExitButton, ScaleRateButton, _scaleOriginBigButton);
        ToolsDaraLinhObj.instance.ScaleButtonWhenMousePointerFameByFame(AboutMeButton, ScaleRateButton, _scaleOriginSmallButton);
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void ClickPlayGameButton()
    {
        AudioManager.instance.StopBackground();
        SceneManager.LoadSceneAsync(1);
    }

    public void ClickSettingButton()
    {
        instance.enabled = false;
        SettingManager.instance.On();
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void ClickAboutMeButton()
    {
        instance.enabled = false;
        AboutMe.instance.On();
    }
}
