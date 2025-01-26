using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    public Button button;
    public Color hoverColor;
    private Color initialColor;
    private ColorBlock cb;

    void Start()
    {
        cb = button.colors;
        initialColor = button.colors.highlightedColor;
    }

    public void OnClick()
    {
        SceneManager.LoadScene("FirstLevelTemp");
    }

    public void OnHover()
    {
        cb.highlightedColor = hoverColor;
        button.colors = cb;
    }

    public void OffHover()
    {
        cb.highlightedColor = initialColor;
        button.colors = cb;
    }
}
