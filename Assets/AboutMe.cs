using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutMe : MonoBehaviour
{
    public static AboutMe instance = null;

    public Text UrlFacebook;
    public Text UrlGitHub;
    public Text Gmail;
    public Image ImageAboutMe;
    public Image ImageHub;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            Off();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!ToolsDaraLinhObj.instance. IsPointerOverUIObject(ImageHub))
            {
                Off();
                return;
            }
        }

    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void Off()
    {
        ImageAboutMe.gameObject.SetActive(false);
        instance.gameObject.SetActive(false);
    }

    public void On()
    {
        ImageAboutMe.gameObject.SetActive(true);
    }

    public void ClickButtonFacebook()
    {
        Application.OpenURL(UrlFacebook.text);
    }

    public void ClickButtonGitHub()
    {
        Application.OpenURL(UrlGitHub.text);
    }

    public void ClickButtonGmail()
    {
        Application.OpenURL($"mailto:{Gmail.text}");
    }
}
