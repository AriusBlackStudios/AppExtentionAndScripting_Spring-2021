using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
	bool showInventory = false;
	public Rect inventoryRect = new Rect(Screen.width / 2, Screen.height / 2, 400, 400);
	public GameObject EmptyObject;
	public int InventorySize;
	public Item[] invItems;
	public Item[] QuickItems;
	public PlayerController player;
	

	//List<Item> items = new List<Item>();

	
	void InitializeInventory()
	{
		invItems = new Item[InventorySize];
        QuickItems = new Item[4];
		for(int i = 0; i < InventorySize; i++)
		{
			invItems[i] = new Item(EmptyObject,0);
			//items.Add(invItems[i]);
			
			if(i < QuickItems.Length)
				QuickItems[i] = invItems[i];
		}
	}

	void AddToInventory(int HowMany, GameObject NewItem)
	{
		for(int i = 0; i < invItems.Length; i++)
		{
			if(invItems[i].Name != "Empty")
			{
				if(invItems[i].Name == NewItem.name)
				{
					int val = invItems[i].Quantity + HowMany;
                    invItems[i].Quantity = val;
					Debug.Log(invItems[i]);
					break;
				}
			}
			else
			{
                
                Item it = new Item(NewItem, HowMany);
               // items.Add(it);
                invItems[i] = it;
				Debug.Log(invItems[i]);
				
				break;
			}

			
		}
        for (int j = 0; j < QuickItems.Length; j++)
            SetQuickItem(invItems[j], j);
    }

	void RemoveFromInventory(int HowMany, Item Item)
	{
		for(int i = 0; i < invItems.Length; i++)
		{
			if(invItems[i].Name != "Empty")
			{
				if(invItems[i].Name == Item.Name)
				{
					invItems[i].Quantity -= HowMany;
					useItem(Item);
					
					if(invItems[i].Quantity <= 0)
					{
                        invItems[i] = new Item(EmptyObject, 0);
                    }
					break;
				}
			}
		}
        for (int j = 0; j < QuickItems.Length; j++)
            SetQuickItem(invItems[j], j);
    }

	void useItem(Item Item)
    {
		//health potions
		if(Item.Name == "Large Health")
        {
			player.HealPlayer(50f);
			player.healthPotions++;
        }
		else if (Item.Name == "Medium Health")
		{
			player.HealPlayer(20f);
			player.healthPotions++;
		}
		else if (Item.Name == "Small Health")
		{
			player.HealPlayer(10f);
			player.healthPotions++;
		}


		//mana potions
		if (Item.Name == "Large Mana")
		{
			player.RecoverMana(50f);
			player.manaPotions++;
		}
		else if (Item.Name == "Medium Mana")
		{
			player.RecoverMana(20f);
			player.manaPotions++;
		}
		else if (Item.Name == "Small Mana")
		{
			player.RecoverMana(10f);
			player.manaPotions++;
		}
	}

    void SetQuickItem(Item NewItem, int QuickInput)
    {
        if (QuickItems[QuickInput].Name != NewItem.Name)
            if (QuickInput < QuickItems.Length)
                QuickItems[QuickInput] = NewItem;
    }

    void Awake()
	{
		InitializeInventory();
		player = FindObjectOfType<PlayerController>();
	}

	void Update()
	{
		if(Input.GetAxis("Inventory")>0)
		{
			showInventory = (showInventory) ? false : true;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		int invAmount = 1;
		if(col.gameObject.tag.Equals("InventoryItem"))
		{
			Debug.Log("Collect one " + col.gameObject.name);
			if(col.gameObject.name.Equals("GroupInventoryItem")){
				invAmount = col.gameObject.GetComponent<GroupInventoryAmount>().amount;
			}

			AddToInventory(invAmount, col.gameObject);
			col.gameObject.SetActive(false);
		}
	}
	
	void OnGUI()
	{
		if(showInventory)
		{
			inventoryRect = GUI.Window(0, inventoryRect, InventoryGUI, "Inventory");
		}
	}
	
	void InventoryGUI(int ID)
	{
		GUILayout.BeginArea(new Rect(0, 50, 400, 400));

		GUILayout.BeginHorizontal();
        if (GUILayout.Button(invItems[0].ToString(), GUILayout.Height(75)))
        {
            RemoveFromInventory(1, invItems[0]);
        }
        //GUILayout.Button(itemCount[0].Value.ToString() + " " + invItems[0].name, GUILayout.Height(75));
       if( GUILayout.Button(invItems[1].ToString() , GUILayout.Height(75)))
			{
			RemoveFromInventory(1, invItems[1]);
		}
		GUILayout.Button(invItems[2].ToString() , GUILayout.Height(75));
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		GUILayout.Button(invItems[3].ToString(), GUILayout.Height(75));
		GUILayout.Button(invItems[4].ToString() , GUILayout.Height(75));
		GUILayout.Button(invItems[5].ToString() , GUILayout.Height(75));
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		GUILayout.Button(invItems[6].ToString() , GUILayout.Height(75));
		GUILayout.Button(invItems[7].ToString() , GUILayout.Height(75));
		GUILayout.Button(invItems[8].ToString() , GUILayout.Height(75));
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		GUILayout.Button(QuickItems[0].Name, GUILayout.Height(50));
		GUILayout.Button(QuickItems[1].Name, GUILayout.Height(50));
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Button(QuickItems[2].Name, GUILayout.Height(50));
		GUILayout.Button(QuickItems[3].Name, GUILayout.Height(50));
		GUILayout.EndHorizontal();

		GUILayout.EndArea();
	}
}