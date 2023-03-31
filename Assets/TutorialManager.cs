using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public PlayableDirector TutorialTimeline;
    public PlayableDirector EncounterTimeline;


    public Camera cam;
    public GameObject target1;
    public GameObject check1;
    public GameObject target2;
    public GameObject check2;
    private bool checkTarget1 = false;
    private bool checkTarget2 = false;

    public bool tutorialOver = false;

    public Image TutorialImage1;
    public Sprite TutorialImage2;

    public Animator animator;



    private bool IsVisible(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;

        foreach(var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }
        return true;
    }

    public void changeScene()
    {
        SceneManager.LoadScene("LisaScene");
    }

    void Start()
    {
        check1.SetActive(false);
        check2.SetActive(false);
    }
    // Update is called once per frame
    private void Update()
    {
        var targetRender1 = target1.GetComponent<Renderer>();
        var targetRender2 = target2.GetComponent<Renderer>();

        if (tutorialOver == false)
        {

            if (IsVisible(cam, target1))
            {
                //targetRender1.material.SetColor("_Color", Color.red);
                check1.SetActive(true);
                checkTarget1 = true;
                StartCoroutine(BriefCheck1());


            }
            else if (IsVisible(cam, target2))
            {
                //targetRender2.material.SetColor("_Color", Color.red);
                check2.SetActive(true);
                checkTarget2 = true;
                StartCoroutine(BriefCheck2());
            }

            if (checkTarget1 == true && checkTarget2 == true)
            {
                tutorialOver = true;
                TutorialImage1.sprite = TutorialImage2;
                Destroy(TutorialImage1, 8);
                Debug.Log("Tutorial Over");
                TutorialTimeline.Stop();
                EncounterTimeline.Play();
            }
        }
    }

        IEnumerator BriefCheck1()
    {        
        yield return new WaitForSeconds(3);
        check1.SetActive(false);
    }

    IEnumerator BriefCheck2()
    {
        yield return new WaitForSeconds(3);
        check2.SetActive(false);
    }

    public void fadeOut()
    {
        animator.SetTrigger("FadeOut");
    }

}
