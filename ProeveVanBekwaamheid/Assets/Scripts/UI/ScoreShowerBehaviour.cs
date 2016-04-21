using UnityEngine;
using System.Collections;

public class ScoreShowerBehaviour : MonoBehaviour {
    private TextMesh ownText;

    void Start()
    {
        ownText = GetComponent<TextMesh>();
        VarsController.Instance.scoreShower = this;
    }

    void Update()
    {
        transform.Translate(0,0.01f,0);
    }

    void OnEnable()
    {
        StartCoroutine("destroyAfterSeconds");
    }

    private IEnumerator destroyAfterSeconds(int lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        transform.localPosition = new Vector3(0,0,0);
        gameObject.SetActive(false);
    }

}
