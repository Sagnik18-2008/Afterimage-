using UnityEngine;
using UnityEngine.SceneManagement;

namespace Afterimage.UI
{
    public class MainMenuController : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("Tutorial");
        }

        public void ShowHowToPlay()
        {
            Debug.Log("How to Play panel opened.");
        }

        public void OpenSettings()
        {
            Debug.Log("Settings panel opened.");
        }
    }
}
