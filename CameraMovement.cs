using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    // Update is called once per frame
    void Update ()
    {
        Cursor.visible = false;
        // you'll have to create a new input axis named "UpDown" with controls of your choosing, but here it is shown with SPACE (for positive)/CRTL (for negative)
        // you'll also have to create another input axis named "Roll", with recommended values of E (positive) and Q (negative)
        WASDMovement(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), Input.GetAxis("UpDown")); // WASD and Space/CRTL input for FWD, BWD, L, R, UP, DOWN
        MouseRotation(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y")); // Mouse input for pitch and yaw
        PitchRotation(Input.GetAxis("Roll"));
	}

    private void WASDMovement(float f, float r, float u) // f is forward/backward axis input, r is right/left axis input, u is up/down axis input
    {
        Vector3 curFDirection = transform.forward; // current forward, right, and up directions of tranform with respect to rotation
        Vector3 curRDirection = transform.right;
        Vector3 curUDirection = transform.up;
        Vector3 curPosition = transform.position; // current position 
        // to avoid use of lots of IF statements, multiply axis value by respective direction vector and sum to get movement
        // when axis value is 0, there will be no movement in that direction
        transform.position = curPosition + (f * curFDirection) + (r * curRDirection) + (u * curUDirection);
    }

    private void MouseRotation(float x, float y) // mouse axis inputs
    {
        Vector3 rotationVector = (x * Vector3.up) + (y * Vector3.left); // up vector for yaw rotation, negative right vector for pitch rotation
        transform.Rotate(rotationVector);
    }

    private void PitchRotation(float c) // q and e roll inputs 
    {
        Vector3 rotationVector = c * Vector3.back; // negative forward vector for roll
        transform.Rotate(rotationVector);
    }

}
