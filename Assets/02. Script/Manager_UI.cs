using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Manager_UI : MonoBehaviour
{
   [SerializeField] private Image fade_Img;

   private void OnEnable()
   {
      fade_Img.color = new Color(0, 0, 0, 0);
   }

   public void Ending(bool isHappy)
   {
      Color color = isHappy ? Color.green : Color.black;
      StartCoroutine(Fade_Start(3f, color, true));
   }
   
   public IEnumerator Fade_Start(float fade_time, Color c, bool isFade)
   {
      float timer = 0;
      float percent = 0;

      while (percent <= 1)
      {
         timer += Time.deltaTime;
         percent = timer / fade_time;
         float velue = isFade ? percent : 1 - percent;
         
         fade_Img.color = new Color(c.r, c.g, c.b, velue);
         yield return null;
      }
   }
}
