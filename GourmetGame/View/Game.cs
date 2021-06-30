using GourmetGame.Controllers;
using GourmetGame.Model.Enumeration;
using GourmetGame.View.Components;
using System;
using System.Windows.Forms;

namespace GourmetGame
{
    public partial class Game : Form
    {
        private GameController gameController;

        public Game()
        {
            InitializeComponent();
            gameController = new GameController();
        }

        private void StartGame(object sender, EventArgs e)
        {
            bool continueGame = true;

            do
            {
                var value = gameController.GetValue();
                var confirmResult = MessageBox.Show($"O prato que você pensou é {value}", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                var answer = confirmResult == DialogResult.Yes;
                var status = gameController.AnswerQuestion(answer);
                continueGame = GameAction(continueGame, status);

            } while (continueGame);
        }

        private bool GameAction(bool continueGame, GameStatus status)
        {
            switch (status)
            {
                case GameStatus.Winner:
                    MessageBox.Show($"Acertei de Novo!", "Jogo Gourmet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    continueGame = EndGame();
                    break;
                case GameStatus.Loser:
                    {
                        string meal;
                        string type;

                        meal = OpenDialogueMessage("Qual prato você pensou ?", "Desisto");
                        var question = gameController.GetQuestionDescription();               
                        type = OpenDialogueMessage($"{meal} é ________ mas {question} não.", "Complete");

                        gameController.Insert(meal, type);
                        continueGame = EndGame();
                        break;
                    }
            }

            return continueGame;
        }

        private string OpenDialogueMessage(string message, string formMessage)
        {
            string inputResult = "";

            using (DialogueMessage form = new(message, formMessage))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    inputResult = form.Result;
                    form.Close();
                }
            }

            return inputResult;
        }

        private bool EndGame()
        {
            gameController.RestartGame();
            return false;
        }
    }
}
