using System;
using System.Collections; 
using System.Collections.Generic;
using System.Windows.Forms;
using GTA;
using GTA.Math;
using GTA.Native;
using System.Numerics;
public class BlipsCreator : Script {
    ScriptSettings IniSettings;
    Vector3 BatteriaCoords = new Vector3 (-2451f, 2979f, 30f); //red
    Vector3 AvengerCoords = new Vector3 (-1845f, -3148f, 30f); //red
    Vector3 DeluxoCoords = new Vector3 (3578f, 3658f, 30f); //red
    Vector3 APCCoords = new Vector3 (-1888f, 2950f, 30f); //red
    Vector3 RuinerCoords = new Vector3 (1358f, -2095f, 30f); //red
    Vector3 ApacheCoords = new Vector3 (-1051f, -3489f, 30f); //red
    Vector3 ValkyrieCoords = new Vector3 (503f, -3375f, 30f); //red
    Vector3 UfficioCoords = new Vector3 (-80f, -837f, 30f); //red
    /// <summary>
    /// ////////////////////////YELLOW
    /// </summary>
    Vector3 MigCoords = new Vector3 (1706f, 3252f, 30f); //yellow
    Vector3 KanjaliCoords = new Vector3 (-2192f, 3298f, 30f); //yellow
    Vector3 AircraftCarrierCoords = new Vector3 (3083.465f, -4659.136f, 30f); //yellow
    Vector3 SottomarinoCoords = new Vector3 (-1291f, 6855f, 30f); //yellow
    Vector3 ZancudoCoords = new Vector3 (-2317f, 3396f, 30f); //yellow
    Vector3 IAACoords = new Vector3 (2053f, 2947f, 30F); //yellow
    Vector3 BankCoords = new Vector3 (230f, 213f, 105f);
    /// <summary>
    /// ///////////////WHITE
    /// </summary>
    Vector3 LifeCoords = new Vector3 (-1079f, -262f, 30f); //white
    Vector3 LabCoords = new Vector3 (3421f, 3757f, 30f); //white
    Vector3 Casino = new Vector3 (922f, 47f, 80f);
    /// <summary>
    /// //////////////PINK
    /// </summary>
    Vector3 PlayboyCoords = new Vector3 (-1469f, 65f, 30f); //pink
    /// <summary>
    /// //////////////////PURPLE
    /// </summary>
    Vector3 MazeCoords = new Vector3 (-164f, -2009f, 30f); //purple
    Vector3 [] ThaterCoords = new [] { new Vector3 (232f, 1170f, 30f), new Vector3 (650f, 585f, 30f) };
    /// <summary>
    /// /////////////////////ORANGE
    /// </summary>
    Vector3 [] FireDepartment = new [] { new Vector3 (-655f, -116f, 30f), new Vector3 (-385f, 6135f, 30f), new Vector3 (1200f, -1452f, 30f), new Vector3 (222f, -1636f, 30f) };
    /// <summary>
    /// //////////////////////GREEN
    /// </summary>
    Vector3 [] HospitalCoords = new [] { new Vector3 (293f, -585f, 30f), new Vector3 (282f, -1419f, 30f), new Vector3 (1842f, 3668f, 30f), new Vector3 (-228f, 6316f, 30f), new Vector3 (-468f, -359f, 30f) };
    Vector3 BaseCoords = new Vector3 (-361f, 4827f, 30f); //green
    Vector3 ServerCoords = new Vector3 (2480f, -405f, 30f); //green
    /// <summary>
    /// ////////////////////////BLUE
    /// </summary>
    Vector3 [] PoliceCoords = new [] { new Vector3 (655f, -15f, 30f), new Vector3 (811f, -1288f, 30f), new Vector3 (404f, -1605f, 30f), new Vector3 (-1052f, -802f, 18f), new Vector3 (-556f, -145f, 30f), new Vector3 (-431f, 6041f, 30f), new Vector3 (1859f, 3680f, 30f), new Vector3 (424f, -980f, 30f) };
    Vector3 [] YatchCoords = new [] { new Vector3 (-2061f, -1024f, 30f), new Vector3 (-1407f, 6748f, 30f) };
    Vector3 PrigioneCoords = new Vector3 (1853f, 2605f, 30f); //blue
    Vector3 SetCoords = new Vector3 (-1215f, -582f, 30f); //blue
    Vector3 FIBCoords = new Vector3 (66f, -735f, 30f); //blue
    Vector3 OsservatorioCoords = new Vector3 (-412f, 1170f, 30f); //blue
    Vector3 BennyCoords = new Vector3 (-206f, -1312f, 30f);
    /////////////////////////// OTHER
    Vector3 IppodromoCoords = new Vector3 (1120f, 231f, 80f);
    Vector3 [] AddBlipsCoords = new Vector3 [12];
    //////////////////////////
    int pos = 0, lenght, hud_colour = -1, hud1 = -1, hud2 = -2, Facility_Number = 0;
    float Xb = 100f, Yb = 100f;
    string Language = "it";
    bool GPS, MODActive = true, Special_Blip = true, Facility = false, Police = false, Hospital = false, Online = true, Fire = false, Persistence = false, GPSColour = true, GPSSprite = true, First = true, _blipReloaded = false;
    static bool [] AddBlip = new bool [12];
    static float [] X_Blip = new float [12];
    static float [] Y_Blip = new float [12];
    static float [] Z_Blip = new float [12];
    static int [] Blip_Sptite = new int [12];
    static int [] Blip_Colour = new int [12];
    static string [] Blip_Name = new string [12];
    static bool [] Facility_Active = new bool [9];
    static string [] Facility_Name = new string [9];
    static int [] Facility_Sprite = new int [9];
    static int [] Facility_Colour = new int [9];
    static float [] _X_Facility = new float [] { 1885f, 1271f, 2088f, 2754f, 1f, -2228f, -1f, 21f, 3387f };
    static float [] _Y_Facility = new float [] { 303f, 2833f, 1761f, 3904f, 2509f, 2399f, 3347f, 6824f, 5509f };
    static float [] _Z_Facility = new float [] { 30f, 30f, 30f, 30f, 30f, 30f, 30f, 30f, 30f };
    static string [] LanguageNameBlip = new string [24];
    static Blip [] AddedBlip = new Blip [12];
    bool first = true;
    List<Blip> _modBlips;

