using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenDemo : MonoBehaviour
{
    private GameObject enemy;
    public GameObject posA;
    public GameObject posB;
    public GameObject posC;
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
    }

    // Update is called once per frame
    void Update()
    {
       
      if (Input.GetKeyDown(KeyCode.A))
        {
            SequenceTest();
        }
    }
    void SequenceTest()
    {
        Sequence enemyTransform = DOTween.Sequence();
        enemyTransform.Append(enemy.transform.DOMove(new Vector3(posA.transform.position.x, posA.transform.position.y + 1, posA.transform.position.z), 5f))
                      .Append(enemy.transform.DOMove(new Vector3(posB.transform.position.x, posB.transform.position.y + 1, posB.transform.position.z), 5f))
                      .Append(enemy.transform.DOMove(new Vector3(posC.transform.position.x, posC.transform.position.y + 1, posC.transform.position.z), 5f))
                      .Append(enemy.transform.DORotate(new Vector3(0, 0, 90), 10f));
    }
}
