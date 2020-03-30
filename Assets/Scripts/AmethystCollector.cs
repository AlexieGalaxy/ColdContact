using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmethystCollector : MonoBehaviour
{
    private float amethystCount = 0;

    public TextMeshProUGUI textAmethysts;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Amethyst") {

            Amethyst amethyst = collider.gameObject.GetComponent<Amethyst>();

            if (!amethyst.collected)
            {
                amethystCount++;
                textAmethysts.text = "x " + amethystCount.ToString();

                Destroy(collider.gameObject);
            }

            amethyst.collected = true;
        }
    }
}
