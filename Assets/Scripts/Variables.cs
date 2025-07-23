using UnityEngine;

public class Variables : MonoBehaviour
{
    public static bool ComputerBooted = false;

    public static bool WateringPlants = false;
    public static int PlantsLeft = 5;
    public static int MessLeft = 2;
    public Interactions[] plants;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (WateringPlants && PlantsLeft == 0)
        {
            //do something important here
        }

        if (MessLeft == 0)
        {
            //come on show sum text or smth
        }
    }

    public void TimeToWaterThePlants()
    {
        foreach (var plant in plants)
        {
            plant.enabled = true;
        }
        WateringPlants = true;
        //also put the waterer on the player's hands
    }
}
