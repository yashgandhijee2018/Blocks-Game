using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube1 : MonoBehaviour
{
    Rigidbody body;
    public int score=0;
    Vector3 velocity;
    int speed = 6;
    bool k = true;
    // Start is called before the first frame update

    public TextMesh tm;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        tm = (TextMesh)GameObject.Find("score").GetComponent<TextMesh>();
        tm.text = "--";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        Vector3 velocity = v * speed;
        //Vector3 disp = velocity * Time.deltaTime;
        //transform.Translate(disp);
        Vector3 disp = velocity * Time.deltaTime;
        body.position += disp;

        tm = (TextMesh)GameObject.Find("score").GetComponent<TextMesh>();
        tm.text = (score * 10).ToString();
    }
    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="coin tag")
        {
            Destroy(other.gameObject);
            score++;
            body.transform.localScale += new Vector3(0.1f,0.1f,0.1f);
            MaterialPropertyBlock props = new MaterialPropertyBlock();
            if (k == true)
            {
                props.AddColor("_Color", Color.green);
                k = false;
                GetComponent<Renderer>().SetPropertyBlock(props);
            }
            else
            {
                props.AddColor("_Color", Color.blue);
                k = true;
                GetComponent<Renderer>().SetPropertyBlock(props);
            }
            
        }
    }
}
