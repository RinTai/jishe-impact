using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    bool isClosed;
    public GameObject bag;

    public void OpenCloseBag()
    {
        if (isClosed == true)//����������ڹر�״̬
        {
            bag.SetActive(true);
            isClosed = false;
        }
        else if(isClosed == false)
        {
            bag.SetActive(false);
            isClosed = true;
        }
    }
}
