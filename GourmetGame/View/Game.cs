using GourmetGame.Controllers;
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
                var confirmResult = MessageBox.Show($"O prato que você pensou é {value}", "", MessageBoxButtons.YesNo);
                var answer = confirmResult == DialogResult.Yes;
                var status = gameController.AnswerQuestion(answer);

                if (status == Model.Enumeration.GameStatus.Winner)
                {
                    MessageBox.Show($"Acertei de Novo!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    continueGame = EndGame();
                }
                else if (status == Model.Enumeration.GameStatus.Loser)
                {
                    string meal = "null";
                    string type = "null";

                    using (DialogueMessage form = new DialogueMessage("Qual prato você pensou ?", "Desisto"))
                    {
                        var result = form.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            meal = form.Result;
                            form.Close();
                        }
                    }

                    var question = gameController.GetQuestionDescription();

                    using (DialogueMessage form = new DialogueMessage($"{meal} é ________ mas {question} não.", "Complete"))
                    {
                        var result = form.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            type = form.Result;
                        }
                    }

                    gameController.Insert(meal, type);
                    continueGame = EndGame();
                }

            } while (continueGame);
        }

        private bool EndGame()
        {
            gameController.RestartGame();
            return false;
        }
    }
}
