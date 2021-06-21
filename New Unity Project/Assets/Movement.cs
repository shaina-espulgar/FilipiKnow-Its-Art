//BAGARES: This is the script for movement of the pieces

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Route Route;

    int routePosition;

    public int steps;

    bool isMoving;

    void Update() //Updating the dice roll and the movement
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            steps = Random.Range(1, 7);
            Debug.Log("Dice Roll " + steps);
            Debug.Log(Route.childNodeList);

            if (routePosition + steps > Route.childNodeList.Count) //[BAGARES] (!fixed) Overflow Protection when the roll is too high
            {
                steps = Route.childNodeList.Count;
                StartCoroutine(Move());
            }
            else
            {
                StartCoroutine(Move());
            }
         
        }
    }

    IEnumerator Move() //[BAGARES] Governs the movement along the the board
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;
        while (steps > 0)
        {
            Vector3 nextPos = Route.childNodeList[routePosition + 1].position;
            while(MoveToNextNode(nextPos))
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            steps--;
            routePosition++;
        }
        isMoving = false;


    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 5f * Time.deltaTime));
        

    }

}
