using TMPro;
using UnityEngine;

namespace _Scripts.Features.UpdateScore
{
    public class UpdateScoreView: MonoBehaviour
    {
        private int _curScore;
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void UpdateScore(int score)
        {
            _curScore += score;
            _scoreText.text = _curScore.ToString();
        }
    }
}