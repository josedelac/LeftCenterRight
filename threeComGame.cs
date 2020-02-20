using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace CST343Project
{
    //Jesse Delacruz
    public partial class threeComGame : Form
    {
        int totalChipCount = 12;
        int playerChipCount = 3;

        Random random = new Random();

        //create computer objects with 3 chips each
        ComputerPlayer com1 = new ComputerPlayer("Computer1", 3);
        ComputerPlayer com2 = new ComputerPlayer("Computer2", 3);
        ComputerPlayer com3 = new ComputerPlayer("Computer3", 3);



        ComputerPlayer computerPlayer = ComputerPlayer.LoadFromFile("Computer.xml");

        public threeComGame()
        {
            InitializeComponent();

            hideImages();
            hideChips();

            C1TurnLabel.Hide();
            C2TurnLabel.Hide();
            C3TurnLabel.Hide();
            Skip.Hide();

            //show starting chips for each player at beginning of game
            //player chips
            HPC1.Show();
            HPC2.Show();
            HPC3.Show();
            //computer1 chips
            C1C1.Show();
            C1C2.Show();
            C1C3.Show();
            //computer2 chips
            C2C1.Show();
            C2C2.Show();
            C2C3.Show();
            //computer3 chips
            C3C1.Show();
            C3C2.Show();
            C3C3.Show();

            
        }

        //set bet amount only allow integer value
        private void BetTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a number and click 'set bet'");
            }
        }

        int userBet;
        private void BetButton_Click(object sender, EventArgs e)
        {
            userBet = Convert.ToInt32(value: betTextBox.Text);
            betTextBox.Hide();
            betLabel.Hide();
            betButton.Hide();

            //show beginning dice and button to roll them
            //three dice maximun during game
            firstDie.Show();
            secondDie.Show();
            thirdDie.Show();
            rollButton.Show();
        }

        public async void RollButton_Click(object sender, EventArgs e)
        {   
            //must be atleast one chip to continue game
            if (totalChipCount > 0)
            {
                //check how many chips player has
                //roll dice for amount of chips <= 3
                switch (playerChipCount)
                {
                    case 0:
                        firstDie.Hide();
                        secondDie.Hide();
                        thirdDie.Hide();
                        MessageBox.Show("You have no chips. Turn skipped!");
                        showChips();
                        break;
                    case 1: //roll 1st die
                        firstDie.Hide();
                        thirdDie.Hide();
                        playerSecondRoll();
                        showChips();
                        break;
                    case 2: //roll 1st and 2nd dice
                        thirdDie.Hide();
                        playerFirstRoll(); 
                        playerSecondRoll(); 
                        showChips();
                        break;
                    case 3: //roll all 3 dice
                        playerFirstRoll();
                        playerSecondRoll();
                        playerThirdRoll();
                        showChips();
                        break;
                    default: //player has more than 3 chips, only roll 3 dice
                        playerFirstRoll();
                        playerSecondRoll();
                        playerThirdRoll();
                        showChips();
                        break;
                }


                rollButton.Hide();
                await Task.Delay(1000);
                C1TurnLabel.Show();
                await Task.Delay(1000);
                firstDie.Show();
                secondDie.Show();
                thirdDie.Show();

                //computer 1's turn to roll dice per chip <= 3
                switch (com1.ChipCount)
                {
                    case 0:
                        firstDie.Hide();
                        secondDie.Hide();
                        thirdDie.Hide();
                        Skip.Show();
                        break;
                    case 1:
                        firstDie.Hide();
                        thirdDie.Hide();
                        computer1SecondRoll();
                        showChips();
                        break;
                    case 2:
                        thirdDie.Hide();
                        computer1FirstRoll();
                        computer1SecondRoll();
                        showChips();
                        break;
                    case 3:
                        computer1FirstRoll();
                        computer1SecondRoll();
                        computer1ThirdRoll();
                        showChips();
                        break;
                    default:
                        computer1FirstRoll();
                        computer1SecondRoll();
                        computer1ThirdRoll();
                        showChips();
                        break;
                }

                //pause to show chip movement and wait for next turn
                await Task.Delay(2000);
                Skip.Hide();
                C1TurnLabel.Hide();
                C2TurnLabel.Show();
                await Task.Delay(1000);
                firstDie.Show();
                secondDie.Show();
                thirdDie.Show();

                //computer 2's turn to roll dice per chip <= 3
                switch (com2.ChipCount)
                {
                    case 0:
                        firstDie.Hide();
                        secondDie.Hide();
                        thirdDie.Hide();
                        Skip.Show();
                        break;
                    case 1:
                        firstDie.Hide();
                        thirdDie.Hide();
                        computer2SecondRoll();
                        showChips();
                        break;
                    case 2:
                        thirdDie.Hide();
                        computer2FirstRoll();
                        computer2SecondRoll();
                        showChips();
                        break;
                    case 3:
                        computer2FirstRoll();
                        computer2SecondRoll();
                        computer2ThirdRoll();
                        showChips();
                        break;
                    default:
                        computer2FirstRoll();
                        computer2SecondRoll();
                        computer2ThirdRoll();
                        showChips();
                        break;
                }

                //pause to show chip movement and wait for next turn
                await Task.Delay(2000);
                Skip.Hide();
                C2TurnLabel.Hide();
                C3TurnLabel.Show();
                await Task.Delay(1000);
                firstDie.Show();
                secondDie.Show();
                thirdDie.Show();

                //computer 3's turn to roll dice per chip <= 3
                switch (com3.ChipCount)
                {
                    case 0:
                        firstDie.Hide();
                        secondDie.Hide();
                        thirdDie.Hide();
                        Skip.Show();
                        break;
                    case 1:
                        firstDie.Hide();
                        thirdDie.Hide();
                        computer3SecondRoll();
                        showChips();
                        break;
                    case 2:
                        thirdDie.Hide();
                        computer3FirstRoll();
                        computer3SecondRoll();
                        showChips();
                        break;
                    case 3:
                        computer3FirstRoll();
                        computer3SecondRoll();
                        computer3ThirdRoll();
                        showChips();
                        break;
                    default:
                        computer3FirstRoll();
                        computer3SecondRoll();
                        computer3ThirdRoll();
                        showChips();
                        break;
                }

                //pause then show chips left in game after round is done
                await Task.Delay(1000);
                C3TurnLabel.Hide();
                Skip.Hide();
                await Task.Delay(1000);
                MessageBox.Show("Total Chips: " + totalChipCount);
                firstDie.Show();
                secondDie.Show();
                thirdDie.Show();
                rollButton.Show();
            }
            else
            {
                //game ended with no chips left
                rollButton.Hide();
                MessageBox.Show("This game is a draw!");
            }
        }

        //player rolls first die
        private void playerFirstRoll()
        {
            //set four outcomes for dice
            int playerFirstRoll = random.Next(0, 4);

            switch (playerFirstRoll)
            {

                case 0: //player rolled (L) and passes chip to player on left
                    firstDie.Image = leftDie.Image;
                    playerChipCount = playerChipCount - 1;
                    com3.ChipCount = com3.ChipCount + 1;
                    break;
                case 1://player rolled (C) and keeps chip
                    firstDie.Image = centerDie.Image;
                    playerChipCount = playerChipCount - 0;
                    break;
                case 2://player rolled (R) and passes chip to player on right
                    firstDie.Image = rightDie.Image;
                    playerChipCount = playerChipCount - 1;
                    com1.ChipCount = com1.ChipCount + 1;
                    break;
                case 3://player rolled (Circle) and chip is entirely out of the game
                    firstDie.Image = circleDie.Image;
                    playerChipCount = playerChipCount - 1;
                    totalChipCount = totalChipCount - 1;
                    break;
            }
        }

        //player roll second die
        private void playerSecondRoll()
        {
            //set four outcomes for dice
            int playerSecondRoll = random.Next(0, 4);

            switch (playerSecondRoll)
            {
                case 0://player rolled (L) and passes chip to player on left
                    secondDie.Image = leftDie.Image;
                    playerChipCount = playerChipCount - 1;
                    com3.ChipCount = com3.ChipCount + 1;
                    break;
                case 1://player rolled (C) and keeps chip
                    secondDie.Image = centerDie.Image;
                    playerChipCount = playerChipCount - 0;
                    if (totalChipCount == 1)
                    {
                        MessageBox.Show("You win " + (userBet * 4) + "!");
                        Thread.Sleep(Timeout.Infinite);
                    }
                    break;
                case 2://player rolled (R) and passes chip to player on right
                    secondDie.Image = rightDie.Image;
                    playerChipCount = playerChipCount - 1;
                    com1.ChipCount = com1.ChipCount + 1;
                    break;
                case 3://player rolled (Circle) and chip is entirely out of the game unless last chip
                    secondDie.Image = circleDie.Image;
                    if (totalChipCount == 1)
                    {
                        playerChipCount = playerChipCount + 0;
                    }
                    else
                    {
                        playerChipCount = playerChipCount - 1;
                        totalChipCount = totalChipCount - 1;
                    }
                    break;
            }
        }

        private void playerThirdRoll()
        {
            //set four outcomes for dice
            int playerThirdRoll = random.Next(0, 4);

            switch (playerThirdRoll)
            {
                case 0://player rolled (L) and passes chip to player on left
                    thirdDie.Image = leftDie.Image;
                    playerChipCount = playerChipCount - 1;
                    com3.ChipCount = com3.ChipCount + 1;
                    break;
                case 1://player rolled (C) and keeps chip
                    thirdDie.Image = centerDie.Image;
                    playerChipCount = playerChipCount - 0;
                    break;
                case 2://player rolled (R) and passes chip to player on right
                    thirdDie.Image = rightDie.Image;
                    playerChipCount = playerChipCount - 1;
                    com1.ChipCount = com1.ChipCount + 1;
                    break;
                case 3://player rolled (Circle) and chip is entirely out of the game unless last chip
                    thirdDie.Image = circleDie.Image;
                    if (totalChipCount == 1)
                    {
                        playerChipCount = playerChipCount + 0;
                    }
                    else
                    {
                        playerChipCount = playerChipCount - 1;
                        totalChipCount = totalChipCount - 1;
                    }
                    break;
            }

        }

        private void computer1FirstRoll()
        {

            //-------------------------FIRST DIE ROLL---------------------------

            //set four outcomes for dice
            int computer1FirstRoll = random.Next(0, 4);

            switch (computer1FirstRoll)
            {
                case 0://player rolled (L) and passes chip to player on left
                    firstDie.Image = leftDie.Image;
                    com1.ChipCount = com1.ChipCount - 1;
                    playerChipCount = playerChipCount + 1;
                    break;
                case 1://player rolled (C) and keeps chip
                    firstDie.Image = centerDie.Image;
                    com1.ChipCount = com1.ChipCount - 0;
                    break;
                case 2://player rolled (R) and passes chip to player on right
                    firstDie.Image = rightDie.Image;
                    com1.ChipCount = com1.ChipCount - 1;
                    com2.ChipCount = com2.ChipCount + 1;
                    break;
                case 3://player rolled (Circle) and chip is entirely out of the game
                    firstDie.Image = circleDie.Image;
                    com1.ChipCount = com1.ChipCount - 1;
                    totalChipCount = totalChipCount - 1;
                    break;
            }

        }
        //-----------------------------SECOND DIE ROLL---------------------------

        private void computer1SecondRoll()
        {
            //set four outcomes for dice
            int computer1SecondRoll = random.Next(0, 4);

            switch (computer1SecondRoll)
            {
                case 0://player rolled (L) and passes chip to player on left
                    secondDie.Image = leftDie.Image;
                    com1.ChipCount = com1.ChipCount - 1;
                    playerChipCount = playerChipCount + 1;
                    break;
                case 1://player rolled (C) and keeps chip
                    secondDie.Image = centerDie.Image;
                    com1.ChipCount = com1.ChipCount - 0;
                    if (totalChipCount == 1)
                    {
                        MessageBox.Show("Computer 1 wins " + (userBet * 4) + "!");
                        Thread.Sleep(Timeout.Infinite);
                    }
                    break;
                case 2://player rolled (R) and passes chip to player on right
                    secondDie.Image = rightDie.Image;
                    com1.ChipCount = com1.ChipCount - 1;
                    com2.ChipCount = com2.ChipCount + 1;
                    break;
                case 3://player rolled (Circle) and chip is entirely out of the game unless last chip
                    secondDie.Image = circleDie.Image;
                    if (totalChipCount == 1)
                    {
                        playerChipCount = playerChipCount + 0;
                    }
                    else
                    {
                        com1.ChipCount = com1.ChipCount - 1;
                        totalChipCount = totalChipCount - 1;
                    }
                    break;
            }
        }

        private void computer1ThirdRoll()
        {
            //-----------------------------THIRD DIE ROLL---------------------------

            //set four outcomes for dice
            int computer1ThirdRoll = random.Next(0, 4);

            switch (computer1ThirdRoll)
            {
                case 0://player rolled (L) and passes chip to player on left
                    thirdDie.Image = leftDie.Image;
                    com1.ChipCount = com1.ChipCount - 1;
                    playerChipCount = playerChipCount + 1;
                    break;
                case 1://player rolled (C) and keeps chip
                    thirdDie.Image = centerDie.Image;
                    com1.ChipCount = com1.ChipCount - 0;
                    break;
                case 2://player rolled (R) and passes chip to player on right
                    thirdDie.Image = rightDie.Image;
                    com1.ChipCount = com1.ChipCount - 1;
                    com2.ChipCount = com2.ChipCount + 1;
                    break;
                case 3://player rolled (Circle) and chip is entirely out of the game unless last chip
                    thirdDie.Image = circleDie.Image;
                    if (totalChipCount == 1)
                    {
                        playerChipCount = playerChipCount + 0;
                    }
                    else
                    {
                        com1.ChipCount = com1.ChipCount - 1;
                        totalChipCount = totalChipCount - 1;
                    }
                    break;
            }
        }

        private void computer2FirstRoll()
        {
            //-----------------------------FIRST DIE ROLL---------------------------

            //set four outcomes for dice
            int computer2FirstRoll = random.Next(0, 4);

            switch (computer2FirstRoll)
            {
                case 0://player rolled (L) and passes chip to player on left
                    firstDie.Image = leftDie.Image;
                    com2.ChipCount = com2.ChipCount - 1;
                    com1.ChipCount = com1.ChipCount + 1;
                    break;
                case 1://player rolled (C) and keeps chip
                    firstDie.Image = centerDie.Image;
                    com2.ChipCount = com2.ChipCount - 0;
                    break;
                case 2://player rolled (R) and passes chip to player on right
                    firstDie.Image = rightDie.Image;
                    com2.ChipCount = com2.ChipCount - 1;
                    com3.ChipCount = com3.ChipCount + 1;
                    break;
                case 3://player rolled (Circle) and chip is entirely out of the game
                    firstDie.Image = circleDie.Image;
                    com2.ChipCount = com2.ChipCount - 1;
                    totalChipCount = totalChipCount - 1;
                    break;
            }
        }

        private void computer2SecondRoll()
        {
            //-----------------------------SECOND DIE ROLL---------------------------

            //set four outcomes for dice
            int computer2SecondRoll = random.Next(0, 4);

            switch (computer2SecondRoll)
            {
                case 0://player rolled (L) and passes chip to player on left
                    secondDie.Image = leftDie.Image;
                    com2.ChipCount = com2.ChipCount - 1;
                    com1.ChipCount = com1.ChipCount + 1;
                    break;
                case 1://player rolled (C) and keeps chip
                    secondDie.Image = centerDie.Image;
                    com2.ChipCount = com2.ChipCount - 0;
                    if (totalChipCount == 1)
                    {
                        MessageBox.Show("Computer 2 wins " + (userBet * 4) + "!");
                        Thread.Sleep(Timeout.Infinite);
                    }
                    break;
                case 2://player rolled (R) and passes chip to player on right
                    secondDie.Image = rightDie.Image;
                    com2.ChipCount = com2.ChipCount - 1;
                    com3.ChipCount = com3.ChipCount + 1;
                    break;
                case 3://player rolled (Circle) and chip is entirely out of the game unless last chip
                    secondDie.Image = circleDie.Image;
                    if (totalChipCount == 1)
                    {
                        playerChipCount = playerChipCount + 0; 
                    }
                    else
                    {
                        com2.ChipCount = com2.ChipCount - 1;
                        totalChipCount = totalChipCount - 1;
                    }
                    break;
            }

        }

        private void computer2ThirdRoll()
        {
            //-----------------------------THIRD DIE ROLL---------------------------

            //set four outcomes for dice
            int computer2ThirdRoll = random.Next(0, 4);

            switch (computer2ThirdRoll)
            {
                case 0://player rolled (L) and passes chip to player on left
                    thirdDie.Image = leftDie.Image;
                    com2.ChipCount = com2.ChipCount - 1;
                    com1.ChipCount = com1.ChipCount + 1;
                    break;
                case 1://player rolled (C) and keeps chip
                    thirdDie.Image = centerDie.Image;
                    com2.ChipCount = com2.ChipCount - 0;
                    break;
                case 2://player rolled (R) and passes chip to player on right
                    thirdDie.Image = rightDie.Image;
                    com2.ChipCount = com2.ChipCount - 1;
                    com3.ChipCount = com3.ChipCount + 1;
                    break;
                case 3://player rolled (Circle) and chip is entirely out of the game unless last chip
                    thirdDie.Image = circleDie.Image;
                    if (totalChipCount == 1)
                    {
                        playerChipCount = playerChipCount + 0;
                    }
                    else
                    {
                        com2.ChipCount = com2.ChipCount - 1;
                        totalChipCount = totalChipCount - 1;
                    }
                    break;
            }
        }

        private void computer3FirstRoll()
        {
            //-----------------------------FIRST DIE ROLL---------------------------

            //set four outcomes for dice
            int computer3FirstRoll = random.Next(0, 4);

            switch (computer3FirstRoll)
            {
                case 0://player rolled (L) and passes chip to player on left
                    firstDie.Image = leftDie.Image;
                    com3.ChipCount = com3.ChipCount - 1;
                    com2.ChipCount = com2.ChipCount + 1;
                    break;
                case 1://player rolled (C) and keeps chip
                    firstDie.Image = centerDie.Image;
                    com3.ChipCount = com3.ChipCount - 0;
                    break;
                case 2://player rolled (R) and passes chip to player on right
                    firstDie.Image = rightDie.Image;
                    com3.ChipCount = com3.ChipCount - 1;
                    playerChipCount = playerChipCount + 1;
                    break;
                case 3://player rolled (Circle) and chip is entirely out of the game
                    firstDie.Image = circleDie.Image;
                    com3.ChipCount = com3.ChipCount - 1;
                    totalChipCount = totalChipCount - 1;
                    break;
            }
        }

        private void computer3SecondRoll()
        {

            //-----------------------------SECOND DIE ROLL---------------------------

            //set four outcomes for dice
            int computer3SecondRoll = random.Next(0, 4);

            switch (computer3SecondRoll)
            {
                case 0://player rolled (L) and passes chip to player on left
                    secondDie.Image = leftDie.Image;
                    com3.ChipCount = com3.ChipCount - 1;
                    com2.ChipCount = com2.ChipCount + 1;
                    break;
                case 1://player rolled (C) and keeps chip
                    secondDie.Image = centerDie.Image;
                    com3.ChipCount = com3.ChipCount - 0;
                    if (totalChipCount == 1)
                    {
                        MessageBox.Show("Computer 3 wins " + (userBet * 4) + "!");
                        Thread.Sleep(Timeout.Infinite);
                    }
                    break;
                case 2://player rolled (R) and passes chip to player on right
                    secondDie.Image = rightDie.Image;
                    com3.ChipCount = com3.ChipCount - 1;
                    playerChipCount = playerChipCount + 1;
                    break;
                case 3://player rolled (Circle) and chip is entirely out of the game unless last chip
                    secondDie.Image = circleDie.Image;
                    if (totalChipCount == 1)
                    {
                        playerChipCount = playerChipCount + 0;
                    }
                    else
                    {
                        com3.ChipCount = com3.ChipCount - 1;
                        totalChipCount = totalChipCount - 1;
                    }

                    break;
            }
        }

        private void computer3ThirdRoll()
        {
            //-----------------------------THIRD DIE ROLL---------------------------

            //set four outcomes for dice
            int computer3ThirdRoll = random.Next(0, 4);

            switch (computer3ThirdRoll)
            {
                case 0://player rolled (L) and passes chip to player on left
                    thirdDie.Image = leftDie.Image;
                    com3.ChipCount = com3.ChipCount - 1;
                    com2.ChipCount = com2.ChipCount + 1;
                    break;
                case 1://player rolled (C) and keeps chip
                    thirdDie.Image = centerDie.Image;
                    com3.ChipCount = com3.ChipCount - 0;
                    break;
                case 2://player rolled (R) and passes chip to player on right
                    thirdDie.Image = rightDie.Image;
                    com3.ChipCount = com3.ChipCount - 1;
                    playerChipCount = playerChipCount + 1;
                    break;
                case 3://player rolled (Circle) and chip is entirely out of the game unless last chip
                    thirdDie.Image = circleDie.Image;
                    if (totalChipCount == 1)
                    {
                        playerChipCount = playerChipCount + 0;
                    }
                    else
                    {
                        com3.ChipCount = com3.ChipCount - 1;
                        totalChipCount = totalChipCount - 1;
                    }
                    break;
            }
        }

        private void showChips()
        {
            //Show the amount of chips the player has 
            switch (playerChipCount)
            {
                case 0:
                    HPC1.Hide();
                    HPC2.Hide();
                    HPC3.Hide();
                    HPC4.Hide();
                    HPC5.Hide();
                    HPC6.Hide();
                    HPC7.Hide();
                    HPC8.Hide();
                    HPC9.Hide();
                    HPC10.Hide();
                    HPC11.Hide();
                    HPC12.Hide();
                    break;
                case 1:
                    HPC1.Show();
                    HPC2.Hide();
                    HPC3.Hide();
                    HPC4.Hide();
                    HPC5.Hide();
                    HPC6.Hide();
                    HPC8.Hide();
                    HPC9.Hide();
                    HPC10.Hide();
                    HPC11.Hide();
                    HPC12.Hide();
                    break;
                case 2:
                    HPC1.Show();
                    HPC2.Show();
                    HPC3.Hide();
                    HPC4.Hide();
                    HPC5.Hide();
                    HPC6.Hide();
                    HPC7.Hide();
                    HPC8.Hide();
                    HPC9.Hide();
                    HPC10.Hide();
                    HPC11.Hide();
                    HPC12.Hide();
                    break;
                case 3:
                    HPC1.Show();
                    HPC2.Show();
                    HPC3.Show();
                    HPC4.Hide();
                    HPC5.Hide();
                    HPC6.Hide();
                    HPC7.Hide();
                    HPC8.Hide();
                    HPC9.Hide();
                    HPC10.Hide();
                    HPC11.Hide();
                    HPC12.Hide();
                    break;
                case 4:
                    HPC1.Show();
                    HPC2.Show();
                    HPC3.Show();
                    HPC4.Show();
                    HPC5.Hide();
                    HPC6.Hide();
                    HPC7.Hide();
                    HPC8.Hide();
                    HPC9.Hide();
                    HPC10.Hide();
                    HPC11.Hide();
                    HPC12.Hide();
                    break;
                case 5:
                    HPC1.Show();
                    HPC2.Show();
                    HPC3.Show();
                    HPC4.Show();
                    HPC5.Show();
                    HPC6.Hide();
                    HPC7.Hide();
                    HPC8.Hide();
                    HPC9.Hide();
                    HPC10.Hide();
                    HPC11.Hide();
                    HPC12.Hide();
                    break;
                case 6:
                    HPC1.Show();
                    HPC2.Show();
                    HPC3.Show();
                    HPC4.Show();
                    HPC5.Show();
                    HPC6.Show();
                    HPC7.Hide();
                    HPC8.Hide();
                    HPC9.Hide();
                    HPC10.Hide();
                    HPC11.Hide();
                    HPC12.Hide();
                    break;
                case 7:
                    HPC1.Show();
                    HPC2.Show();
                    HPC3.Show();
                    HPC4.Show();
                    HPC5.Show();
                    HPC6.Show();
                    HPC7.Show();
                    HPC8.Hide();
                    HPC9.Hide();
                    HPC10.Hide();
                    HPC11.Hide();
                    HPC12.Hide();
                    break;
                case 8:
                    HPC1.Show();
                    HPC2.Show();
                    HPC3.Show();
                    HPC4.Show();
                    HPC5.Show();
                    HPC6.Show();
                    HPC7.Show();
                    HPC8.Show();
                    HPC9.Hide();
                    HPC10.Hide();
                    HPC11.Hide();
                    HPC12.Hide();
                    break;
                case 9:
                    HPC1.Show();
                    HPC2.Show();
                    HPC3.Show();
                    HPC4.Show();
                    HPC5.Show();
                    HPC6.Show();
                    HPC7.Show();
                    HPC8.Show();
                    HPC9.Show();
                    HPC10.Hide();
                    HPC11.Hide();
                    HPC12.Hide();
                    break;
                case 10:
                    HPC1.Show();
                    HPC2.Show();
                    HPC3.Show();
                    HPC4.Show();
                    HPC5.Show();
                    HPC6.Show();
                    HPC7.Show();
                    HPC8.Show();
                    HPC9.Show();
                    HPC10.Show();
                    HPC11.Hide();
                    HPC12.Hide();
                    break;
                case 11:
                    HPC1.Show();
                    HPC2.Show();
                    HPC3.Show();
                    HPC4.Show();
                    HPC5.Show();
                    HPC6.Show();
                    HPC7.Show();
                    HPC8.Show();
                    HPC9.Show();
                    HPC10.Show();
                    HPC11.Show();
                    HPC12.Hide();
                    break;
                case 12:
                    HPC1.Show();
                    HPC2.Show();
                    HPC3.Show();
                    HPC4.Show();
                    HPC5.Show();
                    HPC6.Show();
                    HPC7.Show();
                    HPC8.Show();
                    HPC9.Show();
                    HPC10.Show();
                    HPC11.Show();
                    HPC12.Show();
                    break;
            }

            switch (com1.ChipCount)
            {
                case 0:
                    C1C1.Hide();
                    C1C2.Hide();
                    C1C3.Hide();
                    C1C4.Hide();
                    C1C5.Hide();
                    C1C6.Hide();
                    C1C7.Hide();
                    C1C8.Hide();
                    C1C9.Hide();
                    C1C10.Hide();
                    C1C11.Hide();
                    C1C12.Hide();
                    break;
                case 1:
                    C1C1.Show();
                    C1C2.Hide();
                    C1C3.Hide();
                    C1C4.Hide();
                    C1C5.Hide();
                    C1C6.Hide();
                    C1C8.Hide();
                    C1C9.Hide();
                    C1C10.Hide();
                    C1C11.Hide();
                    C1C12.Hide();
                    break;
                case 2:
                    C1C1.Show();
                    C1C2.Show();
                    C1C3.Hide();
                    C1C4.Hide();
                    C1C5.Hide();
                    C1C6.Hide();
                    C1C7.Hide();
                    C1C8.Hide();
                    C1C9.Hide();
                    C1C10.Hide();
                    C1C11.Hide();
                    C1C12.Hide();
                    break;
                case 3:
                    C1C1.Show();
                    C1C2.Show();
                    C1C3.Show();
                    C1C4.Hide();
                    C1C5.Hide();
                    C1C6.Hide();
                    C1C7.Hide();
                    C1C8.Hide();
                    C1C9.Hide();
                    C1C10.Hide();
                    C1C11.Hide();
                    C1C12.Hide();
                    break;
                case 4:
                    C1C1.Show();
                    C1C2.Show();
                    C1C3.Show();
                    C1C4.Show();
                    C1C5.Hide();
                    C1C6.Hide();
                    C1C7.Hide();
                    C1C8.Hide();
                    C1C9.Hide();
                    C1C10.Hide();
                    C1C11.Hide();
                    C1C12.Hide();
                    break;
                case 5:
                    C1C1.Show();
                    C1C2.Show();
                    C1C3.Show();
                    C1C4.Show();
                    C1C5.Show();
                    C1C6.Hide();
                    C1C7.Hide();
                    C1C8.Hide();
                    C1C9.Hide();
                    C1C10.Hide();
                    C1C11.Hide();
                    C1C12.Hide();
                    break;
                case 6:
                    C1C1.Show();
                    C1C2.Show();
                    C1C3.Show();
                    C1C4.Show();
                    C1C5.Show();
                    C1C6.Show();
                    C1C7.Hide();
                    C1C8.Hide();
                    C1C9.Hide();
                    C1C10.Hide();
                    C1C11.Hide();
                    C1C12.Hide();
                    break;
                case 7:
                    C1C1.Show();
                    C1C2.Show();
                    C1C3.Show();
                    C1C4.Show();
                    C1C5.Show();
                    C1C6.Show();
                    C1C7.Show();
                    C1C8.Hide();
                    C1C9.Hide();
                    C1C10.Hide();
                    C1C11.Hide();
                    C1C12.Hide();
                    break;
                case 8:
                    C1C1.Show();
                    C1C2.Show();
                    C1C3.Show();
                    C1C4.Show();
                    C1C5.Show();
                    C1C6.Show();
                    C1C7.Show();
                    C1C8.Show();
                    C1C9.Hide();
                    C1C10.Hide();
                    C1C11.Hide();
                    C1C12.Hide();
                    break;
                case 9:
                    C1C1.Show();
                    C1C2.Show();
                    C1C3.Show();
                    C1C4.Show();
                    C1C5.Show();
                    C1C6.Show();
                    C1C7.Show();
                    C1C8.Show();
                    C1C9.Show();
                    C1C10.Hide();
                    C1C11.Hide();
                    C1C12.Hide();
                    break;
                case 10:
                    C1C1.Show();
                    C1C2.Show();
                    C1C3.Show();
                    C1C4.Show();
                    C1C5.Show();
                    C1C6.Show();
                    C1C7.Show();
                    C1C8.Show();
                    C1C9.Show();
                    C1C10.Show();
                    C1C11.Hide();
                    C1C12.Hide();
                    break;
                case 11:
                    C1C1.Show();
                    C1C2.Show();
                    C1C3.Show();
                    C1C4.Show();
                    C1C5.Show();
                    C1C6.Show();
                    C1C7.Show();
                    C1C8.Show();
                    C1C9.Show();
                    C1C10.Show();
                    C1C11.Show();
                    C1C12.Hide();
                    break;
                case 12:
                    C1C1.Show();
                    C1C2.Show();
                    C1C3.Show();
                    C1C4.Show();
                    C1C5.Show();
                    C1C6.Show();
                    C1C7.Show();
                    C1C8.Show();
                    C1C9.Show();
                    C1C10.Show();
                    C1C11.Show();
                    C1C12.Show();
                    break;
            }


            switch (com2.ChipCount)
            {
                case 0:
                    C2C1.Hide();
                    C2C2.Hide();
                    C2C3.Hide();
                    C2C4.Hide();
                    C2C5.Hide();
                    C2C6.Hide();
                    C2C7.Hide();
                    C2C8.Hide();
                    C2C9.Hide();
                    C2C10.Hide();
                    C2C11.Hide();
                    C2C12.Hide();
                    break;
                case 1:
                    C2C1.Show();
                    C2C2.Hide();
                    C2C3.Hide();
                    C2C4.Hide();
                    C2C5.Hide();
                    C2C6.Hide();
                    C2C8.Hide();
                    C2C9.Hide();
                    C2C10.Hide();
                    C2C11.Hide();
                    C2C12.Hide();
                    break;
                case 2:
                    C2C1.Show();
                    C2C2.Show();
                    C2C3.Hide();
                    C2C4.Hide();
                    C2C5.Hide();
                    C2C6.Hide();
                    C2C7.Hide();
                    C2C8.Hide();
                    C2C9.Hide();
                    C2C10.Hide();
                    C2C11.Hide();
                    C2C12.Hide();
                    break;
                case 3:
                    C2C1.Show();
                    C2C2.Show();
                    C2C3.Show();
                    C2C4.Hide();
                    C2C5.Hide();
                    C2C6.Hide();
                    C2C7.Hide();
                    C2C8.Hide();
                    C2C9.Hide();
                    C2C10.Hide();
                    C2C11.Hide();
                    C2C12.Hide();
                    break;
                case 4:
                    C2C1.Show();
                    C2C2.Show();
                    C2C3.Show();
                    C2C4.Show();
                    C2C5.Hide();
                    C2C6.Hide();
                    C2C7.Hide();
                    C2C8.Hide();
                    C2C9.Hide();
                    C2C10.Hide();
                    C2C11.Hide();
                    C2C12.Hide();
                    break;
                case 5:
                    C2C1.Show();
                    C2C2.Show();
                    C2C3.Show();
                    C2C4.Show();
                    C2C5.Show();
                    C2C6.Hide();
                    C2C7.Hide();
                    C2C8.Hide();
                    C2C9.Hide();
                    C2C10.Hide();
                    C2C11.Hide();
                    C2C12.Hide();
                    break;
                case 6:
                    C2C1.Show();
                    C2C2.Show();
                    C2C3.Show();
                    C2C4.Show();
                    C2C5.Show();
                    C2C6.Show();
                    C2C7.Hide();
                    C2C8.Hide();
                    C2C9.Hide();
                    C2C10.Hide();
                    C2C11.Hide();
                    C2C12.Hide();
                    break;
                case 7:
                    C2C1.Show();
                    C2C2.Show();
                    C2C3.Show();
                    C2C4.Show();
                    C2C5.Show();
                    C2C6.Show();
                    C2C7.Show();
                    C2C8.Hide();
                    C2C9.Hide();
                    C2C10.Hide();
                    C2C11.Hide();
                    C2C12.Hide();
                    break;
                case 8:
                    C2C1.Show();
                    C2C2.Show();
                    C2C3.Show();
                    C2C4.Show();
                    C2C5.Show();
                    C2C6.Show();
                    C2C7.Show();
                    C2C8.Show();
                    C2C9.Hide();
                    C2C10.Hide();
                    C2C11.Hide();
                    C2C12.Hide();
                    break;
                case 9:
                    C2C1.Show();
                    C2C2.Show();
                    C2C3.Show();
                    C2C4.Show();
                    C2C5.Show();
                    C2C6.Show();
                    C2C7.Show();
                    C2C8.Show();
                    C2C9.Show();
                    C2C10.Hide();
                    C2C11.Hide();
                    C2C12.Hide();
                    break;
                case 10:
                    C2C1.Show();
                    C2C2.Show();
                    C2C3.Show();
                    C2C4.Show();
                    C2C5.Show();
                    C2C6.Show();
                    C2C7.Show();
                    C2C8.Show();
                    C2C9.Show();
                    C2C10.Show();
                    C2C11.Hide();
                    C2C12.Hide();
                    break;
                case 11:
                    C2C1.Show();
                    C2C2.Show();
                    C2C3.Show();
                    C2C4.Show();
                    C2C5.Show();
                    C2C6.Show();
                    C2C7.Show();
                    C2C8.Show();
                    C2C9.Show();
                    C2C10.Show();
                    C2C11.Show();
                    C2C12.Hide();
                    break;
                case 12:
                    C2C1.Show();
                    C2C2.Show();
                    C2C3.Show();
                    C2C4.Show();
                    C2C5.Show();
                    C2C6.Show();
                    C2C7.Show();
                    C2C8.Show();
                    C2C9.Show();
                    C2C10.Show();
                    C2C11.Show();
                    C2C12.Show();
                    break;
            }


            switch (com3.ChipCount)
            {
                case 0:
                    C3C1.Hide();
                    C3C2.Hide();
                    C3C3.Hide();
                    C3C4.Hide();
                    C3C5.Hide();
                    C3C6.Hide();
                    C3C7.Hide();
                    C3C8.Hide();
                    C3C9.Hide();
                    C3C10.Hide();
                    C3C11.Hide();
                    C3C12.Hide();
                    break;
                case 1:
                    C3C1.Show();
                    C3C2.Hide();
                    C3C3.Hide();
                    C3C4.Hide();
                    C3C5.Hide();
                    C3C6.Hide();
                    C3C8.Hide();
                    C3C9.Hide();
                    C3C10.Hide();
                    C3C11.Hide();
                    C3C12.Hide();
                    break;
                case 2:
                    C3C1.Show();
                    C3C2.Show();
                    C3C3.Hide();
                    C3C4.Hide();
                    C3C5.Hide();
                    C3C6.Hide();
                    C3C7.Hide();
                    C3C8.Hide();
                    C3C9.Hide();
                    C3C10.Hide();
                    C3C11.Hide();
                    C3C12.Hide();
                    break;
                case 3:
                    C3C1.Show();
                    C3C2.Show();
                    C3C3.Show();
                    C3C4.Hide();
                    C3C5.Hide();
                    C3C6.Hide();
                    C3C7.Hide();
                    C3C8.Hide();
                    C3C9.Hide();
                    C3C10.Hide();
                    C3C11.Hide();
                    C3C12.Hide();
                    break;
                case 4:
                    C3C1.Show();
                    C3C2.Show();
                    C3C3.Show();
                    C3C4.Show();
                    C3C5.Hide();
                    C3C6.Hide();
                    C3C7.Hide();
                    C3C8.Hide();
                    C3C9.Hide();
                    C3C10.Hide();
                    C3C11.Hide();
                    C3C12.Hide();
                    break;
                case 5:
                    C3C1.Show();
                    C3C2.Show();
                    C3C3.Show();
                    C3C4.Show();
                    C3C5.Show();
                    C3C6.Hide();
                    C3C7.Hide();
                    C3C8.Hide();
                    C3C9.Hide();
                    C3C10.Hide();
                    C3C11.Hide();
                    C3C12.Hide();
                    break;
                case 6:
                    C3C1.Show();
                    C3C2.Show();
                    C3C3.Show();
                    C3C4.Show();
                    C3C5.Show();
                    C3C6.Show();
                    C3C7.Hide();
                    C3C8.Hide();
                    C3C9.Hide();
                    C3C10.Hide();
                    C3C11.Hide();
                    C3C12.Hide();
                    break;
                case 7:
                    C3C1.Show();
                    C3C2.Show();
                    C3C3.Show();
                    C3C4.Show();
                    C3C5.Show();
                    C3C6.Show();
                    C3C7.Show();
                    C3C8.Hide();
                    C3C9.Hide();
                    C3C10.Hide();
                    C3C11.Hide();
                    C3C12.Hide();
                    break;
                case 8:
                    C3C1.Show();
                    C3C2.Show();
                    C3C3.Show();
                    C3C4.Show();
                    C3C5.Show();
                    C3C6.Show();
                    C3C7.Show();
                    C3C8.Show();
                    C3C9.Hide();
                    C3C10.Hide();
                    C3C11.Hide();
                    C3C12.Hide();
                    break;
                case 9:
                    C3C1.Show();
                    C3C2.Show();
                    C3C3.Show();
                    C3C4.Show();
                    C3C5.Show();
                    C3C6.Show();
                    C3C7.Show();
                    C3C8.Show();
                    C3C9.Show();
                    C3C10.Hide();
                    C3C11.Hide();
                    C3C12.Hide();
                    break;
                case 10:
                    C3C1.Show();
                    C3C2.Show();
                    C3C3.Show();
                    C3C4.Show();
                    C3C5.Show();
                    C3C6.Show();
                    C3C7.Show();
                    C3C8.Show();
                    C3C9.Show();
                    C3C10.Show();
                    C3C11.Hide();
                    C3C12.Hide();
                    break;
                case 11:
                    C3C1.Show();
                    C3C2.Show();
                    C3C3.Show();
                    C3C4.Show();
                    C3C5.Show();
                    C3C6.Show();
                    C3C7.Show();
                    C3C8.Show();
                    C3C9.Show();
                    C3C10.Show();
                    C3C11.Show();
                    C3C12.Hide();
                    break;
                case 12:
                    C3C1.Show();
                    C3C2.Show();
                    C3C3.Show();
                    C3C4.Show();
                    C3C5.Show();
                    C3C6.Show();
                    C3C7.Show();
                    C3C8.Show();
                    C3C9.Show();
                    C3C10.Show();
                    C3C11.Show();
                    C3C12.Show();
                    break;
            }
        }

        //hide all chips
        private void hideChips()
        {
            HPC1.Hide();
            HPC2.Hide();
            HPC3.Hide();
            HPC4.Hide();
            HPC5.Hide();
            HPC6.Hide();
            HPC7.Hide();
            HPC8.Hide();
            HPC9.Hide();
            HPC10.Hide();
            HPC11.Hide();
            HPC12.Hide();

            C1C1.Hide();
            C1C2.Hide();
            C1C3.Hide();
            C1C4.Hide();
            C1C5.Hide();
            C1C6.Hide();
            C1C7.Hide();
            C1C8.Hide();
            C1C9.Hide();
            C1C10.Hide();
            C1C11.Hide();
            C1C12.Hide();

            C2C1.Hide();
            C2C2.Hide();
            C2C3.Hide();
            C2C4.Hide();
            C2C5.Hide();
            C2C6.Hide();
            C2C7.Hide();
            C2C8.Hide();
            C2C9.Hide();
            C2C10.Hide();
            C2C11.Hide();
            C2C12.Hide();

            C3C1.Hide();
            C3C2.Hide();
            C3C3.Hide();
            C3C4.Hide();
            C3C5.Hide();
            C3C6.Hide();
            C3C7.Hide();
            C3C8.Hide();
            C3C9.Hide();
            C3C10.Hide();
            C3C11.Hide();
            C3C12.Hide();
        }

        private void hideImages()
        {
            firstDie.Hide();
            secondDie.Hide();
            thirdDie.Hide();
            leftDie.Hide();
            rightDie.Hide();
            centerDie.Hide();
            circleDie.Hide();
            rollButton.Hide();
        }
    }
    
}
