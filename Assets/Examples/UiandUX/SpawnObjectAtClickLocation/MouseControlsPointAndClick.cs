//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Examples/UiandUX/SpawnObjectAtClickLocation/MouseControlsPointAndClick.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @MouseControlsPointAndClick : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MouseControlsPointAndClick()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MouseControlsPointAndClick"",
    ""maps"": [
        {
            ""name"": ""MouseRTS"",
            ""id"": ""78fe1106-d178-42de-925d-40295861e0d3"",
            ""actions"": [
                {
                    ""name"": ""Pan"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2a60c28e-8965-450c-830f-a66e6bb69e13"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c4dd056e-6c49-478e-871e-e5f56ce90667"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PrimaryAction"",
                    ""type"": ""Button"",
                    ""id"": ""a29cecb5-855f-4695-a4cc-5713e2c10fdb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondaryAction"",
                    ""type"": ""Button"",
                    ""id"": ""8dde157a-a90c-4472-8744-722b43583bed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9a5c48ef-9904-4426-a02b-86b3f3cb8279"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pan"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""681f1853-86ce-41e5-b35e-884b67bc70fe"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b79936d-128b-41b1-af86-cd155d0dea8b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aecd967b-87b9-4ec3-ad62-445062300b8e"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MouseRTS
        m_MouseRTS = asset.FindActionMap("MouseRTS", throwIfNotFound: true);
        m_MouseRTS_Pan = m_MouseRTS.FindAction("Pan", throwIfNotFound: true);
        m_MouseRTS_Zoom = m_MouseRTS.FindAction("Zoom", throwIfNotFound: true);
        m_MouseRTS_PrimaryAction = m_MouseRTS.FindAction("PrimaryAction", throwIfNotFound: true);
        m_MouseRTS_SecondaryAction = m_MouseRTS.FindAction("SecondaryAction", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // MouseRTS
    private readonly InputActionMap m_MouseRTS;
    private IMouseRTSActions m_MouseRTSActionsCallbackInterface;
    private readonly InputAction m_MouseRTS_Pan;
    private readonly InputAction m_MouseRTS_Zoom;
    private readonly InputAction m_MouseRTS_PrimaryAction;
    private readonly InputAction m_MouseRTS_SecondaryAction;
    public struct MouseRTSActions
    {
        private @MouseControlsPointAndClick m_Wrapper;
        public MouseRTSActions(@MouseControlsPointAndClick wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pan => m_Wrapper.m_MouseRTS_Pan;
        public InputAction @Zoom => m_Wrapper.m_MouseRTS_Zoom;
        public InputAction @PrimaryAction => m_Wrapper.m_MouseRTS_PrimaryAction;
        public InputAction @SecondaryAction => m_Wrapper.m_MouseRTS_SecondaryAction;
        public InputActionMap Get() { return m_Wrapper.m_MouseRTS; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseRTSActions set) { return set.Get(); }
        public void SetCallbacks(IMouseRTSActions instance)
        {
            if (m_Wrapper.m_MouseRTSActionsCallbackInterface != null)
            {
                @Pan.started -= m_Wrapper.m_MouseRTSActionsCallbackInterface.OnPan;
                @Pan.performed -= m_Wrapper.m_MouseRTSActionsCallbackInterface.OnPan;
                @Pan.canceled -= m_Wrapper.m_MouseRTSActionsCallbackInterface.OnPan;
                @Zoom.started -= m_Wrapper.m_MouseRTSActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_MouseRTSActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_MouseRTSActionsCallbackInterface.OnZoom;
                @PrimaryAction.started -= m_Wrapper.m_MouseRTSActionsCallbackInterface.OnPrimaryAction;
                @PrimaryAction.performed -= m_Wrapper.m_MouseRTSActionsCallbackInterface.OnPrimaryAction;
                @PrimaryAction.canceled -= m_Wrapper.m_MouseRTSActionsCallbackInterface.OnPrimaryAction;
                @SecondaryAction.started -= m_Wrapper.m_MouseRTSActionsCallbackInterface.OnSecondaryAction;
                @SecondaryAction.performed -= m_Wrapper.m_MouseRTSActionsCallbackInterface.OnSecondaryAction;
                @SecondaryAction.canceled -= m_Wrapper.m_MouseRTSActionsCallbackInterface.OnSecondaryAction;
            }
            m_Wrapper.m_MouseRTSActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pan.started += instance.OnPan;
                @Pan.performed += instance.OnPan;
                @Pan.canceled += instance.OnPan;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @PrimaryAction.started += instance.OnPrimaryAction;
                @PrimaryAction.performed += instance.OnPrimaryAction;
                @PrimaryAction.canceled += instance.OnPrimaryAction;
                @SecondaryAction.started += instance.OnSecondaryAction;
                @SecondaryAction.performed += instance.OnSecondaryAction;
                @SecondaryAction.canceled += instance.OnSecondaryAction;
            }
        }
    }
    public MouseRTSActions @MouseRTS => new MouseRTSActions(this);
    public interface IMouseRTSActions
    {
        void OnPan(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnPrimaryAction(InputAction.CallbackContext context);
        void OnSecondaryAction(InputAction.CallbackContext context);
    }
}
