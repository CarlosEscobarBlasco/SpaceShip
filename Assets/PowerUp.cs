using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public interface PowerUp
{
    void execute();
    Sprite icon { get; set; }
    GameObject player { get; set; }
}
