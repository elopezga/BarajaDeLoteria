using UnityEngine;
using UnityEngine.SceneManagement;

namespace BarajaDeLoteria.MainMenu
{
    public class MenuCanvasController : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}