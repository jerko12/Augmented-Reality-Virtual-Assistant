// GENERATED AUTOMATICALLY FROM 'Assets/ExampleAssets/_Scripts/Input/InputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""AR Input"",
            ""id"": ""0b01810a-d2f5-425b-8b4c-98c3af59e6bc"",
            ""actions"": [
                {
                    ""name"": ""Primary Touch"",
                    ""type"": ""Button"",
                    ""id"": ""9214e671-3031-42a7-a497-1a6cb752f29d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Primary Touch Position"",
                    ""type"": ""Value"",
                    ""id"": ""511be7ea-aea0-4c31-8fd1-cd660a51c953"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""04c5bc74-66b4-48e4-9a45-1a5f207fb943"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f55b87aa-f63c-497e-adf2-6c2badd3a63e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a682d7c-1a59-45bc-b610-c6cf98c69241"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary Touch Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1e17176-5c10-4615-a6e6-f00e2645f086"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary Touch Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // AR Input
        m_ARInput = asset.FindActionMap("AR Input", throwIfNotFound: true);
        m_ARInput_PrimaryTouch = m_ARInput.FindAction("Primary Touch", throwIfNotFound: true);
        m_ARInput_PrimaryTouchPosition = m_ARInput.FindAction("Primary Touch Position", throwIfNotFound: true);
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

    // AR Input
    private readonly InputActionMap m_ARInput;
    private IARInputActions m_ARInputActionsCallbackInterface;
    private readonly InputAction m_ARInput_PrimaryTouch;
    private readonly InputAction m_ARInput_PrimaryTouchPosition;
    public struct ARInputActions
    {
        private @InputControls m_Wrapper;
        public ARInputActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryTouch => m_Wrapper.m_ARInput_PrimaryTouch;
        public InputAction @PrimaryTouchPosition => m_Wrapper.m_ARInput_PrimaryTouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_ARInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ARInputActions set) { return set.Get(); }
        public void SetCallbacks(IARInputActions instance)
        {
            if (m_Wrapper.m_ARInputActionsCallbackInterface != null)
            {
                @PrimaryTouch.started -= m_Wrapper.m_ARInputActionsCallbackInterface.OnPrimaryTouch;
                @PrimaryTouch.performed -= m_Wrapper.m_ARInputActionsCallbackInterface.OnPrimaryTouch;
                @PrimaryTouch.canceled -= m_Wrapper.m_ARInputActionsCallbackInterface.OnPrimaryTouch;
                @PrimaryTouchPosition.started -= m_Wrapper.m_ARInputActionsCallbackInterface.OnPrimaryTouchPosition;
                @PrimaryTouchPosition.performed -= m_Wrapper.m_ARInputActionsCallbackInterface.OnPrimaryTouchPosition;
                @PrimaryTouchPosition.canceled -= m_Wrapper.m_ARInputActionsCallbackInterface.OnPrimaryTouchPosition;
            }
            m_Wrapper.m_ARInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryTouch.started += instance.OnPrimaryTouch;
                @PrimaryTouch.performed += instance.OnPrimaryTouch;
                @PrimaryTouch.canceled += instance.OnPrimaryTouch;
                @PrimaryTouchPosition.started += instance.OnPrimaryTouchPosition;
                @PrimaryTouchPosition.performed += instance.OnPrimaryTouchPosition;
                @PrimaryTouchPosition.canceled += instance.OnPrimaryTouchPosition;
            }
        }
    }
    public ARInputActions @ARInput => new ARInputActions(this);
    public interface IARInputActions
    {
        void OnPrimaryTouch(InputAction.CallbackContext context);
        void OnPrimaryTouchPosition(InputAction.CallbackContext context);
    }
}
