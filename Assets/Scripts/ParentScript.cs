using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ParentScript : MonoBehaviour
{
    public float pos = 1f;

    private GameObject[] children;

    void Start()
    {
        children = new GameObject[10];

        for (int i = 0; i < children.Length; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            float randomY = Random.Range(0.2f, 2.0f);
            cube.transform.localScale = new Vector3(1, randomY, 1);
            cube.transform.parent = this.transform;
            children[i] = cube;
        }

        BubbleSort(children);

        for (int i = 0; i < children.Length; i++)
        {
            children[i].transform.localPosition = new Vector3(i * pos, 0, 0);
        }
    }

    void BubbleSort(GameObject[] objects)
    {
        int n = objects.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                float heightA = objects[j].transform.localScale.y;
                float heightB = objects[j + 1].transform.localScale.y;

                if (heightA > heightB)
                {
                    GameObject temp = objects[j];
                    objects[j] = objects[j + 1];
                    objects[j + 1] = temp;
                }
            }
        }
    }

}




