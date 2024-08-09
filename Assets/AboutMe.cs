using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutMe : MonoBehaviour
{
    public static AboutMe instance = null;
    private Vector3 _scaleOriginGmailButton;
    private Vector3 _scaleOriginGitHubButton;
    private Vector3 _scaleOriginFacebookButton;


    public float ScaleRateButton;
    public Button GmailButton;
    public Button GitHubButton;
    public Button FacebookButton;

    public Text UrlFacebook;
    public Text UrlGitHub;
    public Text Gmail;
    public Image ImageAboutMe;
    public Image ImageHub;

    void Start()
    {
        _scaleOriginGmailButton = GmailButton.GetComponent<RectTransform>().localScale;
        _scaleOriginGitHubButton = GitHubButton.GetComponent<RectTransform>().localScale;
        _scaleOriginFacebookButton = FacebookButton.GetComponent<RectTransform>().localScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            Off();
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (!ToolsDaraLinhObj.instance. IsPointerOverUIObject(ImageHub))
            {
                Off();
                return;
            }
        }

        if (ToolsDaraLinhObj.instance.IsPointerOverUIObject(GmailButton))
        {
            ToolsDaraLinhObj.instance.ScaleButtonWhenMousePointerFameByFame(GmailButton, ScaleRateButton, _scaleOriginGmailButton);
        }
        else if (ToolsDaraLinhObj.instance.IsPointerOverUIObject(GitHubButton))
        {
            ToolsDaraLinhObj.instance.ScaleButtonWhenMousePointerFameByFame(GmailButton, ScaleRateButton, _scaleOriginGitHubButton);
        }
        else if (ToolsDaraLinhObj.instance.IsPointerOverUIObject(FacebookButton))
        {
            ToolsDaraLinhObj.instance.ScaleButtonWhenMousePointerFameByFame(GmailButton, ScaleRateButton, _scaleOriginFacebookButton);
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void On()
    {
        ImageAboutMe.gameObject.SetActive(true);
        instance.gameObject.SetActive(true);
    }

    public void Off()
    {
        ImageAboutMe.gameObject.SetActive(false);
        instance.gameObject.SetActive(false);
        Menu.instance.enabled = true;
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
