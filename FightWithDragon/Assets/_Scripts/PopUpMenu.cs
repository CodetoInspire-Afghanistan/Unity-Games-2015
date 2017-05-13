using UnityEngine;
using System.Collections;

public class PopUpMenu : MonoBehaviour {

    public GameObject panel;
    void Start() {
        panel.SetActive(false);

    }
    // Use this for initialization
    public void OpenPanel() {
        Time.timeScale = 0;
        panel.SetActive(true);
    }
    public void ClosePanel() {
        panel.SetActive(false);
        Time.timeScale = 1;
    }
}
