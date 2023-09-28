using UnityEngine;
using UnityEngine.UI;

public class ShowImageOnButtonPress : MonoBehaviour
{
    public Image imageToShow;
    private bool isImageVisible = false;

    private void Start()
    {
        // Set the image to be initially invisible
        imageToShow.gameObject.SetActive(false);
    }

    public void ToggleImageVisibility()
    {
        isImageVisible = !isImageVisible;
        imageToShow.gameObject.SetActive(isImageVisible);
    }
}
