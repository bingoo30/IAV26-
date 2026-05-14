using UnityEngine;

public class OnClick : MonoBehaviour
{
    public void ChangeToMenu()
    {
        GameManager.Instance.LoadScene("Play");
    }
    public void Quit()
    {
        Application.Quit();
    }
}