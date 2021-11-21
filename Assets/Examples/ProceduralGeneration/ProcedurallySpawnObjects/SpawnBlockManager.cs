using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnBlockManager : MonoBehaviour
{
    
    public GameObject correct;
    public GameObject incorrect;

    // Start is called before the first frame update
    void Start()
    {
        // Create / Instantiate the three GameObjects for the one correct and two incorrect

        int value = Random.Range(0,3);

        GameObject g1 = Instantiate(incorrect, transform.Find("AnswerPosition").transform.Find("Lane1").position, Quaternion.identity, transform);
        GameObject g2 = Instantiate(incorrect, transform.Find("AnswerPosition").transform.Find("Lane2").position, Quaternion.identity, transform);
        GameObject g3 = Instantiate(incorrect, transform.Find("AnswerPosition").transform.Find("Lane3").position, Quaternion.identity, transform);

        switch(value) {
        case 0:
            SetCorrect(g1, "Lane1");
            break;
        case 1:
            SetCorrect(g2, "Lane2");
            break;
        case 2:
            SetCorrect(g3, "Lane3");
            break;
        default:
            break;
        } 

        
    }

    void SetCorrect(GameObject go, string lane) {
        Destroy(go);
        go = Instantiate(correct, transform.Find("AnswerPosition").transform.Find(lane).position, Quaternion.identity, transform);
        go.GetComponent<AnswerCheck>().correct = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
