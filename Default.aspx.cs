using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected static char turn;
    protected static byte difficultyLevel = 1;
    protected static int turnCount, Wins = 0;
    protected static string user;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;

        b.Text = "X";
        turn = 'X';
        turnCount++;
        b.Enabled = false;


        computerMove();
    }
    protected bool chechForWinner()
    {
        bool winner = false;

        //Horizontal Check for winner
        if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            winner = true;
        else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            winner = true;
        else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            winner = true;

        //Vertical Check for winner
        else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            winner = true;
        else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            winner = true;
        else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            winner = true;

        //Diagonal Check for winner
        else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            winner = true;
        else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
            winner = true;

        if (winner)
        {
            if (turn == 'X')
            {
                labelWinner.Text = "Winner: X";
                Wins++;
                if (Wins > 1)
                {
                    winsInARow.Text = "Congratulations! You've won " + Wins + " number of times in a row.";
                }
                highscores();
            }
            else if (turn == 'O')
            {
                Wins = 0;
                labelWinner.Text = "Winner: O";
                winsInARow.Text = "";
            }
            else
            {
                Wins = 0;
            }
            disableButtons();
            return true;
        }

        else if (turnCount == 9)
        {
            labelWinner.Text = "Draw!";
            Wins = 0;
            winsInARow.Text = "";
            return true;
        }

        else
        {
            return false;
        }
    }

    protected void computerMove()
    {

        if (chechForWinner() == true)
        {
            return;
        }
        else
        {
            Button move = null;
            if (difficultyLevel == 1)
            {
                move = gameWinCondition("O");

                if (move == null)
                {
                    move = gameWinCondition("X");

                    if (move == null)
                    {
                        move = anyOpenCorner();
                        if (move == null)
                        {
                            move = anyOpenSpace();
                        }
                    }
                }
            }
            else if (difficultyLevel == 2)
            {
                move = gameWinCondition("O");

                if (move == null)
                {
                    move = gameWinCondition("X");

                    if (move == null)
                    {
                        move = centerPosition();
                        if (move == null)
                        {
                            move = anyOpenCorner();
                            if (move == null)
                            {
                                move = anyOpenSpace();
                            }
                        }
                    }
                }
            }
            try { move.Text = "O"; move.Enabled = false; }
            catch { }

            turnCount++;
            turn = 'O';

            chechForWinner();
        }
    }
    protected Button gameWinCondition(string mark) //Method to check for Game win positions
    {
        //Horizontal Row 1 check for winning move 
        if (A1.Text == mark && A2.Text == mark && A3.Text == "")
            return A3;
        if (A1.Text == mark && A2.Text == "" && A3.Text == mark)
            return A2;
        if (A1.Text == "" && A2.Text == mark && A3.Text == mark)
            return A1;

        //Horizontal Row 2 Check for winning move
        if (B1.Text == mark && B2.Text == mark && B3.Text == "")
            return B3;
        if (B1.Text == mark && B2.Text == "" && B3.Text == mark)
            return B2;
        if (B1.Text == "" && B2.Text == mark && B3.Text == mark)
            return B1;

        //Horizontal Row 3 Check for winning move
        if (C1.Text == mark && C2.Text == mark && C3.Text == "")
            return C3;
        if (C1.Text == mark && C2.Text == "" && C3.Text == mark)
            return C2;
        if (C1.Text == "" && C2.Text == mark && C3.Text == mark)
            return C1;

        //Vertical Column 1 Check for winning move
        if (A1.Text == mark && B1.Text == mark && C1.Text == "")
            return C1;
        if (A1.Text == mark && B1.Text == "" && C1.Text == mark)
            return B1;
        if (A1.Text == "" && B1.Text == mark && C1.Text == mark)
            return A1;

        //Vertical Column 2 Check for winning move
        if (A2.Text == mark && B2.Text == mark && C2.Text == "")
            return C2;
        if (A2.Text == mark && B2.Text == "" && C2.Text == mark)
            return B2;
        if (A2.Text == "" && B2.Text == mark && C2.Text == mark)
            return A2;

        //Vertical Column 2 Check for winning move
        if (A3.Text == mark && B3.Text == mark && C3.Text == "")
            return C3;
        if (A3.Text == mark && B3.Text == "" && C3.Text == mark)
            return B3;
        if (A3.Text == "" && B3.Text == mark && C3.Text == mark)
            return A3;

        //DIagonal 1 check for winning move
        if (A1.Text == mark && B2.Text == mark && C3.Text == "")
            return C3;
        if (A1.Text == mark && B2.Text == "" && C3.Text == mark)
            return B2;
        if (A1.Text == "" && B2.Text == mark && C3.Text == mark)
            return A1;

        //DIagonal 1 check for winning move
        if (A3.Text == mark && B2.Text == mark && C1.Text == "")
            return C1;
        if (A3.Text == mark && B2.Text == "" && C1.Text == mark)
            return B2;
        if (A3.Text == "" && B2.Text == mark && C1.Text == mark)
            return A3;

        return null;
    }
    protected Button centerPosition()//Method to check for open space in Center (B2)
    {
        if (B2.Text == "")
            return B2;
        else
            return null;
    }
    protected Button anyOpenSpace()//Method to check for any open space
    {
        if (A1.Text == "")
            return A1;
        else if (A2.Text == "")
            return A2;
        else if (A3.Text == "")
            return A3;
        else if (B1.Text == "")
            return B1;
        else if (B2.Text == "")
            return B2;
        else if (B3.Text == "")
            return B3;
        else if (C1.Text == "")
            return C1;
        else if (C2.Text == "")
            return C2;
        else if (C3.Text == "")
            return C3;
        else
            return null;
    }
    protected Button anyOpenCorner() //Method to check for any open corner
    {
        if (A1.Text == "O")
        {
            if (A3.Text == "")
                return A3;
            if (C3.Text == "")
                return C3;
            if (C1.Text == "")
                return C1;
        }

        if (A3.Text == "O")
        {
            if (A1.Text == "")
                return A1;
            if (C3.Text == "")
                return C3;
            if (C1.Text == "")
                return C1;
        }

        if (C3.Text == "O")
        {
            if (A1.Text == "")
                return A3;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
        }

        if (C1.Text == "O")
        {
            if (A1.Text == "")
                return A3;
            if (A3.Text == "")
                return A3;
            if (C3.Text == "")
                return C3;
        }

        if (A1.Text == "")
            return A1;
        if (A3.Text == "")
            return A3;
        if (C1.Text == "")
            return C1;
        if (C3.Text == "")
            return C3;

        return null;
    }

    protected void Reset_Button_Click(object sender, EventArgs e)
    {
        enableButtons();
        labelWinner.Text = "";
        turnCount = 0;
        winsInARow.Text = "";
    }
    protected void enableButtons()
    {
        A1.Enabled = true; A1.Text = "";
        A2.Enabled = true; A2.Text = "";
        A3.Enabled = true; A3.Text = "";

        B1.Enabled = true; B1.Text = "";
        B2.Enabled = true; B2.Text = "";
        B3.Enabled = true; B3.Text = "";

        C1.Enabled = true; C1.Text = "";
        C2.Enabled = true; C2.Text = "";
        C3.Enabled = true; C3.Text = "";

    }
    protected void disableButtons()
    {
        A1.Enabled = false;
        A2.Enabled = false;
        A3.Enabled = false;

        B1.Enabled = false;
        B2.Enabled = false;
        B3.Enabled = false;

        C1.Enabled = false;
        C2.Enabled = false;
        C3.Enabled = false;
    }


    protected void hard_Click(object sender, EventArgs e)
    {
        enableButtons();
        difficultyLevel = 1;
        difficultyLabel.Text = "Difficulty level: Hard";
        hard.Enabled = false; hard.Text = "";
        impossible.Enabled = false; impossible.Text = "";
        gameStartTextLabel.Text = "Make your move!";
        changeDifficulty.Enabled = true;
        changeDifficulty.Text = "Change";
    }

    protected void impossible_Click(object sender, EventArgs e)
    {
        enableButtons();
        difficultyLevel = 2;
        difficultyLabel.Text = "Difficulty level: Very Hard";
        hard.Enabled = false; hard.Text = "";
        impossible.Enabled = false; impossible.Text = "";
        gameStartTextLabel.Text = "Make your move!";
        changeDifficulty.Enabled = true;
        changeDifficulty.Text = "Change";
    }

    protected void changeDifficulty_Click(object sender, EventArgs e)
    {
        turnCount = 0; difficultyLevel = 0;
        difficultyLabel.Text = "Difficulty Level: ";
        enableButtons();
        disableButtons();
        hard.Enabled = true; hard.Text = "Hard";
        impossible.Enabled = true; impossible.Text = "Very Hard";
        labelWinner.Text = "";
        changeDifficulty.Enabled = false;
        changeDifficulty.Text = "";
    }
    protected void highscores()
    {
        if (Wins > 3)
        {
            switch (Wins)
            {
                case 4:
                    {
                        winsInARow.Text = "Congratulations! You've made a new high score! Enter name to save high score";
                        highscoreLabel.Text = "";
                        break;
                    }
                case 5:
                    {
                        winsInARow.Text = "";
                        highscoreLabel.Text = user + "'s new high score is " + Wins;
                        break;
                    }
                case 6:
                    {
                        winsInARow.Text = "";
                        highscoreLabel.Text = user + "'s new high score is " + Wins;
                        break;
                    }
                case 7:
                    {
                        winsInARow.Text = "";
                        highscoreLabel.Text = user + "'s new high score is " + Wins;
                        break;
                    }
                case 8:
                    {
                        winsInARow.Text = "";
                        highscoreLabel.Text = user + "'s new high score is " + Wins;
                        break;
                    }
            }
        }
        else
            return;
    }
}