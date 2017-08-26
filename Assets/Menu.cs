using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
    public class Menu : MonoBehaviour
    {
        public void LoadLevel()
        {
            SceneManager.LoadScene("mainGame");
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