    public BlipsCreator () {
        IniSettings = ScriptSettings.Load ("scripts\\AddBlips.ini");
        GPSColour = IniSettings.GetValue<bool> ("General", "GPS_Colour", true);
        GPSSprite = IniSettings.GetValue<bool> ("General", "GPS_Sprite", true);
        Language = IniSettings.GetValue<string> ("General", "Language", "it");
        MODActive = IniSettings.GetValue<bool> ("General", "MODActive", true);
        Special_Blip = IniSettings.GetValue<bool> ("General", "Special_Location_Blips", true);
        Police = IniSettings.GetValue<bool> ("General", "Police_Station_Blips", true);
        Hospital = IniSettings.GetValue<bool> ("General", "Hospital_Blips", true);
        Fire = IniSettings.GetValue<bool> ("General", "Fire_Station_Blips", true);
        Online = IniSettings.GetValue<bool> ("General", "Online_Blips", true);
        //Persistence = IniSettings.GetValue<bool> ("General", "Persistence_Vehicle_Blips", false);

        ////////////////////////////////////////////////////////////////////////////////////////////////// 
        AddBlip [0] = IniSettings.GetValue<bool> ("Blip1", "Active", false);
        X_Blip [0] = IniSettings.GetValue ("Blip1", "X", 0f);
        Y_Blip [0] = IniSettings.GetValue ("Blip1", "Y", 0f);
        Z_Blip [0] = IniSettings.GetValue ("Blip1", "Z", 0f);
        Blip_Name [0] = IniSettings.GetValue<string> ("Blip1", "Custom_Name", "Blip1");
        Blip_Sptite [0] = IniSettings.GetValue<int> ("Blip1", "Custom_Sprite", 1);
        Blip_Colour [0] = IniSettings.GetValue<int> ("Blip1", "Custom_Colour", 1);
        /////////////////////////////////////////////////////////////////////////////////////////////////
        AddBlip [1] = IniSettings.GetValue<bool> ("Blip2", "Active", false);
        X_Blip [1] = IniSettings.GetValue ("Blip2", "X", 0f);
        Y_Blip [1] = IniSettings.GetValue ("Blip2", "Y", 0f);
        Z_Blip [1] = IniSettings.GetValue ("Blip2", "Z", 0f);
        Blip_Name [1] = IniSettings.GetValue<string> ("Blip2", "Custom_Name", "Blip2");
        Blip_Sptite [1] = IniSettings.GetValue<int> ("Blip2", "Custom_Sprite", 1);
        Blip_Colour [1] = IniSettings.GetValue<int> ("Blip2", "Custom_Colour", 1);
        /////////////////////////////////////////////////////////////////////////////////////////////////
        AddBlip [2] = IniSettings.GetValue<bool> ("Blip3", "Active", false);
        X_Blip [2] = IniSettings.GetValue ("Blip3", "X", 0f);
        Y_Blip [2] = IniSettings.GetValue ("Blip3", "Y", 0f);
        Z_Blip [2] = IniSettings.GetValue ("Blip3", "Z", 0f);
        Blip_Name [2] = IniSettings.GetValue<string> ("Blip3", "Custom_Name", "Blip3");
        Blip_Sptite [2] = IniSettings.GetValue<int> ("Blip3", "Custom_Sprite", 1);
        Blip_Colour [2] = IniSettings.GetValue<int> ("Blip3", "Custom_Colour", 1);
        /////////////////////////////////////////////////////////////////////////////////////////////////
        AddBlip [3] = IniSettings.GetValue<bool> ("Blip4", "Active", false);
        X_Blip [3] = IniSettings.GetValue<float> ("Blip4", "X", 0f);
        Y_Blip [3] = IniSettings.GetValue<float> ("Blip4", "Y", 0f);
        Z_Blip [3] = IniSettings.GetValue<float> ("Blip4", "Z", 0f);
        Blip_Name [3] = IniSettings.GetValue<string> ("Blip4", "Custom_Name", "Blip4");
        Blip_Sptite [3] = IniSettings.GetValue<int> ("Blip4", "Custom_Sprite", 1);
        Blip_Colour [3] = IniSettings.GetValue<int> ("Blip4", "Custom_Colour", 1);
        /////////////////////////////////////////////////////////////////////////////////////////////////
        AddBlip [4] = IniSettings.GetValue<bool> ("Blip5", "Active", false);
        X_Blip [4] = IniSettings.GetValue<float> ("Blip5", "X", 0f);
        Y_Blip [4] = IniSettings.GetValue<float> ("Blip5", "Y", 0f);
        Z_Blip [4] = IniSettings.GetValue<float> ("Blip5", "Z", 0f);
        Blip_Name [4] = IniSettings.GetValue<string> ("Blip5", "Custom_Name", "Blip5");
        Blip_Sptite [4] = IniSettings.GetValue<int> ("Blip5", "Custom_Sprite", 1);
        Blip_Colour [4] = IniSettings.GetValue<int> ("Blip5", "Custom_Colour", 1);
        /////////////////////////////////////////////////////////////////////////////////////////////////
        AddBlip [5] = IniSettings.GetValue<bool> ("Blip6", "Active", false);
        X_Blip [5] = IniSettings.GetValue<float> ("Blip6", "X", 0f);
        Y_Blip [5] = IniSettings.GetValue<float> ("Blip6", "Y", 0f);
        Z_Blip [5] = IniSettings.GetValue<float> ("Blip6", "Z", 0f);
        Blip_Name [5] = IniSettings.GetValue<string> ("Blip6", "Custom_Name", "Blip6");
        Blip_Sptite [5] = IniSettings.GetValue<int> ("Blip6", "Custom_Sprite", 1);
        Blip_Colour [5] = IniSettings.GetValue<int> ("Blip6", "Custom_Colour", 1);
        /////////////////////////////////////////////////////////////////////////////////////////////////
        AddBlip [6] = IniSettings.GetValue<bool> ("Blip7", "Active", false);
        X_Blip [6] = IniSettings.GetValue<float> ("Blip7", "X", 0f);
        Y_Blip [6] = IniSettings.GetValue<float> ("Blip7", "Y", 0f);
        Z_Blip [6] = IniSettings.GetValue<float> ("Blip7", "Z", 0f);
        Blip_Name [6] = IniSettings.GetValue<string> ("Blip7", "Custom_Name", "Blip7");
        Blip_Sptite [6] = IniSettings.GetValue<int> ("Blip7", "Custom_Sprite", 1);
        Blip_Colour [6] = IniSettings.GetValue<int> ("Blip7", "Custom_Colour", 1);
        /////////////////////////////////////////////////////////////////////////////////////////////////
        AddBlip [7] = IniSettings.GetValue<bool> ("Blip8", "Active", false);
        X_Blip [7] = IniSettings.GetValue<float> ("Blip8", "X", 0f);
        Y_Blip [7] = IniSettings.GetValue<float> ("Blip8", "Y", 0f);
        Z_Blip [7] = IniSettings.GetValue<float> ("Blip8", "Z", 0f);
        Blip_Name [7] = IniSettings.GetValue<string> ("Blip8", "Custom_Name", "Blip8");
        Blip_Sptite [7] = IniSettings.GetValue<int> ("Blip8", "Custom_Sprite", 1);
        Blip_Colour [7] = IniSettings.GetValue<int> ("Blip8", "Custom_Colour", 1);
        /////////////////////////////////////////////////////////////////////////////////////////////////
        AddBlip [8] = IniSettings.GetValue<bool> ("Blip9", "Active", false);
        X_Blip [8] = IniSettings.GetValue<float> ("Blip9", "X", 0f);
        Y_Blip [8] = IniSettings.GetValue<float> ("Blip9", "Y", 0f);
        Z_Blip [8] = IniSettings.GetValue<float> ("Blip9", "Z", 0f);
        Blip_Name [8] = IniSettings.GetValue<string> ("Blip9", "Custom_Name", "Blip9");
        Blip_Sptite [8] = IniSettings.GetValue<int> ("Blip9", "Custom_Sprite", 1);
        Blip_Colour [8] = IniSettings.GetValue<int> ("Blip9", "Custom_Colour", 1);
        /////////////////////////////////////////////////////////////////////////////////////////////////
        AddBlip [9] = IniSettings.GetValue<bool> ("Blip10", "Active", false);
        X_Blip [9] = IniSettings.GetValue<float> ("Blip10", "X", 0f);
        Y_Blip [9] = IniSettings.GetValue<float> ("Blip10", "Y", 0f);
        Z_Blip [9] = IniSettings.GetValue<float> ("Blip10", "Z", 0f);
        Blip_Name [9] = IniSettings.GetValue<string> ("Blip10", "Custom_Name", "Blip10");
        Blip_Sptite [9] = IniSettings.GetValue<int> ("Blip10", "Custom_Sprite", 1);
        Blip_Colour [9] = IniSettings.GetValue<int> ("Blip10", "Custom_Colour", 1);
        /////////////////////////////////////////////////////////////////////////////////////////////////
        AddBlip [10] = IniSettings.GetValue<bool> ("Blip11", "Active", false);
        X_Blip [10] = IniSettings.GetValue<float> ("Blip11", "X", 0f);
        Y_Blip [10] = IniSettings.GetValue<float> ("Blip11", "Y", 0f);
        Z_Blip [10] = IniSettings.GetValue<float> ("Blip11", "Z", 0f);
        Blip_Name [10] = IniSettings.GetValue<string> ("Blip11", "Custom_Name", "Blip11");
        Blip_Sptite [10] = IniSettings.GetValue<int> ("Blip11", "Custom_Sprite", 1);
        Blip_Colour [10] = IniSettings.GetValue<int> ("Blip11", "Custom_Colour", 1);
        /////////////////////////////////////////////////////////////////////////////////////////////////
        AddBlip [11] = IniSettings.GetValue<bool> ("Blip12", "Active", false);
        X_Blip [11] = IniSettings.GetValue<float> ("Blip12", "X", 0f);
        Y_Blip [11] = IniSettings.GetValue<float> ("Blip12", "Y", 0f);
        Z_Blip [11] = IniSettings.GetValue<float> ("Blip12", "Z", 0f);
        Blip_Name [11] = IniSettings.GetValue<string> ("Blip12", "Custom_Name", "Blip12");
        Blip_Sptite [11] = IniSettings.GetValue<int> ("Blip12", "Custom_Sprite", 1);
        Blip_Colour [11] = IniSettings.GetValue<int> ("Blip12", "Custom_Colour", 1);

        /////////////////////////////////////////////////////////////////////////////////////////////////
        Facility_Active [0] = IniSettings.GetValue<bool> ("Reservoir", "Active", false);
        Facility_Name [0] = IniSettings.GetValue<string> ("Reservoir", "Custom_Name", "Reservoir Facility");
        Facility_Sprite [0] = IniSettings.GetValue<int> ("Reservoir", "Custom_Sprite", 590);
        Facility_Colour [0] = IniSettings.GetValue<int> ("Reservoir", "Custom_Colour", 1);
        if (Facility_Active [0]) {

            Facility_Number = 0;
            Facility = true;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        Facility_Active [1] = IniSettings.GetValue<bool> ("GSD1", "Active", false);
        Facility_Name [1] = IniSettings.GetValue<string> ("GSD1", "Custom_Name", "GSD1 Facility");
        Facility_Sprite [1] = IniSettings.GetValue<int> ("GSD1", "Custom_Sprite", 590);
        Facility_Colour [1] = IniSettings.GetValue<int> ("GSD1", "Custom_Colour", 1);
        if (Facility_Active [1]) {

            Facility_Number = 1;
            Facility = true;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        Facility_Active [2] = IniSettings.GetValue<bool> ("GSD2", "Active", false);
        Facility_Name [2] = IniSettings.GetValue<string> ("GSD2", "Custom_Name", "GSD2 Facility");
        Facility_Sprite [2] = IniSettings.GetValue<int> ("GSD2", "Custom_Sprite", 590);
        Facility_Colour [2] = IniSettings.GetValue<int> ("GSD2", "Custom_Colour", 1);
        if (Facility_Active [2]) {

            Facility_Number = 2;
            Facility = true;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        Facility_Active [3] = IniSettings.GetValue<bool> ("GSD3", "Active", false);
        Facility_Name [3] = IniSettings.GetValue<string> ("GSD3", "Custom_Name", "GSD3 Facility");
        Facility_Sprite [3] = IniSettings.GetValue<int> ("GSD3", "Custom_Sprite", 590);
        Facility_Colour [3] = IniSettings.GetValue<int> ("GSD3", "Custom_Colour", 1);
        if (Facility_Active [3]) {

            Facility_Number = 3;
            Facility = true;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        Facility_Active [4] = IniSettings.GetValue<bool> ("GSD4", "Active", false);
        Facility_Name [4] = IniSettings.GetValue<string> ("GSD4", "Custom_Name", "GSD4 Facility");
        Facility_Sprite [4] = IniSettings.GetValue<int> ("GSD4", "Custom_Sprite", 590);
        Facility_Colour [4] = IniSettings.GetValue<int> ("GSD4", "Custom_Colour", 1);
        if (Facility_Active [4]) {

            Facility_Number = 4;
            Facility = true;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        Facility_Active [5] = IniSettings.GetValue<bool> ("Zancudo_Lake", "Active", false);
        Facility_Name [5] = IniSettings.GetValue<string> ("Zancudo_Lake", "Custom_Name", "Zancudo_Lake Facility");
        Facility_Sprite [5] = IniSettings.GetValue<int> ("Zancudo_Lake", "Custom_Sprite", 590);
        Facility_Colour [5] = IniSettings.GetValue<int> ("Zancudo_Lake", "Custom_Colour", 1);
        if (Facility_Active [5]) {
            Facility_Number = 5;
            Facility = true;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        Facility_Active [6] = IniSettings.GetValue<bool> ("Zancudo_River", "Active", false);
        Facility_Name [6] = IniSettings.GetValue<string> ("Zancudo_River", "Custom_Name", "Zancudo_River Facility");
        Facility_Sprite [6] = IniSettings.GetValue<int> ("Zancudo_River", "Custom_Sprite", 590);
        Facility_Colour [6] = IniSettings.GetValue<int> ("Zancudo_River", "Custom_Colour", 1);
        if (Facility_Active [6]) {

            Facility_Number = 6;
            Facility = true;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        Facility_Active [7] = IniSettings.GetValue<bool> ("Pelato", "Active", false);
        Facility_Name [7] = IniSettings.GetValue<string> ("Pelato", "Custom_Name", "Pelato Facility");
        Facility_Sprite [7] = IniSettings.GetValue<int> ("Pelato", "Custom_Sprite", 590);
        Facility_Colour [7] = IniSettings.GetValue<int> ("Pelato", "Custom_Colour", 1);
        if (Facility_Active [7]) {

            Facility_Number = 7;
            Facility = true;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        Facility_Active [8] = IniSettings.GetValue<bool> ("Gordo", "Active", false);
        Facility_Name [8] = IniSettings.GetValue<string> ("Gordo", "Custom_Name", "Gordo Facility");
        Facility_Sprite [8] = IniSettings.GetValue<int> ("Gordo", "Custom_Sprite", 590);
        Facility_Colour [8] = IniSettings.GetValue<int> ("Gordo", "Custom_Colour", 1);
        if (Facility_Active [8]) {

            Facility_Number = 8;
            Facility = true;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////
        _modBlips = new List<Blip> ();
        GenerateBlips ();
        Tick += BlipsCreator_Tick;
        Tick += Route;
    }

    private void BlipsCreator_Tick (object sender, EventArgs e) {
        if (!_blipReloaded) {
            foreach (Blip bp in _modBlips) {
                if (!bp.Exists ()) {
                    GenerateBlips ();
                    _blipReloaded = true;
                    break;
                }
            }
        }
    }
    public void RemoveOther(Vector3 coords, int sprite){
        Blip bl = Function.Call<Blip>(Hash.GET_FIRST_BLIP_INFO_ID,sprite);
        while (Function.Call<bool>(Hash.DOES_BLIP_EXIST,bl)) {
            Vector3 coor = Function.Call<Vector3>(Hash.GET_BLIP_INFO_ID_COORD,bl);
            bool same = coords.Equals(coor);
            if(same)
                Function.Call(Hash.REMOVE_BLIP,bl);
            bl = Function.Call<Blip>(Hash.GET_NEXT_BLIP_INFO_ID,sprite);
        }
    }
    void NewBlip (Blip BlipName, int sprite, int colour, string name, bool ShortRange) {
        Vector3 coords = Function.Call<Vector3>(Hash.GET_BLIP_COORDS,BlipName);
        RemoveOther(coords,sprite);
            int length = name.Length;
            bool b2 = string.IsNullOrEmpty(name);
            Function.Call (Hash.SET_BLIP_SPRITE, BlipName, sprite);
            if (colour >= 0) Function.Call (Hash.SET_BLIP_COLOUR, BlipName, colour);
            if (!b2) { //lunghezza stringa
                Function.Call (Hash.BEGIN_TEXT_COMMAND_SET_BLIP_NAME, "STRING");
                Function.Call (Hash._ADD_TEXT_COMPONENT_STRING, name);
                Function.Call (Hash.END_TEXT_COMMAND_SET_BLIP_NAME, BlipName);
            }
            Function.Call (Hash.SET_BLIP_AS_SHORT_RANGE, BlipName, ShortRange);
            _modBlips.Add (BlipName);
    }
    void LoadAddBlips () {
        for (pos = 0; pos < 12; pos++) {
            AddBlipsCoords [pos] = new Vector3 ( (float)X_Blip[pos], (float)Y_Blip[pos], (float)Z_Blip[pos]);
            if (AddBlip [pos]) {
                AddedBlip [pos] = World.CreateBlip (AddBlipsCoords [pos]);
                NewBlip (AddedBlip [pos], Blip_Sptite [pos], Blip_Colour [pos], Blip_Name [pos], true);
            }
        }

    }
    void LoadLanguage () {
        LanguageNameBlip [0] = "Kanjali";
        LanguageNameBlip [1] = "MIG";
        LanguageNameBlip [2] = "Yatcht";
        LanguageNameBlip [4] = "IAA";
        LanguageNameBlip [6] = "Server Farm";
        LanguageNameBlip [10] = "Maze Bank Arena";
        LanguageNameBlip [11] = "Valkyrie";
        LanguageNameBlip [12] = "Fort Zancudo";
        LanguageNameBlip [13] = "Life Invader";
        LanguageNameBlip [15] = "FIB";
        LanguageNameBlip [16] = "Playboy";

        if (Language == "it") {
            LanguageNameBlip [3] = "Base Missilistica";
            LanguageNameBlip [5] = "Ufficio";
            LanguageNameBlip [7] = "Portaerei";
            LanguageNameBlip [8] = "Sottomarino";
            LanguageNameBlip [9] = "Laboratori Humane";
            LanguageNameBlip [14] = "Set Cinematografico";
            LanguageNameBlip [17] = "Prigione";
            LanguageNameBlip [18] = "Teatro";
            LanguageNameBlip [19] = "Osservatorio";
            LanguageNameBlip [20] = "Pompieri";
            LanguageNameBlip [21] = "Ippodromo";
            LanguageNameBlip [22] = "Banca";
            LanguageNameBlip [23] = "Casinò";
        }
        if (Language == "en") {
            LanguageNameBlip [3] = "Missile Base";
            LanguageNameBlip [5] = "Office";
            LanguageNameBlip [7] = "Aircraft Carrier";
            LanguageNameBlip [8] = "Submarine";
            LanguageNameBlip [9] = "Humane Lab";
            LanguageNameBlip [14] = "Movie Set";
            LanguageNameBlip [17] = "Prison";
            LanguageNameBlip [18] = "Theater";
            LanguageNameBlip [19] = "Observatory";
            LanguageNameBlip [20] = "Fire Station";
            LanguageNameBlip [21] = "Race Track";
            LanguageNameBlip [22] = "Bank";
            LanguageNameBlip [23] = "Casino";
        }
        if (Language == "es") {
            LanguageNameBlip [3] = "Base de misiles";                
            LanguageNameBlip [5] = "Office";                
            LanguageNameBlip [7] = "Portaaviones";                
            LanguageNameBlip [8] = "Submarino";                
            LanguageNameBlip [9] = "Laboratorios humanitarios";                
            LanguageNameBlip [14] = "Set de película";                
            LanguageNameBlip [17] = "Prisión";                
            LanguageNameBlip [18] = "Teatro";                
            LanguageNameBlip [19] = "Observatorio";                
            LanguageNameBlip [20] = "Bomberos";                
            LanguageNameBlip [21] = "Hipódromo";                
            LanguageNameBlip [22] = "Banco";                
            LanguageNameBlip [23] = "Casino";
        }
        if (Language == "fr") {
            LanguageNameBlip [3] = "Base de missile";                
            LanguageNameBlip [5] = "Bureau";                
            LanguageNameBlip [7] = "Porte-avions";                
            LanguageNameBlip [8] = "Sous-marin";                
            LanguageNameBlip [9] = "Laboratoires humanitaires";                
            LanguageNameBlip [14] = "Film défini";                
            LanguageNameBlip [17] = "Prison";                
            LanguageNameBlip [18] = "Théâtre";                
            LanguageNameBlip [19] = "Observatoire";                
            LanguageNameBlip [20] = "Pompiers";                
            LanguageNameBlip [21] = "Hippodrome";                
            LanguageNameBlip [22] = "Bank";                
            LanguageNameBlip [23] = "Casino";
        }
        if (Language == "de") {
            LanguageNameBlip [3] = "Raketenbasis";                
            LanguageNameBlip [5] = "Office";                
            LanguageNameBlip [7] = "Flugzeugträger";                
            LanguageNameBlip [8] = "U-Boot";                
            LanguageNameBlip [9] = "Humane Laboratories";                
            LanguageNameBlip [14] = "Filmset";                
            LanguageNameBlip [17] = "Gefängnis";                
            LanguageNameBlip [18] = "Theater";                
            LanguageNameBlip [19] = "Beobachtungsstelle";                
            LanguageNameBlip [20] = "Feuerwehr";                
            LanguageNameBlip [21] = "Hippodrom";                
            LanguageNameBlip [22] = "Bank";                
            LanguageNameBlip [23] = "Casino";
        }
    }
    private void GenerateBlips () {
        Player pl = Function.Call<Player>(Hash.GET_PLAYER_INDEX);
        _modBlips.Clear ();
        bool play = Function.Call<bool>(Hash.IS_PLAYER_PLAYING,pl);

        if (MODActive) {
            LoadLanguage ();
            LoadAddBlips ();
            if (Facility) {
                Blip FacilityBlip = World.CreateBlip (new Vector3 (_X_Facility [Facility_Number], _Y_Facility [Facility_Number], _Z_Facility [Facility_Number]));
                NewBlip (FacilityBlip, Facility_Sprite [Facility_Number], Facility_Colour [Facility_Number], Facility_Name [Facility_Number], true);
            }
            if (Persistence) {
                Blip batteria = World.CreateBlip (BatteriaCoords);
                NewBlip (batteria, 603, 1, "", true);

                Blip Avenger = World.CreateBlip (AvengerCoords);
                NewBlip (Avenger, 589, 1, "", true);

                Blip Kanjali = World.CreateBlip (KanjaliCoords);
                NewBlip (Kanjali, 598, 66, "", true);

                Blip mig = World.CreateBlip (MigCoords);
                NewBlip (mig, 16, 66, "", true);

                Blip Deluxo = World.CreateBlip (DeluxoCoords);
                NewBlip (Deluxo, 596, 1, "", true);

                Blip APC = World.CreateBlip (APCCoords);
                NewBlip (APC, 558, 1, "", true);

                Blip Ruiner = World.CreateBlip (RuinerCoords);
                NewBlip (Ruiner, 530, 1, "", true);

                Blip Apache = World.CreateBlip (ApacheCoords);
                NewBlip (Apache, 576, 1, "", true);
                
                Blip valkyrie = World.CreateBlip (ValkyrieCoords);
                NewBlip (valkyrie, 576, 1, LanguageNameBlip [11], true);
            }
            if (Online) {

                Blip Benny = World.CreateBlip (BennyCoords);
                NewBlip (Benny, 446, 48, "Benny's", true);

                Blip Yatch1 = World.CreateBlip (YatchCoords [0]);
                NewBlip (Yatch1, 455, 3, LanguageNameBlip [2], true);

                Blip Yatch2 = World.CreateBlip (YatchCoords [1]);
                NewBlip (Yatch2, 455, 3, LanguageNameBlip [2], true);

                Blip Base = World.CreateBlip (BaseCoords);
                NewBlip (Base, 548, 2, LanguageNameBlip [3], true);

                Blip IAA = World.CreateBlip (IAACoords);
                NewBlip (IAA, 564, 5, LanguageNameBlip [4], true);

                Blip Ufficio = World.CreateBlip (UfficioCoords);
                NewBlip (Ufficio, 475, 1, LanguageNameBlip [5], true);

                Blip Server = World.CreateBlip (ServerCoords);
                NewBlip (Server, 459, 2, LanguageNameBlip [6], true);

                Blip AircraftCarrier = World.CreateBlip (AircraftCarrierCoords);
                NewBlip (AircraftCarrier, 16, 66, LanguageNameBlip [7], true);

                Blip Sottomarino = World.CreateBlip (SottomarinoCoords);
                NewBlip (Sottomarino, 308, -1, LanguageNameBlip [8], true);
            }
            if (Special_Blip) {

                Blip Casino_Blip = World.CreateBlip (Casino);
                NewBlip (Casino_Blip, 680, 1, LanguageNameBlip [23], true);

                Blip Ippodromo = World.CreateBlip (IppodromoCoords);
                NewBlip (Ippodromo, 684, 6, LanguageNameBlip [21], true);

                Blip Bank = World.CreateBlip (BankCoords);
                NewBlip (Bank, 618, 5, LanguageNameBlip [22], true);

                Blip Lab = World.CreateBlip (LabCoords);
                NewBlip (Lab, 588, -1, LanguageNameBlip [9], true);

                Blip Maze = World.CreateBlip (MazeCoords);
                NewBlip (Maze, 102, -1, LanguageNameBlip [10], true);
                
                Blip Zancudo = World.CreateBlip (ZancudoCoords);
                NewBlip (Zancudo, 600, 66, LanguageNameBlip [12], true);

                Blip Life = World.CreateBlip (LifeCoords);
                NewBlip (Life, 521, -1, LanguageNameBlip [13], true);

                Blip Set = World.CreateBlip (SetCoords);
                NewBlip (Set, 135, -1, LanguageNameBlip [14], true);

                Blip FIB = World.CreateBlip (FIBCoords);
                NewBlip (FIB, 487, 3, LanguageNameBlip [15], true);

                Blip Playboy = World.CreateBlip (PlayboyCoords);
                NewBlip (Playboy, 279, -1, LanguageNameBlip [16], true);

                Blip Prigione = World.CreateBlip (PrigioneCoords);
                NewBlip (Prigione, 189, 42, LanguageNameBlip [17], true);

                Blip Teatro = World.CreateBlip (ThaterCoords [0]);
                NewBlip (Teatro, 102, -1, LanguageNameBlip [18], true);
                
                Blip Teatro2 = World.CreateBlip (ThaterCoords [1]);
                NewBlip (Teatro2, 102, -1, LanguageNameBlip [18], true);

                Blip Osservatorio = World.CreateBlip (OsservatorioCoords);
                NewBlip (Osservatorio, 468, 57, LanguageNameBlip [18], true);

            }
            if (Fire) {
                Blip Pompieri1 = World.CreateBlip (FireDepartment [0]);
                NewBlip (Pompieri1, 436, 17, LanguageNameBlip [20], true);

                Blip Pompieri2 = World.CreateBlip (FireDepartment [1]);
                NewBlip (Pompieri2, 436, 17, LanguageNameBlip [20], true);

                Blip Pompieri3 = World.CreateBlip (FireDepartment [2]);
                NewBlip (Pompieri3, 436, 17, LanguageNameBlip [20], true);

                Blip Pompieri4 = World.CreateBlip (FireDepartment [3]);
                NewBlip (Pompieri4, 436, 17, LanguageNameBlip [20], true);
            }

            if (Hospital) {
                Blip Hospital1 = World.CreateBlip (HospitalCoords [0]);
                NewBlip (Hospital1, 61, -1, "", true);

                Blip Hospital2 = World.CreateBlip (HospitalCoords [1]);
                NewBlip (Hospital2, 61, -1, "", true);

                Blip Hospital3 = World.CreateBlip (HospitalCoords [2]);
                NewBlip (Hospital3, 61, -1, "", true);

                Blip Hospital4 = World.CreateBlip (HospitalCoords [3]);
                NewBlip (Hospital4, 61, -1, "", true);

                Blip Hospital5 = World.CreateBlip (HospitalCoords [4]);
                NewBlip (Hospital5, 61, -1, "", true);
            }
            if (Police) {
                Blip Police1 = World.CreateBlip (PoliceCoords [0]);
                NewBlip (Police1, 60, -1, "", true);

                Blip Police2 = World.CreateBlip (PoliceCoords [1]);
                NewBlip (Police2, 60, -1, "", true);

                Blip Police3 = World.CreateBlip (PoliceCoords [2]);
                NewBlip (Police3, 60, -1, "", true);

                Blip Police4 = World.CreateBlip (PoliceCoords [3]);
                NewBlip (Police4, 60, -1, "", true);

                Blip Police5 = World.CreateBlip (PoliceCoords [4]);
                NewBlip (Police5, 60, -1, "", true);

                Blip Police6 = World.CreateBlip (PoliceCoords [5]);
                NewBlip (Police6, 60, -1, "", true);

                Blip Police7 = World.CreateBlip (PoliceCoords [6]);
                NewBlip (Police7, 60, -1, "", true);

                Blip Police8 = World.CreateBlip (PoliceCoords [7]);
                NewBlip (Police8, 60, -1, "", true);
            }
            
        }
    }
    public static Blip GetWaypointBlip () {
        if (!Game.IsWaypointActive) {
            return null;
        }

        for (int it = Function.Call<int> (Hash._GET_BLIP_INFO_ID_ITERATOR), blip = Function.Call<int> (Hash.GET_FIRST_BLIP_INFO_ID, it); Function.Call<bool> (Hash.DOES_BLIP_EXIST, blip); blip = Function.Call<int> (Hash.GET_NEXT_BLIP_INFO_ID, it)) {
            if (Function.Call<int> (Hash.GET_BLIP_INFO_ID_TYPE, blip) == 4) {
                return new Blip (blip);
            }
        }

        return null;
    }
    void get_hud (Vector3 blipcoords, int colour, int SpriteID) {
        if (Game.IsWaypointActive) {
            Vector3 waypointPos = World.GetWaypointPosition ();
            waypointPos.Z = 30f;
            if (World.GetDistance (waypointPos, blipcoords) <= 10) {
                hud_colour = colour;
                Xb = blipcoords.X;
                Yb = blipcoords.Y;
                GPS = true;
                Blip Waypoint = GetWaypointBlip ();
                Function.Call (Hash.SET_BLIP_SPRITE, Waypoint, SpriteID);
                Function.Call (Hash.SET_BLIP_COLOUR, Waypoint, colour);
                Function.Call (Hash.SET_BLIP_AS_FRIENDLY, Waypoint, true);
                Function.Call (Hash.SET_BLIP_SECONDARY_COLOUR, Waypoint, 66);
            }
        }
    }
    void colorized_hud (bool color) {
        if (color) {
            //////////RED
            get_hud (BatteriaCoords, 1, 603);
            get_hud (AvengerCoords, 1, 589);
            get_hud (DeluxoCoords, 1, 596);
            get_hud (APCCoords, 1, 558);
            get_hud (RuinerCoords, 1, 530);
            get_hud (ApacheCoords, 1, 576);
            get_hud (ValkyrieCoords, 1, 576);
            get_hud (UfficioCoords, 1, 475);
            ////////////////////////GREEN
            get_hud (HospitalCoords [0], 2, 61);
            get_hud (HospitalCoords [1], 2, 61);
            get_hud (HospitalCoords [2], 2, 61);
            get_hud (HospitalCoords [3], 2, 61);
            get_hud (HospitalCoords [4], 2, 61);
            get_hud (BaseCoords, 2, 548);
            get_hud (ServerCoords, 2, 459);
            ///////BLUE
            get_hud (PoliceCoords [0], 3, 60);
            get_hud (PoliceCoords [1], 3, 60);
            get_hud (PoliceCoords [2], 3, 60);
            get_hud (PoliceCoords [3], 3, 60);
            get_hud (PoliceCoords [4], 3, 60);
            get_hud (PoliceCoords [5], 3, 60);
            get_hud (PoliceCoords [6], 3, 60);
            get_hud (PoliceCoords [7], 3, 60);
            get_hud (YatchCoords [0], 3, 455);
            get_hud (YatchCoords [1], 3, 455);
            get_hud (PrigioneCoords, 3, 189);
            get_hud (SetCoords, 3, 135);
            get_hud (FIBCoords, 3, 487);
            get_hud (OsservatorioCoords, 3, 468);
            ////////////WHITE
            get_hud (LifeCoords, 4, 521);
            get_hud (LabCoords, 4, 588);
            ///////////ORANGE
            get_hud (FireDepartment [0], 17, 436);
            get_hud (FireDepartment [1], 17, 436);
            get_hud (FireDepartment [2], 17, 436);
            get_hud (FireDepartment [3], 17, 436);
            get_hud (BennyCoords, 17, 446);
            get_hud (IppodromoCoords, 17, 684);
            ///////////PINK
            get_hud (PlayboyCoords, 34, 279);
            ///////////YELLOW
            get_hud (MigCoords, 66, 16);
            get_hud (KanjaliCoords, 66, 598);
            get_hud (AircraftCarrierCoords, 66, 16);
            get_hud (SottomarinoCoords, 66, 308);
            get_hud (ZancudoCoords, 66, 600);
            get_hud (IAACoords, 66, 564);
            get_hud (BankCoords, 66, 618);
            ///////////PURPLE
            get_hud (MazeCoords, 83, 102);
            get_hud (ThaterCoords [1], 83, 102);
            get_hud (ThaterCoords [0], 83, 102);
        }
        else {
            //////////RED
            get_hud (BatteriaCoords, 1, 8);
            get_hud (AvengerCoords, 1, 8);
            get_hud (DeluxoCoords, 1, 8);
            get_hud (APCCoords, 1, 8);
            get_hud (RuinerCoords, 1, 8);
            get_hud (ApacheCoords, 1, 8);
            get_hud (ValkyrieCoords, 1, 8);
            get_hud (UfficioCoords, 1, 8);
            get_hud (Casino, 1, 8);
            ////////////////////////GREEN
            get_hud (HospitalCoords [0], 2, 8);
            get_hud (HospitalCoords [1], 2, 8);
            get_hud (HospitalCoords [2], 2, 8);
            get_hud (HospitalCoords [3], 2, 8);
            get_hud (HospitalCoords [4], 2, 8);
            get_hud (BaseCoords, 2, 8);
            get_hud (ServerCoords, 2, 8);
            ///////BLUE
            get_hud (PoliceCoords [0], 3, 8);
            get_hud (PoliceCoords [1], 3, 8);
            get_hud (PoliceCoords [2], 3, 8);
            get_hud (PoliceCoords [3], 3, 8);
            get_hud (PoliceCoords [4], 3, 8);
            get_hud (PoliceCoords [5], 3, 8);
            get_hud (PoliceCoords [6], 3, 8);
            get_hud (PoliceCoords [7], 3, 8);
            get_hud (YatchCoords [0], 3, 8);
            get_hud (YatchCoords [1], 3, 8);
            get_hud (PrigioneCoords, 3, 8);
            get_hud (SetCoords, 3, 8);
            get_hud (FIBCoords, 3, 8);
            get_hud (OsservatorioCoords, 3, 8);
            ////////////WHITE
            get_hud (LifeCoords, 4, 8);
            get_hud (LabCoords, 4, 8);
            ///////////ORANGE
            get_hud (FireDepartment [0], 17, 8);
            get_hud (FireDepartment [1], 17, 8);
            get_hud (FireDepartment [2], 17, 8);
            get_hud (FireDepartment [3], 17, 8);
            get_hud (BennyCoords, 17, 8);
            get_hud (IppodromoCoords, 17, 8);
            ///////////PINK
            get_hud (PlayboyCoords, 34, 8);
            ///////////YELLOW
            get_hud (MigCoords, 66, 8);
            get_hud (KanjaliCoords, 66, 8);
            get_hud (AircraftCarrierCoords, 66, 8);
            get_hud (SottomarinoCoords, 66, 8);
            get_hud (ZancudoCoords, 66, 8);
            get_hud (IAACoords, 66, 8);
            get_hud (BankCoords, 66, 8);
            ///////////PURPLE
            get_hud (MazeCoords, 83, 8);
            get_hud (ThaterCoords [1], 83, 8);
            get_hud (ThaterCoords [0], 83, 8);
        }
    }
    void Route (object sender, EventArgs e) {
        Vector3 waypointPos;
        Function.Call (Hash.SET_IGNORE_NO_GPS_FLAG, true);
        if ((Game.IsWaypointActive) && GPSColour) {
            GPS = false;
            waypointPos = World.GetWaypointPosition ();
            waypointPos.Z = 30f;
            Xb = waypointPos.X;
            Yb = waypointPos.Y;
            colorized_hud (GPSSprite);
            switch (hud_colour) {
                case 0: //default
                    {
                        Function.Call (Hash._0xF314CF4F0211894E, 142, 164, 76, 242, 255);
                        hud1 = 0;
                        break;
                    }
                case 1: //red
                    {
                        Function.Call (Hash._0xF314CF4F0211894E, 142, 224, 50, 50, 255);
                        hud1 = 1;
                        break;
                    }
                case 2: //green
                    {
                        Function.Call (Hash._0xF314CF4F0211894E, 142, 114, 204, 114, 255);
                        hud1 = 2;
                        break;
                    }
                case 3: //blue
                    {
                        Function.Call (Hash._0xF314CF4F0211894E, 142, 93, 182, 229, 255);
                        hud1 = 3;
                        break;
                    }
                case 4: //white
                    {
                        Function.Call (Hash._0xF314CF4F0211894E, 142, 240, 240, 240, 255);
                        hud1 = 4;
                        break;
                    }
                case 17: //orange
                    {
                        Function.Call (Hash._0xF314CF4F0211894E, 142, 255, 133, 85, 255);
                        hud1 = 17;
                        break;
                    }
                case 34: //pink
                    {
                        Function.Call (Hash._0xF314CF4F0211894E, 142, 203, 54, 148, 255);
                        hud1 = 34;
                        break;
                    }
                case 66: //yellow
                    {
                        Function.Call (Hash._0xF314CF4F0211894E, 142, 240, 160, 0, 255);
                        hud1 = 66;
                        break;
                    }
                case 83: //purple
                    {
                        Function.Call (Hash._0xF314CF4F0211894E, 142, 132, 102, 226, 255);
                        hud1 = 83;
                        break;
                    }
                default:
                    {
                        hud1 = -110;
                        break;
                    }
            }
            if ((hud1 != hud2) && (hud1 != -110)) {
                Function.Call (Hash.SET_WAYPOINT_OFF);
                Function.Call (Hash.SET_NEW_WAYPOINT, Xb, Yb);
                Function.Call (Hash._0xF314CF4F0211894E, 142, 164, 76, 242, 255);
            }
            hud2 = hud1;
        }
    }
}