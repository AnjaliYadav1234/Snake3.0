using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodCube : MonoBehaviour
{
    public static FoodCube instance;

    public GameObject foodCubePrefab;
    private bool IsFoodEaten = true;
    private Vector3 moveDirection = Vector3.forward;
    // Start is called before the first frame update
    void Start()
    {
        MakeFood();
    }

    // Update is called once per frame
    void Update()
    {
        MakeFood();
    }

    void MakeFood()
    {
        if(IsFoodEaten)
        {
            transform.position = new Vector3(Random.Range(-10,10), Random.Range(-10,10),Random.Range(-10,10));
            GameObject newFood = Instantiate(foodCubePrefab, transform.position, Quaternion.identity);
            IsFoodEaten = false;
        }
    }

    public void isFoodEaten()
    {
        IsFoodEaten = true;
    }
}
