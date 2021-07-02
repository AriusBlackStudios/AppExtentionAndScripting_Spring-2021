using UnityEngine;
using System.Collections;
using System.Collections.Generic;


    public class Item
    {
    private int quantity;
    private GameObject go;
    private string name;
    public Item( GameObject g, int q)
    {
        go = g; ;
        quantity = q;
        name = g.name;
    }

    public GameObject Go
    {
        get { return go; }
        set { go = value; }
    }
    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public override string ToString()
    {
        return go.name + " " + quantity + "\n";
    }



}

