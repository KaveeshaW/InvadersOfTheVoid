using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; 
using UnityEngine.SceneManagement;
public class EnemyAI : MonoBehaviour
{
    public Transform target;
    Scene scene;
    public float speed = 600f;
    public float nextWaypointDistance = 3f;

    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    private bool m_FacingLeft = true;  // For determining which way the enemy is currently facing. 
    //pretty important because otherwise the bat will be moving left and right very frequently

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        //keep doing this in an interval
        //call it after one second to allow for animation, repeat rate
        InvokeRepeating("UpdatePath", 1f, .5f);
        // Return the current Active Scene in order to get the current Scene name.
        scene = SceneManager.GetActiveScene();
    }

    //updates the path
    void UpdatePath()
    {
        //don't update while currently calculating a path
        if(seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    
    //checks to see if there is an error, if there is not then create a new path
    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //do you have a path? if not, return
        if (path == null)
        {
            return;
        }

        //have you reached the destination?
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        //makes sure the arrow is always one
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        //go to the next waypoint
        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        //going to the right and is facing the left
        if (force.x >= 0.01f && m_FacingLeft)
        {
            m_FacingLeft = !m_FacingLeft;
            transform.Rotate(0f, 180f, 0f);

        }
        //going to the left and facing right
        else if (force.x <= 0.01f && !m_FacingLeft)
        {
            m_FacingLeft = !m_FacingLeft;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
