using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectForTapping : MonoBehaviour
{
    public Image Image;
    public GameHolder GameHolder;
    private RectTransform _transform;
    public int increase = 1;
    public bool DontDestroy;

    public virtual void WhenTap()
    {
        GameHolder.ChangeScore(increase, !DontDestroy);
        _transform.localScale = Vector3.one;
        if (DontDestroy)
        {
            DontDestroy = false;
            return;
        }
        Destroy(gameObject);
    }
    
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(WhenTap);
        _transform = GetComponent<RectTransform>();
        ChangePosition();
    }

    void ChangePosition()
    {
        var newAnchor =  new Vector2(Random.Range(0f,1f),Random.Range(0f,1f));
        _transform.anchorMin = newAnchor;
        _transform.anchorMax = newAnchor;
        _transform.anchoredPosition = Vector2.zero;
    }
    
}
