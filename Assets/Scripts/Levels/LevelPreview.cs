
using UnityEngine;
using UnityEngine.UI;

public class LevelPreview : MonoBehaviour
{
   public Text Name;
   public Image Background, Rating;
   public LeaderboardCreator Leaderboard;
   public Animator Animator, MenuAnimator;
   public GameHolder Game;
   private LevelData _data;

   public void LaunchLevel()
   {
      MenuAnimator.SetTrigger("InGame");
      Game.LoadLevel(_data);
   }
   public void Load(LevelData data)
   { 
      Animator.SetTrigger("Normal");
      _data = data;
      Name.text = data.Name;
      Background.sprite = data.Background;
      Background.color = data.BackgroundColor;
      Rating.fillAmount = data.Socials.GetStars(data.DatasetName)/5f;
      Leaderboard.CreateLeaderbodard(data);
   }
}
