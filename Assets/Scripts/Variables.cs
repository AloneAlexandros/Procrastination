using UnityEngine;

public class Variables : MonoBehaviour
{
    public static bool ComputerBooted = false;

    public static bool WateringPlants = false;
    public static int PlantsWatered = 0;
    public Interactions[] plants;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (WateringPlants && plants.Length == PlantsWatered)
        {
            //do something important here
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
