using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Manager_UI : MonoBehaviour
{
   [SerializeField] private Manager_Audio manager_Audio;
   [SerializeField] private GameObject inGame_Obj;
   [SerializeField] private GameObject outtro_Obj;
   [SerializeField] private GameObject endingImg_Obj;
   
   [SerializeField] private Image fade_Img;
   [SerializeField] private Image ending_Img;
   [SerializeField] private Image ending_Text_Img;
   [SerializeField] private Sprite[] ending_Imgs;

   private string bgmName;
   private void OnEnable()
   {
      fade_Img.color = new Color(0, 0, 0, 0);
   }

   public void Ending(bool isHappy)
   {
      outtro_Obj.SetActive(true);
      Color color = isHappy ? Color.white : Color.black;
      StartCoroutine(Fade_Start(3f, color, true));
      if (isHappy)
      {
         ending_Img.sprite = ending_Imgs[0];
         ending_Text_Img.sprite = ending_Imgs[2];
         ending_Text_Img.SetNativeSize();
         bgmName = "Happy";
      }
      else
      {
         ending_Img.sprite = ending_Imgs[1];
         ending_Text_Img.sprite = ending_Imgs[3];
         ending_Text_Img.SetNativeSize();
         bgmName = "Bad";
      }
   
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
      manager_Audio.BGM_Play(bgmName);
      endingImg_Obj.SetActive(true);
      inGame_Obj.SetActive(false);
   }
   
   public void ExitGame()
   {
      #if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
      #else
        Application.Quit(); // 어플리케이션 종료
      #endif
   }
}
