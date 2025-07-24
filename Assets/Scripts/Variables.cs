using UnityEngine;

public class Variables : MonoBehaviour
{
    public static bool ComputerBooted = false;

    public static bool WateringPlants = false;
    public static int PlantsLeft = 5;
    public static int MessLeft = 2;
    public Interactions[] plants;

    public GameObject wateringCan;

    public TextBoxSystem textBoxSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (WateringPlants && PlantsLeft == 0)
        {
           WateringPlants = false;
           textBoxSystem.Gaem();
        }

        if (MessLeft == 0)
        {
            textBoxSystem.PlantWork();
            MessLeft++;
        }
    }

    public void TimeToWaterThePlants()
    {
        foreach (var plant in plants)
        {
            plant.interactionEnabled = true;
        }
        WateringPlants = true;
        wateringCan.SetActive(true);
    }
}
