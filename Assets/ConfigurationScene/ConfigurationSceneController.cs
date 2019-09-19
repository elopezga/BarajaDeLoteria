using UnityEngine;
using UnityEngine.SceneManagement;

namespace BarajaDeLoteria.ConfigurationScene
{
    public class ConfigurationSceneController : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

