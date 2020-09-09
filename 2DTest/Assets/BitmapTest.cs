using UnityEngine;


public class BitmapTest : MonoBehaviour
{
    [SerializeField] private Texture2D T2d;
    [SerializeField] private GameObject Sphere_Prefab;

    // Start is called before the first frame update
    void Start()
    {
        test1(T2d);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void test1(Texture2D image)
    {
        for (int i = 0; i < image.width; i++)
        {
            for (int j = 0; j < image.height; j++)
            {
                Color pixel = image.GetPixel(i, j);
                if (pixel != Color.white) { Instantiate(Sphere_Prefab, new Vector3(i, j, 10.0f), Quaternion.identity); }
                Debug.Log(pixel.ToString());
            }
        }
    }

}
