<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;
=======
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
>>>>>>> 7f6ba21916b8b97113b7c9b0a2eb474cb61d23fd

public class RandomizeItemOrder : MonoBehaviour
{
    private int numberOfPossibleItems;
    private const int NUMBER_OF_NPCS = 3;

<<<<<<< HEAD
    private string itemOrder;
=======
    private string item_order = "Order:\n";
>>>>>>> 7f6ba21916b8b97113b7c9b0a2eb474cb61d23fd
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
<<<<<<< HEAD
	numberOfPossibleItems = availableItems.Length;

	AppendToItemOrder("Order", true);
        RandomizeObjects();
	SetOrderText();
=======

        numberOfPossibleItems = availableItems.Length;
        RandomizeObjects();
>>>>>>> 7f6ba21916b8b97113b7c9b0a2eb474cb61d23fd
    }

    private void RandomizeObjects()
    {
        int npcNumber = 0;
        while (npcNumber < NUMBER_OF_NPCS)
        {
<<<<<<< HEAD
            int randomInt = Random.Range(0, availableItems.Length - npcNumber);

            // Setting the item for each NPC also allows their scripts to begin running (avoid race conditions)
            npcArray[npcNumber++].GetComponent<NPCAction>().SetNpcItem(availableItems[randomInt]);

            string nameOfItem = availableItems[randomInt].name;
            AppendToItemOrder(nameOfItem, (npcNumber != 3) ? true : false);
            ShiftArray(randomInt);
        }
=======
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
>>>>>>> 7f6ba21916b8b97113b7c9b0a2eb474cb61d23fd
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
<<<<<<< HEAD
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
=======
            textMeshPro.text = item_order;
        }
    }

}
*/
>>>>>>> 7f6ba21916b8b97113b7c9b0a2eb474cb61d23fd
