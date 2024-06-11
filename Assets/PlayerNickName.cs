using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fusion;

public class PlayerNickName : NetworkBehaviour
{

    [Networked, OnChangedRender(nameof(OnNameChanged))]
    public string PlayerName { get; set; }

    public Text textPlace;

    public void OnNameChanged()
    {
        textPlace.text = PlayerName;
    }

    public void FixedUpdate()
    {
        OnNameChanged();
    }

}
