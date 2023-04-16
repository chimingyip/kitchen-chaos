using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingForOtherPlayersUI : MonoBehaviour
{
    private void Start() {
        _GameManager.Instance.OnLocalPlayerReadyChanged += _GameManager_OnLocalPlayerReadyChanged;
        _GameManager.Instance.OnStateChanged += _GameManager_OnStateChanged;

        Hide();
    }

    private void _GameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (_GameManager.Instance.IsCountdownToStartActive()) {
            Hide();
        }
    }

    private void _GameManager_OnLocalPlayerReadyChanged(object sender, System.EventArgs e) {
        if (_GameManager.Instance.IsLocalPlayerReady()) {
            Show();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }
}
