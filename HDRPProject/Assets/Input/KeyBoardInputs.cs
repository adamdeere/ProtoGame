// GENERATED AUTOMATICALLY FROM 'Assets/Input/KeyBoardInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @KeyBoardInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @KeyBoardInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""KeyBoardInputs"",
    ""maps"": [
        {
            ""name"": ""KeyBoard"",
            ""id"": ""22729cbd-56cd-4af9-9495-2816cb6f8023"",
            ""actions"": [
                {
                    ""name"": ""Create"",
                    ""type"": ""Button"",
                    ""id"": ""e77ffa7b-4e5e-45a5-8669-81ebc3ea7621"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Load"",
                    ""type"": ""Button"",
                    ""id"": ""1cec6b29-6757-4561-8e7f-dc601f4a8a9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Save"",
                    ""type"": ""Button"",
                    ""id"": ""8e1f9229-6cb3-4e5c-aee1-d52a503f8913"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""842c34ad-4cd4-4d3d-afdf-19514cf94007"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""077738d4-ffce-418e-a1f5-8c7e09c6e9fc"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Create"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85387ea3-7430-4352-9fa5-2a73488ae59a"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Load"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""edbe6b97-932d-4fe0-8c6f-453370200ecb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de4eac7a-2f0b-44aa-af0d-c671c0d03ee2"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // KeyBoard
        m_KeyBoard = asset.FindActionMap("KeyBoard", throwIfNotFound: true);
        m_KeyBoard_Create = m_KeyBoard.FindAction("Create", throwIfNotFound: true);
        m_KeyBoard_Load = m_KeyBoard.FindAction("Load", throwIfNotFound: true);
        m_KeyBoard_Save = m_KeyBoard.FindAction("Save", throwIfNotFound: true);
        m_KeyBoard_Quit = m_KeyBoard.FindAction("Quit", throwIfNotFound: true);
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

    // KeyBoard
    private readonly InputActionMap m_KeyBoard;
    private IKeyBoardActions m_KeyBoardActionsCallbackInterface;
    private readonly InputAction m_KeyBoard_Create;
    private readonly InputAction m_KeyBoard_Load;
    private readonly InputAction m_KeyBoard_Save;
    private readonly InputAction m_KeyBoard_Quit;
    public struct KeyBoardActions
    {
        private @KeyBoardInputs m_Wrapper;
        public KeyBoardActions(@KeyBoardInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Create => m_Wrapper.m_KeyBoard_Create;
        public InputAction @Load => m_Wrapper.m_KeyBoard_Load;
        public InputAction @Save => m_Wrapper.m_KeyBoard_Save;
        public InputAction @Quit => m_Wrapper.m_KeyBoard_Quit;
        public InputActionMap Get() { return m_Wrapper.m_KeyBoard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyBoardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyBoardActions instance)
        {
            if (m_Wrapper.m_KeyBoardActionsCallbackInterface != null)
            {
                @Create.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnCreate;
                @Create.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnCreate;
                @Create.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnCreate;
                @Load.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnLoad;
                @Load.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnLoad;
                @Load.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnLoad;
                @Save.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnSave;
                @Save.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnSave;
                @Save.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnSave;
                @Quit.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_KeyBoardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Create.started += instance.OnCreate;
                @Create.performed += instance.OnCreate;
                @Create.canceled += instance.OnCreate;
                @Load.started += instance.OnLoad;
                @Load.performed += instance.OnLoad;
                @Load.canceled += instance.OnLoad;
                @Save.started += instance.OnSave;
                @Save.performed += instance.OnSave;
                @Save.canceled += instance.OnSave;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public KeyBoardActions @KeyBoard => new KeyBoardActions(this);
    public interface IKeyBoardActions
    {
        void OnCreate(InputAction.CallbackContext context);
        void OnLoad(InputAction.CallbackContext context);
        void OnSave(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
}
