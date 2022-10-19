using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Line : MonoBehaviour
{

    public GameObject gameObject1;         
    public GameObject gameObject2;
    public GameObject arrow;
    public Text label;
    public Material materiale;
    private float dirRx, dirRy;
    private LineRenderer line; 

    private Color color = Color.black;

    [System.Obsolete]
    void Start()
    {
        line = this.gameObject.AddComponent<LineRenderer>();
        line.SetWidth(0.05F, 0.05F);
        line.SetVertexCount(2);
        line.startColor = color;
        line.endColor = color;
        line.sortingLayerName = "BackGround";
        line.sortingOrder = 10;
        line.material = materiale;
      
       

    }


    
    void Update()
    {
      
        if (gameObject1 != null && gameObject2 != null)
        {
        
                line.SetPosition(0, gameObject1.transform.position);
                line.SetPosition(1, gameObject2.transform.position);
          

                dirRx = gameObject1.transform.position.x - gameObject2.transform.position.x;
                dirRy = gameObject1.transform.position.y - gameObject2.transform.position.y;
                arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(-dirRx, dirRy) * Mathf.Rad2Deg));


        }
    }
}