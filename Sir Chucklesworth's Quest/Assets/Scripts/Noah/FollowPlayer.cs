using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject Player;

    private void LateUpdate()
    {
        if(Player != null)
        {
            transform.position = Player.transform.position + new Vector3(0, 0, -10f);
        }
    }
}
