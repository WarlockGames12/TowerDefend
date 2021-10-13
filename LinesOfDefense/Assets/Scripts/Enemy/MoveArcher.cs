using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArcher : MonoBehaviour
{
    [SerializeField] private bool CanMove = true;
    [SerializeField] List<Transform> Waypoints = new List<Transform>();
    //[SerializeField] private Transform[] Waypoints;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform CurrentWayPoint;
    [SerializeField] private int WaypointCounter;
    [SerializeField] private GameObject[] Towers;
    [SerializeField] private GameObject closestObject = null;
    [SerializeField] private float closestDistance = 9999;
    public AudioSource HurtPlayer;





    // Start is called before the first frame update
    private void Start()
    {

        foreach (Transform transform in GameObject.Find("Waypoints2").GetComponentInChildren<Transform>())
        {
            Waypoints.Add(transform);
        }
        GotoWayPoint();
        CanMove = true;
    }
    private void NextWaypoint()
    {
        WaypointCounter++;
        GotoWayPoint();
    }
    private void GotoWayPoint()
    {
        if (CheckArray())
        {
            CurrentWayPoint = Waypoints[WaypointCounter];
        }
    }
    private bool CheckArray()
    {
        bool result = false;
        if (WaypointCounter >= Waypoints.Count && CanMove)
        {
            CanMove = false;
            print("TakeDamage");
            HurtPlayer.Play();
            GameObject.Find("TheKing").GetComponent<PlayerHealth>().TakeDamage(1);
            result = false;
            Destroy(gameObject);
        }
        else
        {
            result = true;
        }
        return result;
    }





    private void Update()
    {
        if (CanMove)
        {
            print("Please work :(");
            float dist = Vector2.Distance(transform.position, CurrentWayPoint.transform.position);

            float dist2 = Vector2.Distance(transform.position, CurrentWayPoint.transform.position);
            // Sets the rotation towards the waypoint
            Vector3 dir2 = Waypoints[WaypointCounter].position - transform.position;
            dir2.z = 0;
            float angle = Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg;
            // Only rotate if there is some distance to our destination
            if (dir2.magnitude >= 0.2f)
            {
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

            print(CurrentWayPoint.transform.position);
            if (dist <= 0.1f)
            {
                NextWaypoint();
                print("Can Move");
            }
            else
            {
                // var targetRotation = Quaternion.LookRotation(CurrentWayPoint.position - transform.position);
                // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, moveSpeed * Time.deltaTime);
                // transform.position +=  transform.right* Time.deltaTime * moveSpeed;
                Vector2 dir = CurrentWayPoint.transform.position - transform.position;
                transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
            }



        }



        Towers = GameObject.FindGameObjectsWithTag("Turret");

        if (Towers.Length > 0)
        {
            for (int i = 0; i < Towers.Length; i++)
            {
                float dist = Vector2.Distance(this.gameObject.transform.position, Towers[i].transform.position);

                if (dist < closestDistance)
                {
                    closestObject = Towers[i];
                    closestDistance = dist;
                    Vector3 dir = closestObject.transform.position - transform.position;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    moveSpeed = 0f;

                }
            }

            
        }
        else
        {
            moveSpeed = 5f;
        }

    }

}
