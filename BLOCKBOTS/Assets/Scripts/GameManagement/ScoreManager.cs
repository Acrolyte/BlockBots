using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    #region  Singleton

    public static ScoreManager instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Score sce;
    public int aim = 0;
    public void Update()
    {
        int num = sce.point;
        if (num >= aim)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
