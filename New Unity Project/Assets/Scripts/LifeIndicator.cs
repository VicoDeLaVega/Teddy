using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeIndicator : MonoBehaviour {
    public Enemy root;
    public Material material;
    public Material materialLifeIndicator;
    public GameObject gameCamera;
    public float distScale;
    public float distScaleMultipler = 5000;
    Vector3 upVector;
    // Use this for initialization
    void Start () {
     //   root = GetComponent<Enemy>();
//        GameObject lifeIndicatorOriginal = GameObject.Find("EnemyLifeSprite");
 //       lifeIndicator = GameObject.Instantiate<GameObject>(lifeIndicatorOriginal, transform);
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        materialLifeIndicator = meshRenderer.material;
        gameCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update () {
        float lifePointvalue = (float)root.lifePoints / (float)root.originalLifePoints;
        materialLifeIndicator.SetFloat("_Value", lifePointvalue);
        transform.LookAt(gameCamera.transform.position, gameCamera.transform.up);
        float distance = (gameCamera.transform.position - transform.position).magnitude;
        distScale = Mathf.Clamp01(distance / 1000);
        transform.localScale = Vector3.one* distScale * distScaleMultipler;
    }
}
