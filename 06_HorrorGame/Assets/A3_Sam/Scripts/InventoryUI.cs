using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{

    private TextMeshProUGUI collectableText;
    // Start is called before the first frame update
    void Start()
    {
        collectableText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateCollecableText(PlayerInventory playerInventory)
    {
        collectableText.text = playerInventory.NumberOfCollectables.ToString();
    }
}
