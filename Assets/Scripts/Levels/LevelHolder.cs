
using UnityEngine;
using UnityEngine.UI;

public class LevelHolder : MonoBehaviour
{
    public Text Name;
    public Image Background, Rating;
    
    private LevelData _data;
    private LevelPreview _preview;
    
    public void SetLevelData(LevelData data, LevelPreview preview)
    {
        _data = data;
        _preview = preview;
        Name.text = data.Name;
        Background.sprite = data.Background;
        Background.color = data.BackgroundColor;
        Rating.fillAmount = data.Socials.GetStars(data.DatasetName)/5f;
    }

    public void LoadLevelPanel()
    {
        _preview.Load(_data);
        Debug.Log("Loaded");
    }
}
