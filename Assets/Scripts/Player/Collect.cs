using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Collect : MonoBehaviour
{

    [Header ("Collectibles")]
   public TMP_Text countText;
   public int count;
   public float delay;

   [Header ("Key")]
   public Color32 keyOff;
   public Color32 keyOn;
   public RawImage keyIMG;
   public bool isKey; //tiene la llave?
    

//----------------------------------------------------------//
    private void Start()
    {
        count = 0;

        keyIMG.color = keyOff;
        isKey = false;
    }

    private void Update()
    {
        SetCountText();
    }

//--------------------------------------------------------//

    private void SetCountText()
    {
        countText.text = count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            //Collider col = other.gameObject.GetComponent<SphereCollider>();
            //col.enabled = false;
            StartCoroutine(DeactivateWithDelay(other.gameObject, delay));
            count ++;
        }

        if (other.gameObject.tag == "Key")
        {
            keyIMG.color = keyOn;
            isKey = true;
            other.gameObject.SetActive(false);
        }
    }

    private IEnumerator DeactivateWithDelay (GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }
}
