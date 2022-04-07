// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player Movement"",
            ""id"": ""66e15dcb-dae5-4546-abc4-ab88040d4f32"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""f29370f3-f971-485d-9386-373fb1de1477"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""87c57f62-488b-4c24-a142-afc2757d344a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""7e42558f-45c9-489d-9bb0-18b9428eff9c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""105b7fdf-e7f4-43fa-abe2-d31a615e299d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.01)""
                },
                {
                    ""name"": ""FinishSprint"",
                    ""type"": ""Button"",
                    ""id"": ""9ada7759-87df-41e1-b934-9be8623fa3ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.01,behavior=1)""
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""09cbe49c-1fdb-4161-a4db-ee09a31ce9c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.01)""
                },
                {
                    ""name"": ""FinishCrouch"",
                    ""type"": ""Button"",
                    ""id"": ""605ce73d-0bba-4525-bc82-fbe69270ec79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.01,behavior=1)""
                },
                {
                    ""name"": ""Action_1"",
                    ""type"": ""Button"",
                    ""id"": ""f4985629-edf6-455c-8561-968a7a482ef9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.01)""
                },
                {
                    ""name"": ""ViewObjectives"",
                    ""type"": ""Button"",
                    ""id"": ""82bafdaa-49a9-499b-84ed-f3e7f5f6eeb3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""54260ce7-477f-4750-8df8-6dba22e0339d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d61ce1be-65f5-4179-95c3-9d16f2cb1f27"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bc1dc06a-f02d-419d-bcc4-ae7598bbca56"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a65716cc-6006-4ece-a342-00c664e803fb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5bc24987-f787-4c19-b536-697622c786ee"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""166edbe2-965a-45b0-9d30-34c9e98d08c5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed0d2a56-1f68-46c1-b010-f41d68aee61b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b48d34c-cd52-45dd-9d8f-ae6321b2ccf1"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5b75665-a8ae-48fe-98ba-43d2eb300b0f"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""043831c9-ea39-4b6a-b556-0cbf662b411b"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FinishSprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fce0153-8574-4b16-b354-660218317dde"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FinishCrouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84fe5cff-a5e9-41f5-bccc-7dffe1d04164"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ea3fbfa-09a2-4b54-a2af-246ab959e259"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewObjectives"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Movement
        m_PlayerMovement = asset.FindActionMap("Player Movement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovement_Jump = m_PlayerMovement.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMovement_Look = m_PlayerMovement.FindAction("Look", throwIfNotFound: true);
        m_PlayerMovement_Sprint = m_PlayerMovement.FindAction("Sprint", throwIfNotFound: true);
        m_PlayerMovement_FinishSprint = m_PlayerMovement.FindAction("FinishSprint", throwIfNotFound: true);
        m_PlayerMovement_Crouch = m_PlayerMovement.FindAction("Crouch", throwIfNotFound: true);
        m_PlayerMovement_FinishCrouch = m_PlayerMovement.FindAction("FinishCrouch", throwIfNotFound: true);
        m_PlayerMovement_Action_1 = m_PlayerMovement.FindAction("Action_1", throwIfNotFound: true);
        m_PlayerMovement_ViewObjectives = m_PlayerMovement.FindAction("ViewObjectives", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player Movement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    private readonly InputAction m_PlayerMovement_Jump;
    private readonly InputAction m_PlayerMovement_Look;
    private readonly InputAction m_PlayerMovement_Sprint;
    private readonly InputAction m_PlayerMovement_FinishSprint;
    private readonly InputAction m_PlayerMovement_Crouch;
    private readonly InputAction m_PlayerMovement_FinishCrouch;
    private readonly InputAction m_PlayerMovement_Action_1;
    private readonly InputAction m_PlayerMovement_ViewObjectives;
    public struct PlayerMovementActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerMovement_Jump;
        public InputAction @Look => m_Wrapper.m_PlayerMovement_Look;
        public InputAction @Sprint => m_Wrapper.m_PlayerMovement_Sprint;
        public InputAction @FinishSprint => m_Wrapper.m_PlayerMovement_FinishSprint;
        public InputAction @Crouch => m_Wrapper.m_PlayerMovement_Crouch;
        public InputAction @FinishCrouch => m_Wrapper.m_PlayerMovement_FinishCrouch;
        public InputAction @Action_1 => m_Wrapper.m_PlayerMovement_Action_1;
        public InputAction @ViewObjectives => m_Wrapper.m_PlayerMovement_ViewObjectives;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJump;
                @Look.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLook;
                @Sprint.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnSprint;
                @FinishSprint.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnFinishSprint;
                @FinishSprint.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnFinishSprint;
                @FinishSprint.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnFinishSprint;
                @Crouch.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCrouch;
                @FinishCrouch.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnFinishCrouch;
                @FinishCrouch.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnFinishCrouch;
                @FinishCrouch.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnFinishCrouch;
                @Action_1.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAction_1;
                @Action_1.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAction_1;
                @Action_1.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnAction_1;
                @ViewObjectives.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnViewObjectives;
                @ViewObjectives.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnViewObjectives;
                @ViewObjectives.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnViewObjectives;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @FinishSprint.started += instance.OnFinishSprint;
                @FinishSprint.performed += instance.OnFinishSprint;
                @FinishSprint.canceled += instance.OnFinishSprint;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @FinishCrouch.started += instance.OnFinishCrouch;
                @FinishCrouch.performed += instance.OnFinishCrouch;
                @FinishCrouch.canceled += instance.OnFinishCrouch;
                @Action_1.started += instance.OnAction_1;
                @Action_1.performed += instance.OnAction_1;
                @Action_1.canceled += instance.OnAction_1;
                @ViewObjectives.started += instance.OnViewObjectives;
                @ViewObjectives.performed += instance.OnViewObjectives;
                @ViewObjectives.canceled += instance.OnViewObjectives;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnFinishSprint(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnFinishCrouch(InputAction.CallbackContext context);
        void OnAction_1(InputAction.CallbackContext context);
        void OnViewObjectives(InputAction.CallbackContext context);
    }
}
