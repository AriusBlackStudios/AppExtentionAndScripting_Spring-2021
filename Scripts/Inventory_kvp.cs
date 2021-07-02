using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory_kvp : MonoBehaviour
{
    bool showInventory = false;
    public Rect inventoryRect = new Rect(Screen.width / 2, Screen.height / 2, 400, 400);
    public GameObject EmptyObject;
    public int InventorySize;
    public GameObject[] invItems;
    public GameObject[] QuickItems;

    List<KeyValuePair<int, GameObject>> items = new List<KeyValuePair<int, GameObject>>();

    List<KeyValuePair<int, int>> itemCount = new List<KeyValuePair<int, int>>();


    //called on awake, before start
    void InitializeInventory()
    {
        invItems = new GameObject[InventorySize];
        for (int i = 0; i < InventorySize; i++)
        {
            //makes everything in the inventory read Empty
            invItems[i] = EmptyObject;
            items.Add(new KeyValuePair<int, GameObject>(i, invItems[i]));
            itemCount.Add(new KeyValuePair<int, int>(i, 0));

            if (i < QuickItems.Length)
                QuickItems[i] = invItems[i];
        }
    }

    void AddToInventory(int HowMany, GameObject NewItem)
    {

        for (int i = 0; i < invItems.Length; i++)
        {
            if (invItems[i].name != "Empty")
            {
                if (invItems[i].name == NewItem.name)
                {
                    int val = itemCount[i].Value + HowMany;
                    itemCount[i] = new KeyValuePair<int, int>(itemCount[i].Key, val);
                    Debug.Log(items[i].Key + ": " + items[i].Value.name);
                    Debug.Log(itemCount[i].Key + ": " + itemCount[i].Value);
                    break;
                }
            }
            else
            {
                int val = itemCount[i].Value + HowMany;
                invItems[i] = NewItem;
                items[i] = new KeyValuePair<int, GameObject>(i, NewItem);
                itemCount[i] = new KeyValuePair<int, int>(i, val);
                //items.Add(new KeyValuePair<int, GameObject>(i, NewItem));
                //itemCount.Add(new KeyValuePair<int, int>(i, val));
                Debug.Log(items[i].Key + ": " + items[i].Value.name);
                Debug.Log(itemCount[i].Key + ": " + itemCount[i].Value);
                break;
            }
          
        }
        for (int j = 0; j < QuickItems.Length; j++)
            SetQuickItem(invItems[j], j);
         
    }

    void RemoveFromInventory(int HowMany, GameObject Item)
    {
        for (int i = 0; i < items.Capacity; i++)
        {
            if (invItems[i].name != "Empty")
            {
                if (invItems[i].name == Item.name)
                {
                    int val = itemCount[i].Value - HowMany;
                    itemCount[i] = new KeyValuePair<int, int>(itemCount[i].Key, val);
                    if (itemCount[i].Value <= 0)
                    {
                        invItems[i] = EmptyObject;
                        items[i] = new KeyValuePair<int, GameObject>(i, EmptyObject);
                        itemCount[i] = new KeyValuePair<int, int>(itemCount[i].Key, 0);
                    }
                    break;
                }
            }
        }
    }

    void SetQuickItem(GameObject NewItem, int QuickInput)
    {
        if (QuickItems[QuickInput].name != NewItem.name)
            if (QuickInput < QuickItems.Length)
                QuickItems[QuickInput] = NewItem;
    }

    void Awake()
    {
        InitializeInventory();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            showInventory = (showInventory) ? false : true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        int invAmount = 1;
        if (col.gameObject.tag.Equals("InventoryItem"))
        {
            Debug.Log("Collect one " + col.gameObject.name);
            if (col.gameObject.name.Equals("GroupInventoryItem"))
            {
                invAmount = col.gameObject.GetComponent<GroupInventoryAmount>().amount;
            }

            AddToInventory(invAmount, col.gameObject);
            col.gameObject.SetActive(false);
        }
    }

    void OnGUI()
    {
        if (showInventory)
        {
            inventoryRect = GUI.Window(0, inventoryRect, InventoryGUI, "Inventory");
        }
    }

    void InventoryGUI(int ID)
    {
        GUILayout.BeginArea(new Rect(0, 50, 400, 400));

        GUILayout.BeginHorizontal();
        if (GUILayout.Button(itemCount[0].Value.ToString() + " " + invItems[0].name, GUILayout.Height(75)))
        {
            RemoveFromInventory(1, invItems[0]);
        }
        //GUILayout.Button(itemCount[0].Value.ToString() + " " + invItems[0].name, GUILayout.Height(75));
        GUILayout.Button(itemCount[1].Value.ToString() + " " + invItems[1].name, GUILayout.Height(75));
        GUILayout.Button(itemCount[2].Value.ToString() + " " + invItems[2].name, GUILayout.Height(75));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Button(itemCount[3].Value.ToString() + " " + invItems[3].name, GUILayout.Height(75));
        GUILayout.Button(itemCount[4].Value.ToString() + " " + invItems[4].name, GUILayout.Height(75));
        GUILayout.Button(itemCount[5].Value.ToString() + " " + invItems[5].name, GUILayout.Height(75));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Button(itemCount[6].Value.ToString() + " " + invItems[6].name, GUILayout.Height(75));
        GUILayout.Button(itemCount[7].Value.ToString() + " " + invItems[7].name, GUILayout.Height(75));
        GUILayout.Button(itemCount[8].Value.ToString() + " " + invItems[8].name, GUILayout.Height(75));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Button(QuickItems[0].name, GUILayout.Height(50));
        GUILayout.Button(QuickItems[1].name, GUILayout.Height(50));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Button(QuickItems[2].name, GUILayout.Height(50));
        GUILayout.Button(QuickItems[3].name, GUILayout.Height(50));
        GUILayout.EndHorizontal();

        GUILayout.EndArea();
    }
}