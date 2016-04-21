using UnityEngine;
using System.Collections;

public class ScoreShowerBehaviour : MonoBehaviour {
    private TextMesh ownText;

    void Start()
    {
        ownText = GetComponent<TextMesh>();
        VarsController.Instance.scoreShower = this;
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Translate(0,0.01f,0);
    }

    void OnEnable()
    {
        StartCoroutine("destroyAfterSeconds",1);
    }

    public void ActivateScoreShow(float Score)
    {
        transform.localPosition = new Vector3(0, 0, 0);
        ownText.text = Score.ToString();
        gameObject.SetActive(true);

    }

    private IEnumerator destroyAfterSeconds(int lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

}
