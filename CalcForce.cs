class Measure{
    [SerializeField] private float glavity;
    [SerializeField] private float min_measure_rad;
    [SerializeField] private float max_measure_rad;
    [SerializeField] private float measure_torque;
    [SerializeField] private float tape_thickness;
    [SerializeField] private float angular_theta;
    [SerializeField] private float tape_density;
    [SerializeField] private Vector3 init_measure_pos;
    [SerializeField] private Vector3 fulclum_pos;
    [SerializeField] private float angular_vel;
    [SerializeField] private float elevate_vel;
    [SerializeField] private Vector3 current_measure_pos;
    [SerializeField] private Vector3 current_measure_vel;
    [SerializeField] private string game_phase;
    /*
    "title"    -> Title
    "lift"  -> Section 1
    "tilt"     -> Section 2
    "swing"    -> Section 3
    "jump"   -> Section 4
    "gauge" -> Section 5
    "retry"
    */

    public void CalcForce(void)
    {
        
    }
}