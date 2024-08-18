using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DesignPatterns.StatePattern
{
    /// <summary>
    /// A user interface that responds to internal state changes
    /// </summary>
    [RequireComponent(typeof(PlayerController))]
    public class PlayerStateView : MonoBehaviour
    {
        private PlayerController m_Player;
        private SimplePlayerStateMachine m_PlayerStateMachine;
        private string lastName;

        [Header("Animators")]
        [SerializeField]
        private Animator animator;

        private void Awake()
        {
            m_Player = GetComponent<PlayerController>();
            animator = GetComponentInChildren<Animator>();

        }
        private void Start()
        {
            // cache to save typing
            m_PlayerStateMachine = m_Player.PlayerStateMachine;
            // listen for any state changes
            m_PlayerStateMachine.stateChanged += OnStateChanged;
        }

        void OnDestroy()
        {
            // unregister the subscription if we destroy the object
            m_PlayerStateMachine.stateChanged -= OnStateChanged;
        }

        // change the UI.Text when the state changes
        private void OnStateChanged(IState state)
        {
            if (lastName != null )
            {
                animator.ResetTrigger(lastName);
            }
            animator.SetTrigger(state.GetType().Name);
            lastName = state.GetType().Name;
            Debug.Log(state.GetType().Name);
        }

    }
}
