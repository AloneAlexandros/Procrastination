using UnityEngine;
using UnityEngine.Serialization;

public class Actions : MonoBehaviour
{
    [FormerlySerializedAs("Sheet")] [SerializeField] private GameObject sheet;
    public void WaterThePlant()
    {
        Variables.PlantsLeft--;
        GameObject.Find("wateringcan").GetComponent<Animator>().SetTrigger("watering");
    }

    public void ClearTheMess()
    {
        Variables.MessLeft--;
        Destroy(this.gameObject);   
    }

    public void MakeTheBed()
    {
        sheet.SetActive(true);
        ClearTheMess();
    }
}
