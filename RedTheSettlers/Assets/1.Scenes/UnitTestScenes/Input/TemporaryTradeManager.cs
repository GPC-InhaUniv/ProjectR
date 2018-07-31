using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryTradeManager : Singleton<TemporaryTradeManager>
{
    TemporaryTradeManager tempTradeManager;

    private void Start()
    {
        tempTradeManager = this;
    }

    public void Trade(Vector3 position)
    {

    }
}
