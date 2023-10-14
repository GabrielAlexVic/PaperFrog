using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonManager : MonoBehaviour
{
    public Upgrade[] upgrades;

    // Start is called before the first frame update
    void Start()
    {
        ArrangeUpgradeButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ArrangeUpgradeButtons()
    {
        float xOffset = 0f;

        for (int i = 0; i < upgrades.Length; i++)
        {
            Button button = upgrades[i].buyButton;

            if (upgrades[i].IsBought == 0)
            {
                Vector3 newPosition = button.transform.position;
                newPosition.x = xOffset;
                button.transform.position = newPosition;

                xOffset += button.GetComponent<RectTransform>().rect.width + 10f;
            }
            else
            {
                button.gameObject.SetActive(false);
            }
        }
    }
}
