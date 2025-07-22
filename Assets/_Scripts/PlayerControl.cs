using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public float motorForce = 800f;            // 가속력
    public float maxSteerAngle = 30f;          // 최대 스티어 각도 (도 단위)
    public float steerSpeed = 90f;              // 바퀴 회전 속도 (도/초)
    public float maxSpeed = 20f;                // 최대 속도 (m/s)
    public float rotationPower = 8f;            //회전 얼마나 빨리 많이 할지
    public Transform[] wheels = new Transform[4];         // 앞 네 바퀴 부모 오브젝트

    private Rigidbody rb;
    private float currentSteerAngle = 0f;       // 현재 바퀴 조향각

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");   // W/S
        float steerInput = Input.GetAxisRaw("Horizontal"); // A/D (Raw는 순간값)

        // 1. 스티어 각도 업데이트 (A/D 누르면 바퀴 최대각도까지 회전)
        if (steerInput != 0)
        {
            currentSteerAngle += steerInput * steerSpeed * Time.fixedDeltaTime;
            currentSteerAngle = Mathf.Clamp(currentSteerAngle, -maxSteerAngle, maxSteerAngle);
        }
        else
        {
            // 스티어 입력 없으면 바퀴 각도 원위치로 부드럽게 돌아오게
            currentSteerAngle = Mathf.MoveTowards(currentSteerAngle, 0, steerSpeed * Time.fixedDeltaTime);
        }

        // 2. 앞바퀴 시각적 회전 (부모 오브젝트로 한 번에 회전)
        foreach(Transform item in wheels)
        {
            item.localRotation = Quaternion.Euler(0, currentSteerAngle, 0);
        }

        // 3. 차량 회전 (바퀴 조향각에 따라 차체가 서서히 방향 틀기)
        float speed = Vector3.Dot(rb.velocity, transform.forward);
        if (Mathf.Abs(speed) > 0.1f)
        {
            float turn = speed / maxSpeed * currentSteerAngle;  // 속도 비례해서 회전 각도 조절
            Quaternion turnRotation = Quaternion.Euler(0, turn * Time.fixedDeltaTime * rotationPower, 0);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        // 4. 이동은 W/S 입력 있을 때만 앞으로 힘 가하기
        if (moveInput != 0 && rb.velocity.magnitude < maxSpeed)
        {
            Vector3 force = transform.forward * moveInput * motorForce * Time.fixedDeltaTime;
            rb.AddForce(force);
        }
    }
}
