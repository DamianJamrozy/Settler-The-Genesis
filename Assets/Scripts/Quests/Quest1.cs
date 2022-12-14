using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest1 : MonoBehaviour
{
    public static Quest1 Instance;

    public int inQuestCounter = 0;
    private int questNumber = 0;

    public GameObject player;
    public GameObject Item1;
    public TextMeshProUGUI questText;
    public TextMeshProUGUI questInfo;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (inQuestCounter == 4) return;
        else if ( Controller.Instance.questCounter == questNumber )
        {
            if(inQuestCounter == 0)
            {
                questInfo.text = "Przydałoby się zdobyć pierwszą broń, może poszukam kogoś kto byłby w stanie mi w tym pomóc";
                float distance = Vector3.Distance(this.transform.position, player.transform.position);
                if (distance <= 1)
                {
                    questText.text = "Press Q to talk";
                    if(Input.GetKeyDown(KeyCode.Q))
                    {
                        //wypisać coś / dzwięk
                        inQuestCounter = 1;
                        TextWriter.Instance.AddWriter("Czy byłbyś tak miły i pomógłbyś mi odnaleźć mój miecz?", 0.1f);
                    }
                }else questText.text = "";
            }
            else if (inQuestCounter == 1)
            {
                questInfo.text = "Muszę znaleźć miecz ( ͡° ͜ʖ ͡°)";
                float distance = Vector3.Distance(Item1.transform.position, player.transform.position);
                if (distance <= 0.8)
                {
                    questText.text = "Try to pick up this";
                }else questText.text = "";

            }
            else if (inQuestCounter == 2)
            {
                questInfo.text = "Miecz zdobyty teraz tylko udać się do właściciela i liczyć na nagrodę ";
                float distance = Vector3.Distance(this.transform.position, player.transform.position);
                if (distance <= 1)
                {
                    questText.text = "Press Q to talk";
                    if(Input.GetKeyDown(KeyCode.Q))
                    {
                        TextWriter.Instance.AddWriter("Dziękuję, ALE CHWILA TO NIE JEST MÓJ MIECZ..., Ten badziew możesz sobie zostawić.. Słyszałem, że karczmarz coś od Ciebie chce. Zajrzyj do niego.", 0.1f);
                        Controller.Instance.sword.SetActive(true);
                        inQuestCounter = 3;
                    }
                }else questText.text = "";
            }
            if (inQuestCounter == 3)
            {
                questText.text = "";
                Controller.Instance.questCounter = 2;
                inQuestCounter = 4;
            } 
        }
    }
}
