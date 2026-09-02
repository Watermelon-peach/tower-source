using Tower.Player;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
namespace Tower.UI
{
    public class Pause : MonoBehaviour
    {
        #region Variables
        public GameObject pauseCanvas;
        public Volume grayscale;
        //public AK.Wwise.Event Menuin;
        //public AK.Wwise.Event MenuOut;

        #endregion

        #region Unity Event Method
        private void Update()
        {
            if (InputManager.Instance.PausePressed && !TeamManager.Instance.IsSomeoneParrying)
            {
                Toggle();
            }
        }
        #endregion

        #region Custom Method
        private void Toggle()
        {
            pauseCanvas.SetActive(!pauseCanvas.activeSelf);
            Time.timeScale = pauseCanvas.activeSelf ? 0 : 1;
            grayscale.enabled = pauseCanvas.activeSelf;
            Cursor.lockState = pauseCanvas.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = pauseCanvas.activeSelf;
            if (pauseCanvas.activeSelf)
            {
                //Menuin?.Post(gameObject);
            }
            else
            {
                //MenuOut?.Post(gameObject);
            }
            
        }

        public void OnExitButton()
        {
            //나가기
            //...
            SceneManager.LoadScene(0);
        }

        public void OnResumeButton()
        {
            Toggle();
        }
        #endregion

    }
}
