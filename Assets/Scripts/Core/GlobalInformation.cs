using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GlobalInformation : MonoBehaviour
{
    // First Player Information
    private static int maxLocalHp = 3;
    private static int maxGlobalLifes = 3;
    private static int firstLevel = 1;
    private static int firstSublevel = 1;
    private static int normalGeneralVolume = 100;
    private static int normalMusicVolume = 100;

    // Level Info
    public static int LevelLoaded { get; private set; }
    public static int SubLevelLoaded { get; private set; }
    
    // Player Info
    public static int LocalRemainingHp { get; private set; }
    public static int GlobalRemainingLifes { get; private set; }
    
    // Settings Info
    public static int GeneralSoundVolume { get; private set; }
    public static int GeneralMusicVolume { get; private set; }
    
    // KEYS
    private const string KEY_Level = "CURR_LVL";
    private const string KEY_SubLevel = "CURR_SUBLVL";
    private const string KEY_LocalHp = "LCL_LFS";
    private const string KEY_GlobalLifes = "GLB_LFS";
    private const string KEY_SoundVol = "SND_VOL";
    private const string KEY_MusicVol = "MSC_VOL";
    
    #region INITIALIZATION

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        LoadPrefs();
    }

    private void LoadPrefs()
    {
        if(PlayerPrefs.HasKey(KEY_Level))
            LevelLoaded = PlayerPrefs.GetInt(KEY_Level);
        if(PlayerPrefs.HasKey(KEY_SubLevel))
            SubLevelLoaded = PlayerPrefs.GetInt(KEY_SubLevel);
        if(PlayerPrefs.HasKey(KEY_LocalHp))
            LocalRemainingHp = PlayerPrefs.GetInt(KEY_LocalHp);
        if(PlayerPrefs.HasKey(KEY_GlobalLifes))
            GlobalRemainingLifes = PlayerPrefs.GetInt(KEY_GlobalLifes);
        if(PlayerPrefs.HasKey(KEY_SoundVol))
            GeneralSoundVolume = PlayerPrefs.GetInt(KEY_SoundVol);
        if(PlayerPrefs.HasKey(KEY_MusicVol)) 
            GeneralMusicVolume = PlayerPrefs.GetInt(KEY_MusicVol);
    }

    #endregion

    // Level Info
    public static void UpgradeLevelCount()
    {
        if (PlayerPrefs.HasKey(KEY_Level))          
            PlayerPrefs.SetInt(KEY_Level, PlayerPrefs.GetInt(KEY_Level)+1);
        else
            PlayerPrefs.SetInt(KEY_Level, firstLevel);
            
        LevelLoaded = PlayerPrefs.GetInt(KEY_Level);
        PlayerPrefs.Save();
    }

    public static void UpgradeSublevelCount()
    {
        if (PlayerPrefs.HasKey(KEY_SubLevel))
            PlayerPrefs.SetInt(KEY_SubLevel, PlayerPrefs.GetInt(KEY_SubLevel)+1);
        else
            PlayerPrefs.SetInt(KEY_SubLevel, firstSublevel);

        
        if (PlayerPrefs.GetInt(KEY_SubLevel) > 4)
        {
            PlayerPrefs.SetInt(KEY_SubLevel, firstSublevel);
            UpgradeLevelCount();
        }
        
        SubLevelLoaded = PlayerPrefs.GetInt(KEY_SubLevel);
        PlayerPrefs.Save();
    }
    
    public static void ResetSublevelCount()
    {
        PlayerPrefs.SetInt(KEY_SubLevel, firstSublevel);
        SubLevelLoaded = PlayerPrefs.GetInt(KEY_SubLevel);
        PlayerPrefs.Save();
    }

    // Player Info
    public static void ChangeLocalHp(int amount)
    {
        if (PlayerPrefs.HasKey(KEY_LocalHp))
            PlayerPrefs.SetInt(KEY_LocalHp, amount);
        else
            PlayerPrefs.SetInt(KEY_LocalHp, maxLocalHp);
        
        LocalRemainingHp = PlayerPrefs.GetInt(KEY_LocalHp);
        PlayerPrefs.Save();
    }

    public static void ChangeGlobalLifes(int amount)
    {
        if (PlayerPrefs.HasKey(KEY_GlobalLifes))
            PlayerPrefs.SetInt(KEY_GlobalLifes, amount);
        else
            PlayerPrefs.SetInt(KEY_GlobalLifes, maxGlobalLifes);
        
        GlobalRemainingLifes = PlayerPrefs.GetInt(KEY_GlobalLifes);
        PlayerPrefs.Save();
    }
        
    // Settings Info
    public static void ChangeSoundVolume(int newVolume)
    {
        if (PlayerPrefs.HasKey(KEY_SoundVol))
            PlayerPrefs.SetInt(KEY_SoundVol, newVolume);
        else
            PlayerPrefs.SetInt(KEY_SoundVol, normalGeneralVolume);
        
        GeneralSoundVolume = PlayerPrefs.GetInt(KEY_SoundVol);
        PlayerPrefs.Save();
    }

    public static void ChangeMusicVolume(int newVolume)
    {
        if (PlayerPrefs.HasKey(KEY_MusicVol))
            PlayerPrefs.SetInt(KEY_MusicVol, newVolume);
        else
            PlayerPrefs.SetInt(KEY_MusicVol, normalMusicVolume);
        
        GeneralMusicVolume = PlayerPrefs.GetInt(KEY_MusicVol);
        PlayerPrefs.Save();
    }
}
