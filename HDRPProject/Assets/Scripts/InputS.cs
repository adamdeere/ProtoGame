// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputPrefs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputPrefsClass : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputPrefsClass()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputPrefs"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""d01e62a1-9014-467b-96be-c47231f01479"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""28942fe6-0206-43f6-931e-aef6df7d5dfa"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""45a68deb-f69b-4d9d-95ba-4fb65e975075"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HostilitySwitcher"",
                    ""type"": ""Button"",
                    ""id"": ""1d3f3eb2-1f43-414a-9549-e8eaf5d847a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aiming"",
                    ""type"": ""Button"",
                    ""id"": ""46d1426a-bbec-4874-b76f-5d88f56096fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a879d809-15fa-45e8-84f2-b55ec956e98e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpawnCube"",
                    ""type"": ""Button"",
                    ""id"": ""f4a9d0b8-f33c-4de8-8f60-52cb52db7c5f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""00ca640b-d935-4593-8157-c05846ea39b3"",
                    ""path"": ""Dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e2062cb9-1b15-46a2-838c-2f8d72a0bdd9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8180e8bd-4097-4f4e-ab88-4523101a6ce9"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""320bffee-a40b-4347-ac70-c210eb8bc73a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1c5327b5-f71c-4f60-99c7-4e737386f1d1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d2581a9b-1d11-4566-b27d-b92aff5fabbc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2e46982e-44cc-431b-9f0b-c11910bf467a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fcfe95b8-67b9-4526-84b5-5d0bc98d6400"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""77bff152-3580-4b21-b6de-dcd0c7e41164"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e9d4c120-843b-4228-8a88-ebcc1999eec5"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c8e490b-c610-4785-884f-f04217b23ca4"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse;Touch"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06a097b5-6338-4513-9120-5a9867a55cc2"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d83f931-f6b3-40b2-8c5e-4b8166f2f70f"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""HostilitySwitcher"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c2fac91-24af-4cf2-bd34-17d1a31db84c"",
                    ""path"": ""<DualShockGamepad>/touchpadButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HostilitySwitcher"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8009a68f-0d31-420c-8317-6f356ad18b57"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe9051fa-2ec5-4a4f-b35e-c6821d0520f3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c5c1e95-9f98-430e-87c7-4ded33d7bdb5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7e8147b-319d-4af1-a559-67df84eadd47"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SpawnCube"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""KeyboardControlls"",
            ""id"": ""52fe1c44-7e27-42e5-9e2d-90ecf007001a"",
            ""actions"": [
                {
                    ""name"": ""Load"",
                    ""type"": ""Button"",
                    ""id"": ""d789c83b-dfff-4d69-bf1a-c55aeeb3b5f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Save"",
                    ""type"": ""Button"",
                    ""id"": ""9de38169-fd35-429b-8648-b4979f66e135"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""8b58aace-2e67-4f60-bd41-3fc3df7727d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Create"",
                    ""type"": ""Button"",
                    ""id"": ""0459b767-888a-4035-acb0-7f6b5b0b6848"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aa378927-5b49-49c7-9aab-1affa26e6db8"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;Gamepad"",
                    ""action"": ""Load"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5410be7-85b1-4c25-8e4d-10bf12ab04c7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88c26cfd-6500-4f05-83bb-dac47808007c"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50f62afd-845b-4a1f-8df7-c405c52c49bc"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Create"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_HostilitySwitcher = m_Player.FindAction("HostilitySwitcher", throwIfNotFound: true);
        m_Player_Aiming = m_Player.FindAction("Aiming", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_SpawnCube = m_Player.FindAction("SpawnCube", throwIfNotFound: true);
        // KeyboardControlls
        m_KeyboardControlls = asset.FindActionMap("KeyboardControlls", throwIfNotFound: true);
        m_KeyboardControlls_Load = m_KeyboardControlls.FindAction("Load", throwIfNotFound: true);
        m_KeyboardControlls_Save = m_KeyboardControlls.FindAction("Save", throwIfNotFound: true);
        m_KeyboardControlls_Quit = m_KeyboardControlls.FindAction("Quit", throwIfNotFound: true);
        m_KeyboardControlls_Create = m_KeyboardControlls.FindAction("Create", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_HostilitySwitcher;
    private readonly InputAction m_Player_Aiming;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_SpawnCube;
    public struct PlayerActions
    {
        private @InputPrefsClass m_Wrapper;
        public PlayerActions(@InputPrefsClass wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @HostilitySwitcher => m_Wrapper.m_Player_HostilitySwitcher;
        public InputAction @Aiming => m_Wrapper.m_Player_Aiming;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @SpawnCube => m_Wrapper.m_Player_SpawnCube;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @HostilitySwitcher.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHostilitySwitcher;
                @HostilitySwitcher.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHostilitySwitcher;
                @HostilitySwitcher.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHostilitySwitcher;
                @Aiming.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAiming;
                @Aiming.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAiming;
                @Aiming.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAiming;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @SpawnCube.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnCube;
                @SpawnCube.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnCube;
                @SpawnCube.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpawnCube;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @HostilitySwitcher.started += instance.OnHostilitySwitcher;
                @HostilitySwitcher.performed += instance.OnHostilitySwitcher;
                @HostilitySwitcher.canceled += instance.OnHostilitySwitcher;
                @Aiming.started += instance.OnAiming;
                @Aiming.performed += instance.OnAiming;
                @Aiming.canceled += instance.OnAiming;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @SpawnCube.started += instance.OnSpawnCube;
                @SpawnCube.performed += instance.OnSpawnCube;
                @SpawnCube.canceled += instance.OnSpawnCube;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // KeyboardControlls
    private readonly InputActionMap m_KeyboardControlls;
    private IKeyboardControllsActions m_KeyboardControllsActionsCallbackInterface;
    private readonly InputAction m_KeyboardControlls_Load;
    private readonly InputAction m_KeyboardControlls_Save;
    private readonly InputAction m_KeyboardControlls_Quit;
    private readonly InputAction m_KeyboardControlls_Create;
    public struct KeyboardControllsActions
    {
        private @InputPrefsClass m_Wrapper;
        public KeyboardControllsActions(@InputPrefsClass wrapper) { m_Wrapper = wrapper; }
        public InputAction @Load => m_Wrapper.m_KeyboardControlls_Load;
        public InputAction @Save => m_Wrapper.m_KeyboardControlls_Save;
        public InputAction @Quit => m_Wrapper.m_KeyboardControlls_Quit;
        public InputAction @Create => m_Wrapper.m_KeyboardControlls_Create;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardControlls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardControllsActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardControllsActions instance)
        {
            if (m_Wrapper.m_KeyboardControllsActionsCallbackInterface != null)
            {
                @Load.started -= m_Wrapper.m_KeyboardControllsActionsCallbackInterface.OnLoad;
                @Load.performed -= m_Wrapper.m_KeyboardControllsActionsCallbackInterface.OnLoad;
                @Load.canceled -= m_Wrapper.m_KeyboardControllsActionsCallbackInterface.OnLoad;
                @Save.started -= m_Wrapper.m_KeyboardControllsActionsCallbackInterface.OnSave;
                @Save.performed -= m_Wrapper.m_KeyboardControllsActionsCallbackInterface.OnSave;
                @Save.canceled -= m_Wrapper.m_KeyboardControllsActionsCallbackInterface.OnSave;
                @Quit.started -= m_Wrapper.m_KeyboardControllsActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_KeyboardControllsActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_KeyboardControllsActionsCallbackInterface.OnQuit;
                @Create.started -= m_Wrapper.m_KeyboardControllsActionsCallbackInterface.OnCreate;
                @Create.performed -= m_Wrapper.m_KeyboardControllsActionsCallbackInterface.OnCreate;
                @Create.canceled -= m_Wrapper.m_KeyboardControllsActionsCallbackInterface.OnCreate;
            }
            m_Wrapper.m_KeyboardControllsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Load.started += instance.OnLoad;
                @Load.performed += instance.OnLoad;
                @Load.canceled += instance.OnLoad;
                @Save.started += instance.OnSave;
                @Save.performed += instance.OnSave;
                @Save.canceled += instance.OnSave;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @Create.started += instance.OnCreate;
                @Create.performed += instance.OnCreate;
                @Create.canceled += instance.OnCreate;
            }
        }
    }
    public KeyboardControllsActions @KeyboardControlls => new KeyboardControllsActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnHostilitySwitcher(InputAction.CallbackContext context);
        void OnAiming(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSpawnCube(InputAction.CallbackContext context);
    }
    public interface IKeyboardControllsActions
    {
        void OnLoad(InputAction.CallbackContext context);
        void OnSave(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
        void OnCreate(InputAction.CallbackContext context);
    }
}
