using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArangeElements : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textElement;
    public Transform hand;
    void Start()
    {
        // transform.position+=hand.transform.position;
        if(textElement){
            Debug.Log(transform.localScale.x);
            Debug.Log(GetComponent<SphereCollider>().radius);
        CreateEnemiesAroundPoint(27,transform.position,GetComponent<SphereCollider>().radius);
        }
    }

 
 public void CreateEnemiesAroundPoint (int num, Vector3 point, float radius) {
    List<string> alphabets =new List<string>(new string[] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","Clear"});//Space

        List<Vector3> upts = new List<Vector3>();
            float inc = Mathf.PI * (3 - Mathf.Sqrt(5));
            float off = 2.0f / num;
            float x = 0;
            float y = 0;
            float z = 0;
            float r = 0;
            float phi = 0;
    for (var k = 0; k < num; k++){
                y = k * off - 1 + (off /2);
                r = Mathf.Sqrt(1 - y * y);
                phi = k * inc;
                x = Mathf.Cos(phi) * r;
                z = Mathf.Sin(phi) * r;
            var spawnDir = new Vector3 (x, z, y);
            
            /* Get the spawn position */ 
            var spawnPos = point + spawnDir * radius; // Radius is just the distance away from the point
            
            /* Now spawn */
            var elements = Instantiate (textElement, spawnPos, transform.rotation,transform) as GameObject;
            elements.SetActive(true);
            /* Rotate the enemy to face towards player */
            elements.transform.LookAt(point);
            elements.GetComponent<ChangeText>().textComponent.text=alphabets[k];
            
            /* Adjust height */
            elements.transform.Translate (new Vector3 (0, elements.transform.localScale.y / 2, 0));
       }
       
        
         
         
 }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
