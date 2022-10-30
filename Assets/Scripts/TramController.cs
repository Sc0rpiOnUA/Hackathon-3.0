using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TramController : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] public float _speed;
    [HideInInspector] public bool canTurn = false;
    [HideInInspector] public bool isTurned = false;
    [HideInInspector] public int turnWay = 1;
    private float horizontal;
    public UnityEvent onHitBomb;
    [SerializeField] private PlayerControlForLeaderboard _leaderBoard;
    [SerializeField] private int health = 3;

    private void Start()
    {
        onHitBomb.AddListener(() =>
        {
            if (health==0)
            {
                gameManager.OpenLosePanel();
                _leaderBoard.SetScore();
            }
            else
            {
                health--;
            }
            }
        );
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

    }
    private void FixedUpdate()
    {
        ManageMove();
    }
    private void ManageMove()
    {
        Forward();
      
    }

    private void Forward()
    {
        
        transform.Translate((Vector3.forward) * _speed);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            gameManager.OpenLosePanel();
        }
        if (collision.transform.tag == "Bomb")
        {
            onHitBomb.Invoke();
            Destroy(collision.gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 target;

        if (other.transform.tag == "Turn")
        {
            if (horizontal == 1)
            {
                isTurned = true;
                turnWay = 2;
                target = other.GetComponent<RotationFlag>().rightTurn.transform.position;
                if(target == null)
                {
                    isTurned = false;
                    other.gameObject.SetActive(false);
                    
                }
                else
                {
                    StartCoroutine(Turn(target));
                    isTurned = true;
                    other.gameObject.SetActive(false);
                }
            }
            else if (horizontal == -1)
            {
                isTurned = true;
                turnWay = 0;
                target = other.GetComponent<RotationFlag>().leftTurn.transform.position;
                if (target == null)
                {
                    isTurned = false;
                    other.gameObject.SetActive(false);
                }
                else
                {
                    StartCoroutine(Turn(target));
                    isTurned = true;
                    other.gameObject.SetActive(false);
                }
            }
            else if(horizontal == 0)
            {
                isTurned = true;
                turnWay = 1;

            }
        }
    }
    private IEnumerator Turn(Vector3 target)
    {
        
        yield return new WaitUntil(() => IsTurned(target));


    }

    private bool IsTurned(Vector3 target)
    {
        Quaternion currentRotation = transform.rotation;
        Quaternion wantedRotation = Quaternion.LookRotation(new Vector3(target.x,transform.position.y,target.z)-transform.position);
        transform.rotation = Quaternion.Lerp(currentRotation, wantedRotation, Time.deltaTime * 20f);
        float distanation = Vector3.Distance(transform.position, new Vector3(target.x, transform.position.y, target.z));
        if (distanation < 2f)
        {
            Debug.Log("Turned");
            transform.rotation = new Quaternion(transform.rotation.x, Mathf.Round(transform.rotation.y),transform.rotation.z,transform.rotation.w) ;
            return true;
        }
        else
        {
            return false;
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Fork")
        {
            canTurn = true;
            Debug.Log("Can Turn");
        }
        else
        {
            canTurn = false;
        }
    }
}
