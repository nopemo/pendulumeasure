using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Makijaku : MonoBehaviour
{
    [SerializeField] private string game_section = "title";
    // the valuables whick are changed in the inspector window
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private float torque = 10.0f;
    [SerializeField] private float max_length = 10.0f;
    [SerializeField] private float min_length = 1.0f;
    [SerializeField] private float thickness = 0.1f;
    [SerializeField] private float init_radius = 0.1f;
    [SerializeField] private float init_mass = 1.0f;
    [SerializeField] private float density = 1.0f;
    [SerializeField] private Vector3 mass_center_pos = new Vector3(0.0f, 0.0f, 0.0f);
    [SerializeField] private Vector3 tape_exit_pos = new Vector3(0.0f, 0.0f, 0.0f);
    [SerializeField] private Vector3 pillar_pos = new Vector3(0.0f, 0.0f, 0.0f);
    [SerializeField] private Vector3 current_pos = new Vector3(0.0f, 0.0f, 0.0f);
    [SerializeField] private Vector3 current_vel = new Vector3(0.0f, 0.0f, 0.0f);
    [SerializeField] private current_theta = 0.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


}
