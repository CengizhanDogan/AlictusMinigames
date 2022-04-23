using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ring_ObjectBehaviour : MonoBehaviour
{
    public BodyBehaviour myBody;
    public BodyBehaviour futureBody;
    public ObjectTrigger trigger;

    private Collider myColl;

    private Vector3 startPos;

    public enum RingColor { Blue, Green, Yellow, Pink };

    public RingColor color;

    [HideInInspector] public bool selected;
    void Start()
    {
        startPos = transform.position;
        trigger = GetComponent<ObjectTrigger>();
        myColl = GetComponent<Collider>();
    }
    public void GetStartPosition()
    {
        Vector3 bodyPos = myBody.GetComponent<Collider>().bounds.center;
        myColl.enabled = false;
        Destroy(trigger.myGhost);
        transform.DOMove(bodyPos, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.DOMove(startPos, 0.4f).SetEase(Ease.OutBounce).OnComplete(() =>
            {
                myColl.enabled = true;
                startPos = transform.position;
            }); ;
        });
    }
    public void GetSelected(Ring_DragObjects _drag)
    {
        Vector3 bodyPos = myBody.GetComponent<Collider>().bounds.center;
        myColl.enabled = false;
        Destroy(trigger.myGhost);
        transform.DOMove(bodyPos, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            myColl.enabled = true;
            if (Input.GetMouseButton(0))
            {
                _drag.moveObject = gameObject;
            }
            else
            {
                transform.DOMove(startPos, 0.4f).SetEase(Ease.OutBounce);
            }
        });
    }

    public void GetPlaced()
    {
        trigger.canPlace = false;
        Vector3 bodyPos = futureBody.GetComponent<Collider>().bounds.center;
        myColl.enabled = false;
        Destroy(trigger.myGhost);

        Vector3 destination = Destination;

        //Ring changes bodies 

        myBody.containingRings.Remove(gameObject);
        futureBody.containingRings.Add(gameObject);
        myBody = futureBody;
        futureBody = null;

        myBody.CheckList();

        //

        transform.DOMove(bodyPos, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.DOMove(destination, 0.4f).SetEase(Ease.OutBounce).OnComplete(() =>
            {
                myColl.enabled = true;
                startPos = transform.position;
            }); ;
        });
    }

    private Vector3 Destination
    {
        get
        {
            Vector3 place = Vector3.zero;

            if (futureBody.containingRings.Count > 0)
            {
                GameObject lastRing = futureBody.containingRings[futureBody.containingRings.Count - 1];
                place = lastRing.transform.position;
                place.y += 1.8f;
            }
            else
            {
                place = futureBody.transform.position;
                place.y = 0.8f;
            }

            return place;
        }
    }
}
