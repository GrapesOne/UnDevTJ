using UnityEngine;
using UnityEngine.UI;

public class RecordInfo : MonoBehaviour
{
    public Text Name, Score;

    private RecordModel _recordModel;
    public void SetRecord(RecordModel recordModel)
    {
        _recordModel = recordModel;
        Name.text = recordModel.name;
        Score.text = recordModel.time.ToString();
    }
}


