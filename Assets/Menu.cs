using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Vector3 _scaleOriginBigButton;
    private Vector3 _scaleOriginSmallButton;

    public float ScaleRateButton;
    public static Menu instance = null;
    //public Image ImageToEnlarge;
    public Button PlayButton;
    public Button SettingButton;
    public Button ExitButton;
    public Button AboutMeButton;

    // Start is called before the first frame update
    void Start()
    {
        _scaleOriginBigButton = PlayButton.GetComponent<RectTransform>().localScale;
        _scaleOriginSmallButton = AboutMeButton.GetComponent<RectTransform>().localScale;

        AboutMe.instance.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ToolsDaraLinhObj.instance.ScaleButtonWhenMousePointer(PlayButton, ScaleRateButton, _scaleOriginBigButton);
        ToolsDaraLinhObj.instance.ScaleButtonWhenMousePointer(SettingButton, ScaleRateButton, _scaleOriginBigButton);
        ToolsDaraLinhObj.instance.ScaleButtonWhenMousePointer(ExitButton, ScaleRateButton, _scaleOriginBigButton);
        ToolsDaraLinhObj.instance.ScaleButtonWhenMousePointer(AboutMeButton, ScaleRateButton, _scaleOriginSmallButton);
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
        ToolsDaraLinhObj.instance.ReSizeUIObject(PlayButton, _scaleOriginBigButton);
        SceneManager.LoadSceneAsync(1);
    }

    public void ClickSettingButton()
    {
        instance.enabled = false;
        ToolsDaraLinhObj.instance.ReSizeUIObject(SettingButton, _scaleOriginBigButton);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void ClickAboutMeButton()
    {
        instance.enabled = false;
        ToolsDaraLinhObj.instance.ReSizeUIObject(AboutMeButton, _scaleOriginSmallButton);
        AboutMe.instance.gameObject.SetActive(true);
    }
}
