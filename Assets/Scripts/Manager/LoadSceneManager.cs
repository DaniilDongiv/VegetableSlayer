using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class LoadSceneManager : MonoBehaviour
    {
        public void LoadGameScene()
        {
            SceneManager.LoadScene("Scenes/GameScene");
        }
    }
}
