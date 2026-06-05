using UnityEngine;
using UnityEngine.SceneManagement; // Tambahkan baris ini agar SceneManager berfungsi!

public class PauseManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject pauseButton; // Tombol II di pojok kanan atas
    public GameObject pauseMenu;   // Panel yang berisi Home, Restart, Resume

    void Start()
    {
        // Pastikan saat game mulai, menu tertutup dan tombol pause muncul
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    // Fungsi untuk tombol pause (II)
    public void PauseGame()
    {
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Menghentikan waktu game
    }

    // Fungsi untuk tombol resume (PlayBtn di dalam menu)
    public void ResumeGame()
    {
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Menjalankan waktu kembali
    }

    // Fungsi untuk kembali ke Menu Utama
    public void GoToHome()
    {
        Time.timeScale = 1f; // PENTING: Kembalikan waktu ke normal sebelum pindah scene
        if (scoremanager.instance != null) scoremanager.instance.ResetScore();
        SceneManager.LoadScene("MainMenu");
    }

    // Fungsi untuk mengulang Level (Restart)
    public void RestartLevel()
    {
        Time.timeScale = 1f; // PENTING: Kembalikan waktu ke normal agar game tidak macet saat restart

        // Reset score dulu agar UI dan state kembali ke 0
        if (scoremanager.instance != null) scoremanager.instance.ResetScore();

        // Mengambil nama scene yang sedang aktif saat ini agar otomatis
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}