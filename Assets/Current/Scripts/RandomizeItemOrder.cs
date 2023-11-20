/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomizeItemOrder : MonoBehaviour
{
    private int numberOfPossibleItems;
    private const int NUMBER_OF_NPCS = 3;

    private string item_order = "Order:\n";
    [SerializeField] public GameObject orderTextBox;

    [SerializeField] public GameObject[] npcArray;
    [SerializeField] public GameObject[] availableItems;

    // Start is called before the first frame update
    void Start()
    {
        if (availableItems == null)
        {
            return;
        }

        numberOfPossibleItems = availableItems.Length;
        RandomizeObjects();
    }

    private void RandomizeObjects()
    {
        int npcNumber = 0;
        while (npcNumber < NUMBER_OF_NPCS)
        {
            int randomInt = Random.Range(0, NUMBER_OF_NPCS - npcNumber);
            // Setting the item for each NPC also allows their scripts to begin running (avoid race conditions)
            npcArray[npcNumber++].GetComponent<NPCAction>().SetNpcItem(availableItems[randomInt]);
            item_order += availableItems[randomInt].name;
            if (npcNumber != 3)
            {
                item_order += "\n";
            }
            ShiftArray(randomInt);
        }

        SetOrderText();
    }

    private void ShiftArray(int indexRemoved)
    {
        for (int i = indexRemoved; i < numberOfPossibleItems - 1; i++)
        {
            availableItems[i] = availableItems[i + 1];
        }
        numberOfPossibleItems--;
    }

    private void SetOrderText()
    {
        TextMeshProUGUI textMeshPro = orderTextBox.GetComponent<TextMeshProUGUI>();
        if (textMeshPro != null)
        {
            textMeshPro.text = item_order;
        }
    }

}
*/