using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraSplatterScript : MonoBehaviour 
{
    [Tooltip("Time a splatter stays on screen for.")]
    public float lingerTime = 5f;
    [Tooltip("Time it takes a splatter to fade off.")]
    public float fadeTime = 2f;

    public Canvas canvas;

    public Image[]  splatters;
    public Sprite[] splatEffects;

    Color currentImageColor;
    Color targetImageColor;
    Color deltaColor;

    #region Image size and position vars
    Vector2 imageSize = new Vector2(200, 200);

    Vector2 imagePos0 = new Vector2(0, 0);
    Vector2 imagePos1 = new Vector2(Screen.width / 2 - 100, 0);
    Vector2 imagePos2 = new Vector2(Screen.width - 200, 0);
    Vector2 imagePos3 = new Vector2(0, Screen.height / 2 - 100);
    Vector2 imagePos4 = new Vector2(Screen.width - 200, Screen.height / 2 - 100);
    Vector2 imagePos5 = new Vector2(0, Screen.height - 200);
    Vector2 imagePos6 = new Vector2(Screen.width / 2 - 100, Screen.height - 200);
    Vector2 imagePos7 = new Vector2(Screen.width - 200, Screen.height - 200);
    Vector2 imagePos8 = new Vector2(Screen.width / 2 - 300, Screen.height / 2 - 200);
    Vector2 imagePos9 = new Vector2(Screen.width / 2 - 100, Screen.height / 2 - 200);
    Vector2 imagePos10 = new Vector2(Screen.width / 2 + 100, Screen.height / 2 - 200);
    Vector2 imagePos11 = new Vector2(Screen.width / 2 - 300, Screen.height / 2);
    Vector2 imagePos12 = new Vector2(Screen.width / 2 - 100, Screen.height / 2);
    Vector2 imagePos13 = new Vector2(Screen.width / 2 + 100, Screen.height / 2);
    #endregion

    Rect buttonPos = new Rect(Screen.width / 2, Screen.height / 2 + 50, 100, 30);

    void Awake()
    {   
        
        foreach (Image splatter in splatters)
        {
            splatter.enabled = false;
        }
    }

    void OnGUI()
    {
        //GUI.TextArea(new Rect(imagePos0, imageSize), "SPLATTER 0");
        //GUI.TextArea(new Rect(imagePos1, imageSize), "SPLATTER 1");
        //GUI.TextArea(new Rect(imagePos2, imageSize), "SPLATTER 2");
        //GUI.TextArea(new Rect(imagePos3, imageSize), "SPLATTER 3");
        //GUI.TextArea(new Rect(imagePos4, imageSize), "SPLATTER 4");
        //GUI.TextArea(new Rect(imagePos5, imageSize), "SPLATTER 5");
        //GUI.TextArea(new Rect(imagePos6, imageSize), "SPLATTER 6");
        //GUI.TextArea(new Rect(imagePos7, imageSize), "SPLATTER 7");
        //GUI.TextArea(new Rect(imagePos8, imageSize), "SPLATTER 8");
        //GUI.TextArea(new Rect(imagePos9, imageSize), "SPLATTER 9");
        //GUI.TextArea(new Rect(imagePos10, imageSize), "SPLATTER 10");
        //GUI.TextArea(new Rect(imagePos11, imageSize), "SPLATTER 11");
        //GUI.TextArea(new Rect(imagePos12, imageSize), "SPLATTER 12");
        //GUI.TextArea(new Rect(imagePos13, imageSize), "SPLATTER 13");

        if (GUI.Button(buttonPos, "Splatter"))
        {
            SplatterScreen();
            Invoke("CallFade", lingerTime);
        }
    }

    void SplatterScreen()
    {
        Image activeSplatArea = null;
        Sprite activeSplatImage = null;

        foreach (Image splatter in splatters)
        {
            if (splatter.enabled.Equals(true))
                splatter.enabled = false;
        }

        int randomArea = (int)System.Math.Ceiling(Random.value * 11);
        int randomImage = (int)System.Math.Ceiling(Random.value * 6);

        GetSplatterArea(ref activeSplatArea, randomArea);
        GetSplatterImage(ref activeSplatImage, randomImage);        

        if (!activeSplatArea.Equals(null) && !activeSplatImage.Equals(null))
        {
            activeSplatArea.enabled = true;
            activeSplatArea.color = new Color(activeSplatArea.color.r, activeSplatArea.color.g, activeSplatArea.color.b, 1);
            currentImageColor = activeSplatArea.color;
            activeSplatArea.GetComponent<Image>().sprite = activeSplatImage;
        }
    }

    void GetSplatterArea(ref Image splatterArea, int splatterFlag)
    {
        switch (splatterFlag)
        {
            case (1):
                splatterArea = splatters[0];
                break;
            case (2):
                splatterArea = splatters[1];
                break;
            case (3):
                splatterArea = splatters[2];
                break;
            case (4):
                splatterArea = splatters[3];
                break;
            case (5):
                splatterArea = splatters[4];
                break;
            case (6):
                splatterArea = splatters[5];
                break;
            case (7):
                splatterArea = splatters[6];
                break;
            case (8):
                splatterArea = splatters[7];
                break;
            case (9):
                splatterArea = splatters[8];
                break;
            case (10):
                splatterArea = splatters[9];
                break;
            case (11):
                splatterArea = splatters[10];
                break;
            default:
                break;
        }
    }

    void GetSplatterImage(ref Sprite splatterImage, int splatterFlag)
    {
        switch (splatterFlag)
        {
            case (1):
                splatterImage = splatEffects[0];
                break;
            case (2):
                splatterImage = splatEffects[1];
                break;
            case (3):
                splatterImage = splatEffects[2];
                break;
            case (4):
                splatterImage = splatEffects[3];
                break;
            case (5):
                splatterImage = splatEffects[4];
                break;
            case (6):
                splatterImage = splatEffects[5];
                break;
            default:
                break;
        }
    }

    void CallFade()
    {
        foreach(Image splatter in splatters)
            if(splatter.enabled.Equals(true))
                StartCoroutine("FadeSplatter");
    }

    IEnumerator FadeSplatter()
    {
        foreach (Image splatter in splatters)
            if (splatter.enabled.Equals(true))
                splatter.enabled = false;
        yield return null;
    }

    
}
