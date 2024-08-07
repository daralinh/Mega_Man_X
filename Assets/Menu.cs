using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Vector3 _scaleOriginButton;

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
        _scaleOriginButton = PlayButton.GetComponent<RectTransform>().localScale;
        AboutMe.instance.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MousePointerButton(PlayButton);
        MousePointerButton(SettingButton);
        MousePointerButton(ExitButton);
        MousePointerButton(AboutMeButton);
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void MousePointerButton(Button button)
    {
        if (ToolsDaraLinhObj.instance.IsPointerUIObject(button))
        {
            ToolsDaraLinhObj.instance.ReSizeUIObject(button, ScaleRateButton);
        }
        else
        {
            if (button.GetComponent<RectTransform>().localScale == _scaleOriginButton)
            {
                return;
            }

            ToolsDaraLinhObj.instance.ReSizeUIObject(button, _scaleOriginButton);
        }
    }

    public void ClickPlayGameButton()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ClickSettingButton()
    {
        instance.enabled = false;
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void ClickAboutMeButton()
    {
        instance.enabled = false;
        AboutMe.instance.gameObject.SetActive(true);
        AboutMe.instance.On();
    }
}
