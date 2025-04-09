using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class Board : MonoBehaviour
{
    public GameObject card;
    GameObject[] cards;

    private void Start()
    {
        cards = new GameObject[GameManager.instance.maxCardNum];

        int[] arr = new int[GameManager.instance.maxCardNum];
        for (int i = 0, num = 0; i < arr.Length; i += 2, num++)
        {
            arr[i] = num;
            arr[i + 1] = num;
        }
        arr = arr.OrderBy(x => Random.value).ToArray();

        for(int i = 0; i < arr.Length; i++)
        {
            cards[i] = Instantiate(card, transform);
            cards[i].GetComponent<Card>().InitImage(arr[i]);
        }
    }

    public void ThrowAllCard()
    {
        foreach (GameObject c in cards) 
        {
            c.GetComponent<Card>().ThrowCardAnim();
        }
    }
 }
