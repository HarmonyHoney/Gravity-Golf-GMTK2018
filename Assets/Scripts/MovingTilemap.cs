using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTilemap : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    [SerializeField] private float waitTime;
    private float countDown;

    [SerializeField] private bool reverseOrder;

    [SerializeField] private Transform[] wayPoint;
    private int activeWayPoint;


    private void Start() {

        activeWayPoint = 1;

        countDown = 0;

    }

    private void Update() {

        if (countDown > 0) {

            countDown -= Time.deltaTime;

            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, wayPoint[activeWayPoint].position, moveSpeed * Time.deltaTime);



        if (transform.position == wayPoint[activeWayPoint].position) {      //If current position equals waypoint position

            countDown = waitTime;

            if (reverseOrder) {         //If the order of waypoints is reversed

                activeWayPoint--;
            }
            else {                      //If waypoint order is normal

                activeWayPoint++;
            }

            if (activeWayPoint < 0) {   //If activeWayPoint is outside of array range

                activeWayPoint = wayPoint.Length - 1;
            }
            else if (activeWayPoint + 1 > wayPoint.Length) {

                activeWayPoint = 0;
            }

        }

    }

}
