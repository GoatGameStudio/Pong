using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CamerGlitch : MonoBehaviour
{
    public Material glitchMaterial;
    public TextMeshProUGUI score1, score2;
    private bool isRotating = false;
    private bool isRotated = false;
    private float rotationTimer = 0f;

    void Update()
    {
        if (!isRotating)
        {
            if (Time.time % 30 < 0.5f)
            {
                ApplyGlitchEffect();
            }
        }

        if (isRotating)
        {
            rotationTimer += Time.deltaTime;

            if (rotationTimer < 0.5f)
            {
                RotateCamera();
            }
            else
            {
                isRotating = false;
                rotationTimer = 0f;
            }
        }
    }

    void ApplyGlitchEffect()
    {
        isRotating = true;

        Shader.SetGlobalFloat("_GlitchStrength", 0.1f);
        Shader.SetGlobalFloat("_GlitchFrequency", 0.1f);
       
        Shader.SetGlobalFloat("_GlitchStrength", 0f);
        Shader.SetGlobalFloat("_GlitchFrequency", 0f);
    }
    void RotateCamera()
    {
        transform.Rotate(new Vector3(0, 0, 180));
        
        if (!isRotated)
        {
            score1.transform.position = new Vector3(460f, 400f, 0f);
            score2.transform.position = new Vector3(390f, 400f, 0f);
            isRotated = true;
        }
        else
        {
            score2.transform.position = new Vector3(460f, 400f, 0f);
            score1.transform.position = new Vector3(390f, 400f, 0f);
            isRotated = false;
        }
    }
    /*
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, glitchMaterial);
    }
    */
}
