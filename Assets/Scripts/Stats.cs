using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{
    public int hitCount = 0;
    public int missed = 0;

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width / 10, Screen.height / 10), "Hit count: " + hitCount + "\n" + "Missed: " + missed);
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
