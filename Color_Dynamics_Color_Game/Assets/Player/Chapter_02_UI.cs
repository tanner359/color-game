using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Chapter_02_UI : Player_UI
{
    public TMP_Text timer, final_time;
    private float elapsed_time;
    private int stopped;

    public void Stop_Timer()
    {
        stopped = 1;
        final_time.text = timer.text.Remove(0, 6);
    }

    private void Update()
    {
        if (stopped != 1) {
            elapsed_time += Time.deltaTime;
            int minutes = (int)elapsed_time / 60;
            int seconds = (int)elapsed_time % 60;
            timer.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
