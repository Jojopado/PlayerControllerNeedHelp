using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTween : MonoBehaviour
{
    private GameObject enemy;
    public GameObject posA;
    public GameObject posB;
    public GameObject posC;

    public bool go;
    public Ease animationEase;
    public enum AIStatus 
    { 
        patrol = 0 , 
        warning = 1 , 
        attack = 2 ,
    };
    AIStatus aistatus;
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
    }

    public void Update()
    {
        SwitchCase();
        if (Input.GetKeyDown(KeyCode.A))
        {
            aistatus = AIStatus.attack;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            aistatus = AIStatus.patrol;
        }
    }
    void SwitchCase()
    {
        switch (aistatus)
        {
            case AIStatus.attack:
                Debug.Log("0");
                SequenceTest();
                break;
            case AIStatus.patrol:
                if (!go)
                {
                    go = true;
                    enemy.transform.DOMove(GoRandomPos(), 10f).OnComplete(() => { go = false; });
                }
                break;
            case AIStatus.warning:
                Debug.Log("2");
                break;
            
        }
    }
    void SequenceTest()
    {
        Sequence enemyTransform = DOTween.Sequence();
        enemyTransform.Append(enemy.transform.DOMove(new Vector3(posA.transform.position.x, posA.transform.position.y + 1, posA.transform.position.z), 5f)).SetEase(animationEase)
                      .Append(enemy.transform.DOMove(new Vector3(posB.transform.position.x, posB.transform.position.y + 1, posB.transform.position.z), 5f))
                      .Append(enemy.transform.DOMove(new Vector3(posC.transform.position.x, posC.transform.position.y + 1, posC.transform.position.z), 5f))
                      .Append(enemy.transform.DORotate(new Vector3(0, 0, 90), 10f));
    }
   Vector3 GoRandomPos()
    {
        Vector3 randomPos = new Vector3(Random.Range(-14, 14), 2 , Random.Range(-14, 14));
        return randomPos;
    }
}
