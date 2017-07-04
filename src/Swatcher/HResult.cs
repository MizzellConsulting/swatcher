using System;
using System.ComponentModel;

// ReSharper disable InconsistentNaming

namespace BraveLantern.Swatcher
{

    public enum HResult : uint
    {
        [Description("The underlying file was converted to compound file format")]
        STG_S_CONVERTED = 0x00030200,
        [Description("The storage operation should block until more data is available")]
        STG_S_BLOCK = 0x00030201,
        [Description("The storage operation should retry immediately")]
        STG_S_RETRYNOW = 0x00030202,
        [Description("The notified event sink will not influence the storage operation")]
        STG_S_MONITORING = 0x00030203,
        [Description("Multiple opens prevent consolidated. (commit succeeded)")]
        STG_S_MULTIPLEOPENS = 0x00030204,
        [Description("Consolidation of the storage file failed. (commit succeeded)")]
        STG_S_CONSOLIDATIONFAILED = 0x00030205,
        [Description("Consolidation of the storage file is inappropriate. (commit succeeded)")]
        STG_S_CANNOTCONSOLIDATE = 0x00030206,
        [Description("Use the registry database to provide the requested information")]
        OLE_S_USEREG = 0x00040000,
        [Description("Success, but static")]
        OLE_S_STATIC = 0x00040001,
        [Description("Macintosh clipboard format")]
        OLE_S_MAC_CLIPFORMAT = 0x00040002,
        [Description("Successful drop took place")]
        DRAGDROP_S_DROP = 0x00040100,
        [Description("Drag-drop operation canceled")]
        DRAGDROP_S_CANCEL = 0x00040101,
        [Description("Use the default cursor")]
        DRAGDROP_S_USEDEFAULTCURSORS = 0x00040102,
        [Description("Data has same FORMATETC")]
        DATA_S_SAMEFORMATETC = 0x00040130,
        [Description("View is already frozen")]
        VIEW_S_ALREADY_FROZEN = 0x00040140,
        [Description("FORMATETC not supported")]
        CACHE_S_FORMATETC_NOTSUPPORTED = 0x00040170,
        [Description("Same cache")]
        CACHE_S_SAMECACHE = 0x00040171,
        [Description("Some cache(s) not updated")]
        CACHE_S_SOMECACHES_NOTUPDATED = 0x00040172,
        [Description("Invalid verb for OLE object")]
        OLEOBJ_S_INVALIDVERB = 0x00040180,
        [Description("Verb number is valid but verb cannot be done now")]
        OLEOBJ_S_CANNOT_DOVERB_NOW = 0x00040181,
        [Description("Invalid window handle passed")]
        OLEOBJ_S_INVALIDHWND = 0x00040182,
        [Description("Message is too long; some of it had to be truncated before displaying")]
        INPLACE_S_TRUNCATED = 0x000401A0,
        [Description("Unable to convert OLESTREAM to IStorage")]
        CONVERT10_S_NO_PRESENTATION = 0x000401C0,
        [Description("Moniker reduced to itself")]
        MK_S_REDUCED_TO_SELF = 0x000401E2,
        [Description("Common prefix is this moniker")]
        MK_S_ME = 0x000401E4,
        [Description("Common prefix is input moniker")]
        MK_S_HIM = 0x000401E5,
        [Description("Common prefix is both monikers")]
        MK_S_US = 0x000401E6,
        [Description("Moniker is already registered in running object table")]
        MK_S_MONIKERALREADYREGISTERED = 0x000401E7,
        [Description("An event was able to invoke some but not all of the subscribers")]
        EVENT_S_SOME_SUBSCRIBERS_FAILED = 0x00040200,
        [Description("An event was delivered but there were no subscribers")]
        EVENT_S_NOSUBSCRIBERS = 0x00040202,
        [Description("The task is ready to run at its next scheduled time")]
        SCHED_S_TASK_READY = 0x00041300,
        [Description("The task is currently running")]
        SCHED_S_TASK_RUNNING = 0x00041301,
        [Description("The task will not run at the scheduled times because it has been disabled")]
        SCHED_S_TASK_DISABLED = 0x00041302,
        [Description("The task has not yet run")]
        SCHED_S_TASK_HAS_NOT_RUN = 0x00041303,
        [Description("There are no more runs scheduled for this task")]
        SCHED_S_TASK_NO_MORE_RUNS = 0x00041304,
        [Description("One or more of the properties that are needed to run this task on a schedule have not been set")]
        SCHED_S_TASK_NOT_SCHEDULED = 0x00041305,
        [Description("The last run of the task was terminated by the user")]
        SCHED_S_TASK_TERMINATED = 0x00041306,
        [Description("Either the task has no triggers or the existing triggers are disabled or not set")]
        SCHED_S_TASK_NO_VALID_TRIGGERS = 0x00041307,
        [Description("Event triggers don't have set run times")]
        SCHED_S_EVENT_TRIGGER = 0x00041308,
        [Description("The task is registered, but not all specified triggers will start the task, check task scheduler event log for detailed information")]
        SCHED_S_SOME_TRIGGERS_FAILED = 0x0004131B,
        [Description("The task is registered, but may fail to start. Batch logon privilege needs to be enabled for the task principal")]
        SCHED_S_BATCH_LOGON_PROBLEM = 0x0004131C,
        [Description("An asynchronous operation was specified. The operation has begun, but its outcome is not known yet")]
        XACT_S_ASYNC = 0x0004D000,
        [Description("The method call succeeded because the transaction was read-only")]
        XACT_S_READONLY = 0x0004D002,
        [Description("The transaction was successfully aborted. However, this is a coordinated transaction, and some number of enlisted resources were aborted outright because they could not support abort-retaining semantics")]
        XACT_S_SOMENORETAIN = 0x0004D003,
        [Description("No changes were made during this call, but the sink wants another chance to look if any other sinks make further changes")]
        XACT_S_OKINFORM = 0x0004D004,
        [Description("The sink is content and wishes the transaction to proceed. Changes were made to one or more resources during this call")]
        XACT_S_MADECHANGESCONTENT = 0x0004D005,
        [Description("The sink is for the moment and wishes the transaction to proceed, but if other changes are made following this return by other event sinks then this sink wants another chance to look")]
        XACT_S_MADECHANGESINFORM = 0x0004D006,
        [Description("The transaction was successfully aborted. However, the abort was non-retaining")]
        XACT_S_ALLNORETAIN = 0x0004D007,
        [Description("An abort operation was already in progress")]
        XACT_S_ABORTING = 0x0004D008,
        [Description("The resource manager has performed a single-phase commit of the transaction")]
        XACT_S_SINGLEPHASE = 0x0004D009,
        [Description("The local transaction has not aborted")]
        XACT_S_LOCALLY_OK = 0x0004D00A,
        [Description("The resource manager has requested to be the coordinator (last resource manager) for the transaction")]
        XACT_S_LASTRESOURCEMANAGER = 0x0004D010,
        [Description("Not all the requested interfaces were available")]
        CO_S_NOTALLINTERFACES = 0x00080012,
        [Description("The specified machine name was not found in the cache")]
        CO_S_MACHINENAMENOTFOUND = 0x00080013,
        [Description("The function completed successfully, but must be called again to complete the context")]
        SEC_I_CONTINUE_NEEDED = 0x00090312,
        [Description("The function completed successfully, but CompleteToken must be called")]
        SEC_I_COMPLETE_NEEDED = 0x00090313,
        [Description("The function completed successfully, but both CompleteToken and this function must be called to complete the context")]
        SEC_I_COMPLETE_AND_CONTINUE = 0x00090314,
        [Description("The logon was completed, but no network authority was available. The logon was made using locally known information")]
        SEC_I_LOCAL_LOGON = 0x00090315,
        [Description("The context has expired and can no longer be used")]
        SEC_I_CONTEXT_EXPIRED = 0x00090317,
        [Description("The credentials supplied were not complete, and could not be verified. Additional information can be returned from the context")]
        SEC_I_INCOMPLETE_CREDENTIALS = 0x00090320,
        [Description("The context data must be renegotiated with the peer")]
        SEC_I_RENEGOTIATE = 0x00090321,
        [Description("There is no LSA mode context associated with this context")]
        SEC_I_NO_LSA_CONTEXT = 0x00090323,
        [Description("A signature operation must be performed before the user can authenticate")]
        SEC_I_SIGNATURE_NEEDED = 0x0009035C,
        [Description("The protected data needs to be re-protected")]
        CRYPT_I_NEW_PROTECTION_REQUIRED = 0x00091012,
        [Description("Unknown error (0xd0000)")]
        NS_S_CALLPENDING = 0x000D0000,
        [Description("Unknown error (0xd0001)")]
        NS_S_CALLABORTED = 0x000D0001,
        [Description("Unknown error (0xd0002)")]
        NS_S_STREAM_TRUNCATED = 0x000D0002,
        [Description("Unknown error (0xd0bc8)")]
        NS_S_REBUFFERING = 0x000D0BC8,
        [Description("Unknown error (0xd0bc9)")]
        NS_S_DEGRADING_QUALITY = 0x000D0BC9,
        [Description("Unknown error (0xd0bdb)")]
        NS_S_TRANSCRYPTOR_EOF = 0x000D0BDB,
        [Description("Unknown error (0xd0fe8)")]
        NS_S_WMP_UI_VERSIONMISMATCH = 0x000D0FE8,
        [Description("Unknown error (0xd0fe9)")]
        NS_S_WMP_EXCEPTION = 0x000D0FE9,
        [Description("Unknown error (0xd1040)")]
        NS_S_WMP_LOADED_GIF_IMAGE = 0x000D1040,
        [Description("Unknown error (0xd1041)")]
        NS_S_WMP_LOADED_PNG_IMAGE = 0x000D1041,
        [Description("Unknown error (0xd1042)")]
        NS_S_WMP_LOADED_BMP_IMAGE = 0x000D1042,
        [Description("Unknown error (0xd1043)")]
        NS_S_WMP_LOADED_JPG_IMAGE = 0x000D1043,
        [Description("Unknown error (0xd104f)")]
        NS_S_WMG_FORCE_DROP_FRAME = 0x000D104F,
        [Description("Unknown error (0xd105f)")]
        NS_S_WMR_ALREADYRENDERED = 0x000D105F,
        [Description("Unknown error (0xd1060)")]
        NS_S_WMR_PINTYPEPARTIALMATCH = 0x000D1060,
        [Description("Unknown error (0xd1061)")]
        NS_S_WMR_PINTYPEFULLMATCH = 0x000D1061,
        [Description("Unknown error (0xd1066)")]
        NS_S_WMG_ADVISE_DROP_FRAME = 0x000D1066,
        [Description("Unknown error (0xd1067)")]
        NS_S_WMG_ADVISE_DROP_TO_KEYFRAME = 0x000D1067,
        [Description("Unknown error (0xd10db)")]
        NS_S_NEED_TO_BUY_BURN_RIGHTS = 0x000D10DB,
        [Description("Unknown error (0xd10fe)")]
        NS_S_WMPCORE_PLAYLISTCLEARABORT = 0x000D10FE,
        [Description("Unknown error (0xd10ff)")]
        NS_S_WMPCORE_PLAYLISTREMOVEITEMABORT = 0x000D10FF,
        [Description("Unknown error (0xd1102)")]
        NS_S_WMPCORE_PLAYLIST_CREATION_PENDING = 0x000D1102,
        [Description("Unknown error (0xd1103)")]
        NS_S_WMPCORE_MEDIA_VALIDATION_PENDING = 0x000D1103,
        [Description("Unknown error (0xd1104)")]
        NS_S_WMPCORE_PLAYLIST_REPEAT_SECONDARY_SEGMENTS_IGNORED = 0x000D1104,
        [Description("Unknown error (0xd1105)")]
        NS_S_WMPCORE_COMMAND_NOT_AVAILABLE = 0x000D1105,
        [Description("Unknown error (0xd1106)")]
        NS_S_WMPCORE_PLAYLIST_NAME_AUTO_GENERATED = 0x000D1106,
        [Description("Unknown error (0xd1107)")]
        NS_S_WMPCORE_PLAYLIST_IMPORT_MISSING_ITEMS = 0x000D1107,
        [Description("Unknown error (0xd1108)")]
        NS_S_WMPCORE_PLAYLIST_COLLAPSED_TO_SINGLE_MEDIA = 0x000D1108,
        [Description("Unknown error (0xd1109)")]
        NS_S_WMPCORE_MEDIA_CHILD_PLAYLIST_OPEN_PENDING = 0x000D1109,
        [Description("Unknown error (0xd110a)")]
        NS_S_WMPCORE_MORE_NODES_AVAIABLE = 0x000D110A,
        [Description("Unknown error (0xd1135)")]
        NS_S_WMPBR_SUCCESS = 0x000D1135,
        [Description("Unknown error (0xd1136)")]
        NS_S_WMPBR_PARTIALSUCCESS = 0x000D1136,
        [Description("Unknown error (0xd1144)")]
        NS_S_WMPEFFECT_TRANSPARENT = 0x000D1144,
        [Description("Unknown error (0xd1145)")]
        NS_S_WMPEFFECT_OPAQUE = 0x000D1145,
        [Description("Unknown error (0xd114e)")]
        NS_S_OPERATION_PENDING = 0x000D114E,
        [Description("Unknown error (0xd1359)")]
        NS_S_TRACK_BUY_REQUIRES_ALBUM_PURCHASE = 0x000D1359,
        [Description("Unknown error (0xd135e)")]
        NS_S_NAVIGATION_COMPLETE_WITH_ERRORS = 0x000D135E,
        [Description("Unknown error (0xd1361)")]
        NS_S_TRACK_ALREADY_DOWNLOADED = 0x000D1361,
        [Description("Unknown error (0xd1519)")]
        NS_S_PUBLISHING_POINT_STARTED_WITH_FAILED_SINKS = 0x000D1519,
        [Description("Unknown error (0xd2726)")]
        NS_S_DRM_LICENSE_ACQUIRED = 0x000D2726,
        [Description("Unknown error (0xd2727)")]
        NS_S_DRM_INDIVIDUALIZED = 0x000D2727,
        [Description("Unknown error (0xd2746)")]
        NS_S_DRM_MONITOR_CANCELLED = 0x000D2746,
        [Description("Unknown error (0xd2747)")]
        NS_S_DRM_ACQUIRE_CANCELLED = 0x000D2747,
        [Description("Unknown error (0xd276e)")]
        NS_S_DRM_BURNABLE_TRACK = 0x000D276E,
        [Description("Unknown error (0xd276f)")]
        NS_S_DRM_BURNABLE_TRACK_WITH_PLAYLIST_RESTRICTION = 0x000D276F,
        [Description("Unknown error (0xd27de)")]
        NS_S_DRM_NEEDS_INDIVIDUALIZATION = 0x000D27DE,
        [Description("Unknown error (0xd2af8)")]
        NS_S_REBOOT_RECOMMENDED = 0x000D2AF8,
        [Description("Unknown error (0xd2af9)")]
        NS_S_REBOOT_REQUIRED = 0x000D2AF9,
        [Description("Unknown error (0xd2f09)")]
        NS_S_EOSRECEDING = 0x000D2F09,
        [Description("Unknown error (0xd2f0d)")]
        NS_S_CHANGENOTICE = 0x000D2F0D,
        [Description("The IO was completed by a filter")]
        ERROR_FLT_IO_COMPLETE = 0x001F0001,
        [Description("No mode is pinned on the specified VidPN source/target")]
        ERROR_GRAPHICS_MODE_NOT_PINNED = 0x00262307,
        [Description("Specified mode set does not specify preference for one of its modes")]
        ERROR_GRAPHICS_NO_PREFERRED_MODE = 0x0026231E,
        [Description("Specified data set (e.g. mode set, frequency range set, descriptor set, topology, etc.) is empty")]
        ERROR_GRAPHICS_DATASET_IS_EMPTY = 0x0026234B,
        [Description("Specified data set (e.g. mode set, frequency range set, descriptor set, topology, etc.) does not contain any more elements")]
        ERROR_GRAPHICS_NO_MORE_ELEMENTS_IN_DATASET = 0x0026234C,
        [Description("Specified content transformation is not pinned on the specified VidPN present path")]
        ERROR_GRAPHICS_PATH_CONTENT_GEOMETRY_TRANSFORMATION_NOT_PINNED = 0x00262351,
        [Description("Property value will be ignored")]
        PLA_S_PROPERTY_IGNORED = 0x00300100,
        [Description("The request will be completed later by NDIS status indication")]
        ERROR_NDIS_INDICATION_REQUIRED = 0x00340001,
        [Description("Unknown error (0xdead100)")]
        TRK_S_OUT_OF_SYNC = 0x0DEAD100,
        [Description("Unknown error (0xdead102)")]
        TRK_VOLUME_NOT_FOUND = 0x0DEAD102,
        [Description("Unknown error (0xdead103)")]
        TRK_VOLUME_NOT_OWNED = 0x0DEAD103,
        [Description("Unknown error (0xdead107)")]
        TRK_S_NOTIFICATION_QUOTA_EXCEEDED = 0x0DEAD107,
        [Description("Unknown error (0x400d004f)")]
        NS_I_TIGER_START = 0x400D004F,
        [Description("Unknown error (0x400d0051)")]
        NS_I_CUB_START = 0x400D0051,
        [Description("Unknown error (0x400d0052)")]
        NS_I_CUB_RUNNING = 0x400D0052,
        [Description("Unknown error (0x400d0054)")]
        NS_I_DISK_START = 0x400D0054,
        [Description("Unknown error (0x400d0056)")]
        NS_I_DISK_REBUILD_STARTED = 0x400D0056,
        [Description("Unknown error (0x400d0057)")]
        NS_I_DISK_REBUILD_FINISHED = 0x400D0057,
        [Description("Unknown error (0x400d0058)")]
        NS_I_DISK_REBUILD_ABORTED = 0x400D0058,
        [Description("Unknown error (0x400d0059)")]
        NS_I_LIMIT_FUNNELS = 0x400D0059,
        [Description("Unknown error (0x400d005a)")]
        NS_I_START_DISK = 0x400D005A,
        [Description("Unknown error (0x400d005b)")]
        NS_I_STOP_DISK = 0x400D005B,
        [Description("Unknown error (0x400d005c)")]
        NS_I_STOP_CUB = 0x400D005C,
        [Description("Unknown error (0x400d005d)")]
        NS_I_KILL_USERSESSION = 0x400D005D,
        [Description("Unknown error (0x400d005e)")]
        NS_I_KILL_CONNECTION = 0x400D005E,
        [Description("Unknown error (0x400d005f)")]
        NS_I_REBUILD_DISK = 0x400D005F,
        [Description("Unknown error (0x400d0069)")]
        MCMADM_I_NO_EVENTS = 0x400D0069,
        [Description("Unknown error (0x400d006e)")]
        NS_I_LOGGING_FAILED = 0x400D006E,
        [Description("Unknown error (0x400d0070)")]
        NS_I_LIMIT_BANDWIDTH = 0x400D0070,
        [Description("Unknown error (0x400d0191)")]
        NS_I_CUB_UNFAIL_LINK = 0x400D0191,
        [Description("Unknown error (0x400d0193)")]
        NS_I_RESTRIPE_START = 0x400D0193,
        [Description("Unknown error (0x400d0194)")]
        NS_I_RESTRIPE_DONE = 0x400D0194,
        [Description("Unknown error (0x400d0196)")]
        NS_I_RESTRIPE_DISK_OUT = 0x400D0196,
        [Description("Unknown error (0x400d0197)")]
        NS_I_RESTRIPE_CUB_OUT = 0x400D0197,
        [Description("Unknown error (0x400d0198)")]
        NS_I_DISK_STOP = 0x400D0198,
        [Description("Unknown error (0x400d14be)")]
        NS_I_PLAYLIST_CHANGE_RECEDING = 0x400D14BE,
        [Description("Unknown error (0x400d2eff)")]
        NS_I_RECONNECTED = 0x400D2EFF,
        [Description("Unknown error (0x400d2f01)")]
        NS_I_NOLOG_STOP = 0x400D2F01,
        [Description("Unknown error (0x400d2f03)")]
        NS_I_EXISTING_PACKETIZER = 0x400D2F03,
        [Description("Unknown error (0x400d2f04)")]
        NS_I_MANUAL_PROXY = 0x400D2F04,
        [Description("Unknown error (0x40262009)")]
        ERROR_GRAPHICS_DRIVER_MISMATCH = 0x40262009,
        [Description("Child device presence was not reliably detected")]
        ERROR_GRAPHICS_UNKNOWN_CHILD_STATUS = 0x4026242F,
        [Description("Starting the leadlink adapter has been deferred temporarily")]
        ERROR_GRAPHICS_LEADLINK_START_DEFERRED = 0x40262437,
        [Description("The display adapter is being polled for children too frequently at the same polling level")]
        ERROR_GRAPHICS_POLLING_TOO_FREQUENTLY = 0x40262439,
        [Description("Starting the adapter has been deferred temporarily")]
        ERROR_GRAPHICS_START_DEFERRED = 0x4026243A,
        [Description("The data necessary to complete this operation is not yet available")]
        E_PENDING = 0x8000000A,
        [Description("Not implemented")]
        E_NOTIMPL = 0x80004001,
        [Description("No such interface supported")]
        E_NOINTERFACE = 0x80004002,
        [Description("Invalid pointer")]
        E_POINTER = 0x80004003,
        [Description("Operation aborted")]
        E_ABORT = 0x80004004,
        [Description("Unspecified error")]
        E_FAIL = 0x80004005,
        [Description("Thread local storage failure")]
        CO_E_INIT_TLS = 0x80004006,
        [Description("Get shared memory allocator failure")]
        CO_E_INIT_SHARED_ALLOCATOR = 0x80004007,
        [Description("Get memory allocator failure")]
        CO_E_INIT_MEMORY_ALLOCATOR = 0x80004008,
        [Description("Unable to initialize class cache")]
        CO_E_INIT_CLASS_CACHE = 0x80004009,
        [Description("Unable to initialize RPC services")]
        CO_E_INIT_RPC_CHANNEL = 0x8000400A,
        [Description("Cannot set thread local storage channel control")]
        CO_E_INIT_TLS_SET_CHANNEL_CONTROL = 0x8000400B,
        [Description("Could not allocate thread local storage channel control")]
        CO_E_INIT_TLS_CHANNEL_CONTROL = 0x8000400C,
        [Description("The user supplied memory allocator is unacceptable")]
        CO_E_INIT_UNACCEPTED_USER_ALLOCATOR = 0x8000400D,
        [Description("The OLE service mutex already exists")]
        CO_E_INIT_SCM_MUTEX_EXISTS = 0x8000400E,
        [Description("The OLE service file mapping already exists")]
        CO_E_INIT_SCM_FILE_MAPPING_EXISTS = 0x8000400F,
        [Description("Unable to map view of file for OLE service")]
        CO_E_INIT_SCM_MAP_VIEW_OF_FILE = 0x80004010,
        [Description("Failure attempting to launch OLE service")]
        CO_E_INIT_SCM_EXEC_FAILURE = 0x80004011,
        [Description("There was an attempt to call CoInitialize a second time while single threaded")]
        CO_E_INIT_ONLY_SINGLE_THREADED = 0x80004012,
        [Description("A Remote activation was necessary but was not allowed")]
        CO_E_CANT_REMOTE = 0x80004013,
        [Description("A Remote activation was necessary but the server name provided was invalid")]
        CO_E_BAD_SERVER_NAME = 0x80004014,
        [Description("The class is configured to run as a security id different from the caller")]
        CO_E_WRONG_SERVER_IDENTITY = 0x80004015,
        [Description("Use of Ole1 services requiring DDE windows is disabled")]
        CO_E_OLE1DDE_DISABLED = 0x80004016,
        [Description("A RunAs specification must be <domain name>\\<user name> or simply <user name>")]
        CO_E_RUNAS_SYNTAX = 0x80004017,
        [Description("The server process could not be started. The pathname may be incorrect")]
        CO_E_CREATEPROCESS_FAILURE = 0x80004018,
        [Description("The server process could not be started as the configured identity. The pathname may be incorrect or unavailable")]
        CO_E_RUNAS_CREATEPROCESS_FAILURE = 0x80004019,
        [Description("The server process could not be started because the configured identity is incorrect. Check the username and password")]
        CO_E_RUNAS_LOGON_FAILURE = 0x8000401A,
        [Description("The client is not allowed to launch this server")]
        CO_E_LAUNCH_PERMSSION_DENIED = 0x8000401B,
        [Description("The service providing this server could not be started")]
        CO_E_START_SERVICE_FAILURE = 0x8000401C,
        [Description("This computer was unable to communicate with the computer providing the server")]
        CO_E_REMOTE_COMMUNICATION_FAILURE = 0x8000401D,
        [Description("The server did not respond after being launched")]
        CO_E_SERVER_START_TIMEOUT = 0x8000401E,
        [Description("The registration information for this server is inconsistent or incomplete")]
        CO_E_CLSREG_INCONSISTENT = 0x8000401F,
        [Description("The registration information for this interface is inconsistent or incomplete")]
        CO_E_IIDREG_INCONSISTENT = 0x80004020,
        [Description("The operation attempted is not supported")]
        CO_E_NOT_SUPPORTED = 0x80004021,
        [Description("A dll must be loaded")]
        CO_E_RELOAD_DLL = 0x80004022,
        [Description("A Microsoft Software Installer error was encountered")]
        CO_E_MSI_ERROR = 0x80004023,
        [Description("The specified activation could not occur in the client context as specified")]
        CO_E_ATTEMPT_TO_CREATE_OUTSIDE_CLIENT_CONTEXT = 0x80004024,
        [Description("Activations on the server are paused")]
        CO_E_SERVER_PAUSED = 0x80004025,
        [Description("Activations on the server are not paused")]
        CO_E_SERVER_NOT_PAUSED = 0x80004026,
        [Description("The component or application containing the component has been disabled")]
        CO_E_CLASS_DISABLED = 0x80004027,
        [Description("The common language runtime is not available")]
        CO_E_CLRNOTAVAILABLE = 0x80004028,
        [Description("The thread-pool rejected the submitted asynchronous work")]
        CO_E_ASYNC_WORK_REJECTED = 0x80004029,
        [Description("The server started, but did not finish initializing in a timely fashion")]
        CO_E_SERVER_INIT_TIMEOUT = 0x8000402A,
        [Description("Unable to complete the call since there is no COM+ security context inside IObjectControl.Activate")]
        CO_E_NO_SECCTX_IN_ACTIVATE = 0x8000402B,
        [Description("The provided tracker configuration is invalid")]
        CO_E_TRACKER_CONFIG = 0x80004030,
        [Description("The provided thread pool configuration is invalid")]
        CO_E_THREADPOOL_CONFIG = 0x80004031,
        [Description("The provided side-by-side configuration is invalid")]
        CO_E_SXS_CONFIG = 0x80004032,
        [Description("The server principal name (SPN) obtained during security negotiation is malformed")]
        CO_E_MALFORMED_SPN = 0x80004033,
        [Description("Catastrophic failure")]
        E_UNEXPECTED = 0x8000FFFF,
        [Description("Call was rejected by callee")]
        RPC_E_CALL_REJECTED = 0x80010001,
        [Description("Call was canceled by the message filter")]
        RPC_E_CALL_CANCELED = 0x80010002,
        [Description("The caller is dispatching an intertask SendMessage call and cannot call out via PostMessage")]
        RPC_E_CANTPOST_INSENDCALL = 0x80010003,
        [Description("The caller is dispatching an asynchronous call and cannot make an outgoing call on behalf of this call")]
        RPC_E_CANTCALLOUT_INASYNCCALL = 0x80010004,
        [Description("It is illegal to call out while inside message filter")]
        RPC_E_CANTCALLOUT_INEXTERNALCALL = 0x80010005,
        [Description("The connection terminated or is in a bogus state and cannot be used any more. Other connections are still valid")]
        RPC_E_CONNECTION_TERMINATED = 0x80010006,
        [Description("The callee (server [not server application]) is not available and disappeared; all connections are invalid. The call may have executed")]
        RPC_E_SERVER_DIED = 0x80010007,
        [Description("The caller (client) disappeared while the callee (server) was processing a call")]
        RPC_E_CLIENT_DIED = 0x80010008,
        [Description("The data packet with the marshalled parameter data is incorrect")]
        RPC_E_INVALID_DATAPACKET = 0x80010009,
        [Description("The call was not transmitted properly; the message queue was full and was not emptied after yielding")]
        RPC_E_CANTTRANSMIT_CALL = 0x8001000A,
        [Description("The client (caller) cannot marshall the parameter data - low memory, etc")]
        RPC_E_CLIENT_CANTMARSHAL_DATA = 0x8001000B,
        [Description("The client (caller) cannot unmarshall the return data - low memory, etc")]
        RPC_E_CLIENT_CANTUNMARSHAL_DATA = 0x8001000C,
        [Description("The server (callee) cannot marshall the return data - low memory, etc")]
        RPC_E_SERVER_CANTMARSHAL_DATA = 0x8001000D,
        [Description("The server (callee) cannot unmarshall the parameter data - low memory, etc")]
        RPC_E_SERVER_CANTUNMARSHAL_DATA = 0x8001000E,
        [Description("Received data is invalid; could be server or client data")]
        RPC_E_INVALID_DATA = 0x8001000F,
        [Description("A particular parameter is invalid and cannot be (un)marshalled")]
        RPC_E_INVALID_PARAMETER = 0x80010010,
        [Description("There is no second outgoing call on same channel in DDE conversation")]
        RPC_E_CANTCALLOUT_AGAIN = 0x80010011,
        [Description("The callee (server [not server application]) is not available and disappeared; all connections are invalid. The call did not execute")]
        RPC_E_SERVER_DIED_DNE = 0x80010012,
        [Description("System call failed")]
        RPC_E_SYS_CALL_FAILED = 0x80010100,
        [Description("Could not allocate some required resource (memory, events, ...)")]
        RPC_E_OUT_OF_RESOURCES = 0x80010101,
        [Description("Attempted to make calls on more than one thread in single threaded mode")]
        RPC_E_ATTEMPTED_MULTITHREAD = 0x80010102,
        [Description("The requested interface is not registered on the server object")]
        RPC_E_NOT_REGISTERED = 0x80010103,
        [Description("RPC could not call the server or could not return the results of calling the server")]
        RPC_E_FAULT = 0x80010104,
        [Description("The server threw an exception")]
        RPC_E_SERVERFAULT = 0x80010105,
        [Description("Cannot change thread mode after it is set")]
        RPC_E_CHANGED_MODE = 0x80010106,
        [Description("The method called does not exist on the server")]
        RPC_E_INVALIDMETHOD = 0x80010107,
        [Description("The object invoked has disconnected from its clients")]
        RPC_E_DISCONNECTED = 0x80010108,
        [Description("The object invoked chose not to process the call now. Try again later")]
        RPC_E_RETRY = 0x80010109,
        [Description("The message filter indicated that the application is busy")]
        RPC_E_SERVERCALL_RETRYLATER = 0x8001010A,
        [Description("The message filter rejected the call")]
        RPC_E_SERVERCALL_REJECTED = 0x8001010B,
        [Description("A call control interfaces was called with invalid data")]
        RPC_E_INVALID_CALLDATA = 0x8001010C,
        [Description("An outgoing call cannot be made since the application is dispatching an input-synchronous call")]
        RPC_E_CANTCALLOUT_ININPUTSYNCCALL = 0x8001010D,
        [Description("The application called an interface that was marshalled for a different thread")]
        RPC_E_WRONG_THREAD = 0x8001010E,
        [Description("CoInitialize has not been called on the current thread")]
        RPC_E_THREAD_NOT_INIT = 0x8001010F,
        [Description("The version of OLE on the client and server machines does not match")]
        RPC_E_VERSION_MISMATCH = 0x80010110,
        [Description("OLE received a packet with an invalid header")]
        RPC_E_INVALID_HEADER = 0x80010111,
        [Description("OLE received a packet with an invalid extension")]
        RPC_E_INVALID_EXTENSION = 0x80010112,
        [Description("The requested object or interface does not exist")]
        RPC_E_INVALID_IPID = 0x80010113,
        [Description("The requested object does not exist")]
        RPC_E_INVALID_OBJECT = 0x80010114,
        [Description("OLE has sent a request and is waiting for a reply")]
        RPC_S_CALLPENDING = 0x80010115,
        [Description("OLE is waiting before retrying a request")]
        RPC_S_WAITONTIMER = 0x80010116,
        [Description("Call context cannot be accessed after call completed")]
        RPC_E_CALL_COMPLETE = 0x80010117,
        [Description("Impersonate on unsecure calls is not supported")]
        RPC_E_UNSECURE_CALL = 0x80010118,
        [Description("Security must be initialized before any interfaces are marshalled or unmarshalled. It cannot be changed once initialized")]
        RPC_E_TOO_LATE = 0x80010119,
        [Description("No security packages are installed on this machine or the user is not logged on or there are no compatible security packages between the client and server")]
        RPC_E_NO_GOOD_SECURITY_PACKAGES = 0x8001011A,
        [Description("Access is denied")]
        RPC_E_ACCESS_DENIED = 0x8001011B,
        [Description("Remote calls are not allowed for this process")]
        RPC_E_REMOTE_DISABLED = 0x8001011C,
        [Description("The marshaled interface data packet (OBJREF) has an invalid or unknown format")]
        RPC_E_INVALID_OBJREF = 0x8001011D,
        [Description("No context is associated with this call. This happens for some custom marshalled calls and on the client side of the call")]
        RPC_E_NO_CONTEXT = 0x8001011E,
        [Description("This operation returned because the timeout period expired")]
        RPC_E_TIMEOUT = 0x8001011F,
        [Description("There are no synchronize objects to wait on")]
        RPC_E_NO_SYNC = 0x80010120,
        [Description("Full subject issuer chain SSL principal name expected from the server")]
        RPC_E_FULLSIC_REQUIRED = 0x80010121,
        [Description("Principal name is not a valid MSSTD name")]
        RPC_E_INVALID_STD_NAME = 0x80010122,
        [Description("Unable to impersonate DCOM client")]
        CO_E_FAILEDTOIMPERSONATE = 0x80010123,
        [Description("Unable to obtain server's security context")]
        CO_E_FAILEDTOGETSECCTX = 0x80010124,
        [Description("Unable to open the access token of the current thread")]
        CO_E_FAILEDTOOPENTHREADTOKEN = 0x80010125,
        [Description("Unable to obtain user info from an access token")]
        CO_E_FAILEDTOGETTOKENINFO = 0x80010126,
        [Description("The client who called IAccessControl::IsAccessPermitted was not the trustee provided to the method")]
        CO_E_TRUSTEEDOESNTMATCHCLIENT = 0x80010127,
        [Description("Unable to obtain the client's security blanket")]
        CO_E_FAILEDTOQUERYCLIENTBLANKET = 0x80010128,
        [Description("Unable to set a discretionary ACL into a security descriptor")]
        CO_E_FAILEDTOSETDACL = 0x80010129,
        [Description("The system function, AccessCheck, returned false")]
        CO_E_ACCESSCHECKFAILED = 0x8001012A,
        [Description("Either NetAccessDel or NetAccessAdd returned an error code")]
        CO_E_NETACCESSAPIFAILED = 0x8001012B,
        [Description("One of the trustee strings provided by the user did not conform to the <Domain>\\<Name> syntax and it was not the \" * \" string")]
        CO_E_WRONGTRUSTEENAMESYNTAX = 0x8001012C,
        [Description("One of the security identifiers provided by the user was invalid")]
        CO_E_INVALIDSID = 0x8001012D,
        [Description("Unable to convert a wide character trustee string to a multibyte trustee string")]
        CO_E_CONVERSIONFAILED = 0x8001012E,
        [Description("Unable to find a security identifier that corresponds to a trustee string provided by the user")]
        CO_E_NOMATCHINGSIDFOUND = 0x8001012F,
        [Description("The system function, LookupAccountSID, failed")]
        CO_E_LOOKUPACCSIDFAILED = 0x80010130,
        [Description("Unable to find a trustee name that corresponds to a security identifier provided by the user")]
        CO_E_NOMATCHINGNAMEFOUND = 0x80010131,
        [Description("The system function, LookupAccountName, failed")]
        CO_E_LOOKUPACCNAMEFAILED = 0x80010132,
        [Description("Unable to set or reset a serialization handle")]
        CO_E_SETSERLHNDLFAILED = 0x80010133,
        [Description("Unable to obtain the Windows directory")]
        CO_E_FAILEDTOGETWINDIR = 0x80010134,
        [Description("Path too long")]
        CO_E_PATHTOOLONG = 0x80010135,
        [Description("Unable to generate a uuid")]
        CO_E_FAILEDTOGENUUID = 0x80010136,
        [Description("Unable to create file")]
        CO_E_FAILEDTOCREATEFILE = 0x80010137,
        [Description("Unable to close a serialization handle or a file handle")]
        CO_E_FAILEDTOCLOSEHANDLE = 0x80010138,
        [Description("The number of ACEs in an ACL exceeds the system limit")]
        CO_E_EXCEEDSYSACLLIMIT = 0x80010139,
        [Description("Not all the DENY_ACCESS ACEs are arranged in front of the GRANT_ACCESS ACEs in the stream")]
        CO_E_ACESINWRONGORDER = 0x8001013A,
        [Description("The version of ACL format in the stream is not supported by this implementation of IAccessControl")]
        CO_E_INCOMPATIBLESTREAMVERSION = 0x8001013B,
        [Description("Unable to open the access token of the server process")]
        CO_E_FAILEDTOOPENPROCESSTOKEN = 0x8001013C,
        [Description("Unable to decode the ACL in the stream provided by the user")]
        CO_E_DECODEFAILED = 0x8001013D,
        [Description("The COM IAccessControl object is not initialized")]
        CO_E_ACNOTINITIALIZED = 0x8001013F,
        [Description("Call Cancellation is disabled")]
        CO_E_CANCEL_DISABLED = 0x80010140,
        [Description("An internal error occurred")]
        RPC_E_UNEXPECTED = 0x8001FFFF,
        [Description("Unknown interface")]
        DISP_E_UNKNOWNINTERFACE = 0x80020001,
        [Description("Member not found")]
        DISP_E_MEMBERNOTFOUND = 0x80020003,
        [Description("Parameter not found")]
        DISP_E_PARAMNOTFOUND = 0x80020004,
        [Description("Type mismatch")]
        DISP_E_TYPEMISMATCH = 0x80020005,
        [Description("Unknown name")]
        DISP_E_UNKNOWNNAME = 0x80020006,
        [Description("No named arguments")]
        DISP_E_NONAMEDARGS = 0x80020007,
        [Description("Bad variable type")]
        DISP_E_BADVARTYPE = 0x80020008,
        [Description("Exception occurred")]
        DISP_E_EXCEPTION = 0x80020009,
        [Description("Out of present range")]
        DISP_E_OVERFLOW = 0x8002000A,
        [Description("Invalid index")]
        DISP_E_BADINDEX = 0x8002000B,
        [Description("Unknown language")]
        DISP_E_UNKNOWNLCID = 0x8002000C,
        [Description("Memory is locked")]
        DISP_E_ARRAYISLOCKED = 0x8002000D,
        [Description("Invalid number of parameters")]
        DISP_E_BADPARAMCOUNT = 0x8002000E,
        [Description("Parameter not optional")]
        DISP_E_PARAMNOTOPTIONAL = 0x8002000F,
        [Description("Invalid callee")]
        DISP_E_BADCALLEE = 0x80020010,
        [Description("Does not support a collection")]
        DISP_E_NOTACOLLECTION = 0x80020011,
        [Description("Division by zero")]
        DISP_E_DIVBYZERO = 0x80020012,
        [Description("Buffer too small")]
        DISP_E_BUFFERTOOSMALL = 0x80020013,
        [Description("Buffer too small")]
        TYPE_E_BUFFERTOOSMALL = 0x80028016,
        [Description("Field name not defined in the record")]
        TYPE_E_FIELDNOTFOUND = 0x80028017,
        [Description("Old format or invalid type library")]
        TYPE_E_INVDATAREAD = 0x80028018,
        [Description("Old format or invalid type library")]
        TYPE_E_UNSUPFORMAT = 0x80028019,
        [Description("Error accessing the OLE registry")]
        TYPE_E_REGISTRYACCESS = 0x8002801C,
        [Description("Library not registered")]
        TYPE_E_LIBNOTREGISTERED = 0x8002801D,
        [Description("Bound to unknown type")]
        TYPE_E_UNDEFINEDTYPE = 0x80028027,
        [Description("Qualified name disallowed")]
        TYPE_E_QUALIFIEDNAMEDISALLOWED = 0x80028028,
        [Description("Invalid forward reference, or reference to uncompiled type")]
        TYPE_E_INVALIDSTATE = 0x80028029,
        [Description("Type mismatch")]
        TYPE_E_WRONGTYPEKIND = 0x8002802A,
        [Description("Element not found")]
        TYPE_E_ELEMENTNOTFOUND = 0x8002802B,
        [Description("Ambiguous name")]
        TYPE_E_AMBIGUOUSNAME = 0x8002802C,
        [Description("Name already exists in the library")]
        TYPE_E_NAMECONFLICT = 0x8002802D,
        [Description("Unknown LCID")]
        TYPE_E_UNKNOWNLCID = 0x8002802E,
        [Description("Function not defined in specified DLL")]
        TYPE_E_DLLFUNCTIONNOTFOUND = 0x8002802F,
        [Description("Wrong module kind for the operation")]
        TYPE_E_BADMODULEKIND = 0x800288BD,
        [Description("Size may not exceed 64K")]
        TYPE_E_SIZETOOBIG = 0x800288C5,
        [Description("Duplicate ID in inheritance hierarchy")]
        TYPE_E_DUPLICATEID = 0x800288C6,
        [Description("Incorrect inheritance depth in standard OLE hmember")]
        TYPE_E_INVALIDID = 0x800288CF,
        [Description("Type mismatch")]
        TYPE_E_TYPEMISMATCH = 0x80028CA0,
        [Description("Invalid number of arguments")]
        TYPE_E_OUTOFBOUNDS = 0x80028CA1,
        [Description("I/O Error")]
        TYPE_E_IOERROR = 0x80028CA2,
        [Description("Error creating unique tmp file")]
        TYPE_E_CANTCREATETMPFILE = 0x80028CA3,
        [Description("Error loading type library/DLL")]
        TYPE_E_CANTLOADLIBRARY = 0x80029C4A,
        [Description("Inconsistent property functions")]
        TYPE_E_INCONSISTENTPROPFUNCS = 0x80029C83,
        [Description("Circular dependency between types/modules")]
        TYPE_E_CIRCULARTYPE = 0x80029C84,
        [Description("Unable to perform requested operation")]
        STG_E_INVALIDFUNCTION = 0x80030001,
        [Description("%1 could not be found")]
        STG_E_FILENOTFOUND = 0x80030002,
        [Description("The path %1 could not be found")]
        STG_E_PATHNOTFOUND = 0x80030003,
        [Description("There are insufficient resources to open another file")]
        STG_E_TOOMANYOPENFILES = 0x80030004,
        [Description("Access Denied")]
        STG_E_ACCESSDENIED = 0x80030005,
        [Description("Attempted an operation on an invalid object")]
        STG_E_INVALIDHANDLE = 0x80030006,
        [Description("There is insufficient memory available to complete operation")]
        STG_E_INSUFFICIENTMEMORY = 0x80030008,
        [Description("Invalid pointer error")]
        STG_E_INVALIDPOINTER = 0x80030009,
        [Description("There are no more entries to return")]
        STG_E_NOMOREFILES = 0x80030012,
        [Description("Disk is write-protected")]
        STG_E_DISKISWRITEPROTECTED = 0x80030013,
        [Description("An error occurred during a seek operation")]
        STG_E_SEEKERROR = 0x80030019,
        [Description("A disk error occurred during a write operation")]
        STG_E_WRITEFAULT = 0x8003001D,
        [Description("A disk error occurred during a read operation")]
        STG_E_READFAULT = 0x8003001E,
        [Description("A share violation has occurred")]
        STG_E_SHAREVIOLATION = 0x80030020,
        [Description("A lock violation has occurred")]
        STG_E_LOCKVIOLATION = 0x80030021,
        [Description("%1 already exists")]
        STG_E_FILEALREADYEXISTS = 0x80030050,
        [Description("Invalid parameter error")]
        STG_E_INVALIDPARAMETER = 0x80030057,
        [Description("There is insufficient disk space to complete operation")]
        STG_E_MEDIUMFULL = 0x80030070,
        [Description("Illegal write of non-simple property to simple property set")]
        STG_E_PROPSETMISMATCHED = 0x800300F0,
        [Description("An API call exited abnormally")]
        STG_E_ABNORMALAPIEXIT = 0x800300FA,
        [Description("The file %1 is not a valid compound file")]
        STG_E_INVALIDHEADER = 0x800300FB,
        [Description("The name %1 is not valid")]
        STG_E_INVALIDNAME = 0x800300FC,
        [Description("An unexpected error occurred")]
        STG_E_UNKNOWN = 0x800300FD,
        [Description("That function is not implemented")]
        STG_E_UNIMPLEMENTEDFUNCTION = 0x800300FE,
        [Description("Invalid flag error")]
        STG_E_INVALIDFLAG = 0x800300FF,
        [Description("Attempted to use an object that is busy")]
        STG_E_INUSE = 0x80030100,
        [Description("The storage has been changed since the last commit")]
        STG_E_NOTCURRENT = 0x80030101,
        [Description("Attempted to use an object that has ceased to exist")]
        STG_E_REVERTED = 0x80030102,
        [Description("Can't save")]
        STG_E_CANTSAVE = 0x80030103,
        [Description("The compound file %1 was produced with an incompatible version of storage")]
        STG_E_OLDFORMAT = 0x80030104,
        [Description("The compound file %1 was produced with a newer version of storage")]
        STG_E_OLDDLL = 0x80030105,
        [Description("Share.exe or equivalent is required for operation")]
        STG_E_SHAREREQUIRED = 0x80030106,
        [Description("Illegal operation called on non-file based storage")]
        STG_E_NOTFILEBASEDSTORAGE = 0x80030107,
        [Description("Illegal operation called on object with extant marshallings")]
        STG_E_EXTANTMARSHALLINGS = 0x80030108,
        [Description("The docfile has been corrupted")]
        STG_E_DOCFILECORRUPT = 0x80030109,
        [Description("OLE32.DLL has been loaded at the wrong address")]
        STG_E_BADBASEADDRESS = 0x80030110,
        [Description("The compound file is too large for the current implementation")]
        STG_E_DOCFILETOOLARGE = 0x80030111,
        [Description("The compound file was not created with the STGM_SIMPLE flag")]
        STG_E_NOTSIMPLEFORMAT = 0x80030112,
        [Description("The file download was aborted abnormally. The file is incomplete")]
        STG_E_INCOMPLETE = 0x80030201,
        [Description("The file download has been terminated")]
        STG_E_TERMINATED = 0x80030202,
        [Description("Generic Copy Protection Error")]
        STG_E_STATUS_COPY_PROTECTION_FAILURE = 0x80030305,
        [Description("Copy Protection Error - DVD CSS Authentication failed")]
        STG_E_CSS_AUTHENTICATION_FAILURE = 0x80030306,
        [Description("Copy Protection Error - The given sector does not have a valid CSS key")]
        STG_E_CSS_KEY_NOT_PRESENT = 0x80030307,
        [Description("Copy Protection Error - DVD session key not established")]
        STG_E_CSS_KEY_NOT_ESTABLISHED = 0x80030308,
        [Description("Copy Protection Error - The read failed because the sector is encrypted")]
        STG_E_CSS_SCRAMBLED_SECTOR = 0x80030309,
        [Description("Copy Protection Error - The current DVD's region does not correspond to the region setting of the drive")]
        STG_E_CSS_REGION_MISMATCH = 0x8003030A,
        [Description("Copy Protection Error - The drive's region setting may be permanent or the number of user resets has been exhausted")]
        STG_E_RESETS_EXHAUSTED = 0x8003030B,
        [Description("Invalid OLEVERB structure")]
        OLE_E_OLEVERB = 0x80040000,
        [Description("Invalid advise flags")]
        OLE_E_ADVF = 0x80040001,
        [Description("Can't enumerate any more, because the associated data is missing")]
        OLE_E_ENUM_NOMORE = 0x80040002,
        [Description("This implementation doesn't take advises")]
        OLE_E_ADVISENOTSUPPORTED = 0x80040003,
        [Description("There is no connection for this connection ID")]
        OLE_E_NOCONNECTION = 0x80040004,
        [Description("Need to run the object to perform this operation")]
        OLE_E_NOTRUNNING = 0x80040005,
        [Description("There is no cache to operate on")]
        OLE_E_NOCACHE = 0x80040006,
        [Description("Uninitialized object")]
        OLE_E_BLANK = 0x80040007,
        [Description("Linked object's source class has changed")]
        OLE_E_CLASSDIFF = 0x80040008,
        [Description("Not able to get the moniker of the object")]
        OLE_E_CANT_GETMONIKER = 0x80040009,
        [Description("Not able to bind to the source")]
        OLE_E_CANT_BINDTOSOURCE = 0x8004000A,
        [Description("Object is static; operation not allowed")]
        OLE_E_STATIC = 0x8004000B,
        [Description("User canceled out of save dialog")]
        OLE_E_PROMPTSAVECANCELLED = 0x8004000C,
        [Description("Invalid rectangle")]
        OLE_E_INVALIDRECT = 0x8004000D,
        [Description("compobj.dll is too old for the ole2.dll initialized")]
        OLE_E_WRONGCOMPOBJ = 0x8004000E,
        [Description("Invalid window handle")]
        OLE_E_INVALIDHWND = 0x8004000F,
        [Description("Object is not in any of the inplace active states")]
        OLE_E_NOT_INPLACEACTIVE = 0x80040010,
        [Description("Not able to convert object")]
        OLE_E_CANTCONVERT = 0x80040011,
        [Description("Not able to perform the operation because object is not given storage yet")]
        OLE_E_NOSTORAGE = 0x80040012,
        [Description("Invalid FORMATETC structure")]
        DV_E_FORMATETC = 0x80040064,
        [Description("Invalid DVTARGETDEVICE structure")]
        DV_E_DVTARGETDEVICE = 0x80040065,
        [Description("Invalid STDGMEDIUM structure")]
        DV_E_STGMEDIUM = 0x80040066,
        [Description("Invalid STATDATA structure")]
        DV_E_STATDATA = 0x80040067,
        [Description("Invalid lindex")]
        DV_E_LINDEX = 0x80040068,
        [Description("Invalid tymed")]
        DV_E_TYMED = 0x80040069,
        [Description("Invalid clipboard format")]
        DV_E_CLIPFORMAT = 0x8004006A,
        [Description("Invalid aspect(s)")]
        DV_E_DVASPECT = 0x8004006B,
        [Description("tdSize parameter of the DVTARGETDEVICE structure is invalid")]
        DV_E_DVTARGETDEVICE_SIZE = 0x8004006C,
        [Description("Object doesn't support IViewObject interface")]
        DV_E_NOIVIEWOBJECT = 0x8004006D,
        [Description("Trying to revoke a drop target that has not been registered")]
        DRAGDROP_E_NOTREGISTERED = 0x80040100,
        [Description("This window has already been registered as a drop target")]
        DRAGDROP_E_ALREADYREGISTERED = 0x80040101,
        [Description("Invalid window handle")]
        DRAGDROP_E_INVALIDHWND = 0x80040102,
        [Description("Class does not support aggregation (or class object is remote)")]
        CLASS_E_NOAGGREGATION = 0x80040110,
        [Description("ClassFactory cannot supply requested class")]
        CLASS_E_CLASSNOTAVAILABLE = 0x80040111,
        [Description("Class is not licensed for use")]
        CLASS_E_NOTLICENSED = 0x80040112,
        [Description("Error drawing view")]
        VIEW_E_DRAW = 0x80040140,
        [Description("Could not read key from registry")]
        REGDB_E_READREGDB = 0x80040150,
        [Description("Could not write key to registry")]
        REGDB_E_WRITEREGDB = 0x80040151,
        [Description("Could not find the key in the registry")]
        REGDB_E_KEYMISSING = 0x80040152,
        [Description("Invalid value for registry")]
        REGDB_E_INVALIDVALUE = 0x80040153,
        [Description("Class not registered")]
        REGDB_E_CLASSNOTREG = 0x80040154,
        [Description("Interface not registered")]
        REGDB_E_IIDNOTREG = 0x80040155,
        [Description("Threading model entry is not valid")]
        REGDB_E_BADTHREADINGMODEL = 0x80040156,
        [Description("CATID does not exist")]
        CAT_E_CATIDNOEXIST = 0x80040160,
        [Description("Description not found")]
        CAT_E_NODESCRIPTION = 0x80040161,
        [Description("No package in the software installation data in the Active Directory meets this criteria")]
        CS_E_PACKAGE_NOTFOUND = 0x80040164,
        [Description("Deleting this will break the referential integrity of the software installation data in the Active Directory")]
        CS_E_NOT_DELETABLE = 0x80040165,
        [Description("The CLSID was not found in the software installation data in the Active Directory")]
        CS_E_CLASS_NOTFOUND = 0x80040166,
        [Description("The software installation data in the Active Directory is corrupt")]
        CS_E_INVALID_VERSION = 0x80040167,
        [Description("There is no software installation data in the Active Directory")]
        CS_E_NO_CLASSSTORE = 0x80040168,
        [Description("There is no software installation data object in the Active Directory")]
        CS_E_OBJECT_NOTFOUND = 0x80040169,
        [Description("The software installation data object in the Active Directory already exists")]
        CS_E_OBJECT_ALREADY_EXISTS = 0x8004016A,
        [Description("The path to the software installation data in the Active Directory is not correct")]
        CS_E_INVALID_PATH = 0x8004016B,
        [Description("A network error interrupted the operation")]
        CS_E_NETWORK_ERROR = 0x8004016C,
        [Description("The size of this object exceeds the maximum size set by the Administrator")]
        CS_E_ADMIN_LIMIT_EXCEEDED = 0x8004016D,
        [Description("The schema for the software installation data in the Active Directory does not match the required schema")]
        CS_E_SCHEMA_MISMATCH = 0x8004016E,
        [Description("An error occurred in the software installation data in the Active Directory")]
        CS_E_INTERNAL_ERROR = 0x8004016F,
        [Description("Cache not updated")]
        CACHE_E_NOCACHE_UPDATED = 0x80040170,
        [Description("No verbs for OLE object")]
        OLEOBJ_E_NOVERBS = 0x80040180,
        [Description("Invalid verb for OLE object")]
        OLEOBJ_E_INVALIDVERB = 0x80040181,
        [Description("Undo is not available")]
        INPLACE_E_NOTUNDOABLE = 0x800401A0,
        [Description("Space for tools is not available")]
        INPLACE_E_NOTOOLSPACE = 0x800401A1,
        [Description("OLESTREAM Get method failed")]
        CONVERT10_E_OLESTREAM_GET = 0x800401C0,
        [Description("OLESTREAM Put method failed")]
        CONVERT10_E_OLESTREAM_PUT = 0x800401C1,
        [Description("Contents of the OLESTREAM not in correct format")]
        CONVERT10_E_OLESTREAM_FMT = 0x800401C2,
        [Description("There was an error in a Windows GDI call while converting the bitmap to a DIB")]
        CONVERT10_E_OLESTREAM_BITMAP_TO_DIB = 0x800401C3,
        [Description("Contents of the IStorage not in correct format")]
        CONVERT10_E_STG_FMT = 0x800401C4,
        [Description("Contents of IStorage is missing one of the standard streams")]
        CONVERT10_E_STG_NO_STD_STREAM = 0x800401C5,
        [Description("There was an error in a Windows GDI call while converting the DIB to a bitmap")]
        CONVERT10_E_STG_DIB_TO_BITMAP = 0x800401C6,
        [Description("OpenClipboard Failed")]
        CLIPBRD_E_CANT_OPEN = 0x800401D0,
        [Description("EmptyClipboard Failed")]
        CLIPBRD_E_CANT_EMPTY = 0x800401D1,
        [Description("SetClipboard Failed")]
        CLIPBRD_E_CANT_SET = 0x800401D2,
        [Description("Data on clipboard is invalid")]
        CLIPBRD_E_BAD_DATA = 0x800401D3,
        [Description("CloseClipboard Failed")]
        CLIPBRD_E_CANT_CLOSE = 0x800401D4,
        [Description("Moniker needs to be connected manually")]
        MK_E_CONNECTMANUALLY = 0x800401E0,
        [Description("Operation exceeded deadline")]
        MK_E_EXCEEDEDDEADLINE = 0x800401E1,
        [Description("Moniker needs to be generic")]
        MK_E_NEEDGENERIC = 0x800401E2,
        [Description("Operation unavailable")]
        MK_E_UNAVAILABLE = 0x800401E3,
        [Description("Invalid syntax")]
        MK_E_SYNTAX = 0x800401E4,
        [Description("No object for moniker")]
        MK_E_NOOBJECT = 0x800401E5,
        [Description("Bad extension for file")]
        MK_E_INVALIDEXTENSION = 0x800401E6,
        [Description("Intermediate operation failed")]
        MK_E_INTERMEDIATEINTERFACENOTSUPPORTED = 0x800401E7,
        [Description("Moniker is not bindable")]
        MK_E_NOTBINDABLE = 0x800401E8,
        [Description("Moniker is not bound")]
        MK_E_NOTBOUND = 0x800401E9,
        [Description("Moniker cannot open file")]
        MK_E_CANTOPENFILE = 0x800401EA,
        [Description("User input required for operation to succeed")]
        MK_E_MUSTBOTHERUSER = 0x800401EB,
        [Description("Moniker class has no inverse")]
        MK_E_NOINVERSE = 0x800401EC,
        [Description("Moniker does not refer to storage")]
        MK_E_NOSTORAGE = 0x800401ED,
        [Description("No common prefix")]
        MK_E_NOPREFIX = 0x800401EE,
        [Description("Moniker could not be enumerated")]
        MK_E_ENUMERATION_FAILED = 0x800401EF,
        [Description("CoInitialize has not been called")]
        CO_E_NOTINITIALIZED = 0x800401F0,
        [Description("CoInitialize has already been called")]
        CO_E_ALREADYINITIALIZED = 0x800401F1,
        [Description("Class of object cannot be determined")]
        CO_E_CANTDETERMINECLASS = 0x800401F2,
        [Description("Invalid class string")]
        CO_E_CLASSSTRING = 0x800401F3,
        [Description("Invalid interface string")]
        CO_E_IIDSTRING = 0x800401F4,
        [Description("Application not found")]
        CO_E_APPNOTFOUND = 0x800401F5,
        [Description("Application cannot be run more than once")]
        CO_E_APPSINGLEUSE = 0x800401F6,
        [Description("Some error in application program")]
        CO_E_ERRORINAPP = 0x800401F7,
        [Description("DLL for class not found")]
        CO_E_DLLNOTFOUND = 0x800401F8,
        [Description("Error in the DLL")]
        CO_E_ERRORINDLL = 0x800401F9,
        [Description("Wrong OS or OS version for application")]
        CO_E_WRONGOSFORAPP = 0x800401FA,
        [Description("Object is not registered")]
        CO_E_OBJNOTREG = 0x800401FB,
        [Description("Object is already registered")]
        CO_E_OBJISREG = 0x800401FC,
        [Description("Object is not connected to server")]
        CO_E_OBJNOTCONNECTED = 0x800401FD,
        [Description("Application was launched but it didn't register a class factory")]
        CO_E_APPDIDNTREG = 0x800401FE,
        [Description("Object has been released")]
        CO_E_RELEASED = 0x800401FF,
        [Description("An event was unable to invoke any of the subscribers")]
        EVENT_E_ALL_SUBSCRIBERS_FAILED = 0x80040201,
        [Description("A syntax error occurred trying to evaluate a query string")]
        EVENT_E_QUERYSYNTAX = 0x80040203,
        [Description("An invalid field name was used in a query string")]
        EVENT_E_QUERYFIELD = 0x80040204,
        [Description("An unexpected exception was raised")]
        EVENT_E_INTERNALEXCEPTION = 0x80040205,
        [Description("An unexpected internal error was detected")]
        EVENT_E_INTERNALERROR = 0x80040206,
        [Description("The owner SID on a per-user subscription doesn't exist")]
        EVENT_E_INVALID_PER_USER_SID = 0x80040207,
        [Description("A user-supplied component or subscriber raised an exception")]
        EVENT_E_USER_EXCEPTION = 0x80040208,
        [Description("An interface has too many methods to fire events from")]
        EVENT_E_TOO_MANY_METHODS = 0x80040209,
        [Description("A subscription cannot be stored unless its event class already exists")]
        EVENT_E_MISSING_EVENTCLASS = 0x8004020A,
        [Description("Not all the objects requested could be removed")]
        EVENT_E_NOT_ALL_REMOVED = 0x8004020B,
        [Description("COM+ is required for this operation, but is not installed")]
        EVENT_E_COMPLUS_NOT_INSTALLED = 0x8004020C,
        [Description("Cannot modify or delete an object that was not added using the COM+ Admin SDK")]
        EVENT_E_CANT_MODIFY_OR_DELETE_UNCONFIGURED_OBJECT = 0x8004020D,
        [Description("Cannot modify or delete an object that was added using the COM+ Admin SDK")]
        EVENT_E_CANT_MODIFY_OR_DELETE_CONFIGURED_OBJECT = 0x8004020E,
        [Description("The event class for this subscription is in an invalid partition")]
        EVENT_E_INVALID_EVENT_CLASS_PARTITION = 0x8004020F,
        [Description("The owner of the PerUser subscription is not logged on to the system specified")]
        EVENT_E_PER_USER_SID_NOT_LOGGED_ON = 0x80040210,
        [Description("Trigger not found")]
        SCHED_E_TRIGGER_NOT_FOUND = 0x80041309,
        [Description("One or more of the properties that are needed to run this task have not been set")]
        SCHED_E_TASK_NOT_READY = 0x8004130A,
        [Description("There is no running instance of the task")]
        SCHED_E_TASK_NOT_RUNNING = 0x8004130B,
        [Description("The Task Scheduler Service is not installed on this computer")]
        SCHED_E_SERVICE_NOT_INSTALLED = 0x8004130C,
        [Description("The task object could not be opened")]
        SCHED_E_CANNOT_OPEN_TASK = 0x8004130D,
        [Description("The object is either an invalid task object or is not a task object")]
        SCHED_E_INVALID_TASK = 0x8004130E,
        [Description("No account information could be found in the Task Scheduler security database for the task indicated")]
        SCHED_E_ACCOUNT_INFORMATION_NOT_SET = 0x8004130F,
        [Description("Unable to establish existence of the account specified")]
        SCHED_E_ACCOUNT_NAME_NOT_FOUND = 0x80041310,
        [Description("Corruption was detected in the Task Scheduler security database; the database has been reset")]
        SCHED_E_ACCOUNT_DBASE_CORRUPT = 0x80041311,
        [Description("Task Scheduler security services are available only on Windows NT")]
        SCHED_E_NO_SECURITY_SERVICES = 0x80041312,
        [Description("The task object version is either unsupported or invalid")]
        SCHED_E_UNKNOWN_OBJECT_VERSION = 0x80041313,
        [Description("The task has been configured with an unsupported combination of account settings and run time options")]
        SCHED_E_UNSUPPORTED_ACCOUNT_OPTION = 0x80041314,
        [Description("The Task Scheduler Service is not running")]
        SCHED_E_SERVICE_NOT_RUNNING = 0x80041315,
        [Description("The task XML contains an unexpected node")]
        SCHED_E_UNEXPECTEDNODE = 0x80041316,
        [Description("The task XML contains an element or attribute from an unexpected namespace")]
        SCHED_E_NAMESPACE = 0x80041317,
        [Description("The task XML contains a value which is incorrectly formatted or out of range")]
        SCHED_E_INVALIDVALUE = 0x80041318,
        [Description("The task XML is missing a required element or attribute")]
        SCHED_E_MISSINGNODE = 0x80041319,
        [Description("The task XML is malformed")]
        SCHED_E_MALFORMEDXML = 0x8004131A,
        [Description("The task XML contains too many nodes of the same type")]
        SCHED_E_TOO_MANY_NODES = 0x8004131D,
        [Description("The task cannot be started after the trigger's end boundary")]
        SCHED_E_PAST_END_BOUNDARY = 0x8004131E,
        [Description("An instance of this task is already running")]
        SCHED_E_ALREADY_RUNNING = 0x8004131F,
        [Description("The task will not run because the user is not logged on")]
        SCHED_E_USER_NOT_LOGGED_ON = 0x80041320,
        [Description("The task image is corrupt or has been tampered with")]
        SCHED_E_INVALID_TASK_HASH = 0x80041321,
        [Description("The Task Scheduler service is not available")]
        SCHED_E_SERVICE_NOT_AVAILABLE = 0x80041322,
        [Description("The Task Scheduler service is too busy to handle your request. Please try again later")]
        SCHED_E_SERVICE_TOO_BUSY = 0x80041323,
        [Description("The Task Scheduler service attempted to run the task, but the task did not run due to one of the constraints in the task definition")]
        SCHED_E_TASK_ATTEMPTED = 0x80041324,
        [Description("Another single phase resource manager has already been enlisted in this transaction")]
        XACT_E_ALREADYOTHERSINGLEPHASE = 0x8004D000,
        [Description("A retaining commit or abort is not supported")]
        XACT_E_CANTRETAIN = 0x8004D001,
        [Description("The transaction failed to commit for an unknown reason. The transaction was aborted")]
        XACT_E_COMMITFAILED = 0x8004D002,
        [Description("Cannot call commit on this transaction object because the calling application did not initiate the transaction")]
        XACT_E_COMMITPREVENTED = 0x8004D003,
        [Description("Instead of committing, the resource heuristically aborted")]
        XACT_E_HEURISTICABORT = 0x8004D004,
        [Description("Instead of aborting, the resource heuristically committed")]
        XACT_E_HEURISTICCOMMIT = 0x8004D005,
        [Description("Some of the states of the resource were committed while others were aborted, likely because of heuristic decisions")]
        XACT_E_HEURISTICDAMAGE = 0x8004D006,
        [Description("Some of the states of the resource may have been committed while others may have been aborted, likely because of heuristic decisions")]
        XACT_E_HEURISTICDANGER = 0x8004D007,
        [Description("The requested isolation level is not valid or supported")]
        XACT_E_ISOLATIONLEVEL = 0x8004D008,
        [Description("The transaction manager doesn't support an asynchronous operation for this method")]
        XACT_E_NOASYNC = 0x8004D009,
        [Description("Unable to enlist in the transaction")]
        XACT_E_NOENLIST = 0x8004D00A,
        [Description("The requested semantics of retention of isolation across retaining commit and abort boundaries cannot be supported by this transaction implementation, or isoFlags was not equal to zero")]
        XACT_E_NOISORETAIN = 0x8004D00B,
        [Description("There is no resource presently associated with this enlistment")]
        XACT_E_NORESOURCE = 0x8004D00C,
        [Description("The transaction failed to commit due to the failure of optimistic concurrency control in at least one of the resource managers")]
        XACT_E_NOTCURRENT = 0x8004D00D,
        [Description("The transaction has already been implicitly or explicitly committed or aborted")]
        XACT_E_NOTRANSACTION = 0x8004D00E,
        [Description("An invalid combination of flags was specified")]
        XACT_E_NOTSUPPORTED = 0x8004D00F,
        [Description("The resource manager id is not associated with this transaction or the transaction manager")]
        XACT_E_UNKNOWNRMGRID = 0x8004D010,
        [Description("This method was called in the wrong state")]
        XACT_E_WRONGSTATE = 0x8004D011,
        [Description("The indicated unit of work does not match the unit of work expected by the resource manager")]
        XACT_E_WRONGUOW = 0x8004D012,
        [Description("An enlistment in a transaction already exists")]
        XACT_E_XTIONEXISTS = 0x8004D013,
        [Description("An import object for the transaction could not be found")]
        XACT_E_NOIMPORTOBJECT = 0x8004D014,
        [Description("The transaction cookie is invalid")]
        XACT_E_INVALIDCOOKIE = 0x8004D015,
        [Description("The transaction status is in doubt. A communication failure occurred, or a transaction manager or resource manager has failed")]
        XACT_E_INDOUBT = 0x8004D016,
        [Description("A time-out was specified, but time-outs are not supported")]
        XACT_E_NOTIMEOUT = 0x8004D017,
        [Description("The requested operation is already in progress for the transaction")]
        XACT_E_ALREADYINPROGRESS = 0x8004D018,
        [Description("The transaction has already been aborted")]
        XACT_E_ABORTED = 0x8004D019,
        [Description("The Transaction Manager returned a log full error")]
        XACT_E_LOGFULL = 0x8004D01A,
        [Description("The Transaction Manager is not available")]
        XACT_E_TMNOTAVAILABLE = 0x8004D01B,
        [Description("A connection with the transaction manager was lost")]
        XACT_E_CONNECTION_DOWN = 0x8004D01C,
        [Description("A request to establish a connection with the transaction manager was denied")]
        XACT_E_CONNECTION_DENIED = 0x8004D01D,
        [Description("Resource manager reenlistment to determine transaction status timed out")]
        XACT_E_REENLISTTIMEOUT = 0x8004D01E,
        [Description("This transaction manager failed to establish a connection with another TIP transaction manager")]
        XACT_E_TIP_CONNECT_FAILED = 0x8004D01F,
        [Description("This transaction manager encountered a protocol error with another TIP transaction manager")]
        XACT_E_TIP_PROTOCOL_ERROR = 0x8004D020,
        [Description("This transaction manager could not propagate a transaction from another TIP transaction manager")]
        XACT_E_TIP_PULL_FAILED = 0x8004D021,
        [Description("The Transaction Manager on the destination machine is not available")]
        XACT_E_DEST_TMNOTAVAILABLE = 0x8004D022,
        [Description("The Transaction Manager has disabled its support for TIP")]
        XACT_E_TIP_DISABLED = 0x8004D023,
        [Description("The transaction manager has disabled its support for remote/network transactions")]
        XACT_E_NETWORK_TX_DISABLED = 0x8004D024,
        [Description("The partner transaction manager has disabled its support for remote/network transactions")]
        XACT_E_PARTNER_NETWORK_TX_DISABLED = 0x8004D025,
        [Description("The transaction manager has disabled its support for XA transactions")]
        XACT_E_XA_TX_DISABLED = 0x8004D026,
        [Description("MSDTC was unable to read its configuration information")]
        XACT_E_UNABLE_TO_READ_DTC_CONFIG = 0x8004D027,
        [Description("MSDTC was unable to load the dtc proxy dll")]
        XACT_E_UNABLE_TO_LOAD_DTC_PROXY = 0x8004D028,
        [Description("The local transaction has aborted")]
        XACT_E_ABORTING = 0x8004D029,
        [Description("XACT_E_CLERKNOTFOUND")]
        XACT_E_CLERKNOTFOUND = 0x8004D080,
        [Description("XACT_E_CLERKEXISTS")]
        XACT_E_CLERKEXISTS = 0x8004D081,
        [Description("XACT_E_RECOVERYINPROGRESS")]
        XACT_E_RECOVERYINPROGRESS = 0x8004D082,
        [Description("XACT_E_TRANSACTIONCLOSED")]
        XACT_E_TRANSACTIONCLOSED = 0x8004D083,
        [Description("XACT_E_INVALIDLSN")]
        XACT_E_INVALIDLSN = 0x8004D084,
        [Description("XACT_E_REPLAYREQUEST")]
        XACT_E_REPLAYREQUEST = 0x8004D085,
        [Description("The request to connect to the specified transaction coordinator was denied")]
        XACT_E_CONNECTION_REQUEST_DENIED = 0x8004D100,
        [Description("The maximum number of enlistments for the specified transaction has been reached")]
        XACT_E_TOOMANY_ENLISTMENTS = 0x8004D101,
        [Description("A resource manager with the same identifier is already registered with the specified transaction coordinator")]
        XACT_E_DUPLICATE_GUID = 0x8004D102,
        [Description("The prepare request given was not eligible for single phase optimizations")]
        XACT_E_NOTSINGLEPHASE = 0x8004D103,
        [Description("RecoveryComplete has already been called for the given resource manager")]
        XACT_E_RECOVERYALREADYDONE = 0x8004D104,
        [Description("The interface call made was incorrect for the current state of the protocol")]
        XACT_E_PROTOCOL = 0x8004D105,
        [Description("xa_open call failed for the XA resource")]
        XACT_E_RM_FAILURE = 0x8004D106,
        [Description("xa_recover call failed for the XA resource")]
        XACT_E_RECOVERY_FAILED = 0x8004D107,
        [Description("The Logical Unit of Work specified cannot be found")]
        XACT_E_LU_NOT_FOUND = 0x8004D108,
        [Description("The specified Logical Unit of Work already exists")]
        XACT_E_DUPLICATE_LU = 0x8004D109,
        [Description("Subordinate creation failed. The specified Logical Unit of Work was not connected")]
        XACT_E_LU_NOT_CONNECTED = 0x8004D10A,
        [Description("A transaction with the given identifier already exists")]
        XACT_E_DUPLICATE_TRANSID = 0x8004D10B,
        [Description("The resource is in use")]
        XACT_E_LU_BUSY = 0x8004D10C,
        [Description("The LU Recovery process is down")]
        XACT_E_LU_NO_RECOVERY_PROCESS = 0x8004D10D,
        [Description("The remote session was lost")]
        XACT_E_LU_DOWN = 0x8004D10E,
        [Description("The resource is currently recovering")]
        XACT_E_LU_RECOVERING = 0x8004D10F,
        [Description("There was a mismatch in driving recovery")]
        XACT_E_LU_RECOVERY_MISMATCH = 0x8004D110,
        [Description("An error occurred with the XA resource")]
        XACT_E_RM_UNAVAILABLE = 0x8004D111,
        [Description("The root transaction wanted to commit, but transaction aborted")]
        CONTEXT_E_ABORTED = 0x8004E002,
        [Description("You made a method call on a COM+ component that has a transaction that has already aborted or in the process of aborting")]
        CONTEXT_E_ABORTING = 0x8004E003,
        [Description("There is no MTS object context")]
        CONTEXT_E_NOCONTEXT = 0x8004E004,
        [Description("The component is configured to use synchronization and this method call would cause a deadlock to occur")]
        CONTEXT_E_WOULD_DEADLOCK = 0x8004E005,
        [Description("The component is configured to use synchronization and a thread has timed out waiting to enter the context")]
        CONTEXT_E_SYNCH_TIMEOUT = 0x8004E006,
        [Description("You made a method call on a COM+ component that has a transaction that has already committed or aborted")]
        CONTEXT_E_OLDREF = 0x8004E007,
        [Description("The specified role was not configured for the application")]
        CONTEXT_E_ROLENOTFOUND = 0x8004E00C,
        [Description("COM+ was unable to talk to the Microsoft Distributed Transaction Coordinator")]
        CONTEXT_E_TMNOTAVAILABLE = 0x8004E00F,
        [Description("An unexpected error occurred during COM+ Activation")]
        CO_E_ACTIVATIONFAILED = 0x8004E021,
        [Description("COM+ Activation failed. Check the event log for more information")]
        CO_E_ACTIVATIONFAILED_EVENTLOGGED = 0x8004E022,
        [Description("COM+ Activation failed due to a catalog or configuration error")]
        CO_E_ACTIVATIONFAILED_CATALOGERROR = 0x8004E023,
        [Description("COM+ activation failed because the activation could not be completed in the specified amount of time")]
        CO_E_ACTIVATIONFAILED_TIMEOUT = 0x8004E024,
        [Description("COM+ Activation failed because an initialization function failed. Check the event log for more information")]
        CO_E_INITIALIZATIONFAILED = 0x8004E025,
        [Description("The requested operation requires that JIT be in the current context and it is not")]
        CONTEXT_E_NOJIT = 0x8004E026,
        [Description("The requested operation requires that the current context have a Transaction, and it does not")]
        CONTEXT_E_NOTRANSACTION = 0x8004E027,
        [Description("The components threading model has changed after install into a COM+ Application. Please re-install component")]
        CO_E_THREADINGMODEL_CHANGED = 0x8004E028,
        [Description("IIS intrinsics not available. Start your work with IIS")]
        CO_E_NOIISINTRINSICS = 0x8004E029,
        [Description("An attempt to write a cookie failed")]
        CO_E_NOCOOKIES = 0x8004E02A,
        [Description("An attempt to use a database generated a database specific error")]
        CO_E_DBERROR = 0x8004E02B,
        [Description("The COM+ component you created must use object pooling to work")]
        CO_E_NOTPOOLED = 0x8004E02C,
        [Description("The COM+ component you created must use object construction to work correctly")]
        CO_E_NOTCONSTRUCTED = 0x8004E02D,
        [Description("The COM+ component requires synchronization, and it is not configured for it")]
        CO_E_NOSYNCHRONIZATION = 0x8004E02E,
        [Description("The TxIsolation Level property for the COM+ component being created is stronger than the TxIsolationLevel for the \"root\" component for the transaction. The creation failed")]
        CO_E_ISOLEVELMISMATCH = 0x8004E02F,
        [Description("The component attempted to make a cross-context call between invocations of EnterTransactionScopeand ExitTransactionScope. This is not allowed. Cross-context calls cannot be made while inside of a transaction scope")]
        CO_E_CALL_OUT_OF_TX_SCOPE_NOT_ALLOWED = 0x8004E030,
        [Description("The component made a call to EnterTransactionScope, but did not make a corresponding call to ExitTransactionScope before returning")]
        CO_E_EXIT_TRANSACTION_SCOPE_NOT_CALLED = 0x8004E031,
        [Description("Access is denied")]
        E_ACCESSDENIED = 0x80070005,
        [Description("Not enough storage is available to complete this operation")]
        E_OUTOFMEMORY = 0x8007000E,
        [Description("The request is not supported")]
        ERROR_NOT_SUPPORTED = 0x80070032,
        [Description("The parameter is incorrect")]
        E_INVALIDARG = 0x80070057,
        [Description("There is not enough space on the disk")]
        ERROR_DISK_FULL = 0x80070070,
        [Description("Attempt to create a class object failed")]
        CO_E_CLASS_CREATE_FAILED = 0x80080001,
        [Description("OLE service could not bind object")]
        CO_E_SCM_ERROR = 0x80080002,
        [Description("RPC communication failed with OLE service")]
        CO_E_SCM_RPC_FAILURE = 0x80080003,
        [Description("Bad path to object")]
        CO_E_BAD_PATH = 0x80080004,
        [Description("Server execution failed")]
        CO_E_SERVER_EXEC_FAILURE = 0x80080005,
        [Description("OLE service could not communicate with the object server")]
        CO_E_OBJSRV_RPC_FAILURE = 0x80080006,
        [Description("Moniker path could not be normalized")]
        MK_E_NO_NORMALIZED = 0x80080007,
        [Description("Object server is stopping when OLE service contacts it")]
        CO_E_SERVER_STOPPING = 0x80080008,
        [Description("An invalid root block pointer was specified")]
        MEM_E_INVALID_ROOT = 0x80080009,
        [Description("An allocation chain contained an invalid link pointer")]
        MEM_E_INVALID_LINK = 0x80080010,
        [Description("The requested allocation size was too large")]
        MEM_E_INVALID_SIZE = 0x80080011,
        [Description("The activation requires a display name to be present under the CLSID key")]
        CO_E_MISSING_DISPLAYNAME = 0x80080015,
        [Description("The activation requires that the RunAs value for the application is Activate As Activator")]
        CO_E_RUNAS_VALUE_MUST_BE_AAA = 0x80080016,
        [Description("The class is not configured to support Elevated activation")]
        CO_E_ELEVATION_DISABLED = 0x80080017,
        [Description("Bad UID")]
        NTE_BAD_UID = 0x80090001,
        [Description("Bad Hash")]
        NTE_BAD_HASH = 0x80090002,
        [Description("Bad Key")]
        NTE_BAD_KEY = 0x80090003,
        [Description("Bad Length")]
        NTE_BAD_LEN = 0x80090004,
        [Description("Bad Data")]
        NTE_BAD_DATA = 0x80090005,
        [Description("Invalid Signature")]
        NTE_BAD_SIGNATURE = 0x80090006,
        [Description("Bad Version of provider")]
        NTE_BAD_VER = 0x80090007,
        [Description("Invalid algorithm specified")]
        NTE_BAD_ALGID = 0x80090008,
        [Description("Invalid flags specified")]
        NTE_BAD_FLAGS = 0x80090009,
        [Description("Invalid type specified")]
        NTE_BAD_TYPE = 0x8009000A,
        [Description("Key not valid for use in specified state")]
        NTE_BAD_KEY_STATE = 0x8009000B,
        [Description("Hash not valid for use in specified state")]
        NTE_BAD_HASH_STATE = 0x8009000C,
        [Description("Key does not exist")]
        NTE_NO_KEY = 0x8009000D,
        [Description("Insufficient memory available for the operation")]
        NTE_NO_MEMORY = 0x8009000E,
        [Description("Object already exists")]
        NTE_EXISTS = 0x8009000F,
        [Description("Access denied")]
        NTE_PERM = 0x80090010,
        [Description("Object was not found")]
        NTE_NOT_FOUND = 0x80090011,
        [Description("Data already encrypted")]
        NTE_DOUBLE_ENCRYPT = 0x80090012,
        [Description("Invalid provider specified")]
        NTE_BAD_PROVIDER = 0x80090013,
        [Description("Invalid provider type specified")]
        NTE_BAD_PROV_TYPE = 0x80090014,
        [Description("Provider's public key is invalid")]
        NTE_BAD_PUBLIC_KEY = 0x80090015,
        [Description("Keyset does not exist")]
        NTE_BAD_KEYSET = 0x80090016,
        [Description("Provider type not defined")]
        NTE_PROV_TYPE_NOT_DEF = 0x80090017,
        [Description("Provider type as registered is invalid")]
        NTE_PROV_TYPE_ENTRY_BAD = 0x80090018,
        [Description("The keyset is not defined")]
        NTE_KEYSET_NOT_DEF = 0x80090019,
        [Description("Keyset as registered is invalid")]
        NTE_KEYSET_ENTRY_BAD = 0x8009001A,
        [Description("Provider type does not match registered value")]
        NTE_PROV_TYPE_NO_MATCH = 0x8009001B,
        [Description("The digital signature file is corrupt")]
        NTE_SIGNATURE_FILE_BAD = 0x8009001C,
        [Description("Provider DLL failed to initialize correctly")]
        NTE_PROVIDER_DLL_FAIL = 0x8009001D,
        [Description("Provider DLL could not be found")]
        NTE_PROV_DLL_NOT_FOUND = 0x8009001E,
        [Description("The Keyset parameter is invalid")]
        NTE_BAD_KEYSET_PARAM = 0x8009001F,
        [Description("An internal error occurred")]
        NTE_FAIL = 0x80090020,
        [Description("A base error occurred")]
        NTE_SYS_ERR = 0x80090021,
        [Description("Provider could not perform the action since the context was acquired as silent")]
        NTE_SILENT_CONTEXT = 0x80090022,
        [Description("The security token does not have storage space available for an additional container")]
        NTE_TOKEN_KEYSET_STORAGE_FULL = 0x80090023,
        [Description("The profile for the user is a temporary profile")]
        NTE_TEMPORARY_PROFILE = 0x80090024,
        [Description("The key parameters could not be set because the CSP uses fixed parameters")]
        NTE_FIXEDPARAMETER = 0x80090025,
        [Description("The supplied handle is invalid")]
        NTE_INVALID_HANDLE = 0x80090026,
        [Description("The parameter is incorrect")]
        NTE_INVALID_PARAMETER = 0x80090027,
        [Description("The buffer supplied to a function was too small")]
        NTE_BUFFER_TOO_SMALL = 0x80090028,
        [Description("The requested operation is not supported")]
        NTE_NOT_SUPPORTED = 0x80090029,
        [Description("No more data is available")]
        NTE_NO_MORE_ITEMS = 0x8009002A,
        [Description("The supplied buffers overlap incorrectly")]
        NTE_BUFFERS_OVERLAP = 0x8009002B,
        [Description("The specified data could not be decrypted")]
        NTE_DECRYPTION_FAILURE = 0x8009002C,
        [Description("An internal consistency check failed")]
        NTE_INTERNAL_ERROR = 0x8009002D,
        [Description("This operation requires input from the user")]
        NTE_UI_REQUIRED = 0x8009002E,
        [Description("The cryptographic provider does not support HMAC")]
        NTE_HMAC_NOT_SUPPORTED = 0x8009002F,
        [Description("Not enough memory is available to complete this request")]
        SEC_E_INSUFFICIENT_MEMORY = 0x80090300,
        [Description("The handle specified is invalid")]
        SEC_E_INVALID_HANDLE = 0x80090301,
        [Description("The function requested is not supported")]
        SEC_E_UNSUPPORTED_FUNCTION = 0x80090302,
        [Description("The specified target is unknown or unreachable")]
        SEC_E_TARGET_UNKNOWN = 0x80090303,
        [Description("The Local Security Authority cannot be contacted")]
        SEC_E_INTERNAL_ERROR = 0x80090304,
        [Description("The requested security package does not exist")]
        SEC_E_SECPKG_NOT_FOUND = 0x80090305,
        [Description("The caller is not the owner of the desired credentials")]
        SEC_E_NOT_OWNER = 0x80090306,
        [Description("The security package failed to initialize, and cannot be installed")]
        SEC_E_CANNOT_INSTALL = 0x80090307,
        [Description("The token supplied to the function is invalid")]
        SEC_E_INVALID_TOKEN = 0x80090308,
        [Description("The security package is not able to marshall the logon buffer, so the logon attempt has failed")]
        SEC_E_CANNOT_PACK = 0x80090309,
        [Description("The per-message Quality of Protection is not supported by the security package")]
        SEC_E_QOP_NOT_SUPPORTED = 0x8009030A,
        [Description("The security context does not allow impersonation of the client")]
        SEC_E_NO_IMPERSONATION = 0x8009030B,
        [Description("The logon attempt failed")]
        SEC_E_LOGON_DENIED = 0x8009030C,
        [Description("The credentials supplied to the package were not recognized")]
        SEC_E_UNKNOWN_CREDENTIALS = 0x8009030D,
        [Description("No credentials are available in the security package")]
        SEC_E_NO_CREDENTIALS = 0x8009030E,
        [Description("The message or signature supplied for verification has been altered")]
        SEC_E_MESSAGE_ALTERED = 0x8009030F,
        [Description("The message supplied for verification is out of sequence")]
        SEC_E_OUT_OF_SEQUENCE = 0x80090310,
        [Description("No authority could be contacted for authentication")]
        SEC_E_NO_AUTHENTICATING_AUTHORITY = 0x80090311,
        [Description("The requested security package does not exist")]
        SEC_E_BAD_PKGID = 0x80090316,
        [Description("The context has expired and can no longer be used")]
        SEC_E_CONTEXT_EXPIRED = 0x80090317,
        [Description("The supplied message is incomplete. The signature was not verified")]
        SEC_E_INCOMPLETE_MESSAGE = 0x80090318,
        [Description("The credentials supplied were not complete, and could not be verified. The context could not be initialized")]
        SEC_E_INCOMPLETE_CREDENTIALS = 0x80090320,
        [Description("The buffers supplied to a function was too small")]
        SEC_E_BUFFER_TOO_SMALL = 0x80090321,
        [Description("The target principal name is incorrect")]
        SEC_E_WRONG_PRINCIPAL = 0x80090322,
        [Description("The clocks on the client and server machines are skewed")]
        SEC_E_TIME_SKEW = 0x80090324,
        [Description("The certificate chain was issued by an authority that is not trusted")]
        SEC_E_UNTRUSTED_ROOT = 0x80090325,
        [Description("The message received was unexpected or badly formatted")]
        SEC_E_ILLEGAL_MESSAGE = 0x80090326,
        [Description("An unknown error occurred while processing the certificate")]
        SEC_E_CERT_UNKNOWN = 0x80090327,
        [Description("The received certificate has expired")]
        SEC_E_CERT_EXPIRED = 0x80090328,
        [Description("The specified data could not be encrypted")]
        SEC_E_ENCRYPT_FAILURE = 0x80090329,
        [Description("The specified data could not be decrypted")]
        SEC_E_DECRYPT_FAILURE = 0x80090330,
        [Description("The client and server cannot communicate, because they do not possess a common algorithm")]
        SEC_E_ALGORITHM_MISMATCH = 0x80090331,
        [Description("The security context could not be established due to a failure in the requested quality of service (e.g. mutual authentication or delegation)")]
        SEC_E_SECURITY_QOS_FAILED = 0x80090332,
        [Description("A security context was deleted before the context was completed. This is considered a logon failure")]
        SEC_E_UNFINISHED_CONTEXT_DELETED = 0x80090333,
        [Description("The client is trying to negotiate a context and the server requires user-to-user but didn't send a TGT reply")]
        SEC_E_NO_TGT_REPLY = 0x80090334,
        [Description("Unable to accomplish the requested task because the local machine does not have any IP addresses")]
        SEC_E_NO_IP_ADDRESSES = 0x80090335,
        [Description("The supplied credential handle does not match the credential associated with the security context")]
        SEC_E_WRONG_CREDENTIAL_HANDLE = 0x80090336,
        [Description("The crypto system or checksum function is invalid because a required function is unavailable")]
        SEC_E_CRYPTO_SYSTEM_INVALID = 0x80090337,
        [Description("The number of maximum ticket referrals has been exceeded")]
        SEC_E_MAX_REFERRALS_EXCEEDED = 0x80090338,
        [Description("The local machine must be a Kerberos KDC (domain controller) and it is not")]
        SEC_E_MUST_BE_KDC = 0x80090339,
        [Description("The other end of the security negotiation is requires strong crypto but it is not supported on the local machine")]
        SEC_E_STRONG_CRYPTO_NOT_SUPPORTED = 0x8009033A,
        [Description("The KDC reply contained more than one principal name")]
        SEC_E_TOO_MANY_PRINCIPALS = 0x8009033B,
        [Description("Expected to find PA data for a hint of what etype to use, but it was not found")]
        SEC_E_NO_PA_DATA = 0x8009033C,
        [Description("The client certificate does not contain a valid UPN, or does not match the client name in the logon request. Please contact your administrator")]
        SEC_E_PKINIT_NAME_MISMATCH = 0x8009033D,
        [Description("Smartcard logon is required and was not used")]
        SEC_E_SMARTCARD_LOGON_REQUIRED = 0x8009033E,
        [Description("A system shutdown is in progress")]
        SEC_E_SHUTDOWN_IN_PROGRESS = 0x8009033F,
        [Description("An invalid request was sent to the KDC")]
        SEC_E_KDC_INVALID_REQUEST = 0x80090340,
        [Description("The KDC was unable to generate a referral for the service requested")]
        SEC_E_KDC_UNABLE_TO_REFER = 0x80090341,
        [Description("The encryption type requested is not supported by the KDC")]
        SEC_E_KDC_UNKNOWN_ETYPE = 0x80090342,
        [Description("An unsupported preauthentication mechanism was presented to the Kerberos package")]
        SEC_E_UNSUPPORTED_PREAUTH = 0x80090343,
        [Description("The requested operation cannot be completed. The computer must be trusted for delegation and the current user account must be configured to allow delegation")]
        SEC_E_DELEGATION_REQUIRED = 0x80090345,
        [Description("Client's supplied SSPI channel bindings were incorrect")]
        SEC_E_BAD_BINDINGS = 0x80090346,
        [Description("The received certificate was mapped to multiple accounts")]
        SEC_E_MULTIPLE_ACCOUNTS = 0x80090347,
        [Description("SEC_E_NO_KERB_KEY")]
        SEC_E_NO_KERB_KEY = 0x80090348,
        [Description("The certificate is not valid for the requested usage")]
        SEC_E_CERT_WRONG_USAGE = 0x80090349,
        [Description("The system cannot contact a domain controller to service the authentication request. Please try again later")]
        SEC_E_DOWNGRADE_DETECTED = 0x80090350,
        [Description("The smartcard certificate used for authentication has been revoked. Please contact your system administrator. There may be additional information in the event log")]
        SEC_E_SMARTCARD_CERT_REVOKED = 0x80090351,
        [Description("An untrusted certificate authority was detected while processing the smartcard certificate used for authentication. Please contact your system administrator")]
        SEC_E_ISSUING_CA_UNTRUSTED = 0x80090352,
        [Description("The revocation status of the smartcard certificate used for authentication could not be determined. Please contact your system administrator")]
        SEC_E_REVOCATION_OFFLINE_C = 0x80090353,
        [Description("The smartcard certificate used for authentication was not trusted. Please contact your system administrator")]
        SEC_E_PKINIT_CLIENT_FAILURE = 0x80090354,
        [Description("The smartcard certificate used for authentication has expired. Please contact your system administrator")]
        SEC_E_SMARTCARD_CERT_EXPIRED = 0x80090355,
        [Description("The Kerberos subsystem encountered an error. A service for user protocol request was made against a domain controller which does not support service for user")]
        SEC_E_NO_S4U_PROT_SUPPORT = 0x80090356,
        [Description("An attempt was made by this server to make a Kerberos constrained delegation request for a target outside of the server's realm. This is not supported, and indicates a misconfiguration on this server's allowed to delegate to list. Please contact your administrator")]
        SEC_E_CROSSREALM_DELEGATION_FAILURE = 0x80090357,
        [Description("The revocation status of the domain controller certificate used for smartcard authentication could not be determined. There is additional information in the system event log. Please contact your system administrator")]
        SEC_E_REVOCATION_OFFLINE_KDC = 0x80090358,
        [Description("An untrusted certificate authority was detected while processing the domain controller certificate used for authentication. There is additional information in the system event log. Please contact your system administrator")]
        SEC_E_ISSUING_CA_UNTRUSTED_KDC = 0x80090359,
        [Description("The domain controller certificate used for smartcard logon has expired. Please contact your system administrator with the contents of your system event log")]
        SEC_E_KDC_CERT_EXPIRED = 0x8009035A,
        [Description("The domain controller certificate used for smartcard logon has been revoked. Please contact your system administrator with the contents of your system event log")]
        SEC_E_KDC_CERT_REVOKED = 0x8009035B,
        [Description("One or more of the parameters passed to the function was invalid")]
        SEC_E_INVALID_PARAMETER = 0x8009035D,
        [Description("Client policy does not allow credential delegation to target server")]
        SEC_E_DELEGATION_POLICY = 0x8009035E,
        [Description("Client policy does not allow credential delegation to target server with NLTM only authentication")]
        SEC_E_POLICY_NLTM_ONLY = 0x8009035F,
        [Description("An error occurred while performing an operation on a cryptographic message")]
        CRYPT_E_MSG_ERROR = 0x80091001,
        [Description("Unknown cryptographic algorithm")]
        CRYPT_E_UNKNOWN_ALGO = 0x80091002,
        [Description("The object identifier is poorly formatted")]
        CRYPT_E_OID_FORMAT = 0x80091003,
        [Description("Invalid cryptographic message type")]
        CRYPT_E_INVALID_MSG_TYPE = 0x80091004,
        [Description("Unexpected cryptographic message encoding")]
        CRYPT_E_UNEXPECTED_ENCODING = 0x80091005,
        [Description("The cryptographic message does not contain an expected authenticated attribute")]
        CRYPT_E_AUTH_ATTR_MISSING = 0x80091006,
        [Description("The hash value is not correct")]
        CRYPT_E_HASH_VALUE = 0x80091007,
        [Description("The index value is not valid")]
        CRYPT_E_INVALID_INDEX = 0x80091008,
        [Description("The content of the cryptographic message has already been decrypted")]
        CRYPT_E_ALREADY_DECRYPTED = 0x80091009,
        [Description("The content of the cryptographic message has not been decrypted yet")]
        CRYPT_E_NOT_DECRYPTED = 0x8009100A,
        [Description("The enveloped-data message does not contain the specified recipient")]
        CRYPT_E_RECIPIENT_NOT_FOUND = 0x8009100B,
        [Description("Invalid control type")]
        CRYPT_E_CONTROL_TYPE = 0x8009100C,
        [Description("Invalid issuer and/or serial number")]
        CRYPT_E_ISSUER_SERIALNUMBER = 0x8009100D,
        [Description("Cannot find the original signer")]
        CRYPT_E_SIGNER_NOT_FOUND = 0x8009100E,
        [Description("The cryptographic message does not contain all of the requested attributes")]
        CRYPT_E_ATTRIBUTES_MISSING = 0x8009100F,
        [Description("The streamed cryptographic message is not ready to return data")]
        CRYPT_E_STREAM_MSG_NOT_READY = 0x80091010,
        [Description("The streamed cryptographic message requires more data to complete the decode operation")]
        CRYPT_E_STREAM_INSUFFICIENT_DATA = 0x80091011,
        [Description("The length specified for the output data was insufficient")]
        CRYPT_E_BAD_LEN = 0x80092001,
        [Description("An error occurred during encode or decode operation")]
        CRYPT_E_BAD_ENCODE = 0x80092002,
        [Description("An error occurred while reading or writing to a file")]
        CRYPT_E_FILE_ERROR = 0x80092003,
        [Description("Cannot find object or property")]
        CRYPT_E_NOT_FOUND = 0x80092004,
        [Description("The object or property already exists")]
        CRYPT_E_EXISTS = 0x80092005,
        [Description("No provider was specified for the store or object")]
        CRYPT_E_NO_PROVIDER = 0x80092006,
        [Description("The specified certificate is self signed")]
        CRYPT_E_SELF_SIGNED = 0x80092007,
        [Description("The previous certificate or CRL context was deleted")]
        CRYPT_E_DELETED_PREV = 0x80092008,
        [Description("Cannot find the requested object")]
        CRYPT_E_NO_MATCH = 0x80092009,
        [Description("The certificate does not have a property that references a private key")]
        CRYPT_E_UNEXPECTED_MSG_TYPE = 0x8009200A,
        [Description("Cannot find the certificate and private key for decryption")]
        CRYPT_E_NO_KEY_PROPERTY = 0x8009200B,
        [Description("Cannot find the certificate and private key to use for decryption")]
        CRYPT_E_NO_DECRYPT_CERT = 0x8009200C,
        [Description("Not a cryptographic message or the cryptographic message is not formatted correctly")]
        CRYPT_E_BAD_MSG = 0x8009200D,
        [Description("The signed cryptographic message does not have a signer for the specified signer index")]
        CRYPT_E_NO_SIGNER = 0x8009200E,
        [Description("Final closure is pending until additional frees or closes")]
        CRYPT_E_PENDING_CLOSE = 0x8009200F,
        [Description("The certificate is revoked")]
        CRYPT_E_REVOKED = 0x80092010,
        [Description("No Dll or exported function was found to verify revocation")]
        CRYPT_E_NO_REVOCATION_DLL = 0x80092011,
        [Description("The revocation function was unable to check revocation for the certificate")]
        CRYPT_E_NO_REVOCATION_CHECK = 0x80092012,
        [Description("The revocation function was unable to check revocation because the revocation server was offline")]
        CRYPT_E_REVOCATION_OFFLINE = 0x80092013,
        [Description("The certificate is not in the revocation server's database")]
        CRYPT_E_NOT_IN_REVOCATION_DATABASE = 0x80092014,
        [Description("The string contains a non-numeric character")]
        CRYPT_E_INVALID_NUMERIC_STRING = 0x80092020,
        [Description("The string contains a non-printable character")]
        CRYPT_E_INVALID_PRINTABLE_STRING = 0x80092021,
        [Description("The string contains a character not in the 7 bit ASCII character set")]
        CRYPT_E_INVALID_IA5_STRING = 0x80092022,
        [Description("The string contains an invalid X500 name attribute key, oid, value or delimiter")]
        CRYPT_E_INVALID_X500_STRING = 0x80092023,
        [Description("The dwValueType for the CERT_NAME_VALUE is not one of the character strings. Most likely it is either a CERT_RDN_ENCODED_BLOB or CERT_RDN_OCTET_STRING")]
        CRYPT_E_NOT_CHAR_STRING = 0x80092024,
        [Description("The Put operation cannot continue. The file needs to be resized. However, there is already a signature present. A complete signing operation must be done")]
        CRYPT_E_FILERESIZED = 0x80092025,
        [Description("The cryptographic operation failed due to a local security option setting")]
        CRYPT_E_SECURITY_SETTINGS = 0x80092026,
        [Description("No DLL or exported function was found to verify subject usage")]
        CRYPT_E_NO_VERIFY_USAGE_DLL = 0x80092027,
        [Description("The called function was unable to do a usage check on the subject")]
        CRYPT_E_NO_VERIFY_USAGE_CHECK = 0x80092028,
        [Description("Since the server was offline, the called function was unable to complete the usage check")]
        CRYPT_E_VERIFY_USAGE_OFFLINE = 0x80092029,
        [Description("The subject was not found in a Certificate Trust List (CTL)")]
        CRYPT_E_NOT_IN_CTL = 0x8009202A,
        [Description("None of the signers of the cryptographic message or certificate trust list is trusted")]
        CRYPT_E_NO_TRUSTED_SIGNER = 0x8009202B,
        [Description("The public key's algorithm parameters are missing")]
        CRYPT_E_MISSING_PUBKEY_PARA = 0x8009202C,
        [Description("OSS Certificate encode/decode error. code base See asn1code.h for a definition of the OSS runtime errors.The OSS error values are offset by CRYPT_E_OSS_ERROR")]
        
        CRYPT_E_OSS_ERROR = 0x80093000,
        [Description("OSS ASN.1 Error: Output Buffer is too small")]
        
        OSS_MORE_BUF = 0x80093001,
        [Description("OSS ASN.1 Error: Signed integer is encoded as a unsigned integer")]
        
        OSS_NEGATIVE_UINTEGER = 0x80093002,
        [Description("OSS ASN.1 Error: Unknown ASN.1 data type")]
        
        OSS_PDU_RANGE = 0x80093003,
        [Description("OSS ASN.1 Error: Output buffer is too small, the decoded data has been truncated")]
        
        OSS_MORE_INPUT = 0x80093004,
        [Description("OSS ASN.1 Error: Invalid data")]
        
        OSS_DATA_ERROR = 0x80093005,
        [Description("OSS ASN.1 Error: Invalid argument")]
        
        OSS_BAD_ARG = 0x80093006,
        [Description("OSS ASN.1 Error: Encode/Decode version mismatch")]
        
        OSS_BAD_VERSION = 0x80093007,
        [Description("OSS ASN.1 Error: Out of memory")]
        
        OSS_OUT_MEMORY = 0x80093008,
        [Description("OSS ASN.1 Error: Encode/Decode Error")]
        
        OSS_PDU_MISMATCH = 0x80093009,
        [Description("OSS ASN.1 Error: Internal Error")]
        
        OSS_LIMITED = 0x8009300A,
        [Description("OSS ASN.1 Error: Invalid data")]
        
        OSS_BAD_PTR = 0x8009300B,
        [Description("OSS ASN.1 Error: Invalid data")]
        
        OSS_BAD_TIME = 0x8009300C,
        [Description("OSS ASN.1 Error: Unsupported BER indefinite-length encoding")]
        
        OSS_INDEFINITE_NOT_SUPPORTED = 0x8009300D,
        [Description("OSS ASN.1 Error: Access violation")]
        
        OSS_MEM_ERROR = 0x8009300E,
        [Description("OSS ASN.1 Error: Invalid data")]
        
        OSS_BAD_TABLE = 0x8009300F,
        [Description("OSS ASN.1 Error: Invalid data")]
        
        OSS_TOO_LONG = 0x80093010,
        [Description("OSS ASN.1 Error: Invalid data")]
        
        OSS_CONSTRAINT_VIOLATED = 0x80093011,
        [Description("OSS ASN.1 Error: Internal Error")]
        
        OSS_FATAL_ERROR = 0x80093012,
        [Description("OSS ASN.1 Error: Multi-threading conflict")]
        
        OSS_ACCESS_SERIALIZATION_ERROR = 0x80093013,
        [Description("OSS ASN.1 Error: Invalid data")]
        
        OSS_NULL_TBL = 0x80093014,
        [Description("OSS ASN.1 Error: Invalid data")]
        
        OSS_NULL_FCN = 0x80093015,
        [Description("OSS ASN.1 Error: Invalid data")]
        
        OSS_BAD_ENCRULES = 0x80093016,
        [Description("OSS ASN.1 Error: Encode/Decode function not implemented")]
        
        OSS_UNAVAIL_ENCRULES = 0x80093017,
        [Description("OSS ASN.1 Error: Trace file error")]
        
        OSS_CANT_OPEN_TRACE_WINDOW = 0x80093018,
        [Description("OSS ASN.1 Error: Function not implemented")]
        
        OSS_UNIMPLEMENTED = 0x80093019,
        [Description("OSS ASN.1 Error: Program link error")]
        
        OSS_OID_DLL_NOT_LINKED = 0x8009301A,
        [Description("OSS ASN.1 Error: Trace file error")]
        
        OSS_CANT_OPEN_TRACE_FILE = 0x8009301B,
        [Description("OSS ASN.1 Error: Trace file error")]
        
        OSS_TRACE_FILE_ALREADY_OPEN = 0x8009301C,
        [Description("OSS ASN.1 Error: Invalid data")]
        
        OSS_TABLE_MISMATCH = 0x8009301D,
        [Description("OSS ASN.1 Error: Invalid data")]
        
        OSS_TYPE_NOT_SUPPORTED = 0x8009301E,
        [Description("OSS ASN.1 Error: Program link error")]
        
        OSS_REAL_DLL_NOT_LINKED = 0x8009301F,
        [Description("OSS ASN.1 Error: Program link error")]
        
        OSS_REAL_CODE_NOT_LINKED = 0x80093020,
        [Description("OSS ASN.1 Error: Program link error")]
        
        OSS_OUT_OF_RANGE = 0x80093021,
        [Description("OSS ASN.1 Error: Program link error")]
        
        OSS_COPIER_DLL_NOT_LINKED = 0x80093022,
        [Description("OSS ASN.1 Error: Program link error")]
        
        OSS_CONSTRAINT_DLL_NOT_LINKED = 0x80093023,
        [Description("OSS ASN.1 Error: Program link error")]
        
        OSS_COMPARATOR_DLL_NOT_LINKED = 0x80093024,
        [Description("OSS ASN.1 Error: Program link error")]
        
        OSS_COMPARATOR_CODE_NOT_LINKED = 0x80093025,
        [Description("OSS ASN.1 Error: Program link error")]
        
        OSS_MEM_MGR_DLL_NOT_LINKED = 0x80093026,
        [Description("OSS ASN.1 Error: Program link error")]
        
        OSS_PDV_DLL_NOT_LINKED = 0x80093027,
        [Description("OSS ASN.1 Error: Program link error")]
        
        OSS_PDV_CODE_NOT_LINKED = 0x80093028,
        [Description("OSS ASN.1 Error: Program link error")]
        
        OSS_API_DLL_NOT_LINKED = 0x80093029,
        [Description("OSS ASN.1 Error: Program link error")]
        
        OSS_BERDER_DLL_NOT_LINKED = 0x8009302A,
        [Description("OSS ASN.1 Error: Program link error")]
        
        OSS_PER_DLL_NOT_LINKED = 0x8009302B,
        [Description("OSS ASN.1 Error: Program link error")]
        
        OSS_OPEN_TYPE_ERROR = 0x8009302C,
        [Description("OSS ASN.1 Error: System resource error")]
        
        OSS_MUTEX_NOT_CREATED = 0x8009302D,
        [Description("OSS ASN.1 Error: Trace file error")]
        
        OSS_CANT_CLOSE_TRACE_FILE = 0x8009302E,
        [Description("ASN1 Certificate encode/decode error code base. The ASN1 error values are offset by CRYPT_E_ASN1_ERROR")]
        
        CRYPT_E_ASN1_ERROR = 0x80093100,
        [Description("ASN1 internal encode or decode error")]
        
        CRYPT_E_ASN1_INTERNAL = 0x80093101,
        [Description("ASN1 unexpected end of data")]
        
        CRYPT_E_ASN1_EOD = 0x80093102,
        [Description("ASN1 corrupted data")]
        
        CRYPT_E_ASN1_CORRUPT = 0x80093103,
        [Description("ASN1 value too large")]
        
        CRYPT_E_ASN1_LARGE = 0x80093104,
        [Description("ASN1 constraint violated")]
        
        CRYPT_E_ASN1_CONSTRAINT = 0x80093105,
        [Description("ASN1 out of memory")]
        
        CRYPT_E_ASN1_MEMORY = 0x80093106,
        [Description("ASN1 buffer overflow")]
        
        CRYPT_E_ASN1_OVERFLOW = 0x80093107,
        [Description("ASN1 function not supported for this PDU")]
        
        CRYPT_E_ASN1_BADPDU = 0x80093108,
        [Description("ASN1 bad arguments to function call")]
        
        CRYPT_E_ASN1_BADARGS = 0x80093109,
        [Description("ASN1 bad real value")]
        
        CRYPT_E_ASN1_BADREAL = 0x8009310A,
        [Description("ASN1 bad tag value met")]
        
        CRYPT_E_ASN1_BADTAG = 0x8009310B,
        [Description("ASN1 bad choice value")]
        
        CRYPT_E_ASN1_CHOICE = 0x8009310C,
        [Description("ASN1 bad encoding rule")]
        
        CRYPT_E_ASN1_RULE = 0x8009310D,
        [Description("ASN1 bad unicode (UTF8)")]
        
        CRYPT_E_ASN1_UTF8 = 0x8009310E,
        [Description("ASN1 bad PDU type")]
        
        CRYPT_E_ASN1_PDU_TYPE = 0x80093133,
        [Description("ASN1 not yet implemented")]
        
        CRYPT_E_ASN1_NYI = 0x80093134,
        [Description("ASN1 skipped unknown extension(s)")]
        
        CRYPT_E_ASN1_EXTENDED = 0x80093201,
        [Description("ASN1 end of data expected")]
        
        CRYPT_E_ASN1_NOEOD = 0x80093202,
        [Description("The request subject name is invalid or too long")]
        
        CERTSRV_E_BAD_REQUESTSUBJECT = 0x80094001,
        [Description("The request does not exist")]
        
        CERTSRV_E_NO_REQUEST = 0x80094002,
        [Description("The request's current status does not allow this operation")]
        
        CERTSRV_E_BAD_REQUESTSTATUS = 0x80094003,
        [Description("The requested property value is empty")]
        
        CERTSRV_E_PROPERTY_EMPTY = 0x80094004,
        [Description("The certification authority's certificate contains invalid data")]
        
        CERTSRV_E_INVALID_CA_CERTIFICATE = 0x80094005,
        [Description("Certificate service has been suspended for a database restore operation")]
        
        CERTSRV_E_SERVER_SUSPENDED = 0x80094006,
        [Description("The certificate contains an encoded length that is potentially incompatible with older enrollment software")]
        
        CERTSRV_E_ENCODING_LENGTH = 0x80094007,
        [Description("The operation is denied. The user has multiple roles assigned and the certification authority is configured to enforce role separation")]
        
        CERTSRV_E_ROLECONFLICT = 0x80094008,
        [Description("The operation is denied. It can only be performed by a certificate manager that is allowed to manage certificates for the current requester")]
        
        CERTSRV_E_RESTRICTEDOFFICER = 0x80094009,
        [Description("Cannot archive private key. The certification authority is not configured for key archival")]
        
        CERTSRV_E_KEY_ARCHIVAL_NOT_CONFIGURED = 0x8009400A,
        [Description("Cannot archive private key. The certification authority could not verify one or more key recovery certificates")]
        
        CERTSRV_E_NO_VALID_KRA = 0x8009400B,
        [Description("The request is incorrectly formatted. The encrypted private key must be in an unauthenticated attribute in an outermost signature")]
        
        CERTSRV_E_BAD_REQUEST_KEY_ARCHIVAL = 0x8009400C,
        [Description("At least one security principal must have the permission to manage this CA")]
        
        CERTSRV_E_NO_CAADMIN_DEFINED = 0x8009400D,
        [Description("The request contains an invalid renewal certificate attribute")]
        
        CERTSRV_E_BAD_RENEWAL_CERT_ATTRIBUTE = 0x8009400E,
        [Description("An attempt was made to open a Certification Authority database session, but there are already too many active sessions. The server may need to be configured to allow additional sessions")]
        
        CERTSRV_E_NO_DB_SESSIONS = 0x8009400F,
        [Description("A memory reference caused a data alignment fault")]
        
        CERTSRV_E_ALIGNMENT_FAULT = 0x80094010,
        [Description("The permissions on this certification authority do not allow the current user to enroll for certificates")]
        
        CERTSRV_E_ENROLL_DENIED = 0x80094011,
        [Description("The permissions on the certificate template do not allow the current user to enroll for this type of certificate")]
        
        CERTSRV_E_TEMPLATE_DENIED = 0x80094012,
        [Description("The contacted domain controller cannot support signed LDAP traffic. Update the domain controller or configure Certificate Services to use SSL for Active Directory access")]
        
        CERTSRV_E_DOWNLEVEL_DC_SSL_OR_UPGRADE = 0x80094013,
        [Description("The requested certificate template is not supported by this CA")]
        
        CERTSRV_E_UNSUPPORTED_CERT_TYPE = 0x80094800,
        [Description("The request contains no certificate template information")]
        
        CERTSRV_E_NO_CERT_TYPE = 0x80094801,
        [Description("The request contains conflicting template information")]
        
        CERTSRV_E_TEMPLATE_CONFLICT = 0x80094802,
        [Description("The request is missing a required Subject Alternate name extension")]
        
        CERTSRV_E_SUBJECT_ALT_NAME_REQUIRED = 0x80094803,
        [Description("The request is missing a required private key for archival by the server")]
        
        CERTSRV_E_ARCHIVED_KEY_REQUIRED = 0x80094804,
        [Description("The request is missing a required SMIME capabilities extension")]
        
        CERTSRV_E_SMIME_REQUIRED = 0x80094805,
        [Description("The request was made on behalf of a subject other than the caller. The certificate template must be configured to require at least one signature to authorize the request")]
        
        CERTSRV_E_BAD_RENEWAL_SUBJECT = 0x80094806,
        [Description("The request template version is newer than the supported template version")]
        
        CERTSRV_E_BAD_TEMPLATE_VERSION = 0x80094807,
        [Description("The template is missing a required signature policy attribute")]
        
        CERTSRV_E_TEMPLATE_POLICY_REQUIRED = 0x80094808,
        [Description("The request is missing required signature policy information")]
        
        CERTSRV_E_SIGNATURE_POLICY_REQUIRED = 0x80094809,
        [Description("The request is missing one or more required signatures")]
        
        CERTSRV_E_SIGNATURE_COUNT = 0x8009480A,
        [Description("One or more signatures did not include the required application or issuance policies. The request is missing one or more required valid signatures")]
        
        CERTSRV_E_SIGNATURE_REJECTED = 0x8009480B,
        [Description("The request is missing one or more required signature issuance policies")]
        
        CERTSRV_E_ISSUANCE_POLICY_REQUIRED = 0x8009480C,
        [Description("The UPN is unavailable and cannot be added to the Subject Alternate name")]
        
        CERTSRV_E_SUBJECT_UPN_REQUIRED = 0x8009480D,
        [Description("The Active Directory GUID is unavailable and cannot be added to the Subject Alternate name")]
        
        CERTSRV_E_SUBJECT_DIRECTORY_GUID_REQUIRED = 0x8009480E,
        [Description("The DNS name is unavailable and cannot be added to the Subject Alternate name")]
        
        CERTSRV_E_SUBJECT_DNS_REQUIRED = 0x8009480F,
        [Description("The request includes a private key for archival by the server, but key archival is not enabled for the specified certificate template")]
        
        CERTSRV_E_ARCHIVED_KEY_UNEXPECTED = 0x80094810,
        [Description("The public key does not meet the minimum size required by the specified certificate template")]
        
        CERTSRV_E_KEY_LENGTH = 0x80094811,
        [Description("The EMail name is unavailable and cannot be added to the Subject or Subject Alternate name")]
        
        CERTSRV_E_SUBJECT_EMAIL_REQUIRED = 0x80094812,
        [Description("One or more certificate templates to be enabled on this certification authority could not be found")]
        
        CERTSRV_E_UNKNOWN_CERT_TYPE = 0x80094813,
        [Description("The certificate template renewal period is longer than the certificate validity period. The template should be reconfigured or the CA certificate renewed")]
        
        CERTSRV_E_CERT_TYPE_OVERLAP = 0x80094814,
        [Description("The certificate template requires too many RA signatures. Only one RA signature is allowed")]
        
        CERTSRV_E_TOO_MANY_SIGNATURES = 0x80094815,
        [Description("The certificate template requires renewal with the same public key, but the request uses a different public key")]
        
        CERTSRV_E_RENEWAL_BAD_PUBLIC_KEY = 0x80094816,
        [Description("The certification authority cannot interpret or verify the endorsement key information supplied in the request, or the information is inconsistent")]
        
        CERTSRV_E_INVALID_EK = 0x80094817,
        [Description("The request does not support private key attestation as defined in the certificate template")]
        
        CERTSRV_E_KEY_ATTESTATION = 0x8009481A,
        [Description("The key is not exportable")]
        
        XENROLL_E_KEY_NOT_EXPORTABLE = 0x80095000,
        [Description("You cannot add the root CA certificate into your local store")]
        
        XENROLL_E_CANNOT_ADD_ROOT_CERT = 0x80095001,
        [Description("The key archival hash attribute was not found in the response")]
        
        XENROLL_E_RESPONSE_KA_HASH_NOT_FOUND = 0x80095002,
        [Description("An unexpected key archival hash attribute was found in the response")]
        
        XENROLL_E_RESPONSE_UNEXPECTED_KA_HASH = 0x80095003,
        [Description("There is a key archival hash mismatch between the request and the response")]
        
        XENROLL_E_RESPONSE_KA_HASH_MISMATCH = 0x80095004,
        [Description("Signing certificate cannot include SMIME extension")]
        
        XENROLL_E_KEYSPEC_SMIME_MISMATCH = 0x80095005,
        [Description("A system-level error occurred while verifying trust")]
        
        TRUST_E_SYSTEM_ERROR = 0x80096001,
        [Description("The certificate for the signer of the message is invalid or not found")]
        
        TRUST_E_NO_SIGNER_CERT = 0x80096002,
        [Description("One of the counter signatures was invalid")]
        
        TRUST_E_COUNTER_SIGNER = 0x80096003,
        [Description("The signature of the certificate cannot be verified")]
        
        TRUST_E_CERT_SIGNATURE = 0x80096004,
        [Description("The timestamp signature and/or certificate could not be verified or is malformed")]
        
        TRUST_E_TIME_STAMP = 0x80096005,
        [Description("The digital signature of the object did not verify")]
        
        TRUST_E_BAD_DIGEST = 0x80096010,
        [Description("A certificate's basic constraint extension has not been observed")]
        
        TRUST_E_BASIC_CONSTRAINTS = 0x80096019,
        [Description("The certificate does not meet or contain the Authenticode(tm) financial extensions")]
        
        TRUST_E_FINANCIAL_CRITERIA = 0x8009601E,
        [Description("Tried to reference a part of the file outside the proper range")]
        
        MSSIPOTF_E_OUTOFMEMRANGE = 0x80097001,
        [Description("Could not retrieve an object from the file")]
        
        MSSIPOTF_E_CANTGETOBJECT = 0x80097002,
        [Description("Could not find the head table in the file")]
        
        MSSIPOTF_E_NOHEADTABLE = 0x80097003,
        [Description("The magic number in the head table is incorrect")]
        
        MSSIPOTF_E_BAD_MAGICNUMBER = 0x80097004,
        [Description("The offset table has incorrect values")]
        
        MSSIPOTF_E_BAD_OFFSET_TABLE = 0x80097005,
        [Description("Duplicate table tags or tags out of alphabetical order")]
        
        MSSIPOTF_E_TABLE_TAGORDER = 0x80097006,
        [Description("A table does not start on a long word boundary")]
        
        MSSIPOTF_E_TABLE_LONGWORD = 0x80097007,
        [Description("First table does not appear after header information")]
        
        MSSIPOTF_E_BAD_FIRST_TABLE_PLACEMENT = 0x80097008,
        [Description("Two or more tables overlap")]
        
        MSSIPOTF_E_TABLES_OVERLAP = 0x80097009,
        [Description("Too many pad bytes between tables or pad bytes are not 0")]
        
        MSSIPOTF_E_TABLE_PADBYTES = 0x8009700A,
        [Description("File is too small to contain the last table")]
        
        MSSIPOTF_E_FILETOOSMALL = 0x8009700B,
        [Description("A table checksum is incorrect")]
        
        MSSIPOTF_E_TABLE_CHECKSUM = 0x8009700C,
        [Description("The file checksum is incorrect")]
        
        MSSIPOTF_E_FILE_CHECKSUM = 0x8009700D,
        [Description("The signature does not have the correct attributes for the policy")]
        
        MSSIPOTF_E_FAILED_POLICY = 0x80097010,
        [Description("The file did not pass the hints check")]
        
        MSSIPOTF_E_FAILED_HINTS_CHECK = 0x80097011,
        [Description("The file is not an OpenType file")]
        
        MSSIPOTF_E_NOT_OPENTYPE = 0x80097012,
        [Description("Failed on a file operation (open, map, read, write)")]
        
        MSSIPOTF_E_FILE = 0x80097013,
        [Description("A call to a CryptoAPI function failed")]
        
        MSSIPOTF_E_CRYPT = 0x80097014,
        [Description("There is a bad version number in the file")]
        
        MSSIPOTF_E_BADVERSION = 0x80097015,
        [Description("The structure of the DSIG table is incorrect")]
        
        MSSIPOTF_E_DSIG_STRUCTURE = 0x80097016,
        [Description("A check failed in a partially constant table")]
        
        MSSIPOTF_E_PCONST_CHECK = 0x80097017,
        [Description("Some kind of structural error")]
        
        MSSIPOTF_E_STRUCTURE = 0x80097018,
        [Description("The requested credential requires confirmation")]
        
        ERROR_CRED_REQUIRES_CONFIRMATION = 0x80097019,
        [Description("Unknown trust provider")]
        
        TRUST_E_PROVIDER_UNKNOWN = 0x800B0001,
        [Description("The trust verification action specified is not supported by the specified trust provider")]
        
        TRUST_E_ACTION_UNKNOWN = 0x800B0002,
        [Description("The form specified for the subject is not one supported or known by the specified trust provider")]
        
        TRUST_E_SUBJECT_FORM_UNKNOWN = 0x800B0003,
        [Description("The subject is not trusted for the specified action")]
        
        TRUST_E_SUBJECT_NOT_TRUSTED = 0x800B0004,
        [Description("Error due to problem in ASN.1 encoding process")]
        
        DIGSIG_E_ENCODE = 0x800B0005,
        [Description("Error due to problem in ASN.1 decoding process")]
        
        DIGSIG_E_DECODE = 0x800B0006,
        [Description("Reading / writing Extensions where Attributes are appropriate, and vice versa")]
        
        DIGSIG_E_EXTENSIBILITY = 0x800B0007,
        [Description("Unspecified cryptographic failure")]
        
        DIGSIG_E_CRYPTO = 0x800B0008,
        [Description("The size of the data could not be determined")]
        
        PERSIST_E_SIZEDEFINITE = 0x800B0009,
        [Description("The size of the indefinite-sized data could not be determined")]
        
        PERSIST_E_SIZEINDEFINITE = 0x800B000A,
        [Description("This object does not read and write self-sizing data")]
        
        PERSIST_E_NOTSELFSIZING = 0x800B000B,
        [Description("No signature was present in the subject")]
        
        TRUST_E_NOSIGNATURE = 0x800B0100,
        [Description("A required certificate is not within its validity period when verifying against the current system clock or the timestamp in the signed file")]
        
        CERT_E_EXPIRED = 0x800B0101,
        [Description("The validity periods of the certification chain do not nest correctly")]
        
        CERT_E_VALIDITYPERIODNESTING = 0x800B0102,
        [Description("A certificate that can only be used as an end-entity is being used as a CA or vice versa")]
        
        CERT_E_ROLE = 0x800B0103,
        [Description("A path length constraint in the certification chain has been violated")]
        
        CERT_E_PATHLENCONST = 0x800B0104,
        [Description("A certificate contains an unknown extension that is marked 'critical'")]
        
        CERT_E_CRITICAL = 0x800B0105,
        [Description("A certificate being used for a purpose other than the ones specified by its CA")]
        
        CERT_E_PURPOSE = 0x800B0106,
        [Description("A parent of a given certificate in fact did not issue that child certificate")]
        
        CERT_E_ISSUERCHAINING = 0x800B0107,
        [Description("A certificate is missing or has an empty value for an important field, such as a subject or issuer name")]
        
        CERT_E_MALFORMED = 0x800B0108,
        [Description("A certificate chain processed, but terminated in a root certificate which is not trusted by the trust provider")]
        
        CERT_E_UNTRUSTEDROOT = 0x800B0109,
        [Description("A certificate chain could not be built to a trusted root authority")]
        
        CERT_E_CHAINING = 0x800B010A,
        [Description("Generic trust failure")]
        
        TRUST_E_FAIL = 0x800B010B,
        [Description("A certificate was explicitly revoked by its issuer")]
        
        CERT_E_REVOKED = 0x800B010C,
        [Description("The certification path terminates with the test root which is not trusted with the current policy settings")]
        
        CERT_E_UNTRUSTEDTESTROOT = 0x800B010D,
        [Description("The revocation process could not continue - the certificate(s) could not be checked")]
        
        CERT_E_REVOCATION_FAILURE = 0x800B010E,
        [Description("The certificate's CN name does not match the passed value")]
        
        CERT_E_CN_NO_MATCH = 0x800B010F,
        [Description("The certificate is not valid for the requested usage")]
        
        CERT_E_WRONG_USAGE = 0x800B0110,
        [Description("The certificate was explicitly marked as untrusted by the user")]
        
        TRUST_E_EXPLICIT_DISTRUST = 0x800B0111,
        [Description("A certification chain processed correctly, but one of the CA certificates is not trusted by the policy provider")]
        
        CERT_E_UNTRUSTEDCA = 0x800B0112,
        [Description("The certificate has invalid policy")]
        
        CERT_E_INVALID_POLICY = 0x800B0113,
        [Description("The certificate has an invalid name. The name is not included in the permitted list or is explicitly excluded")]
        
        CERT_E_INVALID_NAME = 0x800B0114,
        [Description("Unknown error (0x800d0003)")]
        
        NS_W_SERVER_BANDWIDTH_LIMIT = 0x800D0003,
        [Description("Unknown error (0x800d0004)")]
        
        NS_W_FILE_BANDWIDTH_LIMIT = 0x800D0004,
        [Description("Unknown error (0x800d0060)")]
        
        NS_W_UNKNOWN_EVENT = 0x800D0060,
        [Description("Unknown error (0x800d0199)")]
        
        NS_I_CATATONIC_FAILURE = 0x800D0199,
        [Description("Unknown error (0x800d019a)")]
        
        NS_I_CATATONIC_AUTO_UNFAIL = 0x800D019A,
        [Description("A non-empty line was encountered in the INF before the start of a section")]
        
        SPAPI_E_EXPECTED_SECTION_NAME = 0x800F0000,
        [Description("A section name marker in the INF is not complete, or does not exist on a line by itself")]
        
        SPAPI_E_BAD_SECTION_NAME_LINE = 0x800F0001,
        [Description("An INF section was encountered whose name exceeds the maximum section name length")]
        
        SPAPI_E_SECTION_NAME_TOO_LONG = 0x800F0002,
        [Description("The syntax of the INF is invalid")]
        
        SPAPI_E_GENERAL_SYNTAX = 0x800F0003,
        [Description("The style of the INF is different than what was requested")]
        
        SPAPI_E_WRONG_INF_STYLE = 0x800F0100,
        [Description("The required section was not found in the INF")]
        
        SPAPI_E_SECTION_NOT_FOUND = 0x800F0101,
        [Description("The required line was not found in the INF")]
        
        SPAPI_E_LINE_NOT_FOUND = 0x800F0102,
        [Description("The files affected by the installation of this file queue have not been backed up for uninstall")]
        
        SPAPI_E_NO_BACKUP = 0x800F0103,
        [Description("The INF or the device information set or element does not have an associated install class")]
        
        SPAPI_E_NO_ASSOCIATED_CLASS = 0x800F0200,
        [Description("The INF or the device information set or element does not match the specified install class")]
        
        SPAPI_E_CLASS_MISMATCH = 0x800F0201,
        [Description("An existing device was found that is a duplicate of the device being manually installed")]
        
        SPAPI_E_DUPLICATE_FOUND = 0x800F0202,
        [Description("There is no driver selected for the device information set or element")]
        
        SPAPI_E_NO_DRIVER_SELECTED = 0x800F0203,
        [Description("The requested device registry key does not exist")]
        
        SPAPI_E_KEY_DOES_NOT_EXIST = 0x800F0204,
        [Description("The device instance name is invalid")]
        
        SPAPI_E_INVALID_DEVINST_NAME = 0x800F0205,
        [Description("The install class is not present or is invalid")]
        
        SPAPI_E_INVALID_CLASS = 0x800F0206,
        [Description("The device instance cannot be created because it already exists")]
        
        SPAPI_E_DEVINST_ALREADY_EXISTS = 0x800F0207,
        [Description("The operation cannot be performed on a device information element that has not been registered")]
        
        SPAPI_E_DEVINFO_NOT_REGISTERED = 0x800F0208,
        [Description("The device property code is invalid")]
        
        SPAPI_E_INVALID_REG_PROPERTY = 0x800F0209,
        [Description("The INF from which a driver list is to be built does not exist")]
        
        SPAPI_E_NO_INF = 0x800F020A,
        [Description("The device instance does not exist in the hardware tree")]
        
        SPAPI_E_NO_SUCH_DEVINST = 0x800F020B,
        [Description("The icon representing this install class cannot be loaded")]
        
        SPAPI_E_CANT_LOAD_CLASS_ICON = 0x800F020C,
        [Description("The class installer registry entry is invalid")]
        
        SPAPI_E_INVALID_CLASS_INSTALLER = 0x800F020D,
        [Description("The class installer has indicated that the default action should be performed for this installation request")]
        
        SPAPI_E_DI_DO_DEFAULT = 0x800F020E,
        [Description("The operation does not require any files to be copied")]
        
        SPAPI_E_DI_NOFILECOPY = 0x800F020F,
        [Description("The specified hardware profile does not exist")]
        
        SPAPI_E_INVALID_HWPROFILE = 0x800F0210,
        [Description("There is no device information element currently selected for this device information set")]
        
        SPAPI_E_NO_DEVICE_SELECTED = 0x800F0211,
        [Description("The operation cannot be performed because the device information set is locked")]
        
        SPAPI_E_DEVINFO_LIST_LOCKED = 0x800F0212,
        [Description("The operation cannot be performed because the device information element is locked")]
        
        SPAPI_E_DEVINFO_DATA_LOCKED = 0x800F0213,
        [Description("The specified path does not contain any applicable device INFs")]
        
        SPAPI_E_DI_BAD_PATH = 0x800F0214,
        [Description("No class installer parameters have been set for the device information set or element")]
        
        SPAPI_E_NO_CLASSINSTALL_PARAMS = 0x800F0215,
        [Description("The operation cannot be performed because the file queue is locked")]
        
        SPAPI_E_FILEQUEUE_LOCKED = 0x800F0216,
        [Description("A service installation section in this INF is invalid")]
        
        SPAPI_E_BAD_SERVICE_INSTALLSECT = 0x800F0217,
        [Description("There is no class driver list for the device information element")]
        
        SPAPI_E_NO_CLASS_DRIVER_LIST = 0x800F0218,
        [Description("The installation failed because a function driver was not specified for this device instance")]
        
        SPAPI_E_NO_ASSOCIATED_SERVICE = 0x800F0219,
        [Description("There is presently no default device interface designated for this interface class")]
        
        SPAPI_E_NO_DEFAULT_DEVICE_INTERFACE = 0x800F021A,
        [Description("The operation cannot be performed because the device interface is currently active")]
        
        SPAPI_E_DEVICE_INTERFACE_ACTIVE = 0x800F021B,
        [Description("The operation cannot be performed because the device interface has been removed from the system")]
        
        SPAPI_E_DEVICE_INTERFACE_REMOVED = 0x800F021C,
        [Description("An interface installation section in this INF is invalid")]
        
        SPAPI_E_BAD_INTERFACE_INSTALLSECT = 0x800F021D,
        [Description("This interface class does not exist in the system")]
        
        SPAPI_E_NO_SUCH_INTERFACE_CLASS = 0x800F021E,
        [Description("The reference string supplied for this interface device is invalid")]
        
        SPAPI_E_INVALID_REFERENCE_STRING = 0x800F021F,
        [Description("The specified machine name does not conform to UNC naming conventions")]
        
        SPAPI_E_INVALID_MACHINENAME = 0x800F0220,
        [Description("A general remote communication error occurred")]
        
        SPAPI_E_REMOTE_COMM_FAILURE = 0x800F0221,
        [Description("The machine selected for remote communication is not available at this time")]
        
        SPAPI_E_MACHINE_UNAVAILABLE = 0x800F0222,
        [Description("The Plug and Play service is not available on the remote machine")]
        
        SPAPI_E_NO_CONFIGMGR_SERVICES = 0x800F0223,
        [Description("The property page provider registry entry is invalid")]
        
        SPAPI_E_INVALID_PROPPAGE_PROVIDER = 0x800F0224,
        [Description("The requested device interface is not present in the system")]
        
        SPAPI_E_NO_SUCH_DEVICE_INTERFACE = 0x800F0225,
        [Description("The device's co-installer has additional work to perform after installation is complete")]
        
        SPAPI_E_DI_POSTPROCESSING_REQUIRED = 0x800F0226,
        [Description("The device's co-installer is invalid")]
        
        SPAPI_E_INVALID_COINSTALLER = 0x800F0227,
        [Description("There are no compatible drivers for this device")]
        
        SPAPI_E_NO_COMPAT_DRIVERS = 0x800F0228,
        [Description("There is no icon that represents this device or device type")]
        
        SPAPI_E_NO_DEVICE_ICON = 0x800F0229,
        [Description("A logical configuration specified in this INF is invalid")]
        
        SPAPI_E_INVALID_INF_LOGCONFIG = 0x800F022A,
        [Description("The class installer has denied the request to install or upgrade this device")]
        
        SPAPI_E_DI_DONT_INSTALL = 0x800F022B,
        [Description("One of the filter drivers installed for this device is invalid")]
        
        SPAPI_E_INVALID_FILTER_DRIVER = 0x800F022C,
        [Description("The driver selected for this device does not support this version of Windows")]
        
        SPAPI_E_NON_WINDOWS_NT_DRIVER = 0x800F022D,
        [Description("The driver selected for this device does not support Windows")]
        
        SPAPI_E_NON_WINDOWS_DRIVER = 0x800F022E,
        [Description("The third-party INF does not contain digital signature information")]
        
        SPAPI_E_NO_CATALOG_FOR_OEM_INF = 0x800F022F,
        [Description("An invalid attempt was made to use a device installation file queue for verification of digital signatures relative to other platforms")]
        
        SPAPI_E_DEVINSTALL_QUEUE_NONNATIVE = 0x800F0230,
        [Description("The device cannot be disabled")]
        
        SPAPI_E_NOT_DISABLEABLE = 0x800F0231,
        [Description("The device could not be dynamically removed")]
        
        SPAPI_E_CANT_REMOVE_DEVINST = 0x800F0232,
        [Description("Cannot copy to specified target")]
        
        SPAPI_E_INVALID_TARGET = 0x800F0233,
        [Description("Driver is not intended for this platform")]
        
        SPAPI_E_DRIVER_NONNATIVE = 0x800F0234,
        [Description("Operation not allowed in WOW64")]
        
        SPAPI_E_IN_WOW64 = 0x800F0235,
        [Description("The operation involving unsigned file copying was rolled back, so that a system restore point could be set")]
        
        SPAPI_E_SET_SYSTEM_RESTORE_POINT = 0x800F0236,
        [Description("An INF was copied into the Windows INF directory in an improper manner")]
        
        SPAPI_E_INCORRECTLY_COPIED_INF = 0x800F0237,
        [Description("The Security Configuration Editor (SCE) APIs have been disabled on this Embedded product")]
        
        SPAPI_E_SCE_DISABLED = 0x800F0238,
        [Description("An unknown exception was encountered")]
        
        SPAPI_E_UNKNOWN_EXCEPTION = 0x800F0239,
        [Description("A problem was encountered when accessing the Plug and Play registry database")]
        
        SPAPI_E_PNP_REGISTRY_ERROR = 0x800F023A,
        [Description("The requested operation is not supported for a remote machine")]
        
        SPAPI_E_REMOTE_REQUEST_UNSUPPORTED = 0x800F023B,
        [Description("The specified file is not an installed OEM INF")]
        
        SPAPI_E_NOT_AN_INSTALLED_OEM_INF = 0x800F023C,
        [Description("One or more devices are presently installed using the specified INF")]
        
        SPAPI_E_INF_IN_USE_BY_DEVICES = 0x800F023D,
        [Description("The requested device install operation is obsolete")]
        
        SPAPI_E_DI_FUNCTION_OBSOLETE = 0x800F023E,
        [Description("A file could not be verified because it does not have an associated catalog signed via Authenticode(tm)")]
        
        SPAPI_E_NO_AUTHENTICODE_CATALOG = 0x800F023F,
        [Description("Authenticode(tm) signature verification is not supported for the specified INF")]
        
        SPAPI_E_AUTHENTICODE_DISALLOWED = 0x800F0240,
        [Description("The INF was signed with an Authenticode(tm) catalog from a trusted publisher")]
        
        SPAPI_E_AUTHENTICODE_TRUSTED_PUBLISHER = 0x800F0241,
        [Description("The publisher of an Authenticode(tm) signed catalog has not yet been established as trusted")]
        
        SPAPI_E_AUTHENTICODE_TRUST_NOT_ESTABLISHED = 0x800F0242,
        [Description("The publisher of an Authenticode(tm) signed catalog was not established as trusted")]
        
        SPAPI_E_AUTHENTICODE_PUBLISHER_NOT_TRUSTED = 0x800F0243,
        [Description("The software was tested for compliance with Windows Logo requirements on a different version of Windows, and may not be compatible with this version")]
        
        SPAPI_E_SIGNATURE_OSATTRIBUTE_MISMATCH = 0x800F0244,
        [Description("The file may only be validated by a catalog signed via Authenticode(tm)")]
        
        SPAPI_E_ONLY_VALIDATE_VIA_AUTHENTICODE = 0x800F0245,
        [Description("One of the installers for this device cannot perform the installation at this time")]
        
        SPAPI_E_DEVICE_INSTALLER_NOT_READY = 0x800F0246,
        [Description("A problem was encountered while attempting to add the driver to the store")]
        
        SPAPI_E_DRIVER_STORE_ADD_FAILED = 0x800F0247,
        [Description("The installation of this device is forbidden by system policy. Contact your system administrator")]
        
        SPAPI_E_DEVICE_INSTALL_BLOCKED = 0x800F0248,
        [Description("The installation of this driver is forbidden by system policy. Contact your system administrator")]
        
        SPAPI_E_DRIVER_INSTALL_BLOCKED = 0x800F0249,
        [Description("The specified INF is the wrong type for this operation")]
        
        SPAPI_E_WRONG_INF_TYPE = 0x800F024A,
        [Description("The hash for the file is not present in the specified catalog file. The file is likely corrupt or the victim of tampering")]
        
        SPAPI_E_FILE_HASH_NOT_IN_CATALOG = 0x800F024B,
        [Description("A problem was encountered while attempting to delete the driver from the store")]
        
        SPAPI_E_DRIVER_STORE_DELETE_FAILED = 0x800F024C,
        [Description("An unrecoverable stack overflow was encountered")]
        
        SPAPI_E_UNRECOVERABLE_STACK_OVERFLOW = 0x800F0300,
        [Description("No installed components were detected")]
        
        SPAPI_E_ERROR_NOT_INSTALLED = 0x800F1000,
        [Description("An internal consistency check failed")]
        
        SCARD_F_INTERNAL_ERROR = 0x80100001,
        [Description("The action was cancelled by an SCardCancel request")]
        
        SCARD_E_CANCELLED = 0x80100002,
        [Description("The supplied handle was invalid")]
        
        SCARD_E_INVALID_HANDLE = 0x80100003,
        [Description("One or more of the supplied parameters could not be properly interpreted")]
        
        SCARD_E_INVALID_PARAMETER = 0x80100004,
        [Description("Registry startup information is missing or invalid")]
        
        SCARD_E_INVALID_TARGET = 0x80100005,
        [Description("Not enough memory available to complete this command")]
        
        SCARD_E_NO_MEMORY = 0x80100006,
        [Description("An internal consistency timer has expired")]
        
        SCARD_F_WAITED_TOO_LONG = 0x80100007,
        [Description("The data buffer to receive returned data is too small for the returned data")]
        
        SCARD_E_INSUFFICIENT_BUFFER = 0x80100008,
        [Description("The specified reader name is not recognized")]
        
        SCARD_E_UNKNOWN_READER = 0x80100009,
        [Description("The user-specified timeout value has expired")]
        
        SCARD_E_TIMEOUT = 0x8010000A,
        [Description("The smart card cannot be accessed because of other connections outstanding")]
        
        SCARD_E_SHARING_VIOLATION = 0x8010000B,
        [Description("The operation requires a smart card, but no smart card is currently in the device")]
        
        SCARD_E_NO_SMARTCARD = 0x8010000C,
        [Description("The specified smart card name is not recognized")]
        
        SCARD_E_UNKNOWN_CARD = 0x8010000D,
        [Description("The system could not dispose of the media in the requested manner")]
        
        SCARD_E_CANT_DISPOSE = 0x8010000E,
        [Description("The requested protocols are incompatible with the protocol currently in use with the smart card")]
        
        SCARD_E_PROTO_MISMATCH = 0x8010000F,
        [Description("The reader or smart card is not ready to accept commands")]
        
        SCARD_E_NOT_READY = 0x80100010,
        [Description("One or more of the supplied parameters values could not be properly interpreted")]
        
        SCARD_E_INVALID_VALUE = 0x80100011,
        [Description("The action was cancelled by the system, presumably to log off or shut down")]
        
        SCARD_E_SYSTEM_CANCELLED = 0x80100012,
        [Description("An internal communications error has been detected")]
        
        SCARD_F_COMM_ERROR = 0x80100013,
        [Description("An internal error has been detected, but the source is unknown")]
        
        SCARD_F_UNKNOWN_ERROR = 0x80100014,
        [Description("An ATR obtained from the registry is not a valid ATR string")]
        
        SCARD_E_INVALID_ATR = 0x80100015,
        [Description("An attempt was made to end a non-existent transaction")]
        
        SCARD_E_NOT_TRANSACTED = 0x80100016,
        [Description("The specified reader is not currently available for use")]
        
        SCARD_E_READER_UNAVAILABLE = 0x80100017,
        [Description("The operation has been aborted to allow the server application to exit")]
        
        SCARD_P_SHUTDOWN = 0x80100018,
        [Description("The PCI Receive buffer was too small")]
        
        SCARD_E_PCI_TOO_SMALL = 0x80100019,
        [Description("The reader driver does not meet minimal requirements for support")]
        
        SCARD_E_READER_UNSUPPORTED = 0x8010001A,
        [Description("The reader driver did not produce a unique reader name")]
        
        SCARD_E_DUPLICATE_READER = 0x8010001B,
        [Description("The smart card does not meet minimal requirements for support")]
        
        SCARD_E_CARD_UNSUPPORTED = 0x8010001C,
        [Description("The Smart Card Resource Manager is not running")]
        
        SCARD_E_NO_SERVICE = 0x8010001D,
        [Description("The Smart Card Resource Manager has shut down")]
        
        SCARD_E_SERVICE_STOPPED = 0x8010001E,
        [Description("An unexpected card error has occurred")]
        
        SCARD_E_UNEXPECTED = 0x8010001F,
        [Description("No Primary Provider can be found for the smart card")]
        
        SCARD_E_ICC_INSTALLATION = 0x80100020,
        [Description("The requested order of object creation is not supported")]
        
        SCARD_E_ICC_CREATEORDER = 0x80100021,
        [Description("This smart card does not support the requested feature")]
        
        SCARD_E_UNSUPPORTED_FEATURE = 0x80100022,
        [Description("The identified directory does not exist in the smart card")]
        
        SCARD_E_DIR_NOT_FOUND = 0x80100023,
        [Description("The identified file does not exist in the smart card")]
        
        SCARD_E_FILE_NOT_FOUND = 0x80100024,
        [Description("The supplied path does not represent a smart card directory")]
        
        SCARD_E_NO_DIR = 0x80100025,
        [Description("The supplied path does not represent a smart card file")]
        
        SCARD_E_NO_FILE = 0x80100026,
        [Description("Access is denied to this file")]
        
        SCARD_E_NO_ACCESS = 0x80100027,
        [Description("The smart card does not have enough memory to store the information")]
        
        SCARD_E_WRITE_TOO_MANY = 0x80100028,
        [Description("There was an error trying to set the smart card file object pointer")]
        
        SCARD_E_BAD_SEEK = 0x80100029,
        [Description("The supplied PIN is incorrect")]
        
        SCARD_E_INVALID_CHV = 0x8010002A,
        [Description("An unrecognized error code was returned from a layered component")]
        
        SCARD_E_UNKNOWN_RES_MNG = 0x8010002B,
        [Description("The requested certificate does not exist")]
        
        SCARD_E_NO_SUCH_CERTIFICATE = 0x8010002C,
        [Description("The requested certificate could not be obtained")]
        
        SCARD_E_CERTIFICATE_UNAVAILABLE = 0x8010002D,
        [Description("Cannot find a smart card reader")]
        
        SCARD_E_NO_READERS_AVAILABLE = 0x8010002E,
        [Description("A communications error with the smart card has been detected. Retry the operation")]
        
        SCARD_E_COMM_DATA_LOST = 0x8010002F,
        [Description("The requested key container does not exist on the smart card")]
        
        SCARD_E_NO_KEY_CONTAINER = 0x80100030,
        [Description("The Smart Card Resource Manager is too busy to complete this operation")]
        
        SCARD_E_SERVER_TOO_BUSY = 0x80100031,
        [Description("The reader cannot communicate with the smart card, due to ATR configuration conflicts")]
        
        SCARD_W_UNSUPPORTED_CARD = 0x80100065,
        [Description("The smart card is not responding to a reset")]
        
        SCARD_W_UNRESPONSIVE_CARD = 0x80100066,
        [Description("Power has been removed from the smart card, so that further communication is not possible")]
        
        SCARD_W_UNPOWERED_CARD = 0x80100067,
        [Description("The smart card has been reset, so any shared state information is invalid")]
        
        SCARD_W_RESET_CARD = 0x80100068,
        [Description("The smart card has been removed, so that further communication is not possible")]
        
        SCARD_W_REMOVED_CARD = 0x80100069,
        [Description("Access was denied because of a security violation")]
        
        SCARD_W_SECURITY_VIOLATION = 0x8010006A,
        [Description("The card cannot be accessed because the wrong PIN was presented")]
        
        SCARD_W_WRONG_CHV = 0x8010006B,
        [Description("The card cannot be accessed because the maximum number of PIN entry attempts has been reached")]
        
        SCARD_W_CHV_BLOCKED = 0x8010006C,
        [Description("The end of the smart card file has been reached")]
        
        SCARD_W_EOF = 0x8010006D,
        [Description("The action was cancelled by the user")]
        
        SCARD_W_CANCELLED_BY_USER = 0x8010006E,
        [Description("No PIN was presented to the smart card")]
        
        SCARD_W_CARD_NOT_AUTHENTICATED = 0x8010006F,
        [Description("Errors occurred accessing one or more objects - the ErrorInfo collection may have more detail")]
        
        COMADMIN_E_OBJECTERRORS = 0x80110401,
        [Description("One or more of the object's properties are missing or invalid")]
        
        COMADMIN_E_OBJECTINVALID = 0x80110402,
        [Description("The object was not found in the catalog")]
        
        COMADMIN_E_KEYMISSING = 0x80110403,
        [Description("The object is already registered")]
        
        COMADMIN_E_ALREADYINSTALLED = 0x80110404,
        [Description("Error occurred writing to the application file")]
        
        COMADMIN_E_APP_FILE_WRITEFAIL = 0x80110407,
        [Description("Error occurred reading the application file")]
        
        COMADMIN_E_APP_FILE_READFAIL = 0x80110408,
        [Description("Invalid version number in application file")]
        
        COMADMIN_E_APP_FILE_VERSION = 0x80110409,
        [Description("The file path is invalid")]
        
        COMADMIN_E_BADPATH = 0x8011040A,
        [Description("The application is already installed")]
        
        COMADMIN_E_APPLICATIONEXISTS = 0x8011040B,
        [Description("The role already exists")]
        
        COMADMIN_E_ROLEEXISTS = 0x8011040C,
        [Description("An error occurred copying the file")]
        
        COMADMIN_E_CANTCOPYFILE = 0x8011040D,
        [Description("One or more users are not valid")]
        
        COMADMIN_E_NOUSER = 0x8011040F,
        [Description("One or more users in the application file are not valid")]
        
        COMADMIN_E_INVALIDUSERIDS = 0x80110410,
        [Description("The component's CLSID is missing or corrupt")]
        
        COMADMIN_E_NOREGISTRYCLSID = 0x80110411,
        [Description("The component's progID is missing or corrupt")]
        
        COMADMIN_E_BADREGISTRYPROGID = 0x80110412,
        [Description("Unable to set required authentication level for update request")]
        
        COMADMIN_E_AUTHENTICATIONLEVEL = 0x80110413,
        [Description("The identity or password set on the application is not valid")]
        
        COMADMIN_E_USERPASSWDNOTVALID = 0x80110414,
        [Description("Application file CLSIDs or IIDs do not match corresponding DLLs")]
        
        COMADMIN_E_CLSIDORIIDMISMATCH = 0x80110418,
        [Description("Interface information is either missing or changed")]
        
        COMADMIN_E_REMOTEINTERFACE = 0x80110419,
        [Description("DllRegisterServer failed on component install")]
        
        COMADMIN_E_DLLREGISTERSERVER = 0x8011041A,
        [Description("No server file share available")]
        
        COMADMIN_E_NOSERVERSHARE = 0x8011041B,
        [Description("DLL could not be loaded")]
        
        COMADMIN_E_DLLLOADFAILED = 0x8011041D,
        [Description("The registered TypeLib ID is not valid")]
        
        COMADMIN_E_BADREGISTRYLIBID = 0x8011041E,
        [Description("Application install directory not found")]
        
        COMADMIN_E_APPDIRNOTFOUND = 0x8011041F,
        [Description("Errors occurred while in the component registrar")]
        
        COMADMIN_E_REGISTRARFAILED = 0x80110423,
        [Description("The file does not exist")]
        
        COMADMIN_E_COMPFILE_DOESNOTEXIST = 0x80110424,
        [Description("The DLL could not be loaded")]
        
        COMADMIN_E_COMPFILE_LOADDLLFAIL = 0x80110425,
        [Description("GetClassObject failed in the DLL")]
        
        COMADMIN_E_COMPFILE_GETCLASSOBJ = 0x80110426,
        [Description("The DLL does not support the components listed in the TypeLib")]
        
        COMADMIN_E_COMPFILE_CLASSNOTAVAIL = 0x80110427,
        [Description("The TypeLib could not be loaded")]
        
        COMADMIN_E_COMPFILE_BADTLB = 0x80110428,
        [Description("The file does not contain components or component information")]
        
        COMADMIN_E_COMPFILE_NOTINSTALLABLE = 0x80110429,
        [Description("Changes to this object and its sub-objects have been disabled")]
        
        COMADMIN_E_NOTCHANGEABLE = 0x8011042A,
        [Description("The delete function has been disabled for this object")]
        
        COMADMIN_E_NOTDELETEABLE = 0x8011042B,
        [Description("The server catalog version is not supported")]
        
        COMADMIN_E_SESSION = 0x8011042C,
        [Description("The component move was disallowed, because the source or destination application is either a system application or currently locked against changes")]
        
        COMADMIN_E_COMP_MOVE_LOCKED = 0x8011042D,
        [Description("The component move failed because the destination application no longer exists")]
        
        COMADMIN_E_COMP_MOVE_BAD_DEST = 0x8011042E,
        [Description("The system was unable to register the TypeLib")]
        
        COMADMIN_E_REGISTERTLB = 0x80110430,
        [Description("This operation cannot be performed on the system application")]
        
        COMADMIN_E_SYSTEMAPP = 0x80110433,
        [Description("The component registrar referenced in this file is not available")]
        
        COMADMIN_E_COMPFILE_NOREGISTRAR = 0x80110434,
        [Description("A component in the same DLL is already installed")]
        
        COMADMIN_E_COREQCOMPINSTALLED = 0x80110435,
        [Description("The service is not installed")]
        
        COMADMIN_E_SERVICENOTINSTALLED = 0x80110436,
        [Description("One or more property settings are either invalid or in conflict with each other")]
        
        COMADMIN_E_PROPERTYSAVEFAILED = 0x80110437,
        [Description("The object you are attempting to add or rename already exists")]
        
        COMADMIN_E_OBJECTEXISTS = 0x80110438,
        [Description("The component already exists")]
        
        COMADMIN_E_COMPONENTEXISTS = 0x80110439,
        [Description("The registration file is corrupt")]
        
        COMADMIN_E_REGFILE_CORRUPT = 0x8011043B,
        [Description("The property value is too large")]
        
        COMADMIN_E_PROPERTY_OVERFLOW = 0x8011043C,
        [Description("Object was not found in registry")]
        
        COMADMIN_E_NOTINREGISTRY = 0x8011043E,
        [Description("This object is not poolable")]
        
        COMADMIN_E_OBJECTNOTPOOLABLE = 0x8011043F,
        [Description("A CLSID with the same GUID as the new application ID is already installed on this machine")]
        
        COMADMIN_E_APPLID_MATCHES_CLSID = 0x80110446,
        [Description("A role assigned to a component, interface, or method did not exist in the application")]
        
        COMADMIN_E_ROLE_DOES_NOT_EXIST = 0x80110447,
        [Description("You must have components in an application in order to start the application")]
        
        COMADMIN_E_START_APP_NEEDS_COMPONENTS = 0x80110448,
        [Description("This operation is not enabled on this platform")]
        
        COMADMIN_E_REQUIRES_DIFFERENT_PLATFORM = 0x80110449,
        [Description("Application Proxy is not exportable")]
        
        COMADMIN_E_CAN_NOT_EXPORT_APP_PROXY = 0x8011044A,
        [Description("Failed to start application because it is either a library application or an application proxy")]
        
        COMADMIN_E_CAN_NOT_START_APP = 0x8011044B,
        [Description("System application is not exportable")]
        
        COMADMIN_E_CAN_NOT_EXPORT_SYS_APP = 0x8011044C,
        [Description("Cannot subscribe to this component (the component may have been imported)")]
        
        COMADMIN_E_CANT_SUBSCRIBE_TO_COMPONENT = 0x8011044D,
        [Description("An event class cannot also be a subscriber component")]
        
        COMADMIN_E_EVENTCLASS_CANT_BE_SUBSCRIBER = 0x8011044E,
        [Description("Library applications and application proxies are incompatible")]
        
        COMADMIN_E_LIB_APP_PROXY_INCOMPATIBLE = 0x8011044F,
        [Description("This function is valid for the base partition only")]
        
        COMADMIN_E_BASE_PARTITION_ONLY = 0x80110450,
        [Description("You cannot start an application that has been disabled")]
        
        COMADMIN_E_START_APP_DISABLED = 0x80110451,
        [Description("The specified partition name is already in use on this computer")]
        
        COMADMIN_E_CAT_DUPLICATE_PARTITION_NAME = 0x80110457,
        [Description("The specified partition name is invalid. Check that the name contains at least one visible character")]
        
        COMADMIN_E_CAT_INVALID_PARTITION_NAME = 0x80110458,
        [Description("The partition cannot be deleted because it is the default partition for one or more users")]
        
        COMADMIN_E_CAT_PARTITION_IN_USE = 0x80110459,
        [Description("The partition cannot be exported, because one or more components in the partition have the same file name")]
        
        COMADMIN_E_FILE_PARTITION_DUPLICATE_FILES = 0x8011045A,
        [Description("Applications that contain one or more imported components cannot be installed into a non-base partition")]
        
        COMADMIN_E_CAT_IMPORTED_COMPONENTS_NOT_ALLOWED = 0x8011045B,
        [Description("The application name is not unique and cannot be resolved to an application id")]
        
        COMADMIN_E_AMBIGUOUS_APPLICATION_NAME = 0x8011045C,
        [Description("The partition name is not unique and cannot be resolved to a partition id")]
        
        COMADMIN_E_AMBIGUOUS_PARTITION_NAME = 0x8011045D,
        [Description("The COM+ registry database has not been initialized")]
        
        COMADMIN_E_REGDB_NOTINITIALIZED = 0x80110472,
        [Description("The COM+ registry database is not open")]
        
        COMADMIN_E_REGDB_NOTOPEN = 0x80110473,
        [Description("The COM+ registry database detected a system error")]
        
        COMADMIN_E_REGDB_SYSTEMERR = 0x80110474,
        [Description("The COM+ registry database is already running")]
        
        COMADMIN_E_REGDB_ALREADYRUNNING = 0x80110475,
        [Description("This version of the COM+ registry database cannot be migrated")]
        
        COMADMIN_E_MIG_VERSIONNOTSUPPORTED = 0x80110480,
        [Description("The schema version to be migrated could not be found in the COM+ registry database")]
        
        COMADMIN_E_MIG_SCHEMANOTFOUND = 0x80110481,
        [Description("There was a type mismatch between binaries")]
        
        COMADMIN_E_CAT_BITNESSMISMATCH = 0x80110482,
        [Description("A binary of unknown or invalid type was provided")]
        
        COMADMIN_E_CAT_UNACCEPTABLEBITNESS = 0x80110483,
        [Description("There was a type mismatch between a binary and an application")]
        
        COMADMIN_E_CAT_WRONGAPPBITNESS = 0x80110484,
        [Description("The application cannot be paused or resumed")]
        
        COMADMIN_E_CAT_PAUSE_RESUME_NOT_SUPPORTED = 0x80110485,
        [Description("The COM+ Catalog Server threw an exception during execution")]
        
        COMADMIN_E_CAT_SERVERFAULT = 0x80110486,
        [Description("Only COM+ Applications marked \"queued\" can be invoked using the \"queue\" moniker")]
        
        COMQC_E_APPLICATION_NOT_QUEUED = 0x80110600,
        [Description("At least one interface must be marked \"queued\" in order to create a queued component instance with the \"queue\" moniker")]
        
        COMQC_E_NO_QUEUEABLE_INTERFACES = 0x80110601,
        [Description("MSMQ is required for the requested operation and is not installed")]
        
        COMQC_E_QUEUING_SERVICE_NOT_AVAILABLE = 0x80110602,
        [Description("Unable to marshal an interface that does not support IPersistStream")]
        
        COMQC_E_NO_IPERSISTSTREAM = 0x80110603,
        [Description("The message is improperly formatted or was damaged in transit")]
        
        COMQC_E_BAD_MESSAGE = 0x80110604,
        [Description("An unauthenticated message was received by an application that accepts only authenticated messages")]
        
        COMQC_E_UNAUTHENTICATED = 0x80110605,
        [Description("The message was requeued or moved by a user not in the \"QC Trusted User\" role")]
        
        COMQC_E_UNTRUSTED_ENQUEUER = 0x80110606,
        [Description("Cannot create a duplicate resource of type Distributed Transaction Coordinator")]
        
        MSDTC_E_DUPLICATE_RESOURCE = 0x80110701,
        [Description("One of the objects being inserted or updated does not belong to a valid parent collection")]
        
        COMADMIN_E_OBJECT_PARENT_MISSING = 0x80110808,
        [Description("One of the specified objects cannot be found")]
        
        COMADMIN_E_OBJECT_DOES_NOT_EXIST = 0x80110809,
        [Description("The specified application is not currently running")]
        
        COMADMIN_E_APP_NOT_RUNNING = 0x8011080A,
        [Description("The partition(s) specified are not valid")]
        
        COMADMIN_E_INVALID_PARTITION = 0x8011080B,
        [Description("COM+ applications that run as NT service may not be pooled or recycled")]
        
        COMADMIN_E_SVCAPP_NOT_POOLABLE_OR_RECYCLABLE = 0x8011080D,
        [Description("One or more users are already assigned to a local partition set")]
        
        COMADMIN_E_USER_IN_SET = 0x8011080E,
        [Description("Library applications may not be recycled")]
        
        COMADMIN_E_CANTRECYCLELIBRARYAPPS = 0x8011080F,
        [Description("Applications running as NT services may not be recycled")]
        
        COMADMIN_E_CANTRECYCLESERVICEAPPS = 0x80110811,
        [Description("The process has already been recycled")]
        
        COMADMIN_E_PROCESSALREADYRECYCLED = 0x80110812,
        [Description("A paused process may not be recycled")]
        
        COMADMIN_E_PAUSEDPROCESSMAYNOTBERECYCLED = 0x80110813,
        [Description("Library applications may not be NT services")]
        
        COMADMIN_E_CANTMAKEINPROCSERVICE = 0x80110814,
        [Description("The ProgID provided to the copy operation is invalid. The ProgID is in use by another registered CLSID")]
        
        COMADMIN_E_PROGIDINUSEBYCLSID = 0x80110815,
        [Description("The partition specified as default is not a member of the partition set")]
        
        COMADMIN_E_DEFAULT_PARTITION_NOT_IN_SET = 0x80110816,
        [Description("A recycled process may not be paused")]
        
        COMADMIN_E_RECYCLEDPROCESSMAYNOTBEPAUSED = 0x80110817,
        [Description("Access to the specified partition is denied")]
        
        COMADMIN_E_PARTITION_ACCESSDENIED = 0x80110818,
        [Description("Only Application Files (*.MSI files) can be installed into partitions")]
        
        COMADMIN_E_PARTITION_MSI_ONLY = 0x80110819,
        [Description("Applications containing one or more legacy components may not be exported to 1.0 format")]
        
        COMADMIN_E_LEGACYCOMPS_NOT_ALLOWED_IN_1_0_FORMAT = 0x8011081A,
        [Description("Legacy components may not exist in non-base partitions")]
        
        COMADMIN_E_LEGACYCOMPS_NOT_ALLOWED_IN_NONBASE_PARTITIONS = 0x8011081B,
        [Description("A component cannot be moved (or copied) from the System Application, an application proxy or a non-changeable application")]
        
        COMADMIN_E_COMP_MOVE_SOURCE = 0x8011081C,
        [Description("A component cannot be moved (or copied) to the System Application, an application proxy or a non-changeable application")]
        
        COMADMIN_E_COMP_MOVE_DEST = 0x8011081D,
        [Description("A private component cannot be moved (or copied) to a library application or to the base partition")]
        
        COMADMIN_E_COMP_MOVE_PRIVATE = 0x8011081E,
        [Description("The Base Application Partition exists in all partition sets and cannot be removed")]
        
        COMADMIN_E_BASEPARTITION_REQUIRED_IN_SET = 0x8011081F,
        [Description("Alas, Event Class components cannot be aliased")]
        
        COMADMIN_E_CANNOT_ALIAS_EVENTCLASS = 0x80110820,
        [Description("Access is denied because the component is private")]
        
        COMADMIN_E_PRIVATE_ACCESSDENIED = 0x80110821,
        [Description("The specified SAFER level is invalid")]
        
        COMADMIN_E_SAFERINVALID = 0x80110822,
        [Description("The specified user cannot write to the system registry")]
        
        COMADMIN_E_REGISTRY_ACCESSDENIED = 0x80110823,
        [Description("COM+ partitions are currently disabled")]
        
        COMADMIN_E_PARTITIONS_DISABLED = 0x80110824,
        [Description("A handler was not defined by the filter for this operation")]
        
        ERROR_FLT_NO_HANDLER_DEFINED = 0x801F0001,
        [Description("A context is already defined for this object")]
        
        ERROR_FLT_CONTEXT_ALREADY_DEFINED = 0x801F0002,
        [Description("Asynchronous requests are not valid for this operation")]
        
        ERROR_FLT_INVALID_ASYNCHRONOUS_REQUEST = 0x801F0003,
        [Description("Disallow the Fast IO path for this operation")]
        
        ERROR_FLT_DISALLOW_FAST_IO = 0x801F0004,
        [Description("An invalid name request was made. The name requested cannot be retrieved at this time")]
        
        ERROR_FLT_INVALID_NAME_REQUEST = 0x801F0005,
        [Description("Posting this operation to a worker thread for further processing is not safe at this time because it could lead to a system deadlock")]
        
        ERROR_FLT_NOT_SAFE_TO_POST_OPERATION = 0x801F0006,
        [Description("The Filter Manager was not initialized when a filter tried to register. Make sure that the Filter Manager is getting loaded as a driver")]
        
        ERROR_FLT_NOT_INITIALIZED = 0x801F0007,
        [Description("The filter is not ready for attachment to volumes because it has not finished initializing (FltStartFiltering has not been called)")]
        
        ERROR_FLT_FILTER_NOT_READY = 0x801F0008,
        [Description("The filter must cleanup any operation specific context at this time because it is being removed from the system before the operation is completed by the lower drivers")]
        
        ERROR_FLT_POST_OPERATION_CLEANUP = 0x801F0009,
        [Description("The Filter Manager had an internal error from which it cannot recover, therefore the operation has been failed. This is usually the result of a filter returning an invalid value from a pre-operation callback")]
        
        ERROR_FLT_INTERNAL_ERROR = 0x801F000A,
        [Description("The object specified for this action is in the process of being deleted, therefore the action requested cannot be completed at this time")]
        
        ERROR_FLT_DELETING_OBJECT = 0x801F000B,
        [Description("Non-paged pool must be used for this type of context")]
        
        ERROR_FLT_MUST_BE_NONPAGED_POOL = 0x801F000C,
        [Description("A duplicate handler definition has been provided for an operation")]
        
        ERROR_FLT_DUPLICATE_ENTRY = 0x801F000D,
        [Description("The callback data queue has been disabled")]
        
        ERROR_FLT_CBDQ_DISABLED = 0x801F000E,
        [Description("Do not attach the filter to the volume at this time")]
        
        ERROR_FLT_DO_NOT_ATTACH = 0x801F000F,
        [Description("Do not detach the filter from the volume at this time")]
        
        ERROR_FLT_DO_NOT_DETACH = 0x801F0010,
        [Description("An instance already exists at this altitude on the volume specified")]
        
        ERROR_FLT_INSTANCE_ALTITUDE_COLLISION = 0x801F0011,
        [Description("An instance already exists with this name on the volume specified")]
        
        ERROR_FLT_INSTANCE_NAME_COLLISION = 0x801F0012,
        [Description("The system could not find the filter specified")]
        
        ERROR_FLT_FILTER_NOT_FOUND = 0x801F0013,
        [Description("The system could not find the volume specified")]
        
        ERROR_FLT_VOLUME_NOT_FOUND = 0x801F0014,
        [Description("The system could not find the instance specified")]
        
        ERROR_FLT_INSTANCE_NOT_FOUND = 0x801F0015,
        [Description("No registered context allocation definition was found for the given request")]
        
        ERROR_FLT_CONTEXT_ALLOCATION_NOT_FOUND = 0x801F0016,
        [Description("An invalid parameter was specified during context registration")]
        
        ERROR_FLT_INVALID_CONTEXT_REGISTRATION = 0x801F0017,
        [Description("The name requested was not found in Filter Manager's name cache and could not be retrieved from the file system")]
        
        ERROR_FLT_NAME_CACHE_MISS = 0x801F0018,
        [Description("The requested device object does not exist for the given volume")]
        
        ERROR_FLT_NO_DEVICE_OBJECT = 0x801F0019,
        [Description("The specified volume is already mounted")]
        
        ERROR_FLT_VOLUME_ALREADY_MOUNTED = 0x801F001A,
        [Description("The specified Transaction Context is already enlisted in a transaction")]
        
        ERROR_FLT_ALREADY_ENLISTED = 0x801F001B,
        [Description("The specifiec context is already attached to another object")]
        
        ERROR_FLT_CONTEXT_ALREADY_LINKED = 0x801F001C,
        [Description("No waiter is present for the filter's reply to this message")]
        
        ERROR_FLT_NO_WAITER_FOR_REPLY = 0x801F0020,
        [Description("{Display Driver Stopped Responding}\r\nThe % hs display driver has stopped working normally.Save your work and reboot the system to restore full display functionality.\r\nThe next time you reboot the machine a dialog will be displayed giving you a chance to report this failure to Microsoft")]
        
        ERROR_HUNG_DISPLAY_DRIVER_THREAD = 0x80260001,
        [Description("Unknown error (0x80261001)")]
        
        ERROR_MONITOR_NO_DESCRIPTOR = 0x80261001,
        [Description("Unknown error (0x80261002)")]
        
        ERROR_MONITOR_UNKNOWN_DESCRIPTOR_FORMAT = 0x80261002,
        [Description("{Desktop composition is disabled}\r\nThe operation could not be completed because desktop composition is disabled")]
        
        DWM_E_COMPOSITIONDISABLED = 0x80263001,
        [Description("{Some desktop composition APIs are not supported while remoting}\r\nThe operation is not supported while running in a remote session")]
        
        DWM_E_REMOTING_NOT_SUPPORTED = 0x80263002,
        [Description("{No DWM redirection surface is available}\r\nThe DWM was unable to provide a redireciton surface to complete the DirectX present")]
        
        DWM_E_NO_REDIRECTION_SURFACE_AVAILABLE = 0x80263003,
        [Description("{DWM is not queuing presents for the specified window}\r\nThe window specified is not currently using queued presents")]
        DWM_E_NOT_QUEUING_PRESENTS = 0x80263004,
        [Description("This is an error mask to convert TPM hardware errors to win errors")]
        TPM_E_ERROR_MASK = 0x80280000,
        [Description("Authentication failed")]
        TPM_E_AUTHFAIL = 0x80280001,
        [Description("The index to a PCR, DIR or other register is incorrect")]
        TPM_E_BADINDEX = 0x80280002,
        [Description("One or more parameter is bad")]
        TPM_E_BAD_PARAMETER = 0x80280003,
        [Description("An operation completed successfully but the auditing of that operation failed")]
        TPM_E_AUDITFAILURE = 0x80280004,
        [Description("The clear disable flag is set and all clear operations now require physical access")]
        TPM_E_CLEAR_DISABLED = 0x80280005,
        [Description("Activate the Trusted Platform Module (TPM)")]
        TPM_E_DEACTIVATED = 0x80280006,
        [Description("Enable the Trusted Platform Module (TPM)")]
        TPM_E_DISABLED = 0x80280007,
        [Description("The target command has been disabled")]
        TPM_E_DISABLED_CMD = 0x80280008,
        [Description("The operation failed")]
        TPM_E_FAIL = 0x80280009,
        [Description("The ordinal was unknown or inconsistent")]
        TPM_E_BAD_ORDINAL = 0x8028000A,
        [Description("The ability to install an owner is disabled")]
        TPM_E_INSTALL_DISABLED = 0x8028000B,
        [Description("The key handle cannot be interpreted")]
        TPM_E_INVALID_KEYHANDLE = 0x8028000C,
        [Description("The key handle points to an invalid key")]
        TPM_E_KEYNOTFOUND = 0x8028000D,
        [Description("Unacceptable encryption scheme")]
        TPM_E_INAPPROPRIATE_ENC = 0x8028000E,
        [Description("Migration authorization failed")]
        TPM_E_MIGRATEFAIL = 0x8028000F,
        [Description("PCR information could not be interpreted")]
        TPM_E_INVALID_PCR_INFO = 0x80280010,
        [Description("No room to load key")]
        TPM_E_NOSPACE = 0x80280011,
        [Description("There is no Storage Root Key (SRK) set")]
        TPM_E_NOSRK = 0x80280012,
        [Description("An encrypted blob is invalid or was not created by this TPM")]
        TPM_E_NOTSEALED_BLOB = 0x80280013,
        [Description("The Trusted Platform Module (TPM) already has an owner")]
        TPM_E_OWNER_SET = 0x80280014,
        [Description("The TPM has insufficient internal resources to perform the requested action")]
        TPM_E_RESOURCES = 0x80280015,
        [Description("A random string was too short")]
        TPM_E_SHORTRANDOM = 0x80280016,
        [Description("The TPM does not have the space to perform the operation")]
        TPM_E_SIZE = 0x80280017,
        [Description("The named PCR value does not match the current PCR value")]
        TPM_E_WRONGPCRVAL = 0x80280018,
        [Description("The paramSize argument to the command has the incorrect value")]
        TPM_E_BAD_PARAM_SIZE = 0x80280019,
        [Description("There is no existing SHA-1 thread")]
        TPM_E_SHA_THREAD = 0x8028001A,
        [Description("The calculation is unable to proceed because the existing SHA-1 thread has already encountered an error")]
        TPM_E_SHA_ERROR = 0x8028001B,
        [Description("The TPM hardware device reported a failure during its internal self test. Try restarting the computer to resolve the problem. If the problem continues, check for the latest BIOS or firmware update for your TPM hardware. Consult the computer manufacturer's documentation for instructions")]
        TPM_E_FAILEDSELFTEST = 0x8028001C,
        [Description("The authorization for the second key in a 2 key function failed authorization")]
        TPM_E_AUTH2FAIL = 0x8028001D,
        [Description("The tag value sent to for a command is invalid")]
        TPM_E_BADTAG = 0x8028001E,
        [Description("An IO error occurred transmitting information to the TPM")]
        TPM_E_IOERROR = 0x8028001F,
        [Description("The encryption process had a problem")]
        TPM_E_ENCRYPT_ERROR = 0x80280020,
        [Description("The decryption process did not complete")]
        TPM_E_DECRYPT_ERROR = 0x80280021,
        [Description("An invalid handle was used")]
        TPM_E_INVALID_AUTHHANDLE = 0x80280022,
        [Description("The TPM does not have an Endorsement Key (EK) installed")]
        TPM_E_NO_ENDORSEMENT = 0x80280023,
        [Description("The usage of a key is not allowed")]
        TPM_E_INVALID_KEYUSAGE = 0x80280024,
        [Description("The submitted entity type is not allowed")]
        TPM_E_WRONG_ENTITYTYPE = 0x80280025,
        [Description("The command was received in the wrong sequence relative to TPM_Init and a subsequent TPM_Startup")]
        TPM_E_INVALID_POSTINIT = 0x80280026,
        [Description("Signed data cannot include additional DER information")]
        TPM_E_INAPPROPRIATE_SIG = 0x80280027,
        [Description("The key properties in TPM_KEY_PARMs are not supported by this TPM")]
        TPM_E_BAD_KEY_PROPERTY = 0x80280028,
        [Description("The migration properties of this key are incorrect")]
        TPM_E_BAD_MIGRATION = 0x80280029,
        [Description("The signature or encryption scheme for this key is incorrect or not permitted in this situation")]
        TPM_E_BAD_SCHEME = 0x8028002A,
        [Description("The size of the data (or blob) parameter is bad or inconsistent with the referenced key")]
        TPM_E_BAD_DATASIZE = 0x8028002B,
        [Description("A mode parameter is bad, such as capArea or subCapArea for TPM_GetCapability, phsicalPresence parameter for TPM_PhysicalPresence, or migrationType for TPM_CreateMigrationBlob")]
        TPM_E_BAD_MODE = 0x8028002C,
        [Description("Either the physicalPresence or physicalPresenceLock bits have the wrong value")]
        TPM_E_BAD_PRESENCE = 0x8028002D,
        [Description("The TPM cannot perform this version of the capability")]
        TPM_E_BAD_VERSION = 0x8028002E,
        [Description("The TPM does not allow for wrapped transport sessions")]
        TPM_E_NO_WRAP_TRANSPORT = 0x8028002F,
        [Description("TPM audit construction failed and the underlying command was returning a failure code also")]
        TPM_E_AUDITFAIL_UNSUCCESSFUL = 0x80280030,
        [Description("TPM audit construction failed and the underlying command was returning success")]
        TPM_E_AUDITFAIL_SUCCESSFUL = 0x80280031,
        [Description("Attempt to reset a PCR register that does not have the resettable attribute")]
        TPM_E_NOTRESETABLE = 0x80280032,
        [Description("Attempt to reset a PCR register that requires locality and locality modifier not part of command transport")]
        TPM_E_NOTLOCAL = 0x80280033,
        [Description("Make identity blob not properly typed")]
        TPM_E_BAD_TYPE = 0x80280034,
        [Description("When saving context identified resource type does not match actual resource")]
        TPM_E_INVALID_RESOURCE = 0x80280035,
        [Description("The TPM is attempting to execute a command only available when in FIPS mode")]
        TPM_E_NOTFIPS = 0x80280036,
        [Description("The command is attempting to use an invalid family ID")]
        TPM_E_INVALID_FAMILY = 0x80280037,
        [Description("The permission to manipulate the NV storage is not available")]
        TPM_E_NO_NV_PERMISSION = 0x80280038,
        [Description("The operation requires a signed command")]
        TPM_E_REQUIRES_SIGN = 0x80280039,
        [Description("Wrong operation to load an NV key")]
        TPM_E_KEY_NOTSUPPORTED = 0x8028003A,
        [Description("NV_LoadKey blob requires both owner and blob authorization")]
        TPM_E_AUTH_CONFLICT = 0x8028003B,
        [Description("The NV area is locked and not writtable")]
        TPM_E_AREA_LOCKED = 0x8028003C,
        [Description("The locality is incorrect for the attempted operation")]
        TPM_E_BAD_LOCALITY = 0x8028003D,
        [Description("The NV area is read only and can't be written to")]
        TPM_E_READ_ONLY = 0x8028003E,
        [Description("There is no protection on the write to the NV area")]
        TPM_E_PER_NOWRITE = 0x8028003F,
        [Description("The family count value does not match")]
        TPM_E_FAMILYCOUNT = 0x80280040,
        [Description("The NV area has already been written to")]
        TPM_E_WRITE_LOCKED = 0x80280041,
        [Description("The NV area attributes conflict")]
        TPM_E_BAD_ATTRIBUTES = 0x80280042,
        [Description("The structure tag and version are invalid or inconsistent")]
        TPM_E_INVALID_STRUCTURE = 0x80280043,
        [Description("The key is under control of the TPM Owner and can only be evicted by the TPM Owner")]
        TPM_E_KEY_OWNER_CONTROL = 0x80280044,
        [Description("The counter handle is incorrect")]
        TPM_E_BAD_COUNTER = 0x80280045,
        [Description("The write is not a complete write of the area")]
        TPM_E_NOT_FULLWRITE = 0x80280046,
        [Description("The gap between saved context counts is too large")]
        TPM_E_CONTEXT_GAP = 0x80280047,
        [Description("The maximum number of NV writes without an owner has been exceeded")]
        TPM_E_MAXNVWRITES = 0x80280048,
        [Description("No operator AuthData value is set")]
        TPM_E_NOOPERATOR = 0x80280049,
        [Description("The resource pointed to by context is not loaded")]
        TPM_E_RESOURCEMISSING = 0x8028004A,
        [Description("The delegate administration is locked")]
        TPM_E_DELEGATE_LOCK = 0x8028004B,
        [Description("Attempt to manage a family other then the delegated family")]
        TPM_E_DELEGATE_FAMILY = 0x8028004C,
        [Description("Delegation table management not enabled")]
        TPM_E_DELEGATE_ADMIN = 0x8028004D,
        [Description("There was a command executed outside of an exclusive transport session")]
        TPM_E_TRANSPORT_NOTEXCLUSIVE = 0x8028004E,
        [Description("Attempt to context save a owner evict controlled key")]
        TPM_E_OWNER_CONTROL = 0x8028004F,
        [Description("The DAA command has no resources availble to execute the command")]
        TPM_E_DAA_RESOURCES = 0x80280050,
        [Description("The consistency check on DAA parameter inputData0 has failed")]
        TPM_E_DAA_INPUT_DATA0 = 0x80280051,
        [Description("The consistency check on DAA parameter inputData1 has failed")]
        TPM_E_DAA_INPUT_DATA1 = 0x80280052,
        [Description("The consistency check on DAA_issuerSettings has failed")]
        TPM_E_DAA_ISSUER_SETTINGS = 0x80280053,
        [Description("The consistency check on DAA_tpmSpecific has failed")]
        TPM_E_DAA_TPM_SETTINGS = 0x80280054,
        [Description("The atomic process indicated by the submitted DAA command is not the expected process")]
        TPM_E_DAA_STAGE = 0x80280055,
        [Description("The issuer's validity check has detected an inconsistency")]
        TPM_E_DAA_ISSUER_VALIDITY = 0x80280056,
        [Description("The consistency check on w has failed")]
        TPM_E_DAA_WRONG_W = 0x80280057,
        [Description("The handle is incorrect")]
        TPM_E_BAD_HANDLE = 0x80280058,
        [Description("Delegation is not correct")]
        TPM_E_BAD_DELEGATE = 0x80280059,
        [Description("The context blob is invalid")]
        TPM_E_BADCONTEXT = 0x8028005A,
        [Description("Too many contexts held by the TPM")]
        TPM_E_TOOMANYCONTEXTS = 0x8028005B,
        [Description("Migration authority signature validation failure")]
        TPM_E_MA_TICKET_SIGNATURE = 0x8028005C,
        [Description("Migration destination not authenticated")]
        TPM_E_MA_DESTINATION = 0x8028005D,
        [Description("Migration source incorrect")]
        TPM_E_MA_SOURCE = 0x8028005E,
        [Description("Incorrect migration authority")]
        TPM_E_MA_AUTHORITY = 0x8028005F,
        [Description("Attempt to revoke the EK and the EK is not revocable")]
        TPM_E_PERMANENTEK = 0x80280061,
        [Description("Bad signature of CMK ticket")]
        TPM_E_BAD_SIGNATURE = 0x80280062,
        [Description("There is no room in the context list for additional contexts")]
        TPM_E_NOCONTEXTSPACE = 0x80280063,
        [Description("The command was blocked")]
        TPM_E_COMMAND_BLOCKED = 0x80280400,
        [Description("The specified handle was not found")]
        TPM_E_INVALID_HANDLE = 0x80280401,
        [Description("The TPM returned a duplicate handle and the command needs to be resubmitted")]
        TPM_E_DUPLICATE_VHANDLE = 0x80280402,
        [Description("The command within the transport was blocked")]
        TPM_E_EMBEDDED_COMMAND_BLOCKED = 0x80280403,
        [Description("The command within the transport is not supported")]
        TPM_E_EMBEDDED_COMMAND_UNSUPPORTED = 0x80280404,
        [Description("The TPM is too busy to respond to the command immediately, but the command could be resubmitted at a later time")]
        TPM_E_RETRY = 0x80280800,
        [Description("SelfTestFull has not been run")]
        TPM_E_NEEDS_SELFTEST = 0x80280801,
        [Description("The TPM is currently executing a full selftest")]
        TPM_E_DOING_SELFTEST = 0x80280802,
        [Description("The TPM is defending against dictionary attacks and is in a time-out period")]
        TPM_E_DEFEND_LOCK_RUNNING = 0x80280803,
        [Description("An internal error has occurred within the Trusted Platform Module support program")]
        TBS_E_INTERNAL_ERROR = 0x80284001,
        [Description("One or more input parameters is bad")]
        TBS_E_BAD_PARAMETER = 0x80284002,
        [Description("A specified output pointer is bad")]
        TBS_E_INVALID_OUTPUT_POINTER = 0x80284003,
        [Description("The specified context handle does not refer to a valid context")]
        TBS_E_INVALID_CONTEXT = 0x80284004,
        [Description("A specified output buffer is too small")]
        TBS_E_INSUFFICIENT_BUFFER = 0x80284005,
        [Description("An error occurred while communicating with the TPM")]
        TBS_E_IOERROR = 0x80284006,
        [Description("One or more context parameters is invalid")]
        TBS_E_INVALID_CONTEXT_PARAM = 0x80284007,
        [Description("The TBS service is not running and could not be started")]
        TBS_E_SERVICE_NOT_RUNNING = 0x80284008,
        [Description("A new context could not be created because there are too many open contexts")]
        TBS_E_TOO_MANY_TBS_CONTEXTS = 0x80284009,
        [Description("A new virtual resource could not be created because there are too many open virtual resources")]
        TBS_E_TOO_MANY_RESOURCES = 0x8028400A,
        [Description("The TBS service has been started but is not yet running")]
        TBS_E_SERVICE_START_PENDING = 0x8028400B,
        [Description("The physical presence interface is not supported")]
        TBS_E_PPI_NOT_SUPPORTED = 0x8028400C,
        [Description("The command was canceled")]
        TBS_E_COMMAND_CANCELED = 0x8028400D,
        [Description("The input or output buffer is too large")]
        TBS_E_BUFFER_TOO_LARGE = 0x8028400E,
        [Description("The command buffer is not in the correct state")]
        TPMAPI_E_INVALID_STATE = 0x80290100,
        [Description("The command buffer does not contain enough data to satisfy the request")]
        TPMAPI_E_NOT_ENOUGH_DATA = 0x80290101,
        [Description("The command buffer cannot contain any more data")]
        TPMAPI_E_TOO_MUCH_DATA = 0x80290102,
        [Description("One or more output parameters was NULL or invalid")]
        TPMAPI_E_INVALID_OUTPUT_POINTER = 0x80290103,
        [Description("One or more input parameters is invalid")]
        TPMAPI_E_INVALID_PARAMETER = 0x80290104,
        [Description("Not enough memory was available to satisfy the request")]
        TPMAPI_E_OUT_OF_MEMORY = 0x80290105,
        [Description("The specified buffer was too small")]
        TPMAPI_E_BUFFER_TOO_SMALL = 0x80290106,
        [Description("An internal error was detected")]
        TPMAPI_E_INTERNAL_ERROR = 0x80290107,
        [Description("The caller does not have the appropriate rights to perform the requested operation")]
        TPMAPI_E_ACCESS_DENIED = 0x80290108,
        [Description("The specified authorization information was invalid")]
        TPMAPI_E_AUTHORIZATION_FAILED = 0x80290109,
        [Description("The specified context handle was not valid")]
        TPMAPI_E_INVALID_CONTEXT_HANDLE = 0x8029010A,
        [Description("An error occurred while communicating with the TBS")]
        TPMAPI_E_TBS_COMMUNICATION_ERROR = 0x8029010B,
        [Description("The TPM returned an unexpected result")]
        TPMAPI_E_TPM_COMMAND_ERROR = 0x8029010C,
        [Description("The message was too large for the encoding scheme")]
        TPMAPI_E_MESSAGE_TOO_LARGE = 0x8029010D,
        [Description("The encoding in the blob was not recognized")]
        TPMAPI_E_INVALID_ENCODING = 0x8029010E,
        [Description("The key size is not valid")]
        TPMAPI_E_INVALID_KEY_SIZE = 0x8029010F,
        [Description("The encryption operation failed")]
        TPMAPI_E_ENCRYPTION_FAILED = 0x80290110,
        [Description("The key parameters structure was not valid")]
        TPMAPI_E_INVALID_KEY_PARAMS = 0x80290111,
        [Description("The requested supplied data does not appear to be a valid migration authorization blob")]
        TPMAPI_E_INVALID_MIGRATION_AUTHORIZATION_BLOB = 0x80290112,
        [Description("The specified PCR index was invalid")]
        TPMAPI_E_INVALID_PCR_INDEX = 0x80290113,
        [Description("The data given does not appear to be a valid delegate blob")]
        TPMAPI_E_INVALID_DELEGATE_BLOB = 0x80290114,
        [Description("One or more of the specified context parameters was not valid")]
        TPMAPI_E_INVALID_CONTEXT_PARAMS = 0x80290115,
        [Description("The data given does not appear to be a valid key blob")]
        TPMAPI_E_INVALID_KEY_BLOB = 0x80290116,
        [Description("The specified PCR data was invalid")]
        TPMAPI_E_INVALID_PCR_DATA = 0x80290117,
        [Description("The format of the owner auth data was invalid")]
        TPMAPI_E_INVALID_OWNER_AUTH = 0x80290118,
        [Description("The specified buffer was too small")]
        TBSIMP_E_BUFFER_TOO_SMALL = 0x80290200,
        [Description("The context could not be cleaned up")]
        TBSIMP_E_CLEANUP_FAILED = 0x80290201,
        [Description("The specified context handle is invalid")]
        TBSIMP_E_INVALID_CONTEXT_HANDLE = 0x80290202,
        [Description("An invalid context parameter was specified")]
        TBSIMP_E_INVALID_CONTEXT_PARAM = 0x80290203,
        [Description("An error occurred while communicating with the TPM")]
        TBSIMP_E_TPM_ERROR = 0x80290204,
        [Description("No entry with the specified key was found")]
        TBSIMP_E_HASH_BAD_KEY = 0x80290205,
        [Description("The specified virtual handle matches a virtual handle already in use")]
        TBSIMP_E_DUPLICATE_VHANDLE = 0x80290206,
        [Description("The pointer to the returned handle location was NULL or invalid")]
        TBSIMP_E_INVALID_OUTPUT_POINTER = 0x80290207,
        [Description("One or more parameters is invalid")]
        TBSIMP_E_INVALID_PARAMETER = 0x80290208,
        [Description("The RPC subsystem could not be initialized")]
        TBSIMP_E_RPC_INIT_FAILED = 0x80290209,
        [Description("The TBS scheduler is not running")]
        TBSIMP_E_SCHEDULER_NOT_RUNNING = 0x8029020A,
        [Description("The command was canceled")]
        TBSIMP_E_COMMAND_CANCELED = 0x8029020B,
        [Description("There was not enough memory to fulfill the request")]
        TBSIMP_E_OUT_OF_MEMORY = 0x8029020C,
        [Description("The specified list is empty, or the iteration has reached the end of the list")]
        TBSIMP_E_LIST_NO_MORE_ITEMS = 0x8029020D,
        [Description("The specified item was not found in the list")]
        TBSIMP_E_LIST_NOT_FOUND = 0x8029020E,
        [Description("The TPM does not have enough space to load the requested resource")]
        TBSIMP_E_NOT_ENOUGH_SPACE = 0x8029020F,
        [Description("There are too many TPM contexts in use")]
        TBSIMP_E_NOT_ENOUGH_TPM_CONTEXTS = 0x80290210,
        [Description("The TPM command failed")]
        TBSIMP_E_COMMAND_FAILED = 0x80290211,
        [Description("The TBS does not recognize the specified ordinal")]
        TBSIMP_E_UNKNOWN_ORDINAL = 0x80290212,
        [Description("The requested resource is no longer available")]
        TBSIMP_E_RESOURCE_EXPIRED = 0x80290213,
        [Description("The resource type did not match")]
        TBSIMP_E_INVALID_RESOURCE = 0x80290214,
        [Description("No resources can be unloaded")]
        TBSIMP_E_NOTHING_TO_UNLOAD = 0x80290215,
        [Description("No new entries can be added to the hash table")]
        TBSIMP_E_HASH_TABLE_FULL = 0x80290216,
        [Description("A new TBS context could not be created because there are too many open contexts")]
        TBSIMP_E_TOO_MANY_TBS_CONTEXTS = 0x80290217,
        [Description("A new virtual resource could not be created because there are too many open virtual resources")]
        TBSIMP_E_TOO_MANY_RESOURCES = 0x80290218,
        [Description("The physical presence interface is not supported")]
        TBSIMP_E_PPI_NOT_SUPPORTED = 0x80290219,
        [Description("TBS is not compatible with the version of TPM found on the system")]
        TBSIMP_E_TPM_INCOMPATIBLE = 0x8029021A,
        [Description("A general error was detected when attempting to acquire the BIOS's response to a Physical Presence command")]
        TPM_E_PPI_ACPI_FAILURE = 0x80290300,
        [Description("The user failed to confirm the TPM operation request")]
        TPM_E_PPI_USER_ABORT = 0x80290301,
        [Description("The BIOS failure prevented the successful execution of the requested TPM operation (e.g. invalid TPM operation request, BIOS communication error with the TPM)")]
        TPM_E_PPI_BIOS_FAILURE = 0x80290302,
        [Description("The BIOS does not support the physical presence interface")]
        TPM_E_PPI_NOT_SUPPORTED = 0x80290303,
        [Description("Data Collector Set was not found")]
        PLA_E_DCS_NOT_FOUND = 0x80300002,
        [Description("Unable to start Data Collector Set because there are too many folders")]
        PLA_E_TOO_MANY_FOLDERS = 0x80300045,
        [Description("Not enough free disk space to start Data Collector Set")]
        PLA_E_NO_MIN_DISK = 0x80300070,
        [Description("The Data Collector Set or one of its dependencies is already in use")]
        PLA_E_DCS_IN_USE = 0x803000AA,
        [Description("Data Collector Set already exists")]
        PLA_E_DCS_ALREADY_EXISTS = 0x803000B7,
        [Description("Property value conflict")]
        PLA_E_PROPERTY_CONFLICT = 0x80300101,
        [Description("The current configuration for this Data Collector Set requires that it contain exactly one Data Collector")]
        PLA_E_DCS_SINGLETON_REQUIRED = 0x80300102,
        [Description("A user account is required in order to commit the current Data Collector Set properties")]
        PLA_E_CREDENTIALS_REQUIRED = 0x80300103,
        [Description("Data Collector Set is not running")]
        PLA_E_DCS_NOT_RUNNING = 0x80300104,
        [Description("A conflict was detected in the list of include/exclude APIs. Do not specify the same API in both the include list and the exclude list")]
        PLA_E_CONFLICT_INCL_EXCL_API = 0x80300105,
        [Description("The executable path you have specified refers to a network share or UNC path")]
        PLA_E_NETWORK_EXE_NOT_VALID = 0x80300106,
        [Description("The executable path you have specified is already configured for API tracing")]
        PLA_E_EXE_ALREADY_CONFIGURED = 0x80300107,
        [Description("The executable path you have specified does not exist. Verify that the specified path is correct")]
        PLA_E_EXE_PATH_NOT_VALID = 0x80300108,
        [Description("Data Collector already exists")]
        PLA_E_DC_ALREADY_EXISTS = 0x80300109,
        [Description("The wait for the Data Collector Set start notification has timed out")]
        PLA_E_DCS_START_WAIT_TIMEOUT = 0x8030010A,
        [Description("The wait for the Data Collector to start has timed out")]
        PLA_E_DC_START_WAIT_TIMEOUT = 0x8030010B,
        [Description("The wait for the report generation tool to finish has timed out")]
        PLA_E_REPORT_WAIT_TIMEOUT = 0x8030010C,
        [Description("Duplicate items are not allowed")]
        PLA_E_NO_DUPLICATES = 0x8030010D,
        [Description("When specifying the executable that you want to trace, you must specify a full path to the executable and not just a filename")]
        PLA_E_EXE_FULL_PATH_REQUIRED = 0x8030010E,
        [Description("The session name provided is invalid")]
        PLA_E_INVALID_SESSION_NAME = 0x8030010F,
        [Description("The Event Log channel Microsoft-Windows-Diagnosis-PLA/Operational must be enabled to perform this operation")]
        PLA_E_PLA_CHANNEL_NOT_ENABLED = 0x80300110,
        [Description("The Event Log channel Microsoft-Windows-TaskScheduler must be enabled to perform this operation")]
        PLA_E_TASKSCHED_CHANNEL_NOT_ENABLED = 0x80300111,
        [Description("This drive is locked by BitLocker Drive Encryption. You must unlock this drive from Control Panel")]
        FVE_E_LOCKED_VOLUME = 0x80310000,
        [Description("This drive is not encrypted")]
        FVE_E_NOT_ENCRYPTED = 0x80310001,
        [Description("The BIOS did not correctly communicate with the Trusted Platform Module (TPM). Contact the computer manufacturer for BIOS upgrade instructions")]
        FVE_E_NO_TPM_BIOS = 0x80310002,
        [Description("The BIOS did not correctly communicate with the master boot record (MBR). Contact the computer manufacturer for BIOS upgrade instructions")]
        FVE_E_NO_MBR_METRIC = 0x80310003,
        [Description("A required TPM measurement is missing. If there is a bootable CD or DVD in your computer, remove it, restart the computer, and turn on BitLocker again. If the problem persists, ensure the master boot record is up to date")]
        FVE_E_NO_BOOTSECTOR_METRIC = 0x80310004,
        [Description("The boot sector of this drive is not compatible with BitLocker Drive Encryption. Use the Bootrec.exe tool in the Windows Recovery Environment to update or repair the boot manager (BOOTMGR)")]
        FVE_E_NO_BOOTMGR_METRIC = 0x80310005,
        [Description("The boot manager of this operating system is not compatible with BitLocker Drive Encryption. Use the Bootrec.exe tool in the Windows Recovery Environment to update or repair the boot manager (BOOTMGR)")]
        FVE_E_WRONG_BOOTMGR = 0x80310006,
        [Description("At least one secure key protector is required for this operation to be performed")]
        FVE_E_SECURE_KEY_REQUIRED = 0x80310007,
        [Description("BitLocker Drive Encryption is not enabled on this drive. Turn on BitLocker")]
        FVE_E_NOT_ACTIVATED = 0x80310008,
        [Description("BitLocker Drive Encryption cannot perform the requested action. This condition may occur when two requests are issued at the same time. Wait a few moments and then try the action again")]
        FVE_E_ACTION_NOT_ALLOWED = 0x80310009,
        [Description("The Active Directory Domain Services forest does not contain the required attributes and classes to host BitLocker Drive Encryption or Trusted Platform Module information. Contact your domain administrator to verify that any required BitLocker Active Directory schema extensions have been installed")]
        FVE_E_AD_SCHEMA_NOT_INSTALLED = 0x8031000A,
        [Description("The type of the data obtained from Active Directory was not expected. The BitLocker recovery information may be missing or corrupted")]
        FVE_E_AD_INVALID_DATATYPE = 0x8031000B,
        [Description("The size of the data obtained from Active Directory was not expected. The BitLocker recovery information may be missing or corrupted")]
        FVE_E_AD_INVALID_DATASIZE = 0x8031000C,
        [Description("The attribute read from Active Directory does not contain any values. The BitLocker recovery information may be missing or corrupted")]
        FVE_E_AD_NO_VALUES = 0x8031000D,
        [Description("The attribute was not set. Verify that you are logged on with a domain account that has the ability to write information to Active Directory objects")]
        FVE_E_AD_ATTR_NOT_SET = 0x8031000E,
        [Description("The specified attribute cannot be found in Active Directory Domain Services. Contact your domain administrator to verify that any required BitLocker Active Directory schema extensions have been installed")]
        FVE_E_AD_GUID_NOT_FOUND = 0x8031000F,
        [Description("The BitLocker metadata for the encrypted drive is not valid. You can attempt to repair the drive to restore access")]
        FVE_E_BAD_INFORMATION = 0x80310010,
        [Description("The drive cannot be encrypted because it does not have enough free space. Delete any unnecessary data on the drive to create additional free space and then try again")]
        FVE_E_TOO_SMALL = 0x80310011,
        [Description("The drive cannot be encrypted because it contains system boot information. Create a separate partition for use as the system drive that contains the boot information and a second partition for use as the operating system drive and then encrypt the operating system drive")]
        FVE_E_SYSTEM_VOLUME = 0x80310012,
        [Description("The drive cannot be encrypted because the file system is not supported")]
        FVE_E_FAILED_WRONG_FS = 0x80310013,
        [Description("The file system size is larger than the partition size in the partition table. This drive may be corrupt or may have been tampered with. To use it with BitLocker, you must reformat the partition")]
        FVE_E_FAILED_BAD_FS = 0x80310014,
        [Description("This drive cannot be encrypted")]
        FVE_E_NOT_SUPPORTED = 0x80310015,
        [Description("The data is not valid")]
        FVE_E_BAD_DATA = 0x80310016,
        [Description("The data drive specified is not set to automatically unlock on the current computer and cannot be unlocked automatically")]
        FVE_E_VOLUME_NOT_BOUND = 0x80310017,
        [Description("You must initialize the Trusted Platform Module (TPM) before you can use BitLocker Drive Encryption")]
        FVE_E_TPM_NOT_OWNED = 0x80310018,
        [Description("The operation attempted cannot be performed on an operating system drive")]
        FVE_E_NOT_DATA_VOLUME = 0x80310019,
        [Description("The buffer supplied to a function was insufficient to contain the returned data. Increase the buffer size before running the function again")]
        FVE_E_AD_INSUFFICIENT_BUFFER = 0x8031001A,
        [Description("A read operation failed while converting the drive. The drive was not converted. Please re-enable BitLocker")]
        FVE_E_CONV_READ = 0x8031001B,
        [Description("A write operation failed while converting the drive. The drive was not converted. Please re-enable BitLocker")]
        FVE_E_CONV_WRITE = 0x8031001C,
        [Description("One or more BitLocker key protectors are required. You cannot delete the last key on this drive")]
        FVE_E_KEY_REQUIRED = 0x8031001D,
        [Description("Cluster configurations are not supported by BitLocker Drive Encryption")]
        FVE_E_CLUSTERING_NOT_SUPPORTED = 0x8031001E,
        [Description("The drive specified is already configured to be automatically unlocked on the current computer")]
        FVE_E_VOLUME_BOUND_ALREADY = 0x8031001F,
        [Description("The operating system drive is not protected by BitLocker Drive Encryption")]
        FVE_E_OS_NOT_PROTECTED = 0x80310020,
        [Description("BitLocker Drive Encryption has been suspended on this drive. All BitLocker key protectors configured for this drive are effectively disabled, and the drive will be automatically unlocked using an unencrypted (clear) key")]
        FVE_E_PROTECTION_DISABLED = 0x80310021,
        [Description("The drive you are attempting to lock does not have any key protectors available for encryption because BitLocker protection is currently suspended. Re-enable BitLocker to lock this drive")]
        FVE_E_RECOVERY_KEY_REQUIRED = 0x80310022,
        [Description("BitLocker cannot use the Trusted Platform Module (TPM) to protect a data drive. TPM protection can only be used with the operating system drive")]
        FVE_E_FOREIGN_VOLUME = 0x80310023,
        [Description("The BitLocker metadata for the encrypted drive cannot be updated because it was locked for updating by another process. Please try this process again")]
        FVE_E_OVERLAPPED_UPDATE = 0x80310024,
        [Description("The authorization data for the storage root key (SRK) of the Trusted Platform Module (TPM) is not zero and is therefore incompatible with BitLocker. Please initialize the TPM before attempting to use it with BitLocker")]
        FVE_E_TPM_SRK_AUTH_NOT_ZERO = 0x80310025,
        [Description("The drive encryption algorithm cannot be used on this sector size")]
        FVE_E_FAILED_SECTOR_SIZE = 0x80310026,
        [Description("The drive cannot be unlocked with the key provided. Confirm that you have provided the correct key and try again")]
        FVE_E_FAILED_AUTHENTICATION = 0x80310027,
        [Description("The drive specified is not the operating system drive")]
        FVE_E_NOT_OS_VOLUME = 0x80310028,
        [Description("BitLocker Drive Encryption cannot be turned off on the operating system drive until the auto unlock feature has been disabled for the fixed data drives and removable data drives associated with this computer")]
        FVE_E_AUTOUNLOCK_ENABLED = 0x80310029,
        [Description("The system partition boot sector does not perform Trusted Platform Module (TPM) measurements. Use the Bootrec.exe tool in the Windows Recovery Environment to update or repair the boot sector")]
        FVE_E_WRONG_BOOTSECTOR = 0x8031002A,
        [Description("BitLocker Drive Encryption operating system drives must be formatted with the NTFS file system in order to be encrypted. Convert the drive to NTFS, and then turn on BitLocker")]
        FVE_E_WRONG_SYSTEM_FS = 0x8031002B,
        [Description("Group Policy settings require that a recovery password be specified before encrypting the drive")]
        FVE_E_POLICY_PASSWORD_REQUIRED = 0x8031002C,
        [Description("The drive encryption algorithm and key cannot be set on a previously encrypted drive. To encrypt this drive with BitLocker Drive Encryption, remove the previous encryption and then turn on BitLocker")]
        FVE_E_CANNOT_SET_FVEK_ENCRYPTED = 0x8031002D,
        [Description("BitLocker Drive Encryption cannot encrypt the specified drive because an encryption key is not available. Add a key protector to encrypt this drive")]
        FVE_E_CANNOT_ENCRYPT_NO_KEY = 0x8031002E,
        [Description("BitLocker Drive Encryption detected bootable media (CD or DVD) in the computer. Remove the media and restart the computer before configuring BitLocker")]
        FVE_E_BOOTABLE_CDDVD = 0x80310030,
        [Description("This key protector cannot be added. Only one key protector of this type is allowed for this drive")]
        FVE_E_PROTECTOR_EXISTS = 0x80310031,
        [Description("The recovery password file was not found because a relative path was specified. Recovery passwords must be saved to a fully qualified path. Environment variables configured on the computer can be used in the path")]
        FVE_E_RELATIVE_PATH = 0x80310032,
        [Description("The callout does not exist")]
        FWP_E_CALLOUT_NOT_FOUND = 0x80320001,
        [Description("The filter condition does not exist")]
        FWP_E_CONDITION_NOT_FOUND = 0x80320002,
        [Description("The filter does not exist")]
        FWP_E_FILTER_NOT_FOUND = 0x80320003,
        [Description("The layer does not exist")]
        FWP_E_LAYER_NOT_FOUND = 0x80320004,
        [Description("The provider does not exist")]
        FWP_E_PROVIDER_NOT_FOUND = 0x80320005,
        [Description("The provider context does not exist")]
        FWP_E_PROVIDER_CONTEXT_NOT_FOUND = 0x80320006,
        [Description("The sublayer does not exist")]
        FWP_E_SUBLAYER_NOT_FOUND = 0x80320007,
        [Description("The object does not exist")]
        FWP_E_NOT_FOUND = 0x80320008,
        [Description("An object with that GUID or LUID already exists")]
        FWP_E_ALREADY_EXISTS = 0x80320009,
        [Description("The object is referenced by other objects so cannot be deleted")]
        FWP_E_IN_USE = 0x8032000A,
        [Description("The call is not allowed from within a dynamic session")]
        FWP_E_DYNAMIC_SESSION_IN_PROGRESS = 0x8032000B,
        [Description("The call was made from the wrong session so cannot be completed")]
        FWP_E_WRONG_SESSION = 0x8032000C,
        [Description("The call must be made from within an explicit transaction")]
        FWP_E_NO_TXN_IN_PROGRESS = 0x8032000D,
        [Description("The call is not allowed from within an explicit transaction")]
        FWP_E_TXN_IN_PROGRESS = 0x8032000E,
        [Description("The explicit transaction has been forcibly cancelled")]
        FWP_E_TXN_ABORTED = 0x8032000F,
        [Description("The session has been cancelled")]
        FWP_E_SESSION_ABORTED = 0x80320010,
        [Description("The call is not allowed from within a read-only transaction")]
        FWP_E_INCOMPATIBLE_TXN = 0x80320011,
        [Description("The call timed out while waiting to acquire the transaction lock")]
        FWP_E_TIMEOUT = 0x80320012,
        [Description("Collection of network diagnostic events is disabled")]
        FWP_E_NET_EVENTS_DISABLED = 0x80320013,
        [Description("The operation is not supported by the specified layer")]
        FWP_E_INCOMPATIBLE_LAYER = 0x80320014,
        [Description("The call is allowed for kernel-mode callers only")]
        FWP_E_KM_CLIENTS_ONLY = 0x80320015,
        [Description("The call tried to associate two objects with incompatible lifetimes")]
        FWP_E_LIFETIME_MISMATCH = 0x80320016,
        [Description("The object is built in so cannot be deleted")]
        FWP_E_BUILTIN_OBJECT = 0x80320017,
        [Description("The maximum number of callouts has been reached")]
        FWP_E_TOO_MANY_BOOTTIME_FILTERS = 0x80320018,
        [Description("A notification could not be delivered because a message queue is at its maximum capacity")]
        FWP_E_NOTIFICATION_DROPPED = 0x80320019,
        [Description("The traffic parameters do not match those for the security association context")]
        FWP_E_TRAFFIC_MISMATCH = 0x8032001A,
        [Description("The call is not allowed for the current security association state")]
        FWP_E_INCOMPATIBLE_SA_STATE = 0x8032001B,
        [Description("A required pointer is null")]
        FWP_E_NULL_POINTER = 0x8032001C,
        [Description("An enumerator is not valid")]
        FWP_E_INVALID_ENUMERATOR = 0x8032001D,
        [Description("The flags field contains an invalid value")]
        FWP_E_INVALID_FLAGS = 0x8032001E,
        [Description("A network mask is not valid")]
        FWP_E_INVALID_NET_MASK = 0x8032001F,
        [Description("An FWP_RANGE is not valid")]
        FWP_E_INVALID_RANGE = 0x80320020,
        [Description("The time interval is not valid")]
        FWP_E_INVALID_INTERVAL = 0x80320021,
        [Description("An array that must contain at least one element is zero length")]
        FWP_E_ZERO_LENGTH_ARRAY = 0x80320022,
        [Description("The displayData.name field cannot be null")]
        FWP_E_NULL_DISPLAY_NAME = 0x80320023,
        [Description("The action type is not one of the allowed action types for a filter")]
        FWP_E_INVALID_ACTION_TYPE = 0x80320024,
        [Description("The filter weight is not valid")]
        FWP_E_INVALID_WEIGHT = 0x80320025,
        [Description("A filter condition contains a match type that is not compatible with the operands")]
        FWP_E_MATCH_TYPE_MISMATCH = 0x80320026,
        [Description("An FWP_VALUE or FWPM_CONDITION_VALUE is of the wrong type")]
        FWP_E_TYPE_MISMATCH = 0x80320027,
        [Description("An integer value is outside the allowed range")]
        FWP_E_OUT_OF_BOUNDS = 0x80320028,
        [Description("A reserved field is non-zero")]
        FWP_E_RESERVED = 0x80320029,
        [Description("A filter cannot contain multiple conditions operating on a single field")]
        FWP_E_DUPLICATE_CONDITION = 0x8032002A,
        [Description("A policy cannot contain the same keying module more than once")]
        FWP_E_DUPLICATE_KEYMOD = 0x8032002B,
        [Description("The action type is not compatible with the layer")]
        FWP_E_ACTION_INCOMPATIBLE_WITH_LAYER = 0x8032002C,
        [Description("The action type is not compatible with the sublayer")]
        FWP_E_ACTION_INCOMPATIBLE_WITH_SUBLAYER = 0x8032002D,
        [Description("The raw context or the provider context is not compatible with the layer")]
        FWP_E_CONTEXT_INCOMPATIBLE_WITH_LAYER = 0x8032002E,
        [Description("The raw context or the provider context is not compatible with the callout")]
        FWP_E_CONTEXT_INCOMPATIBLE_WITH_CALLOUT = 0x8032002F,
        [Description("The authentication method is not compatible with the policy type")]
        FWP_E_INCOMPATIBLE_AUTH_METHOD = 0x80320030,
        [Description("The Diffie-Hellman group is not compatible with the policy type")]
        FWP_E_INCOMPATIBLE_DH_GROUP = 0x80320031,
        [Description("An IKE policy cannot contain an Extended Mode policy")]
        FWP_E_EM_NOT_SUPPORTED = 0x80320032,
        [Description("The enumeration template or subscription will never match any objects")]
        FWP_E_NEVER_MATCH = 0x80320033,
        [Description("The provider context is of the wrong type")]
        FWP_E_PROVIDER_CONTEXT_MISMATCH = 0x80320034,
        [Description("The parameter is incorrect")]
        FWP_E_INVALID_PARAMETER = 0x80320035,
        [Description("The maximum number of sublayers has been reached")]
        FWP_E_TOO_MANY_SUBLAYERS = 0x80320036,
        [Description("The notification function for a callout returned an error")]
        FWP_E_CALLOUT_NOTIFICATION_FAILED = 0x80320037,
        [Description("The IPsec authentication transform is not valid")]
        FWP_E_INCOMPATIBLE_AUTH_CONFIG = 0x80320038,
        [Description("The IPsec cipher transform is not valid")]
        FWP_E_INCOMPATIBLE_CIPHER_CONFIG = 0x80320039,
        [Description("The binding to the network interface is being closed")]
        ERROR_NDIS_INTERFACE_CLOSING = 0x80340002,
        [Description("An invalid version was specified")]
        ERROR_NDIS_BAD_VERSION = 0x80340004,
        [Description("An invalid characteristics table was used")]
        ERROR_NDIS_BAD_CHARACTERISTICS = 0x80340005,
        [Description("Failed to find the network interface or network interface is not ready")]
        ERROR_NDIS_ADAPTER_NOT_FOUND = 0x80340006,
        [Description("Failed to open the network interface")]
        ERROR_NDIS_OPEN_FAILED = 0x80340007,
        [Description("Network interface has encountered an internal unrecoverable failure")]
        ERROR_NDIS_DEVICE_FAILED = 0x80340008,
        [Description("The multicast list on the network interface is full")]
        ERROR_NDIS_MULTICAST_FULL = 0x80340009,
        [Description("An attempt was made to add a duplicate multicast address to the list")]
        ERROR_NDIS_MULTICAST_EXISTS = 0x8034000A,
        [Description("At attempt was made to remove a multicast address that was never added")]
        ERROR_NDIS_MULTICAST_NOT_FOUND = 0x8034000B,
        [Description("Netowork interface aborted the request")]
        ERROR_NDIS_REQUEST_ABORTED = 0x8034000C,
        [Description("Network interface can not process the request because it is being reset")]
        ERROR_NDIS_RESET_IN_PROGRESS = 0x8034000D,
        [Description("An attempt was made to send an invalid packet on a network interface")]
        ERROR_NDIS_INVALID_PACKET = 0x8034000F,
        [Description("The specified request is not a valid operation for the target device")]
        ERROR_NDIS_INVALID_DEVICE_REQUEST = 0x80340010,
        [Description("Network interface is not ready to complete this operation")]
        ERROR_NDIS_ADAPTER_NOT_READY = 0x80340011,
        [Description("The length of the buffer submitted for this operation is not valid")]
        ERROR_NDIS_INVALID_LENGTH = 0x80340014,
        [Description("The data used for this operation is not valid")]
        ERROR_NDIS_INVALID_DATA = 0x80340015,
        [Description("The length of buffer submitted for this operation is too small")]
        ERROR_NDIS_BUFFER_TOO_SHORT = 0x80340016,
        [Description("Network interface does not support this OID (Object Identifier)")]
        ERROR_NDIS_INVALID_OID = 0x80340017,
        [Description("The network interface has been removed")]
        ERROR_NDIS_ADAPTER_REMOVED = 0x80340018,
        [Description("Network interface does not support this media type")]
        ERROR_NDIS_UNSUPPORTED_MEDIA = 0x80340019,
        [Description("An attempt was made to remove a token ring group address that is in use by other components")]
        ERROR_NDIS_GROUP_ADDRESS_IN_USE = 0x8034001A,
        [Description("An attempt was made to map a file that can not be found")]
        ERROR_NDIS_FILE_NOT_FOUND = 0x8034001B,
        [Description("An error occurred while NDIS tried to map the file")]
        ERROR_NDIS_ERROR_READING_FILE = 0x8034001C,
        [Description("An attempt was made to map a file that is alreay mapped")]
        ERROR_NDIS_ALREADY_MAPPED = 0x8034001D,
        [Description("An attempt to allocate a hardware resource failed because the resource is used by another component")]
        ERROR_NDIS_RESOURCE_CONFLICT = 0x8034001E,
        [Description("The I/O operation failed because network media is disconnected or wireless access point is out of range")]
        ERROR_NDIS_MEDIA_DISCONNECTED = 0x8034001F,
        [Description("The network address used in the request is invalid")]
        ERROR_NDIS_INVALID_ADDRESS = 0x80340022,
        [Description("The offload operation on the network interface has been paused")]
        ERROR_NDIS_PAUSED = 0x8034002A,
        [Description("Network interface was not found")]
        ERROR_NDIS_INTERFACE_NOT_FOUND = 0x8034002B,
        [Description("The revision number specified in the structure is not supported")]
        ERROR_NDIS_UNSUPPORTED_REVISION = 0x8034002C,
        [Description("The specified port does not exist on this network interface")]
        ERROR_NDIS_INVALID_PORT = 0x8034002D,
        [Description("The current state of the specified port on this network interface does not support the requested operation")]
        ERROR_NDIS_INVALID_PORT_STATE = 0x8034002E,
        [Description("Netword interface does not support this request")]
        ERROR_NDIS_NOT_SUPPORTED = 0x803400BB,
        [Description("The wireless local area network interface is in auto configuration mode and doesn't support the requested parameter change operation")]
        ERROR_NDIS_DOT11_AUTO_CONFIG_ENABLED = 0x80342000,
        [Description("The wireless local area network interface is busy and can not perform the requested operation")]
        ERROR_NDIS_DOT11_MEDIA_IN_USE = 0x80342001,
        [Description("The wireless local area network interface is powered down and doesn't support the requested operation")]
        ERROR_NDIS_DOT11_POWER_STATE_INVALID = 0x80342002,
        [Description("Unknown error (0x8dead01b)")]
        TRK_E_NOT_FOUND = 0x8DEAD01B,
        [Description("Unknown error (0x8dead01c)")]
        TRK_E_VOLUME_QUOTA_EXCEEDED = 0x8DEAD01C,
        [Description("Unknown error (0x8dead01e)")]
        TRK_SERVER_TOO_BUSY = 0x8DEAD01E,
        [Description("The specified event is currently not being audited")]
        ERROR_AUDITING_DISABLED = 0xC0090001,
        [Description("The SID filtering operation removed all SIDs")]
        ERROR_ALL_SIDS_FILTERED = 0xC0090002,
        [Description("Business rule scripts are disabled for the calling application")]
        ERROR_BIZRULES_NOT_ENABLED = 0xC0090003,
        [Description("Unknown error (0xc00d0005)")]
        NS_E_NOCONNECTION = 0xC00D0005,
        [Description("Unknown error (0xc00d0006)")]
        NS_E_CANNOTCONNECT = 0xC00D0006,
        [Description("Unknown error (0xc00d0007)")]
        NS_E_CANNOTDESTROYTITLE = 0xC00D0007,
        [Description("Unknown error (0xc00d0008)")]
        NS_E_CANNOTRENAMETITLE = 0xC00D0008,
        [Description("Unknown error (0xc00d0009)")]
        NS_E_CANNOTOFFLINEDISK = 0xC00D0009,
        [Description("Unknown error (0xc00d000a)")]
        NS_E_CANNOTONLINEDISK = 0xC00D000A,
        [Description("Unknown error (0xc00d000b)")]
        NS_E_NOREGISTEREDWALKER = 0xC00D000B,
        [Description("Unknown error (0xc00d000c)")]
        NS_E_NOFUNNEL = 0xC00D000C,
        [Description("Unknown error (0xc00d000d)")]
        NS_E_NO_LOCALPLAY = 0xC00D000D,
        [Description("Unknown error (0xc00d000e)")]
        NS_E_NETWORK_BUSY = 0xC00D000E,
        [Description("Unknown error (0xc00d000f)")]
        NS_E_TOO_MANY_SESS = 0xC00D000F,
        [Description("Unknown error (0xc00d0010)")]
        NS_E_ALREADY_CONNECTED = 0xC00D0010,
        [Description("Unknown error (0xc00d0011)")]
        NS_E_INVALID_INDEX = 0xC00D0011,
        [Description("Unknown error (0xc00d0012)")]
        NS_E_PROTOCOL_MISMATCH = 0xC00D0012,
        [Description("Unknown error (0xc00d0013)")]
        NS_E_TIMEOUT = 0xC00D0013,
        [Description("Unknown error (0xc00d0014)")]
        NS_E_NET_WRITE = 0xC00D0014,
        [Description("Unknown error (0xc00d0015)")]
        NS_E_NET_READ = 0xC00D0015,
        [Description("Unknown error (0xc00d0016)")]
        NS_E_DISK_WRITE = 0xC00D0016,
        [Description("Unknown error (0xc00d0017)")]
        NS_E_DISK_READ = 0xC00D0017,
        [Description("Unknown error (0xc00d0018)")]
        NS_E_FILE_WRITE = 0xC00D0018,
        [Description("Unknown error (0xc00d0019)")]
        NS_E_FILE_READ = 0xC00D0019,
        [Description("Unknown error (0xc00d001a)")]
        NS_E_FILE_NOT_FOUND = 0xC00D001A,
        [Description("Unknown error (0xc00d001b)")]
        NS_E_FILE_EXISTS = 0xC00D001B,
        [Description("Unknown error (0xc00d001c)")]
        NS_E_INVALID_NAME = 0xC00D001C,
        [Description("Unknown error (0xc00d001d)")]
        NS_E_FILE_OPEN_FAILED = 0xC00D001D,
        [Description("Unknown error (0xc00d001e)")]
        NS_E_FILE_ALLOCATION_FAILED = 0xC00D001E,
        [Description("Unknown error (0xc00d001f)")]
        NS_E_FILE_INIT_FAILED = 0xC00D001F,
        [Description("Unknown error (0xc00d0020)")]
        NS_E_FILE_PLAY_FAILED = 0xC00D0020,
        [Description("Unknown error (0xc00d0021)")]
        NS_E_SET_DISK_UID_FAILED = 0xC00D0021,
        [Description("Unknown error (0xc00d0022)")]
        NS_E_INDUCED = 0xC00D0022,
        [Description("Unknown error (0xc00d0023)")]
        NS_E_CCLINK_DOWN = 0xC00D0023,
        [Description("Unknown error (0xc00d0024)")]
        NS_E_INTERNAL = 0xC00D0024,
        [Description("Unknown error (0xc00d0025)")]
        NS_E_BUSY = 0xC00D0025,
        [Description("Unknown error (0xc00d0026)")]
        NS_E_UNRECOGNIZED_STREAM_TYPE = 0xC00D0026,
        [Description("Unknown error (0xc00d0027)")]
        NS_E_NETWORK_SERVICE_FAILURE = 0xC00D0027,
        [Description("Unknown error (0xc00d0028)")]
        NS_E_NETWORK_RESOURCE_FAILURE = 0xC00D0028,
        [Description("Unknown error (0xc00d0029)")]
        NS_E_CONNECTION_FAILURE = 0xC00D0029,
        [Description("Unknown error (0xc00d002a)")]
        NS_E_SHUTDOWN = 0xC00D002A,
        [Description("Unknown error (0xc00d002b)")]
        NS_E_INVALID_REQUEST = 0xC00D002B,
        [Description("Unknown error (0xc00d002c)")]
        NS_E_INSUFFICIENT_BANDWIDTH = 0xC00D002C,
        [Description("Unknown error (0xc00d002d)")]
        NS_E_NOT_REBUILDING = 0xC00D002D,
        [Description("Unknown error (0xc00d002e)")]
        NS_E_LATE_OPERATION = 0xC00D002E,
        [Description("Unknown error (0xc00d002f)")]
        NS_E_INVALID_DATA = 0xC00D002F,
        [Description("Unknown error (0xc00d0030)")]
        NS_E_FILE_BANDWIDTH_LIMIT = 0xC00D0030,
        [Description("Unknown error (0xc00d0031)")]
        NS_E_OPEN_FILE_LIMIT = 0xC00D0031,
        [Description("Unknown error (0xc00d0032)")]
        NS_E_BAD_CONTROL_DATA = 0xC00D0032,
        [Description("Unknown error (0xc00d0033)")]
        NS_E_NO_STREAM = 0xC00D0033,
        [Description("Unknown error (0xc00d0034)")]
        NS_E_STREAM_END = 0xC00D0034,
        [Description("Unknown error (0xc00d0035)")]
        NS_E_SERVER_NOT_FOUND = 0xC00D0035,
        [Description("Unknown error (0xc00d0036)")]
        NS_E_DUPLICATE_NAME = 0xC00D0036,
        [Description("Unknown error (0xc00d0037)")]
        NS_E_DUPLICATE_ADDRESS = 0xC00D0037,
        [Description("Unknown error (0xc00d0038)")]
        NS_E_BAD_MULTICAST_ADDRESS = 0xC00D0038,
        [Description("Unknown error (0xc00d0039)")]
        NS_E_BAD_ADAPTER_ADDRESS = 0xC00D0039,
        [Description("Unknown error (0xc00d003a)")]
        NS_E_BAD_DELIVERY_MODE = 0xC00D003A,
        [Description("Unknown error (0xc00d003b)")]
        NS_E_INVALID_CHANNEL = 0xC00D003B,
        [Description("Unknown error (0xc00d003c)")]
        NS_E_INVALID_STREAM = 0xC00D003C,
        [Description("Unknown error (0xc00d003d)")]
        NS_E_INVALID_ARCHIVE = 0xC00D003D,
        [Description("Unknown error (0xc00d003e)")]
        NS_E_NOTITLES = 0xC00D003E,
        [Description("Unknown error (0xc00d003f)")]
        NS_E_INVALID_CLIENT = 0xC00D003F,
        [Description("Unknown error (0xc00d0040)")]
        NS_E_INVALID_BLACKHOLE_ADDRESS = 0xC00D0040,
        [Description("Unknown error (0xc00d0041)")]
        NS_E_INCOMPATIBLE_FORMAT = 0xC00D0041,
        [Description("Unknown error (0xc00d0042)")]
        NS_E_INVALID_KEY = 0xC00D0042,
        [Description("Unknown error (0xc00d0043)")]
        NS_E_INVALID_PORT = 0xC00D0043,
        [Description("Unknown error (0xc00d0044)")]
        NS_E_INVALID_TTL = 0xC00D0044,
        [Description("Unknown error (0xc00d0045)")]
        NS_E_STRIDE_REFUSED = 0xC00D0045,
        [Description("Unknown error (0xc00d0046)")]
        NS_E_MMSAUTOSERVER_CANTFINDWALKER = 0xC00D0046,
        [Description("Unknown error (0xc00d0047)")]
        NS_E_MAX_BITRATE = 0xC00D0047,
        [Description("Unknown error (0xc00d0048)")]
        NS_E_LOGFILEPERIOD = 0xC00D0048,
        [Description("Unknown error (0xc00d0049)")]
        NS_E_MAX_CLIENTS = 0xC00D0049,
        [Description("Unknown error (0xc00d004a)")]
        NS_E_LOG_FILE_SIZE = 0xC00D004A,
        [Description("Unknown error (0xc00d004b)")]
        NS_E_MAX_FILERATE = 0xC00D004B,
        [Description("Unknown error (0xc00d004c)")]
        NS_E_WALKER_UNKNOWN = 0xC00D004C,
        [Description("Unknown error (0xc00d004d)")]
        NS_E_WALKER_SERVER = 0xC00D004D,
        [Description("Unknown error (0xc00d004e)")]
        NS_E_WALKER_USAGE = 0xC00D004E,
        [Description("Unknown error (0xc00d0050)")]
        NS_E_TIGER_FAIL = 0xC00D0050,
        [Description("Unknown error (0xc00d0053)")]
        NS_E_CUB_FAIL = 0xC00D0053,
        [Description("Unknown error (0xc00d0055)")]
        NS_E_DISK_FAIL = 0xC00D0055,
        [Description("Unknown error (0xc00d0060)")]
        NS_E_MAX_FUNNELS_ALERT = 0xC00D0060,
        [Description("Unknown error (0xc00d0061)")]
        NS_E_ALLOCATE_FILE_FAIL = 0xC00D0061,
        [Description("Unknown error (0xc00d0062)")]
        NS_E_PAGING_ERROR = 0xC00D0062,
        [Description("Unknown error (0xc00d0063)")]
        NS_E_BAD_BLOCK0_VERSION = 0xC00D0063,
        [Description("Unknown error (0xc00d0064)")]
        NS_E_BAD_DISK_UID = 0xC00D0064,
        [Description("Unknown error (0xc00d0065)")]
        NS_E_BAD_FSMAJOR_VERSION = 0xC00D0065,
        [Description("Unknown error (0xc00d0066)")]
        NS_E_BAD_STAMPNUMBER = 0xC00D0066,
        [Description("Unknown error (0xc00d0067)")]
        NS_E_PARTIALLY_REBUILT_DISK = 0xC00D0067,
        [Description("Unknown error (0xc00d0068)")]
        NS_E_ENACTPLAN_GIVEUP = 0xC00D0068,
        [Description("Unknown error (0xc00d006a)")]
        MCMADM_E_REGKEY_NOT_FOUND = 0xC00D006A,
        [Description("Unknown error (0xc00d006b)")]
        NS_E_NO_FORMATS = 0xC00D006B,
        [Description("Unknown error (0xc00d006c)")]
        NS_E_NO_REFERENCES = 0xC00D006C,
        [Description("Unknown error (0xc00d006d)")]
        NS_E_WAVE_OPEN = 0xC00D006D,
        [Description("Unknown error (0xc00d006f)")]
        NS_E_CANNOTCONNECTEVENTS = 0xC00D006F,
        [Description("Unknown error (0xc00d0071)")]
        NS_E_NO_DEVICE = 0xC00D0071,
        [Description("Unknown error (0xc00d0072)")]
        NS_E_NO_SPECIFIED_DEVICE = 0xC00D0072,
        [Description("Unknown error (0xc00d00c8)")]
        NS_E_MONITOR_GIVEUP = 0xC00D00C8,
        [Description("Unknown error (0xc00d00c9)")]
        NS_E_REMIRRORED_DISK = 0xC00D00C9,
        [Description("Unknown error (0xc00d00ca)")]
        NS_E_INSUFFICIENT_DATA = 0xC00D00CA,
        [Description("Unknown error (0xc00d00cb)")]
        NS_E_ASSERT = 0xC00D00CB,
        [Description("Unknown error (0xc00d00cc)")]
        NS_E_BAD_ADAPTER_NAME = 0xC00D00CC,
        [Description("Unknown error (0xc00d00cd)")]
        NS_E_NOT_LICENSED = 0xC00D00CD,
        [Description("Unknown error (0xc00d00ce)")]
        NS_E_NO_SERVER_CONTACT = 0xC00D00CE,
        [Description("Unknown error (0xc00d00cf)")]
        NS_E_TOO_MANY_TITLES = 0xC00D00CF,
        [Description("Unknown error (0xc00d00d0)")]
        NS_E_TITLE_SIZE_EXCEEDED = 0xC00D00D0,
        [Description("Unknown error (0xc00d00d1)")]
        NS_E_UDP_DISABLED = 0xC00D00D1,
        [Description("Unknown error (0xc00d00d2)")]
        NS_E_TCP_DISABLED = 0xC00D00D2,
        [Description("Unknown error (0xc00d00d3)")]
        NS_E_HTTP_DISABLED = 0xC00D00D3,
        [Description("Unknown error (0xc00d00d4)")]
        NS_E_LICENSE_EXPIRED = 0xC00D00D4,
        [Description("Unknown error (0xc00d00d5)")]
        NS_E_TITLE_BITRATE = 0xC00D00D5,
        [Description("Unknown error (0xc00d00d6)")]
        NS_E_EMPTY_PROGRAM_NAME = 0xC00D00D6,
        [Description("Unknown error (0xc00d00d7)")]
        NS_E_MISSING_CHANNEL = 0xC00D00D7,
        [Description("Unknown error (0xc00d00d8)")]
        NS_E_NO_CHANNELS = 0xC00D00D8,
        [Description("Unknown error (0xc00d00d9)")]
        NS_E_INVALID_INDEX2 = 0xC00D00D9,
        [Description("Unknown error (0xc00d0190)")]
        NS_E_CUB_FAIL_LINK = 0xC00D0190,
        [Description("Unknown error (0xc00d0192)")]
        NS_E_BAD_CUB_UID = 0xC00D0192,
        [Description("Unknown error (0xc00d0195)")]
        NS_E_GLITCH_MODE = 0xC00D0195,
        [Description("Unknown error (0xc00d019b)")]
        NS_E_NO_MEDIA_PROTOCOL = 0xC00D019B,
        [Description("Unknown error (0xc00d07f1)")]
        NS_E_NOTHING_TO_DO = 0xC00D07F1,
        [Description("Unknown error (0xc00d07f2)")]
        NS_E_NO_MULTICAST = 0xC00D07F2,
        [Description("Unknown error (0xc00d0bb8)")]
        NS_E_INVALID_INPUT_FORMAT = 0xC00D0BB8,
        [Description("Unknown error (0xc00d0bb9)")]
        NS_E_MSAUDIO_NOT_INSTALLED = 0xC00D0BB9,
        [Description("Unknown error (0xc00d0bba)")]
        NS_E_UNEXPECTED_MSAUDIO_ERROR = 0xC00D0BBA,
        [Description("Unknown error (0xc00d0bbb)")]
        NS_E_INVALID_OUTPUT_FORMAT = 0xC00D0BBB,
        [Description("Unknown error (0xc00d0bbc)")]
        NS_E_NOT_CONFIGURED = 0xC00D0BBC,
        [Description("Unknown error (0xc00d0bbd)")]
        NS_E_PROTECTED_CONTENT = 0xC00D0BBD,
        [Description("Unknown error (0xc00d0bbe)")]
        NS_E_LICENSE_REQUIRED = 0xC00D0BBE,
        [Description("Unknown error (0xc00d0bbf)")]
        NS_E_TAMPERED_CONTENT = 0xC00D0BBF,
        [Description("Unknown error (0xc00d0bc0)")]
        NS_E_LICENSE_OUTOFDATE = 0xC00D0BC0,
        [Description("Unknown error (0xc00d0bc1)")]
        NS_E_LICENSE_INCORRECT_RIGHTS = 0xC00D0BC1,
        [Description("Unknown error (0xc00d0bc2)")]
        NS_E_AUDIO_CODEC_NOT_INSTALLED = 0xC00D0BC2,
        [Description("Unknown error (0xc00d0bc3)")]
        NS_E_AUDIO_CODEC_ERROR = 0xC00D0BC3,
        [Description("Unknown error (0xc00d0bc4)")]
        NS_E_VIDEO_CODEC_NOT_INSTALLED = 0xC00D0BC4,
        [Description("Unknown error (0xc00d0bc5)")]
        NS_E_VIDEO_CODEC_ERROR = 0xC00D0BC5,
        [Description("Unknown error (0xc00d0bc6)")]
        NS_E_INVALIDPROFILE = 0xC00D0BC6,
        [Description("Unknown error (0xc00d0bc7)")]
        NS_E_INCOMPATIBLE_VERSION = 0xC00D0BC7,
        [Description("Unknown error (0xc00d0bca)")]
        NS_E_OFFLINE_MODE = 0xC00D0BCA,
        [Description("Unknown error (0xc00d0bcb)")]
        NS_E_NOT_CONNECTED = 0xC00D0BCB,
        [Description("Unknown error (0xc00d0bcc)")]
        NS_E_TOO_MUCH_DATA = 0xC00D0BCC,
        [Description("Unknown error (0xc00d0bcd)")]
        NS_E_UNSUPPORTED_PROPERTY = 0xC00D0BCD,
        [Description("Unknown error (0xc00d0bce)")]
        NS_E_8BIT_WAVE_UNSUPPORTED = 0xC00D0BCE,
        [Description("Unknown error (0xc00d0bcf)")]
        NS_E_NO_MORE_SAMPLES = 0xC00D0BCF,
        [Description("Unknown error (0xc00d0bd0)")]
        NS_E_INVALID_SAMPLING_RATE = 0xC00D0BD0,
        [Description("Unknown error (0xc00d0bd1)")]
        NS_E_MAX_PACKET_SIZE_TOO_SMALL = 0xC00D0BD1,
        [Description("Unknown error (0xc00d0bd2)")]
        NS_E_LATE_PACKET = 0xC00D0BD2,
        [Description("Unknown error (0xc00d0bd3)")]
        NS_E_DUPLICATE_PACKET = 0xC00D0BD3,
        [Description("Unknown error (0xc00d0bd4)")]
        NS_E_SDK_BUFFERTOOSMALL = 0xC00D0BD4,
        [Description("Unknown error (0xc00d0bd5)")]
        NS_E_INVALID_NUM_PASSES = 0xC00D0BD5,
        [Description("Unknown error (0xc00d0bd6)")]
        NS_E_ATTRIBUTE_READ_ONLY = 0xC00D0BD6,
        [Description("Unknown error (0xc00d0bd7)")]
        NS_E_ATTRIBUTE_NOT_ALLOWED = 0xC00D0BD7,
        [Description("Unknown error (0xc00d0bd8)")]
        NS_E_INVALID_EDL = 0xC00D0BD8,
        [Description("Unknown error (0xc00d0bd9)")]
        NS_E_DATA_UNIT_EXTENSION_TOO_LARGE = 0xC00D0BD9,
        [Description("Unknown error (0xc00d0bda)")]
        NS_E_CODEC_DMO_ERROR = 0xC00D0BDA,
        [Description("Unknown error (0xc00d0bdc)")]
        NS_E_FEATURE_DISABLED_BY_GROUP_POLICY = 0xC00D0BDC,
        [Description("Unknown error (0xc00d0bdd)")]
        NS_E_FEATURE_DISABLED_IN_SKU = 0xC00D0BDD,
        [Description("Unknown error (0xc00d0fa0)")]
        NS_E_NO_CD = 0xC00D0FA0,
        [Description("Unknown error (0xc00d0fa1)")]
        NS_E_CANT_READ_DIGITAL = 0xC00D0FA1,
        [Description("Unknown error (0xc00d0fa2)")]
        NS_E_DEVICE_DISCONNECTED = 0xC00D0FA2,
        [Description("Unknown error (0xc00d0fa3)")]
        NS_E_DEVICE_NOT_SUPPORT_FORMAT = 0xC00D0FA3,
        [Description("Unknown error (0xc00d0fa4)")]
        NS_E_SLOW_READ_DIGITAL = 0xC00D0FA4,
        [Description("Unknown error (0xc00d0fa5)")]
        NS_E_MIXER_INVALID_LINE = 0xC00D0FA5,
        [Description("Unknown error (0xc00d0fa6)")]
        NS_E_MIXER_INVALID_CONTROL = 0xC00D0FA6,
        [Description("Unknown error (0xc00d0fa7)")]
        NS_E_MIXER_INVALID_VALUE = 0xC00D0FA7,
        [Description("Unknown error (0xc00d0fa8)")]
        NS_E_MIXER_UNKNOWN_MMRESULT = 0xC00D0FA8,
        [Description("Unknown error (0xc00d0fa9)")]
        NS_E_USER_STOP = 0xC00D0FA9,
        [Description("Unknown error (0xc00d0faa)")]
        NS_E_MP3_FORMAT_NOT_FOUND = 0xC00D0FAA,
        [Description("Unknown error (0xc00d0fab)")]
        NS_E_CD_READ_ERROR_NO_CORRECTION = 0xC00D0FAB,
        [Description("Unknown error (0xc00d0fac)")]
        NS_E_CD_READ_ERROR = 0xC00D0FAC,
        [Description("Unknown error (0xc00d0fad)")]
        NS_E_CD_SLOW_COPY = 0xC00D0FAD,
        [Description("Unknown error (0xc00d0fae)")]
        NS_E_CD_COPYTO_CD = 0xC00D0FAE,
        [Description("Unknown error (0xc00d0faf)")]
        NS_E_MIXER_NODRIVER = 0xC00D0FAF,
        [Description("Unknown error (0xc00d0fb0)")]
        NS_E_REDBOOK_ENABLED_WHILE_COPYING = 0xC00D0FB0,
        [Description("Unknown error (0xc00d0fb1)")]
        NS_E_CD_REFRESH = 0xC00D0FB1,
        [Description("Unknown error (0xc00d0fb2)")]
        NS_E_CD_DRIVER_PROBLEM = 0xC00D0FB2,
        [Description("Unknown error (0xc00d0fb3)")]
        NS_E_WONT_DO_DIGITAL = 0xC00D0FB3,
        [Description("Unknown error (0xc00d0fb4)")]
        NS_E_WMPXML_NOERROR = 0xC00D0FB4,
        [Description("Unknown error (0xc00d0fb5)")]
        NS_E_WMPXML_ENDOFDATA = 0xC00D0FB5,
        [Description("Unknown error (0xc00d0fb6)")]
        NS_E_WMPXML_PARSEERROR = 0xC00D0FB6,
        [Description("Unknown error (0xc00d0fb7)")]
        NS_E_WMPXML_ATTRIBUTENOTFOUND = 0xC00D0FB7,
        [Description("Unknown error (0xc00d0fb8)")]
        NS_E_WMPXML_PINOTFOUND = 0xC00D0FB8,
        [Description("Unknown error (0xc00d0fb9)")]
        NS_E_WMPXML_EMPTYDOC = 0xC00D0FB9,
        [Description("Unknown error (0xc00d0fba)")]
        NS_E_WMP_PATH_ALREADY_IN_LIBRARY = 0xC00D0FBA,
        [Description("Unknown error (0xc00d0fbe)")]
        NS_E_WMP_FILESCANALREADYSTARTED = 0xC00D0FBE,
        [Description("Unknown error (0xc00d0fbf)")]
        NS_E_WMP_HME_INVALIDOBJECTID = 0xC00D0FBF,
        [Description("Unknown error (0xc00d0fc0)")]
        NS_E_WMP_MF_CODE_EXPIRED = 0xC00D0FC0,
        [Description("Unknown error (0xc00d0fc1)")]
        NS_E_WMP_HME_NOTSEARCHABLEFORITEMS = 0xC00D0FC1,
        [Description("Unknown error (0xc00d0fc7)")]
        NS_E_WMP_ADDTOLIBRARY_FAILED = 0xC00D0FC7,
        [Description("Unknown error (0xc00d0fc8)")]
        NS_E_WMP_WINDOWSAPIFAILURE = 0xC00D0FC8,
        [Description("Unknown error (0xc00d0fc9)")]
        NS_E_WMP_RECORDING_NOT_ALLOWED = 0xC00D0FC9,
        [Description("Unknown error (0xc00d0fca)")]
        NS_E_DEVICE_NOT_READY = 0xC00D0FCA,
        [Description("Unknown error (0xc00d0fcb)")]
        NS_E_DAMAGED_FILE = 0xC00D0FCB,
        [Description("Unknown error (0xc00d0fcc)")]
        NS_E_MPDB_GENERIC = 0xC00D0FCC,
        [Description("Unknown error (0xc00d0fcd)")]
        NS_E_FILE_FAILED_CHECKS = 0xC00D0FCD,
        [Description("Unknown error (0xc00d0fce)")]
        NS_E_MEDIA_LIBRARY_FAILED = 0xC00D0FCE,
        [Description("Unknown error (0xc00d0fcf)")]
        NS_E_SHARING_VIOLATION = 0xC00D0FCF,
        [Description("Unknown error (0xc00d0fd0)")]
        NS_E_NO_ERROR_STRING_FOUND = 0xC00D0FD0,
        [Description("Unknown error (0xc00d0fd1)")]
        NS_E_WMPOCX_NO_REMOTE_CORE = 0xC00D0FD1,
        [Description("Unknown error (0xc00d0fd2)")]
        NS_E_WMPOCX_NO_ACTIVE_CORE = 0xC00D0FD2,
        [Description("Unknown error (0xc00d0fd3)")]
        NS_E_WMPOCX_NOT_RUNNING_REMOTELY = 0xC00D0FD3,
        [Description("Unknown error (0xc00d0fd4)")]
        NS_E_WMPOCX_NO_REMOTE_WINDOW = 0xC00D0FD4,
        [Description("Unknown error (0xc00d0fd5)")]
        NS_E_WMPOCX_ERRORMANAGERNOTAVAILABLE = 0xC00D0FD5,
        [Description("Unknown error (0xc00d0fd6)")]
        NS_E_PLUGIN_NOTSHUTDOWN = 0xC00D0FD6,
        [Description("Unknown error (0xc00d0fd7)")]
        NS_E_WMP_CANNOT_FIND_FOLDER = 0xC00D0FD7,
        [Description("Unknown error (0xc00d0fd8)")]
        NS_E_WMP_STREAMING_RECORDING_NOT_ALLOWED = 0xC00D0FD8,
        [Description("Unknown error (0xc00d0fd9)")]
        NS_E_WMP_PLUGINDLL_NOTFOUND = 0xC00D0FD9,
        [Description("Unknown error (0xc00d0fda)")]
        NS_E_NEED_TO_ASK_USER = 0xC00D0FDA,
        [Description("Unknown error (0xc00d0fdb)")]
        NS_E_WMPOCX_PLAYER_NOT_DOCKED = 0xC00D0FDB,
        [Description("Unknown error (0xc00d0fdc)")]
        NS_E_WMP_EXTERNAL_NOTREADY = 0xC00D0FDC,
        [Description("Unknown error (0xc00d0fdd)")]
        NS_E_WMP_MLS_STALE_DATA = 0xC00D0FDD,
        [Description("Unknown error (0xc00d0fde)")]
        NS_E_WMP_UI_SUBCONTROLSNOTSUPPORTED = 0xC00D0FDE,
        [Description("Unknown error (0xc00d0fdf)")]
        NS_E_WMP_UI_VERSIONMISMATCH = 0xC00D0FDF,
        [Description("Unknown error (0xc00d0fe0)")]
        NS_E_WMP_UI_NOTATHEMEFILE = 0xC00D0FE0,
        [Description("Unknown error (0xc00d0fe1)")]
        NS_E_WMP_UI_SUBELEMENTNOTFOUND = 0xC00D0FE1,
        [Description("Unknown error (0xc00d0fe2)")]
        NS_E_WMP_UI_VERSIONPARSE = 0xC00D0FE2,
        [Description("Unknown error (0xc00d0fe3)")]
        NS_E_WMP_UI_VIEWIDNOTFOUND = 0xC00D0FE3,
        [Description("Unknown error (0xc00d0fe4)")]
        NS_E_WMP_UI_PASSTHROUGH = 0xC00D0FE4,
        [Description("Unknown error (0xc00d0fe5)")]
        NS_E_WMP_UI_OBJECTNOTFOUND = 0xC00D0FE5,
        [Description("Unknown error (0xc00d0fe6)")]
        NS_E_WMP_UI_SECONDHANDLER = 0xC00D0FE6,
        [Description("Unknown error (0xc00d0fe7)")]
        NS_E_WMP_UI_NOSKININZIP = 0xC00D0FE7,
        [Description("Unknown error (0xc00d0fea)")]
        NS_E_WMP_URLDOWNLOADFAILED = 0xC00D0FEA,
        [Description("Unknown error (0xc00d0feb)")]
        NS_E_WMPOCX_UNABLE_TO_LOAD_SKIN = 0xC00D0FEB,
        [Description("Unknown error (0xc00d0fec)")]
        NS_E_WMP_INVALID_SKIN = 0xC00D0FEC,
        [Description("Unknown error (0xc00d0fed)")]
        NS_E_WMP_SENDMAILFAILED = 0xC00D0FED,
        [Description("Unknown error (0xc00d0fee)")]
        NS_E_WMP_LOCKEDINSKINMODE = 0xC00D0FEE,
        [Description("Unknown error (0xc00d0fef)")]
        NS_E_WMP_FAILED_TO_SAVE_FILE = 0xC00D0FEF,
        [Description("Unknown error (0xc00d0ff0)")]
        NS_E_WMP_SAVEAS_READONLY = 0xC00D0FF0,
        [Description("Unknown error (0xc00d0ff1)")]
        NS_E_WMP_FAILED_TO_SAVE_PLAYLIST = 0xC00D0FF1,
        [Description("Unknown error (0xc00d0ff2)")]
        NS_E_WMP_FAILED_TO_OPEN_WMD = 0xC00D0FF2,
        [Description("Unknown error (0xc00d0ff3)")]
        NS_E_WMP_CANT_PLAY_PROTECTED = 0xC00D0FF3,
        [Description("Unknown error (0xc00d0ff4)")]
        NS_E_SHARING_STATE_OUT_OF_SYNC = 0xC00D0FF4,
        [Description("Unknown error (0xc00d0ffa)")]
        NS_E_WMPOCX_REMOTE_PLAYER_ALREADY_RUNNING = 0xC00D0FFA,
        [Description("Unknown error (0xc00d1004)")]
        NS_E_WMP_RBC_JPGMAPPINGIMAGE = 0xC00D1004,
        [Description("Unknown error (0xc00d1005)")]
        NS_E_WMP_JPGTRANSPARENCY = 0xC00D1005,
        [Description("Unknown error (0xc00d1009)")]
        NS_E_WMP_INVALID_MAX_VAL = 0xC00D1009,
        [Description("Unknown error (0xc00d100a)")]
        NS_E_WMP_INVALID_MIN_VAL = 0xC00D100A,
        [Description("Unknown error (0xc00d100e)")]
        NS_E_WMP_CS_JPGPOSITIONIMAGE = 0xC00D100E,
        [Description("Unknown error (0xc00d100f)")]
        NS_E_WMP_CS_NOTEVENLYDIVISIBLE = 0xC00D100F,
        [Description("Unknown error (0xc00d1018)")]
        NS_E_WMPZIP_NOTAZIPFILE = 0xC00D1018,
        [Description("Unknown error (0xc00d1019)")]
        NS_E_WMPZIP_CORRUPT = 0xC00D1019,
        [Description("Unknown error (0xc00d101a)")]
        NS_E_WMPZIP_FILENOTFOUND = 0xC00D101A,
        [Description("Unknown error (0xc00d1022)")]
        NS_E_WMP_IMAGE_FILETYPE_UNSUPPORTED = 0xC00D1022,
        [Description("Unknown error (0xc00d1023)")]
        NS_E_WMP_IMAGE_INVALID_FORMAT = 0xC00D1023,
        [Description("Unknown error (0xc00d1024)")]
        NS_E_WMP_GIF_UNEXPECTED_ENDOFFILE = 0xC00D1024,
        [Description("Unknown error (0xc00d1025)")]
        NS_E_WMP_GIF_INVALID_FORMAT = 0xC00D1025,
        [Description("Unknown error (0xc00d1026)")]
        NS_E_WMP_GIF_BAD_VERSION_NUMBER = 0xC00D1026,
        [Description("Unknown error (0xc00d1027)")]
        NS_E_WMP_GIF_NO_IMAGE_IN_FILE = 0xC00D1027,
        [Description("Unknown error (0xc00d1028)")]
        NS_E_WMP_PNG_INVALIDFORMAT = 0xC00D1028,
        [Description("Unknown error (0xc00d1029)")]
        NS_E_WMP_PNG_UNSUPPORTED_BITDEPTH = 0xC00D1029,
        [Description("Unknown error (0xc00d102a)")]
        NS_E_WMP_PNG_UNSUPPORTED_COMPRESSION = 0xC00D102A,
        [Description("Unknown error (0xc00d102b)")]
        NS_E_WMP_PNG_UNSUPPORTED_FILTER = 0xC00D102B,
        [Description("Unknown error (0xc00d102c)")]
        NS_E_WMP_PNG_UNSUPPORTED_INTERLACE = 0xC00D102C,
        [Description("Unknown error (0xc00d102d)")]
        NS_E_WMP_PNG_UNSUPPORTED_BAD_CRC = 0xC00D102D,
        [Description("Unknown error (0xc00d102e)")]
        NS_E_WMP_BMP_INVALID_BITMASK = 0xC00D102E,
        [Description("Unknown error (0xc00d102f)")]
        NS_E_WMP_BMP_TOPDOWN_DIB_UNSUPPORTED = 0xC00D102F,
        [Description("Unknown error (0xc00d1030)")]
        NS_E_WMP_BMP_BITMAP_NOT_CREATED = 0xC00D1030,
        [Description("Unknown error (0xc00d1031)")]
        NS_E_WMP_BMP_COMPRESSION_UNSUPPORTED = 0xC00D1031,
        [Description("Unknown error (0xc00d1032)")]
        NS_E_WMP_BMP_INVALID_FORMAT = 0xC00D1032,
        [Description("Unknown error (0xc00d1033)")]
        NS_E_WMP_JPG_JERR_ARITHCODING_NOTIMPL = 0xC00D1033,
        [Description("Unknown error (0xc00d1034)")]
        NS_E_WMP_JPG_INVALID_FORMAT = 0xC00D1034,
        [Description("Unknown error (0xc00d1035)")]
        NS_E_WMP_JPG_BAD_DCTSIZE = 0xC00D1035,
        [Description("Unknown error (0xc00d1036)")]
        NS_E_WMP_JPG_BAD_VERSION_NUMBER = 0xC00D1036,
        [Description("Unknown error (0xc00d1037)")]
        NS_E_WMP_JPG_BAD_PRECISION = 0xC00D1037,
        [Description("Unknown error (0xc00d1038)")]
        NS_E_WMP_JPG_CCIR601_NOTIMPL = 0xC00D1038,
        [Description("Unknown error (0xc00d1039)")]
        NS_E_WMP_JPG_NO_IMAGE_IN_FILE = 0xC00D1039,
        [Description("Unknown error (0xc00d103a)")]
        NS_E_WMP_JPG_READ_ERROR = 0xC00D103A,
        [Description("Unknown error (0xc00d103b)")]
        NS_E_WMP_JPG_FRACT_SAMPLE_NOTIMPL = 0xC00D103B,
        [Description("Unknown error (0xc00d103c)")]
        NS_E_WMP_JPG_IMAGE_TOO_BIG = 0xC00D103C,
        [Description("Unknown error (0xc00d103d)")]
        NS_E_WMP_JPG_UNEXPECTED_ENDOFFILE = 0xC00D103D,
        [Description("Unknown error (0xc00d103e)")]
        NS_E_WMP_JPG_SOF_UNSUPPORTED = 0xC00D103E,
        [Description("Unknown error (0xc00d103f)")]
        NS_E_WMP_JPG_UNKNOWN_MARKER = 0xC00D103F,
        [Description("Unknown error (0xc00d1044)")]
        NS_E_WMP_FAILED_TO_OPEN_IMAGE = 0xC00D1044,
        [Description("Unknown error (0xc00d1049)")]
        NS_E_WMP_DAI_SONGTOOSHORT = 0xC00D1049,
        [Description("Unknown error (0xc00d104a)")]
        NS_E_WMG_RATEUNAVAILABLE = 0xC00D104A,
        [Description("Unknown error (0xc00d104b)")]
        NS_E_WMG_PLUGINUNAVAILABLE = 0xC00D104B,
        [Description("Unknown error (0xc00d104c)")]
        NS_E_WMG_CANNOTQUEUE = 0xC00D104C,
        [Description("Unknown error (0xc00d104d)")]
        NS_E_WMG_PREROLLLICENSEACQUISITIONNOTALLOWED = 0xC00D104D,
        [Description("Unknown error (0xc00d104e)")]
        NS_E_WMG_UNEXPECTEDPREROLLSTATUS = 0xC00D104E,
        [Description("Unknown error (0xc00d1051)")]
        NS_E_WMG_INVALID_COPP_CERTIFICATE = 0xC00D1051,
        [Description("Unknown error (0xc00d1052)")]
        NS_E_WMG_COPP_SECURITY_INVALID = 0xC00D1052,
        [Description("Unknown error (0xc00d1053)")]
        NS_E_WMG_COPP_UNSUPPORTED = 0xC00D1053,
        [Description("Unknown error (0xc00d1054)")]
        NS_E_WMG_INVALIDSTATE = 0xC00D1054,
        [Description("Unknown error (0xc00d1055)")]
        NS_E_WMG_SINKALREADYEXISTS = 0xC00D1055,
        [Description("Unknown error (0xc00d1056)")]
        NS_E_WMG_NOSDKINTERFACE = 0xC00D1056,
        [Description("Unknown error (0xc00d1057)")]
        NS_E_WMG_NOTALLOUTPUTSRENDERED = 0xC00D1057,
        [Description("Unknown error (0xc00d1058)")]
        NS_E_WMG_FILETRANSFERNOTALLOWED = 0xC00D1058,
        [Description("Unknown error (0xc00d1059)")]
        NS_E_WMR_UNSUPPORTEDSTREAM = 0xC00D1059,
        [Description("Unknown error (0xc00d105a)")]
        NS_E_WMR_PINNOTFOUND = 0xC00D105A,
        [Description("Unknown error (0xc00d105b)")]
        NS_E_WMR_WAITINGONFORMATSWITCH = 0xC00D105B,
        [Description("Unknown error (0xc00d105c)")]
        NS_E_WMR_NOSOURCEFILTER = 0xC00D105C,
        [Description("Unknown error (0xc00d105d)")]
        NS_E_WMR_PINTYPENOMATCH = 0xC00D105D,
        [Description("Unknown error (0xc00d105e)")]
        NS_E_WMR_NOCALLBACKAVAILABLE = 0xC00D105E,
        [Description("Unknown error (0xc00d1062)")]
        NS_E_WMR_SAMPLEPROPERTYNOTSET = 0xC00D1062,
        [Description("Unknown error (0xc00d1063)")]
        NS_E_WMR_CANNOT_RENDER_BINARY_STREAM = 0xC00D1063,
        [Description("Unknown error (0xc00d1064)")]
        NS_E_WMG_LICENSE_TAMPERED = 0xC00D1064,
        [Description("Unknown error (0xc00d1065)")]
        NS_E_WMR_WILLNOT_RENDER_BINARY_STREAM = 0xC00D1065,
        [Description("Unknown error (0xc00d1068)")]
        NS_E_WMX_UNRECOGNIZED_PLAYLIST_FORMAT = 0xC00D1068,
        [Description("Unknown error (0xc00d1069)")]
        NS_E_ASX_INVALIDFORMAT = 0xC00D1069,
        [Description("Unknown error (0xc00d106a)")]
        NS_E_ASX_INVALIDVERSION = 0xC00D106A,
        [Description("Unknown error (0xc00d106b)")]
        NS_E_ASX_INVALID_REPEAT_BLOCK = 0xC00D106B,
        [Description("Unknown error (0xc00d106c)")]
        NS_E_ASX_NOTHING_TO_WRITE = 0xC00D106C,
        [Description("Unknown error (0xc00d106d)")]
        NS_E_URLLIST_INVALIDFORMAT = 0xC00D106D,
        [Description("Unknown error (0xc00d106e)")]
        NS_E_WMX_ATTRIBUTE_DOES_NOT_EXIST = 0xC00D106E,
        [Description("Unknown error (0xc00d106f)")]
        NS_E_WMX_ATTRIBUTE_ALREADY_EXISTS = 0xC00D106F,
        [Description("Unknown error (0xc00d1070)")]
        NS_E_WMX_ATTRIBUTE_UNRETRIEVABLE = 0xC00D1070,
        [Description("Unknown error (0xc00d1071)")]
        NS_E_WMX_ITEM_DOES_NOT_EXIST = 0xC00D1071,
        [Description("Unknown error (0xc00d1072)")]
        NS_E_WMX_ITEM_TYPE_ILLEGAL = 0xC00D1072,
        [Description("Unknown error (0xc00d1073)")]
        NS_E_WMX_ITEM_UNSETTABLE = 0xC00D1073,
        [Description("Unknown error (0xc00d1074)")]
        NS_E_WMX_PLAYLIST_EMPTY = 0xC00D1074,
        [Description("Unknown error (0xc00d1075)")]
        NS_E_MLS_SMARTPLAYLIST_FILTER_NOT_REGISTERED = 0xC00D1075,
        [Description("Unknown error (0xc00d1076)")]
        NS_E_WMX_INVALID_FORMAT_OVER_NESTING = 0xC00D1076,
        [Description("Unknown error (0xc00d107c)")]
        NS_E_WMPCORE_NOSOURCEURLSTRING = 0xC00D107C,
        [Description("Unknown error (0xc00d107d)")]
        NS_E_WMPCORE_COCREATEFAILEDFORGITOBJECT = 0xC00D107D,
        [Description("Unknown error (0xc00d107e)")]
        NS_E_WMPCORE_FAILEDTOGETMARSHALLEDEVENTHANDLERINTERFACE = 0xC00D107E,
        [Description("Unknown error (0xc00d107f)")]
        NS_E_WMPCORE_BUFFERTOOSMALL = 0xC00D107F,
        [Description("Unknown error (0xc00d1080)")]
        NS_E_WMPCORE_UNAVAILABLE = 0xC00D1080,
        [Description("Unknown error (0xc00d1081)")]
        NS_E_WMPCORE_INVALIDPLAYLISTMODE = 0xC00D1081,
        [Description("Unknown error (0xc00d1086)")]
        NS_E_WMPCORE_ITEMNOTINPLAYLIST = 0xC00D1086,
        [Description("Unknown error (0xc00d1087)")]
        NS_E_WMPCORE_PLAYLISTEMPTY = 0xC00D1087,
        [Description("Unknown error (0xc00d1088)")]
        NS_E_WMPCORE_NOBROWSER = 0xC00D1088,
        [Description("Unknown error (0xc00d1089)")]
        NS_E_WMPCORE_UNRECOGNIZED_MEDIA_URL = 0xC00D1089,
        [Description("Unknown error (0xc00d108a)")]
        NS_E_WMPCORE_GRAPH_NOT_IN_LIST = 0xC00D108A,
        [Description("Unknown error (0xc00d108b)")]
        NS_E_WMPCORE_PLAYLIST_EMPTY_OR_SINGLE_MEDIA = 0xC00D108B,
        [Description("Unknown error (0xc00d108c)")]
        NS_E_WMPCORE_ERRORSINKNOTREGISTERED = 0xC00D108C,
        [Description("Unknown error (0xc00d108d)")]
        NS_E_WMPCORE_ERRORMANAGERNOTAVAILABLE = 0xC00D108D,
        [Description("Unknown error (0xc00d108e)")]
        NS_E_WMPCORE_WEBHELPFAILED = 0xC00D108E,
        [Description("Unknown error (0xc00d108f)")]
        NS_E_WMPCORE_MEDIA_ERROR_RESUME_FAILED = 0xC00D108F,
        [Description("Unknown error (0xc00d1090)")]
        NS_E_WMPCORE_NO_REF_IN_ENTRY = 0xC00D1090,
        [Description("Unknown error (0xc00d1091)")]
        NS_E_WMPCORE_WMX_LIST_ATTRIBUTE_NAME_EMPTY = 0xC00D1091,
        [Description("Unknown error (0xc00d1092)")]
        NS_E_WMPCORE_WMX_LIST_ATTRIBUTE_NAME_ILLEGAL = 0xC00D1092,
        [Description("Unknown error (0xc00d1093)")]
        NS_E_WMPCORE_WMX_LIST_ATTRIBUTE_VALUE_EMPTY = 0xC00D1093,
        [Description("Unknown error (0xc00d1094)")]
        NS_E_WMPCORE_WMX_LIST_ATTRIBUTE_VALUE_ILLEGAL = 0xC00D1094,
        [Description("Unknown error (0xc00d1095)")]
        NS_E_WMPCORE_WMX_LIST_ITEM_ATTRIBUTE_NAME_EMPTY = 0xC00D1095,
        [Description("Unknown error (0xc00d1096)")]
        NS_E_WMPCORE_WMX_LIST_ITEM_ATTRIBUTE_NAME_ILLEGAL = 0xC00D1096,
        [Description("Unknown error (0xc00d1097)")]
        NS_E_WMPCORE_WMX_LIST_ITEM_ATTRIBUTE_VALUE_EMPTY = 0xC00D1097,
        [Description("Unknown error (0xc00d1098)")]
        NS_E_WMPCORE_LIST_ENTRY_NO_REF = 0xC00D1098,
        [Description("Unknown error (0xc00d1099)")]
        NS_E_WMPCORE_MISNAMED_FILE = 0xC00D1099,
        [Description("Unknown error (0xc00d109a)")]
        NS_E_WMPCORE_CODEC_NOT_TRUSTED = 0xC00D109A,
        [Description("Unknown error (0xc00d109b)")]
        NS_E_WMPCORE_CODEC_NOT_FOUND = 0xC00D109B,
        [Description("Unknown error (0xc00d109c)")]
        NS_E_WMPCORE_CODEC_DOWNLOAD_NOT_ALLOWED = 0xC00D109C,
        [Description("Unknown error (0xc00d109d)")]
        NS_E_WMPCORE_ERROR_DOWNLOADING_PLAYLIST = 0xC00D109D,
        [Description("Unknown error (0xc00d109e)")]
        NS_E_WMPCORE_FAILED_TO_BUILD_PLAYLIST = 0xC00D109E,
        [Description("Unknown error (0xc00d109f)")]
        NS_E_WMPCORE_PLAYLIST_ITEM_ALTERNATE_NONE = 0xC00D109F,
        [Description("Unknown error (0xc00d10a0)")]
        NS_E_WMPCORE_PLAYLIST_ITEM_ALTERNATE_EXHAUSTED = 0xC00D10A0,
        [Description("Unknown error (0xc00d10a1)")]
        NS_E_WMPCORE_PLAYLIST_ITEM_ALTERNATE_NAME_NOT_FOUND = 0xC00D10A1,
        [Description("Unknown error (0xc00d10a2)")]
        NS_E_WMPCORE_PLAYLIST_ITEM_ALTERNATE_MORPH_FAILED = 0xC00D10A2,
        [Description("Unknown error (0xc00d10a3)")]
        NS_E_WMPCORE_PLAYLIST_ITEM_ALTERNATE_INIT_FAILED = 0xC00D10A3,
        [Description("Unknown error (0xc00d10a4)")]
        NS_E_WMPCORE_MEDIA_ALTERNATE_REF_EMPTY = 0xC00D10A4,
        [Description("Unknown error (0xc00d10a5)")]
        NS_E_WMPCORE_PLAYLIST_NO_EVENT_NAME = 0xC00D10A5,
        [Description("Unknown error (0xc00d10a6)")]
        NS_E_WMPCORE_PLAYLIST_EVENT_ATTRIBUTE_ABSENT = 0xC00D10A6,
        [Description("Unknown error (0xc00d10a7)")]
        NS_E_WMPCORE_PLAYLIST_EVENT_EMPTY = 0xC00D10A7,
        [Description("Unknown error (0xc00d10a8)")]
        NS_E_WMPCORE_PLAYLIST_STACK_EMPTY = 0xC00D10A8,
        [Description("Unknown error (0xc00d10a9)")]
        NS_E_WMPCORE_CURRENT_MEDIA_NOT_ACTIVE = 0xC00D10A9,
        [Description("Unknown error (0xc00d10ab)")]
        NS_E_WMPCORE_USER_CANCEL = 0xC00D10AB,
        [Description("Unknown error (0xc00d10ac)")]
        NS_E_WMPCORE_PLAYLIST_REPEAT_EMPTY = 0xC00D10AC,
        [Description("Unknown error (0xc00d10ad)")]
        NS_E_WMPCORE_PLAYLIST_REPEAT_START_MEDIA_NONE = 0xC00D10AD,
        [Description("Unknown error (0xc00d10ae)")]
        NS_E_WMPCORE_PLAYLIST_REPEAT_END_MEDIA_NONE = 0xC00D10AE,
        [Description("Unknown error (0xc00d10af)")]
        NS_E_WMPCORE_INVALID_PLAYLIST_URL = 0xC00D10AF,
        [Description("Unknown error (0xc00d10b0)")]
        NS_E_WMPCORE_MISMATCHED_RUNTIME = 0xC00D10B0,
        [Description("Unknown error (0xc00d10b1)")]
        NS_E_WMPCORE_PLAYLIST_IMPORT_FAILED_NO_ITEMS = 0xC00D10B1,
        [Description("Unknown error (0xc00d10b2)")]
        NS_E_WMPCORE_VIDEO_TRANSFORM_FILTER_INSERTION = 0xC00D10B2,
        [Description("Unknown error (0xc00d10b3)")]
        NS_E_WMPCORE_MEDIA_UNAVAILABLE = 0xC00D10B3,
        [Description("Unknown error (0xc00d10b4)")]
        NS_E_WMPCORE_WMX_ENTRYREF_NO_REF = 0xC00D10B4,
        [Description("Unknown error (0xc00d10b5)")]
        NS_E_WMPCORE_NO_PLAYABLE_MEDIA_IN_PLAYLIST = 0xC00D10B5,
        [Description("Unknown error (0xc00d10b6)")]
        NS_E_WMPCORE_PLAYLIST_EMPTY_NESTED_PLAYLIST_SKIPPED_ITEMS = 0xC00D10B6,
        [Description("Unknown error (0xc00d10b7)")]
        NS_E_WMPCORE_BUSY = 0xC00D10B7,
        [Description("Unknown error (0xc00d10b8)")]
        NS_E_WMPCORE_MEDIA_CHILD_PLAYLIST_UNAVAILABLE = 0xC00D10B8,
        [Description("Unknown error (0xc00d10b9)")]
        NS_E_WMPCORE_MEDIA_NO_CHILD_PLAYLIST = 0xC00D10B9,
        [Description("Unknown error (0xc00d10ba)")]
        NS_E_WMPCORE_FILE_NOT_FOUND = 0xC00D10BA,
        [Description("Unknown error (0xc00d10bb)")]
        NS_E_WMPCORE_TEMP_FILE_NOT_FOUND = 0xC00D10BB,
        [Description("Unknown error (0xc00d10bc)")]
        NS_E_WMDM_REVOKED = 0xC00D10BC,
        [Description("Unknown error (0xc00d10bd)")]
        NS_E_DDRAW_GENERIC = 0xC00D10BD,
        [Description("Unknown error (0xc00d10be)")]
        NS_E_DISPLAY_MODE_CHANGE_FAILED = 0xC00D10BE,
        [Description("Unknown error (0xc00d10bf)")]
        NS_E_PLAYLIST_CONTAINS_ERRORS = 0xC00D10BF,
        [Description("Unknown error (0xc00d10c0)")]
        NS_E_CHANGING_PROXY_NAME = 0xC00D10C0,
        [Description("Unknown error (0xc00d10c1)")]
        NS_E_CHANGING_PROXY_PORT = 0xC00D10C1,
        [Description("Unknown error (0xc00d10c2)")]
        NS_E_CHANGING_PROXY_EXCEPTIONLIST = 0xC00D10C2,
        [Description("Unknown error (0xc00d10c3)")]
        NS_E_CHANGING_PROXYBYPASS = 0xC00D10C3,
        [Description("Unknown error (0xc00d10c4)")]
        NS_E_CHANGING_PROXY_PROTOCOL_NOT_FOUND = 0xC00D10C4,
        [Description("Unknown error (0xc00d10c5)")]
        NS_E_GRAPH_NOAUDIOLANGUAGE = 0xC00D10C5,
        [Description("Unknown error (0xc00d10c6)")]
        NS_E_GRAPH_NOAUDIOLANGUAGESELECTED = 0xC00D10C6,
        [Description("Unknown error (0xc00d10c7)")]
        NS_E_CORECD_NOTAMEDIACD = 0xC00D10C7,
        [Description("Unknown error (0xc00d10c8)")]
        NS_E_WMPCORE_MEDIA_URL_TOO_LONG = 0xC00D10C8,
        [Description("Unknown error (0xc00d10c9)")]
        NS_E_WMPFLASH_CANT_FIND_COM_SERVER = 0xC00D10C9,
        [Description("Unknown error (0xc00d10ca)")]
        NS_E_WMPFLASH_INCOMPATIBLEVERSION = 0xC00D10CA,
        [Description("Unknown error (0xc00d10cb)")]
        NS_E_WMPOCXGRAPH_IE_DISALLOWS_ACTIVEX_CONTROLS = 0xC00D10CB,
        [Description("Unknown error (0xc00d10cc)")]
        NS_E_NEED_CORE_REFERENCE = 0xC00D10CC,
        [Description("Unknown error (0xc00d10cd)")]
        NS_E_MEDIACD_READ_ERROR = 0xC00D10CD,
        [Description("Unknown error (0xc00d10ce)")]
        NS_E_IE_DISALLOWS_ACTIVEX_CONTROLS = 0xC00D10CE,
        [Description("Unknown error (0xc00d10cf)")]
        NS_E_FLASH_PLAYBACK_NOT_ALLOWED = 0xC00D10CF,
        [Description("Unknown error (0xc00d10d0)")]
        NS_E_UNABLE_TO_CREATE_RIP_LOCATION = 0xC00D10D0,
        [Description("Unknown error (0xc00d10d1)")]
        NS_E_WMPCORE_SOME_CODECS_MISSING = 0xC00D10D1,
        [Description("Unknown error (0xc00d10d2)")]
        NS_E_WMP_RIP_FAILED = 0xC00D10D2,
        [Description("Unknown error (0xc00d10d3)")]
        NS_E_WMP_FAILED_TO_RIP_TRACK = 0xC00D10D3,
        [Description("Unknown error (0xc00d10d4)")]
        NS_E_WMP_ERASE_FAILED = 0xC00D10D4,
        [Description("Unknown error (0xc00d10d5)")]
        NS_E_WMP_FORMAT_FAILED = 0xC00D10D5,
        [Description("Unknown error (0xc00d10d6)")]
        NS_E_WMP_CANNOT_BURN_NON_LOCAL_FILE = 0xC00D10D6,
        [Description("Unknown error (0xc00d10d7)")]
        NS_E_WMP_FILE_TYPE_CANNOT_BURN_TO_AUDIO_CD = 0xC00D10D7,
        [Description("Unknown error (0xc00d10d8)")]
        NS_E_WMP_FILE_DOES_NOT_FIT_ON_CD = 0xC00D10D8,
        [Description("Unknown error (0xc00d10d9)")]
        NS_E_WMP_FILE_NO_DURATION = 0xC00D10D9,
        [Description("Unknown error (0xc00d10da)")]
        NS_E_PDA_FAILED_TO_BURN = 0xC00D10DA,
        [Description("Unknown error (0xc00d10dc)")]
        NS_E_FAILED_DOWNLOAD_ABORT_BURN = 0xC00D10DC,
        [Description("Unknown error (0xc00d10dd)")]
        NS_E_WMPCORE_DEVICE_DRIVERS_MISSING = 0xC00D10DD,
        [Description("Unknown error (0xc00d1126)")]
        NS_E_WMPIM_USEROFFLINE = 0xC00D1126,
        [Description("Unknown error (0xc00d1127)")]
        NS_E_WMPIM_USERCANCELED = 0xC00D1127,
        [Description("Unknown error (0xc00d1128)")]
        NS_E_WMPIM_DIALUPFAILED = 0xC00D1128,
        [Description("Unknown error (0xc00d1129)")]
        NS_E_WINSOCK_ERROR_STRING = 0xC00D1129,
        [Description("Unknown error (0xc00d1130)")]
        NS_E_WMPBR_NOLISTENER = 0xC00D1130,
        [Description("Unknown error (0xc00d1131)")]
        NS_E_WMPBR_BACKUPCANCEL = 0xC00D1131,
        [Description("Unknown error (0xc00d1132)")]
        NS_E_WMPBR_RESTORECANCEL = 0xC00D1132,
        [Description("Unknown error (0xc00d1133)")]
        NS_E_WMPBR_ERRORWITHURL = 0xC00D1133,
        [Description("Unknown error (0xc00d1134)")]
        NS_E_WMPBR_NAMECOLLISION = 0xC00D1134,
        [Description("Unknown error (0xc00d1137)")]
        NS_E_WMPBR_DRIVE_INVALID = 0xC00D1137,
        [Description("Unknown error (0xc00d1138)")]
        NS_E_WMPBR_BACKUPRESTOREFAILED = 0xC00D1138,
        [Description("Unknown error (0xc00d1158)")]
        NS_E_WMP_CONVERT_FILE_FAILED = 0xC00D1158,
        [Description("Unknown error (0xc00d1159)")]
        NS_E_WMP_CONVERT_NO_RIGHTS_ERRORURL = 0xC00D1159,
        [Description("Unknown error (0xc00d115a)")]
        NS_E_WMP_CONVERT_NO_RIGHTS_NOERRORURL = 0xC00D115A,
        [Description("Unknown error (0xc00d115b)")]
        NS_E_WMP_CONVERT_FILE_CORRUPT = 0xC00D115B,
        [Description("Unknown error (0xc00d115c)")]
        NS_E_WMP_CONVERT_PLUGIN_UNAVAILABLE_ERRORURL = 0xC00D115C,
        [Description("Unknown error (0xc00d115d)")]
        NS_E_WMP_CONVERT_PLUGIN_UNAVAILABLE_NOERRORURL = 0xC00D115D,
        [Description("Unknown error (0xc00d115e)")]
        NS_E_WMP_CONVERT_PLUGIN_UNKNOWN_FILE_OWNER = 0xC00D115E,
        [Description("Unknown error (0xc00d1160)")]
        NS_E_DVD_DISC_COPY_PROTECT_OUTPUT_NS = 0xC00D1160,
        [Description("Unknown error (0xc00d1161)")]
        NS_E_DVD_DISC_COPY_PROTECT_OUTPUT_FAILED = 0xC00D1161,
        [Description("Unknown error (0xc00d1162)")]
        NS_E_DVD_NO_SUBPICTURE_STREAM = 0xC00D1162,
        [Description("Unknown error (0xc00d1163)")]
        NS_E_DVD_COPY_PROTECT = 0xC00D1163,
        [Description("Unknown error (0xc00d1164)")]
        NS_E_DVD_AUTHORING_PROBLEM = 0xC00D1164,
        [Description("Unknown error (0xc00d1165)")]
        NS_E_DVD_INVALID_DISC_REGION = 0xC00D1165,
        [Description("Unknown error (0xc00d1166)")]
        NS_E_DVD_COMPATIBLE_VIDEO_CARD = 0xC00D1166,
        [Description("Unknown error (0xc00d1167)")]
        NS_E_DVD_MACROVISION = 0xC00D1167,
        [Description("Unknown error (0xc00d1168)")]
        NS_E_DVD_SYSTEM_DECODER_REGION = 0xC00D1168,
        [Description("Unknown error (0xc00d1169)")]
        NS_E_DVD_DISC_DECODER_REGION = 0xC00D1169,
        [Description("Unknown error (0xc00d116a)")]
        NS_E_DVD_NO_VIDEO_STREAM = 0xC00D116A,
        [Description("Unknown error (0xc00d116b)")]
        NS_E_DVD_NO_AUDIO_STREAM = 0xC00D116B,
        [Description("Unknown error (0xc00d116c)")]
        NS_E_DVD_GRAPH_BUILDING = 0xC00D116C,
        [Description("Unknown error (0xc00d116d)")]
        NS_E_DVD_NO_DECODER = 0xC00D116D,
        [Description("Unknown error (0xc00d116e)")]
        NS_E_DVD_PARENTAL = 0xC00D116E,
        [Description("Unknown error (0xc00d116f)")]
        NS_E_DVD_CANNOT_JUMP = 0xC00D116F,
        [Description("Unknown error (0xc00d1170)")]
        NS_E_DVD_DEVICE_CONTENTION = 0xC00D1170,
        [Description("Unknown error (0xc00d1171)")]
        NS_E_DVD_NO_VIDEO_MEMORY = 0xC00D1171,
        [Description("Unknown error (0xc00d1172)")]
        NS_E_DVD_CANNOT_COPY_PROTECTED = 0xC00D1172,
        [Description("Unknown error (0xc00d1173)")]
        NS_E_DVD_REQUIRED_PROPERTY_NOT_SET = 0xC00D1173,
        [Description("Unknown error (0xc00d1174)")]
        NS_E_DVD_INVALID_TITLE_CHAPTER = 0xC00D1174,
        [Description("Unknown error (0xc00d1176)")]
        NS_E_NO_CD_BURNER = 0xC00D1176,
        [Description("Unknown error (0xc00d1177)")]
        NS_E_DEVICE_IS_NOT_READY = 0xC00D1177,
        [Description("Unknown error (0xc00d1178)")]
        NS_E_PDA_UNSUPPORTED_FORMAT = 0xC00D1178,
        [Description("Unknown error (0xc00d1179)")]
        NS_E_NO_PDA = 0xC00D1179,
        [Description("Unknown error (0xc00d117a)")]
        NS_E_PDA_UNSPECIFIED_ERROR = 0xC00D117A,
        [Description("Unknown error (0xc00d117b)")]
        NS_E_MEMSTORAGE_BAD_DATA = 0xC00D117B,
        [Description("Unknown error (0xc00d117c)")]
        NS_E_PDA_FAIL_SELECT_DEVICE = 0xC00D117C,
        [Description("Unknown error (0xc00d117d)")]
        NS_E_PDA_FAIL_READ_WAVE_FILE = 0xC00D117D,
        [Description("Unknown error (0xc00d117e)")]
        NS_E_IMAPI_LOSSOFSTREAMING = 0xC00D117E,
        [Description("Unknown error (0xc00d117f)")]
        NS_E_PDA_DEVICE_FULL = 0xC00D117F,
        [Description("Unknown error (0xc00d1180)")]
        NS_E_FAIL_LAUNCH_ROXIO_PLUGIN = 0xC00D1180,
        [Description("Unknown error (0xc00d1181)")]
        NS_E_PDA_DEVICE_FULL_IN_SESSION = 0xC00D1181,
        [Description("Unknown error (0xc00d1182)")]
        NS_E_IMAPI_MEDIUM_INVALIDTYPE = 0xC00D1182,
        [Description("Unknown error (0xc00d1183)")]
        NS_E_PDA_MANUALDEVICE = 0xC00D1183,
        [Description("Unknown error (0xc00d1184)")]
        NS_E_PDA_PARTNERSHIPNOTEXIST = 0xC00D1184,
        [Description("Unknown error (0xc00d1185)")]
        NS_E_PDA_CANNOT_CREATE_ADDITIONAL_SYNC_RELATIONSHIP = 0xC00D1185,
        [Description("Unknown error (0xc00d1186)")]
        NS_E_PDA_NO_TRANSCODE_OF_DRM = 0xC00D1186,
        [Description("Unknown error (0xc00d1187)")]
        NS_E_PDA_TRANSCODECACHEFULL = 0xC00D1187,
        [Description("Unknown error (0xc00d1188)")]
        NS_E_PDA_TOO_MANY_FILE_COLLISIONS = 0xC00D1188,
        [Description("Unknown error (0xc00d1189)")]
        NS_E_PDA_CANNOT_TRANSCODE = 0xC00D1189,
        [Description("Unknown error (0xc00d118a)")]
        NS_E_PDA_TOO_MANY_FILES_IN_DIRECTORY = 0xC00D118A,
        [Description("Unknown error (0xc00d118b)")]
        NS_E_PROCESSINGSHOWSYNCWIZARD = 0xC00D118B,
        [Description("Unknown error (0xc00d118c)")]
        NS_E_PDA_TRANSCODE_NOT_PERMITTED = 0xC00D118C,
        [Description("Unknown error (0xc00d118d)")]
        NS_E_PDA_INITIALIZINGDEVICES = 0xC00D118D,
        [Description("Unknown error (0xc00d118e)")]
        NS_E_PDA_OBSOLETE_SP = 0xC00D118E,
        [Description("Unknown error (0xc00d118f)")]
        NS_E_PDA_TITLE_COLLISION = 0xC00D118F,
        [Description("Unknown error (0xc00d1190)")]
        NS_E_PDA_DEVICESUPPORTDISABLED = 0xC00D1190,
        [Description("Unknown error (0xc00d1191)")]
        NS_E_PDA_NO_LONGER_AVAILABLE = 0xC00D1191,
        [Description("Unknown error (0xc00d1192)")]
        NS_E_PDA_ENCODER_NOT_RESPONDING = 0xC00D1192,
        [Description("Unknown error (0xc00d1193)")]
        NS_E_PDA_CANNOT_SYNC_FROM_LOCATION = 0xC00D1193,
        [Description("Unknown error (0xc00d1194)")]
        NS_E_WMP_PROTOCOL_PROBLEM = 0xC00D1194,
        [Description("Unknown error (0xc00d1195)")]
        NS_E_WMP_NO_DISK_SPACE = 0xC00D1195,
        [Description("Unknown error (0xc00d1196)")]
        NS_E_WMP_LOGON_FAILURE = 0xC00D1196,
        [Description("Unknown error (0xc00d1197)")]
        NS_E_WMP_CANNOT_FIND_FILE = 0xC00D1197,
        [Description("Unknown error (0xc00d1198)")]
        NS_E_WMP_SERVER_INACCESSIBLE = 0xC00D1198,
        [Description("Unknown error (0xc00d1199)")]
        NS_E_WMP_UNSUPPORTED_FORMAT = 0xC00D1199,
        [Description("Unknown error (0xc00d119a)")]
        NS_E_WMP_DSHOW_UNSUPPORTED_FORMAT = 0xC00D119A,
        [Description("Unknown error (0xc00d119b)")]
        NS_E_WMP_PLAYLIST_EXISTS = 0xC00D119B,
        [Description("Unknown error (0xc00d119c)")]
        NS_E_WMP_NONMEDIA_FILES = 0xC00D119C,
        [Description("Unknown error (0xc00d119d)")]
        NS_E_WMP_INVALID_ASX = 0xC00D119D,
        [Description("Unknown error (0xc00d119e)")]
        NS_E_WMP_ALREADY_IN_USE = 0xC00D119E,
        [Description("Unknown error (0xc00d119f)")]
        NS_E_WMP_IMAPI_FAILURE = 0xC00D119F,
        [Description("Unknown error (0xc00d11a0)")]
        NS_E_WMP_WMDM_FAILURE = 0xC00D11A0,
        [Description("Unknown error (0xc00d11a1)")]
        NS_E_WMP_CODEC_NEEDED_WITH_4CC = 0xC00D11A1,
        [Description("Unknown error (0xc00d11a2)")]
        NS_E_WMP_CODEC_NEEDED_WITH_FORMATTAG = 0xC00D11A2,
        [Description("Unknown error (0xc00d11a3)")]
        NS_E_WMP_MSSAP_NOT_AVAILABLE = 0xC00D11A3,
        [Description("Unknown error (0xc00d11a4)")]
        NS_E_WMP_WMDM_INTERFACEDEAD = 0xC00D11A4,
        [Description("Unknown error (0xc00d11a5)")]
        NS_E_WMP_WMDM_NOTCERTIFIED = 0xC00D11A5,
        [Description("Unknown error (0xc00d11a6)")]
        NS_E_WMP_WMDM_LICENSE_NOTEXIST = 0xC00D11A6,
        [Description("Unknown error (0xc00d11a7)")]
        NS_E_WMP_WMDM_LICENSE_EXPIRED = 0xC00D11A7,
        [Description("Unknown error (0xc00d11a8)")]
        NS_E_WMP_WMDM_BUSY = 0xC00D11A8,
        [Description("Unknown error (0xc00d11a9)")]
        NS_E_WMP_WMDM_NORIGHTS = 0xC00D11A9,
        [Description("Unknown error (0xc00d11aa)")]
        NS_E_WMP_WMDM_INCORRECT_RIGHTS = 0xC00D11AA,
        [Description("Unknown error (0xc00d11ab)")]
        NS_E_WMP_IMAPI_GENERIC = 0xC00D11AB,
        [Description("Unknown error (0xc00d11ad)")]
        NS_E_WMP_IMAPI_DEVICE_NOTPRESENT = 0xC00D11AD,
        [Description("Unknown error (0xc00d11ae)")]
        NS_E_WMP_IMAPI_DEVICE_BUSY = 0xC00D11AE,
        [Description("Unknown error (0xc00d11af)")]
        NS_E_WMP_IMAPI_LOSS_OF_STREAMING = 0xC00D11AF,
        [Description("Unknown error (0xc00d11b0)")]
        NS_E_WMP_SERVER_UNAVAILABLE = 0xC00D11B0,
        [Description("Unknown error (0xc00d11b1)")]
        NS_E_WMP_FILE_OPEN_FAILED = 0xC00D11B1,
        [Description("Unknown error (0xc00d11b2)")]
        NS_E_WMP_VERIFY_ONLINE = 0xC00D11B2,
        [Description("Unknown error (0xc00d11b3)")]
        NS_E_WMP_SERVER_NOT_RESPONDING = 0xC00D11B3,
        [Description("Unknown error (0xc00d11b4)")]
        NS_E_WMP_DRM_CORRUPT_BACKUP = 0xC00D11B4,
        [Description("Unknown error (0xc00d11b5)")]
        NS_E_WMP_DRM_LICENSE_SERVER_UNAVAILABLE = 0xC00D11B5,
        [Description("Unknown error (0xc00d11b6)")]
        NS_E_WMP_NETWORK_FIREWALL = 0xC00D11B6,
        [Description("Unknown error (0xc00d11b7)")]
        NS_E_WMP_NO_REMOVABLE_MEDIA = 0xC00D11B7,
        [Description("Unknown error (0xc00d11b8)")]
        NS_E_WMP_PROXY_CONNECT_TIMEOUT = 0xC00D11B8,
        [Description("Unknown error (0xc00d11b9)")]
        NS_E_WMP_NEED_UPGRADE = 0xC00D11B9,
        [Description("Unknown error (0xc00d11ba)")]
        NS_E_WMP_AUDIO_HW_PROBLEM = 0xC00D11BA,
        [Description("Unknown error (0xc00d11bb)")]
        NS_E_WMP_INVALID_PROTOCOL = 0xC00D11BB,
        [Description("Unknown error (0xc00d11bc)")]
        NS_E_WMP_INVALID_LIBRARY_ADD = 0xC00D11BC,
        [Description("Unknown error (0xc00d11bd)")]
        NS_E_WMP_MMS_NOT_SUPPORTED = 0xC00D11BD,
        [Description("Unknown error (0xc00d11be)")]
        NS_E_WMP_NO_PROTOCOLS_SELECTED = 0xC00D11BE,
        [Description("Unknown error (0xc00d11bf)")]
        NS_E_WMP_GOFULLSCREEN_FAILED = 0xC00D11BF,
        [Description("Unknown error (0xc00d11c0)")]
        NS_E_WMP_NETWORK_ERROR = 0xC00D11C0,
        [Description("Unknown error (0xc00d11c1)")]
        NS_E_WMP_CONNECT_TIMEOUT = 0xC00D11C1,
        [Description("Unknown error (0xc00d11c2)")]
        NS_E_WMP_MULTICAST_DISABLED = 0xC00D11C2,
        [Description("Unknown error (0xc00d11c3)")]
        NS_E_WMP_SERVER_DNS_TIMEOUT = 0xC00D11C3,
        [Description("Unknown error (0xc00d11c4)")]
        NS_E_WMP_PROXY_NOT_FOUND = 0xC00D11C4,
        [Description("Unknown error (0xc00d11c5)")]
        NS_E_WMP_TAMPERED_CONTENT = 0xC00D11C5,
        [Description("Unknown error (0xc00d11c6)")]
        NS_E_WMP_OUTOFMEMORY = 0xC00D11C6,
        [Description("Unknown error (0xc00d11c7)")]
        NS_E_WMP_AUDIO_CODEC_NOT_INSTALLED = 0xC00D11C7,
        [Description("Unknown error (0xc00d11c8)")]
        NS_E_WMP_VIDEO_CODEC_NOT_INSTALLED = 0xC00D11C8,
        [Description("Unknown error (0xc00d11c9)")]
        NS_E_WMP_IMAPI_DEVICE_INVALIDTYPE = 0xC00D11C9,
        [Description("Unknown error (0xc00d11ca)")]
        NS_E_WMP_DRM_DRIVER_AUTH_FAILURE = 0xC00D11CA,
        [Description("Unknown error (0xc00d11cb)")]
        NS_E_WMP_NETWORK_RESOURCE_FAILURE = 0xC00D11CB,
        [Description("Unknown error (0xc00d11cc)")]
        NS_E_WMP_UPGRADE_APPLICATION = 0xC00D11CC,
        [Description("Unknown error (0xc00d11cd)")]
        NS_E_WMP_UNKNOWN_ERROR = 0xC00D11CD,
        [Description("Unknown error (0xc00d11ce)")]
        NS_E_WMP_INVALID_KEY = 0xC00D11CE,
        [Description("Unknown error (0xc00d11cf)")]
        NS_E_WMP_CD_ANOTHER_USER = 0xC00D11CF,
        [Description("Unknown error (0xc00d11d0)")]
        NS_E_WMP_DRM_NEEDS_AUTHORIZATION = 0xC00D11D0,
        [Description("Unknown error (0xc00d11d1)")]
        NS_E_WMP_BAD_DRIVER = 0xC00D11D1,
        [Description("Unknown error (0xc00d11d2)")]
        NS_E_WMP_ACCESS_DENIED = 0xC00D11D2,
        [Description("Unknown error (0xc00d11d3)")]
        NS_E_WMP_LICENSE_RESTRICTS = 0xC00D11D3,
        [Description("Unknown error (0xc00d11d4)")]
        NS_E_WMP_INVALID_REQUEST = 0xC00D11D4,
        [Description("Unknown error (0xc00d11d5)")]
        NS_E_WMP_CD_STASH_NO_SPACE = 0xC00D11D5,
        [Description("Unknown error (0xc00d11d6)")]
        NS_E_WMP_DRM_NEW_HARDWARE = 0xC00D11D6,
        [Description("Unknown error (0xc00d11d7)")]
        NS_E_WMP_DRM_INVALID_SIG = 0xC00D11D7,
        [Description("Unknown error (0xc00d11d8)")]
        NS_E_WMP_DRM_CANNOT_RESTORE = 0xC00D11D8,
        [Description("Unknown error (0xc00d11d9)")]
        NS_E_WMP_BURN_DISC_OVERFLOW = 0xC00D11D9,
        [Description("Unknown error (0xc00d11da)")]
        NS_E_WMP_DRM_GENERIC_LICENSE_FAILURE = 0xC00D11DA,
        [Description("Unknown error (0xc00d11db)")]
        NS_E_WMP_DRM_NO_SECURE_CLOCK = 0xC00D11DB,
        [Description("Unknown error (0xc00d11dc)")]
        NS_E_WMP_DRM_NO_RIGHTS = 0xC00D11DC,
        [Description("Unknown error (0xc00d11dd)")]
        NS_E_WMP_DRM_INDIV_FAILED = 0xC00D11DD,
        [Description("Unknown error (0xc00d11de)")]
        NS_E_WMP_SERVER_NONEWCONNECTIONS = 0xC00D11DE,
        [Description("Unknown error (0xc00d11df)")]
        NS_E_WMP_MULTIPLE_ERROR_IN_PLAYLIST = 0xC00D11DF,
        [Description("Unknown error (0xc00d11e0)")]
        NS_E_WMP_IMAPI2_ERASE_FAIL = 0xC00D11E0,
        [Description("Unknown error (0xc00d11e1)")]
        NS_E_WMP_IMAPI2_ERASE_DEVICE_BUSY = 0xC00D11E1,
        [Description("Unknown error (0xc00d11e2)")]
        NS_E_WMP_DRM_COMPONENT_FAILURE = 0xC00D11E2,
        [Description("Unknown error (0xc00d11e3)")]
        NS_E_WMP_DRM_NO_DEVICE_CERT = 0xC00D11E3,
        [Description("Unknown error (0xc00d11e4)")]
        NS_E_WMP_SERVER_SECURITY_ERROR = 0xC00D11E4,
        [Description("Unknown error (0xc00d11e5)")]
        NS_E_WMP_AUDIO_DEVICE_LOST = 0xC00D11E5,
        [Description("Unknown error (0xc00d11e6)")]
        NS_E_WMP_IMAPI_MEDIA_INCOMPATIBLE = 0xC00D11E6,
        [Description("Unknown error (0xc00d11ee)")]
        NS_E_SYNCWIZ_DEVICE_FULL = 0xC00D11EE,
        [Description("Unknown error (0xc00d11ef)")]
        NS_E_SYNCWIZ_CANNOT_CHANGE_SETTINGS = 0xC00D11EF,
        [Description("Unknown error (0xc00d11f0)")]
        NS_E_TRANSCODE_DELETECACHEERROR = 0xC00D11F0,
        [Description("Unknown error (0xc00d11f8)")]
        NS_E_CD_NO_BUFFERS_READ = 0xC00D11F8,
        [Description("Unknown error (0xc00d11f9)")]
        NS_E_CD_EMPTY_TRACK_QUEUE = 0xC00D11F9,
        [Description("Unknown error (0xc00d11fa)")]
        NS_E_CD_NO_READER = 0xC00D11FA,
        [Description("Unknown error (0xc00d11fb)")]
        NS_E_CD_ISRC_INVALID = 0xC00D11FB,
        [Description("Unknown error (0xc00d11fc)")]
        NS_E_CD_MEDIA_CATALOG_NUMBER_INVALID = 0xC00D11FC,
        [Description("Unknown error (0xc00d11fd)")]
        NS_E_SLOW_READ_DIGITAL_WITH_ERRORCORRECTION = 0xC00D11FD,
        [Description("Unknown error (0xc00d11fe)")]
        NS_E_CD_SPEEDDETECT_NOT_ENOUGH_READS = 0xC00D11FE,
        [Description("Unknown error (0xc00d11ff)")]
        NS_E_CD_QUEUEING_DISABLED = 0xC00D11FF,
        [Description("Unknown error (0xc00d1202)")]
        NS_E_WMP_DRM_ACQUIRING_LICENSE = 0xC00D1202,
        [Description("Unknown error (0xc00d1203)")]
        NS_E_WMP_DRM_LICENSE_EXPIRED = 0xC00D1203,
        [Description("Unknown error (0xc00d1204)")]
        NS_E_WMP_DRM_LICENSE_NOTACQUIRED = 0xC00D1204,
        [Description("Unknown error (0xc00d1205)")]
        NS_E_WMP_DRM_LICENSE_NOTENABLED = 0xC00D1205,
        [Description("Unknown error (0xc00d1206)")]
        NS_E_WMP_DRM_LICENSE_UNUSABLE = 0xC00D1206,
        [Description("Unknown error (0xc00d1207)")]
        NS_E_WMP_DRM_LICENSE_CONTENT_REVOKED = 0xC00D1207,
        [Description("Unknown error (0xc00d1208)")]
        NS_E_WMP_DRM_LICENSE_NOSAP = 0xC00D1208,
        [Description("Unknown error (0xc00d1209)")]
        NS_E_WMP_DRM_UNABLE_TO_ACQUIRE_LICENSE = 0xC00D1209,
        [Description("Unknown error (0xc00d120a)")]
        NS_E_WMP_LICENSE_REQUIRED = 0xC00D120A,
        [Description("Unknown error (0xc00d120b)")]
        NS_E_WMP_PROTECTED_CONTENT = 0xC00D120B,
        [Description("Unknown error (0xc00d122a)")]
        NS_E_WMP_POLICY_VALUE_NOT_CONFIGURED = 0xC00D122A,
        [Description("Unknown error (0xc00d1234)")]
        NS_E_PDA_CANNOT_SYNC_FROM_INTERNET = 0xC00D1234,
        [Description("Unknown error (0xc00d1235)")]
        NS_E_PDA_CANNOT_SYNC_INVALID_PLAYLIST = 0xC00D1235,
        [Description("Unknown error (0xc00d1236)")]
        NS_E_PDA_FAILED_TO_SYNCHRONIZE_FILE = 0xC00D1236,
        [Description("Unknown error (0xc00d1237)")]
        NS_E_PDA_SYNC_FAILED = 0xC00D1237,
        [Description("Unknown error (0xc00d1238)")]
        NS_E_PDA_DELETE_FAILED = 0xC00D1238,
        [Description("Unknown error (0xc00d1239)")]
        NS_E_PDA_FAILED_TO_RETRIEVE_FILE = 0xC00D1239,
        [Description("Unknown error (0xc00d123a)")]
        NS_E_PDA_DEVICE_NOT_RESPONDING = 0xC00D123A,
        [Description("Unknown error (0xc00d123b)")]
        NS_E_PDA_FAILED_TO_TRANSCODE_PHOTO = 0xC00D123B,
        [Description("Unknown error (0xc00d123c)")]
        NS_E_PDA_FAILED_TO_ENCRYPT_TRANSCODED_FILE = 0xC00D123C,
        [Description("Unknown error (0xc00d123d)")]
        NS_E_PDA_CANNOT_TRANSCODE_TO_AUDIO = 0xC00D123D,
        [Description("Unknown error (0xc00d123e)")]
        NS_E_PDA_CANNOT_TRANSCODE_TO_VIDEO = 0xC00D123E,
        [Description("Unknown error (0xc00d123f)")]
        NS_E_PDA_CANNOT_TRANSCODE_TO_IMAGE = 0xC00D123F,
        [Description("Unknown error (0xc00d1240)")]
        NS_E_PDA_RETRIEVED_FILE_FILENAME_TOO_LONG = 0xC00D1240,
        [Description("Unknown error (0xc00d1241)")]
        NS_E_PDA_CEWMDM_DRM_ERROR = 0xC00D1241,
        [Description("Unknown error (0xc00d1242)")]
        NS_E_INCOMPLETE_PLAYLIST = 0xC00D1242,
        [Description("Unknown error (0xc00d1243)")]
        NS_E_PDA_SYNC_RUNNING = 0xC00D1243,
        [Description("Unknown error (0xc00d1244)")]
        NS_E_PDA_SYNC_LOGIN_ERROR = 0xC00D1244,
        [Description("Unknown error (0xc00d1245)")]
        NS_E_PDA_TRANSCODE_CODEC_NOT_FOUND = 0xC00D1245,
        [Description("Unknown error (0xc00d1246)")]
        NS_E_CANNOT_SYNC_DRM_TO_NON_JANUS_DEVICE = 0xC00D1246,
        [Description("Unknown error (0xc00d1247)")]
        NS_E_CANNOT_SYNC_PREVIOUS_SYNC_RUNNING = 0xC00D1247,
        [Description("Unknown error (0xc00d125c)")]
        NS_E_WMP_HWND_NOTFOUND = 0xC00D125C,
        [Description("Unknown error (0xc00d125d)")]
        NS_E_BKGDOWNLOAD_WRONG_NO_FILES = 0xC00D125D,
        [Description("Unknown error (0xc00d125e)")]
        NS_E_BKGDOWNLOAD_COMPLETECANCELLEDJOB = 0xC00D125E,
        [Description("Unknown error (0xc00d125f)")]
        NS_E_BKGDOWNLOAD_CANCELCOMPLETEDJOB = 0xC00D125F,
        [Description("Unknown error (0xc00d1260)")]
        NS_E_BKGDOWNLOAD_NOJOBPOINTER = 0xC00D1260,
        [Description("Unknown error (0xc00d1261)")]
        NS_E_BKGDOWNLOAD_INVALIDJOBSIGNATURE = 0xC00D1261,
        [Description("Unknown error (0xc00d1262)")]
        NS_E_BKGDOWNLOAD_FAILED_TO_CREATE_TEMPFILE = 0xC00D1262,
        [Description("Unknown error (0xc00d1263)")]
        NS_E_BKGDOWNLOAD_PLUGIN_FAILEDINITIALIZE = 0xC00D1263,
        [Description("Unknown error (0xc00d1264)")]
        NS_E_BKGDOWNLOAD_PLUGIN_FAILEDTOMOVEFILE = 0xC00D1264,
        [Description("Unknown error (0xc00d1265)")]
        NS_E_BKGDOWNLOAD_CALLFUNCFAILED = 0xC00D1265,
        [Description("Unknown error (0xc00d1266)")]
        NS_E_BKGDOWNLOAD_CALLFUNCTIMEOUT = 0xC00D1266,
        [Description("Unknown error (0xc00d1267)")]
        NS_E_BKGDOWNLOAD_CALLFUNCENDED = 0xC00D1267,
        [Description("Unknown error (0xc00d1268)")]
        NS_E_BKGDOWNLOAD_WMDUNPACKFAILED = 0xC00D1268,
        [Description("Unknown error (0xc00d1269)")]
        NS_E_BKGDOWNLOAD_FAILEDINITIALIZE = 0xC00D1269,
        [Description("Unknown error (0xc00d126a)")]
        NS_E_INTERFACE_NOT_REGISTERED_IN_GIT = 0xC00D126A,
        [Description("Unknown error (0xc00d126b)")]
        NS_E_BKGDOWNLOAD_INVALID_FILE_NAME = 0xC00D126B,
        [Description("Unknown error (0xc00d128e)")]
        NS_E_IMAGE_DOWNLOAD_FAILED = 0xC00D128E,
        [Description("Unknown error (0xc00d12c0)")]
        NS_E_WMP_UDRM_NOUSERLIST = 0xC00D12C0,
        [Description("Unknown error (0xc00d12c1)")]
        NS_E_WMP_DRM_NOT_ACQUIRING = 0xC00D12C1,
        [Description("Unknown error (0xc00d12f2)")]
        NS_E_WMP_BSTR_TOO_LONG = 0xC00D12F2,
        [Description("Unknown error (0xc00d12fc)")]
        NS_E_WMP_AUTOPLAY_INVALID_STATE = 0xC00D12FC,
        [Description("Unknown error (0xc00d1306)")]
        NS_E_WMP_COMPONENT_REVOKED = 0xC00D1306,
        [Description("Unknown error (0xc00d1324)")]
        NS_E_CURL_NOTSAFE = 0xC00D1324,
        [Description("Unknown error (0xc00d1325)")]
        NS_E_CURL_INVALIDCHAR = 0xC00D1325,
        [Description("Unknown error (0xc00d1326)")]
        NS_E_CURL_INVALIDHOSTNAME = 0xC00D1326,
        [Description("Unknown error (0xc00d1327)")]
        NS_E_CURL_INVALIDPATH = 0xC00D1327,
        [Description("Unknown error (0xc00d1328)")]
        NS_E_CURL_INVALIDSCHEME = 0xC00D1328,
        [Description("Unknown error (0xc00d1329)")]
        NS_E_CURL_INVALIDURL = 0xC00D1329,
        [Description("Unknown error (0xc00d132b)")]
        NS_E_CURL_CANTWALK = 0xC00D132B,
        [Description("Unknown error (0xc00d132c)")]
        NS_E_CURL_INVALIDPORT = 0xC00D132C,
        [Description("Unknown error (0xc00d132d)")]
        NS_E_CURLHELPER_NOTADIRECTORY = 0xC00D132D,
        [Description("Unknown error (0xc00d132e)")]
        NS_E_CURLHELPER_NOTAFILE = 0xC00D132E,
        [Description("Unknown error (0xc00d132f)")]
        NS_E_CURL_CANTDECODE = 0xC00D132F,
        [Description("Unknown error (0xc00d1330)")]
        NS_E_CURLHELPER_NOTRELATIVE = 0xC00D1330,
        [Description("Unknown error (0xc00d1331)")]
        NS_E_CURL_INVALIDBUFFERSIZE = 0xC00D1331,
        [Description("Unknown error (0xc00d1356)")]
        NS_E_SUBSCRIPTIONSERVICE_PLAYBACK_DISALLOWED = 0xC00D1356,
        [Description("Unknown error (0xc00d1357)")]
        NS_E_CANNOT_BUY_OR_DOWNLOAD_FROM_MULTIPLE_SERVICES = 0xC00D1357,
        [Description("Unknown error (0xc00d1358)")]
        NS_E_CANNOT_BUY_OR_DOWNLOAD_CONTENT = 0xC00D1358,
        [Description("Unknown error (0xc00d135a)")]
        NS_E_NOT_CONTENT_PARTNER_TRACK = 0xC00D135A,
        [Description("Unknown error (0xc00d135b)")]
        NS_E_TRACK_DOWNLOAD_REQUIRES_ALBUM_PURCHASE = 0xC00D135B,
        [Description("Unknown error (0xc00d135c)")]
        NS_E_TRACK_DOWNLOAD_REQUIRES_PURCHASE = 0xC00D135C,
        [Description("Unknown error (0xc00d135d)")]
        NS_E_TRACK_PURCHASE_MAXIMUM_EXCEEDED = 0xC00D135D,
        [Description("Unknown error (0xc00d135f)")]
        NS_E_SUBSCRIPTIONSERVICE_LOGIN_FAILED = 0xC00D135F,
        [Description("Unknown error (0xc00d1360)")]
        NS_E_SUBSCRIPTIONSERVICE_DOWNLOAD_TIMEOUT = 0xC00D1360,
        [Description("Unknown error (0xc00d1362)")]
        NS_E_CONTENT_PARTNER_STILL_INITIALIZING = 0xC00D1362,
        [Description("Unknown error (0xc00d1363)")]
        NS_E_OPEN_CONTAINING_FOLDER_FAILED = 0xC00D1363,
        [Description("Unknown error (0xc00d136a)")]
        NS_E_ADVANCEDEDIT_TOO_MANY_PICTURES = 0xC00D136A,
        [Description("Unknown error (0xc00d1388)")]
        NS_E_REDIRECT = 0xC00D1388,
        [Description("Unknown error (0xc00d1389)")]
        NS_E_STALE_PRESENTATION = 0xC00D1389,
        [Description("Unknown error (0xc00d138a)")]
        NS_E_NAMESPACE_WRONG_PERSIST = 0xC00D138A,
        [Description("Unknown error (0xc00d138b)")]
        NS_E_NAMESPACE_WRONG_TYPE = 0xC00D138B,
        [Description("Unknown error (0xc00d138c)")]
        NS_E_NAMESPACE_NODE_CONFLICT = 0xC00D138C,
        [Description("Unknown error (0xc00d138d)")]
        NS_E_NAMESPACE_NODE_NOT_FOUND = 0xC00D138D,
        [Description("Unknown error (0xc00d138e)")]
        NS_E_NAMESPACE_BUFFER_TOO_SMALL = 0xC00D138E,
        [Description("Unknown error (0xc00d138f)")]
        NS_E_NAMESPACE_TOO_MANY_CALLBACKS = 0xC00D138F,
        [Description("Unknown error (0xc00d1390)")]
        NS_E_NAMESPACE_DUPLICATE_CALLBACK = 0xC00D1390,
        [Description("Unknown error (0xc00d1391)")]
        NS_E_NAMESPACE_CALLBACK_NOT_FOUND = 0xC00D1391,
        [Description("Unknown error (0xc00d1392)")]
        NS_E_NAMESPACE_NAME_TOO_LONG = 0xC00D1392,
        [Description("Unknown error (0xc00d1393)")]
        NS_E_NAMESPACE_DUPLICATE_NAME = 0xC00D1393,
        [Description("Unknown error (0xc00d1394)")]
        NS_E_NAMESPACE_EMPTY_NAME = 0xC00D1394,
        [Description("Unknown error (0xc00d1395)")]
        NS_E_NAMESPACE_INDEX_TOO_LARGE = 0xC00D1395,
        [Description("Unknown error (0xc00d1396)")]
        NS_E_NAMESPACE_BAD_NAME = 0xC00D1396,
        [Description("Unknown error (0xc00d1397)")]
        NS_E_NAMESPACE_WRONG_SECURITY = 0xC00D1397,
        [Description("Unknown error (0xc00d13ec)")]
        NS_E_CACHE_ARCHIVE_CONFLICT = 0xC00D13EC,
        [Description("Unknown error (0xc00d13ed)")]
        NS_E_CACHE_ORIGIN_SERVER_NOT_FOUND = 0xC00D13ED,
        [Description("Unknown error (0xc00d13ee)")]
        NS_E_CACHE_ORIGIN_SERVER_TIMEOUT = 0xC00D13EE,
        [Description("Unknown error (0xc00d13ef)")]
        NS_E_CACHE_NOT_BROADCAST = 0xC00D13EF,
        [Description("Unknown error (0xc00d13f0)")]
        NS_E_CACHE_CANNOT_BE_CACHED = 0xC00D13F0,
        [Description("Unknown error (0xc00d13f1)")]
        NS_E_CACHE_NOT_MODIFIED = 0xC00D13F1,
        [Description("Unknown error (0xc00d1450)")]
        NS_E_CANNOT_REMOVE_PUBLISHING_POINT = 0xC00D1450,
        [Description("Unknown error (0xc00d1451)")]
        NS_E_CANNOT_REMOVE_PLUGIN = 0xC00D1451,
        [Description("Unknown error (0xc00d1452)")]
        NS_E_WRONG_PUBLISHING_POINT_TYPE = 0xC00D1452,
        [Description("Unknown error (0xc00d1453)")]
        NS_E_UNSUPPORTED_LOAD_TYPE = 0xC00D1453,
        [Description("Unknown error (0xc00d1454)")]
        NS_E_INVALID_PLUGIN_LOAD_TYPE_CONFIGURATION = 0xC00D1454,
        [Description("Unknown error (0xc00d1455)")]
        NS_E_INVALID_PUBLISHING_POINT_NAME = 0xC00D1455,
        [Description("Unknown error (0xc00d1456)")]
        NS_E_TOO_MANY_MULTICAST_SINKS = 0xC00D1456,
        [Description("Unknown error (0xc00d1457)")]
        NS_E_PUBLISHING_POINT_INVALID_REQUEST_WHILE_STARTED = 0xC00D1457,
        [Description("Unknown error (0xc00d1458)")]
        NS_E_MULTICAST_PLUGIN_NOT_ENABLED = 0xC00D1458,
        [Description("Unknown error (0xc00d1459)")]
        NS_E_INVALID_OPERATING_SYSTEM_VERSION = 0xC00D1459,
        [Description("Unknown error (0xc00d145a)")]
        NS_E_PUBLISHING_POINT_REMOVED = 0xC00D145A,
        [Description("Unknown error (0xc00d145b)")]
        NS_E_INVALID_PUSH_PUBLISHING_POINT_START_REQUEST = 0xC00D145B,
        [Description("Unknown error (0xc00d145c)")]
        NS_E_UNSUPPORTED_LANGUAGE = 0xC00D145C,
        [Description("Unknown error (0xc00d145d)")]
        NS_E_WRONG_OS_VERSION = 0xC00D145D,
        [Description("Unknown error (0xc00d145e)")]
        NS_E_PUBLISHING_POINT_STOPPED = 0xC00D145E,
        [Description("Unknown error (0xc00d14b4)")]
        NS_E_PLAYLIST_ENTRY_ALREADY_PLAYING = 0xC00D14B4,
        [Description("Unknown error (0xc00d14b5)")]
        NS_E_EMPTY_PLAYLIST = 0xC00D14B5,
        [Description("Unknown error (0xc00d14b6)")]
        NS_E_PLAYLIST_PARSE_FAILURE = 0xC00D14B6,
        [Description("Unknown error (0xc00d14b7)")]
        NS_E_PLAYLIST_UNSUPPORTED_ENTRY = 0xC00D14B7,
        [Description("Unknown error (0xc00d14b8)")]
        NS_E_PLAYLIST_ENTRY_NOT_IN_PLAYLIST = 0xC00D14B8,
        [Description("Unknown error (0xc00d14b9)")]
        NS_E_PLAYLIST_ENTRY_SEEK = 0xC00D14B9,
        [Description("Unknown error (0xc00d14ba)")]
        NS_E_PLAYLIST_RECURSIVE_PLAYLISTS = 0xC00D14BA,
        [Description("Unknown error (0xc00d14bb)")]
        NS_E_PLAYLIST_TOO_MANY_NESTED_PLAYLISTS = 0xC00D14BB,
        [Description("Unknown error (0xc00d14bc)")]
        NS_E_PLAYLIST_SHUTDOWN = 0xC00D14BC,
        [Description("Unknown error (0xc00d14bd)")]
        NS_E_PLAYLIST_END_RECEDING = 0xC00D14BD,
        [Description("Unknown error (0xc00d1518)")]
        NS_E_DATAPATH_NO_SINK = 0xC00D1518,
        [Description("Unknown error (0xc00d151a)")]
        NS_E_INVALID_PUSH_TEMPLATE = 0xC00D151A,
        [Description("Unknown error (0xc00d151b)")]
        NS_E_INVALID_PUSH_PUBLISHING_POINT = 0xC00D151B,
        [Description("Unknown error (0xc00d151c)")]
        NS_E_CRITICAL_ERROR = 0xC00D151C,
        [Description("Unknown error (0xc00d151d)")]
        NS_E_NO_NEW_CONNECTIONS = 0xC00D151D,
        [Description("Unknown error (0xc00d151e)")]
        NS_E_WSX_INVALID_VERSION = 0xC00D151E,
        [Description("Unknown error (0xc00d151f)")]
        NS_E_HEADER_MISMATCH = 0xC00D151F,
        [Description("Unknown error (0xc00d1520)")]
        NS_E_PUSH_DUPLICATE_PUBLISHING_POINT_NAME = 0xC00D1520,
        [Description("Unknown error (0xc00d157c)")]
        NS_E_NO_SCRIPT_ENGINE = 0xC00D157C,
        [Description("Unknown error (0xc00d157d)")]
        NS_E_PLUGIN_ERROR_REPORTED = 0xC00D157D,
        [Description("Unknown error (0xc00d157e)")]
        NS_E_SOURCE_PLUGIN_NOT_FOUND = 0xC00D157E,
        [Description("Unknown error (0xc00d157f)")]
        NS_E_PLAYLIST_PLUGIN_NOT_FOUND = 0xC00D157F,
        [Description("Unknown error (0xc00d1580)")]
        NS_E_DATA_SOURCE_ENUMERATION_NOT_SUPPORTED = 0xC00D1580,
        [Description("Unknown error (0xc00d1581)")]
        NS_E_MEDIA_PARSER_INVALID_FORMAT = 0xC00D1581,
        [Description("Unknown error (0xc00d1582)")]
        NS_E_SCRIPT_DEBUGGER_NOT_INSTALLED = 0xC00D1582,
        [Description("Unknown error (0xc00d1583)")]
        NS_E_FEATURE_REQUIRES_ENTERPRISE_SERVER = 0xC00D1583,
        [Description("Unknown error (0xc00d1584)")]
        NS_E_WIZARD_RUNNING = 0xC00D1584,
        [Description("Unknown error (0xc00d1585)")]
        NS_E_INVALID_LOG_URL = 0xC00D1585,
        [Description("Unknown error (0xc00d1586)")]
        NS_E_INVALID_MTU_RANGE = 0xC00D1586,
        [Description("Unknown error (0xc00d1587)")]
        NS_E_INVALID_PLAY_STATISTICS = 0xC00D1587,
        [Description("Unknown error (0xc00d1588)")]
        NS_E_LOG_NEED_TO_BE_SKIPPED = 0xC00D1588,
        [Description("Unknown error (0xc00d1589)")]
        NS_E_HTTP_TEXT_DATACONTAINER_SIZE_LIMIT_EXCEEDED = 0xC00D1589,
        [Description("Unknown error (0xc00d158a)")]
        NS_E_PORT_IN_USE = 0xC00D158A,
        [Description("Unknown error (0xc00d158b)")]
        NS_E_PORT_IN_USE_HTTP = 0xC00D158B,
        [Description("Unknown error (0xc00d158c)")]
        NS_E_HTTP_TEXT_DATACONTAINER_INVALID_SERVER_RESPONSE = 0xC00D158C,
        [Description("Unknown error (0xc00d158d)")]
        NS_E_ARCHIVE_REACH_QUOTA = 0xC00D158D,
        [Description("Unknown error (0xc00d158e)")]
        NS_E_ARCHIVE_ABORT_DUE_TO_BCAST = 0xC00D158E,
        [Description("Unknown error (0xc00d158f)")]
        NS_E_ARCHIVE_GAP_DETECTED = 0xC00D158F,
        [Description("Unknown error (0xc00d1590)")]
        NS_E_AUTHORIZATION_FILE_NOT_FOUND = 0xC00D1590,
        [Description("Unknown error (0xc00d1b58)")]
        NS_E_BAD_MARKIN = 0xC00D1B58,
        [Description("Unknown error (0xc00d1b59)")]
        NS_E_BAD_MARKOUT = 0xC00D1B59,
        [Description("Unknown error (0xc00d1b5a)")]
        NS_E_NOMATCHING_MEDIASOURCE = 0xC00D1B5A,
        [Description("Unknown error (0xc00d1b5b)")]
        NS_E_UNSUPPORTED_SOURCETYPE = 0xC00D1B5B,
        [Description("Unknown error (0xc00d1b5c)")]
        NS_E_TOO_MANY_AUDIO = 0xC00D1B5C,
        [Description("Unknown error (0xc00d1b5d)")]
        NS_E_TOO_MANY_VIDEO = 0xC00D1B5D,
        [Description("Unknown error (0xc00d1b5e)")]
        NS_E_NOMATCHING_ELEMENT = 0xC00D1B5E,
        [Description("Unknown error (0xc00d1b5f)")]
        NS_E_MISMATCHED_MEDIACONTENT = 0xC00D1B5F,
        [Description("Unknown error (0xc00d1b60)")]
        NS_E_CANNOT_DELETE_ACTIVE_SOURCEGROUP = 0xC00D1B60,
        [Description("Unknown error (0xc00d1b61)")]
        NS_E_AUDIODEVICE_BUSY = 0xC00D1B61,
        [Description("Unknown error (0xc00d1b62)")]
        NS_E_AUDIODEVICE_UNEXPECTED = 0xC00D1B62,
        [Description("Unknown error (0xc00d1b63)")]
        NS_E_AUDIODEVICE_BADFORMAT = 0xC00D1B63,
        [Description("Unknown error (0xc00d1b64)")]
        NS_E_VIDEODEVICE_BUSY = 0xC00D1B64,
        [Description("Unknown error (0xc00d1b65)")]
        NS_E_VIDEODEVICE_UNEXPECTED = 0xC00D1B65,
        [Description("Unknown error (0xc00d1b66)")]
        NS_E_INVALIDCALL_WHILE_ENCODER_RUNNING = 0xC00D1B66,
        [Description("Unknown error (0xc00d1b67)")]
        NS_E_NO_PROFILE_IN_SOURCEGROUP = 0xC00D1B67,
        [Description("Unknown error (0xc00d1b68)")]
        NS_E_VIDEODRIVER_UNSTABLE = 0xC00D1B68,
        [Description("Unknown error (0xc00d1b69)")]
        NS_E_VIDCAPSTARTFAILED = 0xC00D1B69,
        [Description("Unknown error (0xc00d1b6a)")]
        NS_E_VIDSOURCECOMPRESSION = 0xC00D1B6A,
        [Description("Unknown error (0xc00d1b6b)")]
        NS_E_VIDSOURCESIZE = 0xC00D1B6B,
        [Description("Unknown error (0xc00d1b6c)")]
        NS_E_ICMQUERYFORMAT = 0xC00D1B6C,
        [Description("Unknown error (0xc00d1b6d)")]
        NS_E_VIDCAPCREATEWINDOW = 0xC00D1B6D,
        [Description("Unknown error (0xc00d1b6e)")]
        NS_E_VIDCAPDRVINUSE = 0xC00D1B6E,
        [Description("Unknown error (0xc00d1b6f)")]
        NS_E_NO_MEDIAFORMAT_IN_SOURCE = 0xC00D1B6F,
        [Description("Unknown error (0xc00d1b70)")]
        NS_E_NO_VALID_OUTPUT_STREAM = 0xC00D1B70,
        [Description("Unknown error (0xc00d1b71)")]
        NS_E_NO_VALID_SOURCE_PLUGIN = 0xC00D1B71,
        [Description("Unknown error (0xc00d1b72)")]
        NS_E_NO_ACTIVE_SOURCEGROUP = 0xC00D1B72,
        [Description("Unknown error (0xc00d1b73)")]
        NS_E_NO_SCRIPT_STREAM = 0xC00D1B73,
        [Description("Unknown error (0xc00d1b74)")]
        NS_E_INVALIDCALL_WHILE_ARCHIVAL_RUNNING = 0xC00D1B74,
        [Description("Unknown error (0xc00d1b75)")]
        NS_E_INVALIDPACKETSIZE = 0xC00D1B75,
        [Description("Unknown error (0xc00d1b76)")]
        NS_E_PLUGIN_CLSID_INVALID = 0xC00D1B76,
        [Description("Unknown error (0xc00d1b77)")]
        NS_E_UNSUPPORTED_ARCHIVETYPE = 0xC00D1B77,
        [Description("Unknown error (0xc00d1b78)")]
        NS_E_UNSUPPORTED_ARCHIVEOPERATION = 0xC00D1B78,
        [Description("Unknown error (0xc00d1b79)")]
        NS_E_ARCHIVE_FILENAME_NOTSET = 0xC00D1B79,
        [Description("Unknown error (0xc00d1b7a)")]
        NS_E_SOURCEGROUP_NOTPREPARED = 0xC00D1B7A,
        [Description("Unknown error (0xc00d1b7b)")]
        NS_E_PROFILE_MISMATCH = 0xC00D1B7B,
        [Description("Unknown error (0xc00d1b7c)")]
        NS_E_INCORRECTCLIPSETTINGS = 0xC00D1B7C,
        [Description("Unknown error (0xc00d1b7d)")]
        NS_E_NOSTATSAVAILABLE = 0xC00D1B7D,
        [Description("Unknown error (0xc00d1b7e)")]
        NS_E_NOTARCHIVING = 0xC00D1B7E,
        [Description("Unknown error (0xc00d1b7f)")]
        NS_E_INVALIDCALL_WHILE_ENCODER_STOPPED = 0xC00D1B7F,
        [Description("Unknown error (0xc00d1b80)")]
        NS_E_NOSOURCEGROUPS = 0xC00D1B80,
        [Description("Unknown error (0xc00d1b81)")]
        NS_E_INVALIDINPUTFPS = 0xC00D1B81,
        [Description("Unknown error (0xc00d1b82)")]
        NS_E_NO_DATAVIEW_SUPPORT = 0xC00D1B82,
        [Description("Unknown error (0xc00d1b83)")]
        NS_E_CODEC_UNAVAILABLE = 0xC00D1B83,
        [Description("Unknown error (0xc00d1b84)")]
        NS_E_ARCHIVE_SAME_AS_INPUT = 0xC00D1B84,
        [Description("Unknown error (0xc00d1b85)")]
        NS_E_SOURCE_NOTSPECIFIED = 0xC00D1B85,
        [Description("Unknown error (0xc00d1b86)")]
        NS_E_NO_REALTIME_TIMECOMPRESSION = 0xC00D1B86,
        [Description("Unknown error (0xc00d1b87)")]
        NS_E_UNSUPPORTED_ENCODER_DEVICE = 0xC00D1B87,
        [Description("Unknown error (0xc00d1b88)")]
        NS_E_UNEXPECTED_DISPLAY_SETTINGS = 0xC00D1B88,
        [Description("Unknown error (0xc00d1b89)")]
        NS_E_NO_AUDIODATA = 0xC00D1B89,
        [Description("Unknown error (0xc00d1b8a)")]
        NS_E_INPUTSOURCE_PROBLEM = 0xC00D1B8A,
        [Description("Unknown error (0xc00d1b8b)")]
        NS_E_WME_VERSION_MISMATCH = 0xC00D1B8B,
        [Description("Unknown error (0xc00d1b8c)")]
        NS_E_NO_REALTIME_PREPROCESS = 0xC00D1B8C,
        [Description("Unknown error (0xc00d1b8d)")]
        NS_E_NO_REPEAT_PREPROCESS = 0xC00D1B8D,
        [Description("Unknown error (0xc00d1b8e)")]
        NS_E_CANNOT_PAUSE_LIVEBROADCAST = 0xC00D1B8E,
        [Description("Unknown error (0xc00d1b8f)")]
        NS_E_DRM_PROFILE_NOT_SET = 0xC00D1B8F,
        [Description("Unknown error (0xc00d1b90)")]
        NS_E_DUPLICATE_DRMPROFILE = 0xC00D1B90,
        [Description("Unknown error (0xc00d1b91)")]
        NS_E_INVALID_DEVICE = 0xC00D1B91,
        [Description("Unknown error (0xc00d1b92)")]
        NS_E_SPEECHEDL_ON_NON_MIXEDMODE = 0xC00D1B92,
        [Description("Unknown error (0xc00d1b93)")]
        NS_E_DRM_PASSWORD_TOO_LONG = 0xC00D1B93,
        [Description("Unknown error (0xc00d1b94)")]
        NS_E_DEVCONTROL_FAILED_SEEK = 0xC00D1B94,
        [Description("Unknown error (0xc00d1b95)")]
        NS_E_INTERLACE_REQUIRE_SAMESIZE = 0xC00D1B95,
        [Description("Unknown error (0xc00d1b96)")]
        NS_E_TOO_MANY_DEVICECONTROL = 0xC00D1B96,
        [Description("Unknown error (0xc00d1b97)")]
        NS_E_NO_MULTIPASS_FOR_LIVEDEVICE = 0xC00D1B97,
        [Description("Unknown error (0xc00d1b98)")]
        NS_E_MISSING_AUDIENCE = 0xC00D1B98,
        [Description("Unknown error (0xc00d1b99)")]
        NS_E_AUDIENCE_CONTENTTYPE_MISMATCH = 0xC00D1B99,
        [Description("Unknown error (0xc00d1b9a)")]
        NS_E_MISSING_SOURCE_INDEX = 0xC00D1B9A,
        [Description("Unknown error (0xc00d1b9b)")]
        NS_E_NUM_LANGUAGE_MISMATCH = 0xC00D1B9B,
        [Description("Unknown error (0xc00d1b9c)")]
        NS_E_LANGUAGE_MISMATCH = 0xC00D1B9C,
        [Description("Unknown error (0xc00d1b9d)")]
        NS_E_VBRMODE_MISMATCH = 0xC00D1B9D,
        [Description("Unknown error (0xc00d1b9e)")]
        NS_E_INVALID_INPUT_AUDIENCE_INDEX = 0xC00D1B9E,
        [Description("Unknown error (0xc00d1b9f)")]
        NS_E_INVALID_INPUT_LANGUAGE = 0xC00D1B9F,
        [Description("Unknown error (0xc00d1ba0)")]
        NS_E_INVALID_INPUT_STREAM = 0xC00D1BA0,
        [Description("Unknown error (0xc00d1ba1)")]
        NS_E_EXPECT_MONO_WAV_INPUT = 0xC00D1BA1,
        [Description("Unknown error (0xc00d1ba2)")]
        NS_E_INPUT_WAVFORMAT_MISMATCH = 0xC00D1BA2,
        [Description("Unknown error (0xc00d1ba3)")]
        NS_E_RECORDQ_DISK_FULL = 0xC00D1BA3,
        [Description("Unknown error (0xc00d1ba4)")]
        NS_E_NO_PAL_INVERSE_TELECINE = 0xC00D1BA4,
        [Description("Unknown error (0xc00d1ba5)")]
        NS_E_ACTIVE_SG_DEVICE_DISCONNECTED = 0xC00D1BA5,
        [Description("Unknown error (0xc00d1ba6)")]
        NS_E_ACTIVE_SG_DEVICE_CONTROL_DISCONNECTED = 0xC00D1BA6,
        [Description("Unknown error (0xc00d1ba7)")]
        NS_E_NO_FRAMES_SUBMITTED_TO_ANALYZER = 0xC00D1BA7,
        [Description("Unknown error (0xc00d1ba8)")]
        NS_E_INPUT_DOESNOT_SUPPORT_SMPTE = 0xC00D1BA8,
        [Description("Unknown error (0xc00d1ba9)")]
        NS_E_NO_SMPTE_WITH_MULTIPLE_SOURCEGROUPS = 0xC00D1BA9,
        [Description("Unknown error (0xc00d1baa)")]
        NS_E_BAD_CONTENTEDL = 0xC00D1BAA,
        [Description("Unknown error (0xc00d1bab)")]
        NS_E_INTERLACEMODE_MISMATCH = 0xC00D1BAB,
        [Description("Unknown error (0xc00d1bac)")]
        NS_E_NONSQUAREPIXELMODE_MISMATCH = 0xC00D1BAC,
        [Description("Unknown error (0xc00d1bad)")]
        NS_E_SMPTEMODE_MISMATCH = 0xC00D1BAD,
        [Description("Unknown error (0xc00d1bae)")]
        NS_E_END_OF_TAPE = 0xC00D1BAE,
        [Description("Unknown error (0xc00d1baf)")]
        NS_E_NO_MEDIA_IN_AUDIENCE = 0xC00D1BAF,
        [Description("Unknown error (0xc00d1bb0)")]
        NS_E_NO_AUDIENCES = 0xC00D1BB0,
        [Description("Unknown error (0xc00d1bb1)")]
        NS_E_NO_AUDIO_COMPAT = 0xC00D1BB1,
        [Description("Unknown error (0xc00d1bb2)")]
        NS_E_INVALID_VBR_COMPAT = 0xC00D1BB2,
        [Description("Unknown error (0xc00d1bb3)")]
        NS_E_NO_PROFILE_NAME = 0xC00D1BB3,
        [Description("Unknown error (0xc00d1bb4)")]
        NS_E_INVALID_VBR_WITH_UNCOMP = 0xC00D1BB4,
        [Description("Unknown error (0xc00d1bb5)")]
        NS_E_MULTIPLE_VBR_AUDIENCES = 0xC00D1BB5,
        [Description("Unknown error (0xc00d1bb6)")]
        NS_E_UNCOMP_COMP_COMBINATION = 0xC00D1BB6,
        [Description("Unknown error (0xc00d1bb7)")]
        NS_E_MULTIPLE_AUDIO_CODECS = 0xC00D1BB7,
        [Description("Unknown error (0xc00d1bb8)")]
        NS_E_MULTIPLE_AUDIO_FORMATS = 0xC00D1BB8,
        [Description("Unknown error (0xc00d1bb9)")]
        NS_E_AUDIO_BITRATE_STEPDOWN = 0xC00D1BB9,
        [Description("Unknown error (0xc00d1bba)")]
        NS_E_INVALID_AUDIO_PEAKRATE = 0xC00D1BBA,
        [Description("Unknown error (0xc00d1bbb)")]
        NS_E_INVALID_AUDIO_PEAKRATE_2 = 0xC00D1BBB,
        [Description("Unknown error (0xc00d1bbc)")]
        NS_E_INVALID_AUDIO_BUFFERMAX = 0xC00D1BBC,
        [Description("Unknown error (0xc00d1bbd)")]
        NS_E_MULTIPLE_VIDEO_CODECS = 0xC00D1BBD,
        [Description("Unknown error (0xc00d1bbe)")]
        NS_E_MULTIPLE_VIDEO_SIZES = 0xC00D1BBE,
        [Description("Unknown error (0xc00d1bbf)")]
        NS_E_INVALID_VIDEO_BITRATE = 0xC00D1BBF,
        [Description("Unknown error (0xc00d1bc0)")]
        NS_E_VIDEO_BITRATE_STEPDOWN = 0xC00D1BC0,
        [Description("Unknown error (0xc00d1bc1)")]
        NS_E_INVALID_VIDEO_PEAKRATE = 0xC00D1BC1,
        [Description("Unknown error (0xc00d1bc2)")]
        NS_E_INVALID_VIDEO_PEAKRATE_2 = 0xC00D1BC2,
        [Description("Unknown error (0xc00d1bc3)")]
        NS_E_INVALID_VIDEO_WIDTH = 0xC00D1BC3,
        [Description("Unknown error (0xc00d1bc4)")]
        NS_E_INVALID_VIDEO_HEIGHT = 0xC00D1BC4,
        [Description("Unknown error (0xc00d1bc5)")]
        NS_E_INVALID_VIDEO_FPS = 0xC00D1BC5,
        [Description("Unknown error (0xc00d1bc6)")]
        NS_E_INVALID_VIDEO_KEYFRAME = 0xC00D1BC6,
        [Description("Unknown error (0xc00d1bc7)")]
        NS_E_INVALID_VIDEO_IQUALITY = 0xC00D1BC7,
        [Description("Unknown error (0xc00d1bc8)")]
        NS_E_INVALID_VIDEO_CQUALITY = 0xC00D1BC8,
        [Description("Unknown error (0xc00d1bc9)")]
        NS_E_INVALID_VIDEO_BUFFER = 0xC00D1BC9,
        [Description("Unknown error (0xc00d1bca)")]
        NS_E_INVALID_VIDEO_BUFFERMAX = 0xC00D1BCA,
        [Description("Unknown error (0xc00d1bcb)")]
        NS_E_INVALID_VIDEO_BUFFERMAX_2 = 0xC00D1BCB,
        [Description("Unknown error (0xc00d1bcc)")]
        NS_E_INVALID_VIDEO_WIDTH_ALIGN = 0xC00D1BCC,
        [Description("Unknown error (0xc00d1bcd)")]
        NS_E_INVALID_VIDEO_HEIGHT_ALIGN = 0xC00D1BCD,
        [Description("Unknown error (0xc00d1bce)")]
        NS_E_MULTIPLE_SCRIPT_BITRATES = 0xC00D1BCE,
        [Description("Unknown error (0xc00d1bcf)")]
        NS_E_INVALID_SCRIPT_BITRATE = 0xC00D1BCF,
        [Description("Unknown error (0xc00d1bd0)")]
        NS_E_MULTIPLE_FILE_BITRATES = 0xC00D1BD0,
        [Description("Unknown error (0xc00d1bd1)")]
        NS_E_INVALID_FILE_BITRATE = 0xC00D1BD1,
        [Description("Unknown error (0xc00d1bd2)")]
        NS_E_SAME_AS_INPUT_COMBINATION = 0xC00D1BD2,
        [Description("Unknown error (0xc00d1bd3)")]
        NS_E_SOURCE_CANNOT_LOOP = 0xC00D1BD3,
        [Description("Unknown error (0xc00d1bd4)")]
        NS_E_INVALID_FOLDDOWN_COEFFICIENTS = 0xC00D1BD4,
        [Description("Unknown error (0xc00d1bd5)")]
        NS_E_DRMPROFILE_NOTFOUND = 0xC00D1BD5,
        [Description("Unknown error (0xc00d1bd6)")]
        NS_E_INVALID_TIMECODE = 0xC00D1BD6,
        [Description("Unknown error (0xc00d1bd7)")]
        NS_E_NO_AUDIO_TIMECOMPRESSION = 0xC00D1BD7,
        [Description("Unknown error (0xc00d1bd8)")]
        NS_E_NO_TWOPASS_TIMECOMPRESSION = 0xC00D1BD8,
        [Description("Unknown error (0xc00d1bd9)")]
        NS_E_TIMECODE_REQUIRES_VIDEOSTREAM = 0xC00D1BD9,
        [Description("Unknown error (0xc00d1bda)")]
        NS_E_NO_MBR_WITH_TIMECODE = 0xC00D1BDA,
        [Description("Unknown error (0xc00d1bdb)")]
        NS_E_INVALID_INTERLACEMODE = 0xC00D1BDB,
        [Description("Unknown error (0xc00d1bdc)")]
        NS_E_INVALID_INTERLACE_COMPAT = 0xC00D1BDC,
        [Description("Unknown error (0xc00d1bdd)")]
        NS_E_INVALID_NONSQUAREPIXEL_COMPAT = 0xC00D1BDD,
        [Description("Unknown error (0xc00d1bde)")]
        NS_E_INVALID_SOURCE_WITH_DEVICE_CONTROL = 0xC00D1BDE,
        [Description("Unknown error (0xc00d1bdf)")]
        NS_E_CANNOT_GENERATE_BROADCAST_INFO_FOR_QUALITYVBR = 0xC00D1BDF,
        [Description("Unknown error (0xc00d1be0)")]
        NS_E_EXCEED_MAX_DRM_PROFILE_LIMIT = 0xC00D1BE0,
        [Description("Unknown error (0xc00d1be1)")]
        NS_E_DEVICECONTROL_UNSTABLE = 0xC00D1BE1,
        [Description("Unknown error (0xc00d1be2)")]
        NS_E_INVALID_PIXEL_ASPECT_RATIO = 0xC00D1BE2,
        [Description("Unknown error (0xc00d1be3)")]
        NS_E_AUDIENCE__LANGUAGE_CONTENTTYPE_MISMATCH = 0xC00D1BE3,
        [Description("Unknown error (0xc00d1be4)")]
        NS_E_INVALID_PROFILE_CONTENTTYPE = 0xC00D1BE4,
        [Description("Unknown error (0xc00d1be5)")]
        NS_E_TRANSFORM_PLUGIN_NOT_FOUND = 0xC00D1BE5,
        [Description("Unknown error (0xc00d1be6)")]
        NS_E_TRANSFORM_PLUGIN_INVALID = 0xC00D1BE6,
        [Description("Unknown error (0xc00d1be7)")]
        NS_E_EDL_REQUIRED_FOR_DEVICE_MULTIPASS = 0xC00D1BE7,
        [Description("Unknown error (0xc00d1be8)")]
        NS_E_INVALID_VIDEO_WIDTH_FOR_INTERLACED_ENCODING = 0xC00D1BE8,
        [Description("Unknown error (0xc00d1be9)")]
        NS_E_MARKIN_UNSUPPORTED = 0xC00D1BE9,
        [Description("Unknown error (0xc00d2711)")]
        NS_E_DRM_INVALID_APPLICATION = 0xC00D2711,
        [Description("Unknown error (0xc00d2712)")]
        NS_E_DRM_LICENSE_STORE_ERROR = 0xC00D2712,
        [Description("Unknown error (0xc00d2713)")]
        NS_E_DRM_SECURE_STORE_ERROR = 0xC00D2713,
        [Description("Unknown error (0xc00d2714)")]
        NS_E_DRM_LICENSE_STORE_SAVE_ERROR = 0xC00D2714,
        [Description("Unknown error (0xc00d2715)")]
        NS_E_DRM_SECURE_STORE_UNLOCK_ERROR = 0xC00D2715,
        [Description("Unknown error (0xc00d2716)")]
        NS_E_DRM_INVALID_CONTENT = 0xC00D2716,
        [Description("Unknown error (0xc00d2717)")]
        NS_E_DRM_UNABLE_TO_OPEN_LICENSE = 0xC00D2717,
        [Description("Unknown error (0xc00d2718)")]
        NS_E_DRM_INVALID_LICENSE = 0xC00D2718,
        [Description("Unknown error (0xc00d2719)")]
        NS_E_DRM_INVALID_MACHINE = 0xC00D2719,
        [Description("Unknown error (0xc00d271b)")]
        NS_E_DRM_ENUM_LICENSE_FAILED = 0xC00D271B,
        [Description("Unknown error (0xc00d271c)")]
        NS_E_DRM_INVALID_LICENSE_REQUEST = 0xC00D271C,
        [Description("Unknown error (0xc00d271d)")]
        NS_E_DRM_UNABLE_TO_INITIALIZE = 0xC00D271D,
        [Description("Unknown error (0xc00d271e)")]
        NS_E_DRM_UNABLE_TO_ACQUIRE_LICENSE = 0xC00D271E,
        [Description("Unknown error (0xc00d271f)")]
        NS_E_DRM_INVALID_LICENSE_ACQUIRED = 0xC00D271F,
        [Description("Unknown error (0xc00d2720)")]
        NS_E_DRM_NO_RIGHTS = 0xC00D2720,
        [Description("Unknown error (0xc00d2721)")]
        NS_E_DRM_KEY_ERROR = 0xC00D2721,
        [Description("Unknown error (0xc00d2722)")]
        NS_E_DRM_ENCRYPT_ERROR = 0xC00D2722,
        [Description("Unknown error (0xc00d2723)")]
        NS_E_DRM_DECRYPT_ERROR = 0xC00D2723,
        [Description("Unknown error (0xc00d2725)")]
        NS_E_DRM_LICENSE_INVALID_XML = 0xC00D2725,
        [Description("Unknown error (0xc00d2728)")]
        NS_E_DRM_NEEDS_INDIVIDUALIZATION = 0xC00D2728,
        [Description("Unknown error (0xc00d2729)")]
        NS_E_DRM_ALREADY_INDIVIDUALIZED = 0xC00D2729,
        [Description("Unknown error (0xc00d272a)")]
        NS_E_DRM_ACTION_NOT_QUERIED = 0xC00D272A,
        [Description("Unknown error (0xc00d272b)")]
        NS_E_DRM_ACQUIRING_LICENSE = 0xC00D272B,
        [Description("Unknown error (0xc00d272c)")]
        NS_E_DRM_INDIVIDUALIZING = 0xC00D272C,
        [Description("Unknown error (0xc00d272d)")]
        NS_E_BACKUP_RESTORE_FAILURE = 0xC00D272D,
        [Description("Unknown error (0xc00d272e)")]
        NS_E_BACKUP_RESTORE_BAD_REQUEST_ID = 0xC00D272E,
        [Description("Unknown error (0xc00d272f)")]
        NS_E_DRM_PARAMETERS_MISMATCHED = 0xC00D272F,
        [Description("Unknown error (0xc00d2730)")]
        NS_E_DRM_UNABLE_TO_CREATE_LICENSE_OBJECT = 0xC00D2730,
        [Description("Unknown error (0xc00d2731)")]
        NS_E_DRM_UNABLE_TO_CREATE_INDI_OBJECT = 0xC00D2731,
        [Description("Unknown error (0xc00d2732)")]
        NS_E_DRM_UNABLE_TO_CREATE_ENCRYPT_OBJECT = 0xC00D2732,
        [Description("Unknown error (0xc00d2733)")]
        NS_E_DRM_UNABLE_TO_CREATE_DECRYPT_OBJECT = 0xC00D2733,
        [Description("Unknown error (0xc00d2734)")]
        NS_E_DRM_UNABLE_TO_CREATE_PROPERTIES_OBJECT = 0xC00D2734,
        [Description("Unknown error (0xc00d2735)")]
        NS_E_DRM_UNABLE_TO_CREATE_BACKUP_OBJECT = 0xC00D2735,
        [Description("Unknown error (0xc00d2736)")]
        NS_E_DRM_INDIVIDUALIZE_ERROR = 0xC00D2736,
        [Description("Unknown error (0xc00d2737)")]
        NS_E_DRM_LICENSE_OPEN_ERROR = 0xC00D2737,
        [Description("Unknown error (0xc00d2738)")]
        NS_E_DRM_LICENSE_CLOSE_ERROR = 0xC00D2738,
        [Description("Unknown error (0xc00d2739)")]
        NS_E_DRM_GET_LICENSE_ERROR = 0xC00D2739,
        [Description("Unknown error (0xc00d273a)")]
        NS_E_DRM_QUERY_ERROR = 0xC00D273A,
        [Description("Unknown error (0xc00d273b)")]
        NS_E_DRM_REPORT_ERROR = 0xC00D273B,
        [Description("Unknown error (0xc00d273c)")]
        NS_E_DRM_GET_LICENSESTRING_ERROR = 0xC00D273C,
        [Description("Unknown error (0xc00d273d)")]
        NS_E_DRM_GET_CONTENTSTRING_ERROR = 0xC00D273D,
        [Description("Unknown error (0xc00d273e)")]
        NS_E_DRM_MONITOR_ERROR = 0xC00D273E,
        [Description("Unknown error (0xc00d273f)")]
        NS_E_DRM_UNABLE_TO_SET_PARAMETER = 0xC00D273F,
        [Description("Unknown error (0xc00d2740)")]
        NS_E_DRM_INVALID_APPDATA = 0xC00D2740,
        [Description("Unknown error (0xc00d2741)")]
        NS_E_DRM_INVALID_APPDATA_VERSION = 0xC00D2741,
        [Description("Unknown error (0xc00d2742)")]
        NS_E_DRM_BACKUP_EXISTS = 0xC00D2742,
        [Description("Unknown error (0xc00d2743)")]
        NS_E_DRM_BACKUP_CORRUPT = 0xC00D2743,
        [Description("Unknown error (0xc00d2744)")]
        NS_E_DRM_BACKUPRESTORE_BUSY = 0xC00D2744,
        [Description("Unknown error (0xc00d2745)")]
        NS_E_BACKUP_RESTORE_BAD_DATA = 0xC00D2745,
        [Description("Unknown error (0xc00d2748)")]
        NS_E_DRM_LICENSE_UNUSABLE = 0xC00D2748,
        [Description("Unknown error (0xc00d2749)")]
        NS_E_DRM_INVALID_PROPERTY = 0xC00D2749,
        [Description("Unknown error (0xc00d274a)")]
        NS_E_DRM_SECURE_STORE_NOT_FOUND = 0xC00D274A,
        [Description("Unknown error (0xc00d274b)")]
        NS_E_DRM_CACHED_CONTENT_ERROR = 0xC00D274B,
        [Description("Unknown error (0xc00d274c)")]
        NS_E_DRM_INDIVIDUALIZATION_INCOMPLETE = 0xC00D274C,
        [Description("Unknown error (0xc00d274d)")]
        NS_E_DRM_DRIVER_AUTH_FAILURE = 0xC00D274D,
        [Description("Unknown error (0xc00d274e)")]
        NS_E_DRM_NEED_UPGRADE_MSSAP = 0xC00D274E,
        [Description("Unknown error (0xc00d274f)")]
        NS_E_DRM_REOPEN_CONTENT = 0xC00D274F,
        [Description("Unknown error (0xc00d2750)")]
        NS_E_DRM_DRIVER_DIGIOUT_FAILURE = 0xC00D2750,
        [Description("Unknown error (0xc00d2751)")]
        NS_E_DRM_INVALID_SECURESTORE_PASSWORD = 0xC00D2751,
        [Description("Unknown error (0xc00d2752)")]
        NS_E_DRM_APPCERT_REVOKED = 0xC00D2752,
        [Description("Unknown error (0xc00d2753)")]
        NS_E_DRM_RESTORE_FRAUD = 0xC00D2753,
        [Description("Unknown error (0xc00d2754)")]
        NS_E_DRM_HARDWARE_INCONSISTENT = 0xC00D2754,
        [Description("Unknown error (0xc00d2755)")]
        NS_E_DRM_SDMI_TRIGGER = 0xC00D2755,
        [Description("Unknown error (0xc00d2756)")]
        NS_E_DRM_SDMI_NOMORECOPIES = 0xC00D2756,
        [Description("Unknown error (0xc00d2757)")]
        NS_E_DRM_UNABLE_TO_CREATE_HEADER_OBJECT = 0xC00D2757,
        [Description("Unknown error (0xc00d2758)")]
        NS_E_DRM_UNABLE_TO_CREATE_KEYS_OBJECT = 0xC00D2758,
        [Description("Unknown error (0xc00d2759)")]
        NS_E_DRM_LICENSE_NOTACQUIRED = 0xC00D2759,
        [Description("Unknown error (0xc00d275a)")]
        NS_E_DRM_UNABLE_TO_CREATE_CODING_OBJECT = 0xC00D275A,
        [Description("Unknown error (0xc00d275b)")]
        NS_E_DRM_UNABLE_TO_CREATE_STATE_DATA_OBJECT = 0xC00D275B,
        [Description("Unknown error (0xc00d275c)")]
        NS_E_DRM_BUFFER_TOO_SMALL = 0xC00D275C,
        [Description("Unknown error (0xc00d275d)")]
        NS_E_DRM_UNSUPPORTED_PROPERTY = 0xC00D275D,
        [Description("Unknown error (0xc00d275e)")]
        NS_E_DRM_ERROR_BAD_NET_RESP = 0xC00D275E,
        [Description("Unknown error (0xc00d275f)")]
        NS_E_DRM_STORE_NOTALLSTORED = 0xC00D275F,
        [Description("Unknown error (0xc00d2760)")]
        NS_E_DRM_SECURITY_COMPONENT_SIGNATURE_INVALID = 0xC00D2760,
        [Description("Unknown error (0xc00d2761)")]
        NS_E_DRM_INVALID_DATA = 0xC00D2761,
        [Description("Unknown error (0xc00d2762)")]
        NS_E_DRM_POLICY_DISABLE_ONLINE = 0xC00D2762,
        [Description("Unknown error (0xc00d2763)")]
        NS_E_DRM_UNABLE_TO_CREATE_AUTHENTICATION_OBJECT = 0xC00D2763,
        [Description("Unknown error (0xc00d2764)")]
        NS_E_DRM_NOT_CONFIGURED = 0xC00D2764,
        [Description("Unknown error (0xc00d2765)")]
        NS_E_DRM_DEVICE_ACTIVATION_CANCELED = 0xC00D2765,
        [Description("Unknown error (0xc00d2766)")]
        NS_E_BACKUP_RESTORE_TOO_MANY_RESETS = 0xC00D2766,
        [Description("Unknown error (0xc00d2767)")]
        NS_E_DRM_DEBUGGING_NOT_ALLOWED = 0xC00D2767,
        [Description("Unknown error (0xc00d2768)")]
        NS_E_DRM_OPERATION_CANCELED = 0xC00D2768,
        [Description("Unknown error (0xc00d2769)")]
        NS_E_DRM_RESTRICTIONS_NOT_RETRIEVED = 0xC00D2769,
        [Description("Unknown error (0xc00d276a)")]
        NS_E_DRM_UNABLE_TO_CREATE_PLAYLIST_OBJECT = 0xC00D276A,
        [Description("Unknown error (0xc00d276b)")]
        NS_E_DRM_UNABLE_TO_CREATE_PLAYLIST_BURN_OBJECT = 0xC00D276B,
        [Description("Unknown error (0xc00d276c)")]
        NS_E_DRM_UNABLE_TO_CREATE_DEVICE_REGISTRATION_OBJECT = 0xC00D276C,
        [Description("Unknown error (0xc00d276d)")]
        NS_E_DRM_UNABLE_TO_CREATE_METERING_OBJECT = 0xC00D276D,
        [Description("Unknown error (0xc00d2770)")]
        NS_E_DRM_TRACK_EXCEEDED_PLAYLIST_RESTICTION = 0xC00D2770,
        [Description("Unknown error (0xc00d2771)")]
        NS_E_DRM_TRACK_EXCEEDED_TRACKBURN_RESTRICTION = 0xC00D2771,
        [Description("Unknown error (0xc00d2772)")]
        NS_E_DRM_UNABLE_TO_GET_DEVICE_CERT = 0xC00D2772,
        [Description("Unknown error (0xc00d2773)")]
        NS_E_DRM_UNABLE_TO_GET_SECURE_CLOCK = 0xC00D2773,
        [Description("Unknown error (0xc00d2774)")]
        NS_E_DRM_UNABLE_TO_SET_SECURE_CLOCK = 0xC00D2774,
        [Description("Unknown error (0xc00d2775)")]
        NS_E_DRM_UNABLE_TO_GET_SECURE_CLOCK_FROM_SERVER = 0xC00D2775,
        [Description("Unknown error (0xc00d2776)")]
        NS_E_DRM_POLICY_METERING_DISABLED = 0xC00D2776,
        [Description("Unknown error (0xc00d2777)")]
        NS_E_DRM_TRANSFER_CHAINED_LICENSES_UNSUPPORTED = 0xC00D2777,
        [Description("Unknown error (0xc00d2778)")]
        NS_E_DRM_SDK_VERSIONMISMATCH = 0xC00D2778,
        [Description("Unknown error (0xc00d2779)")]
        NS_E_DRM_LIC_NEEDS_DEVICE_CLOCK_SET = 0xC00D2779,
        [Description("Unknown error (0xc00d277a)")]
        NS_E_LICENSE_HEADER_MISSING_URL = 0xC00D277A,
        [Description("Unknown error (0xc00d277b)")]
        NS_E_DEVICE_NOT_WMDRM_DEVICE = 0xC00D277B,
        [Description("Unknown error (0xc00d277c)")]
        NS_E_DRM_INVALID_APPCERT = 0xC00D277C,
        [Description("Unknown error (0xc00d277d)")]
        NS_E_DRM_PROTOCOL_FORCEFUL_TERMINATION_ON_PETITION = 0xC00D277D,
        [Description("Unknown error (0xc00d277e)")]
        NS_E_DRM_PROTOCOL_FORCEFUL_TERMINATION_ON_CHALLENGE = 0xC00D277E,
        [Description("Unknown error (0xc00d277f)")]
        NS_E_DRM_CHECKPOINT_FAILED = 0xC00D277F,
        [Description("Unknown error (0xc00d2780)")]
        NS_E_DRM_BB_UNABLE_TO_INITIALIZE = 0xC00D2780,
        [Description("Unknown error (0xc00d2781)")]
        NS_E_DRM_UNABLE_TO_LOAD_HARDWARE_ID = 0xC00D2781,
        [Description("Unknown error (0xc00d2782)")]
        NS_E_DRM_UNABLE_TO_OPEN_DATA_STORE = 0xC00D2782,
        [Description("Unknown error (0xc00d2783)")]
        NS_E_DRM_DATASTORE_CORRUPT = 0xC00D2783,
        [Description("Unknown error (0xc00d2784)")]
        NS_E_DRM_UNABLE_TO_CREATE_INMEMORYSTORE_OBJECT = 0xC00D2784,
        [Description("Unknown error (0xc00d2785)")]
        NS_E_DRM_STUBLIB_REQUIRED = 0xC00D2785,
        [Description("Unknown error (0xc00d2786)")]
        NS_E_DRM_UNABLE_TO_CREATE_CERTIFICATE_OBJECT = 0xC00D2786,
        [Description("Unknown error (0xc00d2787)")]
        NS_E_DRM_MIGRATION_TARGET_NOT_ONLINE = 0xC00D2787,
        [Description("Unknown error (0xc00d2788)")]
        NS_E_DRM_INVALID_MIGRATION_IMAGE = 0xC00D2788,
        [Description("Unknown error (0xc00d2789)")]
        NS_E_DRM_MIGRATION_TARGET_STATES_CORRUPTED = 0xC00D2789,
        [Description("Unknown error (0xc00d278a)")]
        NS_E_DRM_MIGRATION_IMPORTER_NOT_AVAILABLE = 0xC00D278A,
        [Description("Unknown error (0xc00d278b)")]
        NS_DRM_E_MIGRATION_UPGRADE_WITH_DIFF_SID = 0xC00D278B,
        [Description("Unknown error (0xc00d278c)")]
        NS_DRM_E_MIGRATION_SOURCE_MACHINE_IN_USE = 0xC00D278C,
        [Description("Unknown error (0xc00d278d)")]
        NS_DRM_E_MIGRATION_TARGET_MACHINE_LESS_THAN_LH = 0xC00D278D,
        [Description("Unknown error (0xc00d278e)")]
        NS_DRM_E_MIGRATION_IMAGE_ALREADY_EXISTS = 0xC00D278E,
        [Description("Unknown error (0xc00d278f)")]
        NS_E_DRM_HARDWAREID_MISMATCH = 0xC00D278F,
        [Description("Unknown error (0xc00d2790)")]
        NS_E_INVALID_DRMV2CLT_STUBLIB = 0xC00D2790,
        [Description("Unknown error (0xc00d2791)")]
        NS_E_DRM_MIGRATION_INVALID_LEGACYV2_DATA = 0xC00D2791,
        [Description("Unknown error (0xc00d2792)")]
        NS_E_DRM_MIGRATION_LICENSE_ALREADY_EXISTS = 0xC00D2792,
        [Description("Unknown error (0xc00d2793)")]
        NS_E_DRM_MIGRATION_INVALID_LEGACYV2_SST_PASSWORD = 0xC00D2793,
        [Description("Unknown error (0xc00d2794)")]
        NS_E_DRM_MIGRATION_NOT_SUPPORTED = 0xC00D2794,
        [Description("Unknown error (0xc00d2795)")]
        NS_E_DRM_UNABLE_TO_CREATE_MIGRATION_IMPORTER_OBJECT = 0xC00D2795,
        [Description("Unknown error (0xc00d2796)")]
        NS_E_DRM_CHECKPOINT_MISMATCH = 0xC00D2796,
        [Description("Unknown error (0xc00d2797)")]
        NS_E_DRM_CHECKPOINT_CORRUPT = 0xC00D2797,
        [Description("Unknown error (0xc00d2798)")]
        NS_E_REG_FLUSH_FAILURE = 0xC00D2798,
        [Description("Unknown error (0xc00d2799)")]
        NS_E_HDS_KEY_MISMATCH = 0xC00D2799,
        [Description("Unknown error (0xc00d279a)")]
        NS_E_DRM_MIGRATION_OPERATION_CANCELLED = 0xC00D279A,
        [Description("Unknown error (0xc00d279b)")]
        NS_E_DRM_MIGRATION_OBJECT_IN_USE = 0xC00D279B,
        [Description("Unknown error (0xc00d279c)")]
        NS_E_DRM_MALFORMED_CONTENT_HEADER = 0xC00D279C,
        [Description("Unknown error (0xc00d27d8)")]
        NS_E_DRM_LICENSE_EXPIRED = 0xC00D27D8,
        [Description("Unknown error (0xc00d27d9)")]
        NS_E_DRM_LICENSE_NOTENABLED = 0xC00D27D9,
        [Description("Unknown error (0xc00d27da)")]
        NS_E_DRM_LICENSE_APPSECLOW = 0xC00D27DA,
        [Description("Unknown error (0xc00d27db)")]
        NS_E_DRM_STORE_NEEDINDI = 0xC00D27DB,
        [Description("Unknown error (0xc00d27dc)")]
        NS_E_DRM_STORE_NOTALLOWED = 0xC00D27DC,
        [Description("Unknown error (0xc00d27dd)")]
        NS_E_DRM_LICENSE_APP_NOTALLOWED = 0xC00D27DD,
        [Description("Unknown error (0xc00d27df)")]
        NS_E_DRM_LICENSE_CERT_EXPIRED = 0xC00D27DF,
        [Description("Unknown error (0xc00d27e0)")]
        NS_E_DRM_LICENSE_SECLOW = 0xC00D27E0,
        [Description("Unknown error (0xc00d27e1)")]
        NS_E_DRM_LICENSE_CONTENT_REVOKED = 0xC00D27E1,
        [Description("Unknown error (0xc00d27e2)")]
        NS_E_DRM_DEVICE_NOT_REGISTERED = 0xC00D27E2,
        [Description("Unknown error (0xc00d280a)")]
        NS_E_DRM_LICENSE_NOSAP = 0xC00D280A,
        [Description("Unknown error (0xc00d280b)")]
        NS_E_DRM_LICENSE_NOSVP = 0xC00D280B,
        [Description("Unknown error (0xc00d280c)")]
        NS_E_DRM_LICENSE_NOWDM = 0xC00D280C,
        [Description("Unknown error (0xc00d280d)")]
        NS_E_DRM_LICENSE_NOTRUSTEDCODEC = 0xC00D280D,
        [Description("Unknown error (0xc00d280e)")]
        NS_E_DRM_SOURCEID_NOT_SUPPORTED = 0xC00D280E,
        [Description("Unknown error (0xc00d283d)")]
        NS_E_DRM_NEEDS_UPGRADE_TEMPFILE = 0xC00D283D,
        [Description("Unknown error (0xc00d283e)")]
        NS_E_DRM_NEED_UPGRADE_PD = 0xC00D283E,
        [Description("Unknown error (0xc00d283f)")]
        NS_E_DRM_SIGNATURE_FAILURE = 0xC00D283F,
        [Description("Unknown error (0xc00d2840)")]
        NS_E_DRM_LICENSE_SERVER_INFO_MISSING = 0xC00D2840,
        [Description("Unknown error (0xc00d2841)")]
        NS_E_DRM_BUSY = 0xC00D2841,
        [Description("Unknown error (0xc00d2842)")]
        NS_E_DRM_PD_TOO_MANY_DEVICES = 0xC00D2842,
        [Description("Unknown error (0xc00d2843)")]
        NS_E_DRM_INDIV_FRAUD = 0xC00D2843,
        [Description("Unknown error (0xc00d2844)")]
        NS_E_DRM_INDIV_NO_CABS = 0xC00D2844,
        [Description("Unknown error (0xc00d2845)")]
        NS_E_DRM_INDIV_SERVICE_UNAVAILABLE = 0xC00D2845,
        [Description("Unknown error (0xc00d2846)")]
        NS_E_DRM_RESTORE_SERVICE_UNAVAILABLE = 0xC00D2846,
        [Description("Unknown error (0xc00d2847)")]
        NS_E_DRM_CLIENT_CODE_EXPIRED = 0xC00D2847,
        [Description("Unknown error (0xc00d2848)")]
        NS_E_DRM_NO_UPLINK_LICENSE = 0xC00D2848,
        [Description("Unknown error (0xc00d2849)")]
        NS_E_DRM_INVALID_KID = 0xC00D2849,
        [Description("Unknown error (0xc00d284a)")]
        NS_E_DRM_LICENSE_INITIALIZATION_ERROR = 0xC00D284A,
        [Description("Unknown error (0xc00d284c)")]
        NS_E_DRM_CHAIN_TOO_LONG = 0xC00D284C,
        [Description("Unknown error (0xc00d284d)")]
        NS_E_DRM_UNSUPPORTED_ALGORITHM = 0xC00D284D,
        [Description("Unknown error (0xc00d284e)")]
        NS_E_DRM_LICENSE_DELETION_ERROR = 0xC00D284E,
        [Description("Unknown error (0xc00d28a0)")]
        NS_E_DRM_INVALID_CERTIFICATE = 0xC00D28A0,
        [Description("Unknown error (0xc00d28a1)")]
        NS_E_DRM_CERTIFICATE_REVOKED = 0xC00D28A1,
        [Description("Unknown error (0xc00d28a2)")]
        NS_E_DRM_LICENSE_UNAVAILABLE = 0xC00D28A2,
        [Description("Unknown error (0xc00d28a3)")]
        NS_E_DRM_DEVICE_LIMIT_REACHED = 0xC00D28A3,
        [Description("Unknown error (0xc00d28a4)")]
        NS_E_DRM_UNABLE_TO_VERIFY_PROXIMITY = 0xC00D28A4,
        [Description("Unknown error (0xc00d28a5)")]
        NS_E_DRM_MUST_REGISTER = 0xC00D28A5,
        [Description("Unknown error (0xc00d28a6)")]
        NS_E_DRM_MUST_APPROVE = 0xC00D28A6,
        [Description("Unknown error (0xc00d28a7)")]
        NS_E_DRM_MUST_REVALIDATE = 0xC00D28A7,
        [Description("Unknown error (0xc00d28a8)")]
        NS_E_DRM_INVALID_PROXIMITY_RESPONSE = 0xC00D28A8,
        [Description("Unknown error (0xc00d28a9)")]
        NS_E_DRM_INVALID_SESSION = 0xC00D28A9,
        [Description("Unknown error (0xc00d28aa)")]
        NS_E_DRM_DEVICE_NOT_OPEN = 0xC00D28AA,
        [Description("Unknown error (0xc00d28ab)")]
        NS_E_DRM_DEVICE_ALREADY_REGISTERED = 0xC00D28AB,
        [Description("Unknown error (0xc00d28ac)")]
        NS_E_DRM_UNSUPPORTED_PROTOCOL_VERSION = 0xC00D28AC,
        [Description("Unknown error (0xc00d28ad)")]
        NS_E_DRM_UNSUPPORTED_ACTION = 0xC00D28AD,
        [Description("Unknown error (0xc00d28ae)")]
        NS_E_DRM_CERTIFICATE_SECURITY_LEVEL_INADEQUATE = 0xC00D28AE,
        [Description("Unknown error (0xc00d28af)")]
        NS_E_DRM_UNABLE_TO_OPEN_PORT = 0xC00D28AF,
        [Description("Unknown error (0xc00d28b0)")]
        NS_E_DRM_BAD_REQUEST = 0xC00D28B0,
        [Description("Unknown error (0xc00d28b1)")]
        NS_E_DRM_INVALID_CRL = 0xC00D28B1,
        [Description("Unknown error (0xc00d28b2)")]
        NS_E_DRM_ATTRIBUTE_TOO_LONG = 0xC00D28B2,
        [Description("Unknown error (0xc00d28b3)")]
        NS_E_DRM_EXPIRED_LICENSEBLOB = 0xC00D28B3,
        [Description("Unknown error (0xc00d28b4)")]
        NS_E_DRM_INVALID_LICENSEBLOB = 0xC00D28B4,
        [Description("Unknown error (0xc00d28b5)")]
        NS_E_DRM_INCLUSION_LIST_REQUIRED = 0xC00D28B5,
        [Description("Unknown error (0xc00d28b6)")]
        NS_E_DRM_DRMV2CLT_REVOKED = 0xC00D28B6,
        [Description("Unknown error (0xc00d28b7)")]
        NS_E_DRM_RIV_TOO_SMALL = 0xC00D28B7,
        [Description("Unknown error (0xc00d2904)")]
        NS_E_OUTPUT_PROTECTION_LEVEL_UNSUPPORTED = 0xC00D2904,
        [Description("Unknown error (0xc00d2905)")]
        NS_E_COMPRESSED_DIGITAL_VIDEO_PROTECTION_LEVEL_UNSUPPORTED = 0xC00D2905,
        [Description("Unknown error (0xc00d2906)")]
        NS_E_UNCOMPRESSED_DIGITAL_VIDEO_PROTECTION_LEVEL_UNSUPPORTED = 0xC00D2906,
        [Description("Unknown error (0xc00d2907)")]
        NS_E_ANALOG_VIDEO_PROTECTION_LEVEL_UNSUPPORTED = 0xC00D2907,
        [Description("Unknown error (0xc00d2908)")]
        NS_E_COMPRESSED_DIGITAL_AUDIO_PROTECTION_LEVEL_UNSUPPORTED = 0xC00D2908,
        [Description("Unknown error (0xc00d2909)")]
        NS_E_UNCOMPRESSED_DIGITAL_AUDIO_PROTECTION_LEVEL_UNSUPPORTED = 0xC00D2909,
        [Description("Unknown error (0xc00d290a)")]
        NS_E_OUTPUT_PROTECTION_SCHEME_UNSUPPORTED = 0xC00D290A,
        [Description("Unknown error (0xc00d2afa)")]
        NS_E_REBOOT_RECOMMENDED = 0xC00D2AFA,
        [Description("Unknown error (0xc00d2afb)")]
        NS_E_REBOOT_REQUIRED = 0xC00D2AFB,
        [Description("Unknown error (0xc00d2afc)")]
        NS_E_SETUP_INCOMPLETE = 0xC00D2AFC,
        [Description("Unknown error (0xc00d2afd)")]
        NS_E_SETUP_DRM_MIGRATION_FAILED = 0xC00D2AFD,
        [Description("Unknown error (0xc00d2afe)")]
        NS_E_SETUP_IGNORABLE_FAILURE = 0xC00D2AFE,
        [Description("Unknown error (0xc00d2aff)")]
        NS_E_SETUP_DRM_MIGRATION_FAILED_AND_IGNORABLE_FAILURE = 0xC00D2AFF,
        [Description("Unknown error (0xc00d2b00)")]
        NS_E_SETUP_BLOCKED = 0xC00D2B00,
        [Description("Unknown error (0xc00d2ee0)")]
        NS_E_UNKNOWN_PROTOCOL = 0xC00D2EE0,
        [Description("Unknown error (0xc00d2ee1)")]
        NS_E_REDIRECT_TO_PROXY = 0xC00D2EE1,
        [Description("Unknown error (0xc00d2ee2)")]
        NS_E_INTERNAL_SERVER_ERROR = 0xC00D2EE2,
        [Description("Unknown error (0xc00d2ee3)")]
        NS_E_BAD_REQUEST = 0xC00D2EE3,
        [Description("Unknown error (0xc00d2ee4)")]
        NS_E_ERROR_FROM_PROXY = 0xC00D2EE4,
        [Description("Unknown error (0xc00d2ee5)")]
        NS_E_PROXY_TIMEOUT = 0xC00D2EE5,
        [Description("Unknown error (0xc00d2ee6)")]
        NS_E_SERVER_UNAVAILABLE = 0xC00D2EE6,
        [Description("Unknown error (0xc00d2ee7)")]
        NS_E_REFUSED_BY_SERVER = 0xC00D2EE7,
        [Description("Unknown error (0xc00d2ee8)")]
        NS_E_INCOMPATIBLE_SERVER = 0xC00D2EE8,
        [Description("Unknown error (0xc00d2ee9)")]
        NS_E_MULTICAST_DISABLED = 0xC00D2EE9,
        [Description("Unknown error (0xc00d2eea)")]
        NS_E_INVALID_REDIRECT = 0xC00D2EEA,
        [Description("Unknown error (0xc00d2eeb)")]
        NS_E_ALL_PROTOCOLS_DISABLED = 0xC00D2EEB,
        [Description("Unknown error (0xc00d2eec)")]
        NS_E_MSBD_NO_LONGER_SUPPORTED = 0xC00D2EEC,
        [Description("Unknown error (0xc00d2eed)")]
        NS_E_PROXY_NOT_FOUND = 0xC00D2EED,
        [Description("Unknown error (0xc00d2eee)")]
        NS_E_CANNOT_CONNECT_TO_PROXY = 0xC00D2EEE,
        [Description("Unknown error (0xc00d2eef)")]
        NS_E_SERVER_DNS_TIMEOUT = 0xC00D2EEF,
        [Description("Unknown error (0xc00d2ef0)")]
        NS_E_PROXY_DNS_TIMEOUT = 0xC00D2EF0,
        [Description("Unknown error (0xc00d2ef1)")]
        NS_E_CLOSED_ON_SUSPEND = 0xC00D2EF1,
        [Description("Unknown error (0xc00d2ef2)")]
        NS_E_CANNOT_READ_PLAYLIST_FROM_MEDIASERVER = 0xC00D2EF2,
        [Description("Unknown error (0xc00d2ef3)")]
        NS_E_SESSION_NOT_FOUND = 0xC00D2EF3,
        [Description("Unknown error (0xc00d2ef4)")]
        NS_E_REQUIRE_STREAMING_CLIENT = 0xC00D2EF4,
        [Description("Unknown error (0xc00d2ef5)")]
        NS_E_PLAYLIST_ENTRY_HAS_CHANGED = 0xC00D2EF5,
        [Description("Unknown error (0xc00d2ef6)")]
        NS_E_PROXY_ACCESSDENIED = 0xC00D2EF6,
        [Description("Unknown error (0xc00d2ef7)")]
        NS_E_PROXY_SOURCE_ACCESSDENIED = 0xC00D2EF7,
        [Description("Unknown error (0xc00d2ef8)")]
        NS_E_NETWORK_SINK_WRITE = 0xC00D2EF8,
        [Description("Unknown error (0xc00d2ef9)")]
        NS_E_FIREWALL = 0xC00D2EF9,
        [Description("Unknown error (0xc00d2efa)")]
        NS_E_MMS_NOT_SUPPORTED = 0xC00D2EFA,
        [Description("Unknown error (0xc00d2efb)")]
        NS_E_SERVER_ACCESSDENIED = 0xC00D2EFB,
        [Description("Unknown error (0xc00d2efc)")]
        NS_E_RESOURCE_GONE = 0xC00D2EFC,
        [Description("Unknown error (0xc00d2efd)")]
        NS_E_NO_EXISTING_PACKETIZER = 0xC00D2EFD,
        [Description("Unknown error (0xc00d2efe)")]
        NS_E_BAD_SYNTAX_IN_SERVER_RESPONSE = 0xC00D2EFE,
        [Description("Unknown error (0xc00d2f00)")]
        NS_E_RESET_SOCKET_CONNECTION = 0xC00D2F00,
        [Description("Unknown error (0xc00d2f02)")]
        NS_E_TOO_MANY_HOPS = 0xC00D2F02,
        [Description("Unknown error (0xc00d2f05)")]
        NS_E_TOO_MUCH_DATA_FROM_SERVER = 0xC00D2F05,
        [Description("Unknown error (0xc00d2f06)")]
        NS_E_CONNECT_TIMEOUT = 0xC00D2F06,
        [Description("Unknown error (0xc00d2f07)")]
        NS_E_PROXY_CONNECT_TIMEOUT = 0xC00D2F07,
        [Description("Unknown error (0xc00d2f08)")]
        NS_E_SESSION_INVALID = 0xC00D2F08,
        [Description("Unknown error (0xc00d2f0a)")]
        NS_E_PACKETSINK_UNKNOWN_FEC_STREAM = 0xC00D2F0A,
        [Description("Unknown error (0xc00d2f0b)")]
        NS_E_PUSH_CANNOTCONNECT = 0xC00D2F0B,
        [Description("Unknown error (0xc00d2f0c)")]
        NS_E_INCOMPATIBLE_PUSH_SERVER = 0xC00D2F0C,
        [Description("Unknown error (0xc00d32c8)")]
        NS_E_END_OF_PLAYLIST = 0xC00D32C8,
        [Description("Unknown error (0xc00d32c9)")]
        NS_E_USE_FILE_SOURCE = 0xC00D32C9,
        [Description("Unknown error (0xc00d32ca)")]
        NS_E_PROPERTY_NOT_FOUND = 0xC00D32CA,
        [Description("Unknown error (0xc00d32cc)")]
        NS_E_PROPERTY_READ_ONLY = 0xC00D32CC,
        [Description("Unknown error (0xc00d32cd)")]
        NS_E_TABLE_KEY_NOT_FOUND = 0xC00D32CD,
        [Description("Unknown error (0xc00d32cf)")]
        NS_E_INVALID_QUERY_OPERATOR = 0xC00D32CF,
        [Description("Unknown error (0xc00d32d0)")]
        NS_E_INVALID_QUERY_PROPERTY = 0xC00D32D0,
        [Description("Unknown error (0xc00d32d2)")]
        NS_E_PROPERTY_NOT_SUPPORTED = 0xC00D32D2,
        [Description("Unknown error (0xc00d32d4)")]
        NS_E_SCHEMA_CLASSIFY_FAILURE = 0xC00D32D4,
        [Description("Unknown error (0xc00d32d5)")]
        NS_E_METADATA_FORMAT_NOT_SUPPORTED = 0xC00D32D5,
        [Description("Unknown error (0xc00d32d6)")]
        NS_E_METADATA_NO_EDITING_CAPABILITY = 0xC00D32D6,
        [Description("Unknown error (0xc00d32d7)")]
        NS_E_METADATA_CANNOT_SET_LOCALE = 0xC00D32D7,
        [Description("Unknown error (0xc00d32d8)")]
        NS_E_METADATA_LANGUAGE_NOT_SUPORTED = 0xC00D32D8,
        [Description("Unknown error (0xc00d32d9)")]
        NS_E_METADATA_NO_RFC1766_NAME_FOR_LOCALE = 0xC00D32D9,
        [Description("Unknown error (0xc00d32da)")]
        NS_E_METADATA_NOT_AVAILABLE = 0xC00D32DA,
        [Description("Unknown error (0xc00d32db)")]
        NS_E_METADATA_CACHE_DATA_NOT_AVAILABLE = 0xC00D32DB,
        [Description("Unknown error (0xc00d32dc)")]
        NS_E_METADATA_INVALID_DOCUMENT_TYPE = 0xC00D32DC,
        [Description("Unknown error (0xc00d32dd)")]
        NS_E_METADATA_IDENTIFIER_NOT_AVAILABLE = 0xC00D32DD,
        [Description("Unknown error (0xc00d32de)")]
        NS_E_METADATA_CANNOT_RETRIEVE_FROM_OFFLINE_CACHE = 0xC00D32DE,
        [Description("Checksum of the obtained monitor descriptor is invalid")]
        ERROR_MONITOR_INVALID_DESCRIPTOR_CHECKSUM = 0xC0261003,
        [Description("Monitor descriptor contains an invalid standard timing block")]
        ERROR_MONITOR_INVALID_STANDARD_TIMING_BLOCK = 0xC0261004,
        [Description("WMI data block registration failed for one of the MSMonitorClass WMI subclasses")]
        ERROR_MONITOR_WMI_DATABLOCK_REGISTRATION_FAILED = 0xC0261005,
        [Description("Provided monitor descriptor block is either corrupted or does not contain monitor's detailed serial number")]
        ERROR_MONITOR_INVALID_SERIAL_NUMBER_MONDSC_BLOCK = 0xC0261006,
        [Description("Provided monitor descriptor block is either corrupted or does not contain monitor's user friendly name")]
        ERROR_MONITOR_INVALID_USER_FRIENDLY_MONDSC_BLOCK = 0xC0261007,
        [Description("There is no monitor descriptor data at the specified (offset, size) region")]
        ERROR_MONITOR_NO_MORE_DESCRIPTOR_DATA = 0xC0261008,
        [Description("Monitor descriptor contains an invalid detailed timing block")]
        ERROR_MONITOR_INVALID_DETAILED_TIMING_BLOCK = 0xC0261009,
        [Description("Exclusive mode ownership is needed to create unmanaged primary allocation")]
        ERROR_GRAPHICS_NOT_EXCLUSIVE_MODE_OWNER = 0xC0262000,
        [Description("The driver needs more DMA buffer space in order to complete the requested operation")]
        ERROR_GRAPHICS_INSUFFICIENT_DMA_BUFFER = 0xC0262001,
        [Description("Specified display adapter handle is invalid")]
        ERROR_GRAPHICS_INVALID_DISPLAY_ADAPTER = 0xC0262002,
        [Description("Specified display adapter and all of its state has been reset")]
        ERROR_GRAPHICS_ADAPTER_WAS_RESET = 0xC0262003,
        [Description("The driver stack doesn't match the expected driver model")]
        ERROR_GRAPHICS_INVALID_DRIVER_MODEL = 0xC0262004,
        [Description("Present happened but ended up into the changed desktop mode")]
        ERROR_GRAPHICS_PRESENT_MODE_CHANGED = 0xC0262005,
        [Description("Nothing to present due to desktop occlusion")]
        ERROR_GRAPHICS_PRESENT_OCCLUDED = 0xC0262006,
        [Description("Not able to present due to denial of desktop access")]
        ERROR_GRAPHICS_PRESENT_DENIED = 0xC0262007,
        [Description("Not able to present with color convertion")]
        ERROR_GRAPHICS_CANNOTCOLORCONVERT = 0xC0262008,
        [Description("Not enough video memory available to complete the operation")]
        ERROR_GRAPHICS_NO_VIDEO_MEMORY = 0xC0262100,
        [Description("Couldn't probe and lock the underlying memory of an allocation")]
        ERROR_GRAPHICS_CANT_LOCK_MEMORY = 0xC0262101,
        [Description("The allocation is currently busy")]
        ERROR_GRAPHICS_ALLOCATION_BUSY = 0xC0262102,
        [Description("An object being referenced has reach the maximum reference count already and can't be reference further")]
        ERROR_GRAPHICS_TOO_MANY_REFERENCES = 0xC0262103,
        [Description("A problem couldn't be solved due to some currently existing condition. The problem should be tried again later")]
        ERROR_GRAPHICS_TRY_AGAIN_LATER = 0xC0262104,
        [Description("A problem couldn't be solved due to some currently existing condition. The problem should be tried again immediately")]
        ERROR_GRAPHICS_TRY_AGAIN_NOW = 0xC0262105,
        [Description("The allocation is invalid")]
        ERROR_GRAPHICS_ALLOCATION_INVALID = 0xC0262106,
        [Description("No more unswizzling aperture are currently available")]
        ERROR_GRAPHICS_UNSWIZZLING_APERTURE_UNAVAILABLE = 0xC0262107,
        [Description("The current allocation can't be unswizzled by an aperture")]
        ERROR_GRAPHICS_UNSWIZZLING_APERTURE_UNSUPPORTED = 0xC0262108,
        [Description("The request failed because a pinned allocation can't be evicted")]
        ERROR_GRAPHICS_CANT_EVICT_PINNED_ALLOCATION = 0xC0262109,
        [Description("The allocation can't be used from its current segment location for the specified operation")]
        ERROR_GRAPHICS_INVALID_ALLOCATION_USAGE = 0xC0262110,
        [Description("A locked allocation can't be used in the current command buffer")]
        ERROR_GRAPHICS_CANT_RENDER_LOCKED_ALLOCATION = 0xC0262111,
        [Description("The allocation being referenced has been closed permanently")]
        ERROR_GRAPHICS_ALLOCATION_CLOSED = 0xC0262112,
        [Description("An invalid allocation instance is being referenced")]
        ERROR_GRAPHICS_INVALID_ALLOCATION_INSTANCE = 0xC0262113,
        [Description("An invalid allocation handle is being referenced")]
        ERROR_GRAPHICS_INVALID_ALLOCATION_HANDLE = 0xC0262114,
        [Description("The allocation being referenced doesn't belong to the current device")]
        ERROR_GRAPHICS_WRONG_ALLOCATION_DEVICE = 0xC0262115,
        [Description("The specified allocation lost its content")]
        ERROR_GRAPHICS_ALLOCATION_CONTENT_LOST = 0xC0262116,
        [Description("GPU exception is detected on the given device. The device is not able to be scheduled")]
        ERROR_GRAPHICS_GPU_EXCEPTION_ON_DEVICE = 0xC0262200,
        [Description("Specified VidPN topology is invalid")]
        ERROR_GRAPHICS_INVALID_VIDPN_TOPOLOGY = 0xC0262300,
        [Description("Specified VidPN topology is valid but is not supported by this model of the display adapter")]
        ERROR_GRAPHICS_VIDPN_TOPOLOGY_NOT_SUPPORTED = 0xC0262301,
        [Description("Specified VidPN topology is valid but is not supported by the display adapter at this time, due to current allocation of its resources")]
        ERROR_GRAPHICS_VIDPN_TOPOLOGY_CURRENTLY_NOT_SUPPORTED = 0xC0262302,
        [Description("Specified VidPN handle is invalid")]
        ERROR_GRAPHICS_INVALID_VIDPN = 0xC0262303,
        [Description("Specified video present source is invalid")]
        ERROR_GRAPHICS_INVALID_VIDEO_PRESENT_SOURCE = 0xC0262304,
        [Description("Specified video present target is invalid")]
        ERROR_GRAPHICS_INVALID_VIDEO_PRESENT_TARGET = 0xC0262305,
        [Description("Specified VidPN modality is not supported (e.g. at least two of the pinned modes are not cofunctional)")]
        ERROR_GRAPHICS_VIDPN_MODALITY_NOT_SUPPORTED = 0xC0262306,
        [Description("Specified VidPN source mode set is invalid")]
        ERROR_GRAPHICS_INVALID_VIDPN_SOURCEMODESET = 0xC0262308,
        [Description("Specified VidPN target mode set is invalid")]
        ERROR_GRAPHICS_INVALID_VIDPN_TARGETMODESET = 0xC0262309,
        [Description("Specified video signal frequency is invalid")]
        ERROR_GRAPHICS_INVALID_FREQUENCY = 0xC026230A,
        [Description("Specified video signal active region is invalid")]
        ERROR_GRAPHICS_INVALID_ACTIVE_REGION = 0xC026230B,
        [Description("Specified video signal total region is invalid")]
        ERROR_GRAPHICS_INVALID_TOTAL_REGION = 0xC026230C,
        [Description("Specified video present source mode is invalid")]
        ERROR_GRAPHICS_INVALID_VIDEO_PRESENT_SOURCE_MODE = 0xC0262310,
        [Description("Specified video present target mode is invalid")]
        ERROR_GRAPHICS_INVALID_VIDEO_PRESENT_TARGET_MODE = 0xC0262311,
        [Description("Pinned mode must remain in the set on VidPN's cofunctional modality enumeration")]
        ERROR_GRAPHICS_PINNED_MODE_MUST_REMAIN_IN_SET = 0xC0262312,
        [Description("Specified video present path is already in VidPN's topology")]
        ERROR_GRAPHICS_PATH_ALREADY_IN_TOPOLOGY = 0xC0262313,
        [Description("Specified mode is already in the mode set")]
        ERROR_GRAPHICS_MODE_ALREADY_IN_MODESET = 0xC0262314,
        [Description("Specified video present source set is invalid")]
        ERROR_GRAPHICS_INVALID_VIDEOPRESENTSOURCESET = 0xC0262315,
        [Description("Specified video present target set is invalid")]
        ERROR_GRAPHICS_INVALID_VIDEOPRESENTTARGETSET = 0xC0262316,
        [Description("Specified video present source is already in the video present source set")]
        ERROR_GRAPHICS_SOURCE_ALREADY_IN_SET = 0xC0262317,
        [Description("Specified video present target is already in the video present target set")]
        ERROR_GRAPHICS_TARGET_ALREADY_IN_SET = 0xC0262318,
        [Description("Specified VidPN present path is invalid")]
        ERROR_GRAPHICS_INVALID_VIDPN_PRESENT_PATH = 0xC0262319,
        [Description("Miniport has no recommendation for augmentation of the specified VidPN's topology")]
        ERROR_GRAPHICS_NO_RECOMMENDED_VIDPN_TOPOLOGY = 0xC026231A,
        [Description("Specified monitor frequency range set is invalid")]
        ERROR_GRAPHICS_INVALID_MONITOR_FREQUENCYRANGESET = 0xC026231B,
        [Description("Specified monitor frequency range is invalid")]
        ERROR_GRAPHICS_INVALID_MONITOR_FREQUENCYRANGE = 0xC026231C,
        [Description("Specified frequency range is not in the specified monitor frequency range set")]
        ERROR_GRAPHICS_FREQUENCYRANGE_NOT_IN_SET = 0xC026231D,
        [Description("Specified frequency range is already in the specified monitor frequency range set")]
        ERROR_GRAPHICS_FREQUENCYRANGE_ALREADY_IN_SET = 0xC026231F,
        [Description("Specified mode set is stale. Please reacquire the new mode set")]
        ERROR_GRAPHICS_STALE_MODESET = 0xC0262320,
        [Description("Specified monitor source mode set is invalid")]
        ERROR_GRAPHICS_INVALID_MONITOR_SOURCEMODESET = 0xC0262321,
        [Description("Specified monitor source mode is invalid")]
        ERROR_GRAPHICS_INVALID_MONITOR_SOURCE_MODE = 0xC0262322,
        [Description("Miniport does not have any recommendation regarding the request to provide a functional VidPN given the current display adapter configuration")]
        ERROR_GRAPHICS_NO_RECOMMENDED_FUNCTIONAL_VIDPN = 0xC0262323,
        [Description("ID of the specified mode is already used by another mode in the set")]
        ERROR_GRAPHICS_MODE_ID_MUST_BE_UNIQUE = 0xC0262324,
        [Description("System failed to determine a mode that is supported by both the display adapter and the monitor connected to it")]
        ERROR_GRAPHICS_EMPTY_ADAPTER_MONITOR_MODE_SUPPORT_INTERSECTION = 0xC0262325,
        [Description("Number of video present targets must be greater than or equal to the number of video present sources")]
        ERROR_GRAPHICS_VIDEO_PRESENT_TARGETS_LESS_THAN_SOURCES = 0xC0262326,
        [Description("Specified present path is not in VidPN's topology")]
        ERROR_GRAPHICS_PATH_NOT_IN_TOPOLOGY = 0xC0262327,
        [Description("Display adapter must have at least one video present source")]
        ERROR_GRAPHICS_ADAPTER_MUST_HAVE_AT_LEAST_ONE_SOURCE = 0xC0262328,
        [Description("Display adapter must have at least one video present target")]
        ERROR_GRAPHICS_ADAPTER_MUST_HAVE_AT_LEAST_ONE_TARGET = 0xC0262329,
        [Description("Specified monitor descriptor set is invalid")]
        ERROR_GRAPHICS_INVALID_MONITORDESCRIPTORSET = 0xC026232A,
        [Description("Specified monitor descriptor is invalid")]
        ERROR_GRAPHICS_INVALID_MONITORDESCRIPTOR = 0xC026232B,
        [Description("Specified descriptor is not in the specified monitor descriptor set")]
        ERROR_GRAPHICS_MONITORDESCRIPTOR_NOT_IN_SET = 0xC026232C,
        [Description("Specified descriptor is already in the specified monitor descriptor set")]
        ERROR_GRAPHICS_MONITORDESCRIPTOR_ALREADY_IN_SET = 0xC026232D,
        [Description("ID of the specified monitor descriptor is already used by another descriptor in the set")]
        ERROR_GRAPHICS_MONITORDESCRIPTOR_ID_MUST_BE_UNIQUE = 0xC026232E,
        [Description("Specified video present target subset type is invalid")]
        ERROR_GRAPHICS_INVALID_VIDPN_TARGET_SUBSET_TYPE = 0xC026232F,
        [Description("Two or more of the specified resources are not related to each other, as defined by the interface semantics")]
        ERROR_GRAPHICS_RESOURCES_NOT_RELATED = 0xC0262330,
        [Description("ID of the specified video present source is already used by another source in the set")]
        ERROR_GRAPHICS_SOURCE_ID_MUST_BE_UNIQUE = 0xC0262331,
        [Description("ID of the specified video present target is already used by another target in the set")]
        ERROR_GRAPHICS_TARGET_ID_MUST_BE_UNIQUE = 0xC0262332,
        [Description("Specified VidPN source cannot be used because there is no available VidPN target to connect it to")]
        ERROR_GRAPHICS_NO_AVAILABLE_VIDPN_TARGET = 0xC0262333,
        [Description("Newly arrived monitor could not be associated with a display adapter")]
        ERROR_GRAPHICS_MONITOR_COULD_NOT_BE_ASSOCIATED_WITH_ADAPTER = 0xC0262334,
        [Description("Display adapter in question does not have an associated VidPN manager")]
        ERROR_GRAPHICS_NO_VIDPNMGR = 0xC0262335,
        [Description("VidPN manager of the display adapter in question does not have an active VidPN")]
        ERROR_GRAPHICS_NO_ACTIVE_VIDPN = 0xC0262336,
        [Description("Specified VidPN topology is stale. Please reacquire the new topology")]
        ERROR_GRAPHICS_STALE_VIDPN_TOPOLOGY = 0xC0262337,
        [Description("There is no monitor connected on the specified video present target")]
        ERROR_GRAPHICS_MONITOR_NOT_CONNECTED = 0xC0262338,
        [Description("Specified source is not part of the specified VidPN's topology")]
        ERROR_GRAPHICS_SOURCE_NOT_IN_TOPOLOGY = 0xC0262339,
        [Description("Specified primary surface size is invalid")]
        ERROR_GRAPHICS_INVALID_PRIMARYSURFACE_SIZE = 0xC026233A,
        [Description("Specified visible region size is invalid")]
        ERROR_GRAPHICS_INVALID_VISIBLEREGION_SIZE = 0xC026233B,
        [Description("Specified stride is invalid")]
        ERROR_GRAPHICS_INVALID_STRIDE = 0xC026233C,
        [Description("Specified pixel format is invalid")]
        ERROR_GRAPHICS_INVALID_PIXELFORMAT = 0xC026233D,
        [Description("Specified color basis is invalid")]
        ERROR_GRAPHICS_INVALID_COLORBASIS = 0xC026233E,
        [Description("Specified pixel value access mode is invalid")]
        ERROR_GRAPHICS_INVALID_PIXELVALUEACCESSMODE = 0xC026233F,
        [Description("Specified target is not part of the specified VidPN's topology")]
        ERROR_GRAPHICS_TARGET_NOT_IN_TOPOLOGY = 0xC0262340,
        [Description("Failed to acquire display mode management interface")]
        ERROR_GRAPHICS_NO_DISPLAY_MODE_MANAGEMENT_SUPPORT = 0xC0262341,
        [Description("Specified VidPN source is already owned by a DMM client and cannot be used until that client releases it")]
        ERROR_GRAPHICS_VIDPN_SOURCE_IN_USE = 0xC0262342,
        [Description("Specified VidPN is active and cannot be accessed")]
        ERROR_GRAPHICS_CANT_ACCESS_ACTIVE_VIDPN = 0xC0262343,
        [Description("Specified VidPN present path importance ordinal is invalid")]
        ERROR_GRAPHICS_INVALID_PATH_IMPORTANCE_ORDINAL = 0xC0262344,
        [Description("Specified VidPN present path content geometry transformation is invalid")]
        ERROR_GRAPHICS_INVALID_PATH_CONTENT_GEOMETRY_TRANSFORMATION = 0xC0262345,
        [Description("Specified content geometry transformation is not supported on the respective VidPN present path")]
        ERROR_GRAPHICS_PATH_CONTENT_GEOMETRY_TRANSFORMATION_NOT_SUPPORTED = 0xC0262346,
        [Description("Specified gamma ramp is invalid")]
        ERROR_GRAPHICS_INVALID_GAMMA_RAMP = 0xC0262347,
        [Description("Specified gamma ramp is not supported on the respective VidPN present path")]
        ERROR_GRAPHICS_GAMMA_RAMP_NOT_SUPPORTED = 0xC0262348,
        [Description("Multi-sampling is not supported on the respective VidPN present path")]
        ERROR_GRAPHICS_MULTISAMPLING_NOT_SUPPORTED = 0xC0262349,
        [Description("Specified mode is not in the specified mode set")]
        ERROR_GRAPHICS_MODE_NOT_IN_MODESET = 0xC026234A,
        [Description("Specified VidPN topology recommendation reason is invalid")]
        ERROR_GRAPHICS_INVALID_VIDPN_TOPOLOGY_RECOMMENDATION_REASON = 0xC026234D,
        [Description("Specified VidPN present path content type is invalid")]
        ERROR_GRAPHICS_INVALID_PATH_CONTENT_TYPE = 0xC026234E,
        [Description("Specified VidPN present path copy protection type is invalid")]
        ERROR_GRAPHICS_INVALID_COPYPROTECTION_TYPE = 0xC026234F,
        [Description("No more than one unassigned mode set can exist at any given time for a given VidPN source/target")]
        ERROR_GRAPHICS_UNASSIGNED_MODESET_ALREADY_EXISTS = 0xC0262350,
        [Description("Specified scanline ordering type is invalid")]
        ERROR_GRAPHICS_INVALID_SCANLINE_ORDERING = 0xC0262352,
        [Description("Topology changes are not allowed for the specified VidPN")]
        ERROR_GRAPHICS_TOPOLOGY_CHANGES_NOT_ALLOWED = 0xC0262353,
        [Description("All available importance ordinals are already used in specified topology")]
        ERROR_GRAPHICS_NO_AVAILABLE_IMPORTANCE_ORDINALS = 0xC0262354,
        [Description("Specified primary surface has a different private format attribute than the current primary surface")]
        ERROR_GRAPHICS_INCOMPATIBLE_PRIVATE_FORMAT = 0xC0262355,
        [Description("Specified mode pruning algorithm is invalid")]
        ERROR_GRAPHICS_INVALID_MODE_PRUNING_ALGORITHM = 0xC0262356,
        [Description("Specified display adapter child device already has an external device connected to it")]
        ERROR_GRAPHICS_SPECIFIED_CHILD_ALREADY_CONNECTED = 0xC0262400,
        [Description("Specified display adapter child device does not support descriptor exposure")]
        ERROR_GRAPHICS_CHILD_DESCRIPTOR_NOT_SUPPORTED = 0xC0262401,
        [Description("The display adapter is not linked to any other adapters")]
        ERROR_GRAPHICS_NOT_A_LINKED_ADAPTER = 0xC0262430,
        [Description("Lead adapter in a linked configuration was not enumerated yet")]
        ERROR_GRAPHICS_LEADLINK_NOT_ENUMERATED = 0xC0262431,
        [Description("Some chain adapters in a linked configuration were not enumerated yet")]
        ERROR_GRAPHICS_CHAINLINKS_NOT_ENUMERATED = 0xC0262432,
        [Description("The chain of linked adapters is not ready to start because of an unknown failure")]
        ERROR_GRAPHICS_ADAPTER_CHAIN_NOT_READY = 0xC0262433,
        [Description("An attempt was made to start a lead link display adapter when the chain links were not started yet")]
        ERROR_GRAPHICS_CHAINLINKS_NOT_STARTED = 0xC0262434,
        [Description("An attempt was made to power up a lead link display adapter when the chain links were powered down")]
        ERROR_GRAPHICS_CHAINLINKS_NOT_POWERED_ON = 0xC0262435,
        [Description("The adapter link was found to be in an inconsistent state. Not all adapters are in an expected PNP/Power state")]
        ERROR_GRAPHICS_INCONSISTENT_DEVICE_LINK_STATE = 0xC0262436,
        [Description("The driver trying to start is not the same as the driver for the POSTed display adapter")]
        ERROR_GRAPHICS_NOT_POST_DEVICE_DRIVER = 0xC0262438,
        [Description("The driver does not support OPM")]
        ERROR_GRAPHICS_OPM_NOT_SUPPORTED = 0xC0262500,

    }
}
