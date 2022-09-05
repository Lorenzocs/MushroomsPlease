using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public float maxX, minX, maxY, minY;
    public Vector3 positionToMove;
    public float speed;
    public float countWaiting;
    [SerializeField]private Animator myAnimator;
    [SerializeField] private SpriteRenderer mySprite;
    void Start()
    {
        positionToMove = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, positionToMove) > 0.3f)
        {
            if (countWaiting <= 0)
            {
                var dir = (positionToMove - transform.position).normalized;
                if (positionToMove.x > transform.position.x)
                {
                    mySprite.flipX = false;
                }
                else
                {
                    mySprite.flipX = true;
                }
                transform.position += dir * Time.deltaTime * speed;
                myAnimator.SetBool("Walk", true);
            }
            else
            {
                countWaiting -= Time.deltaTime;
            }
        }
        else
        {
            countWaiting = Random.Range(0.5f, 3);
            myAnimator.SetBool("Walk", false);
            positionToMove = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        var posMinX = new Vector3(minX, transform.position.y);
        Gizmos.DrawSphere(posMinX, 0.05f);
        var posMaxX = new Vector3(maxX, transform.position.y);
        Gizmos.DrawSphere(posMaxX, 0.05f);

        Gizmos.color = Color.green;
        var posMinY = new Vector3(transform.position.x, minY);
        Gizmos.DrawSphere(posMinY, 0.05f);
        var posMaxY = new Vector3(transform.position.x, maxY);
        Gizmos.DrawSphere(posMaxY, 0.05f);
    }
}
