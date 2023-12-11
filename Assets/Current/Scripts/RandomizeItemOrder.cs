using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;

public class RandomizeItemOrder : MonoBehaviour
{
    private int numberOfPossibleItems;
    private const int NUMBER_OF_NPCS = 3;

    private string itemOrder;
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

	AppendToItemOrder("Order", true);
        RandomizeObjects();
	SetOrderText();
    }

    private void RandomizeObjects()
    {
        int npcNumber = 0;
        while (npcNumber < NUMBER_OF_NPCS)
        {
            int randomInt = Random.Range(0, availableItems.Length - npcNumber);

            // Setting the item for each NPC also allows their scripts to begin running (avoid race conditions)
            npcArray[npcNumber++].GetComponent<NPCAction>().SetNpcItem(availableItems[randomInt]);

            string nameOfItem = availableItems[randomInt].name;
            AppendToItemOrder(nameOfItem, (npcNumber != 3) ? true : false);
            ShiftArray(randomInt);
        }
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
            textMeshPro.text = itemOrder;
        }
    }

    private void AppendToItemOrder(string key, bool nl)
    {
	string itemName = LocalizationSettings.StringDatabase.GetLocalizedStringAsync(key).Result;
	itemName = (nl) ? itemName + "\n" : itemName;
	itemOrder += itemName;
    }

}