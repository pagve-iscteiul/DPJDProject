using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public GameObject gameOver;

    #region Patrol Variables
    public GameObject route;
    public float closeEnought = 0.1f;

    private List<GameObject> patrolRoute = new List<GameObject>();
    private int currentGoalIndex = 0;
    private float timeStopped = 0;
    private float timeWalking = 0;

    #endregion

    private bool caught = false;
    private PlayerController playerController;
    private AudioSource guardFootstep;
    private NavMeshAgent agent;
    private ViewCone viewCone;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerController = GetComponent<PlayerController>();
        viewCone = transform.Find("ViewCone").gameObject.GetComponent<ViewCone>();
        guardFootstep = GetComponent<AudioSource>();
        guardFootstep.Play();

        agent.isStopped = false;

        getPatrolRoute();
        if (patrolRoute.Count > 0)
            agent.SetDestination(patrolRoute[currentGoalIndex].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (caught)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            CheckCone();
        }

        if (patrolRoute.Count != 0)
        {
            Patrol();
        }
    }

    void CheckCone()
    {
        if (viewCone.canSeePlayer())
        {
            caught = true;
            Time.timeScale = 0;
            GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
            //guardFootstep.Stop();
            //agent.isStopped = true;
            //playerController.canMove = false;
            //guardFootstep.enabled = false;

            Instantiate(gameOver);
        }
    }

    void Patrol()
    {
        if (patrolRoute.Count > 0)
        {
            float distance = agent.remainingDistance;
            if (distance < closeEnought)
            {
                timeStopped += Time.deltaTime;
                if (timeStopped >= patrolRoute[currentGoalIndex].GetComponent<RouteWaypoint>().restingTime)
                {

                    currentGoalIndex++;
                    if (currentGoalIndex >= patrolRoute.Count)
                        currentGoalIndex = 0;
                    agent.SetDestination(patrolRoute[currentGoalIndex].transform.position);

                    var routeWayPoint = (RouteWaypoint)patrolRoute[currentGoalIndex].GetComponents(typeof(RouteWaypoint))[0];

                    patrolRoute[currentGoalIndex].GetComponent<Renderer>().material.color = new Color(0, 0, 102);


                    timeStopped = 0;
                }
            }
            else
            {
                timeWalking += Time.deltaTime;
            }
        }
    }

    public void getPatrolRoute()
    {
        if (route.transform.childCount == 0)
        {
            agent.isStopped = true;
            guardFootstep.enabled = false;
        }
        else
        {
            foreach (Transform routeWaypoint in route.transform)
            {
                patrolRoute.Add(routeWaypoint.gameObject);
            }
        }
    }
}