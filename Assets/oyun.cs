using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class oyun : MonoBehaviour
{


    public Soru[] sorular;
    private static List<Soru> sorulmamisSorular;
    private Soru simdikiSoru;
    public Text Sorutexti;
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Button buttonD;
    public static int DogruSayisi;
    public static int YanlisSayisi;
    // Start is called before the first frame update
    void Start()
    {
        if (sorulmamisSorular == null)
        {
            sorulmamisSorular = sorular.ToList<Soru>();
        }
        
        if (sorulmamisSorular.Count <= 0)
        {
            OyunBitti();
        }
        else
        {
            SoruSor();
        }

    }


    // Update is called once per frame
    void SoruSor()
    {
        int soruIndexi = Random.Range(0, sorulmamisSorular.Count);
        simdikiSoru = sorulmamisSorular[soruIndexi];
        Sorutexti.text = simdikiSoru.soru;
        sorulmamisSorular.RemoveAt(soruIndexi);

        buttonA.GetComponentInChildren<Text>().text = simdikiSoru.A_s;
        buttonB.GetComponentInChildren<Text>().text = simdikiSoru.B_s;
        buttonC.GetComponentInChildren<Text>().text = simdikiSoru.C_s;
        buttonD.GetComponentInChildren<Text>().text = simdikiSoru.D_s;

    }
    public void SecenekA()
    {
        if (simdikiSoru.cevap == 1)
        {
          
            buttonA.GetComponent<Image>().color = Color.green;
            DogruSayisi++;
        }
        else
        {
            buttonA.GetComponent<Image>().color = Color.red;
            YanlisSayisi++;
        }
        StartCoroutine(SonrakiSoru());
    }
    public void SecenekB()
    {
        if (simdikiSoru.cevap == 2)
        {
            buttonB.GetComponent<Image>().color = Color.green;
            DogruSayisi++;
        }
        else
        {
            buttonB.GetComponent<Image>().color = Color.red;
            YanlisSayisi++;
        }
        StartCoroutine(SonrakiSoru());
    }
    public void SecenekC()
    {
        if (simdikiSoru.cevap == 3)
        {
            buttonC.GetComponent<Image>().color = Color.green;
            DogruSayisi++;
        }
        else
        {
            buttonC.GetComponent<Image>().color = Color.red;
            YanlisSayisi++;
        }
        StartCoroutine(SonrakiSoru());
    }
    public void SecenekD()
    {
        if (simdikiSoru.cevap == 4)
        {
            buttonD.GetComponent<Image>().color = Color.green;
            DogruSayisi++;
        }
        else
        {
            buttonD.GetComponent<Image>().color = Color.red;
            YanlisSayisi++;
        }
        StartCoroutine(SonrakiSoru());
    }
    IEnumerator SonrakiSoru()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
    public void OyunBitti()
    {
        buttonA.gameObject.SetActive(false);
        buttonB.gameObject.SetActive(false);
        buttonC.gameObject.SetActive(false);
        buttonD.gameObject.SetActive(false);
        
    }

}
