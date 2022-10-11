using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] Transform startZone;
    [SerializeField] Transform deathZone;
    [SerializeField] private InputField timeBirth;
    [SerializeField] private InputField speed;
    [SerializeField] private InputField range;
    private Vector3 startPosition, stopPosition;
    private float timer;

    private void Start()
    {
        //StartTimer = Convert.ToInt32(timeBirth.text);
        startPosition = startZone.position;
        stopPosition = deathZone.position;
        timer = Convert.ToInt32(timeBirth.text);
    }

    private GameObject BirthCube()
    {
        GameObject cloneCube;
        cloneCube = Instantiate(cube, startPosition, Quaternion.identity);
        return (cloneCube);
    }


    private void MoveCubes(GameObject A, InputField S)
    {
        float s = Convert.ToInt32(S.text);
        Vector3 B = new Vector3(0, 0, s);

        A.GetComponent<Rigidbody>().AddForce(B,ForceMode.Impulse);
    }

    private void Timer()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            
            MoveCubes(BirthCube(),speed);
            timer = Convert.ToInt32(timeBirth.text);
        }
    }
    private void Range()
    {
        float r = Convert.ToInt32(range.text);
        stopPosition.z = startPosition.z + r;
        deathZone.position = stopPosition;

    }

    private void Update()
    {
        Timer();
        Range();
    }
}
