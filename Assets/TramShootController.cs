using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TramShootController : MonoBehaviour
{
    public bool canHook= false, canShoot=true;
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public LayerMask whatIsBomb;
    public LayerMask whatIsCar;
    [SerializeField] private Transform _hook;
    private float maxDistance = 100f;
    private SpringJoint joint;
    public bool isShoot = false;

    public UnityEvent OnShoot;
    public UnityEvent OnHook;
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    public void CanHook()
    {
        canHook = true;
    }
    public void CantHook() {
        canHook = false;
    }
    private void Update()
    {

        if (canHook)
        {
            
            if (Input.GetMouseButtonDown(1))
            {

                StartGrapple();
                

            }
            else if (Input.GetMouseButtonUp(1))
            {
                canShoot = true;
                StopGrapple();
                
            }
        }
        
        if(canShoot)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(rayOrigin, out hit, maxDistance, whatIsBomb))
                {
                    Destroy(hit.collider.gameObject);
                }
                    OnShoot.Invoke();
            }
        }

    }
    private void LateUpdate()
    {
        DrawRope();
    }
    void StartGrapple()
    {
        RaycastHit hit;
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayOrigin, out hit, maxDistance, whatIsGrappleable))
            {
            canShoot = false;
            OnHook.Invoke();
            grapplePoint = hit.collider.transform.position + new Vector3(0f,0f,20f);
                joint = gameObject.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = grapplePoint;

                float distanceFromPoint = Vector3.Distance(transform.position, grapplePoint);

                joint.maxDistance = distanceFromPoint * 0.8f;
                joint.minDistance = distanceFromPoint * 0.25f;

                lr.positionCount = 2;
                currentGrapplePosition = _hook.position;
            PlayerPrefs.SetInt("Loot", PlayerPrefs.GetInt("Loot")+1);
        }
        
    }


    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        if (!joint) return;
        if (currentGrapplePosition.z<=transform.position.z)
        {
            
            return;
        }
        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 10f);

        lr.SetPosition(0, _hook.position);
        lr.SetPosition(1, currentGrapplePosition);

    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
