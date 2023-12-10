using UnityEngine;

public class LevelsInfo : MonoBehaviour
{
    private Level[] _levels;

    //private int _lastPassedLevel;

    private void Start()
    {
        _levels = GetComponentsInChildren<Level>();

        SetLastPassedLevel(0);
    }

    public void SetLastPassedLevel(int number)
    {
        //_lastPassedLevel = number;

        if (number >= _levels.Length) return;

        _levels[number].DisableLocker();
    }
}
