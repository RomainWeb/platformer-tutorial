using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int cherriesCount;
    public Text cherriesCountText;

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Inventory already exist on scene");
        }

        instance = this;
    }

    public void AddCherries (int count)
    {
        cherriesCount += count;
        cherriesCountText.text = cherriesCount.ToString();
    }
}
