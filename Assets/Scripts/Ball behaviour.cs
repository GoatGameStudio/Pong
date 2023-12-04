using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Ballbehaviour : MonoBehaviour
{

    [SerializeField] int ballSpeed;
    [SerializeField] GameObject Player1, Player2;
    [SerializeField] int scoreP1,scoreP2;
    // Start is called before the first frame update
    void Start()
    {
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x > Player2.transform.position.x + 2)
        {
            scoreP1++;
            GameObject.Find("Score1").GetComponent<TMP_Text>().text = scoreP1.ToString();
            Respawn();
        }
        if(gameObject.transform.position.x < Player1.transform.position.x - 2)
        {
            scoreP2++;
            GameObject.Find("Score2").GetComponent<TMP_Text>().text = scoreP2.ToString();
            Respawn();
        }
    }

    private void Respawn()
    {
        gameObject.transform.position = Vector2.zero;
        int random = Random.Range(0, 4);
        Vector2 upperRight = new Vector2(1, 1);
        Vector2 upperLeft = new Vector2(-1, 1);
        Vector2 lowerLeft = new Vector2(-1, -1);
        Vector2 lowerRight = new Vector2(1, -1);
        switch (random)
        {
            case 0:
                GetComponent<Rigidbody2D>().velocity = upperLeft * ballSpeed;
                break;
            case 1:
                GetComponent<Rigidbody2D>().velocity = upperRight * ballSpeed;
                break;
            case 2:
                GetComponent<Rigidbody2D>().velocity = lowerLeft * ballSpeed;
                break;
            case 3:
                GetComponent<Rigidbody2D>().velocity = lowerRight * ballSpeed;
                break;
            default:
                break;
        }
    }
}
