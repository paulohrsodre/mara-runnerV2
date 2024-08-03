using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public float speed = 5f;
    [SerializeField] Rigidbody rigidBody;
    float verticalInput;
    [SerializeField] float verticalMultiplier = 2;
    public float speedIncreasePerPoint = 0.1f;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;
    [SerializeField] Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() 
    {
        if (!alive) return;

        Vector3 rightMove = transform.right * speed * Time.fixedDeltaTime;
        Vector3 verticalMove = transform.forward * verticalInput * speed * Time.fixedDeltaTime * verticalMultiplier;
        rigidBody.MovePosition(rigidBody.position + rightMove + verticalMove);
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        CheckIfGrounded();

        if(Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }

        animator.SetBool("IsJumping", !isGrounded);
    }

    public void Die()
    {
        alive = false;
        animator.SetBool("IsHitting", true);

        StartCoroutine(HandleDeathAnimations());
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        rigidBody.AddForce(Vector3.up * jumpForce);
    }

    void CheckIfGrounded()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
    }
    
    private IEnumerator HandleDeathAnimations()
{
    // Espera a duração da animação de Hit
    yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

    // Desativa a animação de Hit e ativa a de Stun
    animator.SetBool("IsHitting", false);
    animator.SetBool("IsStunned", true);

    // Se necessário, reinicia o jogo após um tempo específico
    Invoke(nameof(Restart), 2); // Ajuste o tempo conforme necessário
}
}
