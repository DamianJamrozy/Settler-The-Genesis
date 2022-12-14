using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest2 : MonoBehaviour
{
    public static Quest2 Instance;

    public int inQuestCounter = 0;
    private int questNumber = 2;

    public Item pizzaSlice;

    public int tomatoCounter = 0;

    public GameObject player;
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
                questInfo.text = "Ten dziwny koleś polecił mi abym udał się do karczmy..";
                float distance = Vector3.Distance(this.transform.position, player.transform.position);
                if (distance <= 1)
                {
                    questText.text = "Press Q to talk";
                    if(Input.GetKeyDown(KeyCode.Q))
                    {
                        inQuestCounter = 1;
                        TextWriter.Instance.AddWriter("O witaj, znalazłbyś dla mnie kilka dorodnych pomidorów, abym mogła skończyć robić pizze?", 0.1f);
                    }
                }else questText.text = "";
            }
            else if (inQuestCounter == 1)
            {
                questInfo.text = "Muszę gdzieś w tej wiosce znaleźć pomidory.";
                questText.text = "Znaleziono: " + tomatoCounter.ToString();
                if(tomatoCounter == 3)
                {
                    inQuestCounter = 2;
                }
            }
            else if (inQuestCounter == 2)
            {
                questInfo.text = "Udało już mi się zebrać wszystkie, pora wrócić do karczmy.";
                float distance = Vector3.Distance(this.transform.position, player.transform.position);
                if (distance <= 1)
                {
                    questText.text = "Press Q to talk";
                    if(Input.GetKeyDown(KeyCode.Q))
                    {
                        inQuestCounter = 3;
                        TextWriter.Instance.AddWriter("Udało się!! Dziękuję. Ale chwila, te pomidory wyglądają jakby skakał po nich słoń.. No nic dzięki za fatygę.", 0.1f);
                        InventoryManager.Instance.Add(pizzaSlice);
                    }
                }else questText.text = "";
            }
            if (inQuestCounter == 3)
            {
                questText.text = "";
                Controller.Instance.questCounter = 3;
                inQuestCounter = 4;
            } 
        }
    }
}
