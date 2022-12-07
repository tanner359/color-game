using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlap_Door : Door
{
    public bool reverse;
    public Transform connectedDoor;
    private SpriteRenderer sr;
    public Transform teleport;

    new private void Awake()
    {
        base.Awake();
        action += Teleport;
        action += Overlap;
    }

    private void Start()
    {
        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();

        if (!reverse)
        {
            int r = Random.Range(1, 10);
            int g = Random.Range(1, 10);
            while(Mathf.Abs(r-g) < 1.5f){
                g = Random.Range(1, 10);
            }
            int b = Random.Range(1, 10);
            while (Mathf.Abs(b - g) < 1.5f){
                b = Random.Range(1, 10);
            }
            sr.color = new Color(r / 10f, g / 10f, b / 10f, 1.0f);
        }
    }

    public void Teleport(GameObject actor)
    {
        actor.transform.position = teleport.position;
    }

    public void Overlap(GameObject actor)
    {
        actor.GetComponent<Player>().Overlap_Color(sr.color, reverse);
    }
}
