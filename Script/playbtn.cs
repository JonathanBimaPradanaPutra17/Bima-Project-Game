using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement; // WAJIB TAMBAHKAN INI

public class playbtn : MonoBehaviour
{
    [Header("UIMenu")]
    public GameObject MainMenu;
    public GameObject LevelSelect;
    public GameObject SettingMenu;
    public GameObject InfoMenu;

    [Header("Audio")]
    public AudioSource bgm; // Variabel baru untuk menampung musik

    void Start()
    {
        // Hanya jalankan jika slotnya sudah diisi di Inspector
        if (MainMenu != null) MainMenu.SetActive(true);
        if (LevelSelect != null) LevelSelect.SetActive(false);
        if (SettingMenu != null) SettingMenu.SetActive(false);
        if (InfoMenu != null) InfoMenu.SetActive(false);
    }

    public void Play()
    {
        MainMenu.SetActive(false);
        LevelSelect.SetActive(true);
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        LevelSelect.SetActive(false);
    }

    public void SettingBtnOn()
    {
        SettingMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void SettingBtnOff()
    {
        SettingMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void InfoBtnOn()
    {
        InfoMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void InfoBtnOff()
    {
        InfoMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void SoundOnBtn()
    {
        // Menyalakan musik
        if (bgm != null) bgm.UnPause();
    }

    public void SoundOffBtn()
    {
        // Berhentikan musik
        if (bgm != null) bgm.Pause();
    }

    public void LoadLevel1()
    {
        Time.timeScale = 1f; // Tambahkan ini agar game tidak beku
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        Time.timeScale = 1f; // Tambahkan ini juga
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        Time.timeScale = 1f; // Dan ini
        SceneManager.LoadScene("Level3");
    }
}