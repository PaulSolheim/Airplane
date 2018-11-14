using UnityEngine;
using UnityEngine.SceneManagement;

namespace KodeKlubb
{
    public class KK_SceneLoader : MonoBehaviour
    {
        public string sceneName = "InventoryUI_Partial";
        public LoadSceneMode mode = LoadSceneMode.Additive;

        private void Start()
        {
            var active = SceneManager.GetSceneByName(sceneName);
            if (active.isLoaded == false)
            {
                SceneManager.LoadScene(sceneName, mode);
            }
        }
    }
}

