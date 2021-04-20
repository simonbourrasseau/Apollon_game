using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public float _moveSpeed = 5f;
    public float _gravity = 9.81f;
    public float _jumpSpeed = 3.5f;
    private int layers = 1;
    private int distance = 1;
    private float _directionY;

    public Animator[] animators;
    public SpriteRenderer spriteRenderer;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        if (!animators[0].GetBool("IsOpen"))
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, 0);

            if (characterController.isGrounded)
            {

                if (Input.GetButtonDown("Jump"))
                {
                    _directionY = _jumpSpeed;
                    animators[1].SetBool("Air", true);
                }
                else
                {
                    animators[1].SetBool("Air", false);
                }

            }

            _directionY -= _gravity * Time.deltaTime;

            direction.y = _directionY;

            characterController.Move(direction * _moveSpeed * Time.deltaTime);

            

            if (Input.GetKeyDown(KeyCode.UpArrow) && layers < 3)
            {
                characterController.Move(Vector3.forward * distance);
                layers += 1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && layers > 1)
            {
                characterController.Move(-Vector3.forward * distance);
                layers--;
            }


            Flip(horizontal);
            animators[1].SetFloat("Vitesse", Mathf.Abs(horizontal));




        }

        void Flip(float horizontal)
        {
            if(horizontal > 0.1f)
            {
                spriteRenderer.flipX = true;

            }else if(horizontal < -0.1f)
            {
                spriteRenderer.flipX = false;
            }
            


        }



}

}
    
