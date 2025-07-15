using UnityEngine;

public class WaterPlant : MonoBehaviour
{
    public void WaterThePlant()
    {
        Variables.PlantsWatered++;
        GameObject.Find("wateringcan").GetComponent<Animator>().SetTrigger("watering");
    }
}
