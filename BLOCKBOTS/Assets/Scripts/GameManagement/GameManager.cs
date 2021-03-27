using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   private bool gameHasEnded = false;

   public void EndGame()
   {
      if (gameHasEnded == false)
      {
         gameHasEnded = true;
         Debug.Log("GAME OVER");
      }
   }

   void Restart()
   {
      SceneManager.LoadScene(1);
   }
}
