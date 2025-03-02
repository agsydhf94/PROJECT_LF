using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class EntityFX : MonoBehaviour
    {
        private SpriteRenderer sr;

        [Header("Flash FX")]
        [SerializeField] private float flashDuration;
        [SerializeField] private Material hitMaterial;
        private Material originalMaterial;


        private void Start()
        {
            sr = GetComponentInChildren<SpriteRenderer>();
            originalMaterial = sr.material;
        }

        private IEnumerator FlashFX()
        {
            sr.material = hitMaterial;

            yield return new WaitForSeconds(flashDuration);

            sr.material = originalMaterial;

        }

        private void RedColorBlink()
        {
            if(sr.color != Color.white)
                sr.color = Color.white;
            else
                sr.color = Color.red;
        }

        private void CancelRedBlink()
        {
            CancelInvoke();
            sr.color = Color.white;
        }
    }
}
