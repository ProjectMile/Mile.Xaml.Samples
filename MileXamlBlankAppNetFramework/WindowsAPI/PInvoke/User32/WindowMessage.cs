namespace MileXamlBlankAppNetFrameworkModern.WindowsAPI.PInvoke.User32
{
    public enum WindowMessage : int
    {
        WM_NULL = 0x0000,

        WM_CREATE = 0x0001,

        WM_DESTROY = 0x0002,

        WM_MOVE = 0x0003,

        WM_SIZE = 0x0005,

        WM_ACTIVATE = 0x0006,

        WM_SETFOCUS = 0x0007,

        WM_KILLFOCUS = 0x0008,

        WM_SETVISIBLE = 0x0009,

        WM_ENABLE = 0x000A,

        WM_SETREDRAW = 0x000B,

        WM_SETTEXT = 0x000C,

        WM_GETTEXT = 0x000D,

        WM_GETTEXTLENGTH = 0x000E,

        WM_PAINT = 0x000F,

        WM_CLOSE = 0x0010,

        WM_QUERYENDSESSION = 0x0011,

        WM_QUIT = 0x0012,

        WM_QUERYOPEN = 0x0013,

        WM_ERASEBKGND = 0x0014,

        WM_SYSCOLORCHANGE = 0x0015,

        WM_ENDSESSION = 0x0016,

        WM_SYSTEMERROR = 0x0017,

        WM_SHOWWINDOW = 0x0018,

        WM_CTLCOLOR = 0x0019,

        WM_WININICHANGE = 0x001A,

        WM_SETTINGCHANGE = WM_WININICHANGE,

        WM_DEVMODECHANGE = 0x001B,

        WM_ACTIVATEAPP = 0x001C,

        WM_FONTCHANGE = 0x001D,

        WM_TIMECHANGE = 0x001E,

        WM_CANCELMODE = 0x001F,

        WM_SETCURSOR = 0x0020,

        WM_MOUSEACTIVATE = 0x0021,

        WM_CHILDACTIVATE = 0x0022,

        WM_QUEUESYNC = 0x0023,

        WM_GETMINMAXINFO = 0x0024,

        WM_LOGOFF = 0x0025,

        WM_PAINTICON = 0x0026,

        WM_ICONERASEBKGND = 0x0027,

        WM_NEXTDLGCTL = 0x0028,

        WM_ALTTABACTIVE = 0x0029,

        WM_SPOOLERSTATUS = 0x002A,

        WM_DRAWITEM = 0x002B,

        WM_MEASUREITEM = 0x002C,

        WM_DELETEITEM = 0x002D,

        WM_VKEYTOITEM = 0x002E,

        WM_CHARTOITEM = 0x002F,

        WM_SETFONT = 0x0030,

        WM_GETFONT = 0x0031,

        WM_SETHOTKEY = 0x0032,

        WM_GETHOTKEY = 0x0033,

        WM_SHELLNOTIFY = 0x0034,

        WM_ISACTIVEICON = 0x0035,

        WM_QUERYPARKICON = 0x0036,

        WM_QUERYDRAGICON = 0x0037,

        WM_WINHELP = 0x0038,

        WM_COMPAREITEM = 0x0039,

        WM_FULLSCREEN = 0x003A,

        WM_CLIENTSHUTDOWN = 0x003B,

        WM_DDEMLEVENT = 0x003C,

        WM_GETOBJECT = 0x003D,

        WM_TESTING = 0x0040,

        WM_COMPACTING = 0x0041,

        WM_OTHERWINDOWCREATED = 0x0042,

        WM_OTHERWINDOWDESTROYED = 0x0043,

        WM_COMMNOTIFY = 0x0044,

        WM_WINDOWPOSCHANGING = 0x0046,

        WM_WINDOWPOSCHANGED = 0x0047,

        WM_POWER = 0x0048,

        WM_COPYGLOBALDATA = 0x0049,

        WM_COPYDATA = 0x004A,

        WM_CANCELJOURNAL = 0x004B,

        WM_KEYF1 = 0x004D,

        WM_NOTIFY = 0x004E,

        WM_ACCESS_WINDOW = 0x004F,

        WM_INPUTLANGCHANGEREQUEST = 0x0050,

        WM_INPUTLANGCHANGE = 0x0051,

        WM_TCARD = 0x0052,

        WM_HELP = 0x0053,

        WM_USERCHANGED = 0x0054,

        WM_NOTIFYFORMAT = 0x0055,

        WM_FINALDESTROY = 0x0070,

        WM_MEASUREITEM_CLIENTDATA = 0x0071,

        WM_CONTEXTMENU = 0x007B,

        WM_STYLECHANGING = 0x007C,

        WM_STYLECHANGED = 0x007D,

        WM_DISPLAYCHANGE = 0x007E,

        WM_GETICON = 0x007F,

        WM_SETICON = 0x0080,

        WM_NCCREATE = 0x0081,

        WM_NCDESTROY = 0x0082,

        WM_NCCALCSIZE = 0x0083,

        WM_NCHITTEST = 0x0084,

        WM_NCPAINT = 0x0085,

        WM_NCACTIVATE = 0x0086,

        WM_GETDLGCODE = 0x0087,

        WM_SYNCPAINT = 0x0088,

        WM_SYNCTASK = 0x0089,

        WM_KLUDGEMINRECT = 0x008B,

        WM_LPKDRAWSWITCHWND = 0x008C,

        WM_UAHDESTROYWINDOW = 0x0090,

        WM_UAHDRAWMENU = 0x0091,

        WM_UAHDRAWMENUITEM = 0x0092,

        WM_UAHINITMENU = 0x0093,

        WM_UAHMEASUREMENUITEM = 0x0094,

        WM_UAHNCPAINTMENUPOPUP = 0x0095,

        WM_UAHUPDATE = 0x0096,

        WM_NCMOUSEMOVE = 0x00A0,

        WM_NCLBUTTONDOWN = 0x00A1,

        WM_NCLBUTTONUP = 0x00A2,

        WM_NCLBUTTONDBLCLK = 0x00A3,

        WM_NCRBUTTONDOWN = 0x00A4,

        WM_NCRBUTTONUP = 0x00A5,

        WM_NCRBUTTONDBLCLK = 0x00A6,

        WM_NCMBUTTONDOWN = 0x00A7,

        WM_NCMBUTTONUP = 0x00A8,

        WM_NCMBUTTONDBLCLK = 0x00A9,

        WM_NCXBUTTONDOWN = 0x00AB,

        WM_NCXBUTTONUP = 0x00AC,

        WM_NCXBUTTONDBLCLK = 0x00AD,

        WM_NCUAHDRAWCAPTION = 0x00AE,

        WM_NCUAHDRAWFRAME = 0x00AF,

        EM_GETSEL = 0x00B0,

        EM_SETSEL = 0x00B1,

        EM_GETRECT = 0x00B2,

        EM_SETRECT = 0x00B3,

        EM_SETRECTNP = 0x00B4,

        EM_SCROLL = 0x00B5,

        EM_LINESCROLL = 0x00B6,

        EM_SCROLLCARET = 0x00B7,

        EM_GETMODIFY = 0x00B8,

        EM_SETMODIFY = 0x00B9,

        EM_GETLINECOUNT = 0x00BA,

        EM_LINEINDEX = 0x00BB,

        EM_SETHANDLE = 0x00BC,

        EM_GETHANDLE = 0x00BD,

        EM_GETTHUMB = 0x00BE,

        EM_LINELENGTH = 0x00C1,

        EM_REPLACESEL = 0x00C2,

        EM_SETFONT = 0x00C3,

        EM_GETLINE = 0x00C4,

        EM_LIMITTEXT = 0x00C5,

        EM_SETLIMITTEXT = EM_LIMITTEXT,

        EM_CANUNDO = 0x00C6,

        EM_UNDO = 0x00C7,

        EM_FMTLINES = 0x00C8,

        EM_LINEFROMCHAR = 0x00C9,

        EM_SETWORDBREAK = 0x00CA,

        EM_SETTABSTOPS = 0x00CB,

        EM_SETPASSWORDCHAR = 0x00CC,

        EM_EMPTYUNDOBUFFER = 0x00CD,

        EM_GETFIRSTVISIBLELINE = 0x00CE,

        EM_SETREADONLY = 0x00CF,

        EM_SETWORDBREAKPROC = 0x00D0,

        EM_GETWORDBREAKPROC = 0x00D1,

        EM_GETPASSWORDCHAR = 0x00D2,

        EM_SETMARGINS = 0x00D3,

        EM_GETMARGINS = 0x00D4,

        EM_GETLIMITTEXT = 0x00D5,

        EM_POSFROMCHAR = 0x00D6,

        EM_CHARFROMPOS = 0x00D7,

        EM_SETIMESTATUS = 0x00D8,

        EM_GETIMESTATUS = 0x00D9,

        EM_MSGMAX = 0x00DA,

        SBM_SETPOS = 0x00E0,

        SBM_GETPOS = 0x00E1,

        SBM_SETRANGE = 0x00E2,

        SBM_GETRANGE = 0x00E3,

        SBM_ENABLE_ARROWS = 0x00E4,

        SBM_SETRANGEREDRAW = 0x00E6,

        SBM_SETSCROLLINFO = 0x00E9,

        SBM_GETSCROLLINFO = 0x00EA,

        SBM_GETSCROLLBARINFO = 0x00EB,

        BM_GETCHECK = 0x00F0,

        BM_SETCHECK = 0x00F1,

        BM_GETSTATE = 0x00F2,

        BM_SETSTATE = 0x00F3,

        BM_SETSTYLE = 0x00F4,

        BM_CLICK = 0x00F5,

        BM_GETIMAGE = 0x00F6,

        BM_SETIMAGE = 0x00F7,

        BM_SETDONTCLICK = 0x00F8,

        WM_INPUT_DEVICE_CHANGE = 0x00FE,

        WM_INPUT = 0x00FF,

        WM_KEYFIRST = 0x0100,

        WM_KEYDOWN = 0x0100,

        WM_KEYUP = 0x0101,

        WM_CHAR = 0x0102,

        WM_DEADCHAR = 0x0103,

        WM_SYSKEYDOWN = 0x0104,

        WM_SYSKEYUP = 0x0105,

        WM_SYSCHAR = 0x0106,

        WM_SYSDEADCHAR = 0x0107,

        WM_YOMICHAR = 0x0108,

        WM_UNICHAR = 0x0109,

        WM_KEYLAST = 0x0109,

        WM_CONVERTREQUEST = 0x010A,

        WM_CONVERTRESULT = 0x010B,

        WM_INTERIM = 0x010C,

        WM_IME_STARTCOMPOSITION = 0x010D,

        WM_IME_ENDCOMPOSITION = 0x010E,

        WM_IME_COMPOSITION = 0x010F,

        WM_IME_KEYLAST = 0x010F,

        WM_INITDIALOG = 0x0110,

        WM_COMMAND = 0x0111,

        WM_SYSCOMMAND = 0x0112,

        WM_TIMER = 0x0113,

        WM_HSCROLL = 0x0114,

        WM_VSCROLL = 0x0115,

        WM_INITMENU = 0x0116,

        WM_INITMENUPOPUP = 0x0117,

        WM_SYSTIMER = 0x0118,

        WM_GESTURE = 0x0119,

        WM_GESTURENOTIFY = 0x011A,

        WM_GESTUREINPUT = 0x011B,

        WM_GESTURENOTIFIED = 0x011C,

        WM_MENUSELECT = 0x011F,

        WM_MENUCHAR = 0x0120,

        WM_ENTERIDLE = 0x0121,

        WM_MENURBUTTONUP = 0x0122,

        WM_MENUDRAG = 0x0123,

        WM_MENUGETOBJECT = 0x0124,

        WM_UNINITMENUPOPUP = 0x0125,

        WM_MENUCOMMAND = 0x0126,

        WM_CHANGEUISTATE = 0x0127,

        WM_UPDATEUISTATE = 0x0128,

        WM_QUERYUISTATE = 0x0129,

        WM_LBTRACKPOINT = 0x0131,

        WM_CTLCOLORMSGBOX = 0x0132,

        WM_CTLCOLOREDIT = 0x0133,

        WM_CTLCOLORLISTBOX = 0x0134,

        WM_CTLCOLORBTN = 0x0135,

        WM_CTLCOLORDLG = 0x0136,

        WM_CTLCOLORSCROLLBAR = 0x0137,

        WM_CTLCOLORSTATIC = 0x0138,

        CB_GETEDITSEL = 0x0140,

        CB_LIMITTEXT = 0x0141,

        CB_SETEDITSEL = 0x0142,

        CB_ADDSTRING = 0x0143,

        CB_DELETESTRING = 0x0144,

        CB_DIR = 0x0145,

        CB_GETCOUNT = 0x0146,

        CB_GETCURSEL = 0x0147,

        CB_GETLBTEXT = 0x0148,

        CB_GETLBTEXTLEN = 0x0149,

        CB_INSERTSTRING = 0x014A,

        CB_RESETCONTENT = 0x014B,

        CB_FINDSTRING = 0x014C,

        CB_SELECTSTRING = 0x014D,

        CB_SETCURSEL = 0x014E,

        CB_SHOWDROPDOWN = 0x014F,

        CB_GETITEMDATA = 0x0150,

        CB_SETITEMDATA = 0x0151,

        CB_GETDROPPEDCONTROLRECT = 0x0152,

        CB_SETITEMHEIGHT = 0x0153,

        CB_GETITEMHEIGHT = 0x0154,

        CB_SETEXTENDEDUI = 0x0155,

        CB_GETEXTENDEDUI = 0x0156,

        CB_GETDROPPEDSTATE = 0x0157,

        CB_FINDSTRINGEXACT = 0x0158,

        CB_SETLOCALE = 0x0159,

        CB_GETLOCALE = 0x015A,

        CB_GETTOPINDEX = 0x015B,

        CB_SETTOPINDEX = 0x015C,

        CB_GETHORIZONTALEXTENT = 0x015D,

        CB_SETHORIZONTALEXTENT = 0x015E,

        CB_GETDROPPEDWIDTH = 0x015F,

        CB_SETDROPPEDWIDTH = 0x0160,

        CB_INITSTORAGE = 0x0161,

        CB_MSGMAX_OLD = 0x0162,

        CB_MULTIPLEADDSTRING = 0x0163,

        CB_GETCOMBOBOXINFO = 0x0164,

        CB_MSGMAX = 0x0165,

        LB_ADDSTRING = 0x0180,

        LB_INSERTSTRING = 0x0181,

        LB_DELETESTRING = 0x0182,

        LB_SELITEMRANGEEX = 0x0183,

        LB_RESETCONTENT = 0x0184,

        LB_SETSEL = 0x0185,

        LB_SETCURSEL = 0x0186,

        LB_GETSEL = 0x0187,

        LB_GETCURSEL = 0x0188,

        LB_GETTEXT = 0x0189,

        LB_GETTEXTLEN = 0x018A,

        LB_GETCOUNT = 0x018B,

        LB_SELECTSTRING = 0x018C,

        LB_DIR = 0x018D,

        LB_GETTOPINDEX = 0x018E,

        LB_FINDSTRING = 0x018F,

        LB_GETSELCOUNT = 0x0190,

        LB_GETSELITEMS = 0x0191,

        LB_SETTABSTOPS = 0x0192,

        LB_GETHORIZONTALEXTENT = 0x0193,

        LB_SETHORIZONTALEXTENT = 0x0194,

        LB_SETCOLUMNWIDTH = 0x0195,

        LB_ADDFILE = 0x0196,

        LB_SETTOPINDEX = 0x0197,

        LB_GETITEMRECT = 0x0198,

        LB_GETITEMDATA = 0x0199,

        LB_SETITEMDATA = 0x019A,

        LB_SELITEMRANGE = 0x019B,

        LB_SETANCHORINDEX = 0x019C,

        LB_GETANCHORINDEX = 0x019D,

        LB_SETCARETINDEX = 0x019E,

        LB_GETCARETINDEX = 0x019F,

        LB_SETITEMHEIGHT = 0x01A0,

        LB_GETITEMHEIGHT = 0x01A1,

        LB_FINDSTRINGEXACT = 0x01A2,

        LBCB_CARETON = 0x01A3,

        LBCB_CARETOFF = 0x01A4,

        LB_SETLOCALE = 0x01A5,

        LB_GETLOCALE = 0x01A6,

        LB_SETCOUNT = 0x01A7,

        LB_INITSTORAGE = 0x01A8,

        LB_ITEMFROMPOINT = 0x01A9,

        LB_INSERTSTRINGUPPER = 0x01AA,

        LB_INSERTSTRINGLOWER = 0x01AB,

        LB_ADDSTRINGUPPER = 0x01AC,

        LB_ADDSTRINGLOWER = 0x01AD,

        LBCB_STARTTRACK = 0x01AE,

        LBCB_ENDTRACK = 0x01AF,

        LB_MSGMAX_OLD = 0x01B0,

        LB_MULTIPLEADDSTRING = 0x01B1,

        LB_GETLISTBOXINFO = 0x01B2,

        LB_MSGMAX = 0x01B3,

        MN_FIRST = 0x01E0,

        MN_GETHMENU = 0x01E1,

        WM_MOUSEFIRST = 0x0200,

        WM_MOUSEMOVE = 0x0200,

        WM_LBUTTONDOWN = 0x0201,

        WM_LBUTTONUP = 0x0202,

        WM_LBUTTONDBLCLK = 0x0203,

        WM_RBUTTONDOWN = 0x0204,

        WM_RBUTTONUP = 0x0205,

        WM_RBUTTONDBLCLK = 0x0206,

        WM_MBUTTONDOWN = 0x0207,

        WM_MBUTTONUP = 0x0208,

        WM_MBUTTONDBLCLK = 0x0209,

        WM_MOUSEWHEEL = 0x020A,

        WM_XBUTTONDOWN = 0x020B,

        WM_XBUTTONUP = 0x020C,

        WM_XBUTTONDBLCLK = 0x020D,

        WM_MOUSEHWHEEL = 0x020E,

        WM_MOUSELAST = 0x020E,

        WM_PARENTNOTIFY = 0x0210,

        WM_ENTERMENULOOP = 0x0211,

        WM_EXITMENULOOP = 0x0212,

        WM_NEXTMENU = 0x0213,

        WM_SIZING = 0x0214,

        WM_CAPTURECHANGED = 0x0215,

        WM_MOVING = 0x0216,

        WM_POWERBROADCAST = 0x0218,

        WM_DEVICECHANGE = 0x0219,

        WM_MDICREATE = 0x0220,

        WM_MDIDESTROY = 0x0221,

        WM_MDIACTIVATE = 0x0222,

        WM_MDIRESTORE = 0x0223,

        WM_MDINEXT = 0x0224,

        WM_MDIMAXIMIZE = 0x0225,

        WM_MDITILE = 0x0226,

        WM_MDICASCADE = 0x0227,

        WM_MDIICONARRANGE = 0x0228,

        WM_MDIGETACTIVE = 0x0229,

        WM_DROPOBJECT = 0x022A,

        WM_QUERYDROPOBJECT = 0x022B,

        WM_BEGINDRAG = 0x022C,

        WM_DRAGLOOP = 0x022D,

        WM_DRAGSELECT = 0x022E,

        WM_DRAGMOVE = 0x022F,

        WM_MDISETMENU = 0x0230,

        WM_ENTERSIZEMOVE = 0x0231,

        WM_EXITSIZEMOVE = 0x0232,

        WM_DROPFILES = 0x0233,

        WM_MDIREFRESHMENU = 0x0234,

        WM_POINTERDEVICECHANGE = 0x0238,

        WM_POINTERDEVICEINRANGE = 0x0239,

        WM_POINTERDEVICEOUTOFRANGE = 0x023A,

        WM_STOPINERTIA = 0x023B,

        WM_ENDINERTIA = 0x023C,

        WM_EDGYINERTIA = 0x023D,

        WM_TOUCH = 0x0240,

        WM_NCPOINTERUPDATE = 0x0241,

        WM_NCPOINTERDOWN = 0x0242,

        WM_NCPOINTERUP = 0x0243,

        WM_NCPOINTERLAST = 0x0244,

        WM_POINTERUPDATE = 0x0245,

        WM_POINTERDOWN = 0x0246,

        WM_POINTERUP = 0x0247,

        WM_POINTER_reserved_248 = 0x0248,

        WM_POINTERENTER = 0x0249,

        WM_POINTERLEAVE = 0x024A,

        WM_POINTERACTIVATE = 0x024B,

        WM_POINTERCAPTURECHANGED = 0x024C,

        WM_TOUCHHITTESTING = 0x024D,

        WM_POINTERWHEEL = 0x024E,

        WM_POINTERHWHEEL = 0x024F,

        WM_POINTER_reserved_250 = 0x0250,

        WM_POINTER_reserved_251 = 0x0251,

        WM_POINTER_reserved_252 = 0x0252,

        WM_POINTER_reserved_253 = 0x0253,

        WM_POINTER_reserved_254 = 0x0254,

        WM_POINTER_reserved_255 = 0x0255,

        WM_POINTER_reserved_256 = 0x0256,

        WM_POINTERLAST = 0x0257,

        WM_VISIBILITYCHANGED = 0x0270,

        WM_VIEWSTATECHANGED = 0x0271,

        WM_UNREGISTER_WINDOW_SERVICES = 0x0272,

        WM_CONSOLIDATED = 0x0273,

        WM_IME_REPORT = 0x0280,

        WM_IME_SETCONTEXT = 0x0281,

        WM_IME_NOTIFY = 0x0282,

        WM_IME_CONTROL = 0x0283,

        WM_IME_COMPOSITIONFULL = 0x0284,

        WM_IME_SELECT = 0x0285,

        WM_IME_CHAR = 0x0286,

        WM_IME_SYSTEM = 0x0287,

        WM_IME_REQUEST = 0x0288,

        WM_KANJI_reserved_289 = 0x0289,

        WM_KANJI_reserved_28a = 0x028A,

        WM_KANJI_reserved_28b = 0x028B,

        WM_KANJI_reserved_28c = 0x028C,

        WM_KANJI_reserved_28d = 0x028D,

        WM_KANJI_reserved_28e = 0x028E,

        WM_KANJI_reserved_28f = 0x028F,

        WM_IME_KEYDOWN = 0x0290,

        WM_IME_KEYUP = 0x0291,

        WM_KANJI_reserved_292 = 0x0292,

        WM_KANJI_reserved_293 = 0x0293,

        WM_KANJI_reserved_294 = 0x0294,

        WM_KANJI_reserved_295 = 0x0295,

        WM_KANJI_reserved_296 = 0x0296,

        WM_KANJI_reserved_297 = 0x0297,

        WM_KANJI_reserved_298 = 0x0298,

        WM_KANJI_reserved_299 = 0x0299,

        WM_KANJI_reserved_29a = 0x029A,

        WM_KANJI_reserved_29b = 0x029B,

        WM_KANJI_reserved_29c = 0x029C,

        WM_KANJI_reserved_29d = 0x029D,

        WM_KANJI_reserved_29e = 0x029E,

        WM_KANJILAST = 0x029F,

        WM_NCMOUSEHOVER = 0x02A0,

        WM_MOUSEHOVER = 0x02A1,

        WM_NCMOUSELEAVE = 0x02A2,

        WM_MOUSELEAVE = 0x02A3,

        WM_TRACKMOUSEEVENT__reserved_2a4 = 0x02A4,

        WM_TRACKMOUSEEVENT__reserved_2a5 = 0x02A5,

        WM_TRACKMOUSEEVENT__reserved_2a6 = 0x02A6,

        WM_TRACKMOUSEEVENT__reserved_2a7 = 0x02A7,

        WM_TRACKMOUSEEVENT__reserved_2a8 = 0x02A8,

        WM_TRACKMOUSEEVENT__reserved_2a9 = 0x02A9,

        WM_TRACKMOUSEEVENT__reserved_2aa = 0x02AA,

        WM_TRACKMOUSEEVENT__reserved_2ab = 0x02AB,

        WM_TRACKMOUSEEVENT__reserved_2ac = 0x02AC,

        WM_TRACKMOUSEEVENT__reserved_2ad = 0x02AD,

        WM_TRACKMOUSEEVENT__reserved_2ae = 0x02AE,

        WM_TRACKMOUSEEVENT_LAST = 0x02AF,

        WM_WTSSESSION_CHANGE = 0x02B1,

        WM_TABLET_FIRST = 0x02C0,

        WM_TABLET__reserved_2c1 = 0x02C1,

        WM_TABLET__reserved_2c2 = 0x02C2,

        WM_TABLET__reserved_2c3 = 0x02C3,

        WM_TABLET__reserved_2c4 = 0x02C4,

        WM_TABLET__reserved_2c5 = 0x02C5,

        WM_TABLET__reserved_2c6 = 0x02C6,

        WM_TABLET__reserved_2c7 = 0x02C7,

        WM_POINTERDEVICEADDED = 0x02C8,

        WM_POINTERDEVICEDELETED = 0x02C9,

        WM_TABLET__reserved_2ca = 0x02CA,

        WM_FLICK = 0x02CB,

        WM_TABLET__reserved_2cc = 0x02CC,

        WM_FLICKINTERNAL = 0x02CD,

        WM_BRIGHTNESSCHANGED = 0x02CE,

        WM_TABLET__reserved_2cf = 0x02CF,

        WM_TABLET__reserved_2d0 = 0x02D0,

        WM_TABLET__reserved_2d1 = 0x02D1,

        WM_TABLET__reserved_2d2 = 0x02D2,

        WM_TABLET__reserved_2d3 = 0x02D3,

        WM_TABLET__reserved_2d4 = 0x02D4,

        WM_TABLET__reserved_2d5 = 0x02D5,

        WM_TABLET__reserved_2d6 = 0x02D6,

        WM_TABLET__reserved_2d7 = 0x02D7,

        WM_TABLET__reserved_2d8 = 0x02D8,

        WM_TABLET__reserved_2d9 = 0x02D9,

        WM_TABLET__reserved_2da = 0x02DA,

        WM_TABLET__reserved_2db = 0x02DB,

        WM_TABLET__reserved_2dc = 0x02DC,

        WM_TABLET__reserved_2dd = 0x02DD,

        WM_TABLET__reserved_2de = 0x02DE,

        WM_TABLET_LAST = 0x02DF,

        WM_DPICHANGED = 0x02E0,

        WM_DPICHANGED_BEFOREPARENT = 0x02E2,

        WM_DPICHANGED_AFTERPARENT = 0x02E3,

        WM_GETDPISCALEDSIZE = 0x02E4,

        WM_CUT = 0x0300,

        WM_COPY = 0x0301,

        WM_PASTE = 0x0302,

        WM_CLEAR = 0x0303,

        WM_UNDO = 0x0304,

        WM_RENDERFORMAT = 0x0305,

        WM_RENDERALLFORMATS = 0x0306,

        WM_DESTROYCLIPBOARD = 0x0307,

        WM_DRAWCLIPBOARD = 0x0308,

        WM_PAINTCLIPBOARD = 0x0309,

        WM_VSCROLLCLIPBOARD = 0x030A,

        WM_SIZECLIPBOARD = 0x030B,

        WM_ASKCBFORMATNAME = 0x030C,

        WM_CHANGECBCHAIN = 0x030D,

        WM_HSCROLLCLIPBOARD = 0x030E,

        WM_QUERYNEWPALETTE = 0x030F,

        WM_PALETTEISCHANGING = 0x0310,

        WM_PALETTECHANGED = 0x0311,

        WM_HOTKEY = 0x0312,

        WM_SYSMENU = 0x0313,

        WM_HOOKMSG = 0x0314,

        WM_EXITPROCESS = 0x0315,

        WM_WAKETHREAD = 0x0316,

        WM_PRINT = 0x0317,

        WM_PRINTCLIENT = 0x0318,

        WM_APPCOMMAND = 0x0319,

        WM_THEMECHANGED = 0x031A,

        WM_UAHINIT = 0x031B,

        WM_DESKTOPNOTIFY = 0x031C,

        WM_CLIPBOARDUPDATE = 0x031D,

        WM_DWMCOMPOSITIONCHANGED = 0x031E,

        WM_DWMNCRENDERINGCHANGED = 0x031F,

        WM_DWMCOLORIZATIONCOLORCHANGED = 0x0320,

        WM_DWMWINDOWMAXIMIZEDCHANGE = 0x0321,

        WM_DWMEXILEFRAME = 0x0322,

        WM_DWMSENDICONICTHUMBNAIL = 0x0323,

        WM_MAGNIFICATION_STARTED = 0x0324,

        WM_MAGNIFICATION_ENDED = 0x0325,

        WM_DWMSENDICONICLIVEPREVIEWBITMAP = 0x0326,

        WM_DWMTHUMBNAILSIZECHANGED = 0x0327,

        WM_MAGNIFICATION_OUTPUT = 0x0328,

        WM_BSDRDATA = 0x0329,

        WM_DWMTRANSITIONSTATECHANGED = 0x032A,

        WM_KEYBOARDCORRECTIONCALLOUT = 0x032C,

        WM_KEYBOARDCORRECTIONACTION = 0x032D,

        WM_UIACTION = 0x032E,

        WM_ROUTED_UI_EVENT = 0x032F,

        WM_MEASURECONTROL = 0x0330,

        WM_GETACTIONTEXT = 0x0331,

        WM_CE_ONLY__reserved_332 = 0x0332,

        WM_FORWARDKEYDOWN = 0x0333,

        WM_FORWARDKEYUP = 0x0334,

        WM_CE_ONLY__reserved_335 = 0x0335,

        WM_CE_ONLY__reserved_336 = 0x0336,

        WM_CE_ONLY__reserved_337 = 0x0337,

        WM_CE_ONLY__reserved_338 = 0x0338,

        WM_CE_ONLY__reserved_339 = 0x0339,

        WM_CE_ONLY__reserved_33a = 0x033A,

        WM_CE_ONLY__reserved_33b = 0x033B,

        WM_CE_ONLY__reserved_33c = 0x033C,

        WM_CE_ONLY__reserved_33d = 0x033D,

        WM_CE_ONLY_LAST = 0x033E,

        WM_GETTITLEBARINFOEX = 0x033F,

        WM_NOTIFYWOW = 0x0340,

        WM_HANDHELDFIRST = 0x0358,

        WM_HANDHELD_reserved_359 = 0x0359,

        WM_HANDHELD_reserved_35a = 0x035A,

        WM_HANDHELD_reserved_35b = 0x035B,

        WM_HANDHELD_reserved_35c = 0x035C,

        WM_HANDHELD_reserved_35d = 0x035D,

        WM_HANDHELD_reserved_35e = 0x035E,

        WM_HANDHELDLAST = 0x035F,

        WM_AFXFIRST = 0x0360,

        WM_AFX_reserved_361 = 0x0361,

        WM_AFX_reserved_362 = 0x0362,

        WM_AFX_reserved_363 = 0x0363,

        WM_AFX_reserved_364 = 0x0364,

        WM_AFX_reserved_365 = 0x0365,

        WM_AFX_reserved_366 = 0x0366,

        WM_AFX_reserved_367 = 0x0367,

        WM_AFX_reserved_368 = 0x0368,

        WM_AFX_reserved_369 = 0x0369,

        WM_AFX_reserved_36a = 0x036A,

        WM_AFX_reserved_36b = 0x036B,

        WM_AFX_reserved_36c = 0x036C,

        WM_AFX_reserved_36d = 0x036D,

        WM_AFX_reserved_36e = 0x036E,

        WM_AFX_reserved_36f = 0x036F,

        WM_AFX_reserved_370 = 0x0370,

        WM_AFX_reserved_371 = 0x0371,

        WM_AFX_reserved_372 = 0x0372,

        WM_AFX_reserved_373 = 0x0373,

        WM_AFX_reserved_374 = 0x0374,

        WM_AFX_reserved_375 = 0x0375,

        WM_AFX_reserved_376 = 0x0376,

        WM_AFX_reserved_377 = 0x0377,

        WM_AFX_reserved_378 = 0x0378,

        WM_AFX_reserved_379 = 0x0379,

        WM_AFX_reserved_37a = 0x037A,

        WM_AFX_reserved_37b = 0x037B,

        WM_AFX_reserved_37c = 0x037C,

        WM_AFX_reserved_37d = 0x037D,

        WM_AFX_reserved_37e = 0x037E,

        WM_AFXLAST = 0x037F,

        WM_PENWINFIRST = 0x0380,

        WM_PENWIN_reserved_381 = 0x0381,

        WM_PENWIN_reserved_382 = 0x0382,

        WM_PENWIN_reserved_383 = 0x0383,

        WM_PENWIN_reserved_384 = 0x0384,

        WM_PENWIN_reserved_385 = 0x0385,

        WM_PENWIN_reserved_386 = 0x0386,

        WM_PENWIN_reserved_387 = 0x0387,

        WM_PENWIN_reserved_388 = 0x0388,

        WM_PENWIN_reserved_389 = 0x0389,

        WM_PENWIN_reserved_38a = 0x038A,

        WM_PENWIN_reserved_38b = 0x038B,

        WM_PENWIN_reserved_38c = 0x038C,

        WM_PENWIN_reserved_38d = 0x038D,

        WM_PENWIN_reserved_38e = 0x038E,

        WM_PENWINLAST = 0x038F,

        WM_COALESCE_FIRST = 0x0390,

        WM_COALESCE__reserved_391 = 0x0391,

        WM_COALESCE__reserved_392 = 0x0392,

        WM_COALESCE__reserved_393 = 0x0393,

        WM_COALESCE__reserved_394 = 0x0394,

        WM_COALESCE__reserved_395 = 0x0395,

        WM_COALESCE__reserved_396 = 0x0396,

        WM_COALESCE__reserved_397 = 0x0397,

        WM_COALESCE__reserved_398 = 0x0398,

        WM_COALESCE__reserved_399 = 0x0399,

        WM_COALESCE__reserved_39a = 0x039A,

        WM_COALESCE__reserved_39b = 0x039B,

        WM_COALESCE__reserved_39c = 0x039C,

        WM_COALESCE__reserved_39d = 0x039D,

        WM_COALESCE__reserved_39e = 0x039E,

        WM_COALESCE_LAST = 0x039F,

        WM_MM_RESERVED_FIRST = 0x03A0,

        WM_MM_RESERVED__reserved_3a1 = 0x03A1,

        WM_MM_RESERVED__reserved_3a2 = 0x03A2,

        WM_MM_RESERVED__reserved_3a3 = 0x03A3,

        WM_MM_RESERVED__reserved_3a4 = 0x03A4,

        WM_MM_RESERVED__reserved_3a5 = 0x03A5,

        WM_MM_RESERVED__reserved_3a6 = 0x03A6,

        WM_MM_RESERVED__reserved_3a7 = 0x03A7,

        WM_MM_RESERVED__reserved_3a8 = 0x03A8,

        WM_MM_RESERVED__reserved_3a9 = 0x03A9,

        WM_MM_RESERVED__reserved_3aA = 0x03AA,

        WM_MM_RESERVED__reserved_3ab = 0x03AB,

        WM_MM_RESERVED__reserved_3ac = 0x03AC,

        WM_MM_RESERVED__reserved_3ad = 0x03AD,

        WM_MM_RESERVED__reserved_3ae = 0x03AE,

        WM_MM_RESERVED__reserved_3af = 0x03AF,

        WM_MM_RESERVED__reserved_3b0 = 0x03B0,

        WM_MM_RESERVED__reserved_3b1 = 0x03B1,

        WM_MM_RESERVED__reserved_3b2 = 0x03B2,

        WM_MM_RESERVED__reserved_3b3 = 0x03B3,

        WM_MM_RESERVED__reserved_3b4 = 0x03B4,

        WM_MM_RESERVED__reserved_3b5 = 0x03B5,

        WM_MM_RESERVED__reserved_3b6 = 0x03B6,

        WM_MM_RESERVED__reserved_3b7 = 0x03B7,

        WM_MM_RESERVED__reserved_3b8 = 0x03B8,

        WM_MM_RESERVED__reserved_3b9 = 0x03B9,

        WM_MM_RESERVED__reserved_3ba = 0x03BA,

        WM_MM_RESERVED__reserved_3bb = 0x03BB,

        WM_MM_RESERVED__reserved_3bc = 0x03BC,

        WM_MM_RESERVED__reserved_3bd = 0x03BD,

        WM_MM_RESERVED__reserved_3be = 0x03BE,

        WM_MM_RESERVED__reserved_3bf = 0x03BF,

        WM_MM_RESERVED__reserved_3c0 = 0x03C0,

        WM_MM_RESERVED__reserved_3c1 = 0x03C1,

        WM_MM_RESERVED__reserved_3c2 = 0x03C2,

        WM_MM_RESERVED__reserved_3c3 = 0x03C3,

        WM_MM_RESERVED__reserved_3c4 = 0x03C4,

        WM_MM_RESERVED__reserved_3c5 = 0x03C5,

        WM_MM_RESERVED__reserved_3c6 = 0x03C6,

        WM_MM_RESERVED__reserved_3c7 = 0x03C7,

        WM_MM_RESERVED__reserved_3c8 = 0x03C8,

        WM_MM_RESERVED__reserved_3c9 = 0x03C9,

        WM_MM_RESERVED__reserved_3ca = 0x03CA,

        WM_MM_RESERVED__reserved_3cb = 0x03CB,

        WM_MM_RESERVED__reserved_3cc = 0x03CC,

        WM_MM_RESERVED__reserved_3cd = 0x03CD,

        WM_MM_RESERVED__reserved_3ce = 0x03CE,

        WM_MM_RESERVED__reserved_3cf = 0x03CF,

        WM_MM_RESERVED__reserved_3d0 = 0x03D0,

        WM_MM_RESERVED__reserved_3d1 = 0x03D1,

        WM_MM_RESERVED__reserved_3d2 = 0x03D2,

        WM_MM_RESERVED__reserved_3d3 = 0x03D3,

        WM_MM_RESERVED__reserved_3d4 = 0x03D4,

        WM_MM_RESERVED__reserved_3d5 = 0x03D5,

        WM_MM_RESERVED__reserved_3d6 = 0x03D6,

        WM_MM_RESERVED__reserved_3d7 = 0x03D7,

        WM_MM_RESERVED__reserved_3d8 = 0x03D8,

        WM_MM_RESERVED__reserved_3d9 = 0x03D9,

        WM_MM_RESERVED__reserved_3da = 0x03DA,

        WM_MM_RESERVED__reserved_3db = 0x03DB,

        WM_MM_RESERVED__reserved_3dc = 0x03DC,

        WM_MM_RESERVED__reserved_3dd = 0x03DD,

        WM_MM_RESERVED__reserved_3de = 0x03DE,

        WM_MM_RESERVED_LAST = 0x03DF,

        WM_INTERNAL_DDE_FIRST = 0x03E0,

        WM_INTERNAL_DDE__reserved_3e1 = 0x03E1,

        WM_INTERNAL_DDE__reserved_3e2 = 0x03E2,

        WM_INTERNAL_DDE__reserved_3e3 = 0x03E3,

        WM_INTERNAL_DDE__reserved_3e4 = 0x03E4,

        WM_INTERNAL_DDE__reserved_3e5 = 0x03E5,

        WM_INTERNAL_DDE__reserved_3e6 = 0x03E6,

        WM_INTERNAL_DDE__reserved_3e7 = 0x03E7,

        WM_INTERNAL_DDE__reserved_3e8 = 0x03E8,

        WM_INTERNAL_DDE__reserved_3e9 = 0x03E9,

        WM_INTERNAL_DDE__reserved_3ea = 0x03EA,

        WM_INTERNAL_DDE__reserved_3eb = 0x03EB,

        WM_INTERNAL_DDE__reserved_3ec = 0x03EC,

        WM_INTERNAL_DDE__reserved_3ed = 0x03ED,

        WM_INTERNAL_DDE__reserved_3ee = 0x03EE,

        WM_INTERNAL_DDE_LAST = 0x03EF,

        WM_CBT_RESERVED_FIRST = 0x03F0,

        WM_CBT_RESERVED__reserved_3f1 = 0x03F1,

        WM_CBT_RESERVED__reserved_3f2 = 0x03F2,

        WM_CBT_RESERVED__reserved_3f3 = 0x03F3,

        WM_CBT_RESERVED__reserved_3f4 = 0x03F4,

        WM_CBT_RESERVED__reserved_3f5 = 0x03F5,

        WM_CBT_RESERVED__reserved_3f6 = 0x03F6,

        WM_CBT_RESERVED__reserved_3f7 = 0x03F7,

        WM_CBT_RESERVED__reserved_3f8 = 0x03F8,

        WM_CBT_RESERVED__reserved_3f9 = 0x03F9,

        WM_CBT_RESERVED__reserved_3fa = 0x03FA,

        WM_CBT_RESERVED__reserved_3fb = 0x03FB,

        WM_CBT_RESERVED__reserved_3fc = 0x03FC,

        WM_CBT_RESERVED__reserved_3fd = 0x03FD,

        WM_CBT_RESERVED__reserved_3fe = 0x03FE,

        WM_CBT_RESERVED_LAST = 0x03FF,

        WM_USER = 0x0400,

        WM_APP = 0x8000,
    }
}
