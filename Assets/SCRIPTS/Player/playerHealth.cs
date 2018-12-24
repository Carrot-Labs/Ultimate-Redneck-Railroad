using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {

    public int health = 0;

    public int getHealth()
    {
        return health;
    }

    public void setHealth(int h)
    {
        health = h;
    }

}
