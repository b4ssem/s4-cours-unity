using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string myVar = "TEST";
        Debug.Log(myVar);
        float myFloat = 1.5f;
        Debug.Log(myFloat);
        int[] nombres = new int[] {1, 2, 3, 4};
        Debug.Log(nombres);
        string res = "Bassem";
        Debug.Log(Concat(res));
        int res2 = 5;
        Debug.Log(Multi(res2));
    }

    string Concat(string mot)
    {
        return "Bonjour " + mot;
    }

    int Multi(int nb)
    {
        return nb * nb;
    }

    void Coucou()
    {
        Debug.Log("Coucou !");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Coucou();
        }
    }
}
