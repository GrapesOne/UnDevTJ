using System;

public class RecordModel : IComparable
{
    public string id;
    public string name;
    public float time;

    public RecordModel(string _id, string _name, float _time)
    {
        id = _id;
        name = _name;
        time = _time;
    }

    public int CompareTo(object obj) => !(obj is RecordModel m) ? 1 : m.time.CompareTo(time);
}