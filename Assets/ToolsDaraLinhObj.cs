using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolsDaraLinhObj : MonoBehaviour
{
    public static ToolsDaraLinhObj instance = null;

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

    public bool IsNull(Image image)
    {
        if (image == null)
        {
            Debug.Log("image null");
            return true;
        }

        return false;
    }

    public bool IsNull(Button button)
    {
        if (button == null)
        {
            Debug.Log("button null");
            return true;
        }

        return false;
    }

    public bool IsPointerOverUIObject(Image image)
    {
        if (!instance.IsNull(image))
        {
            RectTransform rectTransform = image.rectTransform;
            Vector2 localMousePosition = rectTransform.InverseTransformPoint(Input.mousePosition);
            return rectTransform.rect.Contains(localMousePosition);
        }

        return false;
    }

    public bool IsPointerUIObject(Image image)
    {
        return !IsPointerOverUIObject(image);
    }

    public bool IsPointerOverUIObject(Button button)
    {
        if (!instance.IsNull(button) && !instance.IsNull(button.image))
        {
            return IsPointerOverUIObject(button.image);
        }
        
        return false;
    }

    public bool IsPointerUIObject(Button button)
    {
        return !IsPointerOverUIObject(button);
    }

    public void ReSizeUIObject(Image image, Vector3 newSize)
    {
        if (!instance.IsNull(image))
        {
            image.GetComponent<RectTransform>().localScale = newSize;
        }
    }

    public void ReSizeUIObject(Image image, float rate)
    {
        if (!instance.IsNull(image))
        {
            RectTransform rectTransform = image.GetComponent<RectTransform>();
            rectTransform.localScale = new Vector3(rectTransform.localScale.x * rate,
                                                   rectTransform.localScale.y * rate,
                                                   rectTransform.localScale.z * rate);
        }
    }

    public void ReSizeUIObject(Button button, float rate)
    {
        if (!instance.IsNull(button))
        {
            RectTransform rectTransform = button.image.GetComponent<RectTransform>();
            button.GetComponent<RectTransform>().localScale = new Vector3(rectTransform.localScale.x * rate,
                                                                          rectTransform.localScale.y * rate,
                                                                          rectTransform.localScale.z * rate);
        }
    }

    public void ReSizeUIObject(Button button, Vector3 newSize)
    {
        if (!instance.IsNull(button))
        {
            button.GetComponent<RectTransform>().localScale = newSize;
        }
    }
}
