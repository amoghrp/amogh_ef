using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NumberPuzzleApplication
{
    public class PuzzleControl
    {
        #region Fields of the class
        Random rnd= new Random();
        #endregion

        /// <summary>
        /// Method to generate a random number
        /// </summary>
        /// <returns></returns>
        private int GetRandomNumber()
        {   
            return rnd.Next(17);
        }

        /// <summary>
        /// Method to change the value of the button when clicked
        /// </summary>
        /// <param name="emptyButton"></param>
        /// <param name="clicked"></param>
        private void SwapButton(Button emptyButton, Button clicked)
        {
            emptyButton.Text = clicked.Text;
            clicked.Text = "";
        }
        
        /// <summary>
        /// Method to get an array of integers for the buttons on the grid
        /// </summary>
        /// <param name="buttons"></param>
        /// <returns></returns>
        private int[] GetIntegerArrayOfButtonIds(Button[] buttons)
        {
            int[] buttonIds = new int[16];
            int id;
            for (int i = 0; i < 16; ++i)
            {
                if (int.TryParse(buttons[i].Text, out id))
                    buttonIds[i] = id;
                else
                    buttonIds[i] = 16;
            }
            return buttonIds;
        }

        
        //----------------------Public Methods to be filled by the participant------------


        /// <summary>
        /// Method to get random numbers to be displayed on the grid
        /// </summary>
        /// <returns></returns>
        public int[] GetRandomNumbersForGrid()
        {
            int[] arr = new int[16];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }

            //Logic to be filled by the participant
            Random r = new Random();
            for (int i = arr.Length - 1; i > 0; i--)
            {
                int j = r.Next(0, i - 1);
                int t = arr[j];
                arr[j] = arr[i];
                arr[i] = t;
            }

            return arr;
        }

        /// <summary>
        /// Method to swap the buttons when a number is clicked on the grid
        /// </summary>
        /// <param name="emptyCellId"></param>
        /// <param name="buttonClicked"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public int HandleButtonClicked(int emptyCellId, Button buttonClicked, Button[] buttons)
        {

            //Logic to be filled by the participant
            int buttonClicked_id = 0;
            for(int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i] == buttonClicked)
                {
                    buttonClicked_id = i;
                }
            }
            // index mapping from 1d to 2d
            // p, q => buttonClicked_id;
            // r, s => EmptyCellId;

            
            int p = buttonClicked_id / 4;
            int q = buttonClicked_id % 4; ;

            //empty cell id
            int r = emptyCellId / 4;
            int s = emptyCellId % 4;
            // call swap only if the emptyCellId and buttonClicked_id are adjacent
            if (r-1 == p && s == q)
            {
                SwapButton(buttons[emptyCellId], buttonClicked);
                emptyCellId = p * 4 + q % 4;
            }
            else if(r+1 == p && s == q)
            {
                SwapButton(buttons[emptyCellId], buttonClicked);
                emptyCellId = p * 4 + q % 4;
            }
            else if(s-1== q && p == r)
            {
                SwapButton(buttons[emptyCellId], buttonClicked);
                emptyCellId = p * 4 + q % 4;
            }
            else if (s+1 == q && p==r)
            {
                SwapButton(buttons[emptyCellId], buttonClicked);
                emptyCellId = p * 4 + q % 4;
            }

            /*
             * this is one more approach 
             * this can also be done
             * Button[,] button_matrix = new Button[4, 4];
            int k = 0;
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    button_matrix[i,j] = buttons[k];
                    k++;
                }
            }*/


            

            return emptyCellId;
        }

        /// <summary>
        /// Method to check for a winner of the game
        /// </summary>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public bool CheckForWinner(Button[] buttons)
        {
            bool winner = true;

            //Logic to be filled by the participant
            int[] arr = GetIntegerArrayOfButtonIds(buttons);
            for(int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] >= arr[i + 1])
                {
                    return false;
                }
            }


            return winner;
        }


    }
}
