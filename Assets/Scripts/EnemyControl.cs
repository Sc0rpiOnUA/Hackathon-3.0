using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private TramController _tramController;
    private float  startSpeed, currentSpeed;
    private Vector3 targetPoint;
    private int tunelNumber;
    private float randX = -8;
    private float randZ = 100;
    private void Awake()
    {
        targetPoint = new Vector3(randX, transform.position.y, transform.position.z + randZ);
    }
    private void Start()
    {
        startSpeed = _tramController._speed;
        currentSpeed = startSpeed;
    }
    private void Update()
    {
        

    }
    private void FixedUpdate()
    {
        StartCoroutine(Turn(targetPoint));
        ManageMove();
    }
    private void ManageMove()
    {
        transform.Translate((Vector3.forward) * currentSpeed);
    }
    /*private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Turn")
        {

            if (other.GetComponent<RotationFlag>().forwardTurn != null)
            {
                tunelNumber = Random.Range(0, 1);
                switch (tunelNumber)
                {
                    case 0:
                        target = other.GetComponent<RotationFlag>().leftTurn.transform.position;
                        break;
                    case 1:
                        target = other.GetComponent<RotationFlag>().rightTurn.transform.position;
                        break;
                }

            }
            else
            {
                tunelNumber = Random.Range(0, 2);
                switch (tunelNumber)
                {
                    case 0:
                        target = other.GetComponent<RotationFlag>().leftTurn.transform.position;
                        break;
                    case 1:
                        target = other.GetComponent<RotationFlag>().forwardTurn.transform.position;
                        break;
                    case 2:
                        target = other.GetComponent<RotationFlag>().rightTurn.transform.position;
                        break;
                }

            }
            StartCoroutine(Turn(target));
        }
    }*/
    private IEnumerator Turn(Vector3 target)
    {

        yield return new WaitUntil(() => IsTurned(target));

        if (transform.position.x < 0)
        {
            targetPoint = new Vector3(-randX, transform.position.y, transform.position.z + randZ);
        }
        else
        {
            targetPoint = new Vector3(randX, transform.position.y, transform.position.z + randZ);
        }

    }

    private bool IsTurned(Vector3 target)
    {
        Quaternion currentRotation = transform.rotation;
        Quaternion wantedRotation = Quaternion.LookRotation(new Vector3(target.x, transform.position.y, target.z) - transform.position);
        transform.rotation = Quaternion.Lerp(currentRotation, wantedRotation, Time.deltaTime * 20f);
        float distanation = Vector3.Distance(transform.position, new Vector3(target.x, transform.position.y, target.z));
        if (distanation < 10f)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
