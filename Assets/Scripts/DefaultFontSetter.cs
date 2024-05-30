using UnityEngine;
using UnityEngine.UI;

public class DefaultFontSetter : MonoBehaviour
{
    public Font defaultFont;

    void Awake()
    {
        if (defaultFont != null)
        {
            Text[] textComponents = FindObjectsOfType<Text>();
            foreach (Text text in textComponents)
            {
                text.font = defaultFont;
            }
        }
        else
        {
            Debug.LogWarning("Default font not set! Please assign a font to the DefaultFontSetter script.");
        }
    }
}
