using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class GameHolder : MonoBehaviour
{
    public Text TimeText, Target, Progress;
    public Image Progressbar, Background;
    public Transform Content, BonusesContent;
    public GameObject Prefab;
    public Animator MenuAnimator;
    public LeaderboardCreator LeaderboardCreator;
    
    private LevelData _data;
    private bool inGame;
    private float time;
    private int progress, target;
    private List<BonusObject> bonuses;
    private List<BonusInUI> activeBonuses = new List<BonusInUI>();
    private BonusForTapping _bonusForTapping;
    private GameObject _tappingGameObject;
    private ObjectForTapping _objectForTapping;
    public void LoadLevel(LevelData data)
    {
        _data = data;
        foreach (Transform t in BonusesContent) Destroy(t.gameObject);
        time = 0;
        progress = 0;
        target = _data.LevelTarget.NumberOfClicks;
        bonuses = _data.LevelTarget.Bonuses;
        Background.sprite = _data.Background;
        Background.color = _data.BackgroundColor;
        SetUIToCurValues();
        inGame = true;
        CreateObjectForTapping();
    }

    void CreateObjectForTapping()
    {
        _tappingGameObject = Instantiate(Prefab, Content);
        _objectForTapping = _tappingGameObject.GetComponent<ObjectForTapping>();
        _objectForTapping.Image.sprite = _data.LevelTarget.Image;
        _objectForTapping.GameHolder = this;
    }

    public void AddBonus(BonusObject bonusObject)
    {
        var bonus = Instantiate(bonusObject.Prefab, BonusesContent);
        var biu = bonus.AddComponent<BonusInUI>();
        biu.Behaviour = bonusObject.Behaviour.Copy();
        activeBonuses.Add(biu);
    }

    public void SetUIToCurValues()
    {
        TimeText.text = Mathf.FloorToInt(time).ToString();
        Target.text = target.ToString();
        Progress.text = progress + "/" + target;
        Progressbar.fillAmount = (float) progress / target;
    }
    // Update is called once per frame
    void Update()
    {
        if(!inGame) return;
        time += Time.deltaTime;
        activeBonuses.RemoveAll(item => item == null);
        for (var i = 0; i < activeBonuses.Count; i++)
        {
            if (activeBonuses[i] == null) continue;
            var workingOff = activeBonuses[i].Behaviour.UpdateAction(_objectForTapping);
            if (!workingOff) continue;
            Debug.Log(activeBonuses[i].gameObject);
            Destroy(activeBonuses[i].gameObject);
            activeBonuses[i] = null;
        }

        if(Time.frameCount%10 ==0)
            SetUIToCurValues();
    }

    public void SaveValues()
    {
        _data.Socials.AddToLeaderBoard(_data.DatasetName, new RecordModel("9999", "_______", time));
    }
    public void ChangeScore(int increase, bool destroyed)
    {
        progress += increase;
        if (progress >= target) 
        {
            SaveValues();
            LeaderboardCreator.CreateLeaderbodard(_data);
            foreach (Transform t in Content) Destroy(t.gameObject);
            MenuAnimator.SetTrigger("InMenu");
            inGame = false;
        }
        else
        {
            bonuses ??= new List<BonusObject>();
            var rnd = Random.Range(0, 10 + bonuses.Count);
            if (_bonusForTapping != null) Destroy(_bonusForTapping.gameObject);
            if (rnd > 9 )
            {
                var bonus = Instantiate(bonuses[rnd-10].Prefab, Content);
                _bonusForTapping = bonus.AddComponent<BonusForTapping>();
                _bonusForTapping.BonusObject = bonuses[rnd - 10];
                _bonusForTapping.GameHolder = this;
            }
            activeBonuses.RemoveAll(item => item == null);
            
            if(destroyed) CreateObjectForTapping();
            Debug.Log(activeBonuses.Count);
            for (var i = 0; i < activeBonuses.Count; i++)
            {
                if (activeBonuses[i] == null) continue;
                var workingOff = activeBonuses[i].Behaviour.Action();
                if (!workingOff) continue;
                Debug.Log(activeBonuses[i].gameObject);
                Destroy(activeBonuses[i].gameObject);
                activeBonuses[i] = null;
            }
        }
    }
}
