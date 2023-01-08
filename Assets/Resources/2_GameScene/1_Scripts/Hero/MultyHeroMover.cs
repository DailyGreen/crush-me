using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

namespace Hero
{
    public class MultyHeroMover : MonoBehaviour
    {
        public float _moveSpeed;

        Rigidbody2D _rigidBody;

        Vector3 _moveVector = Vector3.zero;
        Vector3 _rotateVector = Vector3.zero;
        const float correction = 90f * Mathf.Deg2Rad;

        [SerializeField] Photon.Pun.PhotonView view;

        void Start()
        {
            view = this.GetComponent<Photon.Pun.PhotonView>();
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (view.IsMine)
                getKey();
        }

        void FixedUpdate()
        {
            movement();
            rotation();
        }

        void getKey()
        {
            _moveVector = new Vector3(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical"));
            _rotateVector = new Vector3(CnInputManager.GetAxis("RotateX"), CnInputManager.GetAxis("RotateY"));
        }

        void movement()
        {
            this._rigidBody.velocity = _moveVector * _moveSpeed;
        }

        void rotation()
        {
            if (_moveVector.Equals(Vector3.zero))
                return;

            float value = (Mathf.Atan2(_moveVector.y, _moveVector.x) - correction) * Mathf.Rad2Deg;
            _rigidBody.rotation = value;
        }
    }
}