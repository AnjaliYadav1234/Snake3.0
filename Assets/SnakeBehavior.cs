using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnakeBehavior : MonoBehaviour
{
    public GameObject snakeCubePrefab;
    public GameObject foodCubePrefab;
    public int initialLength = 2;
    public float moveSpeed = 1.0f;
    public float rotationSpeed = 90f;

    private List<GameObject> snakeCubes = new List<GameObject>();
    private Vector3 moveDirection = Vector3.forward;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<initialLength;i++)
        {
            Vector3 cubePosition = transform.position + new Vector3(i , 0, 0);
            GameObject snakeCube = Instantiate(snakeCubePrefab, cubePosition, Quaternion.identity);
            snakeCubes.Add(snakeCube);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveSnake();
        HandleInput();
    }

    private void MoveSnake()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        for(int i=1; i<snakeCubes.Count;i++)
        {
            snakeCubes[i].transform.position = snakeCubes[i - 1].transform.position;
        }
    }

    private void CollideFood()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, moveDirection, out hit, 1.0f))
        {
            if(hit.collider.gameObject==foodCubePrefab)
            {
                EatFood();
                FoodCube.instance.isFoodEaten();
            }
        }
    }

    void EatFood()
    {
        GameObject newSnakeCube = Instantiate(snakeCubePrefab, snakeCubes[0].transform.position, Quaternion.identity);
        snakeCubes.Add(newSnakeCube);

        Destroy(foodCubePrefab);
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveDirection = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            moveDirection = Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            moveDirection = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            moveDirection = Vector3.right;
        }

        // Update the player's position based on the direction
        transform.position += moveDirection * Time.deltaTime;
    }


}

