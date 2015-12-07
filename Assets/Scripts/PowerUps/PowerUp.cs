using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public interface PowerUp
{
    void execute();
    GameObject player { get; set; }
}
