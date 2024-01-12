using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
    //public Ghost ghost;
    public List<Ghost> ghostList;
    public float timer;
    public float timeValue;
    public int ghostIndex;


    private void Awake()
    {
        ghostIndex = 0;

        for(int i = 0; i < ghostList.Count; i++)
        {
            ghostList[i].ResetData();
            ghostList[i].isRecord = false;
            ghostList[i].isReplay = false;
        }
        ghostList[0].isRecord = true;

        timeValue = 0;
        timer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timeValue += Time.deltaTime;

        if(ghostList[ghostIndex].isRecord && timer >= 1 / ghostList[ghostIndex].recordFrequency)
        {
            ghostList[ghostIndex].timeStamp.Add(timeValue);
            ghostList[ghostIndex].position.Add(this.transform.position);
            ghostList[ghostIndex].rotation.Add(this.transform.eulerAngles);

            timer = 0;
        }
    }
}
