using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditsBehaviour : MonoBehaviour
{
    [SerializeField] TextAsset creditsText;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = creditsText.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
